using Bjxit.Evaluacion.Model.Diccionaries;
using Community.Core.EnterpriseLibrary.Activation;
using Community.Core.EnterpriseLibrary.Utilities;
using EnterpriseLibrary.Candidate.Toolkit.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace BJXITEvaluacion
{

    public class Startup
    {
        //seguir este orden        

        #region Properties
        public IConfiguration Configuration { get; }

        private IWebHostEnvironment _currentEnvironment;

        #endregion Properties

        #region Constructor

        //coniguracion de servicios/ regiones de codigo        
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {

            _currentEnvironment = env;
            Configuration = configuration;

        }

        #endregion Constructor

        #region PublicMethods
        // This method gets called by the runtime. Use this method to add services to the container.        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist"; //es la carpeta donde se encuentra el proyecto angular
            });

            // services.AddMvc()
            //.AddNewtonsoftJson()
            //.AddNewtonsoftJson(options =>

            //{
            //    options.SerializerSettings.ReferenceLoopHandling =
            //    ReferenceLoopHandling.Ignore;
            //});


            // Add Caching support
            
            services.AddMemoryCache();        
           // ConfigurationLoader.LoadConfigValues<StringsInfo>("strings", _currentEnvironment.ContentRootPath, _currentEnvironment.EnvironmentName, "es-ES");
            ConfigurationLoader.LoadConfigValues<AppSettingInfo>(Configuration, AppSettingInfo.AppSettingsKey);

            //worker servicios en segundo plano
            //singlertlon variables de un solo uso en toda la aplicacion
            //services.AddSingleton<IWorker, Worker>();
            //Custom policy handlers
            //services.AddSingleton<IAuthorizationPolicyProvider, ResourceAccessPolicyProvider>();
            //services.AddScoped<IAuthorizationHandler, ResourceAccessPolicyAuthorizationHandler>();
            //services.AddHttpContextAccessor();
            //services.AddScoped<IAccessValidationHandler, ResourceLogic>();
            ConfigureEnterprise();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.Use((context, next) => { context.Request.Scheme = "https"; return next(); });

            app.UseAuthentication();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors("CorsPolicy");

            app.UseApiExceptionHandling();

            //app.UseSerilogRequestLogging();

            //enpoints son los verbos http (get, post, put, delete)

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            //redireccion para headers 
            app.Use(async (c, next) =>

            {
                if (c.Request.Path == "/")
                {
                    c.Response.Headers.Add("Cache-Control", "no-store,no-cache");
                    c.Response.Headers.Add("Pragma", "no-cache");
                }
                await next();
            });


            //SPA:SINGLE PAGE APPLICATION-> aplicacion de una sola pagina
            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });

        }

        #endregion
        #region PrivateMethods        
        private void ConfigureEnterprise()
        {
            CoreFrame.WsDatDefActiv = new BscActivation();
            //Logger.Configure(new EventLogLogic(),
            //   AppSettingInfo.AppId,
            //   AppSettingInfo.EntryTypeErrorId,
            //   AppSettingInfo.EntryTypeInformationId,
            //   AppSettingInfo.EntryTypeWarningId,
            //   AppSettingInfo.DefaultUserLogName,
            //   GetType().Assembly.GetName().Version.ToString(),
            //   Dns.GetHostName());
            CoreFrame.Start(1);
        }
        #endregion

    }

}
