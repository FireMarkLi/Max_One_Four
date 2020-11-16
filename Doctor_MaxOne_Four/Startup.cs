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

            //跨域
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
            //        根据自己情况调整
            //         builder.WithOrigins("http://example.com",
            //                                            "http://www.contoso.com");

            //        如果同时打开 AllowAnyOrigin()
            //                            .AllowAnyMethod()
            //                            .AllowAnyHeader()
            //                            .AllowCredentials());
            //        会抛下面这个异常：
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
            //    // Policy 名稱 CorsPolicy 是自訂的，可以自己改
            //    options.AddPolicy("cor", policy =>
            //    {
            //        // 設定允許跨域的來源，有多個的話可以用 `,` 隔開
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
           
            //引用静态文件
            app.UseStaticFiles();
         
            app.UseRouting();
            //跨域
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
