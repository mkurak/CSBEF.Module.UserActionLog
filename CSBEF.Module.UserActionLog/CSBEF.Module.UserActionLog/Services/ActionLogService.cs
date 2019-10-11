using AutoMapper;
using CSBEF.Core.Abstracts;
using CSBEF.Core.Enums;
using CSBEF.Core.Helpers;
using CSBEF.Core.Interfaces;
using CSBEF.Core.Models;
using CSBEF.Module.UserActionLog.Interfaces.Repository;
using CSBEF.Module.UserActionLog.Interfaces.Service;
using CSBEF.Module.UserActionLog.Models.DTO;
using CSBEF.Module.UserActionLog.Poco;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace CSBEF.Module.UserActionLog.Services
{
    public class ActionLogService : ServiceBase<ActionLog, ActionLogDTO>, IActionLogService
    {
        #region Dependencies

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IActionLogRepository _actionLogRepository;

        #endregion

        #region ctor

        public ActionLogService(
           IWebHostEnvironment hostingEnvironment,
           IConfiguration configuration,
           ILogger<ILog> logger,
           IMapper mapper,
           IActionLogRepository repository,
           IEventService eventService,

            // Other Dependencies
            IHttpContextAccessor httpContextAccessor,
            IActionLogRepository actionLogRepository
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
            _httpContextAccessor = httpContextAccessor;
            _actionLogRepository = actionLogRepository;
        }

        #endregion ctor

        #region Public Actions

        public async Task<IReturnModel<dynamic>> SaveLog(IEventInfo eventInfo, dynamic dataToBeSent)
        {
            if (eventInfo == null)
                throw new ArgumentNullException(nameof(eventInfo));

            if (dataToBeSent == null)
                throw new ArgumentNullException(nameof(dataToBeSent));

            IReturnModel<dynamic> rtn = new ReturnModel<dynamic>(_logger);

            try
            {
                #region Variables

                ActionLog addLogModel;

                #endregion Variables

                #region Action Body

                var userId = Tools.GetTokenNameClaim(_httpContextAccessor.HttpContext);
                var tokenId = Tools.GetTokenIdClaim(_httpContextAccessor.HttpContext);

                addLogModel = new ActionLog
                {
                    Ip = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString(),
                    UserId = userId,
                    TokenId = tokenId,
                    EventName = eventInfo.EventName,
                    Module = eventInfo.ModuleName,
                    Action = eventInfo.ModuleName + "." + eventInfo.ServiceName + "." + eventInfo.ActionName,
                    ActionTime = DateTime.Now,
                    Status = true,
                    AddingDate = DateTime.Now,
                    UpdatingDate = DateTime.Now,
                    AddingUserId = userId,
                    UpdatingUserId = userId
                };
                _actionLogRepository.Add(addLogModel);
                await _actionLogRepository.SaveAsync().ConfigureAwait(false);

                rtn.Result = dataToBeSent;

                #endregion Action Body

                #region Clear Memory

                eventInfo = null;
                addLogModel = null;

                #endregion Clear Memory
            }
            catch (Exception ex)
            {
                rtn = rtn.SendError(GlobalErrors.TechnicalError, ex);
            }

            return rtn;
        }

        #endregion
    }
}