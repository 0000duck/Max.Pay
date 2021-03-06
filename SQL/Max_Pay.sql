USE [Max_Pay]
GO
/****** Object:  Table [dbo].[Merchant]    Script Date: 2018/11/10 23:07:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Merchant](
	[MerchantId] [varchar](50) NOT NULL,
	[MerchantNo] [varchar](50) NOT NULL,
	[MerchantName] [nvarchar](100) NOT NULL,
	[AgentId] [varchar](50) NULL,
	[AgentNo] [varchar](50) NULL,
	[Mobile] [varchar](50) NULL,
	[QQ] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[Website] [varchar](500) NULL,
	[Md5Key] [varchar](500) NULL,
	[WithdrawPwd] [varchar](50) NULL,
	[BackWhiteIp] [varchar](500) NULL,
	[ApiWhiteIp] [varchar](500) NULL,
	[Status] [int] NOT NULL,
	[Remark] [varchar](500) NULL,
	[CreateTime] [datetime] NOT NULL,
	[CreateBy] [varchar](50) NOT NULL,
	[UpdateTime] [datetime] NULL,
	[UpdateBy] [varchar](50) NULL,
	[Isdelete] [int] NOT NULL,
 CONSTRAINT [PK_MERCHANT] PRIMARY KEY CLUSTERED 
(
	[MerchantId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MerchantPayService]    Script Date: 2018/11/10 23:07:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MerchantPayService](
	[MerchantPayServiceId] [varchar](50) NOT NULL,
	[MerchantId] [varchar](50) NOT NULL,
	[ServiceId] [varchar](50) NOT NULL,
	[MerchantFeeRate] [decimal](18, 4) NOT NULL,
	[AgentFeeRate] [decimal](18, 4) NOT NULL,
	[Status] [int] NOT NULL,
	[Remark] [varchar](500) NULL,
	[CreateTime] [datetime] NOT NULL,
	[CreateBy] [varchar](50) NOT NULL,
	[UpdateTime] [datetime] NULL,
	[UpdateBy] [varchar](50) NULL,
	[Isdelete] [int] NOT NULL,
	[PayChannelId] [varchar](50) NOT NULL,
	[ServiceType] [int] NOT NULL,
 CONSTRAINT [PK_MERCHANTPAYSERVICE] PRIMARY KEY CLUSTERED 
(
	[MerchantPayServiceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PayService]    Script Date: 2018/11/10 23:07:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PayService](
	[ServiceId] [varchar](50) NOT NULL,
	[ServiceType] [int] NOT NULL,
	[ServiceCode] [varchar](50) NOT NULL,
	[ServiceName] [varchar](50) NOT NULL,
	[Status] [int] NOT NULL,
	[Remark] [varchar](500) NULL,
	[CreateTime] [datetime] NOT NULL,
	[CreateBy] [varchar](50) NOT NULL,
	[UpdateTime] [datetime] NULL,
	[UpdateBy] [varchar](50) NULL,
	[Isdelete] [int] NOT NULL,
 CONSTRAINT [PK_PAYSERVICE] PRIMARY KEY CLUSTERED 
(
	[ServiceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PayChannel]    Script Date: 2018/11/10 23:07:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PayChannel](
	[ChannelId] [varchar](50) NOT NULL,
	[ChannelType] [int] NOT NULL,
	[ChannelName] [varchar](100) NOT NULL,
	[ChannelCode] [varchar](50) NOT NULL,
	[MerchantNo] [varchar](50) NOT NULL,
	[MerchantKey] [varchar](500) NULL,
	[MerchantInfo] [varchar](100) NULL,
	[PaySite] [varchar](500) NOT NULL,
	[MinOrderAmount] [decimal](19, 4) NOT NULL,
	[MaxOrderAmount] [decimal](19, 4) NOT NULL,
	[SettleMode] [int] NOT NULL,
	[FeeRate] [decimal](19, 4) NOT NULL,
	[Status] [int] NOT NULL,
	[Remark] [varchar](500) NULL,
	[CreateTime] [datetime] NOT NULL,
	[CreateBy] [varchar](50) NOT NULL,
	[UpdateTime] [datetime] NULL,
	[UpdateBy] [varchar](50) NULL,
	[Isdelete] [int] NOT NULL,
 CONSTRAINT [PK_PAYCHANNEL] PRIMARY KEY CLUSTERED 
(
	[ChannelId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[V_MerchantPayProduct]    Script Date: 2018/11/10 23:07:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE view [dbo].[V_MerchantPayProduct] as
SELECT  
	mp.MerchantPayServiceId
	,mp.ServiceId
	,mp.MerchantId
	,mp.PayChannelId
	,mp.AgentFeeRate
	,mp.MerchantFeeRate
	,mp.Status
	,mp.Remark
	,mp.CreateTime
	,mp.CreateBy
	,mp.Isdelete
	,p.ServiceName
	,p.ServiceType
	,p.ServiceCode
	,m.MerchantName
	,pc.ChannelName
	,pc.FeeRate
	,1 as IsOpen
  FROM PayService  p
   left join MerchantPayService mp on mp.ServiceId=p.ServiceId
   left join Merchant m on  m.MerchantId = mp.MerchantId
   left join PayChannel pc on mp.PayChannelId=pc.ChannelId
GO
/****** Object:  Table [dbo].[Agent]    Script Date: 2018/11/10 23:07:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Agent](
	[AgentId] [varchar](50) NOT NULL,
	[AgentNo] [varchar](50) NOT NULL,
	[AgentName] [nvarchar](100) NOT NULL,
	[Mobile] [varchar](50) NULL,
	[QQ] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[Status] [int] NOT NULL,
	[Remark] [varchar](500) NULL,
	[CreateTime] [datetime] NOT NULL,
	[CreateBy] [varchar](50) NOT NULL,
	[UpdateTime] [datetime] NULL,
	[UpdateBy] [varchar](50) NULL,
	[Isdelete] [int] NOT NULL,
 CONSTRAINT [PK_AGENT] PRIMARY KEY CLUSTERED 
(
	[AgentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bank]    Script Date: 2018/11/10 23:07:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bank](
	[BankId] [varchar](50) NOT NULL,
	[BankCode] [varchar](50) NOT NULL,
	[BankName] [varchar](50) NOT NULL,
	[SeqNo] [varchar](50) NULL,
	[Status] [int] NOT NULL,
	[Isdelete] [int] NOT NULL,
 CONSTRAINT [PK_BANK] PRIMARY KEY CLUSTERED 
(
	[BankId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MerchantBankAccount]    Script Date: 2018/11/10 23:07:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MerchantBankAccount](
	[AccountId] [varchar](50) NOT NULL,
	[AccountName] [varchar](50) NOT NULL,
	[AccountNumber] [varchar](50) NOT NULL,
	[BankName] [varchar](50) NOT NULL,
	[BankCode] [varchar](50) NOT NULL,
	[BankBranchName] [varchar](100) NULL,
	[Province] [varchar](50) NULL,
	[City] [varchar](50) NULL,
	[Mobile] [varchar](50) NULL,
	[IdCardNo] [varchar](50) NULL,
	[Status] [int] NOT NULL,
	[Remark] [varchar](500) NULL,
	[CreateTime] [datetime] NOT NULL,
	[CreateBy] [varchar](50) NOT NULL,
	[UpdateTime] [datetime] NULL,
	[UpdateBy] [varchar](50) NULL,
	[Isdelete] [int] NOT NULL,
	[MerchantId] [varchar](50) NOT NULL,
 CONSTRAINT [PK_MERCHANTBANKACCOUNT] PRIMARY KEY CLUSTERED 
(
	[AccountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NotifyRecord]    Script Date: 2018/11/10 23:07:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NotifyRecord](
	[RequestId] [varchar](50) NOT NULL,
	[OrderId] [varchar](50) NOT NULL,
	[OrderType] [varchar](50) NOT NULL,
	[NotifyUrl] [varchar](500) NOT NULL,
	[NotifyData] [varchar](500) NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[ResponseMsg] [varchar](500) NOT NULL,
	[NotifyTime] [datetime] NOT NULL,
	[Status] [int] NOT NULL,
	[Remark] [nvarchar](1000) NULL,
 CONSTRAINT [PK_NOTIFYRECORD] PRIMARY KEY CLUSTERED 
(
	[RequestId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OptLog]    Script Date: 2018/11/10 23:07:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OptLog](
	[LogId] [varchar](50) NOT NULL,
	[OptName] [nvarchar](100) NOT NULL,
	[LogType] [nvarchar](50) NOT NULL,
	[Ip] [varchar](50) NULL,
	[OptObjectId] [varchar](50) NULL,
	[LogContent] [nvarchar](1000) NOT NULL,
	[LogTime] [datetime] NOT NULL,
 CONSTRAINT [PK_OPTLOG] PRIMARY KEY CLUSTERED 
(
	[LogId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PayOrder]    Script Date: 2018/11/10 23:07:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PayOrder](
	[OrderId] [varchar](36) NOT NULL,
	[OrderNo] [varchar](50) NOT NULL,
	[AgentNo] [varchar](50) NULL,
	[MerchantId] [varchar](50) NOT NULL,
	[MerchantOrderNo] [varchar](50) NOT NULL,
	[MerchantOrderTime] [datetime] NOT NULL,
	[MemberInfo] [varchar](50) NULL,
	[Ip] [varchar](50) NOT NULL,
	[DeviceType] [varchar](50) NOT NULL,
	[BankInfo] [varchar](50) NULL,
	[BankCode] [varchar](50) NULL,
	[NotifyUrl] [varchar](500) NOT NULL,
	[ReturnUrl] [varchar](500) NULL,
	[PreorderAmount] [decimal](19, 4) NOT NULL,
	[OrderAmount] [decimal](19, 4) NOT NULL,
	[OrderDescription] [nvarchar](100) NULL,
	[ExtendField] [nvarchar](100) NULL,
	[ServiceId] [varchar](50) NULL,
	[ChannelType] [int] NOT NULL,
	[ChannelId] [varchar](50) NOT NULL,
	[ChannelName] [varchar](100) NOT NULL,
	[SettleMode] [varchar](50) NOT NULL,
	[SettleDate] [datetime] NULL,
	[FeeMode] [varchar](50) NULL,
	[TransRate] [decimal](19, 4) NOT NULL,
	[ServiceRate] [decimal](19, 4) NOT NULL,
	[costRate] [decimal](19, 4) NOT NULL,
	[TransFee] [decimal](19, 4) NOT NULL,
	[ServiceFee] [decimal](19, 4) NOT NULL,
	[costFee] [decimal](19, 4) NOT NULL,
	[TransAmount] [decimal](19, 4) NOT NULL,
	[PayStatus] [int] NOT NULL,
	[PayTime] [datetime] NULL,
	[NotifyStatus] [int] NOT NULL,
	[settleToMerchant] [int] NULL,
	[settleToCustomer] [int] NULL,
	[TransactionId] [varchar](50) NULL,
	[CreateTime] [datetime] NOT NULL,
	[NotifyCount] [int] NOT NULL,
	[NotifyMsg] [nvarchar](100) NULL,
	[QueryCount] [int] NOT NULL,
	[NotifyTime] [datetime] NULL,
 CONSTRAINT [PK_PAYORDER] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Settlement]    Script Date: 2018/11/10 23:07:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Settlement](
	[OrderId] [varchar](50) NOT NULL,
	[OrderNo] [varchar](50) NOT NULL,
	[AccountId] [varchar](50) NULL,
	[MerchantNo] [varchar](50) NOT NULL,
	[MerchantOrderNo] [varchar](50) NOT NULL,
	[OrderAmount] [decimal](19, 4) NOT NULL,
	[TransFee] [decimal](19, 4) NOT NULL,
	[TransAmount] [decimal](19, 4) NOT NULL,
	[AccountName] [varchar](50) NOT NULL,
	[AccountNumber] [varchar](50) NOT NULL,
	[BankName] [varchar](50) NOT NULL,
	[BankCode] [varchar](50) NOT NULL,
	[BankBranchName] [varchar](100) NULL,
	[Province] [varchar](50) NULL,
	[City] [varchar](50) NULL,
	[Mobile] [varchar](50) NULL,
	[ExtendField] [nvarchar](100) NULL,
	[Status] [varchar](50) NOT NULL,
	[QueryCount] [int] NOT NULL,
	[CallbackStatus] [int] NOT NULL,
	[CallbackCount] [int] NOT NULL,
	[CallbackTime] [datetime] NULL,
	[CallbackMsg] [nvarchar](100) NULL,
	[CreateBy] [varchar](50) NULL,
	[CreateTime] [datetime] NOT NULL,
	[AuditStatus] [int] NOT NULL,
	[AuditTime] [datetime] NULL,
	[AuditBy] [varchar](50) NULL,
	[Remark] [varchar](500) NULL,
 CONSTRAINT [PK_SETTLEMENT] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transaction]    Script Date: 2018/11/10 23:07:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transaction](
	[TransactionId] [varchar](50) NOT NULL,
	[TransType] [int] NOT NULL,
	[TransAmount] [decimal](19, 4) NOT NULL,
	[OrderAmount] [decimal](19, 4) NOT NULL,
	[TransFee] [decimal](19, 4) NOT NULL,
	[ServiceFee] [decimal](19, 4) NOT NULL,
	[costFee] [decimal](19, 4) NOT NULL,
	[Remark] [varchar](100) NULL,
	[optName] [varchar](100) NULL,
	[CreateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_TRANSACTION] PRIMARY KEY CLUSTERED 
(
	[TransactionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Agent] ([AgentId], [AgentNo], [AgentName], [Mobile], [QQ], [Email], [Status], [Remark], [CreateTime], [CreateBy], [UpdateTime], [UpdateBy], [Isdelete]) VALUES (N'7994b36a-29c2-450e-bbc9-e7fe8c3365f5', N'33z', N'张三', NULL, NULL, NULL, 0, NULL, CAST(N'2018-10-25T22:50:27.613' AS DateTime), N'admin', NULL, NULL, 0)
GO
INSERT [dbo].[Agent] ([AgentId], [AgentNo], [AgentName], [Mobile], [QQ], [Email], [Status], [Remark], [CreateTime], [CreateBy], [UpdateTime], [UpdateBy], [Isdelete]) VALUES (N'c949731c-de82-431c-bb9b-184f0b6e9f83', N'10085', N'代理马大爷', NULL, NULL, NULL, 0, N'支付宝费率1.2', CAST(N'2018-10-25T22:50:00.173' AS DateTime), N'admin', NULL, NULL, 0)
GO
INSERT [dbo].[Bank] ([BankId], [BankCode], [BankName], [SeqNo], [Status], [Isdelete]) VALUES (N'ea295068-99d4-4ce5-b07b-49b99db46069', N'ICBC', N'工商银行', N'12', 0, 0)
GO
INSERT [dbo].[Merchant] ([MerchantId], [MerchantNo], [MerchantName], [AgentId], [AgentNo], [Mobile], [QQ], [Email], [Website], [Md5Key], [WithdrawPwd], [BackWhiteIp], [ApiWhiteIp], [Status], [Remark], [CreateTime], [CreateBy], [UpdateTime], [UpdateBy], [Isdelete]) VALUES (N'2b14dfaf-49b3-43b0-9574-cb9ae0d2e8bf', N'10010', N'卡拉支付宝', NULL, NULL, N'13345678954', NULL, N'132434', NULL, N'65cffd71580b4510a4c044510f55db4f', NULL, NULL, NULL, 0, NULL, CAST(N'2018-10-20T00:40:18.343' AS DateTime), N'admin', NULL, NULL, 0)
GO
INSERT [dbo].[Merchant] ([MerchantId], [MerchantNo], [MerchantName], [AgentId], [AgentNo], [Mobile], [QQ], [Email], [Website], [Md5Key], [WithdrawPwd], [BackWhiteIp], [ApiWhiteIp], [Status], [Remark], [CreateTime], [CreateBy], [UpdateTime], [UpdateBy], [Isdelete]) VALUES (N'66c2db69-b5cb-4acf-b440-5a91df1471e8', N'10086', N'天天支付', NULL, NULL, NULL, NULL, NULL, NULL, N'16cc36db2722437597c178a72f26ac83', NULL, NULL, NULL, 0, NULL, CAST(N'2018-10-21T15:22:09.747' AS DateTime), N'admin', NULL, NULL, 0)
GO
INSERT [dbo].[MerchantBankAccount] ([AccountId], [AccountName], [AccountNumber], [BankName], [BankCode], [BankBranchName], [Province], [City], [Mobile], [IdCardNo], [Status], [Remark], [CreateTime], [CreateBy], [UpdateTime], [UpdateBy], [Isdelete], [MerchantId]) VALUES (N'0369841d-e0f9-433a-8751-f8e0ccfb3393', N'郭富城', N'452646567511466', N'建设银行', N'CCB', N'广州珠江新城支行', N'广东', N'广州', N'13345678954', N'456956262645951566', 0, N'建设', CAST(N'2018-10-21T15:19:06.560' AS DateTime), N'admin', CAST(N'2018-10-21T15:20:09.547' AS DateTime), N'admin', 0, N'2b14dfaf-49b3-43b0-9574-cb9ae0d2e8bf')
GO
INSERT [dbo].[MerchantBankAccount] ([AccountId], [AccountName], [AccountNumber], [BankName], [BankCode], [BankBranchName], [Province], [City], [Mobile], [IdCardNo], [Status], [Remark], [CreateTime], [CreateBy], [UpdateTime], [UpdateBy], [Isdelete], [MerchantId]) VALUES (N'59e2d3d4-7ca8-4c6a-bf35-c317fb595f39', N'kobe', N'4516466556', N'招商银行', N'CMB', NULL, NULL, NULL, NULL, NULL, 0, NULL, CAST(N'2018-10-20T16:59:23.413' AS DateTime), N'admin', NULL, NULL, 1, N'2b14dfaf-49b3-43b0-9574-cb9ae0d2e8bf')
GO
INSERT [dbo].[MerchantBankAccount] ([AccountId], [AccountName], [AccountNumber], [BankName], [BankCode], [BankBranchName], [Province], [City], [Mobile], [IdCardNo], [Status], [Remark], [CreateTime], [CreateBy], [UpdateTime], [UpdateBy], [Isdelete], [MerchantId]) VALUES (N'c1721d6d-dc91-41fd-8fc1-2d15bdff6c7e', N'mark', N'412654846565454', N'工商银行', N'ICBC', NULL, NULL, NULL, N'13345678954', NULL, 0, N'哈哈
', CAST(N'2018-10-20T16:52:59.613' AS DateTime), N'admin', CAST(N'2018-10-20T22:43:58.817' AS DateTime), N'admin', 0, N'2b14dfaf-49b3-43b0-9574-cb9ae0d2e8bf')
GO
INSERT [dbo].[MerchantPayService] ([MerchantPayServiceId], [MerchantId], [ServiceId], [MerchantFeeRate], [AgentFeeRate], [Status], [Remark], [CreateTime], [CreateBy], [UpdateTime], [UpdateBy], [Isdelete], [PayChannelId], [ServiceType]) VALUES (N'8a8c2788-6e5a-417c-b4f4-0772a89a18f8', N'66c2db69-b5cb-4acf-b440-5a91df1471e8', N'063a2563-9548-42f5-b29b-eacc2565b064', CAST(2.0000 AS Decimal(18, 4)), CAST(1.0000 AS Decimal(18, 4)), 0, NULL, CAST(N'2018-10-21T21:07:55.360' AS DateTime), N'admin', CAST(N'2018-10-25T22:26:04.033' AS DateTime), N'admin', 0, N'68bfa6a6-3130-4cac-9ddd-fb50f4c30822', 1)
GO
INSERT [dbo].[MerchantPayService] ([MerchantPayServiceId], [MerchantId], [ServiceId], [MerchantFeeRate], [AgentFeeRate], [Status], [Remark], [CreateTime], [CreateBy], [UpdateTime], [UpdateBy], [Isdelete], [PayChannelId], [ServiceType]) VALUES (N'a704c3e8-7311-4c3b-aaf7-574a1f3a8893', N'66c2db69-b5cb-4acf-b440-5a91df1471e8', N'287f27b5-c268-45ec-8b5b-36f5adde15cf', CAST(1.9000 AS Decimal(18, 4)), CAST(1.8000 AS Decimal(18, 4)), 0, NULL, CAST(N'2018-10-21T19:49:23.930' AS DateTime), N'admin', NULL, NULL, 0, N'2268e39b-7efd-4d72-b0e5-ebe173d0e57e', 3)
GO
INSERT [dbo].[MerchantPayService] ([MerchantPayServiceId], [MerchantId], [ServiceId], [MerchantFeeRate], [AgentFeeRate], [Status], [Remark], [CreateTime], [CreateBy], [UpdateTime], [UpdateBy], [Isdelete], [PayChannelId], [ServiceType]) VALUES (N'caa32c84-ae28-4441-8da5-255553c5c914', N'2b14dfaf-49b3-43b0-9574-cb9ae0d2e8bf', N'063a2563-9548-42f5-b29b-eacc2565b064', CAST(2.9000 AS Decimal(18, 4)), CAST(1.0000 AS Decimal(18, 4)), 0, NULL, CAST(N'2018-10-21T01:05:56.073' AS DateTime), N'admin', CAST(N'2018-10-25T22:26:04.033' AS DateTime), N'admin', 0, N'68bfa6a6-3130-4cac-9ddd-fb50f4c30822', 1)
GO
INSERT [dbo].[MerchantPayService] ([MerchantPayServiceId], [MerchantId], [ServiceId], [MerchantFeeRate], [AgentFeeRate], [Status], [Remark], [CreateTime], [CreateBy], [UpdateTime], [UpdateBy], [Isdelete], [PayChannelId], [ServiceType]) VALUES (N'e0bc332a-e712-401a-8844-f843a808cd3c', N'2b14dfaf-49b3-43b0-9574-cb9ae0d2e8bf', N'7eea705b-1aa8-47d8-9f54-af046d8c721f', CAST(2.2000 AS Decimal(18, 4)), CAST(1.8000 AS Decimal(18, 4)), 0, N'哈哈哈', CAST(N'2018-10-21T01:07:59.463' AS DateTime), N'admin', NULL, NULL, 0, N'e46f2151-205f-432b-9041-27044215b6ef', 2)
GO
INSERT [dbo].[PayChannel] ([ChannelId], [ChannelType], [ChannelName], [ChannelCode], [MerchantNo], [MerchantKey], [MerchantInfo], [PaySite], [MinOrderAmount], [MaxOrderAmount], [SettleMode], [FeeRate], [Status], [Remark], [CreateTime], [CreateBy], [UpdateTime], [UpdateBy], [Isdelete]) VALUES (N'2268e39b-7efd-4d72-b0e5-ebe173d0e57e', 3, N'mark微信支付', N'jubaopay', N'10010', N'f2c773ca049f49418f67cd17ba24108e', N'kalapay', N'www.pay.max.com', CAST(12.0000 AS Decimal(19, 4)), CAST(122222.0000 AS Decimal(19, 4)), 0, CAST(1.5000 AS Decimal(19, 4)), 0, NULL, CAST(N'2018-10-21T19:49:01.507' AS DateTime), N'admin', NULL, NULL, 0)
GO
INSERT [dbo].[PayChannel] ([ChannelId], [ChannelType], [ChannelName], [ChannelCode], [MerchantNo], [MerchantKey], [MerchantInfo], [PaySite], [MinOrderAmount], [MaxOrderAmount], [SettleMode], [FeeRate], [Status], [Remark], [CreateTime], [CreateBy], [UpdateTime], [UpdateBy], [Isdelete]) VALUES (N'68bfa6a6-3130-4cac-9ddd-fb50f4c30822', 1, N'卡拉支付宝', N'kalapay', N'10086', N'f2c773ca049f49418f67cd17ba24108e', N'kalapay', N'www.pay.max.com', CAST(10.0000 AS Decimal(19, 4)), CAST(100000.0000 AS Decimal(19, 4)), 0, CAST(2.6000 AS Decimal(19, 4)), 0, N'哈哈', CAST(N'2018-10-21T00:45:58.880' AS DateTime), N'admin', CAST(N'2018-10-21T01:15:46.153' AS DateTime), N'admin', 0)
GO
INSERT [dbo].[PayChannel] ([ChannelId], [ChannelType], [ChannelName], [ChannelCode], [MerchantNo], [MerchantKey], [MerchantInfo], [PaySite], [MinOrderAmount], [MaxOrderAmount], [SettleMode], [FeeRate], [Status], [Remark], [CreateTime], [CreateBy], [UpdateTime], [UpdateBy], [Isdelete]) VALUES (N'e46f2151-205f-432b-9041-27044215b6ef', 2, N'天空支付宝H5', N'huizhongpay', N'10086', N'f2c773ca049f49418f67cd17ba24108e', N'kalapay', N'www.pay.max.com', CAST(10.0000 AS Decimal(19, 4)), CAST(1000.0000 AS Decimal(19, 4)), 0, CAST(1.6000 AS Decimal(19, 4)), 0, N'呵呵', CAST(N'2018-10-21T01:07:36.003' AS DateTime), N'admin', CAST(N'2018-10-21T01:15:51.920' AS DateTime), N'admin', 1)
GO
INSERT [dbo].[PayOrder] ([OrderId], [OrderNo], [AgentNo], [MerchantId], [MerchantOrderNo], [MerchantOrderTime], [MemberInfo], [Ip], [DeviceType], [BankInfo], [BankCode], [NotifyUrl], [ReturnUrl], [PreorderAmount], [OrderAmount], [OrderDescription], [ExtendField], [ServiceId], [ChannelType], [ChannelId], [ChannelName], [SettleMode], [SettleDate], [FeeMode], [TransRate], [ServiceRate], [costRate], [TransFee], [ServiceFee], [costFee], [TransAmount], [PayStatus], [PayTime], [NotifyStatus], [settleToMerchant], [settleToCustomer], [TransactionId], [CreateTime], [NotifyCount], [NotifyMsg], [QueryCount], [NotifyTime]) VALUES (N'1', N'201810232355145896', N'1', N'2b14dfaf-49b3-43b0-9574-cb9ae0d2e8bf', N'12546', CAST(N'2018-10-23T23:54:00.000' AS DateTime), NULL, N'192.168.1.10', N'wap', NULL, NULL, N'http://google.com', NULL, CAST(100.0000 AS Decimal(19, 4)), CAST(100.0000 AS Decimal(19, 4)), N'max', NULL, N'063a2563-9548-42f5-b29b-eacc2565b064', 1, N'2268e39b-7efd-4d72-b0e5-ebe173d0e57e', N'卡拉支付宝', N'1', NULL, N'1', CAST(0.0200 AS Decimal(19, 4)), CAST(0.0200 AS Decimal(19, 4)), CAST(0.0000 AS Decimal(19, 4)), CAST(2.0000 AS Decimal(19, 4)), CAST(2.0000 AS Decimal(19, 4)), CAST(0.0000 AS Decimal(19, 4)), CAST(98.0000 AS Decimal(19, 4)), 2, CAST(N'2018-10-23T23:55:00.000' AS DateTime), 1, NULL, NULL, N'1', CAST(N'2018-10-23T23:54:00.000' AS DateTime), 1, N'success', 1, CAST(N'2018-10-23T23:56:00.000' AS DateTime))
GO
INSERT [dbo].[PayService] ([ServiceId], [ServiceType], [ServiceCode], [ServiceName], [Status], [Remark], [CreateTime], [CreateBy], [UpdateTime], [UpdateBy], [Isdelete]) VALUES (N'063a2563-9548-42f5-b29b-eacc2565b064', 1, N'alipay', N'支付宝扫码', 0, NULL, CAST(N'2018-10-20T18:38:59.950' AS DateTime), N'admin', CAST(N'2018-10-21T20:16:05.007' AS DateTime), N'admin', 0)
GO
INSERT [dbo].[PayService] ([ServiceId], [ServiceType], [ServiceCode], [ServiceName], [Status], [Remark], [CreateTime], [CreateBy], [UpdateTime], [UpdateBy], [Isdelete]) VALUES (N'287f27b5-c268-45ec-8b5b-36f5adde15cf', 3, N'wechat', N'微信扫码', 0, N'哈哈', CAST(N'2018-10-20T18:39:38.337' AS DateTime), N'admin', CAST(N'2018-10-21T20:16:11.993' AS DateTime), N'admin', 0)
GO
INSERT [dbo].[PayService] ([ServiceId], [ServiceType], [ServiceCode], [ServiceName], [Status], [Remark], [CreateTime], [CreateBy], [UpdateTime], [UpdateBy], [Isdelete]) VALUES (N'7eea705b-1aa8-47d8-9f54-af046d8c721f', 2, N'alipayH5', N'支付宝H5', 0, NULL, CAST(N'2018-10-20T18:39:16.673' AS DateTime), N'admin', CAST(N'2018-10-21T20:14:12.097' AS DateTime), N'admin', 0)
GO
INSERT [dbo].[Settlement] ([OrderId], [OrderNo], [AccountId], [MerchantNo], [MerchantOrderNo], [OrderAmount], [TransFee], [TransAmount], [AccountName], [AccountNumber], [BankName], [BankCode], [BankBranchName], [Province], [City], [Mobile], [ExtendField], [Status], [QueryCount], [CallbackStatus], [CallbackCount], [CallbackTime], [CallbackMsg], [CreateBy], [CreateTime], [AuditStatus], [AuditTime], [AuditBy], [Remark]) VALUES (N'1', N'2018565655656546', N'1', N'10086', N'1', CAST(1000.0000 AS Decimal(19, 4)), CAST(3.0000 AS Decimal(19, 4)), CAST(997.0000 AS Decimal(19, 4)), N'mark', N'45626161665264566', N'工商银行', N'icbc', N'广州支行', N'广州', N'广州', N'13456231547', NULL, N'1', 1, 1, 1, CAST(N'2018-10-25T00:00:00.000' AS DateTime), N'ok', N'1', CAST(N'2018-10-25T00:00:00.000' AS DateTime), 1, CAST(N'2018-10-25T00:00:00.000' AS DateTime), N'1', NULL)
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'代理ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Agent', @level2type=N'COLUMN',@level2name=N'AgentId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'代理编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Agent', @level2type=N'COLUMN',@level2name=N'AgentNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'代理名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Agent', @level2type=N'COLUMN',@level2name=N'AgentName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'电话' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Agent', @level2type=N'COLUMN',@level2name=N'Mobile'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'QQ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Agent', @level2type=N'COLUMN',@level2name=N'QQ'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'邮箱' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Agent', @level2type=N'COLUMN',@level2name=N'Email'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Agent', @level2type=N'COLUMN',@level2name=N'Status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Agent', @level2type=N'COLUMN',@level2name=N'Remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Agent', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Agent', @level2type=N'COLUMN',@level2name=N'CreateBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'更新时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Agent', @level2type=N'COLUMN',@level2name=N'UpdateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'更新人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Agent', @level2type=N'COLUMN',@level2name=N'UpdateBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否删除' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Agent', @level2type=N'COLUMN',@level2name=N'Isdelete'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'代理表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Agent'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'银行ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Bank', @level2type=N'COLUMN',@level2name=N'BankId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'银行代码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Bank', @level2type=N'COLUMN',@level2name=N'BankCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'银行名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Bank', @level2type=N'COLUMN',@level2name=N'BankName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'联行号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Bank', @level2type=N'COLUMN',@level2name=N'SeqNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Bank', @level2type=N'COLUMN',@level2name=N'Status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否删除' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Bank', @level2type=N'COLUMN',@level2name=N'Isdelete'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'银行表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Bank'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商户id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Merchant', @level2type=N'COLUMN',@level2name=N'MerchantId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商户号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Merchant', @level2type=N'COLUMN',@level2name=N'MerchantNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商户名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Merchant', @level2type=N'COLUMN',@level2name=N'MerchantName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'代理ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Merchant', @level2type=N'COLUMN',@level2name=N'AgentId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'代理编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Merchant', @level2type=N'COLUMN',@level2name=N'AgentNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'电话' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Merchant', @level2type=N'COLUMN',@level2name=N'Mobile'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'QQ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Merchant', @level2type=N'COLUMN',@level2name=N'QQ'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'邮箱' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Merchant', @level2type=N'COLUMN',@level2name=N'Email'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商户站点' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Merchant', @level2type=N'COLUMN',@level2name=N'Website'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商户秘钥' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Merchant', @level2type=N'COLUMN',@level2name=N'Md5Key'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'提现密码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Merchant', @level2type=N'COLUMN',@level2name=N'WithdrawPwd'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'后台IP白名单' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Merchant', @level2type=N'COLUMN',@level2name=N'BackWhiteIp'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Api IP白名单' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Merchant', @level2type=N'COLUMN',@level2name=N'ApiWhiteIp'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商户状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Merchant', @level2type=N'COLUMN',@level2name=N'Status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Merchant', @level2type=N'COLUMN',@level2name=N'Remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Merchant', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Merchant', @level2type=N'COLUMN',@level2name=N'CreateBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'更新时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Merchant', @level2type=N'COLUMN',@level2name=N'UpdateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'更新人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Merchant', @level2type=N'COLUMN',@level2name=N'UpdateBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否删除' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Merchant', @level2type=N'COLUMN',@level2name=N'Isdelete'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商户表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Merchant'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'账户id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MerchantBankAccount', @level2type=N'COLUMN',@level2name=N'AccountId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'账户名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MerchantBankAccount', @level2type=N'COLUMN',@level2name=N'AccountName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'账号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MerchantBankAccount', @level2type=N'COLUMN',@level2name=N'AccountNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'银行' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MerchantBankAccount', @level2type=N'COLUMN',@level2name=N'BankName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'银行编码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MerchantBankAccount', @level2type=N'COLUMN',@level2name=N'BankCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'支行' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MerchantBankAccount', @level2type=N'COLUMN',@level2name=N'BankBranchName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'省份' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MerchantBankAccount', @level2type=N'COLUMN',@level2name=N'Province'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'城市' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MerchantBankAccount', @level2type=N'COLUMN',@level2name=N'City'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'手机号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MerchantBankAccount', @level2type=N'COLUMN',@level2name=N'Mobile'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'身份证号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MerchantBankAccount', @level2type=N'COLUMN',@level2name=N'IdCardNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MerchantBankAccount', @level2type=N'COLUMN',@level2name=N'Status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MerchantBankAccount', @level2type=N'COLUMN',@level2name=N'Remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MerchantBankAccount', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MerchantBankAccount', @level2type=N'COLUMN',@level2name=N'CreateBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'更新时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MerchantBankAccount', @level2type=N'COLUMN',@level2name=N'UpdateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'更新人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MerchantBankAccount', @level2type=N'COLUMN',@level2name=N'UpdateBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否删除' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MerchantBankAccount', @level2type=N'COLUMN',@level2name=N'Isdelete'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商户银行卡表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MerchantBankAccount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主键ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MerchantPayService', @level2type=N'COLUMN',@level2name=N'MerchantPayServiceId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商户ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MerchantPayService', @level2type=N'COLUMN',@level2name=N'MerchantId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'产品ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MerchantPayService', @level2type=N'COLUMN',@level2name=N'ServiceId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商户手续费率' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MerchantPayService', @level2type=N'COLUMN',@level2name=N'MerchantFeeRate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'代理手续费率' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MerchantPayService', @level2type=N'COLUMN',@level2name=N'AgentFeeRate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商户状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MerchantPayService', @level2type=N'COLUMN',@level2name=N'Status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MerchantPayService', @level2type=N'COLUMN',@level2name=N'Remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MerchantPayService', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MerchantPayService', @level2type=N'COLUMN',@level2name=N'CreateBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'更新时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MerchantPayService', @level2type=N'COLUMN',@level2name=N'UpdateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'更新人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MerchantPayService', @level2type=N'COLUMN',@level2name=N'UpdateBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否删除' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MerchantPayService', @level2type=N'COLUMN',@level2name=N'Isdelete'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商户开通支付产品表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MerchantPayService'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'请求ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NotifyRecord', @level2type=N'COLUMN',@level2name=N'RequestId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'订单ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NotifyRecord', @level2type=N'COLUMN',@level2name=N'OrderId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'订单类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NotifyRecord', @level2type=N'COLUMN',@level2name=N'OrderType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'回调地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NotifyRecord', @level2type=N'COLUMN',@level2name=N'NotifyUrl'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'回调内容' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NotifyRecord', @level2type=N'COLUMN',@level2name=N'NotifyData'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NotifyRecord', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'返回响应信息' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NotifyRecord', @level2type=N'COLUMN',@level2name=N'ResponseMsg'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'回调时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NotifyRecord', @level2type=N'COLUMN',@level2name=N'NotifyTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'回调状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NotifyRecord', @level2type=N'COLUMN',@level2name=N'Status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注信息' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NotifyRecord', @level2type=N'COLUMN',@level2name=N'Remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'回调通知记录表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NotifyRecord'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'日志ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OptLog', @level2type=N'COLUMN',@level2name=N'LogId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'操作人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OptLog', @level2type=N'COLUMN',@level2name=N'OptName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'日志类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OptLog', @level2type=N'COLUMN',@level2name=N'LogType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ip地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OptLog', @level2type=N'COLUMN',@level2name=N'Ip'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'操作对象ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OptLog', @level2type=N'COLUMN',@level2name=N'OptObjectId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'日志内容' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OptLog', @level2type=N'COLUMN',@level2name=N'LogContent'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'日志时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OptLog', @level2type=N'COLUMN',@level2name=N'LogTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'操作日志表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OptLog'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'支付渠道ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PayChannel', @level2type=N'COLUMN',@level2name=N'ChannelId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'支付渠道类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PayChannel', @level2type=N'COLUMN',@level2name=N'ChannelType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'渠道名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PayChannel', @level2type=N'COLUMN',@level2name=N'ChannelName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商户号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PayChannel', @level2type=N'COLUMN',@level2name=N'MerchantNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商户秘钥' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PayChannel', @level2type=N'COLUMN',@level2name=N'MerchantKey'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商户信息' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PayChannel', @level2type=N'COLUMN',@level2name=N'MerchantInfo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'支付站点' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PayChannel', @level2type=N'COLUMN',@level2name=N'PaySite'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最小支付金额' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PayChannel', @level2type=N'COLUMN',@level2name=N'MinOrderAmount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最大支付金额' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PayChannel', @level2type=N'COLUMN',@level2name=N'MaxOrderAmount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'结算模式' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PayChannel', @level2type=N'COLUMN',@level2name=N'SettleMode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'手续费率' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PayChannel', @level2type=N'COLUMN',@level2name=N'FeeRate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PayChannel', @level2type=N'COLUMN',@level2name=N'Status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PayChannel', @level2type=N'COLUMN',@level2name=N'Remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PayChannel', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PayChannel', @level2type=N'COLUMN',@level2name=N'CreateBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'更新时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PayChannel', @level2type=N'COLUMN',@level2name=N'UpdateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'更新人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PayChannel', @level2type=N'COLUMN',@level2name=N'UpdateBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否删除' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PayChannel', @level2type=N'COLUMN',@level2name=N'Isdelete'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'支付渠道表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PayChannel'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'系统订单ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PayOrder', @level2type=N'COLUMN',@level2name=N'OrderId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'系统订单号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PayOrder', @level2type=N'COLUMN',@level2name=N'OrderNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'代理编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PayOrder', @level2type=N'COLUMN',@level2name=N'AgentNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商户ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PayOrder', @level2type=N'COLUMN',@level2name=N'MerchantId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商户订单号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PayOrder', @level2type=N'COLUMN',@level2name=N'MerchantOrderNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商户订单时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PayOrder', @level2type=N'COLUMN',@level2name=N'MerchantOrderTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'会员信息' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PayOrder', @level2type=N'COLUMN',@level2name=N'MemberInfo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'IP地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PayOrder', @level2type=N'COLUMN',@level2name=N'Ip'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'设备类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PayOrder', @level2type=N'COLUMN',@level2name=N'DeviceType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'银行信息' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PayOrder', @level2type=N'COLUMN',@level2name=N'BankInfo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'银行编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PayOrder', @level2type=N'COLUMN',@level2name=N'BankCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'回调地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PayOrder', @level2type=N'COLUMN',@level2name=N'NotifyUrl'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'返回地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PayOrder', @level2type=N'COLUMN',@level2name=N'ReturnUrl'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'预付金额' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PayOrder', @level2type=N'COLUMN',@level2name=N'PreorderAmount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'订单金额' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PayOrder', @level2type=N'COLUMN',@level2name=N'OrderAmount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'订单描述' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PayOrder', @level2type=N'COLUMN',@level2name=N'OrderDescription'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'扩展字段' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PayOrder', @level2type=N'COLUMN',@level2name=N'ExtendField'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'服务产品ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PayOrder', @level2type=N'COLUMN',@level2name=N'ServiceId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'渠道类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PayOrder', @level2type=N'COLUMN',@level2name=N'ChannelType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'渠道ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PayOrder', @level2type=N'COLUMN',@level2name=N'ChannelId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'渠道名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PayOrder', @level2type=N'COLUMN',@level2name=N'ChannelName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'结算模式' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PayOrder', @level2type=N'COLUMN',@level2name=N'SettleMode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'结算时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PayOrder', @level2type=N'COLUMN',@level2name=N'SettleDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'费率模式' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PayOrder', @level2type=N'COLUMN',@level2name=N'FeeMode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'转账费率' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PayOrder', @level2type=N'COLUMN',@level2name=N'TransRate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'服务费率' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PayOrder', @level2type=N'COLUMN',@level2name=N'ServiceRate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'costRate' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PayOrder', @level2type=N'COLUMN',@level2name=N'costRate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'转账手续费' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PayOrder', @level2type=N'COLUMN',@level2name=N'TransFee'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'产品服务手续费' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PayOrder', @level2type=N'COLUMN',@level2name=N'ServiceFee'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'costFee' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PayOrder', @level2type=N'COLUMN',@level2name=N'costFee'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'实际所得金额(订单金额-手续费)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PayOrder', @level2type=N'COLUMN',@level2name=N'TransAmount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'支付状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PayOrder', @level2type=N'COLUMN',@level2name=N'PayStatus'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'支付时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PayOrder', @level2type=N'COLUMN',@level2name=N'PayTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'回调状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PayOrder', @level2type=N'COLUMN',@level2name=N'NotifyStatus'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'settleToMerchant' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PayOrder', @level2type=N'COLUMN',@level2name=N'settleToMerchant'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'settleToCustomer' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PayOrder', @level2type=N'COLUMN',@level2name=N'settleToCustomer'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'交易记录ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PayOrder', @level2type=N'COLUMN',@level2name=N'TransactionId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PayOrder', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'回调次数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PayOrder', @level2type=N'COLUMN',@level2name=N'NotifyCount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'回调信息' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PayOrder', @level2type=N'COLUMN',@level2name=N'NotifyMsg'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'查询次数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PayOrder', @level2type=N'COLUMN',@level2name=N'QueryCount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'回调时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PayOrder', @level2type=N'COLUMN',@level2name=N'NotifyTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'支付订单表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PayOrder'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'产品ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PayService', @level2type=N'COLUMN',@level2name=N'ServiceId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'产品类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PayService', @level2type=N'COLUMN',@level2name=N'ServiceType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'产品代码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PayService', @level2type=N'COLUMN',@level2name=N'ServiceCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'产品名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PayService', @level2type=N'COLUMN',@level2name=N'ServiceName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商户状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PayService', @level2type=N'COLUMN',@level2name=N'Status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PayService', @level2type=N'COLUMN',@level2name=N'Remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PayService', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PayService', @level2type=N'COLUMN',@level2name=N'CreateBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'更新时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PayService', @level2type=N'COLUMN',@level2name=N'UpdateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'更新人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PayService', @level2type=N'COLUMN',@level2name=N'UpdateBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否删除' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PayService', @level2type=N'COLUMN',@level2name=N'Isdelete'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'支付产品表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PayService'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'结算订单ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Settlement', @level2type=N'COLUMN',@level2name=N'OrderId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'结算订单号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Settlement', @level2type=N'COLUMN',@level2name=N'OrderNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'账户ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Settlement', @level2type=N'COLUMN',@level2name=N'AccountId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商户号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Settlement', @level2type=N'COLUMN',@level2name=N'MerchantNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商户订单号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Settlement', @level2type=N'COLUMN',@level2name=N'MerchantOrderNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'结算订单金额' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Settlement', @level2type=N'COLUMN',@level2name=N'OrderAmount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'转账手续费' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Settlement', @level2type=N'COLUMN',@level2name=N'TransFee'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'实际转账金额' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Settlement', @level2type=N'COLUMN',@level2name=N'TransAmount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'账户名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Settlement', @level2type=N'COLUMN',@level2name=N'AccountName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'账号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Settlement', @level2type=N'COLUMN',@level2name=N'AccountNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'银行' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Settlement', @level2type=N'COLUMN',@level2name=N'BankName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'银行编码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Settlement', @level2type=N'COLUMN',@level2name=N'BankCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'支行' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Settlement', @level2type=N'COLUMN',@level2name=N'BankBranchName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'省份' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Settlement', @level2type=N'COLUMN',@level2name=N'Province'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'城市' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Settlement', @level2type=N'COLUMN',@level2name=N'City'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'手机号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Settlement', @level2type=N'COLUMN',@level2name=N'Mobile'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'扩展字段' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Settlement', @level2type=N'COLUMN',@level2name=N'ExtendField'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'结算状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Settlement', @level2type=N'COLUMN',@level2name=N'Status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'查询次数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Settlement', @level2type=N'COLUMN',@level2name=N'QueryCount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'回调状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Settlement', @level2type=N'COLUMN',@level2name=N'CallbackStatus'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'回调次数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Settlement', @level2type=N'COLUMN',@level2name=N'CallbackCount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'回调时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Settlement', @level2type=N'COLUMN',@level2name=N'CallbackTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'回调信息' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Settlement', @level2type=N'COLUMN',@level2name=N'CallbackMsg'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Settlement', @level2type=N'COLUMN',@level2name=N'CreateBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Settlement', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'审核状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Settlement', @level2type=N'COLUMN',@level2name=N'AuditStatus'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'审核时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Settlement', @level2type=N'COLUMN',@level2name=N'AuditTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'审核人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Settlement', @level2type=N'COLUMN',@level2name=N'AuditBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Settlement', @level2type=N'COLUMN',@level2name=N'Remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'结算' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Settlement'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'交易记录ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Transaction', @level2type=N'COLUMN',@level2name=N'TransactionId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'交易记录类型(支付=1，结算=2)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Transaction', @level2type=N'COLUMN',@level2name=N'TransType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'交易金额' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Transaction', @level2type=N'COLUMN',@level2name=N'TransAmount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'订单金额' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Transaction', @level2type=N'COLUMN',@level2name=N'OrderAmount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'转账手续费' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Transaction', @level2type=N'COLUMN',@level2name=N'TransFee'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'产品手续费' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Transaction', @level2type=N'COLUMN',@level2name=N'ServiceFee'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'costFee' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Transaction', @level2type=N'COLUMN',@level2name=N'costFee'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Transaction', @level2type=N'COLUMN',@level2name=N'Remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'optName' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Transaction', @level2type=N'COLUMN',@level2name=N'optName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Transaction', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'交易记录表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Transaction'
GO
