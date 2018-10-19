use Max_Pay
go
if exists (select 1
            from  sysobjects
           where  id = object_id('Agent')
            and   type = 'U')
   drop table Agent
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Bank')
            and   type = 'U')
   drop table Bank
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Merchant')
            and   type = 'U')
   drop table Merchant
go

if exists (select 1
            from  sysobjects
           where  id = object_id('MerchantBankAccount')
            and   type = 'U')
   drop table MerchantBankAccount
go

if exists (select 1
            from  sysobjects
           where  id = object_id('MerchantPayService')
            and   type = 'U')
   drop table MerchantPayService
go

if exists (select 1
            from  sysobjects
           where  id = object_id('NotifyRecord')
            and   type = 'U')
   drop table NotifyRecord
go

if exists (select 1
            from  sysobjects
           where  id = object_id('OptLog')
            and   type = 'U')
   drop table OptLog
go

if exists (select 1
            from  sysobjects
           where  id = object_id('PayChannel')
            and   type = 'U')
   drop table PayChannel
go

if exists (select 1
            from  sysobjects
           where  id = object_id('PayOrder')
            and   type = 'U')
   drop table PayOrder
go

if exists (select 1
            from  sysobjects
           where  id = object_id('PayService')
            and   type = 'U')
   drop table PayService
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Settlement')
            and   type = 'U')
   drop table Settlement
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('"Transaction"')
            and   name  = 'idx_transaction_awtm'
            and   indid > 0
            and   indid < 255)
   drop index "Transaction".idx_transaction_awtm
go

if exists (select 1
            from  sysobjects
           where  id = object_id('"Transaction"')
            and   type = 'U')
   drop table "Transaction"
go

/*==============================================================*/
/* Table: Agent                                                 */
/*==============================================================*/
create table Agent (
   AgentId              varchar(50)          not null,
   AgentNo              varchar(50)          not null,
   AgentName            nvarchar(100)        not null,
   Mobile               varchar(50)          null,
   QQ                   varchar(50)          null,
   Email                varchar(50)          null,
   Status               int                  not null,
   Remark               varchar(500)         null,
   CreateTime           datetime             not null,
   CreateBy             varchar(50)          not null,
   UpdateTime           datetime             null,
   UpdateBy             varchar(50)          null,
   Isdelete             int                  not null,
   constraint PK_AGENT primary key (AgentId)
)
on "PRIMARY"
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('Agent') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'Agent' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '�����', 
   'user', @CurrentUser, 'table', 'Agent'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Agent')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'AgentId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Agent', 'column', 'AgentId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����ID',
   'user', @CurrentUser, 'table', 'Agent', 'column', 'AgentId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Agent')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'AgentNo')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Agent', 'column', 'AgentNo'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '������',
   'user', @CurrentUser, 'table', 'Agent', 'column', 'AgentNo'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Agent')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'AgentName')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Agent', 'column', 'AgentName'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��������',
   'user', @CurrentUser, 'table', 'Agent', 'column', 'AgentName'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Agent')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Mobile')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Agent', 'column', 'Mobile'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�绰',
   'user', @CurrentUser, 'table', 'Agent', 'column', 'Mobile'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Agent')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'QQ')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Agent', 'column', 'QQ'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'QQ',
   'user', @CurrentUser, 'table', 'Agent', 'column', 'QQ'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Agent')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Email')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Agent', 'column', 'Email'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����',
   'user', @CurrentUser, 'table', 'Agent', 'column', 'Email'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Agent')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Status')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Agent', 'column', 'Status'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '״̬',
   'user', @CurrentUser, 'table', 'Agent', 'column', 'Status'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Agent')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Remark')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Agent', 'column', 'Remark'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��ע',
   'user', @CurrentUser, 'table', 'Agent', 'column', 'Remark'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Agent')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CreateTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Agent', 'column', 'CreateTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����ʱ��',
   'user', @CurrentUser, 'table', 'Agent', 'column', 'CreateTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Agent')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CreateBy')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Agent', 'column', 'CreateBy'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '������',
   'user', @CurrentUser, 'table', 'Agent', 'column', 'CreateBy'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Agent')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UpdateTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Agent', 'column', 'UpdateTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����ʱ��',
   'user', @CurrentUser, 'table', 'Agent', 'column', 'UpdateTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Agent')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UpdateBy')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Agent', 'column', 'UpdateBy'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '������',
   'user', @CurrentUser, 'table', 'Agent', 'column', 'UpdateBy'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Agent')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Isdelete')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Agent', 'column', 'Isdelete'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�Ƿ�ɾ��',
   'user', @CurrentUser, 'table', 'Agent', 'column', 'Isdelete'
go

/*==============================================================*/
/* Table: Bank                                                  */
/*==============================================================*/
create table Bank (
   BankId               varchar(50)          not null,
   BankCode             varchar(50)          not null,
   BankName             varchar(50)          not null,
   SeqNo                varchar(50)          null,
   Status               int                  not null,
   Isdelete             int                  not null,
   constraint PK_BANK primary key (BankId)
)
on "PRIMARY"
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('Bank') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'Bank' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '���б�', 
   'user', @CurrentUser, 'table', 'Bank'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Bank')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'BankId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Bank', 'column', 'BankId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����ID',
   'user', @CurrentUser, 'table', 'Bank', 'column', 'BankId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Bank')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'BankCode')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Bank', 'column', 'BankCode'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '���д���',
   'user', @CurrentUser, 'table', 'Bank', 'column', 'BankCode'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Bank')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'BankName')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Bank', 'column', 'BankName'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��������',
   'user', @CurrentUser, 'table', 'Bank', 'column', 'BankName'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Bank')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'SeqNo')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Bank', 'column', 'SeqNo'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '���к�',
   'user', @CurrentUser, 'table', 'Bank', 'column', 'SeqNo'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Bank')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Status')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Bank', 'column', 'Status'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '״̬',
   'user', @CurrentUser, 'table', 'Bank', 'column', 'Status'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Bank')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Isdelete')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Bank', 'column', 'Isdelete'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�Ƿ�ɾ��',
   'user', @CurrentUser, 'table', 'Bank', 'column', 'Isdelete'
go

