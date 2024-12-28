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
            // ע�� SqlSugarClientFactory
            services.AddSingleton<ISqlSugarClientFactory, SqlSugarClientFactory>();

            // ���� ISqlSugarClient ����������
            services.AddScoped<ISqlSugarClient>(sp =>
            {
                var factory = sp.GetRequiredService<ISqlSugarClientFactory>();
                return factory.CreateClient();
            });

            // ע�᷺�Ͳֿ�
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
                    ValidAudience = _configuration["Jwt:Audience"], // ������Ч��audienceֵ
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]))
                };
            });

            services.AddAuthorization(options =>
            {
                // ����һ����Ϊ��ApiAccess���Ĳ���
                options.AddPolicy("ApiAccess", policy =>
                {
                    policy.AuthenticationSchemes.Add("Bearer");
                    policy.RequireAuthenticatedUser();
                });

                // ʹ�����涨��ġ�ApiAccess��������ΪĬ�ϲ���
                options.DefaultPolicy = options.GetPolicy("ApiAccess");
            });


            services.AddControllers(options =>
            {
                options.Conventions.Add(new AuthorizeAllControllersConvention());
                options.RespectBrowserAcceptHeader = true;
            }).AddNewtonsoftJson(opt =>
            {
                //ʱ���ʽ����Ӧ
                opt.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
                opt.SerializerSettings.ContractResolver = new DefaultContractResolver();
            });

            #region ����ȫ��·��
            //�ڸ������������ǰ׺��û���ض���·��ǰ�����ǰ׺��
            services.AddMvc(opt =>
            {
                opt.UseCentralRoutePrefix(new RouteAttribute("api/[controller]/[action]"));
            });
            #endregion

            #region ע��Swagger���� 
            services.AddSwaggerGen(s =>
            {
                #region ע�� Swagger
                s.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Title = "EOM.TSHotelManager.Web", //����Swagger�ĵ�������
                    Version = "version-1.0.0", //����Swagger�ĵ��İ汾��
                    Description = "Api Document", //����Swagger�ĵ�������
                    License = new OpenApiLicense()
                    {
                        Name = "MIT",
                        Url = new Uri("https://mit-license.org/")
                    }, //����Swagger�ĵ��Ŀ�Դ��ȨЭ��
                    TermsOfService = new Uri("https://www.oscode.top/"), //����Swagger�ĵ��ķ���֧����ҳ
                    Contact = new OpenApiContact
                    {
                        Name = "Easy-Open-Meta",
                        Email = "eom-official@oscode.top",
                        Url = new Uri("https://www.oscode.top/")
                    }
                });
                //��ȡͬ��������¸��ֲ��xmlע�ͣ�һ���ȡҵ���߼��㡢ʵ����ͽӿڲ㼴��
                s.IncludeXmlComments(AppContext.BaseDirectory + "EOM.TSHotelManager.Application.xml");
                s.IncludeXmlComments(AppContext.BaseDirectory + "EOM.TSHotelManager.Common.Core.xml");
                s.IncludeXmlComments(AppContext.BaseDirectory + "EOM.TSHotelManager.WebApi.xml");
                #endregion

                #region ��ʽ����ʱ��
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

            #region ʹ��Swagger�м��
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
            #region AutoFac IOC����,ʵ����������ע�������
            try
            {
                builder.RegisterType<SqlSugarClientFactory>().As<ISqlSugarClientFactory>().SingleInstance();

                builder.Register(c =>
                {
                    var factory = c.Resolve<ISqlSugarClientFactory>();
                    return factory.CreateClient();
                }).As<ISqlSugarClient>().InstancePerLifetimeScope();

                builder.RegisterGeneric(typeof(GenericRepository<>)).InstancePerLifetimeScope();

                //������������ע��
                var assemblyService = Assembly.LoadFrom(Path.Combine(AppContext.BaseDirectory, "EOM.TSHotelManager.Application.dll"));
                builder.RegisterAssemblyTypes(assemblyService)
                    .AsImplementedInterfaces()
                    .InstancePerDependency()
                    .PropertiesAutowired();

                //ע��ӽ������
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
