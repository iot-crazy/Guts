using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Web.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Interfaces.Factories;
using Factories;
using AutoMapper;
using NetCore.AutoRegisterDi;
using System.Reflection;
using Data;
using System.Security.Principal;
using Microsoft.AspNetCore.Http;
using FluentValidation.AspNetCore;
using Microsoft.IdentityModel.Tokens;

namespace Web
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

            // IPrinciple for the current user
            services.AddTransient<IPrincipal>(provider => provider.GetService<IHttpContextAccessor>()?.HttpContext?.User);

            //Factories
            services.AddSingleton<IDataContextFactory>(p => new DataContextFactory(Configuration.GetConnectionString(Enums.AppSettings.DbConnectionString)));

            // Automapper
            services.AddAutoMapper(typeof(Mapping.MapBase).Assembly);

            //Factories
            services.AddSingleton<IDataContextFactory>(p => new DataContextFactory(Configuration.GetConnectionString(Enums.AppSettings.DbConnectionString)));

            // Persistence 
            services.RegisterAssemblyPublicNonGenericClasses(Assembly.GetAssembly(typeof(Persistence.PersistenceBase)))
              .Where(c => c.Name.EndsWith("Persistence", StringComparison.InvariantCulture))
              .AsPublicImplementedInterfaces();

            // Services
            services.RegisterAssemblyPublicNonGenericClasses(Assembly.GetAssembly(typeof(Services.ServiceBase)))
              .Where(c => c.Name.EndsWith("Service", StringComparison.InvariantCulture))
              .AsPublicImplementedInterfaces();

            // Validators
            services.AddMvc().AddFluentValidation(fv =>
            {
                fv.RegisterValidatorsFromAssemblyContaining<Validators.ValidatorBase>();
                fv.RunDefaultMvcValidationAfterFluentValidationExecutes = false;
            }
            );


            /********************************** Create DB *********************/
            /* This is required to enable the creation of the database */
            services.AddDbContext<DataContext>
                  (options => options.UseSqlServer(
                  Configuration.GetConnectionString(Enums.AppSettings.DbConnectionString)));

            /* Create the DB if it's not already creataed */
            var context = new DataContext(Configuration.GetConnectionString(Enums.AppSettings.DbConnectionString));
            try
            {
                context.Database.EnsureCreated();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            /* end creating the DB */
            /********************************************************************/


            /** Account storage **/
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString(Enums.AppSettings.DbConnectionString)));
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            /***********************/


            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