/*==============================================================*/
/* Table: Merchant                                              */
/*==============================================================*/
create table Merchant (
   MerchantId           varchar(50)          not null,
   MerchantNo           varchar(50)          not null,
   MerchantName         nvarchar(100)        not null,
   AgentId              varchar(50)          null,
   AgentNo              varchar(50)          null,
   Mobile               varchar(50)          null,
   QQ                   varchar(50)          null,
   Email                varchar(50)          null,
   Website              varchar(500)         null,
   Md5Key               varchar(500)         null,
   WithdrawPwd          varchar(50)          null,
   BackWhiteIp          varchar(500)         null,
   ApiWhiteIp           varchar(500)         null,
   Status               int                  not null,
   Remark               varchar(500)         null,
   CreateTime           datetime             not null,
   CreateBy             varchar(50)          not null,
   UpdateTime           datetime             null,
   UpdateBy             varchar(50)          null,
   Isdelete             int                  not null,
   constraint PK_MERCHANT primary key (MerchantId)
)
on "PRIMARY"
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('Merchant') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'Merchant' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '�̻���', 
   'user', @CurrentUser, 'table', 'Merchant'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Merchant')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'MerchantId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Merchant', 'column', 'MerchantId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�̻�id',
   'user', @CurrentUser, 'table', 'Merchant', 'column', 'MerchantId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Merchant')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'MerchantNo')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Merchant', 'column', 'MerchantNo'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�̻���',
   'user', @CurrentUser, 'table', 'Merchant', 'column', 'MerchantNo'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Merchant')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'MerchantName')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Merchant', 'column', 'MerchantName'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�̻�����',
   'user', @CurrentUser, 'table', 'Merchant', 'column', 'MerchantName'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Merchant')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'AgentId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Merchant', 'column', 'AgentId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����ID',
   'user', @CurrentUser, 'table', 'Merchant', 'column', 'AgentId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Merchant')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'AgentNo')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Merchant', 'column', 'AgentNo'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '������',
   'user', @CurrentUser, 'table', 'Merchant', 'column', 'AgentNo'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Merchant')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Mobile')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Merchant', 'column', 'Mobile'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�绰',
   'user', @CurrentUser, 'table', 'Merchant', 'column', 'Mobile'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Merchant')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'QQ')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Merchant', 'column', 'QQ'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'QQ',
   'user', @CurrentUser, 'table', 'Merchant', 'column', 'QQ'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Merchant')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Email')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Merchant', 'column', 'Email'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����',
   'user', @CurrentUser, 'table', 'Merchant', 'column', 'Email'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Merchant')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Website')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Merchant', 'column', 'Website'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�̻�վ��',
   'user', @CurrentUser, 'table', 'Merchant', 'column', 'Website'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Merchant')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Md5Key')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Merchant', 'column', 'Md5Key'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�̻���Կ',
   'user', @CurrentUser, 'table', 'Merchant', 'column', 'Md5Key'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Merchant')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'WithdrawPwd')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Merchant', 'column', 'WithdrawPwd'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��������',
   'user', @CurrentUser, 'table', 'Merchant', 'column', 'WithdrawPwd'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Merchant')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'BackWhiteIp')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Merchant', 'column', 'BackWhiteIp'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��̨IP������',
   'user', @CurrentUser, 'table', 'Merchant', 'column', 'BackWhiteIp'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Merchant')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ApiWhiteIp')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Merchant', 'column', 'ApiWhiteIp'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Api IP������',
   'user', @CurrentUser, 'table', 'Merchant', 'column', 'ApiWhiteIp'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Merchant')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Status')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Merchant', 'column', 'Status'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�̻�״̬',
   'user', @CurrentUser, 'table', 'Merchant', 'column', 'Status'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Merchant')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Remark')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Merchant', 'column', 'Remark'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��ע',
   'user', @CurrentUser, 'table', 'Merchant', 'column', 'Remark'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Merchant')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CreateTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Merchant', 'column', 'CreateTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����ʱ��',
   'user', @CurrentUser, 'table', 'Merchant', 'column', 'CreateTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Merchant')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CreateBy')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Merchant', 'column', 'CreateBy'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '������',
   'user', @CurrentUser, 'table', 'Merchant', 'column', 'CreateBy'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Merchant')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UpdateTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Merchant', 'column', 'UpdateTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����ʱ��',
   'user', @CurrentUser, 'table', 'Merchant', 'column', 'UpdateTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Merchant')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UpdateBy')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Merchant', 'column', 'UpdateBy'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '������',
   'user', @CurrentUser, 'table', 'Merchant', 'column', 'UpdateBy'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Merchant')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Isdelete')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Merchant', 'column', 'Isdelete'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�Ƿ�ɾ��',
   'user', @CurrentUser, 'table', 'Merchant', 'column', 'Isdelete'
go

