using CSBEF.Core.Enums;
using CSBEF.Core.Interfaces;
using System;

namespace CSBEF.Module.UserActionLog
{
    public class ModuleEventsAddInitializer : IModuleEventsAddInitializer
    {
        public ModuleEventsAddInitializer()
        {
        }

        public void Start(IEventService eventService)
        {
            if (eventService == null)
                throw new ArgumentNullException(nameof(eventService));

            #region ActionLogService

            #region Base Actions

            eventService.AddEvent("ActionLogService.FirstAsync.Before", "UserActionLog", "ActionLogService", "FirstAsync", EventTypeEnum.before);
            eventService.AddEvent("ActionLogService.FirstOrDefaultAsync.Before", "UserActionLog", "ActionLogService", "FirstOrDefaultAsync", EventTypeEnum.before);
            eventService.AddEvent("ActionLogService.AnyAsync.Before", "UserActionLog", "ActionLogService", "AnyAsync", EventTypeEnum.before);
            eventService.AddEvent("ActionLogService.ListAsync.Before", "UserActionLog", "ActionLogService", "ListAsync", EventTypeEnum.before);
            eventService.AddEvent("ActionLogService.CountAsync.Before", "UserActionLog", "ActionLogService", "CountAsync", EventTypeEnum.before);

            eventService.AddEvent("ActionLogService.FirstAsync.After", "UserActionLog", "ActionLogService", "FirstAsync", EventTypeEnum.after);
            eventService.AddEvent("ActionLogService.FirstOrDefaultAsync.After", "UserActionLog", "ActionLogService", "FirstOrDefaultAsync", EventTypeEnum.after);
            eventService.AddEvent("ActionLogService.AnyAsync.After", "UserActionLog", "ActionLogService", "AnyAsync", EventTypeEnum.after);
            eventService.AddEvent("ActionLogService.ListAsync.After", "UserActionLog", "ActionLogService", "ListAsync", EventTypeEnum.after);
            eventService.AddEvent("ActionLogService.CountAsync.After", "UserActionLog", "ActionLogService", "CountAsync", EventTypeEnum.after);

            #endregion Base Actions

            #endregion ActionLogService
        }
    }
}