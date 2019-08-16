using AutoMapper;
using CSBEF.Core.Abstracts;
using CSBEF.Core.Concretes;
using CSBEF.Module.UserActionLog.Interfaces.Repository;
using CSBEF.Module.UserActionLog.Poco;

namespace CSBEF.Module.UserActionLog.Repositories
{
    public class ActionLogRepository : RepositoryBase<ActionLog>, IActionLogRepository
    {
        public ActionLogRepository(ModularDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