/*==============================================================*/
/* Table: MerchantBankAccount                                   */
/*==============================================================*/
create table MerchantBankAccount (
   AccountId            varchar(50)          not null,
   AccountName          varchar(50)          not null,
   AccountNumber        varchar(50)          not null,
   BankName             varchar(50)          not null,
   BankCode             varchar(50)          not null,
   BankBranchName       varchar(100)         null,
   Province             varchar(50)          null,
   City                 varchar(50)          null,
   Mobile               varchar(50)          null,
   IdCardNo             varchar(50)          null,
   Status               int                  not null,
   Remark               varchar(500)         null,
   CreateTime           datetime             not null,
   CreateBy             varchar(50)          not null,
   UpdateTime           datetime             null,
   UpdateBy             varchar(50)          null,
   Isdelete             int                  not null,
   constraint PK_MERCHANTBANKACCOUNT primary key (AccountId)
)
on "PRIMARY"
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('MerchantBankAccount') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'MerchantBankAccount' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '�̻����п���', 
   'user', @CurrentUser, 'table', 'MerchantBankAccount'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('MerchantBankAccount')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'AccountId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'MerchantBankAccount', 'column', 'AccountId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�˻�id',
   'user', @CurrentUser, 'table', 'MerchantBankAccount', 'column', 'AccountId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('MerchantBankAccount')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'AccountName')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'MerchantBankAccount', 'column', 'AccountName'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�˻�����',
   'user', @CurrentUser, 'table', 'MerchantBankAccount', 'column', 'AccountName'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('MerchantBankAccount')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'AccountNumber')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'MerchantBankAccount', 'column', 'AccountNumber'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�˺�',
   'user', @CurrentUser, 'table', 'MerchantBankAccount', 'column', 'AccountNumber'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('MerchantBankAccount')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'BankName')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'MerchantBankAccount', 'column', 'BankName'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����',
   'user', @CurrentUser, 'table', 'MerchantBankAccount', 'column', 'BankName'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('MerchantBankAccount')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'BankCode')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'MerchantBankAccount', 'column', 'BankCode'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '���б���',
   'user', @CurrentUser, 'table', 'MerchantBankAccount', 'column', 'BankCode'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('MerchantBankAccount')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'BankBranchName')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'MerchantBankAccount', 'column', 'BankBranchName'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '֧��',
   'user', @CurrentUser, 'table', 'MerchantBankAccount', 'column', 'BankBranchName'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('MerchantBankAccount')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Province')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'MerchantBankAccount', 'column', 'Province'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ʡ��',
   'user', @CurrentUser, 'table', 'MerchantBankAccount', 'column', 'Province'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('MerchantBankAccount')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'City')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'MerchantBankAccount', 'column', 'City'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����',
   'user', @CurrentUser, 'table', 'MerchantBankAccount', 'column', 'City'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('MerchantBankAccount')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Mobile')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'MerchantBankAccount', 'column', 'Mobile'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�ֻ���',
   'user', @CurrentUser, 'table', 'MerchantBankAccount', 'column', 'Mobile'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('MerchantBankAccount')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IdCardNo')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'MerchantBankAccount', 'column', 'IdCardNo'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '���֤��',
   'user', @CurrentUser, 'table', 'MerchantBankAccount', 'column', 'IdCardNo'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('MerchantBankAccount')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Status')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'MerchantBankAccount', 'column', 'Status'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '״̬',
   'user', @CurrentUser, 'table', 'MerchantBankAccount', 'column', 'Status'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('MerchantBankAccount')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Remark')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'MerchantBankAccount', 'column', 'Remark'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��ע',
   'user', @CurrentUser, 'table', 'MerchantBankAccount', 'column', 'Remark'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('MerchantBankAccount')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CreateTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'MerchantBankAccount', 'column', 'CreateTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����ʱ��',
   'user', @CurrentUser, 'table', 'MerchantBankAccount', 'column', 'CreateTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('MerchantBankAccount')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CreateBy')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'MerchantBankAccount', 'column', 'CreateBy'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '������',
   'user', @CurrentUser, 'table', 'MerchantBankAccount', 'column', 'CreateBy'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('MerchantBankAccount')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UpdateTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'MerchantBankAccount', 'column', 'UpdateTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����ʱ��',
   'user', @CurrentUser, 'table', 'MerchantBankAccount', 'column', 'UpdateTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('MerchantBankAccount')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UpdateBy')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'MerchantBankAccount', 'column', 'UpdateBy'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '������',
   'user', @CurrentUser, 'table', 'MerchantBankAccount', 'column', 'UpdateBy'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('MerchantBankAccount')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Isdelete')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'MerchantBankAccount', 'column', 'Isdelete'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�Ƿ�ɾ��',
   'user', @CurrentUser, 'table', 'MerchantBankAccount', 'column', 'Isdelete'
go

/*==============================================================*/
/* Table: MerchantPayService                                    */
/*==============================================================*/
create table MerchantPayService (
   MerchantPayServiceId varchar(50)          not null,
   MerchantId           varchar(50)          not null,
   ServiceId            varchar(50)          not null,
   MerchantFeeRate      decimal(18,4)        not null,
   AgentFeeRate         decimal(18,4)        not null,
   Status               int                  not null,
   Remark               varchar(500)         null,
   CreateTime           datetime             not null,
   CreateBy             varchar(50)          not null,
   UpdateTime           datetime             null,
   UpdateBy             varchar(50)          null,
   Isdelete             int                  not null,
   constraint PK_MERCHANTPAYSERVICE primary key (MerchantPayServiceId)
)
on "PRIMARY"
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('MerchantPayService') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'MerchantPayService' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '�̻���֧ͨ����Ʒ��', 
   'user', @CurrentUser, 'table', 'MerchantPayService'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('MerchantPayService')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'MerchantPayServiceId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'MerchantPayService', 'column', 'MerchantPayServiceId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����ID',
   'user', @CurrentUser, 'table', 'MerchantPayService', 'column', 'MerchantPayServiceId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('MerchantPayService')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'MerchantId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'MerchantPayService', 'column', 'MerchantId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�̻�ID',
   'user', @CurrentUser, 'table', 'MerchantPayService', 'column', 'MerchantId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('MerchantPayService')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ServiceId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'MerchantPayService', 'column', 'ServiceId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��ƷID',
   'user', @CurrentUser, 'table', 'MerchantPayService', 'column', 'ServiceId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('MerchantPayService')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'MerchantFeeRate')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'MerchantPayService', 'column', 'MerchantFeeRate'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�̻���������',
   'user', @CurrentUser, 'table', 'MerchantPayService', 'column', 'MerchantFeeRate'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('MerchantPayService')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'AgentFeeRate')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'MerchantPayService', 'column', 'AgentFeeRate'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '������������',
   'user', @CurrentUser, 'table', 'MerchantPayService', 'column', 'AgentFeeRate'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('MerchantPayService')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Status')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'MerchantPayService', 'column', 'Status'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�̻�״̬',
   'user', @CurrentUser, 'table', 'MerchantPayService', 'column', 'Status'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('MerchantPayService')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Remark')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'MerchantPayService', 'column', 'Remark'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��ע',
   'user', @CurrentUser, 'table', 'MerchantPayService', 'column', 'Remark'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('MerchantPayService')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CreateTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'MerchantPayService', 'column', 'CreateTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����ʱ��',
   'user', @CurrentUser, 'table', 'MerchantPayService', 'column', 'CreateTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('MerchantPayService')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CreateBy')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'MerchantPayService', 'column', 'CreateBy'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '������',
   'user', @CurrentUser, 'table', 'MerchantPayService', 'column', 'CreateBy'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('MerchantPayService')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UpdateTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'MerchantPayService', 'column', 'UpdateTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����ʱ��',
   'user', @CurrentUser, 'table', 'MerchantPayService', 'column', 'UpdateTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('MerchantPayService')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UpdateBy')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'MerchantPayService', 'column', 'UpdateBy'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '������',
   'user', @CurrentUser, 'table', 'MerchantPayService', 'column', 'UpdateBy'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('MerchantPayService')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Isdelete')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'MerchantPayService', 'column', 'Isdelete'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�Ƿ�ɾ��',
   'user', @CurrentUser, 'table', 'MerchantPayService', 'column', 'Isdelete'
go

