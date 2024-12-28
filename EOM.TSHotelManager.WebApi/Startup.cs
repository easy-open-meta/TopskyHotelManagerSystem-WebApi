using Autofac;
using EOM.TSHotelManager.EntityFramework;
using EOM.TSHotelManager.Shared;
using EOM.TSHotelManager.WebApi.Filter;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;
using SqlSugar;
using System;
using System.IO;
using System.Reflection;
using System.Text;

namespace EOM.TSHotelManager.WebApi
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // 注册 SqlSugarClientFactory
            services.AddSingleton<ISqlSugarClientFactory, SqlSugarClientFactory>();

            // 配置 ISqlSugarClient 的生命周期
            services.AddScoped<ISqlSugarClient>(sp =>
            {
                var factory = sp.GetRequiredService<ISqlSugarClientFactory>();
                return factory.CreateClient();
            });

            // 注册泛型仓库
            services.AddScoped(typeof(GenericRepository<>));

            services.AddSingleton<IJwtConfigFactory, JwtConfigFactory>();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer("Bearer", options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = _configuration["Jwt:Issuer"],
                    ValidAudience = _configuration["Jwt:Audience"], // 设置有效的audience值
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]))
                };
            });

            services.AddAuthorization(options =>
            {
                // 定义一个名为“ApiAccess”的策略
                options.AddPolicy("ApiAccess", policy =>
                {
                    policy.AuthenticationSchemes.Add("Bearer");
                    policy.RequireAuthenticatedUser();
                });

                // 使用上面定义的“ApiAccess”策略作为默认策略
                options.DefaultPolicy = options.GetPolicy("ApiAccess");
            });


            services.AddControllers(options =>
            {
                options.Conventions.Add(new AuthorizeAllControllersConvention());
                options.RespectBrowserAcceptHeader = true;
            }).AddNewtonsoftJson(opt =>
            {
                //时间格式化响应
                opt.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
                opt.SerializerSettings.ContractResolver = new DefaultContractResolver();
            });

            #region 配置全局路由
            //在各个控制器添加前缀（没有特定的路由前面添加前缀）
            services.AddMvc(opt =>
            {
                opt.UseCentralRoutePrefix(new RouteAttribute("api/[controller]/[action]"));
            });
            #endregion

            #region 注册Swagger服务 
            services.AddSwaggerGen(s =>
            {
                #region 注册 Swagger
                s.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Title = "EOM.TSHotelManager.Web", //定义Swagger文档的名称
                    Version = "version-1.0.0", //定义Swagger文档的版本号
                    Description = "Api Document", //定义Swagger文档的描述
                    License = new OpenApiLicense()
                    {
                        Name = "MIT",
                        Url = new Uri("https://mit-license.org/")
                    }, //定义Swagger文档的开源授权协议
                    TermsOfService = new Uri("https://www.oscode.top/"), //定义Swagger文档的服务支持主页
                    Contact = new OpenApiContact
                    {
                        Name = "Easy-Open-Meta",
                        Email = "eom-official@oscode.top",
                        Url = new Uri("https://www.oscode.top/")
                    }
                });
                //获取同解决方案下各分层的xml注释，一般获取业务逻辑层、实体类和接口层即可
                s.IncludeXmlComments(AppContext.BaseDirectory + "EOM.TSHotelManager.Application.xml");
                s.IncludeXmlComments(AppContext.BaseDirectory + "EOM.TSHotelManager.Common.Core.xml");
                s.IncludeXmlComments(AppContext.BaseDirectory + "EOM.TSHotelManager.WebApi.xml");
                #endregion

                #region 正式发布时用
                //s.IncludeXmlComments("EOM.TSHotelManager.Application.xml");
                //s.IncludeXmlComments("EOM.TSHotelManager.Core.xml");
                //s.IncludeXmlComments("EOM.TSHotelManager.WebApi.xml");
                #endregion
            });
            #endregion

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            #region 使用Swagger中间件
            app.UseSwagger();
            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("/swagger/v1/swagger.json", "EOM.TSHotelManager Api Document");
            });
            #endregion

        }

        /// <summary>
        /// AutoFac
        /// </summary>
        /// <param name="builder"></param>
        public void ConfigureContainer(ContainerBuilder builder)
        {
            #region AutoFac IOC容器,实现批量依赖注入的容器
            try
            {
                builder.RegisterType<SqlSugarClientFactory>().As<ISqlSugarClientFactory>().SingleInstance();

                builder.Register(c =>
                {
                    var factory = c.Resolve<ISqlSugarClientFactory>();
                    return factory.CreateClient();
                }).As<ISqlSugarClient>().InstancePerLifetimeScope();

                builder.RegisterGeneric(typeof(GenericRepository<>)).InstancePerLifetimeScope();

                //程序集批量反射注入
                var assemblyService = Assembly.LoadFrom(Path.Combine(AppContext.BaseDirectory, "EOM.TSHotelManager.Application.dll"));
                builder.RegisterAssemblyTypes(assemblyService)
                    .AsImplementedInterfaces()
                    .InstancePerDependency()
                    .PropertiesAutowired();

                //注入加解密组件
                var encryptionService = Assembly.LoadFrom(Path.Combine(AppContext.BaseDirectory, "jvncorelib.EncryptorLib.dll"));
                builder.RegisterAssemblyTypes(encryptionService)
                    .PropertiesAutowired();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "\n" + ex.InnerException);
            }
            #endregion
        }


    }
}
