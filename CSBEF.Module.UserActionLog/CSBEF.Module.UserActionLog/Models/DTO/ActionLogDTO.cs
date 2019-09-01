using CSBEF.Core.Models;
using System;

namespace CSBEF.Module.UserActionLog.Models.DTO
{
    public class ActionLogDTO : DTOModelBase
    {
        public string Ip { get; set; }
        public int? UserId { get; set; }
        public int? TokenId { get; set; }
        public string Module { get; set; }
        public string Action { get; set; }
        public DateTime ActionTime { get; set; }
    }
}