/*==============================================================*/
/* Table: NotifyRecord                                          */
/*==============================================================*/
create table NotifyRecord (
   RequestId            varchar(50)          not null,
   OrderId              varchar(50)          not null,
   OrderType            varchar(50)          not null,
   NotifyUrl            varchar(500)         not null,
   NotifyData           varchar(500)         not null,
   CreateTime           datetime             not null,
   ResponseMsg          varchar(500)         not null,
   NotifyTime           datetime             not null,
   Status               int                  not null,
   Remark               nvarchar(1000)       null,
   constraint PK_NOTIFYRECORD primary key (RequestId)
)
on "PRIMARY"
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('NotifyRecord') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'NotifyRecord' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '�ص�֪ͨ��¼��', 
   'user', @CurrentUser, 'table', 'NotifyRecord'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('NotifyRecord')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'RequestId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'NotifyRecord', 'column', 'RequestId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����ID',
   'user', @CurrentUser, 'table', 'NotifyRecord', 'column', 'RequestId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('NotifyRecord')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'OrderId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'NotifyRecord', 'column', 'OrderId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����ID',
   'user', @CurrentUser, 'table', 'NotifyRecord', 'column', 'OrderId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('NotifyRecord')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'OrderType')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'NotifyRecord', 'column', 'OrderType'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��������',
   'user', @CurrentUser, 'table', 'NotifyRecord', 'column', 'OrderType'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('NotifyRecord')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'NotifyUrl')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'NotifyRecord', 'column', 'NotifyUrl'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�ص���ַ',
   'user', @CurrentUser, 'table', 'NotifyRecord', 'column', 'NotifyUrl'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('NotifyRecord')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'NotifyData')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'NotifyRecord', 'column', 'NotifyData'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�ص�����',
   'user', @CurrentUser, 'table', 'NotifyRecord', 'column', 'NotifyData'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('NotifyRecord')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CreateTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'NotifyRecord', 'column', 'CreateTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����ʱ��',
   'user', @CurrentUser, 'table', 'NotifyRecord', 'column', 'CreateTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('NotifyRecord')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ResponseMsg')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'NotifyRecord', 'column', 'ResponseMsg'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '������Ӧ��Ϣ',
   'user', @CurrentUser, 'table', 'NotifyRecord', 'column', 'ResponseMsg'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('NotifyRecord')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'NotifyTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'NotifyRecord', 'column', 'NotifyTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�ص�ʱ��',
   'user', @CurrentUser, 'table', 'NotifyRecord', 'column', 'NotifyTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('NotifyRecord')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Status')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'NotifyRecord', 'column', 'Status'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�ص�״̬',
   'user', @CurrentUser, 'table', 'NotifyRecord', 'column', 'Status'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('NotifyRecord')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Remark')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'NotifyRecord', 'column', 'Remark'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��ע��Ϣ',
   'user', @CurrentUser, 'table', 'NotifyRecord', 'column', 'Remark'
go

/*==============================================================*/
/* Table: OptLog                                                */
/*==============================================================*/
create table OptLog (
   LogId                varchar(50)          not null,
   OptName              nvarchar(100)        not null,
   LogType              nvarchar(50)         not null,
   Ip                   varchar(50)          null,
   OptObjectId          varchar(50)          null,
   LogContent           nvarchar(1000)       not null,
   LogTime              datetime             not null,
   constraint PK_OPTLOG primary key (LogId)
)
on "PRIMARY"
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('OptLog') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'OptLog' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '������־��', 
   'user', @CurrentUser, 'table', 'OptLog'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('OptLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'LogId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'OptLog', 'column', 'LogId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��־ID',
   'user', @CurrentUser, 'table', 'OptLog', 'column', 'LogId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('OptLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'OptName')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'OptLog', 'column', 'OptName'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '������',
   'user', @CurrentUser, 'table', 'OptLog', 'column', 'OptName'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('OptLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'LogType')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'OptLog', 'column', 'LogType'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��־����',
   'user', @CurrentUser, 'table', 'OptLog', 'column', 'LogType'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('OptLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Ip')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'OptLog', 'column', 'Ip'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Ip��ַ',
   'user', @CurrentUser, 'table', 'OptLog', 'column', 'Ip'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('OptLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'OptObjectId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'OptLog', 'column', 'OptObjectId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��������ID',
   'user', @CurrentUser, 'table', 'OptLog', 'column', 'OptObjectId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('OptLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'LogContent')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'OptLog', 'column', 'LogContent'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��־����',
   'user', @CurrentUser, 'table', 'OptLog', 'column', 'LogContent'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('OptLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'LogTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'OptLog', 'column', 'LogTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��־ʱ��',
   'user', @CurrentUser, 'table', 'OptLog', 'column', 'LogTime'
go

/*==============================================================*/
/* Table: PayChannel                                            */
/*==============================================================*/
create table PayChannel (
   ChannelId            int                  not null,
   ChannelType          varchar(50)          not null,
   ChannelName          varchar(100)         not null,
   MerchantNo           varchar(50)          not null,
   MerchantKey          varchar(500)         null,
   MerchantInfo         varchar(100)         null,
   PaySite              varchar(500)         not null,
   MinOrderAmount       decimal(19,4)        not null,
   MaxOrderAmount       decimal(19,4)        not null,
   SettleMode           int                  not null,
   FeeRate              decimal(19,4)        not null,
   Status               int                  not null,
   Remark               varchar(500)         null,
   CreateTime           datetime             not null,
   CreateBy             varchar(50)          not null,
   UpdateTime           datetime             null,
   UpdateBy             varchar(50)          null,
   Isdelete             int                  not null,
   constraint PK_PAYCHANNEL primary key (ChannelId)
)
on "PRIMARY"
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('PayChannel') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'PayChannel' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '֧��������', 
   'user', @CurrentUser, 'table', 'PayChannel'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('PayChannel')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ChannelId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'PayChannel', 'column', 'ChannelId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '֧������ID',
   'user', @CurrentUser, 'table', 'PayChannel', 'column', 'ChannelId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('PayChannel')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ChannelType')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'PayChannel', 'column', 'ChannelType'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '֧����������',
   'user', @CurrentUser, 'table', 'PayChannel', 'column', 'ChannelType'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('PayChannel')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ChannelName')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'PayChannel', 'column', 'ChannelName'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��������',
   'user', @CurrentUser, 'table', 'PayChannel', 'column', 'ChannelName'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('PayChannel')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'MerchantNo')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'PayChannel', 'column', 'MerchantNo'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�̻���',
   'user', @CurrentUser, 'table', 'PayChannel', 'column', 'MerchantNo'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('PayChannel')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'MerchantKey')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'PayChannel', 'column', 'MerchantKey'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�̻���Կ',
   'user', @CurrentUser, 'table', 'PayChannel', 'column', 'MerchantKey'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('PayChannel')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'MerchantInfo')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'PayChannel', 'column', 'MerchantInfo'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�̻���Ϣ',
   'user', @CurrentUser, 'table', 'PayChannel', 'column', 'MerchantInfo'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('PayChannel')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'PaySite')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'PayChannel', 'column', 'PaySite'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '֧��վ��',
   'user', @CurrentUser, 'table', 'PayChannel', 'column', 'PaySite'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('PayChannel')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'MinOrderAmount')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'PayChannel', 'column', 'MinOrderAmount'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��С֧�����',
   'user', @CurrentUser, 'table', 'PayChannel', 'column', 'MinOrderAmount'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('PayChannel')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'MaxOrderAmount')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'PayChannel', 'column', 'MaxOrderAmount'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '���֧�����',
   'user', @CurrentUser, 'table', 'PayChannel', 'column', 'MaxOrderAmount'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('PayChannel')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'SettleMode')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'PayChannel', 'column', 'SettleMode'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����ģʽ',
   'user', @CurrentUser, 'table', 'PayChannel', 'column', 'SettleMode'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('PayChannel')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FeeRate')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'PayChannel', 'column', 'FeeRate'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��������',
   'user', @CurrentUser, 'table', 'PayChannel', 'column', 'FeeRate'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('PayChannel')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Status')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'PayChannel', 'column', 'Status'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '״̬',
   'user', @CurrentUser, 'table', 'PayChannel', 'column', 'Status'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('PayChannel')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Remark')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'PayChannel', 'column', 'Remark'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��ע',
   'user', @CurrentUser, 'table', 'PayChannel', 'column', 'Remark'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('PayChannel')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CreateTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'PayChannel', 'column', 'CreateTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����ʱ��',
   'user', @CurrentUser, 'table', 'PayChannel', 'column', 'CreateTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('PayChannel')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CreateBy')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'PayChannel', 'column', 'CreateBy'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '������',
   'user', @CurrentUser, 'table', 'PayChannel', 'column', 'CreateBy'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('PayChannel')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UpdateTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'PayChannel', 'column', 'UpdateTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����ʱ��',
   'user', @CurrentUser, 'table', 'PayChannel', 'column', 'UpdateTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('PayChannel')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UpdateBy')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'PayChannel', 'column', 'UpdateBy'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '������',
   'user', @CurrentUser, 'table', 'PayChannel', 'column', 'UpdateBy'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('PayChannel')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Isdelete')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'PayChannel', 'column', 'Isdelete'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�Ƿ�ɾ��',
   'user', @CurrentUser, 'table', 'PayChannel', 'column', 'Isdelete'
