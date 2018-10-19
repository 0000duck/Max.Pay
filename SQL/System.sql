USE [master]
GO
/****** Object:  Database [Poc_System]    Script Date: 2018/10/19 17:43:07 ******/
CREATE DATABASE [Poc_System]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Poc_System', FILENAME = N'D:\SVNProject\DataBase\Poc_System.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Poc_System_log', FILENAME = N'D:\SVNProject\DataBase\Poc_System_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Poc_System] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Poc_System].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Poc_System] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Poc_System] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Poc_System] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Poc_System] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Poc_System] SET ARITHABORT OFF 
GO
ALTER DATABASE [Poc_System] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Poc_System] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Poc_System] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Poc_System] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Poc_System] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Poc_System] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Poc_System] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Poc_System] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Poc_System] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Poc_System] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Poc_System] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Poc_System] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Poc_System] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Poc_System] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Poc_System] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Poc_System] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Poc_System] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Poc_System] SET RECOVERY FULL 
GO
ALTER DATABASE [Poc_System] SET  MULTI_USER 
GO
ALTER DATABASE [Poc_System] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Poc_System] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Poc_System] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Poc_System] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Poc_System] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Poc_System', N'ON'
GO
ALTER DATABASE [Poc_System] SET QUERY_STORE = OFF
GO
USE [Poc_System]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [Poc_System]
GO
/****** Object:  Table [dbo].[SYS_Role]    Script Date: 2018/10/19 17:43:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SYS_Role](
	[SystemRoleId] [varchar](50) NOT NULL,
	[RoleName] [nvarchar](50) NOT NULL,
	[Status] [int] NOT NULL,
	[Permissions] [varchar](max) NULL,
	[CreateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_SYS_ROLE] PRIMARY KEY CLUSTERED 
(
	[SystemRoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SYS_UserRoles]    Script Date: 2018/10/19 17:43:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SYS_UserRoles](
	[SystemUserId] [varchar](50) NOT NULL,
	[SystemRoleId] [varchar](50) NOT NULL,
	[CreateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_SYS_USERROLES] PRIMARY KEY CLUSTERED 
(
	[SystemUserId] ASC,
	[SystemRoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SYS_User]    Script Date: 2018/10/19 17:43:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SYS_User](
	[SystemUserId] [varchar](50) NOT NULL,
	[UserName] [varchar](30) NOT NULL,
	[Password] [varchar](250) NOT NULL,
	[RealName] [nvarchar](20) NULL,
	[Email] [varchar](50) NULL,
	[UserType] [int] NOT NULL,
	[Mobile] [varchar](20) NULL,
	[Status] [int] NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[SystemId] [int] NOT NULL,
 CONSTRAINT [PK_SYS_USER] PRIMARY KEY CLUSTERED 
(
	[SystemUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[V_UserRoles]    Script Date: 2018/10/19 17:43:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE view [dbo].[V_UserRoles] AS 
	select 
	   u.[SystemUserId]
      ,u.[UserName]
      ,u.[RealName]
      ,u.[Email]
      ,u.[UserType]
      ,u.[Mobile]
      ,u.[Status] as UserStatus
      ,u.[CreateTime]
      ,u.[CarMerchantId]
	  ,r.SystemRoleId
	  ,r.RoleName
	  ,r.[Status] as RoleStatus
	  ,r.[Permissions]
	from SYS_User u
		inner join SYS_UserRoles ur on ur.SystemUserId=u.SystemUserId
		inner join SYS_Role r on r.SystemRoleId=ur.SystemRoleId;
GO
/****** Object:  Table [dbo].[SYS_Action]    Script Date: 2018/10/19 17:43:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SYS_Action](
	[ActionId] [varchar](50) NOT NULL,
	[ParentId] [varchar](50) NULL,
	[ActionName] [nvarchar](50) NOT NULL,
	[Url] [varchar](250) NOT NULL,
	[IconClass] [varchar](50) NULL,
	[Sort] [int] NOT NULL,
	[LevelSort] [varchar](500) NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[SystemId] [int] NOT NULL,
 CONSTRAINT [PK_SYS_ACTION] PRIMARY KEY CLUSTERED 
(
	[ActionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SYS_ActionPerms]    Script Date: 2018/10/19 17:43:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SYS_ActionPerms](
	[ActionId] [varchar](50) NOT NULL,
	[PermCode] [varchar](1024) NOT NULL,
	[CreateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_SYS_ACTIONPERMS] PRIMARY KEY CLUSTERED 
(
	[ActionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SYS_Log]    Script Date: 2018/10/19 17:43:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SYS_Log](
	[LogId] [varchar](36) NOT NULL,
	[LogType] [int] NOT NULL,
	[Remark] [nvarchar](1000) NOT NULL,
	[KeyWord] [nvarchar](200) NULL,
	[CreatedBy] [varchar](50) NULL,
	[CreateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_SYS_LOG] PRIMARY KEY CLUSTERED 
(
	[LogId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SYS_Permission]    Script Date: 2018/10/19 17:43:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SYS_Permission](
	[PermId] [nvarchar](50) NOT NULL,
	[PermName] [nvarchar](50) NOT NULL,
	[PermCode] [int] NOT NULL,
	[Controller] [varchar](50) NULL,
	[SystemId] [int] NOT NULL,
	[CreateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_SYS_PERMISSION] PRIMARY KEY CLUSTERED 
(
	[PermId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SYS_PermissionGroup]    Script Date: 2018/10/19 17:43:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SYS_PermissionGroup](
	[GroupId] [nvarchar](50) NOT NULL,
	[GroupName] [nvarchar](50) NOT NULL,
	[Permissions] [nvarchar](max) NULL,
	[CreateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_SYS_PERMISSIONGROUP] PRIMARY KEY CLUSTERED 
(
	[GroupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SYS_RoleMenus]    Script Date: 2018/10/19 17:43:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SYS_RoleMenus](
	[RoleId] [varchar](50) NOT NULL,
	[ActionId] [varchar](50) NOT NULL,
	[CreateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_SYS_ROLEMENUS] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC,
	[ActionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[SYS_Action] ([ActionId], [ParentId], [ActionName], [Url], [IconClass], [Sort], [LevelSort], [CreateTime], [SystemId]) VALUES (N'0409fe87-0c6f-4cd8-b6d7-b23d3d7fc321', N'dd4d4422-c22a-4fa9-b89f-a9fec6ec273b', N'菜单管理', N'/menu/list', NULL, 4, N'0-20181013193119-4-20181013193544', CAST(N'2018-10-13T19:35:44.777' AS DateTime), 1)
GO
INSERT [dbo].[SYS_Action] ([ActionId], [ParentId], [ActionName], [Url], [IconClass], [Sort], [LevelSort], [CreateTime], [SystemId]) VALUES (N'53430cdd-2380-4424-9f7e-0f7c019ef703', NULL, N'会员管理', N'#', NULL, 2, N'2-20181014142133', CAST(N'2018-10-14T14:21:33.700' AS DateTime), 1)
GO
INSERT [dbo].[SYS_Action] ([ActionId], [ParentId], [ActionName], [Url], [IconClass], [Sort], [LevelSort], [CreateTime], [SystemId]) VALUES (N'a14031e6-b917-4ace-8cbd-ebf371e6b3c2', N'53430cdd-2380-4424-9f7e-0f7c019ef703', N'会员等级管理', N'/memberlevel/list', NULL, 2, N'2-20181014142133-2-20181015142032', CAST(N'2018-10-15T14:20:32.263' AS DateTime), 1)
GO
INSERT [dbo].[SYS_Action] ([ActionId], [ParentId], [ActionName], [Url], [IconClass], [Sort], [LevelSort], [CreateTime], [SystemId]) VALUES (N'a2212ea9-d3a9-4051-801f-6da7b1ddd8fa', N'dd4d4422-c22a-4fa9-b89f-a9fec6ec273b', N'角色管理', N'/roles/list', NULL, 2, N'0-20181013193119-2-20181013193341', CAST(N'2018-10-13T19:33:41.250' AS DateTime), 1)
GO
INSERT [dbo].[SYS_Action] ([ActionId], [ParentId], [ActionName], [Url], [IconClass], [Sort], [LevelSort], [CreateTime], [SystemId]) VALUES (N'acd90471-8e25-44f1-a4d5-ba889be59925', N'53430cdd-2380-4424-9f7e-0f7c019ef703', N'会员管理', N'/member/list', NULL, 1, N'2-20181014142133-1-20181014142152', CAST(N'2018-10-14T14:21:52.213' AS DateTime), 1)
GO
INSERT [dbo].[SYS_Action] ([ActionId], [ParentId], [ActionName], [Url], [IconClass], [Sort], [LevelSort], [CreateTime], [SystemId]) VALUES (N'b2cb76cf-be96-4618-a4d6-425ecfb34815', N'dd4d4422-c22a-4fa9-b89f-a9fec6ec273b', N'权限组管理', N'/permission/list', NULL, 5, N'0-20181013193119-5-20181013193652', CAST(N'2018-10-13T19:36:52.313' AS DateTime), 1)
GO
INSERT [dbo].[SYS_Action] ([ActionId], [ParentId], [ActionName], [Url], [IconClass], [Sort], [LevelSort], [CreateTime], [SystemId]) VALUES (N'cc436bac-c552-4802-8097-b25eff2f276f', N'dd4d4422-c22a-4fa9-b89f-a9fec6ec273b', N'用户管理', N'/account/list', NULL, 1, N'0-20181013193119-1-20181013193255', CAST(N'2018-10-13T19:32:55.193' AS DateTime), 1)
GO
INSERT [dbo].[SYS_Action] ([ActionId], [ParentId], [ActionName], [Url], [IconClass], [Sort], [LevelSort], [CreateTime], [SystemId]) VALUES (N'd8b6cf32-e81c-4cf4-878b-52fd7f473142', N'dd4d4422-c22a-4fa9-b89f-a9fec6ec273b', N'系统图标', N'/system/icon', NULL, 8, N'0-20181013193119-8-20181013193208', CAST(N'2018-10-13T19:32:08.483' AS DateTime), 1)
GO
INSERT [dbo].[SYS_Action] ([ActionId], [ParentId], [ActionName], [Url], [IconClass], [Sort], [LevelSort], [CreateTime], [SystemId]) VALUES (N'dd4d4422-c22a-4fa9-b89f-a9fec6ec273b', NULL, N'系统管理', N'#', NULL, 0, N'0-20181013193119', CAST(N'2018-10-13T19:31:19.637' AS DateTime), 1)
GO
INSERT [dbo].[SYS_ActionPerms] ([ActionId], [PermCode], [CreateTime]) VALUES (N'0409fe87-0c6f-4cd8-b6d7-b23d3d7fc321', N'1007,1008,1006,1017', CAST(N'2018-10-13T19:44:59.730' AS DateTime))
GO
INSERT [dbo].[SYS_ActionPerms] ([ActionId], [PermCode], [CreateTime]) VALUES (N'a14031e6-b917-4ace-8cbd-ebf371e6b3c2', N'2006,2007,2005,2004', CAST(N'2018-10-16T17:38:44.550' AS DateTime))
GO
INSERT [dbo].[SYS_ActionPerms] ([ActionId], [PermCode], [CreateTime]) VALUES (N'a2212ea9-d3a9-4051-801f-6da7b1ddd8fa', N'10026,10022,10027,10025,10021,10023', CAST(N'2018-10-13T19:44:55.580' AS DateTime))
GO
INSERT [dbo].[SYS_ActionPerms] ([ActionId], [PermCode], [CreateTime]) VALUES (N'acd90471-8e25-44f1-a4d5-ba889be59925', N'2000,2002,2003,2001', CAST(N'2018-10-14T16:36:20.060' AS DateTime))
GO
INSERT [dbo].[SYS_ActionPerms] ([ActionId], [PermCode], [CreateTime]) VALUES (N'b2cb76cf-be96-4618-a4d6-425ecfb34815', N'10013,10012,1009,10011,10010', CAST(N'2018-10-13T19:45:07.490' AS DateTime))
GO
INSERT [dbo].[SYS_ActionPerms] ([ActionId], [PermCode], [CreateTime]) VALUES (N'cc436bac-c552-4802-8097-b25eff2f276f', N'1004,1005,1002,10024,1003', CAST(N'2018-10-13T19:44:49.077' AS DateTime))
GO
INSERT [dbo].[SYS_Log] ([LogId], [LogType], [Remark], [KeyWord], [CreatedBy], [CreateTime]) VALUES (N'5930ea4f-e0a9-449b-9fa7-10aefee38c9c', 2, N'商户后台【新增【编辑管理员[1004]】】', N'mark', N'admin', CAST(N'2018-10-16T17:38:37.053' AS DateTime))
GO
INSERT [dbo].[SYS_Log] ([LogId], [LogType], [Remark], [KeyWord], [CreatedBy], [CreateTime]) VALUES (N'7b6356fb-b69d-42fc-a57d-da3293ba1c92', 2, N'商户后台【新增【浏览管理员列表[1002]、编辑管理员所属角色[10024]、删除管理员[1005]、编辑管理员[1004]】】', N'运维', N'admin', CAST(N'2018-10-16T14:49:13.567' AS DateTime))
GO
INSERT [dbo].[SYS_Log] ([LogId], [LogType], [Remark], [KeyWord], [CreatedBy], [CreateTime]) VALUES (N'c593af02-c50c-4d9b-a8fd-bd6097574dac', 2, N'商户后台【删除【删除管理员[1005]、编辑管理员[1004]、添加管理员[1003]、编辑管理员所属角色[10024]】】', N'mark', N'admin', CAST(N'2018-10-17T14:11:43.993' AS DateTime))
GO
INSERT [dbo].[SYS_Log] ([LogId], [LogType], [Remark], [KeyWord], [CreatedBy], [CreateTime]) VALUES (N'ed50f82f-4277-446f-a0ca-f6c7122a24da', 2, N'商户后台【新增【添加管理员[1003]】】', N'运维', N'admin', CAST(N'2018-10-16T14:46:18.717' AS DateTime))
GO
INSERT [dbo].[SYS_Permission] ([PermId], [PermName], [PermCode], [Controller], [SystemId], [CreateTime]) VALUES (N'0107dbbf-290d-4610-9df0-cec9a976a030', N'编辑权限组', 10010, N'permission', 1, CAST(N'2018-10-19T17:38:38.627' AS DateTime))
GO
INSERT [dbo].[SYS_Permission] ([PermId], [PermName], [PermCode], [Controller], [SystemId], [CreateTime]) VALUES (N'051aac48-da22-430d-b276-57811a224818', N'Mongo缓存清除', 1994, N'mongo', 1, CAST(N'2018-10-19T17:38:38.627' AS DateTime))
GO
INSERT [dbo].[SYS_Permission] ([PermId], [PermName], [PermCode], [Controller], [SystemId], [CreateTime]) VALUES (N'1d2e5374-6a0d-4742-8f3d-935cc73504a3', N'编辑角色', 10022, N'roles', 1, CAST(N'2018-10-19T17:38:38.627' AS DateTime))
GO
INSERT [dbo].[SYS_Permission] ([PermId], [PermName], [PermCode], [Controller], [SystemId], [CreateTime]) VALUES (N'23e18fd4-08d0-4fa3-a024-9514fe60295e', N'编辑角色用户', 10027, N'roles', 1, CAST(N'2018-10-19T17:38:38.627' AS DateTime))
GO
INSERT [dbo].[SYS_Permission] ([PermId], [PermName], [PermCode], [Controller], [SystemId], [CreateTime]) VALUES (N'28c52e1d-d0e5-4cf1-9f2a-5bf6895326ef', N'编辑角色权限', 10026, N'roles', 1, CAST(N'2018-10-19T17:38:38.627' AS DateTime))
GO
INSERT [dbo].[SYS_Permission] ([PermId], [PermName], [PermCode], [Controller], [SystemId], [CreateTime]) VALUES (N'2e9c02e9-a908-47d5-bf7d-7317f2bb139c', N'编辑管理员所属角色', 10024, N'account', 1, CAST(N'2018-10-19T17:38:38.627' AS DateTime))
GO
INSERT [dbo].[SYS_Permission] ([PermId], [PermName], [PermCode], [Controller], [SystemId], [CreateTime]) VALUES (N'2f619403-b45c-4489-8f21-12e99d871089', N'编辑管理员', 1004, N'account', 1, CAST(N'2018-10-19T17:38:38.627' AS DateTime))
GO
INSERT [dbo].[SYS_Permission] ([PermId], [PermName], [PermCode], [Controller], [SystemId], [CreateTime]) VALUES (N'36010d98-ad02-4242-84b5-1edcae2d9548', N'编辑菜单', 1007, N'menu', 1, CAST(N'2018-10-19T17:38:38.627' AS DateTime))
GO
INSERT [dbo].[SYS_Permission] ([PermId], [PermName], [PermCode], [Controller], [SystemId], [CreateTime]) VALUES (N'5dc48298-42b1-491d-a8ff-a6a5843690f2', N'从权限组中删除权限', 10013, N'permission', 1, CAST(N'2018-10-19T17:38:38.627' AS DateTime))
GO
INSERT [dbo].[SYS_Permission] ([PermId], [PermName], [PermCode], [Controller], [SystemId], [CreateTime]) VALUES (N'981d9f8f-174f-43f5-a389-0dd2866ba20b', N'Mongo缓存查询', 1993, N'mongo', 1, CAST(N'2018-10-19T17:38:38.627' AS DateTime))
GO
INSERT [dbo].[SYS_Permission] ([PermId], [PermName], [PermCode], [Controller], [SystemId], [CreateTime]) VALUES (N'9a3d9748-17cf-4b08-97a3-2d5df2df433c', N'删除权限组', 10011, N'permission', 1, CAST(N'2018-10-19T17:38:38.627' AS DateTime))
GO
INSERT [dbo].[SYS_Permission] ([PermId], [PermName], [PermCode], [Controller], [SystemId], [CreateTime]) VALUES (N'a6fc96ed-c062-4229-b57b-90b7b5907d80', N'添加角色', 10021, N'roles', 1, CAST(N'2018-10-19T17:38:38.627' AS DateTime))
GO
INSERT [dbo].[SYS_Permission] ([PermId], [PermName], [PermCode], [Controller], [SystemId], [CreateTime]) VALUES (N'ad208e2b-81dd-4ae2-b91b-e945f77d21d8', N'编辑角色菜单', 10025, N'roles', 1, CAST(N'2018-10-19T17:38:38.627' AS DateTime))
GO
INSERT [dbo].[SYS_Permission] ([PermId], [PermName], [PermCode], [Controller], [SystemId], [CreateTime]) VALUES (N'b3d0172f-15f5-48fa-af36-1a122f39b39a', N'新增菜单', 1006, N'menu', 1, CAST(N'2018-10-19T17:38:38.627' AS DateTime))
GO
INSERT [dbo].[SYS_Permission] ([PermId], [PermName], [PermCode], [Controller], [SystemId], [CreateTime]) VALUES (N'c31ddcf4-b804-4f0f-a637-1c2c88444a10', N'删除管理员', 1005, N'account', 1, CAST(N'2018-10-19T17:38:38.627' AS DateTime))
GO
INSERT [dbo].[SYS_Permission] ([PermId], [PermName], [PermCode], [Controller], [SystemId], [CreateTime]) VALUES (N'c3b1cd79-6767-4075-952f-cf46e98b954a', N'添加管理员', 1003, N'account', 1, CAST(N'2018-10-19T17:38:38.627' AS DateTime))
GO
INSERT [dbo].[SYS_Permission] ([PermId], [PermName], [PermCode], [Controller], [SystemId], [CreateTime]) VALUES (N'c5413ff7-031a-42c3-96a9-255b7d120491', N'删除角色', 10023, N'roles', 1, CAST(N'2018-10-19T17:38:38.627' AS DateTime))
GO
INSERT [dbo].[SYS_Permission] ([PermId], [PermName], [PermCode], [Controller], [SystemId], [CreateTime]) VALUES (N'c574cbb2-df96-4d4c-91f0-94b285555185', N'添加权限组', 1009, N'permission', 1, CAST(N'2018-10-19T17:38:38.627' AS DateTime))
GO
INSERT [dbo].[SYS_Permission] ([PermId], [PermName], [PermCode], [Controller], [SystemId], [CreateTime]) VALUES (N'c62f8486-2061-4e0d-b658-d52a954a37f9', N'浏览管理员列表', 1002, N'account', 1, CAST(N'2018-10-19T17:38:38.627' AS DateTime))
GO
INSERT [dbo].[SYS_Permission] ([PermId], [PermName], [PermCode], [Controller], [SystemId], [CreateTime]) VALUES (N'cd72336b-9965-42a3-a22d-05d55f298dea', N'添加权限到权限组', 10012, N'permission', 1, CAST(N'2018-10-19T17:38:38.627' AS DateTime))
GO
INSERT [dbo].[SYS_Permission] ([PermId], [PermName], [PermCode], [Controller], [SystemId], [CreateTime]) VALUES (N'cd7f40c9-4c16-4b73-912e-3ac26a533d10', N'删除菜单', 1008, N'menu', 1, CAST(N'2018-10-19T17:38:38.627' AS DateTime))
GO
INSERT [dbo].[SYS_Permission] ([PermId], [PermName], [PermCode], [Controller], [SystemId], [CreateTime]) VALUES (N'd1330c67-3523-4eaf-a65c-21194ce4e69b', N'菜单权限', 1017, N'menu', 1, CAST(N'2018-10-19T17:38:38.627' AS DateTime))
GO
INSERT [dbo].[SYS_PermissionGroup] ([GroupId], [GroupName], [Permissions], [CreateTime]) VALUES (N'0210dfad-f0a8-4918-8827-cc84d0f015e6', N'会员管理', N'2004,2005,2006,2007,2000,2001,2002,2003', CAST(N'2018-10-14T16:02:54.423' AS DateTime))
GO
INSERT [dbo].[SYS_PermissionGroup] ([GroupId], [GroupName], [Permissions], [CreateTime]) VALUES (N'1a6ddb4b-eb48-4464-9e4c-480b86874668', N'系统管理', N'1002,1003,1004,10024,1005,1017,1006,1007,1008,1009,10010,10011,10012,10013,10026,10021,10022,10023,10027,10025', CAST(N'2018-10-13T19:38:10.690' AS DateTime))
GO
INSERT [dbo].[SYS_Role] ([SystemRoleId], [RoleName], [Status], [Permissions], [CreateTime]) VALUES (N'3b516cd6-3eb0-4935-a265-0d0337c69353', N'mark', 0, N'1#1002,10026,10025,10022,10027,10023,10021,2003,2002,2000,2001', CAST(N'2018-10-13T19:45:28.000' AS DateTime))
GO
INSERT [dbo].[SYS_Role] ([SystemRoleId], [RoleName], [Status], [Permissions], [CreateTime]) VALUES (N'510441dc-74cb-4b3f-8274-698496890e81', N'运维', 0, N'1#1003,1002,10024,1005,1004', CAST(N'2018-10-13T19:38:40.000' AS DateTime))
GO
INSERT [dbo].[SYS_RoleMenus] ([RoleId], [ActionId], [CreateTime]) VALUES (N'3b516cd6-3eb0-4935-a265-0d0337c69353', N'a2212ea9-d3a9-4051-801f-6da7b1ddd8fa', CAST(N'2018-10-17T14:11:44.000' AS DateTime))
GO
INSERT [dbo].[SYS_RoleMenus] ([RoleId], [ActionId], [CreateTime]) VALUES (N'3b516cd6-3eb0-4935-a265-0d0337c69353', N'acd90471-8e25-44f1-a4d5-ba889be59925', CAST(N'2018-10-17T14:11:44.000' AS DateTime))
GO
INSERT [dbo].[SYS_RoleMenus] ([RoleId], [ActionId], [CreateTime]) VALUES (N'3b516cd6-3eb0-4935-a265-0d0337c69353', N'cc436bac-c552-4802-8097-b25eff2f276f', CAST(N'2018-10-17T14:11:44.000' AS DateTime))
GO
INSERT [dbo].[SYS_RoleMenus] ([RoleId], [ActionId], [CreateTime]) VALUES (N'3b516cd6-3eb0-4935-a265-0d0337c69353', N'd8b6cf32-e81c-4cf4-878b-52fd7f473142', CAST(N'2018-10-17T14:11:44.000' AS DateTime))
GO
INSERT [dbo].[SYS_RoleMenus] ([RoleId], [ActionId], [CreateTime]) VALUES (N'3b516cd6-3eb0-4935-a265-0d0337c69353', N'dd4d4422-c22a-4fa9-b89f-a9fec6ec273b', CAST(N'2018-10-17T14:11:44.000' AS DateTime))
GO
INSERT [dbo].[SYS_RoleMenus] ([RoleId], [ActionId], [CreateTime]) VALUES (N'510441dc-74cb-4b3f-8274-698496890e81', N'cc436bac-c552-4802-8097-b25eff2f276f', CAST(N'2018-10-16T14:49:13.570' AS DateTime))
GO
INSERT [dbo].[SYS_RoleMenus] ([RoleId], [ActionId], [CreateTime]) VALUES (N'510441dc-74cb-4b3f-8274-698496890e81', N'dd4d4422-c22a-4fa9-b89f-a9fec6ec273b', CAST(N'2018-10-16T14:49:13.570' AS DateTime))
GO
INSERT [dbo].[SYS_User] ([SystemUserId], [UserName], [Password], [RealName], [Email], [UserType], [Mobile], [Status], [CreateTime], [SystemId]) VALUES (N'0a1eb768-197a-4c87-914c-3616ef18aaf4', N'xb001', N'e10adc3949ba59abbe56e057f20f883e', N'xb001', N'mark2@qq.com', 0, N'13345678254', 0, CAST(N'2018-10-16T17:39:52.927' AS DateTime), 3)
GO
INSERT [dbo].[SYS_User] ([SystemUserId], [UserName], [Password], [RealName], [Email], [UserType], [Mobile], [Status], [CreateTime], [SystemId]) VALUES (N'1', N'admin', N'e10adc3949ba59abbe56e057f20f883e', N'admin', N'admin@qq.com', 1, N'13012345678', 0, CAST(N'2018-10-13T00:00:00.000' AS DateTime), 1)
GO
INSERT [dbo].[SYS_User] ([SystemUserId], [UserName], [Password], [RealName], [Email], [UserType], [Mobile], [Status], [CreateTime], [SystemId]) VALUES (N'1e27cf48-1b03-4550-859e-3113a2024b99', N'mark', N'e10adc3949ba59abbe56e057f20f883e', N'mark', N'mark1@qq.com', 0, N'13345678954', 0, CAST(N'2018-10-13T19:43:02.180' AS DateTime), 3)
GO
INSERT [dbo].[SYS_UserRoles] ([SystemUserId], [SystemRoleId], [CreateTime]) VALUES (N'1e27cf48-1b03-4550-859e-3113a2024b99', N'3b516cd6-3eb0-4935-a265-0d0337c69353', CAST(N'2018-10-14T16:30:08.087' AS DateTime))
GO
ALTER TABLE [dbo].[SYS_Action] ADD  CONSTRAINT [DF__SYS_Action__Sort__37A5467C]  DEFAULT ((0)) FOR [Sort]
GO
ALTER TABLE [dbo].[SYS_Role] ADD  DEFAULT ((0)) FOR [Status]
GO
ALTER TABLE [dbo].[SYS_User] ADD  CONSTRAINT [DF__SYS_User__UserTy__412EB0B6]  DEFAULT ((0)) FOR [UserType]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'菜单编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_Action', @level2type=N'COLUMN',@level2name=N'ActionId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'父菜单' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_Action', @level2type=N'COLUMN',@level2name=N'ParentId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'菜单名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_Action', @level2type=N'COLUMN',@level2name=N'ActionName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'页面地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_Action', @level2type=N'COLUMN',@level2name=N'Url'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'菜单图标' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_Action', @level2type=N'COLUMN',@level2name=N'IconClass'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'排序' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_Action', @level2type=N'COLUMN',@level2name=N'Sort'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'分级排序' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_Action', @level2type=N'COLUMN',@level2name=N'LevelSort'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_Action', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'菜单编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_ActionPerms', @level2type=N'COLUMN',@level2name=N'ActionId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_ActionPerms', @level2type=N'COLUMN',@level2name=N'PermCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_ActionPerms', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'权限编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_Log', @level2type=N'COLUMN',@level2name=N'LogId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'日志类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_Log', @level2type=N'COLUMN',@level2name=N'LogType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'日志内容' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_Log', @level2type=N'COLUMN',@level2name=N'Remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'关键字' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_Log', @level2type=N'COLUMN',@level2name=N'KeyWord'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_Log', @level2type=N'COLUMN',@level2name=N'CreatedBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_Log', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'系统操作日志表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_Log'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'权限组编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_Permission', @level2type=N'COLUMN',@level2name=N'PermId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'权限组名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_Permission', @level2type=N'COLUMN',@level2name=N'PermName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'权限列表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_Permission', @level2type=N'COLUMN',@level2name=N'PermCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_Permission', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'权限组编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_PermissionGroup', @level2type=N'COLUMN',@level2name=N'GroupId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'权限组名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_PermissionGroup', @level2type=N'COLUMN',@level2name=N'GroupName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'权限列表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_PermissionGroup', @level2type=N'COLUMN',@level2name=N'Permissions'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_PermissionGroup', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_Role', @level2type=N'COLUMN',@level2name=N'SystemRoleId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_Role', @level2type=N'COLUMN',@level2name=N'RoleName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'状态(0 正常 1 禁用)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_Role', @level2type=N'COLUMN',@level2name=N'Status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'权限列表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_Role', @level2type=N'COLUMN',@level2name=N'Permissions'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_Role', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_RoleMenus', @level2type=N'COLUMN',@level2name=N'RoleId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'菜单编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_RoleMenus', @level2type=N'COLUMN',@level2name=N'ActionId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_RoleMenus', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_User', @level2type=N'COLUMN',@level2name=N'SystemUserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'帐号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_User', @level2type=N'COLUMN',@level2name=N'UserName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'密码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_User', @level2type=N'COLUMN',@level2name=N'Password'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'姓名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_User', @level2type=N'COLUMN',@level2name=N'RealName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'邮箱' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_User', @level2type=N'COLUMN',@level2name=N'Email'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否超级管理员(0 普通管理员 1 超级管理员)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_User', @level2type=N'COLUMN',@level2name=N'UserType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'手机号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_User', @level2type=N'COLUMN',@level2name=N'Mobile'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户状态(0 正常 1 锁定)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_User', @level2type=N'COLUMN',@level2name=N'Status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_User', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'系统编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_User', @level2type=N'COLUMN',@level2name=N'SystemId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_UserRoles', @level2type=N'COLUMN',@level2name=N'SystemUserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_UserRoles', @level2type=N'COLUMN',@level2name=N'SystemRoleId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_UserRoles', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
USE [master]
GO
ALTER DATABASE [Poc_System] SET  READ_WRITE 
GO
