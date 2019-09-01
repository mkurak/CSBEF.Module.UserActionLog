using CSBEF.Core.Concretes;
using CSBEF.Core.Enums;
using CSBEF.Core.Interfaces;
using CSBEF.Core.Models;
using CSBEF.Core.Models.HubModels;
using CSBEF.Module.UserActionLog.Interfaces.Repository;
using CSBEF.Module.UserActionLog.Poco;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CSBEF.Module.UserActionLog
{
    public class ModuleEventsJoinInitializer : IModuleEventsJoinInitializer
    {
        private IServiceProvider _serviceProvicer;
        private ILogger<ILog> _logger;

        public ModuleEventsJoinInitializer(IServiceProvider serviceProvider, ILogger<ILog> logger)
        {
            _serviceProvicer = serviceProvider;
            _logger = logger;
        }

        public void Start(IEventService eventService)
        {
            eventService.GetEvent("Main", "InComingHubClientData").Event += MainInComingHubClientDataHandler;

            var allEvents = eventService.GetAllEvents();
            if (allEvents.Any())
            {
                foreach (var e in allEvents)
                {
                    if (
                        e.EventInfo.EventType == EventTypeEnum.after
                        && (
                            e.EventInfo.ActionName != "FirstAsync"
                            && e.EventInfo.ActionName != "FirstOrDefaultAsync"
                            && e.EventInfo.ActionName != "AnyAsync"
                            && e.EventInfo.ActionName != "ListAsync"
                        )
                    )
                    {
                        e.Event += AddUserLogHandler;
                    }
                }
            }
        }

        private async Task<dynamic> MainInComingHubClientDataHandler(dynamic data, IEventInfo eventInfo)
        {
            var logger = _serviceProvicer.GetService<ILogger<ILog>>();
            var reData = (ServiceParamsWithIdentifier<InComingClientDataModel>)data;
            var rtn = new ReturnModel<SendModuleDataModel>(logger);
            if (reData.Param.ModuleName == "UserActionLog")
            {
                switch (reData.Param.DataKey)
                {
                }
            }

            return rtn;
        }

        private async Task<dynamic> AddUserLogHandler(dynamic data, IEventInfo eventInfo)
        {
            var userActionLogRepository = _serviceProvicer.GetService<IActionLogRepository>();
            var accessor = _serviceProvicer.GetService<IHttpContextAccessor>();
            var addLogModel = new ActionLog
            {
                Ip = accessor.HttpContext.Connection.RemoteIpAddress.ToString(),
                UserId = data.ActionParameter.UserId,
                TokenId = data.ActionParameter.TokenId,
                Module = eventInfo.ModuleName,
                Action = eventInfo.ModuleName + "." + eventInfo.ServiceName + "." + eventInfo.ActionName,
                ActionTime = DateTime.Now,
                Status = true,
                AddingDate = DateTime.Now,
                UpdatingDate = DateTime.Now,
                AddingUserId = data.ActionParameter.UserId,
                UpdatingUserId = data.ActionParameter.UserId
            };
            userActionLogRepository.Add(addLogModel);
            await userActionLogRepository.SaveAsync();

            return data.DataToBeSent;
        }
    }
}