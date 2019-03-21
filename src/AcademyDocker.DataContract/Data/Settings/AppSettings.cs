namespace AcademyDocker.DataContract.Data.Settings
{
    public class AppSettings
    {
        public string ApiGatewayUrl { get; set; }
        public string GlobalSampleSetting { get; set; }
        public string EnvironmentSampleSetting { get; set; }

        public PermissionServiceSettings PermissionServiceSettings { get; set; }
        public AuthenticationSettings AuthenticationSettings { get; set; }
    }
}