go

/*==============================================================*/
/* Table: PayOrder                                              */
/*==============================================================*/
create table PayOrder (
   OrderId              varchar(36)          not null,
   OrderNo              varchar(50)          not null,
   AgentNo              varchar(50)          null,
   MerchantId           varchar(50)          not null,
   MerchantOrderNo      varchar(50)          not null,
   MerchantOrderTime    datetime             not null,
   MemberInfo           varchar(50)          null,
   Ip                   varchar(50)          not null,
   DeviceType           varchar(50)          not null,
   BankInfo             varchar(50)          null,
   BankCode             varchar(50)          null,
   NotifyUrl            varchar(500)         not null,
   ReturnUrl            varchar(500)         null,
   PreorderAmount       decimal(19,4)        not null,
   OrderAmount          decimal(19,4)        not null,
   OrderDescription     nvarchar(100)        null,
   ExtendField          nvarchar(100)        null,
   ServiceId            varchar(50)          null,
   ChannelType          varchar(50)          not null,
   ChannelId            int                  not null,
   ChannelName          varchar(100)         not null,
   SettleMode           varchar(50)          not null,
   SettleDate           datetime             null,
   FeeMode              varchar(50)          null,
   TransRate            decimal(19,4)        not null,
   ServiceRate          decimal(19,4)        not null,
   costRate             decimal(19,4)        not null,
   TransFee             decimal(19,4)        not null,
   ServiceFee           decimal(19,4)        not null,
   costFee              decimal(19,4)        not null,
   TransAmount          decimal(19,4)        not null,
   PayStatus            int                  not null,
   PayTime              datetime             null,
   NotifyStatus         int                  not null,
   settleToMerchant     int                  null,
   settleToCustomer     int                  null,
   TransactionId        varchar(50)          null,
   CreateTime           datetime             not null,
   NotifyCount          int                  not null,
   NotifyMsg            nvarchar(100)        null,
   QueryCount           int                  not null,
   NotifyTime           datetime             null,
   constraint PK_PAYORDER primary key (OrderId)
)
on "PRIMARY"
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('PayOrder') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'PayOrder' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '֧��������', 
   'user', @CurrentUser, 'table', 'PayOrder'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('PayOrder')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'OrderId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'PayOrder', 'column', 'OrderId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ϵͳ����ID',
   'user', @CurrentUser, 'table', 'PayOrder', 'column', 'OrderId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('PayOrder')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'OrderNo')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'PayOrder', 'column', 'OrderNo'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ϵͳ������',
   'user', @CurrentUser, 'table', 'PayOrder', 'column', 'OrderNo'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('PayOrder')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'AgentNo')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'PayOrder', 'column', 'AgentNo'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '������',
   'user', @CurrentUser, 'table', 'PayOrder', 'column', 'AgentNo'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('PayOrder')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'MerchantId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'PayOrder', 'column', 'MerchantId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�̻�ID',
   'user', @CurrentUser, 'table', 'PayOrder', 'column', 'MerchantId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('PayOrder')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'MerchantOrderNo')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'PayOrder', 'column', 'MerchantOrderNo'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�̻�������',
   'user', @CurrentUser, 'table', 'PayOrder', 'column', 'MerchantOrderNo'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('PayOrder')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'MerchantOrderTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'PayOrder', 'column', 'MerchantOrderTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�̻�����ʱ��',
   'user', @CurrentUser, 'table', 'PayOrder', 'column', 'MerchantOrderTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('PayOrder')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'MemberInfo')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'PayOrder', 'column', 'MemberInfo'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��Ա��Ϣ',
   'user', @CurrentUser, 'table', 'PayOrder', 'column', 'MemberInfo'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('PayOrder')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Ip')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'PayOrder', 'column', 'Ip'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'IP��ַ',
   'user', @CurrentUser, 'table', 'PayOrder', 'column', 'Ip'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('PayOrder')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'DeviceType')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'PayOrder', 'column', 'DeviceType'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�豸����',
   'user', @CurrentUser, 'table', 'PayOrder', 'column', 'DeviceType'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('PayOrder')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'BankInfo')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'PayOrder', 'column', 'BankInfo'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '������Ϣ',
   'user', @CurrentUser, 'table', 'PayOrder', 'column', 'BankInfo'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('PayOrder')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'BankCode')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'PayOrder', 'column', 'BankCode'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '���б��',
   'user', @CurrentUser, 'table', 'PayOrder', 'column', 'BankCode'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('PayOrder')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'NotifyUrl')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'PayOrder', 'column', 'NotifyUrl'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�ص���ַ',
   'user', @CurrentUser, 'table', 'PayOrder', 'column', 'NotifyUrl'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('PayOrder')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ReturnUrl')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'PayOrder', 'column', 'ReturnUrl'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '���ص�ַ',
   'user', @CurrentUser, 'table', 'PayOrder', 'column', 'ReturnUrl'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('PayOrder')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'PreorderAmount')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'PayOrder', 'column', 'PreorderAmount'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Ԥ�����',
   'user', @CurrentUser, 'table', 'PayOrder', 'column', 'PreorderAmount'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('PayOrder')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'OrderAmount')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'PayOrder', 'column', 'OrderAmount'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�������',
   'user', @CurrentUser, 'table', 'PayOrder', 'column', 'OrderAmount'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('PayOrder')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'OrderDescription')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'PayOrder', 'column', 'OrderDescription'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��������',
   'user', @CurrentUser, 'table', 'PayOrder', 'column', 'OrderDescription'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('PayOrder')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ExtendField')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'PayOrder', 'column', 'ExtendField'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��չ�ֶ�',
   'user', @CurrentUser, 'table', 'PayOrder', 'column', 'ExtendField'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('PayOrder')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ServiceId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'PayOrder', 'column', 'ServiceId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�����ƷID',
   'user', @CurrentUser, 'table', 'PayOrder', 'column', 'ServiceId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('PayOrder')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ChannelType')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'PayOrder', 'column', 'ChannelType'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��������',
   'user', @CurrentUser, 'table', 'PayOrder', 'column', 'ChannelType'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('PayOrder')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ChannelId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'PayOrder', 'column', 'ChannelId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����ID',
   'user', @CurrentUser, 'table', 'PayOrder', 'column', 'ChannelId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('PayOrder')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ChannelName')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'PayOrder', 'column', 'ChannelName'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��������',
   'user', @CurrentUser, 'table', 'PayOrder', 'column', 'ChannelName'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('PayOrder')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'SettleMode')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'PayOrder', 'column', 'SettleMode'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����ģʽ',
   'user', @CurrentUser, 'table', 'PayOrder', 'column', 'SettleMode'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('PayOrder')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'SettleDate')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'PayOrder', 'column', 'SettleDate'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����ʱ��',
   'user', @CurrentUser, 'table', 'PayOrder', 'column', 'SettleDate'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('PayOrder')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FeeMode')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'PayOrder', 'column', 'FeeMode'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����ģʽ',
   'user', @CurrentUser, 'table', 'PayOrder', 'column', 'FeeMode'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('PayOrder')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'TransRate')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'PayOrder', 'column', 'TransRate'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ת�˷���',
   'user', @CurrentUser, 'table', 'PayOrder', 'column', 'TransRate'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('PayOrder')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ServiceRate')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'PayOrder', 'column', 'ServiceRate'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�������',
   'user', @CurrentUser, 'table', 'PayOrder', 'column', 'ServiceRate'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('PayOrder')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'costRate')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'PayOrder', 'column', 'costRate'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'costRate',
   'user', @CurrentUser, 'table', 'PayOrder', 'column', 'costRate'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('PayOrder')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'TransFee')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'PayOrder', 'column', 'TransFee'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ת��������',
   'user', @CurrentUser, 'table', 'PayOrder', 'column', 'TransFee'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('PayOrder')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ServiceFee')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'PayOrder', 'column', 'ServiceFee'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��Ʒ����������',
   'user', @CurrentUser, 'table', 'PayOrder', 'column', 'ServiceFee'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('PayOrder')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'costFee')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'PayOrder', 'column', 'costFee'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'costFee',
   'user', @CurrentUser, 'table', 'PayOrder', 'column', 'costFee'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('PayOrder')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'TransAmount')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'PayOrder', 'column', 'TransAmount'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ʵ�����ý��(�������-������)',
   'user', @CurrentUser, 'table', 'PayOrder', 'column', 'TransAmount'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('PayOrder')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'PayStatus')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'PayOrder', 'column', 'PayStatus'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '֧��״̬',
   'user', @CurrentUser, 'table', 'PayOrder', 'column', 'PayStatus'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('PayOrder')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'PayTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'PayOrder', 'column', 'PayTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '֧��ʱ��',
   'user', @CurrentUser, 'table', 'PayOrder', 'column', 'PayTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('PayOrder')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'NotifyStatus')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'PayOrder', 'column', 'NotifyStatus'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�ص�״̬',
   'user', @CurrentUser, 'table', 'PayOrder', 'column', 'NotifyStatus'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('PayOrder')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'settleToMerchant')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'PayOrder', 'column', 'settleToMerchant'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'settleToMerchant',
   'user', @CurrentUser, 'table', 'PayOrder', 'column', 'settleToMerchant'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('PayOrder')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'settleToCustomer')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'PayOrder', 'column', 'settleToCustomer'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'settleToCustomer',
   'user', @CurrentUser, 'table', 'PayOrder', 'column', 'settleToCustomer'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('PayOrder')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'TransactionId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'PayOrder', 'column', 'TransactionId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '���׼�¼ID',
   'user', @CurrentUser, 'table', 'PayOrder', 'column', 'TransactionId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('PayOrder')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CreateTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'PayOrder', 'column', 'CreateTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����ʱ��',
   'user', @CurrentUser, 'table', 'PayOrder', 'column', 'CreateTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('PayOrder')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'NotifyCount')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'PayOrder', 'column', 'NotifyCount'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�ص�����',
   'user', @CurrentUser, 'table', 'PayOrder', 'column', 'NotifyCount'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('PayOrder')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'NotifyMsg')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'PayOrder', 'column', 'NotifyMsg'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�ص���Ϣ',
   'user', @CurrentUser, 'table', 'PayOrder', 'column', 'NotifyMsg'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('PayOrder')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'QueryCount')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'PayOrder', 'column', 'QueryCount'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��ѯ����',
   'user', @CurrentUser, 'table', 'PayOrder', 'column', 'QueryCount'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('PayOrder')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'NotifyTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'PayOrder', 'column', 'NotifyTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�ص�ʱ��',
   'user', @CurrentUser, 'table', 'PayOrder', 'column', 'NotifyTime'
