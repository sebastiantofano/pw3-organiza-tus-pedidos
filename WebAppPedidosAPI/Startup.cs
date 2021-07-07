using AutoMapper;
using DAL.Modelos;
using DAL.Repositorios;
using DAL.Repositorios.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Servicios.Administrador;
using Servicios.Administrador.Interfaces;
using Servicios.Helpers.Security;
using Servicios.UsuarioGeneral;
using Servicios.UsuarioGeneral.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using WebAPI.ResponseObjects;

namespace WebAPI
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

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPI", Version = "v1" });
            });

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
                   });
            /* FIN: Agregado para el uso de seguridad por roles */



            /* INICIO: IoC (Inyeccion de Dependencias) para la base de datos */
            services.AddDbContext<PedidosPW3Context>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("WebAppPedidosContext")).UseLazyLoadingProxies());
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

            /* FIN: IoC (Inyeccion de Dependencias) para Servicios y Repositorios */

            /* INICIO: IoC (Inyeccion de Dependencias) para el utilizar HttpContext desde los servicios */
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            /* FIN: IoC (Inyeccion de Dependencias) para el utilizar HttpContext desde los servicios */


            /* INICIO: Configuracion del Mapper */
            var mapperConfig = new MapperConfiguration(m =>
            {
                m.AddProfile(new MappingProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
            /* FIN: Configuracion del Mapper */
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
