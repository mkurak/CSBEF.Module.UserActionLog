CREATE TABLE [dbo].[UserActionLog_ActionLog](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IP] [nvarchar](256) NOT NULL,
	[UserId] [int] NULL,
	[TokenId] [int] NULL,
	[EventName] [nvarchar](256) NULL,
	[Module] [nvarchar](256) NOT NULL,
	[Action] [nvarchar](256) NOT NULL,
	[ActionTime] [datetime] NOT NULL,
	[Status] [bit] NULL,
	[AddingDate] [datetime] NOT NULL,
	[UpdatingDate] [datetime] NOT NULL,
	[AddingUserId] [int] NULL,
	[UpdatingUserId] [int] NULL,
 CONSTRAINT [PK_UserActionLog_ActionLog] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[UserActionLog_ActionLog] ADD  CONSTRAINT [DF_UserActionLog_ActionLog_ActionTime]  DEFAULT (getdate()) FOR [ActionTime]
GO

ALTER TABLE [dbo].[UserActionLog_ActionLog] ADD  CONSTRAINT [DF_UserActionLog_ActionLog_Status]  DEFAULT ((1)) FOR [Status]
GO

ALTER TABLE [dbo].[UserActionLog_ActionLog] ADD  CONSTRAINT [DF_UserActionLog_ActionLog_AddingDate]  DEFAULT (getdate()) FOR [AddingDate]
GO

ALTER TABLE [dbo].[UserActionLog_ActionLog] ADD  CONSTRAINT [DF_UserActionLog_ActionLog_UpdatingDate]  DEFAULT (getdate()) FOR [UpdatingDate]
GO
