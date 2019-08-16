using CSBEF.Core.Interfaces;
using CSBEF.Module.UserActionLog.Interfaces.Repository;
using CSBEF.Module.UserActionLog.Interfaces.Service;
using CSBEF.Module.UserActionLog.Repositories;
using CSBEF.Module.UserActionLog.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CSBEF.Module.UserActionLog
{
    public class ModuleInitializer : IModuleInitializer
    {
        public void Init(IServiceCollection services)
        {
            #region Repositories

            services.AddScoped<IActionLogRepository, ActionLogRepository>();

            #endregion Repositories

            #region Services

            services.AddScoped<IActionLogService, ActionLogService>();

            #endregion Services
        }
    }
}
