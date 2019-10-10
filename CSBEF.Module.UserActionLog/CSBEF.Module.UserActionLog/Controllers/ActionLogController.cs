using CSBEF.Core.Enums;
using CSBEF.Core.Helpers;
using CSBEF.Core.Interfaces;
using CSBEF.Core.Models;
using CSBEF.Module.UserActionLog.Interfaces.Service;
using CSBEF.Module.UserActionLog.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSBEF.Module.UserActionLog.Controllers
{
    [ApiController]
    public class ActionLogController : ControllerBase
    {
        #region Dependencies

        private readonly IConfiguration _configuration;
        private readonly ILogger<ILog> _logger;
        private readonly IActionLogService _service;

        #endregion Dependencies

        #region Construction

        public ActionLogController(IConfiguration configuration, ILogger<ILog> logger, IActionLogService service)
        {
            _configuration = configuration;
            _logger = logger;
            _service = service;
        }

        #endregion Construction

        #region Actions

        [Authorize]
        [Route("api/UserActionLog/ActionLog/List")]
        [HttpGet]
        public async Task<ActionResult<IReturnModel<IList<ActionLogDTO>>>> List([FromQuery]ActionFilterModel filter)
        {
            if (filter == null)
                throw new ArgumentNullException(nameof(filter));

            #region Declares

            IReturnModel<IList<ActionLogDTO>> rtn = new ReturnModel<IList<ActionLogDTO>>(_logger);

            #endregion Declares

            #region Hash Control

            if (!filter.HashControl(_configuration["AppSettings:HashSecureKeys:UserActionLog:ActionLog:List"]))
            {
                _logger.LogError("InvalidHash: " + filter.Hash);
                return BadRequest(rtn.SendError(GlobalErrors.HashCodeInValid));
            }

            #endregion Hash Control

            #region Action Body

            try
            {
                var userId = Tools.GetTokenNameClaim(HttpContext);
                IReturnModel<IList<ActionLogDTO>> serviceAction = await _service.ListAsync(filter).ConfigureAwait(false);
                if (serviceAction.Error.Status)
                    rtn.Error = serviceAction.Error;
                else
                    rtn.Result = serviceAction.Result;
            }
            catch (Exception ex)
            {
                rtn = rtn.SendError(GlobalErrors.TechnicalError, ex);
            }

            #endregion Action Body

            return Ok(rtn);
        }

        #endregion Actions
    }
}