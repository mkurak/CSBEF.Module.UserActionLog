using AutoMapper;
using CSBEF.Core.Abstracts;
using CSBEF.Core.Interfaces;
using CSBEF.Module.UserActionLog.Interfaces.Repository;
using CSBEF.Module.UserActionLog.Interfaces.Service;
using CSBEF.Module.UserActionLog.Models.DTO;
using CSBEF.Module.UserActionLog.Poco;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace CSBEF.Module.UserActionLog.Services
{
    public class ActionLogService : ServiceBase<ActionLog, ActionLogDTO>, IActionLogService
    {
        #region ctor

        public ActionLogService(
           IWebHostEnvironment hostingEnvironment,
           IConfiguration configuration,
           ILogger<ILog> logger,
           IMapper mapper,
           IActionLogRepository repository,
           IEventService eventService

        // Other Repository Dependencies
        ) : base(
           hostingEnvironment,
           configuration,
           logger,
           mapper,
           repository,
           eventService,
           "UserActionLog",
           "ActionLogService"
        )
        {
        }

        #endregion ctor
    }
}