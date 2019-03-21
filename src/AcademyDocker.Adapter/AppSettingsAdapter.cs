using System;
using AcademyDocker.DataContract.Data.Settings;
using AcademyDocker.DataContract.Interfaces.Adapter;
using Microsoft.Extensions.Options;

namespace AcademyDocker.Adapter
{
    public class AppSettingsAdapter : IAppSettingsAdapter
    {
        private readonly IOptions<AppSettings> _options;

        public AppSettings AppSettings => _options.Value;

        public AppSettingsAdapter(IOptions<AppSettings> options)
        {
            _options = options ?? throw new ArgumentNullException(nameof(options), "Options cannot be null. Please check your appsettings.json.");
        }
    }
}