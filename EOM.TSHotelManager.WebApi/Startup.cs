using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.Threading.Tasks;
using Autofac;
using Autofac.Core;
using EOM.Encrypt;
using EOM.TSHotelManager.EntityFramework;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;

namespace EOM.TSHotelManager.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddCors(options =>
            //{
            //    options.AddDefaultPolicy(builder =>
            //    {
            //        builder
            //            .AllowAnyOrigin() // 允许任何来源域
            //            .AllowAnyMethod() // 允许任何HTTP方法
            //            .AllowAnyHeader()// 允许任何HTTP头部字段
            //            .AllowCredentials(); 
            //    });
            //});

            services.AddControllers().AddJsonOptions(opts =>
            {
                opts.JsonSerializerOptions.Encoder = JavaScriptEncoder.Create(UnicodeRanges.All);
                opts.JsonSerializerOptions.PropertyNamingPolicy = null;
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
                    Description = "接口文档", //定义Swagger文档的描述
                    License = new OpenApiLicense()
                    {
                        Name = "MIT",
                        Url = new Uri("https://mit-license.org/")
                    }, //定义Swagger文档的开源授权协议
                    TermsOfService = new Uri("https://www.oscode.top/"), //定义Swagger文档的服务支持主页
                    Contact = new OpenApiContact
                    {
                        Name = "易开元(Easy-Open-Meta)",
                        Email = "eom-official@oscode.top",
                        Url = new Uri("https://www.oscode.top/")
                    }
                });
                //获取同解决方案下各分层的xml注释，一般获取业务逻辑层、实体类和接口层即可
                s.IncludeXmlComments(AppContext.BaseDirectory+"EOM.TSHotelManager.Application.xml");
                s.IncludeXmlComments(AppContext.BaseDirectory+"EOM.TSHotelManager.Common.Core.xml");
                s.IncludeXmlComments(AppContext.BaseDirectory+"EOM.TSHotelManager.WebApi.xml");
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            #region 使用Swagger中间件
            app.UseSwagger();
            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("/swagger/v1/swagger.json", "EOM.TSHotelManager接口文档");
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
                //注入仓储
                builder.RegisterGeneric(typeof(PgRepository<>)).As(typeof(PgRepository<>));

                //程序集批量反射注入
                var assemblyService = Assembly.LoadFrom(Path.Combine(AppContext.BaseDirectory, "EOM.TSHotelManager.Application.dll"));
                builder.RegisterAssemblyTypes(assemblyService)
                    .AsImplementedInterfaces()
                    .InstancePerDependency()
                    .PropertiesAutowired();

                //注入加解密组件
                var encryptionService = Assembly.LoadFrom(Path.Combine(AppContext.BaseDirectory, "EOM.Encrypt.dll"));
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
