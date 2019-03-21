using System;
using AcademyDocker.DataContract.Data.Settings;
using AcademyDocker.DataContract.Interfaces.Adapter;
using Microsoft.Extensions.DependencyInjection;

namespace AcademyDocker.Adapter
{
    public static class AdapterServiceExtension
    {
     

        public static void AddAdapters(this IServiceCollection services)
        {
            services.AddSingleton<IAppSettingsAdapter, AppSettingsAdapter>();
        }
    }
}