go

/*==============================================================*/
/* Table: PayService                                            */
/*==============================================================*/
create table PayService (
   ServiceId            varchar(50)          not null,
   ServiceType          varchar(50)          not null,
   ServiceCode          varchar(50)          not null,
   ServiceName          varchar(50)          not null,
   Status               int                  not null,
   Remark               varchar(500)         null,
   CreateTime           datetime             not null,
   CreateBy             varchar(50)          not null,
   UpdateTime           datetime             null,
   UpdateBy             varchar(50)          null,
   Isdelete             int                  not null,
   constraint PK_PAYSERVICE primary key (ServiceId)
)
on "PRIMARY"
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('PayService') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'PayService' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '֧����Ʒ��', 
   'user', @CurrentUser, 'table', 'PayService'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('PayService')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ServiceId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'PayService', 'column', 'ServiceId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��ƷID',
   'user', @CurrentUser, 'table', 'PayService', 'column', 'ServiceId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('PayService')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ServiceType')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'PayService', 'column', 'ServiceType'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��Ʒ����',
   'user', @CurrentUser, 'table', 'PayService', 'column', 'ServiceType'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('PayService')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ServiceCode')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'PayService', 'column', 'ServiceCode'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��Ʒ����',
   'user', @CurrentUser, 'table', 'PayService', 'column', 'ServiceCode'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('PayService')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ServiceName')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'PayService', 'column', 'ServiceName'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��Ʒ����',
   'user', @CurrentUser, 'table', 'PayService', 'column', 'ServiceName'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('PayService')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Status')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'PayService', 'column', 'Status'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�̻�״̬',
   'user', @CurrentUser, 'table', 'PayService', 'column', 'Status'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('PayService')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Remark')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'PayService', 'column', 'Remark'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��ע',
   'user', @CurrentUser, 'table', 'PayService', 'column', 'Remark'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('PayService')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CreateTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'PayService', 'column', 'CreateTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����ʱ��',
   'user', @CurrentUser, 'table', 'PayService', 'column', 'CreateTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('PayService')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CreateBy')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'PayService', 'column', 'CreateBy'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '������',
   'user', @CurrentUser, 'table', 'PayService', 'column', 'CreateBy'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('PayService')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UpdateTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'PayService', 'column', 'UpdateTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����ʱ��',
   'user', @CurrentUser, 'table', 'PayService', 'column', 'UpdateTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('PayService')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UpdateBy')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'PayService', 'column', 'UpdateBy'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '������',
   'user', @CurrentUser, 'table', 'PayService', 'column', 'UpdateBy'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('PayService')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Isdelete')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'PayService', 'column', 'Isdelete'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�Ƿ�ɾ��',
   'user', @CurrentUser, 'table', 'PayService', 'column', 'Isdelete'
