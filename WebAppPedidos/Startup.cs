using DAL.Modelos;
using DAL.Repositorios;
using DAL.Repositorios.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Servicios.Administrador;
using Servicios.Administrador.Interfaces;
using Servicios.Helpers.Security;
using Servicios.UsuarioGeneral;
using Servicios.UsuarioGeneral.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            /* INICIO: Agregado para el uso de seguridad por roles */
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                   .AddCookie(options =>
                   {
                       /* INICIO: Agregado para solucionar el problema de que devolvía un statusCode 302(Redireccion) en vez del 401 (No autorizado)*/
                       options.Events.OnRedirectToLogin = context =>
                       {
                           context.Response.Headers["Location"] = context.RedirectUri;
                           context.Response.StatusCode = 401;
                           return Task.CompletedTask;
                       };

                       /* FIN: Agregado para solucionar el problema de que devolvía un statusCode 302(Redireccion) en vez del 401 (No autorizado)*/

                       options.LoginPath = "/login";
                       //options.LogoutPath = "/Account/SignOut";
                       options.AccessDeniedPath = "/401unauthorized";  // Ver porque no funciona ???????????
                   });
            /* FIN: Agregado para el uso de seguridad por roles */


       
            /* INICIO: Agregado para el uso de sesiones */
            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                options.Cookie.Name = "WebAppPedidosSession";
                options.IdleTimeout = TimeSpan.FromSeconds(10000);
                //options.Cookie.HttpOnly = true;
                //options.Cookie.IsEssential = true;
                
            });
            /* FIN: Agregado para el uso de sesiones */


            services.AddControllersWithViews();


            /* INICIO: IoC (Inyeccion de Dependencias) para la base de datos */
            services.AddDbContext<PedidosPW3Context>(options => 
                options.UseSqlServer(Configuration.GetConnectionString("WebAppPedidosContext")));
            /* FIN: IoC (Inyeccion de Dependencias) para la base de datos */


            /* INICIO: IoC (Inyeccion de Dependencias) para Servicios y Repositorios */
            services.AddTransient<ILoginService, LoginServiceImpl>();
            services.AddTransient<ILoginRepository, LoginRepositoryImpl>();

            services.AddTransient<IClientesService, ClientesServiceImpl>();
            services.AddTransient<IClientesRepository, ClientesRepositoryImpl>();

            services.AddTransient<IArticulosService, ArticulosServiceImpl>();
            services.AddTransient<IArticulosRepository, ArticulosRepositoryImpl>();

            services.AddTransient<IUsuariosService, UsuariosServiceImpl>();
            services.AddTransient<IUsuariosRepository, UsuariosRepositoryImpl>();

            services.AddTransient<IPedidosService, PedidosServiceImpl>();
            services.AddTransient<IPedidosRepository, PedidosRepositoryImpl>();


            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            /* FIN: IoC (Inyeccion de Dependencias) para Servicios y Repositorios */
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


            /* INICIO: Agregado - Redirecciones a páginas de errores */
            app.UseStatusCodePages(context => {
                if (context.HttpContext.Response.StatusCode == 401) context.HttpContext.Response.Redirect("/401unauthorized"); /* Utiliza un Route al endpoint /UsuarioGeneral/Errores/Error401 */
                if (context.HttpContext.Response.StatusCode == 404) context.HttpContext.Response.Redirect("/404notfound"); /* Utiliza un Route al endpoint /UsuarioGeneral/Errores/Error404 */
               
                return Task.CompletedTask;
            });
            /* FIN: Agregado - Redirecciones a páginas de errores */


            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization(); // Agregado para el uso de autorizacion

            app.UseSession(); // Agregado para el uso de sesiones

            
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
