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
            //            .AllowAnyOrigin() // �����κ���Դ��
            //            .AllowAnyMethod() // �����κ�HTTP����
            //            .AllowAnyHeader()// �����κ�HTTPͷ���ֶ�
            //            .AllowCredentials(); 
            //    });
            //});

            services.AddControllers().AddJsonOptions(opts =>
            {
                opts.JsonSerializerOptions.Encoder = JavaScriptEncoder.Create(UnicodeRanges.All);
                opts.JsonSerializerOptions.PropertyNamingPolicy = null;
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
                    Description = "�ӿ��ĵ�", //����Swagger�ĵ�������
                    License = new OpenApiLicense()
                    {
                        Name = "MIT",
                        Url = new Uri("https://mit-license.org/")
                    }, //����Swagger�ĵ��Ŀ�Դ��ȨЭ��
                    TermsOfService = new Uri("https://www.oscode.top/"), //����Swagger�ĵ��ķ���֧����ҳ
                    Contact = new OpenApiContact
                    {
                        Name = "�׿�Ԫ(Easy-Open-Meta)",
                        Email = "eom-official@oscode.top",
                        Url = new Uri("https://www.oscode.top/")
                    }
                });
                //��ȡͬ��������¸��ֲ��xmlע�ͣ�һ���ȡҵ���߼��㡢ʵ����ͽӿڲ㼴��
                s.IncludeXmlComments(AppContext.BaseDirectory+"EOM.TSHotelManager.Application.xml");
                s.IncludeXmlComments(AppContext.BaseDirectory+"EOM.TSHotelManager.Common.Core.xml");
                s.IncludeXmlComments(AppContext.BaseDirectory+"EOM.TSHotelManager.WebApi.xml");
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            #region ʹ��Swagger�м��
            app.UseSwagger();
            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("/swagger/v1/swagger.json", "EOM.TSHotelManager�ӿ��ĵ�");
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
                //ע��ִ�
                builder.RegisterGeneric(typeof(PgRepository<>)).As(typeof(PgRepository<>));

                //������������ע��
                var assemblyService = Assembly.LoadFrom(Path.Combine(AppContext.BaseDirectory, "EOM.TSHotelManager.Application.dll"));
                builder.RegisterAssemblyTypes(assemblyService)
                    .AsImplementedInterfaces()
                    .InstancePerDependency()
                    .PropertiesAutowired();

                //ע��ӽ������
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
