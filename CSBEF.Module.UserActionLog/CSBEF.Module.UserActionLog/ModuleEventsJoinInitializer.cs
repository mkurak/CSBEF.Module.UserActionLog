using CSBEF.Core.Interfaces;
using CSBEF.Module.UserActionLog.Interfaces.Service;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CSBEF.Module.UserActionLog
{
    public class ModuleEventsJoinInitializer : IModuleEventsJoinInitializer
    {
        private IServiceProvider _serviceProvider;
        private ILogger<ILog> _logger;

        public ModuleEventsJoinInitializer(IServiceProvider serviceProvider, ILogger<ILog> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        public void Start(IEventService eventService)
        {
            if (eventService == null)
                throw new ArgumentNullException(nameof(eventService));

            var allEvents = eventService.GetAllEvents();
            if (allEvents.Any())
            {
                foreach (var e in allEvents)
                {
                    e.Event += AddActionLog;
                }
            }
        }

        private async Task<dynamic> AddActionLog(dynamic data, IEventInfo eventInfo)
        {
            var actitonLogService = _serviceProvider.GetService<IActionLogService>();
            await actitonLogService.SaveLog(eventInfo, data);

            return null;
        }
    }
}
