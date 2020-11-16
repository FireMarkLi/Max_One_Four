using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Doctor_MaxOne_Four
{
    //
    public class Startup
    {
      //  readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            //����
            //services.AddCors(options =>
            //  options.AddPolicy("cor",
            //  p => p.AllowAnyOrigin())
            //   );


            services.AddCors(options => options.AddPolicy("cor",
           builder =>
           {
                    builder.AllowAnyMethod()
                   .AllowAnyHeader()
                   .SetIsOriginAllowed(_ => true) // =AllowAnyOrigin()
                   .AllowCredentials();
           }));


            //services.AddCors(options =>
            //{
            //    options.AddPolicy(MyAllowSpecificOrigins,
            //       // builder => builder.AllowAnyOrigin()
            //       builder => builder.WithOrigins("https://localhost:52083/", "https://localhost:62090")
            //        /*
            //        �����Լ��������
            //         builder.WithOrigins("http://example.com",
            //                                            "http://www.contoso.com");

            //        ���ͬʱ�� AllowAnyOrigin()
            //                            .AllowAnyMethod()
            //                            .AllowAnyHeader()
            //                            .AllowCredentials());
            //        ������������쳣��
            //        System.InvalidOperationException: Endpoint AnXin.DigitalFirePlatform.WebApi.Controllers.StaticPersonController.Get (AnXin.DigitalFirePlatform.WebApi) contains CORS metadata, but a middleware was not found that supports CORS.
            //        Configure your application startup by adding app.UseCors() inside the call to Configure(..) in the application startup code. The call to app.UseAuthorization() must appear between app.UseRouting() and app.UseEndpoints(...).
            //           at Microsoft.AspNetCore.Routing.EndpointMiddleware.ThrowMissingCorsMiddlewareException(Endpoint endpoint)
            //           at Microsoft.AspNetCore.Routing.EndpointMiddleware.Invoke(HttpContext httpContext)
            //           at Microsoft.AspNetCore.Authorization.AuthorizationMiddleware.Invoke(HttpContext context)
            //           at Microsoft.AspNetCore.Diagnostics.DeveloperExceptionPageMiddleware.Invoke(HttpContext context)



            //        */
            //        .AllowAnyMethod()
            //        .AllowAnyHeader()
            //        .AllowCredentials()); ;

            //});



            //services.AddCors(options =>
            //{
            //    // Policy ���Q CorsPolicy ����ӆ�ģ������Լ���
            //    options.AddPolicy("cor", policy =>
            //    {
            //        // �O�����S����ā�Դ���ж�����Ԓ������ `,` ���_
            //        policy.WithOrigins("https://localhost:52083/", "https://localhost:62090")
            //        .AllowAnyHeader()
            //        .AllowAnyMethod()
            //        .AllowCredentials();
            //    });
            //});
            services.AddControllers();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
           
            //���þ�̬�ļ�
            app.UseStaticFiles();
         
            app.UseRouting();
            //����
            app.UseCors("cor");
         //   app.UseCors(MyAllowSpecificOrigins);

            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers().RequireCors(MyAllowSpecificOrigins);
            //});
        }
    }
}
