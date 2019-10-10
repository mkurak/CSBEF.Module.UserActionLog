using CSBEF.Core.Interfaces;
using CSBEF.Module.UserActionLog.Models.DTO;
using CSBEF.Module.UserActionLog.Poco;
using System.Threading.Tasks;

namespace CSBEF.Module.UserActionLog.Interfaces.Service
{
    public interface IActionLogService : IServiceBase<ActionLog, ActionLogDTO>
    {
        Task<IReturnModel<dynamic>> SaveLog(IEventInfo eventInfo, dynamic dataToBeSent);
    }
}