go

/*==============================================================*/
/* Table: Settlement                                            */
/*==============================================================*/
create table Settlement (
   OrderId              varchar(50)          not null,
   OrderNo              varchar(50)          not null,
   AccountId            varchar(50)          null,
   MerchantNo           varchar(50)          not null,
   MerchantOrderNo      varchar(50)          not null,
   OrderAmount          decimal(19,4)        not null,
   TransFee             decimal(19,4)        not null,
   TransAmount          decimal(19,4)        not null,
   AccountName          varchar(50)          not null,
   AccountNumber        varchar(50)          not null,
   BankName             varchar(50)          not null,
   BankCode             varchar(50)          not null,
   BankBranchName       varchar(100)         null,
   Province             varchar(50)          null,
   City                 varchar(50)          null,
   Mobile               varchar(50)          null,
   ExtendField          nvarchar(100)        null,
   Status               varchar(50)          not null,
   QueryCount           int                  not null,
   CallbackStatus       int                  not null,
   CallbackCount        int                  not null,
   CallbackTime         datetime             null,
   CallbackMsg          nvarchar(100)        null,
   CreateBy             varchar(50)          null,
   CreateTime           datetime             not null,
   AuditStatus          int                  not null,
   AuditTime            datetime             null,
   AuditBy              varchar(50)          null,
   Remark               varchar(500)         null,
   constraint PK_SETTLEMENT primary key (OrderId)
)
on "PRIMARY"
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('Settlement') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'Settlement' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '����', 
   'user', @CurrentUser, 'table', 'Settlement'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Settlement')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'OrderId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Settlement', 'column', 'OrderId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '���㶩��ID',
   'user', @CurrentUser, 'table', 'Settlement', 'column', 'OrderId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Settlement')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'OrderNo')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Settlement', 'column', 'OrderNo'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '���㶩����',
   'user', @CurrentUser, 'table', 'Settlement', 'column', 'OrderNo'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Settlement')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'AccountId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Settlement', 'column', 'AccountId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�˻�ID',
   'user', @CurrentUser, 'table', 'Settlement', 'column', 'AccountId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Settlement')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'MerchantNo')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Settlement', 'column', 'MerchantNo'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�̻���',
   'user', @CurrentUser, 'table', 'Settlement', 'column', 'MerchantNo'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Settlement')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'MerchantOrderNo')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Settlement', 'column', 'MerchantOrderNo'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�̻�������',
   'user', @CurrentUser, 'table', 'Settlement', 'column', 'MerchantOrderNo'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Settlement')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'OrderAmount')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Settlement', 'column', 'OrderAmount'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '���㶩�����',
   'user', @CurrentUser, 'table', 'Settlement', 'column', 'OrderAmount'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Settlement')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'TransFee')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Settlement', 'column', 'TransFee'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ת��������',
   'user', @CurrentUser, 'table', 'Settlement', 'column', 'TransFee'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Settlement')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'TransAmount')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Settlement', 'column', 'TransAmount'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ʵ��ת�˽��',
   'user', @CurrentUser, 'table', 'Settlement', 'column', 'TransAmount'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Settlement')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'AccountName')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Settlement', 'column', 'AccountName'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�˻�����',
   'user', @CurrentUser, 'table', 'Settlement', 'column', 'AccountName'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Settlement')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'AccountNumber')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Settlement', 'column', 'AccountNumber'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�˺�',
   'user', @CurrentUser, 'table', 'Settlement', 'column', 'AccountNumber'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Settlement')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'BankName')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Settlement', 'column', 'BankName'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����',
   'user', @CurrentUser, 'table', 'Settlement', 'column', 'BankName'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Settlement')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'BankCode')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Settlement', 'column', 'BankCode'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '���б���',
   'user', @CurrentUser, 'table', 'Settlement', 'column', 'BankCode'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Settlement')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'BankBranchName')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Settlement', 'column', 'BankBranchName'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '֧��',
   'user', @CurrentUser, 'table', 'Settlement', 'column', 'BankBranchName'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Settlement')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Province')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Settlement', 'column', 'Province'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ʡ��',
   'user', @CurrentUser, 'table', 'Settlement', 'column', 'Province'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Settlement')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'City')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Settlement', 'column', 'City'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����',
   'user', @CurrentUser, 'table', 'Settlement', 'column', 'City'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Settlement')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Mobile')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Settlement', 'column', 'Mobile'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�ֻ���',
   'user', @CurrentUser, 'table', 'Settlement', 'column', 'Mobile'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Settlement')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ExtendField')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Settlement', 'column', 'ExtendField'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��չ�ֶ�',
   'user', @CurrentUser, 'table', 'Settlement', 'column', 'ExtendField'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Settlement')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Status')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Settlement', 'column', 'Status'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����״̬',
   'user', @CurrentUser, 'table', 'Settlement', 'column', 'Status'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Settlement')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'QueryCount')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Settlement', 'column', 'QueryCount'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��ѯ����',
   'user', @CurrentUser, 'table', 'Settlement', 'column', 'QueryCount'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Settlement')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CallbackStatus')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Settlement', 'column', 'CallbackStatus'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�ص�״̬',
   'user', @CurrentUser, 'table', 'Settlement', 'column', 'CallbackStatus'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Settlement')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CallbackCount')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Settlement', 'column', 'CallbackCount'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�ص�����',
   'user', @CurrentUser, 'table', 'Settlement', 'column', 'CallbackCount'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Settlement')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CallbackTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Settlement', 'column', 'CallbackTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�ص�ʱ��',
   'user', @CurrentUser, 'table', 'Settlement', 'column', 'CallbackTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Settlement')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CallbackMsg')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Settlement', 'column', 'CallbackMsg'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�ص���Ϣ',
   'user', @CurrentUser, 'table', 'Settlement', 'column', 'CallbackMsg'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Settlement')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CreateBy')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Settlement', 'column', 'CreateBy'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '������',
   'user', @CurrentUser, 'table', 'Settlement', 'column', 'CreateBy'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Settlement')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CreateTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Settlement', 'column', 'CreateTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����ʱ��',
   'user', @CurrentUser, 'table', 'Settlement', 'column', 'CreateTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Settlement')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'AuditStatus')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Settlement', 'column', 'AuditStatus'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '���״̬',
   'user', @CurrentUser, 'table', 'Settlement', 'column', 'AuditStatus'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Settlement')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'AuditTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Settlement', 'column', 'AuditTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '���ʱ��',
   'user', @CurrentUser, 'table', 'Settlement', 'column', 'AuditTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Settlement')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'AuditBy')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Settlement', 'column', 'AuditBy'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�����',
   'user', @CurrentUser, 'table', 'Settlement', 'column', 'AuditBy'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Settlement')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Remark')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Settlement', 'column', 'Remark'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��ע',
   'user', @CurrentUser, 'table', 'Settlement', 'column', 'Remark'
