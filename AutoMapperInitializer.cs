using AutoMapper;
using CSBEF.Module.UserActionLog.Models.DTO;
using CSBEF.Module.UserActionLog.Poco;

namespace CSBEF.Module.UserActionLog
{
    public class AutoMapperInitializer : Profile
    {
        public AutoMapperInitializer()
        {
            #region POCO => POCO

            CreateMap<ActionLog, ActionLog>();

            #endregion POCO => POCO

            #region DTO => DTO

            CreateMap<ActionLogDTO, ActionLogDTO>();

            #endregion DTO => DTO

            #region POCO => DTO & DTO => POCO

            CreateMap<ActionLog, ActionLogDTO>().ReverseMap();

            #endregion POCO => DTO & DTO => POCO
        }
    }
}