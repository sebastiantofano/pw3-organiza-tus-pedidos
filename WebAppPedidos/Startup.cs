using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppPedidos.Helpers;

namespace WebAppPedidos
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
            /* INICIO: Agregado para el uso de sesiones */
            services.AddDistributedMemoryCache();


            services.AddSession(options =>
            {
                options.Cookie.Name = ".WebAppPedidos.Session";
                options.IdleTimeout = TimeSpan.FromSeconds(15);
                //options.Cookie.HttpOnly = true;
                //options.Cookie.IsEssential = true;
                
            });
            /* FIN: Agregado para el uso de sesiones */

            services.AddControllersWithViews();


            /* INICIO: Agregado para el uso de Json Web Token (JWT) */
            var key = Encoding.ASCII.GetBytes(Settings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };

            });
            /* FIN: Agregado para el uso de Json Web Token (JWT) */

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSession(); // Agregado para el uso de sesiones

            

            /* AGREGADO: Redirecciones a páginas de errores */
            app.UseStatusCodePages(context => {
                if (context.HttpContext.Response.StatusCode == 404)
                {
                    /* Utiliza un Route al endpoint /UsuarioGeneral/Errores/Error404 */
                    context.HttpContext.Response.Redirect("/404notfound");
                }

                return Task.CompletedTask;
            });

            app.UseEndpoints(endpoints =>
            {

                /* AGREGADO: Routes para Area "Usuario" */
                endpoints.MapAreaControllerRoute(
                    name: "UsuarioGeneral",
                    areaName: "UsuarioGeneral",
                    pattern: "UsuarioGeneral/{controller=Login}/{action=Index}/{id?}");

                /* AGREGADO: Routes para Area "Administrador" */
                endpoints.MapAreaControllerRoute(
                    name: "Administrador",
                    areaName: "Administrador",
                    pattern: "Administrador/{controller=Home}/{action=Index}/{id?}");

                /* AGREGADO: Routes para Area "Moderador" */
                endpoints.MapAreaControllerRoute(
                    name: "Moderador",
                    areaName: "Moderador",
                    pattern: "Moderador/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                
            });

        }
    }
}
