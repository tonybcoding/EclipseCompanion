ALTER DATABASE [EclipseCompanion] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EclipseCompanion].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EclipseCompanion] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [EclipseCompanion] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [EclipseCompanion] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [EclipseCompanion] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [EclipseCompanion] SET ARITHABORT OFF 
GO
ALTER DATABASE [EclipseCompanion] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [EclipseCompanion] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [EclipseCompanion] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [EclipseCompanion] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [EclipseCompanion] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [EclipseCompanion] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [EclipseCompanion] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [EclipseCompanion] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [EclipseCompanion] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [EclipseCompanion] SET  DISABLE_BROKER 
GO
ALTER DATABASE [EclipseCompanion] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [EclipseCompanion] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [EclipseCompanion] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [EclipseCompanion] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [EclipseCompanion] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [EclipseCompanion] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [EclipseCompanion] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [EclipseCompanion] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [EclipseCompanion] SET  MULTI_USER 
GO
ALTER DATABASE [EclipseCompanion] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [EclipseCompanion] SET DB_CHAINING OFF 
GO
ALTER DATABASE [EclipseCompanion] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [EclipseCompanion] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [EclipseCompanion] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [EclipseCompanion] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'EclipseCompanion', N'ON'
GO
ALTER DATABASE [EclipseCompanion] SET QUERY_STORE = OFF
GO
USE [EclipseCompanion]
GO
/****** Object:  Table [dbo].[ConfigurationFields]    Script Date: 9/25/2021 1:21:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ConfigurationFields](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[fieldname] [varchar](50) NOT NULL,
	[fieldtype] [varchar](50) NOT NULL,
	[displayname] [varchar](50) NOT NULL,
	[displaycolumn] [int] NOT NULL,
	[displaycolumnwidth] [int] NOT NULL,
	[todisplay] [bit] NOT NULL,
 CONSTRAINT [PK_ConfigurationFields] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GeneralConfiguration]    Script Date: 9/25/2021 1:21:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GeneralConfiguration](
	[id] [int] NOT NULL,
	[FirstRun] [bit] NOT NULL,
	[LastAPIRefresh] [datetime2](7) NOT NULL,
	[LastUpdatedByUserId] [int] NOT NULL,
	[UpdatingAPI] [bit] NOT NULL,
	[TruncateString] [varchar](50) NOT NULL,
	[EclipseGreen] [varchar](50) NOT NULL,
	[EclipseYellow] [varchar](50) NOT NULL,
	[EclipseRed] [varchar](50) NOT NULL,
	[ComplexityGreen] [varchar](50) NOT NULL,
	[ComplexityYellow] [varchar](50) NOT NULL,
	[ComplexityRed] [varchar](50) NOT NULL,
	[ScheduleGreen] [varchar](50) NOT NULL,
	[ScheduleYellow] [varchar](50) NOT NULL,
	[ScheduleRed] [varchar](50) NOT NULL,
	[OverallGreen] [varchar](50) NOT NULL,
	[OverallYellow] [varchar](50) NOT NULL,
	[OverallRed] [varchar](50) NOT NULL,
 CONSTRAINT [PK_GeneralConfiguration] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProjectIndicators]    Script Date: 9/25/2021 1:21:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectIndicators](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ProjectEclipseId] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[StateId] [int] NOT NULL,
	[StateName] [varchar](50) NOT NULL,
	[CreateDate] [datetime2](7) NOT NULL,
	[LastUpdated] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_ProjectIndicators] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Projects]    Script Date: 9/25/2021 1:21:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Projects](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[EclipseId] [int] NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Description] [varchar](2048) NOT NULL,
	[ProjectOwner] [varchar](200) NOT NULL,
	[Priority] [varchar](50) NOT NULL,
	[Status] [varchar](50) NOT NULL,
	[StartDate] [datetime2](7) NOT NULL,
	[EndDate] [datetime2](7) NOT NULL,
	[PercentComplete] [decimal](5, 4) NOT NULL,
	[DateCreated] [datetime2](7) NOT NULL,
	[DateLastModified] [datetime2](7) NOT NULL,
	[ShortStatusNotes] [varchar](4000) NOT NULL,
	[FullStatusNotes] [varchar](4000) NOT NULL,
	[StatusCategory] [varchar](50) NOT NULL,
	[StatusSortOder] [int] NOT NULL,
	[LastStatusDate] [datetime2](7) NOT NULL,
	[PrioritySortOrder] [int] NOT NULL,
	[StatusCategoryId] [int] NOT NULL,
	[StatusId] [int] NOT NULL,
	[PriorityId] [int] NOT NULL,
	[ProjectOwnerId] [int] NOT NULL,
	[CreateDate] [datetime2](7) NOT NULL,
	[LastUpdated] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Projects] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProjectTaskResourceLog]    Script Date: 9/25/2021 1:21:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectTaskResourceLog](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ProjId] [int] NOT NULL,
	[TaskId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[StartDateTime] [datetime2](7) NOT NULL,
	[EndDateTime] [datetime2](7) NOT NULL,
	[CreateDate] [datetime2](7) NOT NULL,
	[LastUpdated] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_ProjectTaskResourceLog] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tasks]    Script Date: 9/25/2021 1:21:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tasks](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[TaskName] [varchar](100) NOT NULL,
	[UserCreatedId] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreateDate] [datetime2](7) NOT NULL,
	[LastUpdated] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Tasks] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 9/25/2021 1:21:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](100) NOT NULL,
	[LastName] [varchar](100) NOT NULL,
	[LoginId] [varchar](100) NOT NULL,
	[EmailAddress] [varchar](200) NOT NULL,
	[UserPassword] [varchar](50) NOT NULL,
	[AccessLevel] [int] NOT NULL,
	[LastLogIn] [datetime2](7) NULL,
	[Active] [bit] NOT NULL,
	[Locked] [bit] NOT NULL,
	[ForcePasswordChange] [bit] NOT NULL,
	[CreateDate] [datetime2](7) NOT NULL,
	[LastUpdated] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[GeneralConfiguration] ADD  CONSTRAINT [DF_GeneralConfiguration_LastAPIRefresh]  DEFAULT (getdate()) FOR [LastAPIRefresh]
GO
ALTER TABLE [dbo].[GeneralConfiguration] ADD  CONSTRAINT [DF_GeneralConfiguration_UpdatingAPI]  DEFAULT ((0)) FOR [UpdatingAPI]
GO
ALTER TABLE [dbo].[ProjectIndicators] ADD  CONSTRAINT [DF_ProjectIndicators_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[ProjectIndicators] ADD  CONSTRAINT [DF_ProjectIndicators_LastUpdated]  DEFAULT (getdate()) FOR [LastUpdated]
GO
ALTER TABLE [dbo].[Projects] ADD  CONSTRAINT [DF_Projects_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[Projects] ADD  CONSTRAINT [DF_Projects_LastUpdated]  DEFAULT (getdate()) FOR [LastUpdated]
GO
ALTER TABLE [dbo].[ProjectTaskResourceLog] ADD  CONSTRAINT [DF_ProjectTaskResourceLog_StartDateTime]  DEFAULT (getdate()) FOR [StartDateTime]
GO
ALTER TABLE [dbo].[ProjectTaskResourceLog] ADD  CONSTRAINT [DF_ProjectTaskResourceLog_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[ProjectTaskResourceLog] ADD  CONSTRAINT [DF_ProjectTaskResourceLog_LastUpdated]  DEFAULT (getdate()) FOR [LastUpdated]
GO
ALTER TABLE [dbo].[Tasks] ADD  CONSTRAINT [DF_Tasks_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[Tasks] ADD  CONSTRAINT [DF_Tasks_LastUpdated]  DEFAULT (getdate()) FOR [LastUpdated]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_LastUpdated]  DEFAULT (getdate()) FOR [LastUpdated]
GO
ALTER TABLE [dbo].[ProjectTaskResourceLog]  WITH CHECK ADD  CONSTRAINT [FK_ProjectTaskResourceLog_Projects] FOREIGN KEY([ProjId])
REFERENCES [dbo].[Projects] ([id])
GO
ALTER TABLE [dbo].[ProjectTaskResourceLog] CHECK CONSTRAINT [FK_ProjectTaskResourceLog_Projects]
GO
ALTER TABLE [dbo].[ProjectTaskResourceLog]  WITH CHECK ADD  CONSTRAINT [FK_ProjectTaskResourceLog_Tasks] FOREIGN KEY([TaskId])
REFERENCES [dbo].[Tasks] ([id])
GO
ALTER TABLE [dbo].[ProjectTaskResourceLog] CHECK CONSTRAINT [FK_ProjectTaskResourceLog_Tasks]
GO
ALTER TABLE [dbo].[ProjectTaskResourceLog]  WITH CHECK ADD  CONSTRAINT [FK_ProjectTaskResourceLog_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([id])
GO
ALTER TABLE [dbo].[ProjectTaskResourceLog] CHECK CONSTRAINT [FK_ProjectTaskResourceLog_Users]
GO
ALTER TABLE [dbo].[Tasks]  WITH CHECK ADD  CONSTRAINT [FK_Tasks_Users] FOREIGN KEY([UserCreatedId])
REFERENCES [dbo].[Users] ([id])
GO
ALTER TABLE [dbo].[Tasks] CHECK CONSTRAINT [FK_Tasks_Users]
GO
USE [master]
GO
ALTER DATABASE [EclipseCompanion] SET  READ_WRITE 
GO
