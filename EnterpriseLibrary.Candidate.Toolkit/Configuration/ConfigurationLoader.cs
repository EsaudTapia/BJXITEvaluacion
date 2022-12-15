using Microsoft.Extensions.Configuration;
using System;
namespace EnterpriseLibrary.Candidate.Toolkit.Configuration
{
    public class ConfigurationLoader
    {
        //public static void LoadConfigValues<T>(string fileName, string basePath, string envName, string key)
        //{
        //    var builder = new ConfigurationBuilder()
        //   .SetBasePath(basePath)
        //   .AddJsonFile($"{fileName}.json", optional: true, reloadOnChange: true);



        //    if (envName != null)
        //    {
        //        builder = builder.AddJsonFile($"{fileName}{envName}.json", optional: true);
        //    }



        //    builder = builder.AddEnvironmentVariables();



        //    var configuration = builder.Build();



        //    IConfigurationSection config = configuration.GetSection(key);



        //    Type type = typeof(T); // SystemInfo is static class with static properties
        //    foreach (var field in type.GetProperties())
        //    {
        //        if (config[field.Name] != null)
        //        {
        //            field.SetValue(string.Empty, config[field.Name]);
        //        }
        //    }
        //}
        
        
        public static void LoadConfigValues<T>(IConfiguration configuration, string key)
        {
            IConfigurationSection config = configuration.GetSection(key);



            Type type = typeof(T); // SystemInfo is static class with static properties
            foreach (var field in type.GetProperties())
            {
                if (config[field.Name] != null)
                {
                    if (field.PropertyType == typeof(int))
                    {
                        field.SetValue(-1, int.Parse(config[field.Name]));
                    }
                    else if (field.PropertyType == typeof(bool))
                    {
                        field.SetValue(false, bool.Parse(config[field.Name]));
                    }
                    else
                    {
                        field.SetValue(string.Empty, config[field.Name]);
                    }
                }
            }


        }
    }
}
