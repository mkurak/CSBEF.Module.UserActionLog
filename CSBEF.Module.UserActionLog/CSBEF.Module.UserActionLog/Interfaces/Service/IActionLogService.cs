using CSBEF.Core.Interfaces;
using CSBEF.Module.UserActionLog.Models.DTO;
using CSBEF.Module.UserActionLog.Poco;

namespace CSBEF.Module.UserActionLog.Interfaces.Service
{
    public interface IActionLogService : IServiceBase<ActionLog, ActionLogDTO>
    {
    }
}