go

/*==============================================================*/
/* Table: "Transaction"                                         */
/*==============================================================*/
create table "Transaction" (
   TransactionId        varchar(50)          not null,
   TransType            int                  not null,
   TransAmount          decimal(19,4)        not null,
   OrderAmount          decimal(19,4)        not null,
   TransFee             decimal(19,4)        not null,
   ServiceFee           decimal(19,4)        not null,
   costFee              decimal(19,4)        not null,
   Remark               varchar(100)         null,
   optName              varchar(100)         null,
   CreateTime           datetime             not null,
   constraint PK_TRANSACTION primary key (TransactionId)
)
on "PRIMARY"
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('"Transaction"') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'Transaction' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '���׼�¼��', 
   'user', @CurrentUser, 'table', 'Transaction'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('"Transaction"')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'TransactionId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Transaction', 'column', 'TransactionId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '���׼�¼ID',
   'user', @CurrentUser, 'table', 'Transaction', 'column', 'TransactionId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('"Transaction"')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'TransType')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Transaction', 'column', 'TransType'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '���׼�¼����(֧��=1������=2)',
   'user', @CurrentUser, 'table', 'Transaction', 'column', 'TransType'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('"Transaction"')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'TransAmount')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Transaction', 'column', 'TransAmount'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '���׽��',
   'user', @CurrentUser, 'table', 'Transaction', 'column', 'TransAmount'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('"Transaction"')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'OrderAmount')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Transaction', 'column', 'OrderAmount'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�������',
   'user', @CurrentUser, 'table', 'Transaction', 'column', 'OrderAmount'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('"Transaction"')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'TransFee')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Transaction', 'column', 'TransFee'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ת��������',
   'user', @CurrentUser, 'table', 'Transaction', 'column', 'TransFee'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('"Transaction"')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ServiceFee')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Transaction', 'column', 'ServiceFee'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��Ʒ������',
   'user', @CurrentUser, 'table', 'Transaction', 'column', 'ServiceFee'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('"Transaction"')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'costFee')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Transaction', 'column', 'costFee'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'costFee',
   'user', @CurrentUser, 'table', 'Transaction', 'column', 'costFee'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('"Transaction"')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Remark')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Transaction', 'column', 'Remark'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��ע',
   'user', @CurrentUser, 'table', 'Transaction', 'column', 'Remark'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('"Transaction"')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'optName')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Transaction', 'column', 'optName'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'optName',
   'user', @CurrentUser, 'table', 'Transaction', 'column', 'optName'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('"Transaction"')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CreateTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Transaction', 'column', 'CreateTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����ʱ��',
   'user', @CurrentUser, 'table', 'Transaction', 'column', 'CreateTime'
go

/*==============================================================*/
/* Index: idx_transaction_awtm                                  */
/*==============================================================*/
create index idx_transaction_awtm on "Transaction" (
CreateTime ASC
)
on "PRIMARY"
go
