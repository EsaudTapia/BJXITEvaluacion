using Bjxit.Evaluacion.Model.Diccionaries;
using Community.Core.EnterpriseLibrary.Model.Dictionary;
using Community.Core.EnterpriseLibrary.Utilities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BJXITEvaluacion
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ConfigureEnvironmentSettings();
            CreateHostBuilder(args).Build().Run();
            
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });



        //mapeo
        private static void ConfigureEnvironmentSettings()

        {

            string appSettingFile = "appsettings.json";

            string envValue = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            AppSettingInfo.Environment = "Development";

            IConfigurationRoot configuration;

            bool isDevelopment = envValue.Equals(AppSettingInfo.Environment);



            if (!isDevelopment)

            {

                AppSettingInfo.Environment = envValue;

                appSettingFile = $"appsettings.{envValue}.json";

            }



            configuration = new ConfigurationBuilder().AddJsonFile(appSettingFile, optional: false, reloadOnChange: true).Build();



            DefaultConnectionString.Value = configuration.GetConnectionString("DefaultConnection");

            DefaultConnectionString.ProviderName = configuration[$"{AppSettingInfo.AppSettingsKey}:{nameof(DefaultConnectionString.ProviderName)}"];



            AppSettingInfo applicationSettingInfo = new AppSettingInfo();

            configuration.Bind("AppSettings", applicationSettingInfo);

            //var columnOption = new ColumnOptions

            //{

            //    AdditionalColumns = new Collection<SqlColumn>

            //  {

            //    new SqlColumn

            //        {ColumnName = "Application", DataType = SqlDbType.VarChar, DataLength = int.MaxValue},

            //  }

            //};

            //columnOption.Store.Remove(StandardColumn.Properties);



            //var loggerConfig = new LoggerConfiguration()//.ReadFrom.Configuration(configuration)

            //    .ReadFrom.Configuration(configuration)

            //    .WriteTo.MSSqlServer(connectionString: DefaultConnectionString.Value,

            //                         sinkOptions: new MSSqlServerSinkOptions { TableName = "Tb_Log", SchemaName = "log", AutoCreateSqlTable = true },

            //                         columnOptions: columnOption);



            //if (isDevelopment)

            //{

            //    loggerConfig = loggerConfig.WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level}] {SourceContext}{NewLine}{Message:lj}{NewLine}{Exception}{NewLine}", theme: AnsiConsoleTheme.Code);

            //}



            //loggerConfig.Enrich.WithProperty("Application", "CoreIdentityWebServer")

            //            .Enrich.WithClientIp()

            //            .Enrich.WithClientAgent()

            //            .Enrich.WithMachineName();



            //Log.Logger = loggerConfig.CreateLogger();

        }
    }
}

    