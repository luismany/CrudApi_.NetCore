using EjercicioWebApiPlatzi.Servicios;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.AspNetCore.Authorization;

namespace EjercicioWebApiPlatzi
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
            
            //configurando la coneccion a la base de datos
            services.AddDbContext<TareasDbContext>(
                options => options.UseSqlServer(@"Data Source=DESKTOP-R12URAM\SQLEXPRESS;Initial Catalog=TareasDB;User ID=luismany;Password=12345;Application Name=TareasDb"));

            //***** Configuracion de servicios para JWT *****
            //autorizacion
            services.AddAuthorization(options =>
            options.DefaultPolicy=new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme).RequireAuthenticatedUser().Build()
            );
            //estos valores los obtenemos de nuestro appsettings
            var issuer = Configuration["AuthenticationSettings:Issuer"];
            var audience = Configuration["AuthenticationSettings:Audience"];
            var signinKey = Configuration["AuthenticationSettings:SigningKey"];
            //autenticacion
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.Audience = audience;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidIssuer= issuer,
                    ValidateIssuerSigningKey= true,
                    ValidateLifetime=true,
                    IssuerSigningKey= new SymmetricSecurityKey(Encoding.ASCII.GetBytes(signinKey))
                };
            }
            );

            //configurando la inyeccion de dependencia de los servicios Tarea y Categoria
            services.AddScoped<ITareasServicio, TareasServicio>();
            services.AddScoped<ICategoriaService, CategoriaServicio>();
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //Configurando la aplicaci�n para JWT
            app.UseAuthentication();

            //...
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
