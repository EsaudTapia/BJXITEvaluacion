namespace Bjxit.Evaluacion.Model.Diccionaries
{
    public class AppSettingInfo
    {        
        public static string ConnectionStrings { get; set; } 
        public static string Environment { get; set; } 
        public static string SaltKey { get; set; }
        public static string KeyNumber { get; set; } 
        public static string ProviderName { get; set; } 
        public static string AppDataAssembly { get; set; } 
        public static string AppSettingsKey { get; set; } = "AppSettings";

    }
}
