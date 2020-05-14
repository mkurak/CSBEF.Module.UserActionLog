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

            eventService.AddEvent("ActionLogService.First.Before", "UserActionLog", "ActionLogService", "First", EventTypeEnum.before);
            eventService.AddEvent("ActionLogService.FirstOrDefault.Before", "UserActionLog", "ActionLogService", "FirstOrDefault", EventTypeEnum.before);
            eventService.AddEvent("ActionLogService.Any.Before", "UserActionLog", "ActionLogService", "Any", EventTypeEnum.before);
            eventService.AddEvent("ActionLogService.List.Before", "UserActionLog", "ActionLogService", "List", EventTypeEnum.before);
            eventService.AddEvent("ActionLogService.Count.Before", "UserActionLog", "ActionLogService", "Count", EventTypeEnum.before);

            eventService.AddEvent("ActionLogService.First.After", "UserActionLog", "ActionLogService", "First", EventTypeEnum.after);
            eventService.AddEvent("ActionLogService.FirstOrDefault.After", "UserActionLog", "ActionLogService", "FirstOrDefault", EventTypeEnum.after);
            eventService.AddEvent("ActionLogService.Any.After", "UserActionLog", "ActionLogService", "Any", EventTypeEnum.after);
            eventService.AddEvent("ActionLogService.List.After", "UserActionLog", "ActionLogService", "List", EventTypeEnum.after);
            eventService.AddEvent("ActionLogService.Count.After", "UserActionLog", "ActionLogService", "Count", EventTypeEnum.after);

            #endregion Base Actions

            #endregion ActionLogService
        }
    }
}