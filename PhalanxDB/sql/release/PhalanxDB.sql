/*
Deployment script for PhalanxDB
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "PhalanxDB"
:setvar DefaultDataPath ""
:setvar DefaultLogPath ""

GO
:on error exit
GO
USE [master]
GO
IF (DB_ID(N'$(DatabaseName)') IS NOT NULL
    AND DATABASEPROPERTYEX(N'$(DatabaseName)','Status') <> N'ONLINE')
BEGIN
    RAISERROR(N'The state of the target database, %s, is not set to ONLINE. To deploy to this database, its state must be set to ONLINE.', 16, 127,N'$(DatabaseName)') WITH NOWAIT
    RETURN
END

GO
IF (DB_ID(N'$(DatabaseName)') IS NOT NULL) 
BEGIN
    ALTER DATABASE [$(DatabaseName)]
    SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE [$(DatabaseName)];
END

GO
PRINT N'Creating $(DatabaseName)...'
GO
CREATE DATABASE [$(DatabaseName)]
    ON 
    PRIMARY(NAME = [phalanx_Data], FILENAME = '$(DefaultDataPath)$(DatabaseName).mdf', FILEGROWTH = 10 %)
    LOG ON (NAME = [phalanx_Log], FILENAME = '$(DefaultLogPath)$(DatabaseName)_log.ldf', FILEGROWTH = 10 %) COLLATE SQL_Latin1_General_CP1_CI_AS
GO
EXECUTE sp_dbcmptlevel [$(DatabaseName)], 90;


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ANSI_NULLS ON,
                ANSI_PADDING ON,
                ANSI_WARNINGS ON,
                ARITHABORT ON,
                CONCAT_NULL_YIELDS_NULL ON,
                NUMERIC_ROUNDABORT OFF,
                QUOTED_IDENTIFIER ON,
                ANSI_NULL_DEFAULT ON,
                CURSOR_DEFAULT LOCAL,
                RECOVERY FULL,
                CURSOR_CLOSE_ON_COMMIT OFF,
                AUTO_CREATE_STATISTICS ON,
                AUTO_SHRINK OFF,
                AUTO_UPDATE_STATISTICS ON,
                RECURSIVE_TRIGGERS OFF 
            WITH ROLLBACK IMMEDIATE;
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_CLOSE OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ALLOW_SNAPSHOT_ISOLATION OFF;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET READ_COMMITTED_SNAPSHOT OFF;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_UPDATE_STATISTICS_ASYNC OFF,
                PAGE_VERIFY NONE,
                DATE_CORRELATION_OPTIMIZATION OFF,
                DISABLE_BROKER,
                PARAMETERIZATION SIMPLE,
                SUPPLEMENTAL_LOGGING OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF IS_SRVROLEMEMBER(N'sysadmin') = 1
    BEGIN
        IF EXISTS (SELECT 1
                   FROM   [master].[dbo].[sysdatabases]
                   WHERE  [name] = N'$(DatabaseName)')
            BEGIN
                EXECUTE sp_executesql N'ALTER DATABASE [$(DatabaseName)]
    SET TRUSTWORTHY OFF,
        DB_CHAINING OFF 
    WITH ROLLBACK IMMEDIATE';
            END
    END
ELSE
    BEGIN
        PRINT N'The database settings cannot be modified. You must be a SysAdmin to apply these settings.';
    END


GO
USE [$(DatabaseName)]
GO
IF fulltextserviceproperty(N'IsFulltextInstalled') = 1
    EXECUTE sp_fulltext_database 'enable';


GO
/*
 Pre-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be executed before the build script.	
 Use SQLCMD syntax to include a file in the pre-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the pre-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

GO
PRINT N'Creating [dbo].[accion_item_chk_win_local_user]...';


GO
CREATE TABLE [dbo].[accion_item_chk_win_local_user] (
    [id]     INT           NOT NULL,
    [nombre] VARCHAR (150) NOT NULL
);


GO
PRINT N'Creating PK_accion_item_chk_win_local_user...';


GO
ALTER TABLE [dbo].[accion_item_chk_win_local_user]
    ADD CONSTRAINT [PK_accion_item_chk_win_local_user] PRIMARY KEY CLUSTERED ([id] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating [dbo].[aplicacion_notificacion_clave]...';


GO
CREATE TABLE [dbo].[aplicacion_notificacion_clave] (
    [anc_id]          INT          IDENTITY (1, 1) NOT NULL,
    [anc_code]        VARCHAR (50) NOT NULL,
    [anc_name]        VARCHAR (50) NOT NULL,
    [anc_notificable] BIT          NOT NULL
);


GO
PRINT N'Creating PK_aplicacion_notificacion_clave...';


GO
ALTER TABLE [dbo].[aplicacion_notificacion_clave]
    ADD CONSTRAINT [PK_aplicacion_notificacion_clave] PRIMARY KEY CLUSTERED ([anc_id] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating [dbo].[Applications]...';


GO
CREATE TABLE [dbo].[Applications] (
    [app_id]               INT           IDENTITY (1, 1) NOT NULL,
    [app_name]             VARCHAR (100) COLLATE Latin1_General_CI_AS NOT NULL,
    [app_desc]             VARCHAR (200) COLLATE Latin1_General_CI_AS NULL,
    [app_field1_desc]      VARCHAR (50)  COLLATE Latin1_General_CI_AS NULL,
    [app_field2_desc]      VARCHAR (50)  COLLATE Latin1_General_CI_AS NULL,
    [app_field3_desc]      VARCHAR (50)  COLLATE Latin1_General_CI_AS NULL,
    [active]               BIT           NOT NULL,
    [desactiva_pwd_cierre] BIT           NOT NULL
);


GO
PRINT N'Creating PK_Applications...';


GO
ALTER TABLE [dbo].[Applications]
    ADD CONSTRAINT [PK_Applications] PRIMARY KEY CLUSTERED ([app_id] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating [dbo].[Applications_Users]...';


GO
CREATE TABLE [dbo].[Applications_Users] (
    [user_id]          INT          NOT NULL,
    [app_id]           INT          NOT NULL,
    [app_field1_value] VARCHAR (50) COLLATE Latin1_General_CI_AS NULL,
    [app_field2_value] VARCHAR (50) COLLATE Latin1_General_CI_AS NULL,
    [app_field3_value] VARCHAR (50) COLLATE Latin1_General_CI_AS NULL
);


GO
PRINT N'Creating PK_Applications_Users...';


GO
ALTER TABLE [dbo].[Applications_Users]
    ADD CONSTRAINT [PK_Applications_Users] PRIMARY KEY CLUSTERED ([user_id] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating [dbo].[AS400]...';


GO
CREATE TABLE [dbo].[AS400] (
    [as_id]          INT           IDENTITY (1, 1) NOT NULL,
    [as_server_name] VARCHAR (100) COLLATE Latin1_General_CI_AS NOT NULL,
    [as_desc]        VARCHAR (200) COLLATE Latin1_General_CI_AS NULL,
    [as_ip]          VARCHAR (15)  COLLATE Latin1_General_CI_AS NULL,
    [active]         BIT           NOT NULL
);


GO
PRINT N'Creating PK_AS400...';


GO
ALTER TABLE [dbo].[AS400]
    ADD CONSTRAINT [PK_AS400] PRIMARY KEY CLUSTERED ([as_id] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating [dbo].[AS400_users]...';


GO
CREATE TABLE [dbo].[AS400_users] (
    [user_id] INT NOT NULL,
    [as_id]   INT NOT NULL
);


GO
PRINT N'Creating PK_AS400_users...';


GO
ALTER TABLE [dbo].[AS400_users]
    ADD CONSTRAINT [PK_AS400_users] PRIMARY KEY CLUSTERED ([user_id] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating [dbo].[ATMs_Users]...';


GO
CREATE TABLE [dbo].[ATMs_Users] (
    [user_id]    INT           NOT NULL,
    [ATM_name]   VARCHAR (150) NOT NULL,
    [componente] VARCHAR (50)  NOT NULL
);


GO
PRINT N'Creating PK_ATMs_Users...';


GO
ALTER TABLE [dbo].[ATMs_Users]
    ADD CONSTRAINT [PK_ATMs_Users] PRIMARY KEY CLUSTERED ([user_id] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating [dbo].[audit_application]...';


GO
CREATE TABLE [dbo].[audit_application] (
    [aa_id]       INT           NOT NULL,
    [aa_app_name] VARCHAR (200) NOT NULL
);


GO
PRINT N'Creating PK_audit_application...';


GO
ALTER TABLE [dbo].[audit_application]
    ADD CONSTRAINT [PK_audit_application] PRIMARY KEY CLUSTERED ([aa_id] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating [dbo].[audit_login]...';


GO
CREATE TABLE [dbo].[audit_login] (
    [aud_login_id]    INT           IDENTITY (1, 1) NOT NULL,
    [fecha]           DATETIME      NOT NULL,
    [terminal]        VARCHAR (150) NOT NULL,
    [id_usuario]      INT           NULL,
    [username]        VARCHAR (50)  NOT NULL,
    [fullname]        VARCHAR (100) NULL,
    [evento_login_id] INT           NOT NULL,
    [app_id]          INT           NOT NULL
);


GO
PRINT N'Creating PK_audit_login...';


GO
ALTER TABLE [dbo].[audit_login]
    ADD CONSTRAINT [PK_audit_login] PRIMARY KEY CLUSTERED ([aud_login_id] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating [dbo].[audit_login_historico]...';


GO
CREATE TABLE [dbo].[audit_login_historico] (
    [aud_login_id]    INT           NOT NULL,
    [fecha]           DATETIME      NOT NULL,
    [terminal]        VARCHAR (150) NOT NULL,
    [id_usuario]      INT           NULL,
    [username]        VARCHAR (50)  NOT NULL,
    [fullname]        VARCHAR (100) NULL,
    [evento_login_id] INT           NOT NULL,
    [app_id]          INT           NOT NULL,
    [fecha_borrado]   DATETIME      NULL
);


GO
PRINT N'Creating PK_audit_login_historico...';


GO
ALTER TABLE [dbo].[audit_login_historico]
    ADD CONSTRAINT [PK_audit_login_historico] PRIMARY KEY CLUSTERED ([aud_login_id] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating [dbo].[audit_permisos]...';


GO
CREATE TABLE [dbo].[audit_permisos] (
    [audit_permisos_id]    INT           IDENTITY (1, 1) NOT NULL,
    [recurso]              VARCHAR (50)  NOT NULL,
    [fecha]                DATETIME      NOT NULL,
    [terminal_abm]         VARCHAR (150) NOT NULL,
    [id_usuario_abm]       INT           NOT NULL,
    [username_abm]         VARCHAR (100) NOT NULL,
    [fullname_abm]         VARCHAR (150) NOT NULL,
    [id_rol]               INT           NOT NULL,
    [rol]                  VARCHAR (200) NOT NULL,
    [accion]               VARCHAR (50)  NOT NULL,
    [accion_satisfactoria] BIT           NOT NULL,
    [id_usuario]           INT           NOT NULL,
    [username]             VARCHAR (50)  NOT NULL,
    [fullname]             VARCHAR (100) NOT NULL
);


GO
PRINT N'Creating PK_audit_permisos...';


GO
ALTER TABLE [dbo].[audit_permisos]
    ADD CONSTRAINT [PK_audit_permisos] PRIMARY KEY CLUSTERED ([audit_permisos_id] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating [dbo].[audit_phx_privilege_role]...';


GO
CREATE TABLE [dbo].[audit_phx_privilege_role] (
    [audit_phx_priv_role_id] INT           IDENTITY (1, 1) NOT NULL,
    [fecha]                  DATETIME      NOT NULL,
    [terminal_abm]           VARCHAR (150) NOT NULL,
    [id_usuario_abm]         INT           NOT NULL,
    [username_abm]           VARCHAR (100) NOT NULL,
    [fullname_abm]           VARCHAR (150) NOT NULL,
    [phx_role_id]            INT           NOT NULL,
    [rolename]               VARCHAR (200) NOT NULL,
    [phx_privilege_id]       INT           NOT NULL,
    [phx_privilege_name]     VARCHAR (150) NOT NULL,
    [accion]                 VARCHAR (50)  NOT NULL,
    [accion_satisfactoria]   BIT           NOT NULL
);


GO
PRINT N'Creating PK_audit_phx_privilege_role...';


GO
ALTER TABLE [dbo].[audit_phx_privilege_role]
    ADD CONSTRAINT [PK_audit_phx_privilege_role] PRIMARY KEY CLUSTERED ([audit_phx_priv_role_id] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating [dbo].[audit_phx_role]...';


GO
CREATE TABLE [dbo].[audit_phx_role] (
    [audit_phx_role_id]    INT           IDENTITY (1, 1) NOT NULL,
    [phx_role_id]          INT           NOT NULL,
    [rolename]             VARCHAR (200) NOT NULL,
    [terminal_abm]         VARCHAR (150) NOT NULL,
    [id_usuario_abm]       INT           NOT NULL,
    [username_abm]         VARCHAR (100) NOT NULL,
    [fullname_abm]         VARCHAR (150) NOT NULL,
    [operacion]            VARCHAR (50)  NOT NULL,
    [accion_satisfactoria] BIT           NOT NULL,
    [fecha]                DATETIME      NOT NULL
);


GO
PRINT N'Creating PK_audit_phx_role...';


GO
ALTER TABLE [dbo].[audit_phx_role]
    ADD CONSTRAINT [PK_audit_phx_role] PRIMARY KEY CLUSTERED ([audit_phx_role_id] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating [dbo].[audit_phx_user]...';


GO
CREATE TABLE [dbo].[audit_phx_user] (
    [audit_phx_user_id]         INT           IDENTITY (1, 1) NOT NULL,
    [phx_user_id]               INT           NOT NULL,
    [username]                  VARCHAR (50)  COLLATE Latin1_General_CI_AS NOT NULL,
    [fullname]                  VARCHAR (100) COLLATE Latin1_General_CI_AS NOT NULL,
    [user_domain]               VARCHAR (50)  COLLATE Latin1_General_CI_AS NULL,
    [user_email]                VARCHAR (150) COLLATE Latin1_General_CI_AS NULL,
    [creation_date]             DATETIME      NULL,
    [delete_date]               DATETIME      NULL,
    [phx_user_file_number]      VARCHAR (10)  COLLATE Latin1_General_CI_AS NULL,
    [phx_user_relation_type]    CHAR (1)      COLLATE Latin1_General_CI_AS NULL,
    [phx_user_branch]           VARCHAR (100) COLLATE Latin1_General_CI_AS NULL,
    [phx_user_function]         VARCHAR (50)  COLLATE Latin1_General_CI_AS NULL,
    [phx_user_building_adress]  VARCHAR (50)  COLLATE Latin1_General_CI_AS NULL,
    [phx_user_building_floor]   VARCHAR (5)   COLLATE Latin1_General_CI_AS NULL,
    [phx_user_extension_number] VARCHAR (4)   COLLATE Latin1_General_CI_AS NULL,
    [active]                    BIT           NOT NULL,
    [sup_id]                    INT           NULL,
    [sup_name]                  VARCHAR (100) NULL,
    [sup_mail]                  VARCHAR (100) NULL
);


GO
PRINT N'Creating PK_audit_phx_user...';


GO
ALTER TABLE [dbo].[audit_phx_user]
    ADD CONSTRAINT [PK_audit_phx_user] PRIMARY KEY CLUSTERED ([audit_phx_user_id] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating [dbo].[audit_ticket_notificacion]...';


GO
CREATE TABLE [dbo].[audit_ticket_notificacion] (
    [atn_id]     INT      IDENTITY (1, 1) NOT NULL,
    [atn_fecha]  DATETIME NOT NULL,
    [atn_tnc_id] INT      NOT NULL
);


GO
PRINT N'Creating PK_audit_notificacion_ticket...';


GO
ALTER TABLE [dbo].[audit_ticket_notificacion]
    ADD CONSTRAINT [PK_audit_notificacion_ticket] PRIMARY KEY CLUSTERED ([atn_id] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating [dbo].[audit_usuarios]...';


GO
CREATE TABLE [dbo].[audit_usuarios] (
    [aud_usr_id]            INT           IDENTITY (1, 1) NOT NULL,
    [recurso]               VARCHAR (50)  NOT NULL,
    [id_usuario]            INT           NOT NULL,
    [username]              VARCHAR (50)  NOT NULL,
    [fullname]              VARCHAR (100) NOT NULL,
    [fecha]                 DATETIME      NOT NULL,
    [operacion]             VARCHAR (50)  NOT NULL,
    [id_usuario_abm]        INT           NOT NULL,
    [username_abm]          VARCHAR (50)  NOT NULL,
    [fullname_abm]          VARCHAR (100) NOT NULL,
    [terminal_abm]          VARCHAR (150) NOT NULL,
    [accion_satisfactoria]  BIT           NOT NULL,
    [audit_phx_user_id_old] INT           NULL,
    [audit_phx_user_id_new] INT           NULL
);


GO
PRINT N'Creating PK_audit_usuarios...';


GO
ALTER TABLE [dbo].[audit_usuarios]
    ADD CONSTRAINT [PK_audit_usuarios] PRIMARY KEY CLUSTERED ([aud_usr_id] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating [dbo].[Building]...';


GO
CREATE TABLE [dbo].[Building] (
    [bld_id]      INT          IDENTITY (1, 1) NOT NULL,
    [bld_address] VARCHAR (50) NOT NULL
);


GO
PRINT N'Creating PK_Building...';


GO
ALTER TABLE [dbo].[Building]
    ADD CONSTRAINT [PK_Building] PRIMARY KEY CLUSTERED ([bld_id] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating [dbo].[Communication_Device_Protocols]...';


GO
CREATE TABLE [dbo].[Communication_Device_Protocols] (
    [cm_dv_protocol_id]   INT          IDENTITY (1, 1) NOT NULL,
    [cm_dv_protocol_name] VARCHAR (50) NOT NULL
);


GO
PRINT N'Creating PK_Communication_Device_Protocols...';


GO
ALTER TABLE [dbo].[Communication_Device_Protocols]
    ADD CONSTRAINT [PK_Communication_Device_Protocols] PRIMARY KEY CLUSTERED ([cm_dv_protocol_id] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating [dbo].[Communication_Device_Types]...';


GO
CREATE TABLE [dbo].[Communication_Device_Types] (
    [cm_dv_type_id]   INT          IDENTITY (1, 1) NOT NULL,
    [cm_dv_type_name] VARCHAR (50) COLLATE Latin1_General_CI_AS NOT NULL
);


GO
PRINT N'Creating PK_Communication_Device_Types...';


GO
ALTER TABLE [dbo].[Communication_Device_Types]
    ADD CONSTRAINT [PK_Communication_Device_Types] PRIMARY KEY CLUSTERED ([cm_dv_type_id] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating [dbo].[Communication_Device_User_Protocol]...';


GO
CREATE TABLE [dbo].[Communication_Device_User_Protocol] (
    [Id]                INT IDENTITY (1, 1) NOT NULL,
    [cm_dv_user_id]     INT NOT NULL,
    [cm_dv_protocol_id] INT NOT NULL
);


GO
PRINT N'Creating PK_Communication_Device_User_Protocol...';


GO
ALTER TABLE [dbo].[Communication_Device_User_Protocol]
    ADD CONSTRAINT [PK_Communication_Device_User_Protocol] PRIMARY KEY CLUSTERED ([Id] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating [dbo].[Communication_Device_Users]...';


GO
CREATE TABLE [dbo].[Communication_Device_Users] (
    [user_id]  INT NOT NULL,
    [cm_dv_id] INT NOT NULL
);


GO
PRINT N'Creating PK_Communication_Device_Users...';


GO
ALTER TABLE [dbo].[Communication_Device_Users]
    ADD CONSTRAINT [PK_Communication_Device_Users] PRIMARY KEY CLUSTERED ([user_id] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating [dbo].[Communication_Devices]...';


GO
CREATE TABLE [dbo].[Communication_Devices] (
    [cm_dv_id]          INT           IDENTITY (1, 1) NOT NULL,
    [cm_dv_name]        VARCHAR (100) COLLATE Latin1_General_CI_AS NOT NULL,
    [cm_dv_ip]          VARCHAR (15)  NOT NULL,
    [cm_dv_type_id]     INT           NOT NULL,
    [cm_dv_description] VARCHAR (200) NULL,
    [cm_dv_active]      TINYINT       NOT NULL
);


GO
PRINT N'Creating PK_Communication_Devices...';


GO
ALTER TABLE [dbo].[Communication_Devices]
    ADD CONSTRAINT [PK_Communication_Devices] PRIMARY KEY CLUSTERED ([cm_dv_id] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating [dbo].[Data_Bases]...';


GO
CREATE TABLE [dbo].[Data_Bases] (
    [db_id]          INT           IDENTITY (1, 1) NOT NULL,
    [db_type_id]     INT           NOT NULL,
    [db_name]        VARCHAR (100) COLLATE Latin1_General_CI_AS NOT NULL,
    [db_desc]        VARCHAR (200) COLLATE Latin1_General_CI_AS NULL,
    [db_server_name] VARCHAR (100) COLLATE Latin1_General_CI_AS NULL,
    [db_server_ip1]  TINYINT       NULL,
    [db_server_ip2]  TINYINT       NULL,
    [db_server_ip3]  TINYINT       NULL,
    [db_server_ip4]  TINYINT       NULL,
    [db_port]        INT           NULL,
    [win_pc_id]      INT           NULL,
    [unx_id]         INT           NULL,
    [active]         BIT           NOT NULL
);


GO
PRINT N'Creating PK_Data_Bases...';


GO
ALTER TABLE [dbo].[Data_Bases]
    ADD CONSTRAINT [PK_Data_Bases] PRIMARY KEY CLUSTERED ([db_id] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating [dbo].[Database_Types]...';


GO
CREATE TABLE [dbo].[Database_Types] (
    [db_type_id]   INT           IDENTITY (1, 1) NOT NULL,
    [db_type_code] VARCHAR (50)  COLLATE Latin1_General_CI_AS NOT NULL,
    [db_type_name] VARCHAR (100) COLLATE Latin1_General_CI_AS NOT NULL
);


GO
PRINT N'Creating PK_DataBase_Types...';


GO
ALTER TABLE [dbo].[Database_Types]
    ADD CONSTRAINT [PK_DataBase_Types] PRIMARY KEY CLUSTERED ([db_type_id] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating IX_DataBase_Types_UniqueCode...';


GO
ALTER TABLE [dbo].[Database_Types]
    ADD CONSTRAINT [IX_DataBase_Types_UniqueCode] UNIQUE NONCLUSTERED ([db_type_code] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY];


GO
PRINT N'Creating [dbo].[Databases_Users]...';


GO
CREATE TABLE [dbo].[Databases_Users] (
    [user_id] INT NOT NULL,
    [db_id]   INT NOT NULL
);


GO
PRINT N'Creating PK_Databases_Users...';


GO
ALTER TABLE [dbo].[Databases_Users]
    ADD CONSTRAINT [PK_Databases_Users] PRIMARY KEY CLUSTERED ([user_id] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating [dbo].[Delegation_Requests]...';


GO
CREATE TABLE [dbo].[Delegation_Requests] (
    [request_id]   INT NOT NULL,
    [win_group_id] INT NOT NULL
);


GO
PRINT N'Creating PK_Delegation_Requests...';


GO
ALTER TABLE [dbo].[Delegation_Requests]
    ADD CONSTRAINT [PK_Delegation_Requests] PRIMARY KEY CLUSTERED ([request_id] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating [dbo].[Demo_Conf]...';


GO
CREATE TABLE [dbo].[Demo_Conf] (
    [demo_conf_id] INT           IDENTITY (1, 1) NOT NULL,
    [conf_code]    VARCHAR (50)  COLLATE Latin1_General_CI_AS NOT NULL,
    [conf_value]   VARCHAR (100) COLLATE Latin1_General_CI_AS NULL
);


GO
PRINT N'Creating PK_Demo_Conf...';


GO
ALTER TABLE [dbo].[Demo_Conf]
    ADD CONSTRAINT [PK_Demo_Conf] PRIMARY KEY CLUSTERED ([demo_conf_id] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating [dbo].[Devices]...';


GO
CREATE TABLE [dbo].[Devices] (
    [dv_id]      INT           IDENTITY (1, 1) NOT NULL,
    [dv_type_id] INT           NOT NULL,
    [dv_name]    VARCHAR (100) COLLATE Latin1_General_CI_AS NOT NULL,
    [dv_ip1]     TINYINT       NULL,
    [dv_ip2]     TINYINT       NULL,
    [dv_ip3]     TINYINT       NULL,
    [dv_ip4]     TINYINT       NULL,
    [dv_desc]    VARCHAR (200) COLLATE Latin1_General_CI_AS NULL
);


GO
PRINT N'Creating PK_Devices...';


GO
ALTER TABLE [dbo].[Devices]
    ADD CONSTRAINT [PK_Devices] PRIMARY KEY CLUSTERED ([dv_id] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating [dbo].[Devices_types]...';


GO
CREATE TABLE [dbo].[Devices_types] (
    [dv_type_id]   INT          IDENTITY (1, 1) NOT NULL,
    [dv_type_code] VARCHAR (50) COLLATE Latin1_General_CI_AS NOT NULL,
    [dv_type_desc] VARCHAR (50) COLLATE Latin1_General_CI_AS NOT NULL
);


GO
PRINT N'Creating PK_devices_type...';


GO
ALTER TABLE [dbo].[Devices_types]
    ADD CONSTRAINT [PK_devices_type] PRIMARY KEY CLUSTERED ([dv_type_id] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating [dbo].[Devices_users]...';


GO
CREATE TABLE [dbo].[Devices_users] (
    [user_id] INT NOT NULL,
    [dv_id]   INT NOT NULL
);


GO
PRINT N'Creating PK_Devices_users...';


GO
ALTER TABLE [dbo].[Devices_users]
    ADD CONSTRAINT [PK_Devices_users] PRIMARY KEY CLUSTERED ([user_id] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating [dbo].[evento_login]...';


GO
CREATE TABLE [dbo].[evento_login] (
    [evento_login_id] INT           NOT NULL,
    [evento]          VARCHAR (150) NOT NULL
);


GO
PRINT N'Creating PK_evento_login...';


GO
ALTER TABLE [dbo].[evento_login]
    ADD CONSTRAINT [PK_evento_login] PRIMARY KEY CLUSTERED ([evento_login_id] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating [dbo].[followup_request_group]...';


GO
CREATE TABLE [dbo].[followup_request_group] (
    [frg_id]     INT          IDENTITY (1, 1) NOT NULL,
    [frg_name]   VARCHAR (50) NOT NULL,
    [frg_active] BIT          NOT NULL
);


GO
PRINT N'Creating PK_followup_request_group...';


GO
ALTER TABLE [dbo].[followup_request_group]
    ADD CONSTRAINT [PK_followup_request_group] PRIMARY KEY CLUSTERED ([frg_id] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating [dbo].[followup_request_group_default]...';


GO
CREATE TABLE [dbo].[followup_request_group_default] (
    [frgd_id]      INT IDENTITY (1, 1) NOT NULL,
    [user_type_id] INT NOT NULL,
    [frg_id]       INT NOT NULL
);


GO
PRINT N'Creating PK_followup_request_group_default...';


GO
ALTER TABLE [dbo].[followup_request_group_default]
    ADD CONSTRAINT [PK_followup_request_group_default] PRIMARY KEY CLUSTERED ([frgd_id] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating IX_followup_request_group_default...';


GO
ALTER TABLE [dbo].[followup_request_group_default]
    ADD CONSTRAINT [IX_followup_request_group_default] UNIQUE NONCLUSTERED ([user_type_id] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY];


GO
PRINT N'Creating [dbo].[followup_request_group_password]...';


GO
CREATE TABLE [dbo].[followup_request_group_password] (
    [frgp_id]          INT IDENTITY (1, 1) NOT NULL,
    [frg_id]           INT NOT NULL,
    [user_password_id] INT NOT NULL
);


GO
PRINT N'Creating PK_followup_request_group_password...';


GO
ALTER TABLE [dbo].[followup_request_group_password]
    ADD CONSTRAINT [PK_followup_request_group_password] PRIMARY KEY CLUSTERED ([frgp_id] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating [dbo].[followup_request_group_user]...';


GO
CREATE TABLE [dbo].[followup_request_group_user] (
    [frgu_id]     INT IDENTITY (1, 1) NOT NULL,
    [phx_user_id] INT NOT NULL,
    [frg_id]      INT NOT NULL
);


GO
PRINT N'Creating PK_followup_rqst_grp_user...';


GO
ALTER TABLE [dbo].[followup_request_group_user]
    ADD CONSTRAINT [PK_followup_rqst_grp_user] PRIMARY KEY CLUSTERED ([frgu_id] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating [dbo].[Global_Win_Groups]...';


GO
CREATE TABLE [dbo].[Global_Win_Groups] (
    [win_group_id]  INT NOT NULL,
    [win_domain_id] INT NOT NULL
);


GO
PRINT N'Creating PK_Global_Win_Groups...';


GO
ALTER TABLE [dbo].[Global_Win_Groups]
    ADD CONSTRAINT [PK_Global_Win_Groups] PRIMARY KEY CLUSTERED ([win_group_id] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating [dbo].[hist_change_password]...';


GO
CREATE TABLE [dbo].[hist_change_password] (
    [hist_chg_pwd_id] INT           IDENTITY (1, 1) NOT NULL,
    [user_id]         INT           NOT NULL,
    [phx_user_id]     INT           NULL,
    [d_change]        DATETIME      NOT NULL,
    [password]        VARCHAR (550) NULL
);


GO
PRINT N'Creating [dbo].[hist_change_password_historico]...';


GO
CREATE TABLE [dbo].[hist_change_password_historico] (
    [hist_chg_pwd_id] INT           NOT NULL,
    [user_id]         INT           NOT NULL,
    [phx_user_id]     INT           NULL,
    [d_change]        DATETIME      NOT NULL,
    [password]        VARCHAR (550) NULL,
    [fecha_borrado]   DATETIME      NOT NULL
);


GO
PRINT N'Creating [dbo].[item_lote_chk_win_local_users]...';


GO
CREATE TABLE [dbo].[item_lote_chk_win_local_users] (
    [id]                     INT           IDENTITY (1, 1) NOT NULL,
    [lote]                   INT           NOT NULL,
    [win_local_user]         INT           NOT NULL,
    [fecha_chk]              DATETIME      NULL,
    [chk_ping_nombre_equipo] BIT           NULL,
    [chk_ping_ip_equipo]     BIT           NULL,
    [chk_pwd]                BIT           NULL,
    [nombre_equipo_ping_ip]  VARCHAR (150) NULL,
    [chk_username]           BIT           NULL,
    [accion]                 INT           NULL
);


GO
PRINT N'Creating PK_item_lote_chk_win_local_users...';


GO
ALTER TABLE [dbo].[item_lote_chk_win_local_users]
    ADD CONSTRAINT [PK_item_lote_chk_win_local_users] PRIMARY KEY CLUSTERED ([id] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating [dbo].[Local_Win_Groups]...';


GO
CREATE TABLE [dbo].[Local_Win_Groups] (
    [win_group_id] INT NOT NULL,
    [win_pc_id]    INT NOT NULL
);


GO
PRINT N'Creating PK_Local_Win_Groups...';


GO
ALTER TABLE [dbo].[Local_Win_Groups]
    ADD CONSTRAINT [PK_Local_Win_Groups] PRIMARY KEY CLUSTERED ([win_group_id] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating [dbo].[lote_chk_win_local_users]...';


GO
CREATE TABLE [dbo].[lote_chk_win_local_users] (
    [id]                   INT      IDENTITY (1, 1) NOT NULL,
    [fecha_programada]     DATETIME NOT NULL,
    [fecha_creacion]       DATETIME NOT NULL,
    [fecha_inicio_proceso] DATETIME NULL,
    [fecha_fin_proceso]    DATETIME NULL
);


GO
PRINT N'Creating PK_lote_chk_win_local_users...';


GO
ALTER TABLE [dbo].[lote_chk_win_local_users]
    ADD CONSTRAINT [PK_lote_chk_win_local_users] PRIMARY KEY CLUSTERED ([id] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating [dbo].[M4_CLASSWORX_EMPLEADOS]...';


GO
CREATE TABLE [dbo].[M4_CLASSWORX_EMPLEADOS] (
    [ID_SOCIEDAD]    VARCHAR (2)  NOT NULL,
    [ID_EMPLEADO]    VARCHAR (10) NOT NULL,
    [NOMBRE]         VARCHAR (25) NOT NULL,
    [APELLIDO]       VARCHAR (30) NOT NULL,
    [ID_TIPO_DOC]    VARCHAR (50) NOT NULL,
    [TIPO_DOC]       VARCHAR (40) NOT NULL,
    [NUM_DOCUMENTO]  VARCHAR (10) NOT NULL,
    [CALLE]          VARCHAR (30) NOT NULL,
    [NUM_CALLE]      VARCHAR (5)  NULL,
    [PISO]           VARCHAR (10) NULL,
    [DEPARTAMENTO]   VARCHAR (10) NULL,
    [N_ESTADO_CIVIL] VARCHAR (50) NULL,
    [FEC_NACIMIENTO] DATETIME     NOT NULL,
    [TELEFONO]       VARCHAR (50) NOT NULL,
    [TORRE]          VARCHAR (50) NULL,
    [BLOQUE]         VARCHAR (50) NULL,
    [LOCALIDAD]      VARCHAR (50) NULL
);


GO
PRINT N'Creating [dbo].[M4_CLASSWORX_SOCIEDADES]...';


GO
CREATE TABLE [dbo].[M4_CLASSWORX_SOCIEDADES] (
    [ID_SOCIEDAD] VARCHAR (2)  NOT NULL,
    [N_SOCIEDAD]  VARCHAR (40) NOT NULL
);


GO
PRINT N'Creating [dbo].[M4_CLASSWORX_USUARIOS]...';


GO
CREATE TABLE [dbo].[M4_CLASSWORX_USUARIOS] (
    [ORDINAL]                 INT          IDENTITY (1, 1) NOT NULL,
    [ID_SOCIEDAD]             VARCHAR (2)  NULL,
    [ID_EMPLEADO]             VARCHAR (50) NULL,
    [TIPO_DOC]                VARCHAR (3)  NULL,
    [NUM_DOCUMENTO]           VARCHAR (10) NULL,
    [COD_APLICACION]          VARCHAR (50) NULL,
    [COD_NOVEDAD]             VARCHAR (1)  NULL,
    [DOMINIO_RED]             VARCHAR (30) NULL,
    [ID_USUARIO_RED]          VARCHAR (50) NULL,
    [ID_USUARIO_CORE]         VARCHAR (50) NULL,
    [NOVEDAD_FECHA]           DATETIME     NULL,
    [NOVEDAD_ID_USUARIO]      VARCHAR (40) NULL,
    [ACTUALIZA_M4_FECHA]      DATETIME     NULL,
    [ACTUALIZA_M4_ID_USUARIO] VARCHAR (40) NULL,
    [ACTUALIZA_M4_CODIGO]     VARCHAR (20) NULL
);


GO
PRINT N'Creating [dbo].[mail_alert]...';


GO
CREATE TABLE [dbo].[mail_alert] (
    [mail_alert_id]      INT            IDENTITY (1, 1) NOT NULL,
    [mail_type_id]       INT            NOT NULL,
    [mail_creation_date] DATETIME       NOT NULL,
    [mail_send_date]     DATETIME       NULL,
    [mail_subject]       VARCHAR (100)  NOT NULL,
    [mail_to_name]       VARCHAR (100)  NULL,
    [mail_to_address]    VARCHAR (150)  NOT NULL,
    [mail_cc1_name]      VARCHAR (100)  NULL,
    [mail_cc1_address]   VARCHAR (150)  NULL,
    [mail_cc2_name]      VARCHAR (100)  NULL,
    [mail_cc2_address]   VARCHAR (150)  NULL,
    [mail_cc3_name]      VARCHAR (150)  NULL,
    [mail_cc3_address]   VARCHAR (150)  NULL,
    [mail_cc4_name]      VARCHAR (150)  NULL,
    [mail_cc4_address]   VARCHAR (150)  NULL,
    [mail_cc5_name]      VARCHAR (150)  NULL,
    [mail_cc5_address]   VARCHAR (150)  NULL,
    [mail_cc6_name]      VARCHAR (150)  NULL,
    [mail_cc6_address]   VARCHAR (150)  NULL,
    [mail_cc7_name]      VARCHAR (150)  NULL,
    [mail_cc7_address]   VARCHAR (150)  NULL,
    [mail_cc8_name]      VARCHAR (150)  NULL,
    [mail_cc8_address]   VARCHAR (150)  NULL,
    [mail_cc9_name]      VARCHAR (150)  NULL,
    [mail_cc9_address]   VARCHAR (150)  NULL,
    [mail_cc10_name]     VARCHAR (150)  NULL,
    [mail_cc10_address]  VARCHAR (150)  NULL,
    [mail_cc11_name]     VARCHAR (150)  NULL,
    [mail_cc11_address]  VARCHAR (150)  NULL,
    [mail_cc12_name]     VARCHAR (150)  NULL,
    [mail_cc12_address]  VARCHAR (150)  NULL,
    [mail_body]          VARCHAR (1000) NOT NULL,
    [mail_send_attemp]   INT            NOT NULL
);


GO
PRINT N'Creating PK_mail_alert...';


GO
ALTER TABLE [dbo].[mail_alert]
    ADD CONSTRAINT [PK_mail_alert] PRIMARY KEY CLUSTERED ([mail_alert_id] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating [dbo].[Mail_type]...';


GO
CREATE TABLE [dbo].[Mail_type] (
    [mail_type_id]   INT          NOT NULL,
    [mail_type_name] VARCHAR (50) NOT NULL
);


GO
PRINT N'Creating PK_Mail_type...';


GO
ALTER TABLE [dbo].[Mail_type]
    ADD CONSTRAINT [PK_Mail_type] PRIMARY KEY CLUSTERED ([mail_type_id] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating [dbo].[Passwords_Requests]...';


GO
CREATE TABLE [dbo].[Passwords_Requests] (
    [request_id]       INT NOT NULL,
    [user_password_id] INT NOT NULL
);


GO
PRINT N'Creating PK_Passwords_Requests...';


GO
ALTER TABLE [dbo].[Passwords_Requests]
    ADD CONSTRAINT [PK_Passwords_Requests] PRIMARY KEY CLUSTERED ([request_id] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating [dbo].[phx_config]...';


GO
CREATE TABLE [dbo].[phx_config] (
    [code]            VARCHAR (30)   NOT NULL,
    [description]     VARCHAR (400)  NULL,
    [short_txt_value] VARCHAR (400)  NULL,
    [long_txt_value]  VARCHAR (8000) NULL,
    [name]            VARCHAR (100)  NULL
);


GO
PRINT N'Creating PK_phx_config...';


GO
ALTER TABLE [dbo].[phx_config]
    ADD CONSTRAINT [PK_phx_config] PRIMARY KEY CLUSTERED ([code] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating [dbo].[phx_contingencia]...';


GO
CREATE TABLE [dbo].[phx_contingencia] (
    [phx_cont_id]    INT          IDENTITY (1, 1) NOT NULL,
    [esquema_activo] VARCHAR (50) NOT NULL,
    [fecha]          DATETIME     NOT NULL
);


GO
PRINT N'Creating PK_phx_contingencia...';


GO
ALTER TABLE [dbo].[phx_contingencia]
    ADD CONSTRAINT [PK_phx_contingencia] PRIMARY KEY CLUSTERED ([phx_cont_id] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating [dbo].[Phx_Log]...';


GO
CREATE TABLE [dbo].[Phx_Log] (
    [phx_log_id]    INT           IDENTITY (1, 1) NOT NULL,
    [dbuser]        VARCHAR (50)  COLLATE Latin1_General_CI_AS NOT NULL,
    [creation_date] DATETIME      NOT NULL,
    [Application]   VARCHAR (70)  COLLATE Latin1_General_CI_AS NULL,
    [log_type]      CHAR (1)      COLLATE Latin1_General_CI_AS NOT NULL,
    [Code]          INT           NULL,
    [source]        VARCHAR (200) COLLATE Latin1_General_CI_AS NULL,
    [description]   VARCHAR (500) COLLATE Latin1_General_CI_AS NULL,
    [computer]      VARCHAR (50)  COLLATE Latin1_General_CI_AS NULL
);


GO
PRINT N'Creating PK_Phx_Log...';


GO
ALTER TABLE [dbo].[Phx_Log]
    ADD CONSTRAINT [PK_Phx_Log] PRIMARY KEY CLUSTERED ([phx_log_id] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating [dbo].[phx_privilege]...';


GO
CREATE TABLE [dbo].[phx_privilege] (
    [phx_privilege_id]   INT           IDENTITY (1, 1) NOT NULL,
    [phx_privilege_name] VARCHAR (150) NOT NULL,
    [phx_privilege_code] VARCHAR (50)  NOT NULL,
    [phx_prv_grp_id]     INT           NOT NULL
);


GO
PRINT N'Creating PK_phx_privilege...';


GO
ALTER TABLE [dbo].[phx_privilege]
    ADD CONSTRAINT [PK_phx_privilege] PRIMARY KEY CLUSTERED ([phx_privilege_id] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating [dbo].[phx_privilege_group]...';


GO
CREATE TABLE [dbo].[phx_privilege_group] (
    [phx_prv_grp_id]   INT           NOT NULL,
    [phx_prv_grp_name] VARCHAR (150) NOT NULL
);


GO
PRINT N'Creating PK_phx_privilege_group...';


GO
ALTER TABLE [dbo].[phx_privilege_group]
    ADD CONSTRAINT [PK_phx_privilege_group] PRIMARY KEY CLUSTERED ([phx_prv_grp_id] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating [dbo].[phx_privilege_role]...';


GO
CREATE TABLE [dbo].[phx_privilege_role] (
    [phx_priv_role_id] INT IDENTITY (1, 1) NOT NULL,
    [phx_role_id]      INT NOT NULL,
    [phx_privilege_id] INT NOT NULL
);


GO
PRINT N'Creating PK_phx_privilege_role...';


GO
ALTER TABLE [dbo].[phx_privilege_role]
    ADD CONSTRAINT [PK_phx_privilege_role] PRIMARY KEY CLUSTERED ([phx_priv_role_id] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating [dbo].[Phx_Roles]...';


GO
CREATE TABLE [dbo].[Phx_Roles] (
    [phx_role_id] INT           IDENTITY (1, 1) NOT NULL,
    [role_name]   VARCHAR (200) COLLATE Latin1_General_CI_AS NOT NULL,
    [role_code]   VARCHAR (20)  COLLATE Latin1_General_CI_AS NULL
);


GO
PRINT N'Creating PK_Phx_Roles...';


GO
ALTER TABLE [dbo].[Phx_Roles]
    ADD CONSTRAINT [PK_Phx_Roles] PRIMARY KEY CLUSTERED ([phx_role_id] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating [dbo].[Phx_Roles_Users]...';


GO
CREATE TABLE [dbo].[Phx_Roles_Users] (
    [phx_role_usr_id] INT IDENTITY (1, 1) NOT NULL,
    [phx_role_id]     INT NOT NULL,
    [phx_user_id]     INT NOT NULL
);


GO
PRINT N'Creating PK_Phx_Roles_Users...';


GO
ALTER TABLE [dbo].[Phx_Roles_Users]
    ADD CONSTRAINT [PK_Phx_Roles_Users] PRIMARY KEY CLUSTERED ([phx_role_usr_id] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating Unique_Phx_Roles_Users...';


GO
ALTER TABLE [dbo].[Phx_Roles_Users]
    ADD CONSTRAINT [Unique_Phx_Roles_Users] UNIQUE NONCLUSTERED ([phx_role_id] ASC, [phx_user_id] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY];


GO
PRINT N'Creating [dbo].[Phx_User_Superior]...';


GO
CREATE TABLE [dbo].[Phx_User_Superior] (
    [sup_id]   INT           IDENTITY (1, 1) NOT NULL,
    [sup_name] VARCHAR (100) NOT NULL,
    [sup_mail] VARCHAR (100) NOT NULL
);


GO
PRINT N'Creating PK_Phx_User_Superior...';


GO
ALTER TABLE [dbo].[Phx_User_Superior]
    ADD CONSTRAINT [PK_Phx_User_Superior] PRIMARY KEY CLUSTERED ([sup_id] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating [dbo].[Phx_Users]...';


GO
CREATE TABLE [dbo].[Phx_Users] (
    [phx_user_id]               INT           IDENTITY (1, 1) NOT NULL,
    [username]                  VARCHAR (50)  COLLATE Latin1_General_CI_AS NOT NULL,
    [fullname]                  VARCHAR (100) COLLATE Latin1_General_CI_AS NOT NULL,
    [user_domain]               VARCHAR (50)  COLLATE Latin1_General_CI_AS NULL,
    [user_email]                VARCHAR (150) COLLATE Latin1_General_CI_AS NULL,
    [creation_date]             DATETIME      NULL,
    [delete_date]               DATETIME      NULL,
    [phx_user_file_number]      VARCHAR (10)  COLLATE Latin1_General_CI_AS NULL,
    [phx_user_relation_type]    CHAR (1)      COLLATE Latin1_General_CI_AS NULL,
    [phx_user_branch]           VARCHAR (100) COLLATE Latin1_General_CI_AS NULL,
    [phx_user_function]         VARCHAR (50)  COLLATE Latin1_General_CI_AS NULL,
    [phx_user_building_adress]  VARCHAR (50)  COLLATE Latin1_General_CI_AS NULL,
    [phx_user_building_floor]   VARCHAR (5)   COLLATE Latin1_General_CI_AS NULL,
    [phx_user_extension_number] VARCHAR (4)   COLLATE Latin1_General_CI_AS NULL,
    [active]                    BIT           NOT NULL,
    [sup_id]                    INT           NULL
);


GO
PRINT N'Creating PK_Phx_Users...';


GO
ALTER TABLE [dbo].[Phx_Users]
    ADD CONSTRAINT [PK_Phx_Users] PRIMARY KEY CLUSTERED ([phx_user_id] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating Unique_Phx_Users_Username_Domain...';


GO
ALTER TABLE [dbo].[Phx_Users]
    ADD CONSTRAINT [Unique_Phx_Users_Username_Domain] UNIQUE NONCLUSTERED ([username] ASC, [user_domain] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY];


GO
PRINT N'Creating [dbo].[Phx_Users_Groups]...';


GO
CREATE TABLE [dbo].[Phx_Users_Groups] (
    [phx_usr_grp_id] INT IDENTITY (1, 1) NOT NULL,
    [phx_user_id]    INT NOT NULL,
    [rqst_grp_id]    INT NOT NULL
);


GO
PRINT N'Creating PK_Phx_Users_Groups...';


GO
ALTER TABLE [dbo].[Phx_Users_Groups]
    ADD CONSTRAINT [PK_Phx_Users_Groups] PRIMARY KEY CLUSTERED ([phx_usr_grp_id] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating [dbo].[phx_version]...';


GO
CREATE TABLE [dbo].[phx_version] (
    [phx_version_id]      INT          IDENTITY (1, 1) NOT NULL,
    [version]             VARCHAR (20) NOT NULL,
    [implementation_date] DATETIME     NOT NULL
);


GO
PRINT N'Creating PK_phx_version...';


GO
ALTER TABLE [dbo].[phx_version]
    ADD CONSTRAINT [PK_phx_version] PRIMARY KEY CLUSTERED ([phx_version_id] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating [dbo].[Protocol_Communication_Device]...';


GO
CREATE TABLE [dbo].[Protocol_Communication_Device] (
    [Id]                INT IDENTITY (1, 1) NOT NULL,
    [cm_dv_id]          INT NOT NULL,
    [cm_dv_protocol_id] INT NOT NULL
);


GO
PRINT N'Creating PK_Protocol_Communication_Device...';


GO
ALTER TABLE [dbo].[Protocol_Communication_Device]
    ADD CONSTRAINT [PK_Protocol_Communication_Device] PRIMARY KEY CLUSTERED ([Id] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating [dbo].[Pwd_Lock_types]...';


GO
CREATE TABLE [dbo].[Pwd_Lock_types] (
    [pwd_lock_type_id]   INT           IDENTITY (1, 1) NOT NULL,
    [pwd_lock_type_code] VARCHAR (50)  COLLATE Latin1_General_CI_AS NOT NULL,
    [pwd_lock_type_desc] VARCHAR (150) COLLATE Latin1_General_CI_AS NULL
);


GO
PRINT N'Creating PK_Pwd_Lock_types...';


GO
ALTER TABLE [dbo].[Pwd_Lock_types]
    ADD CONSTRAINT [PK_Pwd_Lock_types] PRIMARY KEY CLUSTERED ([pwd_lock_type_id] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating Unique_Pwd_Lock_type_codes...';


GO
ALTER TABLE [dbo].[Pwd_Lock_types]
    ADD CONSTRAINT [Unique_Pwd_Lock_type_codes] UNIQUE NONCLUSTERED ([pwd_lock_type_code] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY];


GO
PRINT N'Creating [dbo].[Request_States]...';


GO
CREATE TABLE [dbo].[Request_States] (
    [rqst_state_id]   INT           NOT NULL,
    [rqst_state_desc] VARCHAR (100) COLLATE Latin1_General_CI_AS NOT NULL
);


GO
PRINT N'Creating PK_Request_States...';


GO
ALTER TABLE [dbo].[Request_States]
    ADD CONSTRAINT [PK_Request_States] PRIMARY KEY CLUSTERED ([rqst_state_id] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating [dbo].[Requests]...';


GO
CREATE TABLE [dbo].[Requests] (
    [request_id]              INT           IDENTITY (1, 1) NOT NULL,
    [rqst_user_id]            INT           NOT NULL,
    [request_date]            DATETIME      NOT NULL,
    [auth1_usr_id]            INT           NULL,
    [auth1_date]              DATETIME      NULL,
    [auth2_usr_id]            INT           NULL,
    [auth2_date]              DATETIME      NULL,
    [rqst_state_id]           INT           NOT NULL,
    [hours_requested]         INT           NULL,
    [unit_requested]          VARCHAR (1)   COLLATE Latin1_General_CI_AS NULL,
    [hours_given]             INT           NULL,
    [unit_given]              VARCHAR (1)   COLLATE Latin1_General_CI_AS NULL,
    [request_desc]            VARCHAR (500) COLLATE Latin1_General_CI_AS NULL,
    [auth_desc]               VARCHAR (500) COLLATE Latin1_General_CI_AS NULL,
    [expiration_date]         DATETIME      NULL,
    [return_date]             DATETIME      NULL,
    [return_note]             VARCHAR (200) COLLATE Latin1_General_CI_AS NULL,
    [return_usr_id]           INT           NULL,
    [close_date]              DATETIME      NULL,
    [close_note]              VARCHAR (200) COLLATE Latin1_General_CI_AS NULL,
    [close_usr_id]            INT           NULL,
    [expirada_sin_visualizar] BIT           NOT NULL
);


GO
PRINT N'Creating PK_Password_Queries...';


GO
ALTER TABLE [dbo].[Requests]
    ADD CONSTRAINT [PK_Password_Queries] PRIMARY KEY CLUSTERED ([request_id] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating [dbo].[Requests_Groups]...';


GO
CREATE TABLE [dbo].[Requests_Groups] (
    [rqst_grp_id]     INT          IDENTITY (1, 1) NOT NULL,
    [rqst_grp_name]   VARCHAR (50) COLLATE Latin1_General_CI_AS NOT NULL,
    [rqst_grp_active] BIT          NOT NULL
);


GO
PRINT N'Creating PK_Qry_Groups...';


GO
ALTER TABLE [dbo].[Requests_Groups]
    ADD CONSTRAINT [PK_Qry_Groups] PRIMARY KEY CLUSTERED ([rqst_grp_id] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating [dbo].[Requests_Notes]...';


GO
CREATE TABLE [dbo].[Requests_Notes] (
    [request_note_id]      INT           IDENTITY (1, 1) NOT NULL,
    [request_id]           INT           NOT NULL,
    [phx_user_id]          INT           NOT NULL,
    [request_note_date]    DATETIME      NOT NULL,
    [request_note_descrip] VARCHAR (200) COLLATE Latin1_General_CI_AS NOT NULL
);


GO
PRINT N'Creating PK_Requests_Notes...';


GO
ALTER TABLE [dbo].[Requests_Notes]
    ADD CONSTRAINT [PK_Requests_Notes] PRIMARY KEY CLUSTERED ([request_note_id] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating [dbo].[Rqst_Grps_Deleg]...';


GO
CREATE TABLE [dbo].[Rqst_Grps_Deleg] (
    [delrqst_grp_delg_id] INT IDENTITY (1, 1) NOT NULL,
    [rqst_grp_id]         INT NOT NULL,
    [win_group_id]        INT NOT NULL,
    [auth1_usr_id]        INT NULL,
    [auth2_usr_id]        INT NULL
);


GO
PRINT N'Creating PK_Rqst_Grps_Deleg...';


GO
ALTER TABLE [dbo].[Rqst_Grps_Deleg]
    ADD CONSTRAINT [PK_Rqst_Grps_Deleg] PRIMARY KEY CLUSTERED ([delrqst_grp_delg_id] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating [dbo].[Rqst_Grps_Pwds]...';


GO
CREATE TABLE [dbo].[Rqst_Grps_Pwds] (
    [pwdrqst_grp_pwd_id] INT IDENTITY (1, 1) NOT NULL,
    [rqst_grp_id]        INT NOT NULL,
    [user_password_id]   INT NOT NULL,
    [auth1_usr_id]       INT NULL,
    [auth2_usr_id]       INT NULL
);


GO
PRINT N'Creating PK_Qry_Grps_Pwds...';


GO
ALTER TABLE [dbo].[Rqst_Grps_Pwds]
    ADD CONSTRAINT [PK_Qry_Grps_Pwds] PRIMARY KEY CLUSTERED ([pwdrqst_grp_pwd_id] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating [dbo].[Subsidiaria]...';


GO
CREATE TABLE [dbo].[Subsidiaria] (
    [id]       INT          IDENTITY (1, 1) NOT NULL,
    [codigo]   VARCHAR (10) NOT NULL,
    [nombre]   VARCHAR (40) NOT NULL,
    [email_01] VARCHAR (50) NULL,
    [email_02] VARCHAR (50) NULL
);


GO
PRINT N'Creating [dbo].[ticket_notificacion_clave]...';


GO
CREATE TABLE [dbo].[ticket_notificacion_clave] (
    [tnc_id]                INT           IDENTITY (1, 1) NOT NULL,
    [tnc_numero]            INT           NOT NULL,
    [tnc_app_id]            INT           NOT NULL,
    [tnc_app_user]          VARCHAR (50)  NOT NULL,
    [tnc_app_user_pass]     VARCHAR (50)  NULL,
    [tnc_user_domain]       VARCHAR (50)  NOT NULL,
    [tnc_user]              VARCHAR (50)  NOT NULL,
    [tnc_legajo]            VARCHAR (50)  NULL,
    [tnc_tipo_doc]          VARCHAR (50)  NOT NULL,
    [tnc_nro_doc]           VARCHAR (50)  NOT NULL,
    [tnc_is_dom_pass]       TINYINT       NOT NULL,
    [tnc_fecha]             DATETIME      NOT NULL,
    [tnc_fecha_ace_tyc]     DATETIME      NULL,
    [tnc_errado]            TINYINT       NOT NULL,
    [tnc_fecha_procesado]   DATETIME      NULL,
    [tnc_num_sol_alta]      INT           NULL,
    [tnc_num_leg_solicitud] VARCHAR (10)  NULL,
    [tnc_nomb_emp_sol]      VARCHAR (255) NULL,
    [tnc_ape_emp_sol]       VARCHAR (255) NULL,
    [tnc_fecha_vigencia]    DATETIME      NULL,
    [tnc_codigo_gerencia]   VARCHAR (3)   NULL,
    [tnc_nombre_gerencia]   VARCHAR (40)  NULL,
    [tnc_sigla_area]        VARCHAR (10)  NULL,
    [tnc_desc_area]         VARCHAR (40)  NULL,
    [tnc_cod_emp_sub]       VARCHAR (10)  NULL,
    [tnc_nomb_emp_sub]      VARCHAR (40)  NULL,
    [m_tnc_corregido]       TINYINT       NOT NULL,
    [tnc_token]             VARCHAR (40)  NULL,
    [tnc_mail_id]           INT           NULL,
    [tnc_att_fecha]         DATETIME      NULL,
    [tnc_att_terminal]      VARCHAR (50)  NULL,
    [tnc_att_usuario]       VARCHAR (100) NULL
);


GO
PRINT N'Creating PK_ticket_notificacion_clave...';


GO
ALTER TABLE [dbo].[ticket_notificacion_clave]
    ADD CONSTRAINT [PK_ticket_notificacion_clave] PRIMARY KEY CLUSTERED ([tnc_id] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating [dbo].[Unix]...';


GO
CREATE TABLE [dbo].[Unix] (
    [unx_id]          INT           IDENTITY (1, 1) NOT NULL,
    [unx_server_name] VARCHAR (100) COLLATE Latin1_General_CI_AS NOT NULL,
    [unx_server_ip1]  TINYINT       NULL,
    [unx_server_ip2]  TINYINT       NULL,
    [unx_server_ip3]  TINYINT       NULL,
    [unx_server_ip4]  TINYINT       NULL,
    [unx_desc]        VARCHAR (200) COLLATE Latin1_General_CI_AS NULL,
    [unx_ip]          VARCHAR (15)  COLLATE Latin1_General_CI_AS NULL,
    [active]          BIT           NOT NULL
);


GO
PRINT N'Creating PK_Unix...';


GO
ALTER TABLE [dbo].[Unix]
    ADD CONSTRAINT [PK_Unix] PRIMARY KEY CLUSTERED ([unx_id] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating [dbo].[Unix_users]...';


GO
CREATE TABLE [dbo].[Unix_users] (
    [user_id] INT NOT NULL,
    [unx_id]  INT NOT NULL
);


GO
PRINT N'Creating PK_Unix_users...';


GO
ALTER TABLE [dbo].[Unix_users]
    ADD CONSTRAINT [PK_Unix_users] PRIMARY KEY CLUSTERED ([user_id] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating [dbo].[User_Types]...';


GO
CREATE TABLE [dbo].[User_Types] (
    [user_type_id]   INT          NOT NULL,
    [user_type_desc] VARCHAR (50) COLLATE Latin1_General_CI_AS NOT NULL
);


GO
PRINT N'Creating PK_User_Types...';


GO
ALTER TABLE [dbo].[User_Types]
    ADD CONSTRAINT [PK_User_Types] PRIMARY KEY CLUSTERED ([user_type_id] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating [dbo].[Users]...';


GO
CREATE TABLE [dbo].[Users] (
    [user_id]          INT           IDENTITY (1, 1) NOT NULL,
    [username]         VARCHAR (50)  COLLATE Latin1_General_CI_AS NOT NULL,
    [active_user]      BIT           NULL,
    [user_type_id]     INT           NULL,
    [user_password_id] INT           NULL,
    [user_desc]        VARCHAR (100) COLLATE Latin1_General_CI_AS NULL,
    [user_critical]    BIT           NULL,
    [modifying_date]   DATETIME      NULL,
    [modifying_user]   INT           NULL
);


GO
PRINT N'Creating PK_Users...';


GO
ALTER TABLE [dbo].[Users]
    ADD CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([user_id] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating [dbo].[Users_Passwords]...';


GO
CREATE TABLE [dbo].[Users_Passwords] (
    [user_password_id] INT           IDENTITY (1, 1) NOT NULL,
    [password]         VARCHAR (550) COLLATE Latin1_General_CI_AS NULL,
    [static_pwd]       BIT           NOT NULL,
    [d_next_change]    DATETIME      NULL,
    [d_last_change]    DATETIME      NULL,
    [change_freq]      NUMERIC (3)   NULL,
    [change_freq_unit] CHAR (1)      COLLATE Latin1_General_CI_AS NULL,
    [d_next_chk]       DATETIME      NULL,
    [d_last_chk]       DATETIME      NULL,
    [chk_freq]         NUMERIC (3)   NULL,
    [chk_freq_unit]    CHAR (1)      COLLATE Latin1_General_CI_AS NULL,
    [pwd_lock_type_id] INT           NULL,
    [chk_pwd]          BIT           NOT NULL,
    [d_lock_pwd]       DATETIME      NULL,
    [d_in_use_until]   DATETIME      NULL,
    [concurrent]       BIT           NOT NULL,
    [checkeable]       BIT           NOT NULL
);


GO
PRINT N'Creating PK_Users_Passwords...';


GO
ALTER TABLE [dbo].[Users_Passwords]
    ADD CONSTRAINT [PK_Users_Passwords] PRIMARY KEY CLUSTERED ([user_password_id] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating [dbo].[Win_Domain_Controllers]...';


GO
CREATE TABLE [dbo].[Win_Domain_Controllers] (
    [win_dc_id]           INT      IDENTITY (1, 1) NOT NULL,
    [win_domain_id]       INT      NOT NULL,
    [dc_type]             CHAR (1) COLLATE Latin1_General_CI_AS NOT NULL,
    [win_pc_id]           INT      NOT NULL,
    [impersonate_user_id] INT      NULL
);


GO
PRINT N'Creating PK_Win_Domain_Controllers...';


GO
ALTER TABLE [dbo].[Win_Domain_Controllers]
    ADD CONSTRAINT [PK_Win_Domain_Controllers] PRIMARY KEY CLUSTERED ([win_dc_id] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating [dbo].[Win_Domain_Users]...';


GO
CREATE TABLE [dbo].[Win_Domain_Users] (
    [user_id]        INT NOT NULL,
    [win_domain_id]  INT NULL,
    [user_domain_id] INT NULL
);


GO
PRINT N'Creating PK_Win_Domain_Users...';


GO
ALTER TABLE [dbo].[Win_Domain_Users]
    ADD CONSTRAINT [PK_Win_Domain_Users] PRIMARY KEY CLUSTERED ([user_id] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating [dbo].[Win_Domains]...';


GO
CREATE TABLE [dbo].[Win_Domains] (
    [win_domain_id] INT           IDENTITY (1, 1) NOT NULL,
    [nt_name]       VARCHAR (50)  COLLATE Latin1_General_CI_AS NOT NULL,
    [ad_name]       VARCHAR (100) COLLATE Latin1_General_CI_AS NULL,
    [Comments]      VARCHAR (255) COLLATE Latin1_General_CI_AS NULL
);


GO
PRINT N'Creating PK_Win_Domains...';


GO
ALTER TABLE [dbo].[Win_Domains]
    ADD CONSTRAINT [PK_Win_Domains] PRIMARY KEY CLUSTERED ([win_domain_id] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating IX_Win_Domains_unique_nt_name...';


GO
ALTER TABLE [dbo].[Win_Domains]
    ADD CONSTRAINT [IX_Win_Domains_unique_nt_name] UNIQUE NONCLUSTERED ([nt_name] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY];


GO
PRINT N'Creating [dbo].[Win_Groups]...';


GO
CREATE TABLE [dbo].[Win_Groups] (
    [win_group_id]  INT          IDENTITY (1, 1) NOT NULL,
    [ad_group_name] VARCHAR (64) COLLATE Latin1_General_CI_AS NULL,
    [nt_group_name] VARCHAR (40) COLLATE Latin1_General_CI_AS NULL
);


GO
PRINT N'Creating PK_Groups...';


GO
ALTER TABLE [dbo].[Win_Groups]
    ADD CONSTRAINT [PK_Groups] PRIMARY KEY CLUSTERED ([win_group_id] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating [dbo].[Win_Local_Users]...';


GO
CREATE TABLE [dbo].[Win_Local_Users] (
    [user_id]   INT NOT NULL,
    [win_pc_id] INT NULL
);


GO
PRINT N'Creating PK_Win_Local_Users...';


GO
ALTER TABLE [dbo].[Win_Local_Users]
    ADD CONSTRAINT [PK_Win_Local_Users] PRIMARY KEY CLUSTERED ([user_id] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating [dbo].[Win_PCs]...';


GO
CREATE TABLE [dbo].[Win_PCs] (
    [win_pc_id]     INT           IDENTITY (1, 1) NOT NULL,
    [pc_name]       VARCHAR (50)  COLLATE Latin1_General_CI_AS NULL,
    [win_domain_id] INT           NULL,
    [pc_ip]         VARCHAR (15)  COLLATE Latin1_General_CI_AS NULL,
    [pc_desc]       VARCHAR (200) NULL,
    [active]        BIT           NOT NULL,
    [checkable]     BIT           NOT NULL
);


GO
PRINT N'Creating PK_Win_PCs...';


GO
ALTER TABLE [dbo].[Win_PCs]
    ADD CONSTRAINT [PK_Win_PCs] PRIMARY KEY CLUSTERED ([win_pc_id] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating On column: anc_notificable...';


GO
ALTER TABLE [dbo].[aplicacion_notificacion_clave]
    ADD DEFAULT ((1)) FOR [anc_notificable];


GO
PRINT N'Creating DF_Applications_active...';


GO
ALTER TABLE [dbo].[Applications]
    ADD CONSTRAINT [DF_Applications_active] DEFAULT (1) FOR [active];


GO
PRINT N'Creating DF_Applications_desactiva_pwd_cierre...';


GO
ALTER TABLE [dbo].[Applications]
    ADD CONSTRAINT [DF_Applications_desactiva_pwd_cierre] DEFAULT ((0)) FOR [desactiva_pwd_cierre];


GO
PRINT N'Creating DF_AS400_active...';


GO
ALTER TABLE [dbo].[AS400]
    ADD CONSTRAINT [DF_AS400_active] DEFAULT (1) FOR [active];


GO
PRINT N'Creating DF_audit_login_app_id...';


GO
ALTER TABLE [dbo].[audit_login]
    ADD CONSTRAINT [DF_audit_login_app_id] DEFAULT ((1)) FOR [app_id];


GO
PRINT N'Creating DF_audit_login_fecha...';


GO
ALTER TABLE [dbo].[audit_login]
    ADD CONSTRAINT [DF_audit_login_fecha] DEFAULT (getdate()) FOR [fecha];


GO
PRINT N'Creating DF_audit_login_historico_app_id...';


GO
ALTER TABLE [dbo].[audit_login_historico]
    ADD CONSTRAINT [DF_audit_login_historico_app_id] DEFAULT ((1)) FOR [app_id];


GO
PRINT N'Creating DF_audit_login_historico_fecha...';


GO
ALTER TABLE [dbo].[audit_login_historico]
    ADD CONSTRAINT [DF_audit_login_historico_fecha] DEFAULT (getdate()) FOR [fecha];


GO
PRINT N'Creating DF_audit_permisos_fecha...';


GO
ALTER TABLE [dbo].[audit_permisos]
    ADD CONSTRAINT [DF_audit_permisos_fecha] DEFAULT (getdate()) FOR [fecha];


GO
PRINT N'Creating DF_audit_phx_privilege_role_fecha...';


GO
ALTER TABLE [dbo].[audit_phx_privilege_role]
    ADD CONSTRAINT [DF_audit_phx_privilege_role_fecha] DEFAULT (getdate()) FOR [fecha];


GO
PRINT N'Creating DF_audit_phx_role_fecha...';


GO
ALTER TABLE [dbo].[audit_phx_role]
    ADD CONSTRAINT [DF_audit_phx_role_fecha] DEFAULT (getdate()) FOR [fecha];


GO
PRINT N'Creating DF_audit_ticket_notificacion_atn_fecha...';


GO
ALTER TABLE [dbo].[audit_ticket_notificacion]
    ADD CONSTRAINT [DF_audit_ticket_notificacion_atn_fecha] DEFAULT (getdate()) FOR [atn_fecha];


GO
PRINT N'Creating DF_audit_usuarios_fecha...';


GO
ALTER TABLE [dbo].[audit_usuarios]
    ADD CONSTRAINT [DF_audit_usuarios_fecha] DEFAULT (getdate()) FOR [fecha];


GO
PRINT N'Creating DF_Data_Bases_active...';


GO
ALTER TABLE [dbo].[Data_Bases]
    ADD CONSTRAINT [DF_Data_Bases_active] DEFAULT (1) FOR [active];


GO
PRINT N'Creating DF_followup_request_group_frg_active...';


GO
ALTER TABLE [dbo].[followup_request_group]
    ADD CONSTRAINT [DF_followup_request_group_frg_active] DEFAULT ((1)) FOR [frg_active];


GO
PRINT N'Creating DF_lote_chk_win_local_users_fecha_creacion...';


GO
ALTER TABLE [dbo].[lote_chk_win_local_users]
    ADD CONSTRAINT [DF_lote_chk_win_local_users_fecha_creacion] DEFAULT (getdate()) FOR [fecha_creacion];


GO
PRINT N'Creating DF_M4_CLASSWORX_EMPLEADOS_ID_TIPO_DOC...';


GO
ALTER TABLE [dbo].[M4_CLASSWORX_EMPLEADOS]
    ADD CONSTRAINT [DF_M4_CLASSWORX_EMPLEADOS_ID_TIPO_DOC] DEFAULT ('1') FOR [ID_TIPO_DOC];


GO
PRINT N'Creating DF_mail_alert_mai_send_attemp...';


GO
ALTER TABLE [dbo].[mail_alert]
    ADD CONSTRAINT [DF_mail_alert_mai_send_attemp] DEFAULT ((0)) FOR [mail_send_attemp];


GO
PRINT N'Creating DF_mail_alert_mail_creation_date...';


GO
ALTER TABLE [dbo].[mail_alert]
    ADD CONSTRAINT [DF_mail_alert_mail_creation_date] DEFAULT (getdate()) FOR [mail_creation_date];


GO
PRINT N'Creating DF_phx_contingencia_fecha...';


GO
ALTER TABLE [dbo].[phx_contingencia]
    ADD CONSTRAINT [DF_phx_contingencia_fecha] DEFAULT (getdate()) FOR [fecha];


GO
PRINT N'Creating DF__Phx_Log__creatio__1D7B6025...';


GO
ALTER TABLE [dbo].[Phx_Log]
    ADD CONSTRAINT [DF__Phx_Log__creatio__1D7B6025] DEFAULT (getdate()) FOR [creation_date];


GO
PRINT N'Creating DF__Phx_Log__dbuser__1C873BEC...';


GO
ALTER TABLE [dbo].[Phx_Log]
    ADD CONSTRAINT [DF__Phx_Log__dbuser__1C873BEC] DEFAULT (user_name()) FOR [dbuser];


GO
PRINT N'Creating DF_Phx_Users_active...';


GO
ALTER TABLE [dbo].[Phx_Users]
    ADD CONSTRAINT [DF_Phx_Users_active] DEFAULT (1) FOR [active];


GO
PRINT N'Creating DF_Phx_Users_creation_date...';


GO
ALTER TABLE [dbo].[Phx_Users]
    ADD CONSTRAINT [DF_Phx_Users_creation_date] DEFAULT (getdate()) FOR [creation_date];


GO
PRINT N'Creating DF_phx_version_implementation_date...';


GO
ALTER TABLE [dbo].[phx_version]
    ADD CONSTRAINT [DF_phx_version_implementation_date] DEFAULT (getdate()) FOR [implementation_date];


GO
PRINT N'Creating DF_Requests_expirada_sin_visualizar...';


GO
ALTER TABLE [dbo].[Requests]
    ADD CONSTRAINT [DF_Requests_expirada_sin_visualizar] DEFAULT ((0)) FOR [expirada_sin_visualizar];


GO
PRINT N'Creating DF_Requests_Groups_active_user...';


GO
ALTER TABLE [dbo].[Requests_Groups]
    ADD CONSTRAINT [DF_Requests_Groups_active_user] DEFAULT ((1)) FOR [rqst_grp_active];


GO
PRINT N'Creating On column: m_tnc_corregido...';


GO
ALTER TABLE [dbo].[ticket_notificacion_clave]
    ADD DEFAULT ((0)) FOR [m_tnc_corregido];


GO
PRINT N'Creating DF_ticket_notificacion_clave...';


GO
ALTER TABLE [dbo].[ticket_notificacion_clave]
    ADD CONSTRAINT [DF_ticket_notificacion_clave] DEFAULT (getdate()) FOR [tnc_fecha];


GO
PRINT N'Creating DF_ticket_notificacion_clave_errado...';


GO
ALTER TABLE [dbo].[ticket_notificacion_clave]
    ADD CONSTRAINT [DF_ticket_notificacion_clave_errado] DEFAULT ((0)) FOR [tnc_errado];


GO
PRINT N'Creating DF_Unix_active...';


GO
ALTER TABLE [dbo].[Unix]
    ADD CONSTRAINT [DF_Unix_active] DEFAULT (1) FOR [active];


GO
PRINT N'Creating DF_Users_user_critical...';


GO
ALTER TABLE [dbo].[Users]
    ADD CONSTRAINT [DF_Users_user_critical] DEFAULT (0) FOR [user_critical];


GO
PRINT N'Creating DF__Users_Pas__stati__160F4887...';


GO
ALTER TABLE [dbo].[Users_Passwords]
    ADD CONSTRAINT [DF__Users_Pas__stati__160F4887] DEFAULT (0) FOR [static_pwd];


GO
PRINT N'Creating DF_Users_Passwords_checkeable...';


GO
ALTER TABLE [dbo].[Users_Passwords]
    ADD CONSTRAINT [DF_Users_Passwords_checkeable] DEFAULT ((1)) FOR [checkeable];


GO
PRINT N'Creating DF_Users_Passwords_chk_pwd...';


GO
ALTER TABLE [dbo].[Users_Passwords]
    ADD CONSTRAINT [DF_Users_Passwords_chk_pwd] DEFAULT (0) FOR [chk_pwd];


GO
PRINT N'Creating DF_Users_Passwords_concurrent...';


GO
ALTER TABLE [dbo].[Users_Passwords]
    ADD CONSTRAINT [DF_Users_Passwords_concurrent] DEFAULT (0) FOR [concurrent];


GO
PRINT N'Creating DF_Win_PCs_active...';


GO
ALTER TABLE [dbo].[Win_PCs]
    ADD CONSTRAINT [DF_Win_PCs_active] DEFAULT (1) FOR [active];


GO
PRINT N'Creating DF_Win_PCs_checkable...';


GO
ALTER TABLE [dbo].[Win_PCs]
    ADD CONSTRAINT [DF_Win_PCs_checkable] DEFAULT ((1)) FOR [checkable];


GO
PRINT N'Creating FK_Applications_Users_Applications...';


GO
ALTER TABLE [dbo].[Applications_Users] WITH NOCHECK
    ADD CONSTRAINT [FK_Applications_Users_Applications] FOREIGN KEY ([app_id]) REFERENCES [dbo].[Applications] ([app_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_Applications_Users_Users...';


GO
ALTER TABLE [dbo].[Applications_Users] WITH NOCHECK
    ADD CONSTRAINT [FK_Applications_Users_Users] FOREIGN KEY ([user_id]) REFERENCES [dbo].[Users] ([user_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_AS400_users_AS400...';


GO
ALTER TABLE [dbo].[AS400_users] WITH NOCHECK
    ADD CONSTRAINT [FK_AS400_users_AS400] FOREIGN KEY ([as_id]) REFERENCES [dbo].[AS400] ([as_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_AS400_users_Users...';


GO
ALTER TABLE [dbo].[AS400_users] WITH NOCHECK
    ADD CONSTRAINT [FK_AS400_users_Users] FOREIGN KEY ([user_id]) REFERENCES [dbo].[Users] ([user_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_ATMs_Users_Users...';


GO
ALTER TABLE [dbo].[ATMs_Users] WITH NOCHECK
    ADD CONSTRAINT [FK_ATMs_Users_Users] FOREIGN KEY ([user_id]) REFERENCES [dbo].[Users] ([user_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_audit_login_audit_application...';


GO
ALTER TABLE [dbo].[audit_login] WITH NOCHECK
    ADD CONSTRAINT [FK_audit_login_audit_application] FOREIGN KEY ([app_id]) REFERENCES [dbo].[audit_application] ([aa_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_audit_login_evento_login...';


GO
ALTER TABLE [dbo].[audit_login] WITH NOCHECK
    ADD CONSTRAINT [FK_audit_login_evento_login] FOREIGN KEY ([evento_login_id]) REFERENCES [dbo].[evento_login] ([evento_login_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_audit_login_historico_audit_application...';


GO
ALTER TABLE [dbo].[audit_login_historico] WITH NOCHECK
    ADD CONSTRAINT [FK_audit_login_historico_audit_application] FOREIGN KEY ([app_id]) REFERENCES [dbo].[audit_application] ([aa_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_audit_login_historico_evento_login...';


GO
ALTER TABLE [dbo].[audit_login_historico] WITH NOCHECK
    ADD CONSTRAINT [FK_audit_login_historico_evento_login] FOREIGN KEY ([evento_login_id]) REFERENCES [dbo].[evento_login] ([evento_login_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_audit_usuarios_audit_phx_user_new...';


GO
ALTER TABLE [dbo].[audit_usuarios] WITH NOCHECK
    ADD CONSTRAINT [FK_audit_usuarios_audit_phx_user_new] FOREIGN KEY ([audit_phx_user_id_old]) REFERENCES [dbo].[audit_phx_user] ([audit_phx_user_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_audit_usuarios_audit_phx_user_old...';


GO
ALTER TABLE [dbo].[audit_usuarios] WITH NOCHECK
    ADD CONSTRAINT [FK_audit_usuarios_audit_phx_user_old] FOREIGN KEY ([audit_phx_user_id_new]) REFERENCES [dbo].[audit_phx_user] ([audit_phx_user_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_Communication_Device_User_Protocol_Communication_Device_Protocols...';


GO
ALTER TABLE [dbo].[Communication_Device_User_Protocol] WITH NOCHECK
    ADD CONSTRAINT [FK_Communication_Device_User_Protocol_Communication_Device_Protocols] FOREIGN KEY ([cm_dv_protocol_id]) REFERENCES [dbo].[Communication_Device_Protocols] ([cm_dv_protocol_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_Communication_Device_User_Protocol_Communication_Device_Users...';


GO
ALTER TABLE [dbo].[Communication_Device_User_Protocol] WITH NOCHECK
    ADD CONSTRAINT [FK_Communication_Device_User_Protocol_Communication_Device_Users] FOREIGN KEY ([cm_dv_user_id]) REFERENCES [dbo].[Communication_Device_Users] ([user_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_Communication_Device_Users_Communication_Devices...';


GO
ALTER TABLE [dbo].[Communication_Device_Users] WITH NOCHECK
    ADD CONSTRAINT [FK_Communication_Device_Users_Communication_Devices] FOREIGN KEY ([cm_dv_id]) REFERENCES [dbo].[Communication_Devices] ([cm_dv_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_Communication_Device_Users_Users...';


GO
ALTER TABLE [dbo].[Communication_Device_Users] WITH NOCHECK
    ADD CONSTRAINT [FK_Communication_Device_Users_Users] FOREIGN KEY ([user_id]) REFERENCES [dbo].[Users] ([user_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_Communication_Devices_Communication_Device_Types...';


GO
ALTER TABLE [dbo].[Communication_Devices] WITH NOCHECK
    ADD CONSTRAINT [FK_Communication_Devices_Communication_Device_Types] FOREIGN KEY ([cm_dv_type_id]) REFERENCES [dbo].[Communication_Device_Types] ([cm_dv_type_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_Data_Bases_DataBase_Types...';


GO
ALTER TABLE [dbo].[Data_Bases] WITH NOCHECK
    ADD CONSTRAINT [FK_Data_Bases_DataBase_Types] FOREIGN KEY ([db_type_id]) REFERENCES [dbo].[Database_Types] ([db_type_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_Data_Bases_Unix...';


GO
ALTER TABLE [dbo].[Data_Bases] WITH NOCHECK
    ADD CONSTRAINT [FK_Data_Bases_Unix] FOREIGN KEY ([unx_id]) REFERENCES [dbo].[Unix] ([unx_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_Data_Bases_Win_PCs...';


GO
ALTER TABLE [dbo].[Data_Bases] WITH NOCHECK
    ADD CONSTRAINT [FK_Data_Bases_Win_PCs] FOREIGN KEY ([win_pc_id]) REFERENCES [dbo].[Win_PCs] ([win_pc_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_Databases_Users_Data_Bases...';


GO
ALTER TABLE [dbo].[Databases_Users] WITH NOCHECK
    ADD CONSTRAINT [FK_Databases_Users_Data_Bases] FOREIGN KEY ([db_id]) REFERENCES [dbo].[Data_Bases] ([db_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_Databases_Users_Users...';


GO
ALTER TABLE [dbo].[Databases_Users] WITH NOCHECK
    ADD CONSTRAINT [FK_Databases_Users_Users] FOREIGN KEY ([user_id]) REFERENCES [dbo].[Users] ([user_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_Delegation_Requests_Requests...';


GO
ALTER TABLE [dbo].[Delegation_Requests] WITH NOCHECK
    ADD CONSTRAINT [FK_Delegation_Requests_Requests] FOREIGN KEY ([request_id]) REFERENCES [dbo].[Requests] ([request_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_Delegation_Requests_Win_Groups...';


GO
ALTER TABLE [dbo].[Delegation_Requests] WITH NOCHECK
    ADD CONSTRAINT [FK_Delegation_Requests_Win_Groups] FOREIGN KEY ([win_group_id]) REFERENCES [dbo].[Win_Groups] ([win_group_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_Devices_Devices_types...';


GO
ALTER TABLE [dbo].[Devices] WITH NOCHECK
    ADD CONSTRAINT [FK_Devices_Devices_types] FOREIGN KEY ([dv_type_id]) REFERENCES [dbo].[Devices_types] ([dv_type_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_Devices_users_Devices...';


GO
ALTER TABLE [dbo].[Devices_users] WITH NOCHECK
    ADD CONSTRAINT [FK_Devices_users_Devices] FOREIGN KEY ([dv_id]) REFERENCES [dbo].[Devices] ([dv_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_Devices_users_Users...';


GO
ALTER TABLE [dbo].[Devices_users] WITH NOCHECK
    ADD CONSTRAINT [FK_Devices_users_Users] FOREIGN KEY ([user_id]) REFERENCES [dbo].[Users] ([user_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_followup_request_group_default_followup_request_group...';


GO
ALTER TABLE [dbo].[followup_request_group_default] WITH NOCHECK
    ADD CONSTRAINT [FK_followup_request_group_default_followup_request_group] FOREIGN KEY ([frg_id]) REFERENCES [dbo].[followup_request_group] ([frg_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_followup_request_group_default_User_Types...';


GO
ALTER TABLE [dbo].[followup_request_group_default] WITH NOCHECK
    ADD CONSTRAINT [FK_followup_request_group_default_User_Types] FOREIGN KEY ([user_type_id]) REFERENCES [dbo].[User_Types] ([user_type_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_followup_request_group_password_followup_request_group...';


GO
ALTER TABLE [dbo].[followup_request_group_password] WITH NOCHECK
    ADD CONSTRAINT [FK_followup_request_group_password_followup_request_group] FOREIGN KEY ([frg_id]) REFERENCES [dbo].[followup_request_group] ([frg_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_followup_request_group_password_Users_Passwords...';


GO
ALTER TABLE [dbo].[followup_request_group_password] WITH NOCHECK
    ADD CONSTRAINT [FK_followup_request_group_password_Users_Passwords] FOREIGN KEY ([user_password_id]) REFERENCES [dbo].[Users_Passwords] ([user_password_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_followup_rqst_grp_user_followup_request_group...';


GO
ALTER TABLE [dbo].[followup_request_group_user] WITH NOCHECK
    ADD CONSTRAINT [FK_followup_rqst_grp_user_followup_request_group] FOREIGN KEY ([frg_id]) REFERENCES [dbo].[followup_request_group] ([frg_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_followup_rqst_grp_user_Phx_Users...';


GO
ALTER TABLE [dbo].[followup_request_group_user] WITH NOCHECK
    ADD CONSTRAINT [FK_followup_rqst_grp_user_Phx_Users] FOREIGN KEY ([phx_user_id]) REFERENCES [dbo].[Phx_Users] ([phx_user_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_Global_Win_Groups_Win_Domains...';


GO
ALTER TABLE [dbo].[Global_Win_Groups] WITH NOCHECK
    ADD CONSTRAINT [FK_Global_Win_Groups_Win_Domains] FOREIGN KEY ([win_domain_id]) REFERENCES [dbo].[Win_Domains] ([win_domain_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_Global_Win_Groups_Win_Groups...';


GO
ALTER TABLE [dbo].[Global_Win_Groups] WITH NOCHECK
    ADD CONSTRAINT [FK_Global_Win_Groups_Win_Groups] FOREIGN KEY ([win_group_id]) REFERENCES [dbo].[Win_Groups] ([win_group_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_hist_change_password_Phx_Users...';


GO
ALTER TABLE [dbo].[hist_change_password] WITH NOCHECK
    ADD CONSTRAINT [FK_hist_change_password_Phx_Users] FOREIGN KEY ([phx_user_id]) REFERENCES [dbo].[Phx_Users] ([phx_user_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_hist_change_password_Users...';


GO
ALTER TABLE [dbo].[hist_change_password] WITH NOCHECK
    ADD CONSTRAINT [FK_hist_change_password_Users] FOREIGN KEY ([user_id]) REFERENCES [dbo].[Users] ([user_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_hist_change_password_historico_Phx_Users...';


GO
ALTER TABLE [dbo].[hist_change_password_historico] WITH NOCHECK
    ADD CONSTRAINT [FK_hist_change_password_historico_Phx_Users] FOREIGN KEY ([phx_user_id]) REFERENCES [dbo].[Phx_Users] ([phx_user_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_hist_change_password_historico_Users...';


GO
ALTER TABLE [dbo].[hist_change_password_historico] WITH NOCHECK
    ADD CONSTRAINT [FK_hist_change_password_historico_Users] FOREIGN KEY ([user_id]) REFERENCES [dbo].[Users] ([user_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_item_lote_chk_win_local_users_accion_item_chk_win_local_user...';


GO
ALTER TABLE [dbo].[item_lote_chk_win_local_users] WITH NOCHECK
    ADD CONSTRAINT [FK_item_lote_chk_win_local_users_accion_item_chk_win_local_user] FOREIGN KEY ([accion]) REFERENCES [dbo].[accion_item_chk_win_local_user] ([id]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_item_lote_chk_win_local_users_lote_chk_win_local_users...';


GO
ALTER TABLE [dbo].[item_lote_chk_win_local_users] WITH NOCHECK
    ADD CONSTRAINT [FK_item_lote_chk_win_local_users_lote_chk_win_local_users] FOREIGN KEY ([lote]) REFERENCES [dbo].[lote_chk_win_local_users] ([id]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_item_lote_chk_win_local_users_Win_Local_Users...';


GO
ALTER TABLE [dbo].[item_lote_chk_win_local_users] WITH NOCHECK
    ADD CONSTRAINT [FK_item_lote_chk_win_local_users_Win_Local_Users] FOREIGN KEY ([win_local_user]) REFERENCES [dbo].[Win_Local_Users] ([user_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_Local_Win_Groups_Win_Groups...';


GO
ALTER TABLE [dbo].[Local_Win_Groups] WITH NOCHECK
    ADD CONSTRAINT [FK_Local_Win_Groups_Win_Groups] FOREIGN KEY ([win_group_id]) REFERENCES [dbo].[Win_Groups] ([win_group_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_Local_Win_Groups_Win_PCs...';


GO
ALTER TABLE [dbo].[Local_Win_Groups] WITH NOCHECK
    ADD CONSTRAINT [FK_Local_Win_Groups_Win_PCs] FOREIGN KEY ([win_pc_id]) REFERENCES [dbo].[Win_PCs] ([win_pc_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_mail_alert_Mail_type...';


GO
ALTER TABLE [dbo].[mail_alert] WITH NOCHECK
    ADD CONSTRAINT [FK_mail_alert_Mail_type] FOREIGN KEY ([mail_type_id]) REFERENCES [dbo].[Mail_type] ([mail_type_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_Passwords_Requests_Requests...';


GO
ALTER TABLE [dbo].[Passwords_Requests] WITH NOCHECK
    ADD CONSTRAINT [FK_Passwords_Requests_Requests] FOREIGN KEY ([request_id]) REFERENCES [dbo].[Requests] ([request_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_Passwords_Requests_Users_Passwords...';


GO
ALTER TABLE [dbo].[Passwords_Requests] WITH NOCHECK
    ADD CONSTRAINT [FK_Passwords_Requests_Users_Passwords] FOREIGN KEY ([user_password_id]) REFERENCES [dbo].[Users_Passwords] ([user_password_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_phx_privilege_phx_privilege_group...';


GO
ALTER TABLE [dbo].[phx_privilege] WITH NOCHECK
    ADD CONSTRAINT [FK_phx_privilege_phx_privilege_group] FOREIGN KEY ([phx_prv_grp_id]) REFERENCES [dbo].[phx_privilege_group] ([phx_prv_grp_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_phx_privilege_role_phx_privilege...';


GO
ALTER TABLE [dbo].[phx_privilege_role] WITH NOCHECK
    ADD CONSTRAINT [FK_phx_privilege_role_phx_privilege] FOREIGN KEY ([phx_privilege_id]) REFERENCES [dbo].[phx_privilege] ([phx_privilege_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_phx_privilege_role_Phx_Roles...';


GO
ALTER TABLE [dbo].[phx_privilege_role] WITH NOCHECK
    ADD CONSTRAINT [FK_phx_privilege_role_Phx_Roles] FOREIGN KEY ([phx_role_id]) REFERENCES [dbo].[Phx_Roles] ([phx_role_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_Phx_Roles_Users_Phx_Roles...';


GO
ALTER TABLE [dbo].[Phx_Roles_Users] WITH NOCHECK
    ADD CONSTRAINT [FK_Phx_Roles_Users_Phx_Roles] FOREIGN KEY ([phx_role_id]) REFERENCES [dbo].[Phx_Roles] ([phx_role_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_Phx_Roles_Users_Phx_Users...';


GO
ALTER TABLE [dbo].[Phx_Roles_Users] WITH NOCHECK
    ADD CONSTRAINT [FK_Phx_Roles_Users_Phx_Users] FOREIGN KEY ([phx_user_id]) REFERENCES [dbo].[Phx_Users] ([phx_user_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_Phx_Users_Phx_User_Superior...';


GO
ALTER TABLE [dbo].[Phx_Users] WITH NOCHECK
    ADD CONSTRAINT [FK_Phx_Users_Phx_User_Superior] FOREIGN KEY ([sup_id]) REFERENCES [dbo].[Phx_User_Superior] ([sup_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_Phx_Users_Groups_Phx_Users...';


GO
ALTER TABLE [dbo].[Phx_Users_Groups] WITH NOCHECK
    ADD CONSTRAINT [FK_Phx_Users_Groups_Phx_Users] FOREIGN KEY ([phx_user_id]) REFERENCES [dbo].[Phx_Users] ([phx_user_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_Phx_Users_Groups_Qry_Groups...';


GO
ALTER TABLE [dbo].[Phx_Users_Groups] WITH NOCHECK
    ADD CONSTRAINT [FK_Phx_Users_Groups_Qry_Groups] FOREIGN KEY ([rqst_grp_id]) REFERENCES [dbo].[Requests_Groups] ([rqst_grp_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_Protocol_Communication_Device_Communication_Device_Protocols...';


GO
ALTER TABLE [dbo].[Protocol_Communication_Device] WITH NOCHECK
    ADD CONSTRAINT [FK_Protocol_Communication_Device_Communication_Device_Protocols] FOREIGN KEY ([cm_dv_protocol_id]) REFERENCES [dbo].[Communication_Device_Protocols] ([cm_dv_protocol_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_Protocol_Communication_Device_Communication_Devices...';


GO
ALTER TABLE [dbo].[Protocol_Communication_Device] WITH NOCHECK
    ADD CONSTRAINT [FK_Protocol_Communication_Device_Communication_Devices] FOREIGN KEY ([cm_dv_id]) REFERENCES [dbo].[Communication_Devices] ([cm_dv_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_Password_Requests_Request_States...';


GO
ALTER TABLE [dbo].[Requests] WITH NOCHECK
    ADD CONSTRAINT [FK_Password_Requests_Request_States] FOREIGN KEY ([rqst_state_id]) REFERENCES [dbo].[Request_States] ([rqst_state_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_Password_Requests_rqst_User...';


GO
ALTER TABLE [dbo].[Requests] WITH NOCHECK
    ADD CONSTRAINT [FK_Password_Requests_rqst_User] FOREIGN KEY ([rqst_user_id]) REFERENCES [dbo].[Phx_Users] ([phx_user_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_Requests_Phx_Auth1_Users...';


GO
ALTER TABLE [dbo].[Requests] WITH NOCHECK
    ADD CONSTRAINT [FK_Requests_Phx_Auth1_Users] FOREIGN KEY ([auth1_usr_id]) REFERENCES [dbo].[Phx_Users] ([phx_user_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_Requests_Phx_Auth2_Users...';


GO
ALTER TABLE [dbo].[Requests] WITH NOCHECK
    ADD CONSTRAINT [FK_Requests_Phx_Auth2_Users] FOREIGN KEY ([auth2_usr_id]) REFERENCES [dbo].[Phx_Users] ([phx_user_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_Requests_Return_User...';


GO
ALTER TABLE [dbo].[Requests] WITH NOCHECK
    ADD CONSTRAINT [FK_Requests_Return_User] FOREIGN KEY ([return_usr_id]) REFERENCES [dbo].[Phx_Users] ([phx_user_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_Requests_Notes_Phx_Users...';


GO
ALTER TABLE [dbo].[Requests_Notes] WITH NOCHECK
    ADD CONSTRAINT [FK_Requests_Notes_Phx_Users] FOREIGN KEY ([phx_user_id]) REFERENCES [dbo].[Phx_Users] ([phx_user_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_Requests_Notes_Requests...';


GO
ALTER TABLE [dbo].[Requests_Notes] WITH NOCHECK
    ADD CONSTRAINT [FK_Requests_Notes_Requests] FOREIGN KEY ([request_id]) REFERENCES [dbo].[Requests] ([request_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_Rqst_Grps_Deleg_Phx_Auth1Users...';


GO
ALTER TABLE [dbo].[Rqst_Grps_Deleg] WITH NOCHECK
    ADD CONSTRAINT [FK_Rqst_Grps_Deleg_Phx_Auth1Users] FOREIGN KEY ([auth1_usr_id]) REFERENCES [dbo].[Phx_Users] ([phx_user_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_Rqst_Grps_Deleg_Phx_Auth2Users...';


GO
ALTER TABLE [dbo].[Rqst_Grps_Deleg] WITH NOCHECK
    ADD CONSTRAINT [FK_Rqst_Grps_Deleg_Phx_Auth2Users] FOREIGN KEY ([auth2_usr_id]) REFERENCES [dbo].[Phx_Users] ([phx_user_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_Rqst_Grps_Deleg_Requests_Groups...';


GO
ALTER TABLE [dbo].[Rqst_Grps_Deleg] WITH NOCHECK
    ADD CONSTRAINT [FK_Rqst_Grps_Deleg_Requests_Groups] FOREIGN KEY ([rqst_grp_id]) REFERENCES [dbo].[Requests_Groups] ([rqst_grp_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_Rqst_Grps_Deleg_Win_Groups...';


GO
ALTER TABLE [dbo].[Rqst_Grps_Deleg] WITH NOCHECK
    ADD CONSTRAINT [FK_Rqst_Grps_Deleg_Win_Groups] FOREIGN KEY ([win_group_id]) REFERENCES [dbo].[Win_Groups] ([win_group_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_Qry_Grps_Pwds_Phx_Users_Auth1...';


GO
ALTER TABLE [dbo].[Rqst_Grps_Pwds] WITH NOCHECK
    ADD CONSTRAINT [FK_Qry_Grps_Pwds_Phx_Users_Auth1] FOREIGN KEY ([auth1_usr_id]) REFERENCES [dbo].[Phx_Users] ([phx_user_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_Qry_Grps_Pwds_Phx_Users_Auth2...';


GO
ALTER TABLE [dbo].[Rqst_Grps_Pwds] WITH NOCHECK
    ADD CONSTRAINT [FK_Qry_Grps_Pwds_Phx_Users_Auth2] FOREIGN KEY ([auth2_usr_id]) REFERENCES [dbo].[Phx_Users] ([phx_user_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_Qry_Grps_Pwds_Qry_Groups...';


GO
ALTER TABLE [dbo].[Rqst_Grps_Pwds] WITH NOCHECK
    ADD CONSTRAINT [FK_Qry_Grps_Pwds_Qry_Groups] FOREIGN KEY ([rqst_grp_id]) REFERENCES [dbo].[Requests_Groups] ([rqst_grp_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_Qry_Grps_Pwds_Users_Passwords...';


GO
ALTER TABLE [dbo].[Rqst_Grps_Pwds] WITH NOCHECK
    ADD CONSTRAINT [FK_Qry_Grps_Pwds_Users_Passwords] FOREIGN KEY ([user_password_id]) REFERENCES [dbo].[Users_Passwords] ([user_password_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_ticket_notificacion_clave_aplicacion_notificacion_clave...';


GO
ALTER TABLE [dbo].[ticket_notificacion_clave] WITH NOCHECK
    ADD CONSTRAINT [FK_ticket_notificacion_clave_aplicacion_notificacion_clave] FOREIGN KEY ([tnc_app_id]) REFERENCES [dbo].[aplicacion_notificacion_clave] ([anc_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_Unix_users_Unix...';


GO
ALTER TABLE [dbo].[Unix_users] WITH NOCHECK
    ADD CONSTRAINT [FK_Unix_users_Unix] FOREIGN KEY ([unx_id]) REFERENCES [dbo].[Unix] ([unx_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_Users_User_Types...';


GO
ALTER TABLE [dbo].[Users] WITH NOCHECK
    ADD CONSTRAINT [FK_Users_User_Types] FOREIGN KEY ([user_type_id]) REFERENCES [dbo].[User_Types] ([user_type_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_Users_Users_Passwords...';


GO
ALTER TABLE [dbo].[Users] WITH NOCHECK
    ADD CONSTRAINT [FK_Users_Users_Passwords] FOREIGN KEY ([user_password_id]) REFERENCES [dbo].[Users_Passwords] ([user_password_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_Users_Passwords_Pwd_Lock_types...';


GO
ALTER TABLE [dbo].[Users_Passwords] WITH NOCHECK
    ADD CONSTRAINT [FK_Users_Passwords_Pwd_Lock_types] FOREIGN KEY ([pwd_lock_type_id]) REFERENCES [dbo].[Pwd_Lock_types] ([pwd_lock_type_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_Win_Domain_Controllers_Win_Domain_Users...';


GO
ALTER TABLE [dbo].[Win_Domain_Controllers] WITH NOCHECK
    ADD CONSTRAINT [FK_Win_Domain_Controllers_Win_Domain_Users] FOREIGN KEY ([impersonate_user_id]) REFERENCES [dbo].[Win_Domain_Users] ([user_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_Win_Domain_Controllers_Win_Domains...';


GO
ALTER TABLE [dbo].[Win_Domain_Controllers] WITH NOCHECK
    ADD CONSTRAINT [FK_Win_Domain_Controllers_Win_Domains] FOREIGN KEY ([win_domain_id]) REFERENCES [dbo].[Win_Domains] ([win_domain_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_Win_Domain_Controllers_Win_PCs...';


GO
ALTER TABLE [dbo].[Win_Domain_Controllers] WITH NOCHECK
    ADD CONSTRAINT [FK_Win_Domain_Controllers_Win_PCs] FOREIGN KEY ([win_pc_id]) REFERENCES [dbo].[Win_PCs] ([win_pc_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_Win_Domain_Users_Users...';


GO
ALTER TABLE [dbo].[Win_Domain_Users] WITH NOCHECK
    ADD CONSTRAINT [FK_Win_Domain_Users_Users] FOREIGN KEY ([user_id]) REFERENCES [dbo].[Users] ([user_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_Win_Domain_Users_Win_Domains...';


GO
ALTER TABLE [dbo].[Win_Domain_Users] WITH NOCHECK
    ADD CONSTRAINT [FK_Win_Domain_Users_Win_Domains] FOREIGN KEY ([win_domain_id]) REFERENCES [dbo].[Win_Domains] ([win_domain_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_Win_Local_Users_Users...';


GO
ALTER TABLE [dbo].[Win_Local_Users] WITH NOCHECK
    ADD CONSTRAINT [FK_Win_Local_Users_Users] FOREIGN KEY ([user_id]) REFERENCES [dbo].[Users] ([user_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_Win_Local_Users_Win_PCs...';


GO
ALTER TABLE [dbo].[Win_Local_Users] WITH NOCHECK
    ADD CONSTRAINT [FK_Win_Local_Users_Win_PCs] FOREIGN KEY ([win_pc_id]) REFERENCES [dbo].[Win_PCs] ([win_pc_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_Win_PCs_Win_Domains...';


GO
ALTER TABLE [dbo].[Win_PCs] WITH NOCHECK
    ADD CONSTRAINT [FK_Win_PCs_Win_Domains] FOREIGN KEY ([win_domain_id]) REFERENCES [dbo].[Win_Domains] ([win_domain_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating [dbo].[pwdlocktype_chg]...';


GO
SET ANSI_NULLS ON;

SET QUOTED_IDENTIFIER OFF;


GO

/****** Object:  Trigger dbo.pwdlocktype_chg    Script Date: 05/11/2007 09:39:33 a.m. ******/
CREATE TRIGGER pwdlocktype_chg ON [dbo].[Users_Passwords] 
AFTER UPDATE
AS

set nocount on
IF NOT UPDATE(pwd_lock_type_id)
return

declare @pwd_id as int
select @pwd_id = user_password_id from inserted
IF EXISTS (SELECT 1 FROM INSERTED WHERE PWD_LOCK_TYPE_ID IS NOT NULL)
BEGIN
UPDATE Users_Passwords SET D_LOCK_PWD = getdate() where user_password_id = @pwd_id
END
ELSE
BEGIN
UPDATE Users_Passwords SET D_LOCK_PWD = NULL where user_password_id = @pwd_id
END


set nocount off
GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON;


GO
PRINT N'Creating [dbo].[AddWinGroupToDelegRqstGrpDemo]...';


GO
/****** Object:  Trigger dbo.AddWinGroupToDelegRqstGrpDemo    Script Date: 05/11/2007 09:39:33 a.m. ******/
CREATE TRIGGER AddWinGroupToDelegRqstGrpDemo ON dbo.Win_Groups 
FOR INSERT
AS
begin
declare @AuthUserId as varchar(100)
select @AuthUserId = conf_value from demo_conf where conf_code = 'AUTHDELEGRQSTID'
if @AuthUserId is not null AND @AuthUserId <> ''
begin
declare @RqstgrpId as int
declare CURRqstGrps cursor for
select rqst_grp_id from dbo.Requests_Groups open CURRqstGrps
-- Avanzamos un registro y cargamos en las variables los valores encontrados en el primer registro
fetch next from CURRqstGrps
into @RqstgrpId
while @@fetch_status = 0
begin
-- busca passwords no asociados al grupo
declare @WinGroupId as int

declare CURWinGrpGrps cursor for
select win_group_id from Win_Groups wg
where not exists (select 1 from Rqst_Grps_Deleg rgd 
where rgd.rqst_grp_id = @RqstgrpId and wg.win_group_id = rgd.win_group_id)

open CURWinGrpGrps
fetch next from CURWinGrpGrps
into @WinGroupId
while @@fetch_status = 0
begin

INSERT INTO Rqst_Grps_Deleg
([rqst_grp_id], [win_group_id], [auth1_usr_id], [auth2_usr_id])
VALUES
(@RqstgrpId, @WinGroupId, @AuthUserId, null)

fetch next from CURWinGrpGrps
into @WinGroupId
end 
-- cerramos el cursor
close CURWinGrpGrps
deallocate CURWinGrpGrps 

-- termina cursor CURPwdGrps


-- Avanza otro registro
fetch next from CURRqstGrps
into @RqstgrpId
end 
-- cerramos el cursor
close CURRqstGrps
deallocate CURRqstGrps 

--rollback
end

end
GO
PRINT N'Creating [dbo].[DepurarAuditLogin]...';


GO

CREATE PROCEDURE dbo.DepurarAuditLogin
	@Fecha DATETIME
AS
BEGIN
	SET NOCOUNT ON

	BEGIN TRANSACTION

	DECLARE @FechaBorrado DATETIME

	set @FechaBorrado = GETDATE()

	INSERT INTO 
		audit_login_historico (aud_login_id, fecha, terminal, id_usuario, username, fullname, evento_login_id, app_id, fecha_borrado)
	SELECT 
		aud_login_id, fecha, terminal, id_usuario, username, fullname, evento_login_id, app_id, @FechaBorrado
	FROM
		audit_login
	WHERE
		fecha <= @Fecha
	
	DELETE FROM
		audit_login
	WHERE
		fecha <= @Fecha

	COMMIT TRANSACTION

	SELECT 1 resultado
END
GO
PRINT N'Creating [dbo].[DepurarChangePasswordLog]...';


GO

CREATE PROCEDURE dbo.DepurarChangePasswordLog
	@Fecha DATETIME
AS
BEGIN
	SET NOCOUNT ON

	BEGIN TRANSACTION

	DECLARE @FechaBorrado DATETIME

	set @FechaBorrado = GETDATE()

	INSERT INTO 
		hist_change_password_historico (hist_chg_pwd_id, [user_id], phx_user_id, d_change, [password], fecha_borrado)
	SELECT 
		hist_chg_pwd_id, [user_id], phx_user_id, d_change, [password], @FechaBorrado
	FROM
		hist_change_password
	WHERE
		d_change <= @Fecha
	
	DELETE FROM
		hist_change_password
	WHERE
		d_change <= @Fecha

	COMMIT TRANSACTION

	SELECT 1 resultado
END
GO
PRINT N'Creating [dbo].[vwCantFollowRqstGrpPwd]...';


GO
CREATE VIEW dbo.vwCantFollowRqstGrpPwd
AS
SELECT     frgp_id, frg_id, user_password_id,
                          (SELECT     COUNT(*) AS Cant
                            FROM          dbo.followup_request_group_password AS frgp2 INNER JOIN
                                                   dbo.followup_request_group ON frgp2.frg_id = dbo.followup_request_group.frg_id
                            WHERE      (frgp1.user_password_id = frgp2.user_password_id) AND (dbo.followup_request_group.frg_active = 1)) AS Cant
FROM         dbo.followup_request_group_password AS frgp1
GO
PRINT N'Creating [dbo].[vwCantRqstGrpPwd]...';


GO
CREATE VIEW dbo.vwCantRqstGrpPwd
AS
SELECT     pwdrqst_grp_pwd_id, rqst_grp_id, user_password_id,
                          (SELECT     COUNT(*) AS Cant
                            FROM          dbo.Rqst_Grps_Pwds AS rgp2 INNER JOIN
                                                   dbo.Requests_Groups ON rgp2.rqst_grp_id = dbo.Requests_Groups.rqst_grp_id
                            WHERE      (rgp1.user_password_id = rgp2.user_password_id) AND (dbo.Requests_Groups.rqst_grp_active = 1)) AS Cant
FROM         dbo.Rqst_Grps_Pwds AS rgp1
GO
PRINT N'Creating [dbo].[vwCtrlGlobalWinGrps]...';


GO

/****** Object:  View dbo.vwCtrlGlobalWinGrps    Script Date: 05/11/2007 09:39:33 a.m. ******/
CREATE VIEW dbo.vwCtrlGlobalWinGrps
AS
SELECT     dbo.Win_Domains.win_domain_id, dbo.Win_Domains.nt_name, dbo.Win_Groups.win_group_id, dbo.Win_Groups.nt_group_name, 
                      dbo.Rqst_Grps_Deleg.delrqst_grp_delg_id, dbo.Requests_Groups.rqst_grp_id, dbo.Requests_Groups.rqst_grp_name, 
                      dbo.Phx_Users_Groups.phx_usr_grp_id, Phx_Users_1.phx_user_id, Phx_Users_1.username AS phx_username, 
                      Phx_Users_1.user_domain AS phx_user_domain, Phx_Users_1.phx_user_id AS phx_authuser_id, Phx_Users_1.username AS phx_authusername, 
                      Phx_Users_1.user_domain AS phx_authuser_domain
FROM         dbo.Win_Groups INNER JOIN
                      dbo.Win_Domains INNER JOIN
                      dbo.Global_Win_Groups ON dbo.Win_Domains.win_domain_id = dbo.Global_Win_Groups.win_domain_id ON 
                      dbo.Win_Groups.win_group_id = dbo.Global_Win_Groups.win_group_id INNER JOIN
                      dbo.Requests_Groups INNER JOIN
                      dbo.Rqst_Grps_Deleg ON dbo.Requests_Groups.rqst_grp_id = dbo.Rqst_Grps_Deleg.rqst_grp_id INNER JOIN
                      dbo.Phx_Users Phx_Users_1 ON dbo.Rqst_Grps_Deleg.auth1_usr_id = Phx_Users_1.phx_user_id INNER JOIN
                      dbo.Phx_Users_Groups ON dbo.Requests_Groups.rqst_grp_id = dbo.Phx_Users_Groups.rqst_grp_id INNER JOIN
                      dbo.Phx_Users Phx_Users_2 ON dbo.Phx_Users_Groups.phx_user_id = Phx_Users_2.phx_user_id ON 
                      dbo.Global_Win_Groups.win_group_id = dbo.Rqst_Grps_Deleg.win_group_id
GO
PRINT N'Creating [dbo].[vwCtrlLocalWinGrps]...';


GO

/****** Object:  View dbo.vwCtrlLocalWinGrps    Script Date: 05/11/2007 09:39:33 a.m. ******/
CREATE VIEW dbo.vwCtrlLocalWinGrps
AS
SELECT     dbo.Win_Domains.win_domain_id, dbo.Win_Domains.nt_name, dbo.Win_PCs.win_pc_id, dbo.Win_PCs.pc_name, dbo.Win_Groups.win_group_id, 
                      dbo.Win_Groups.nt_group_name, dbo.Rqst_Grps_Deleg.delrqst_grp_delg_id, dbo.Requests_Groups.rqst_grp_id, 
                      dbo.Requests_Groups.rqst_grp_name, dbo.Phx_Users_Groups.phx_usr_grp_id, dbo.Phx_Users.phx_user_id, 
                      dbo.Phx_Users.username AS phx_username, dbo.Phx_Users.user_domain AS phx_user_domain, Phx_Users_1.phx_user_id AS phx_authuser_id, 
                      Phx_Users_1.username AS phx_authusername, Phx_Users_1.user_domain AS phx_authuser_domain
FROM         dbo.Win_Domains INNER JOIN
                      dbo.Win_PCs ON dbo.Win_Domains.win_domain_id = dbo.Win_PCs.win_domain_id INNER JOIN
                      dbo.Local_Win_Groups ON dbo.Win_PCs.win_pc_id = dbo.Local_Win_Groups.win_pc_id INNER JOIN
                      dbo.Win_Groups ON dbo.Local_Win_Groups.win_group_id = dbo.Win_Groups.win_group_id INNER JOIN
                      dbo.Rqst_Grps_Deleg ON dbo.Local_Win_Groups.win_group_id = dbo.Rqst_Grps_Deleg.win_group_id INNER JOIN
                      dbo.Requests_Groups ON dbo.Rqst_Grps_Deleg.rqst_grp_id = dbo.Requests_Groups.rqst_grp_id INNER JOIN
                      dbo.Phx_Users Phx_Users_1 ON dbo.Rqst_Grps_Deleg.auth1_usr_id = Phx_Users_1.phx_user_id INNER JOIN
                      dbo.Phx_Users_Groups ON dbo.Requests_Groups.rqst_grp_id = dbo.Phx_Users_Groups.rqst_grp_id INNER JOIN
                      dbo.Phx_Users ON dbo.Phx_Users_Groups.phx_user_id = dbo.Phx_Users.phx_user_id
GO
PRINT N'Creating [dbo].[vwCtrlUsersPwds]...';


GO

/****** Object:  View dbo.vwCtrlUsersPwds    Script Date: 05/11/2007 09:39:33 a.m. ******/
CREATE VIEW dbo.vwCtrlUsersPwds
AS
SELECT     dbo.Win_Domains.win_domain_id, dbo.Win_Domains.nt_name, dbo.Win_PCs.win_pc_id, dbo.Win_PCs.pc_name, dbo.Win_Local_Users.user_id, 
                      dbo.Users.username, dbo.Users.active_user, dbo.Users_Passwords.user_password_id, dbo.Users_Passwords.password, 
                      dbo.Users_Passwords.static_pwd, dbo.Users_Passwords.d_next_change, dbo.Users_Passwords.d_last_change, dbo.Users_Passwords.change_freq, 
                      dbo.Users_Passwords.change_freq_unit, dbo.Users_Passwords.d_next_chk, dbo.Users_Passwords.d_last_chk, dbo.Users_Passwords.chk_freq, 
                      dbo.Users_Passwords.chk_freq_unit, dbo.Rqst_Grps_Pwds.pwdrqst_grp_pwd_id, dbo.Requests_Groups.rqst_grp_id, 
                      dbo.Requests_Groups.rqst_grp_name, dbo.Phx_Users_Groups.phx_usr_grp_id, dbo.Phx_Users.phx_user_id, 
                      dbo.Phx_Users.username AS phxuser_username, dbo.Phx_Users.fullname AS phxuser_fullname, dbo.Phx_Users.user_domain AS phxuser_domain, 
                      dbo.Rqst_Grps_Pwds.auth1_usr_id, Phx_Users_Auth.username AS auth_username, Phx_Users_Auth.fullname AS auth_fullname, 
                      Phx_Users_Auth.user_domain AS auth_domain
FROM         dbo.Win_Domains INNER JOIN
                      dbo.Win_PCs ON dbo.Win_Domains.win_domain_id = dbo.Win_PCs.win_domain_id INNER JOIN
                      dbo.Win_Local_Users ON dbo.Win_PCs.win_pc_id = dbo.Win_Local_Users.win_pc_id INNER JOIN
                      dbo.Users ON dbo.Win_Local_Users.user_id = dbo.Users.user_id INNER JOIN
                      dbo.Users_Passwords ON dbo.Users.user_password_id = dbo.Users_Passwords.user_password_id INNER JOIN
                      dbo.Rqst_Grps_Pwds ON dbo.Users_Passwords.user_password_id = dbo.Rqst_Grps_Pwds.user_password_id INNER JOIN
                      dbo.Requests_Groups ON dbo.Rqst_Grps_Pwds.rqst_grp_id = dbo.Requests_Groups.rqst_grp_id INNER JOIN
                      dbo.Phx_Users_Groups ON dbo.Requests_Groups.rqst_grp_id = dbo.Phx_Users_Groups.rqst_grp_id INNER JOIN
                      dbo.Phx_Users ON dbo.Phx_Users_Groups.phx_user_id = dbo.Phx_Users.phx_user_id INNER JOIN
                      dbo.Phx_Users Phx_Users_Auth ON dbo.Rqst_Grps_Pwds.auth1_usr_id = Phx_Users_Auth.phx_user_id
GO
PRINT N'Creating [dbo].[vwdate]...';


GO


/****** Object:  View dbo.vwDate    Script Date: 05/11/2007 09:39:33 a.m. ******/
CREATE VIEW vwdate AS SELECT getdate() AS getdate
GO
PRINT N'Creating [dbo].[vwHistChgApp]...';


GO

CREATE  VIEW dbo.vwHistChgApp
AS
SELECT     dbo.hist_change_password.hist_chg_pwd_id AS Id, dbo.Users.user_id AS Folio, dbo.Applications.app_name + '\' + dbo.Users.username AS Usuario, 
                      dbo.hist_change_password.d_change, dbo.Users.user_type_id, dbo.hist_change_password.phx_user_id, dbo.hist_change_password.password
FROM         dbo.Users INNER JOIN
                      dbo.Applications_Users ON dbo.Users.user_id = dbo.Applications_Users.user_id INNER JOIN
                      dbo.Applications ON dbo.Applications_Users.app_id = dbo.Applications.app_id INNER JOIN
                      dbo.hist_change_password ON dbo.Users.user_id = dbo.hist_change_password.user_id
GO
PRINT N'Creating [dbo].[vwHistChgAS400]...';


GO

CREATE VIEW dbo.vwHistChgAS400
AS
SELECT     dbo.hist_change_password.hist_chg_pwd_id AS Id, dbo.Users.user_id AS Folio, dbo.AS400.as_server_name + '\' + dbo.Users.username AS Usuario, 
                      dbo.hist_change_password.d_change, dbo.Users.user_type_id, dbo.hist_change_password.phx_user_id, dbo.hist_change_password.password
FROM         dbo.AS400 INNER JOIN
                      dbo.AS400_users ON dbo.AS400.as_id = dbo.AS400_users.as_id INNER JOIN
                      dbo.hist_change_password INNER JOIN
                      dbo.Users ON dbo.hist_change_password.user_id = dbo.Users.user_id ON dbo.AS400_users.user_id = dbo.Users.user_id
GO
PRINT N'Creating [dbo].[vwHistChgATM]...';


GO

CREATE VIEW [dbo].[vwHistChgATM]
AS
SELECT     dbo.hist_change_password.hist_chg_pwd_id AS Id, dbo.Users.user_id AS Folio, dbo.ATMs_Users.ATM_name + '\' + dbo.Users.username COLLATE DATABASE_DEFAULT AS Usuario, 
                      dbo.hist_change_password.d_change, dbo.Users.user_type_id, dbo.hist_change_password.phx_user_id, dbo.hist_change_password.password
FROM         dbo.Users INNER JOIN
                      dbo.ATMs_Users ON dbo.Users.user_id = dbo.ATMs_Users.user_id INNER JOIN
                      dbo.hist_change_password ON dbo.Users.user_id = dbo.hist_change_password.user_id
WHERE     (dbo.Users.user_type_id = 7)
GO
PRINT N'Creating [dbo].[vwHistChgCD]...';


GO
CREATE VIEW [dbo].[vwHistChgCD]
AS
SELECT     dbo.hist_change_password.hist_chg_pwd_id AS Id, dbo.Users.user_id AS Folio, 
                      dbo.Communication_Device_Types.cm_dv_type_name + '\' + dbo.Communication_Devices.cm_dv_name + '\' + dbo.Users.username AS Usuario, 
                      dbo.hist_change_password.d_change, dbo.Users.user_type_id, dbo.hist_change_password.phx_user_id, dbo.hist_change_password.password
FROM         dbo.Communication_Devices INNER JOIN
                      dbo.Communication_Device_Types ON dbo.Communication_Devices.cm_dv_type_id = dbo.Communication_Device_Types.cm_dv_type_id INNER JOIN
                      dbo.Communication_Device_Users ON dbo.Communication_Devices.cm_dv_id = dbo.Communication_Device_Users.cm_dv_id INNER JOIN
                      dbo.hist_change_password INNER JOIN
                      dbo.Users ON dbo.hist_change_password.user_id = dbo.Users.user_id ON dbo.Communication_Device_Users.user_id = dbo.Users.user_id
GO
PRINT N'Creating [dbo].[vwHistChgDB]...';


GO

CREATE  VIEW dbo.vwHistChgDB
AS
SELECT     dbo.hist_change_password.hist_chg_pwd_id AS Id, dbo.Users.user_id AS Folio, 
                      dbo.Database_Types.db_type_name + '\' + dbo.Data_Bases.db_name + '\' + dbo.Users.username AS Usuario, dbo.hist_change_password.d_change, 
                      dbo.Users.user_type_id, dbo.hist_change_password.phx_user_id, dbo.hist_change_password.password
FROM         dbo.Database_Types INNER JOIN
                      dbo.Data_Bases ON dbo.Database_Types.db_type_id = dbo.Data_Bases.db_type_id INNER JOIN
                      dbo.Databases_Users ON dbo.Data_Bases.db_id = dbo.Databases_Users.db_id INNER JOIN
                      dbo.Users ON dbo.Databases_Users.user_id = dbo.Users.user_id INNER JOIN
                      dbo.hist_change_password ON dbo.Users.user_id = dbo.hist_change_password.user_id
GO
PRINT N'Creating [dbo].[vwHistChgUnix]...';


GO

CREATE  VIEW dbo.vwHistChgUnix
AS
SELECT     dbo.hist_change_password.hist_chg_pwd_id AS Id, dbo.Users.user_id AS Folio, dbo.Unix.unx_server_name + '\' + dbo.Users.username AS Usuario, 
                      dbo.hist_change_password.d_change, dbo.Users.user_type_id, dbo.hist_change_password.phx_user_id, dbo.hist_change_password.password
FROM         dbo.Users INNER JOIN
                      dbo.Unix_users ON dbo.Users.user_id = dbo.Unix_users.user_id INNER JOIN
                      dbo.Unix ON dbo.Unix_users.unx_id = dbo.Unix.unx_id INNER JOIN
                      dbo.hist_change_password ON dbo.Users.user_id = dbo.hist_change_password.user_id
GO
PRINT N'Creating [dbo].[vwHistChgWin]...';


GO

CREATE  VIEW dbo.vwHistChgWin
AS
SELECT     dbo.hist_change_password.hist_chg_pwd_id AS Id, dbo.Users.user_id AS Folio, 
                      dbo.Win_Domains.nt_name + '\' + dbo.Win_PCs.pc_name + '\' + dbo.Users.username AS Usuario, dbo.hist_change_password.d_change, 
                      dbo.Users.user_type_id, dbo.hist_change_password.phx_user_id, dbo.hist_change_password.password
FROM         dbo.Win_PCs INNER JOIN
                      dbo.Win_Local_Users ON dbo.Win_PCs.win_pc_id = dbo.Win_Local_Users.win_pc_id INNER JOIN
                      dbo.Win_Domains ON dbo.Win_PCs.win_domain_id = dbo.Win_Domains.win_domain_id INNER JOIN
                      dbo.Users ON dbo.Win_Local_Users.user_id = dbo.Users.user_id INNER JOIN
                      dbo.hist_change_password ON dbo.Users.user_id = dbo.hist_change_password.user_id
GO
PRINT N'Creating [dbo].[vwHistPwdChg]...';


GO
CREATE VIEW [dbo].[vwHistPwdChg]
AS
SELECT     Id, Folio, Usuario COLLATE DATABASE_DEFAULT as Usuario, d_change, user_type_id, phx_user_id, password
FROM         dbo.vwHistChgApp
UNION
SELECT     Id, Folio, Usuario COLLATE DATABASE_DEFAULT as Usuario, d_change, user_type_id, phx_user_id, password
FROM         dbo.vwHistChgUnix
UNION
SELECT     Id, Folio, Usuario COLLATE DATABASE_DEFAULT as Usuario, d_change, user_type_id, phx_user_id, password
FROM         dbo.vwHistChgDB
UNION
SELECT     Id, Folio, Usuario COLLATE DATABASE_DEFAULT as Usuario, d_change, user_type_id, phx_user_id, password
FROM         dbo.vwHistChgWin
UNION
SELECT     Id, Folio, Usuario COLLATE DATABASE_DEFAULT as Usuario, d_change, user_type_id, phx_user_id, password
FROM         dbo.vwHistChgAS400
UNION
SELECT     Id, Folio, Usuario COLLATE DATABASE_DEFAULT as Usuario, d_change, user_type_id, phx_user_id, password
FROM         vwHistChgCD
UNION
SELECT     Id, Folio, Usuario COLLATE DATABASE_DEFAULT as Usuario, d_change, user_type_id, phx_user_id, password
FROM         dbo.vwHistChgATM
GO
PRINT N'Creating [dbo].[vwInventarioApp]...';


GO
CREATE VIEW dbo.vwInventarioApp
AS
SELECT     dbo.Users.user_id AS Folio, dbo.User_Types.user_type_desc AS Ambiente, dbo.Applications.app_name + '\' + dbo.Users.username AS Usuario, 
                      dbo.Users.active_user AS Activo, dbo.Users.user_critical AS Critico
FROM         dbo.Users INNER JOIN
                      dbo.User_Types ON dbo.Users.user_type_id = dbo.User_Types.user_type_id INNER JOIN
                      dbo.Applications_Users ON dbo.Users.user_id = dbo.Applications_Users.user_id INNER JOIN
                      dbo.Applications ON dbo.Applications_Users.app_id = dbo.Applications.app_id
GO
PRINT N'Creating [dbo].[vwInventarioAS400]...';


GO
CREATE VIEW dbo.vwInventarioAS400
AS
SELECT     dbo.Users.user_id AS Folio, dbo.User_Types.user_type_desc AS Ambiente, dbo.AS400.as_server_name + '\' + dbo.Users.username AS Usuario, 
                      dbo.Users.active_user AS Activo, dbo.Users.user_critical AS Critico
FROM         dbo.Users INNER JOIN
                      dbo.User_Types ON dbo.Users.user_type_id = dbo.User_Types.user_type_id INNER JOIN
                      dbo.AS400_users ON dbo.Users.user_id = dbo.AS400_users.user_id INNER JOIN
                      dbo.AS400 ON dbo.AS400_users.as_id = dbo.AS400.as_id
GO
PRINT N'Creating [dbo].[vwInventarioATM]...';


GO






CREATE VIEW [dbo].[vwInventarioATM]
AS
SELECT     dbo.Users.user_id AS Folio, dbo.User_Types.user_type_desc AS Ambiente, 
                      dbo.ATMs_Users.ATM_name + '\' + dbo.Users.username COLLATE DATABASE_DEFAULT AS Usuario, dbo.Users.active_user AS Activo, 
                      dbo.Users.user_critical AS Critico
FROM         dbo.ATMs_Users INNER JOIN
                      dbo.Users ON dbo.ATMs_Users.user_id = dbo.Users.user_id INNER JOIN
                      dbo.User_Types ON dbo.Users.user_type_id = dbo.User_Types.user_type_id
WHERE     (dbo.Users.user_type_id = 7)
GO
PRINT N'Creating [dbo].[vwInventarioDB]...';


GO
CREATE VIEW dbo.vwInventarioDB
AS
SELECT     dbo.Users.user_id AS Folio, dbo.User_Types.user_type_desc AS Ambiente, 
                      dbo.Database_Types.db_type_name + '\' + dbo.Data_Bases.db_name + '\' + dbo.Users.username AS Usuario, dbo.Users.active_user AS Activo, 
                      dbo.Users.user_critical AS Critico
FROM         dbo.Database_Types INNER JOIN
                      dbo.Data_Bases ON dbo.Database_Types.db_type_id = dbo.Data_Bases.db_type_id INNER JOIN
                      dbo.Databases_Users ON dbo.Data_Bases.db_id = dbo.Databases_Users.db_id INNER JOIN
                      dbo.Users INNER JOIN
                      dbo.User_Types ON dbo.Users.user_type_id = dbo.User_Types.user_type_id ON dbo.Databases_Users.user_id = dbo.Users.user_id
GO
PRINT N'Creating [dbo].[vwInventarioEC]...';


GO
CREATE VIEW [dbo].[vwInventarioEC]
AS
SELECT     dbo.Users.user_id AS Folio, dbo.User_Types.user_type_desc AS Ambiente, 
                      dbo.Communication_Device_Types.cm_dv_type_name + '\' + dbo.Communication_Devices.cm_dv_name + '\' + dbo.Users.username AS Usuario, 
                      dbo.Users.active_user AS Activo, dbo.Users.user_critical AS Critico
FROM         dbo.Communication_Device_Types INNER JOIN
                      dbo.Communication_Devices ON dbo.Communication_Device_Types.cm_dv_type_id = dbo.Communication_Devices.cm_dv_type_id INNER JOIN
                      dbo.Communication_Device_Users ON dbo.Communication_Devices.cm_dv_id = dbo.Communication_Device_Users.cm_dv_id INNER JOIN
                      dbo.Users INNER JOIN
                      dbo.User_Types ON dbo.Users.user_type_id = dbo.User_Types.user_type_id ON dbo.Communication_Device_Users.user_id = dbo.Users.user_id
GO
PRINT N'Creating [dbo].[vwInventarioUnix]...';


GO
CREATE VIEW dbo.vwInventarioUnix
AS
SELECT     dbo.Users.user_id AS Folio, dbo.User_Types.user_type_desc AS Ambiente, dbo.Unix.unx_server_name + '\' + dbo.Users.username AS Usuario, 
                      dbo.Users.active_user AS Activo, dbo.Users.user_critical AS Critico
FROM         dbo.Users INNER JOIN
                      dbo.User_Types ON dbo.Users.user_type_id = dbo.User_Types.user_type_id INNER JOIN
                      dbo.Unix_users ON dbo.Users.user_id = dbo.Unix_users.user_id INNER JOIN
                      dbo.Unix ON dbo.Unix_users.unx_id = dbo.Unix.unx_id
GO
PRINT N'Creating [dbo].[vwInventarioWin]...';


GO
CREATE VIEW dbo.vwInventarioWin
AS
SELECT     dbo.Users.user_id AS Folio, dbo.User_Types.user_type_desc AS Ambiente, 
                      dbo.Win_Domains.nt_name + '\' + dbo.Win_PCs.pc_name + '\' + dbo.Users.username AS Usuario, dbo.Users.active_user AS Activo, 
                      dbo.Users.user_critical AS Critico
FROM         dbo.Win_PCs INNER JOIN
                      dbo.Win_Local_Users ON dbo.Win_PCs.win_pc_id = dbo.Win_Local_Users.win_pc_id INNER JOIN
                      dbo.Win_Domains ON dbo.Win_PCs.win_domain_id = dbo.Win_Domains.win_domain_id INNER JOIN
                      dbo.Users ON dbo.Win_Local_Users.user_id = dbo.Users.user_id INNER JOIN
                      dbo.User_Types ON dbo.Users.user_type_id = dbo.User_Types.user_type_id
GO
PRINT N'Creating [dbo].[vwPerfilUsuario]...';


GO
CREATE VIEW dbo.vwPerfilUsuario
AS
SELECT     dbo.Phx_Roles_Users.phx_role_usr_id AS Id, dbo.Phx_Users.phx_user_id AS UserId, dbo.Phx_Users.user_domain AS UserDomain, 
                      dbo.Phx_Users.username AS UserName, dbo.Phx_Users.fullname AS FullName, dbo.Phx_Roles.phx_role_id AS RoleId, 
                      dbo.Phx_Roles.role_name AS RoleName
FROM         dbo.Phx_Users INNER JOIN
                      dbo.Phx_Roles_Users ON dbo.Phx_Users.phx_user_id = dbo.Phx_Roles_Users.phx_user_id INNER JOIN
                      dbo.Phx_Roles ON dbo.Phx_Roles_Users.phx_role_id = dbo.Phx_Roles.phx_role_id
WHERE     (dbo.Phx_Users.active = 1)
GO
PRINT N'Creating [dbo].[vwPermisoPerfil]...';


GO
CREATE VIEW dbo.vwPermisoPerfil
AS
SELECT     dbo.phx_privilege_role.phx_priv_role_id AS Id, dbo.Phx_Roles.phx_role_id AS RoleId, dbo.Phx_Roles.role_name AS RoleName, 
                      dbo.phx_privilege.phx_privilege_id AS PrivilegeId, dbo.phx_privilege.phx_privilege_name AS PrivilegeName
FROM         dbo.Phx_Roles INNER JOIN
                      dbo.phx_privilege_role ON dbo.Phx_Roles.phx_role_id = dbo.phx_privilege_role.phx_role_id INNER JOIN
                      dbo.phx_privilege ON dbo.phx_privilege_role.phx_privilege_id = dbo.phx_privilege.phx_privilege_id
GO
PRINT N'Creating [dbo].[vwPhxUsersRqstDelGroups]...';


GO

/****** Object:  View dbo.vwPhxUsersRqstDelGroups    Script Date: 05/11/2007 09:39:33 a.m. ******/
CREATE VIEW dbo.vwPhxUsersRqstDelGroups
AS
SELECT     dbo.Rqst_Grps_Deleg.delrqst_grp_delg_id, dbo.Rqst_Grps_Deleg.rqst_grp_id, dbo.Requests_Groups.rqst_grp_name, 
                      dbo.Rqst_Grps_Deleg.win_group_id, dbo.Rqst_Grps_Deleg.auth1_usr_id, dbo.Rqst_Grps_Deleg.auth2_usr_id, dbo.Phx_Users_Groups.phx_user_id, 
                      dbo.Phx_Users.username, dbo.Phx_Users.fullname
FROM         dbo.Phx_Users INNER JOIN
                      dbo.Phx_Users_Groups ON dbo.Phx_Users.phx_user_id = dbo.Phx_Users_Groups.phx_user_id INNER JOIN
                      dbo.Requests_Groups ON dbo.Phx_Users_Groups.rqst_grp_id = dbo.Requests_Groups.rqst_grp_id INNER JOIN
                      dbo.Rqst_Grps_Deleg ON dbo.Requests_Groups.rqst_grp_id = dbo.Rqst_Grps_Deleg.rqst_grp_id
WHERE     (dbo.Phx_Users.delete_date IS NULL)
GO
PRINT N'Creating [dbo].[vwPhxUsersRqstPwdGroups]...';


GO

/****** Object:  View dbo.vwPhxUsersRqstPwdGroups    Script Date: 05/11/2007 09:39:33 a.m. ******/
CREATE VIEW dbo.vwPhxUsersRqstPwdGroups
AS
SELECT     dbo.Rqst_Grps_Pwds.pwdrqst_grp_pwd_id, dbo.Rqst_Grps_Pwds.rqst_grp_id, dbo.Requests_Groups.rqst_grp_name, 
                      dbo.Rqst_Grps_Pwds.user_password_id, dbo.Rqst_Grps_Pwds.auth1_usr_id, dbo.Rqst_Grps_Pwds.auth2_usr_id, 
                      dbo.Phx_Users_Groups.phx_user_id, dbo.Phx_Users.username, dbo.Phx_Users.fullname
FROM         dbo.Rqst_Grps_Pwds INNER JOIN
                      dbo.Requests_Groups ON dbo.Rqst_Grps_Pwds.rqst_grp_id = dbo.Requests_Groups.rqst_grp_id INNER JOIN
                      dbo.Phx_Users_Groups ON dbo.Requests_Groups.rqst_grp_id = dbo.Phx_Users_Groups.rqst_grp_id INNER JOIN
                      dbo.Phx_Users ON dbo.Phx_Users_Groups.phx_user_id = dbo.Phx_Users.phx_user_id
WHERE     (dbo.Phx_Users.delete_date IS NULL)
GO
PRINT N'Creating [dbo].[vwPwdAppRqstGrp]...';


GO


CREATE VIEW [dbo].[vwPwdAppRqstGrp]
AS
SELECT     dbo.Rqst_Grps_Pwds.pwdrqst_grp_pwd_id AS ID, dbo.Users.user_id AS Folio, dbo.User_Types.user_type_id AS IDAmbiente, dbo.User_Types.user_type_desc AS Ambiente, 
                      dbo.Applications.app_name + '\' + dbo.Users.username AS Usuario, dbo.Users.active_user AS Activo, dbo.Users.user_critical AS Critico, 
                      dbo.Requests_Groups.rqst_grp_id AS IDGrupo, dbo.Requests_Groups.rqst_grp_name AS Grupo, 
                      dbo.Requests_Groups.rqst_grp_active AS GrupoActivo
FROM         dbo.Users INNER JOIN
                      dbo.User_Types ON dbo.Users.user_type_id = dbo.User_Types.user_type_id INNER JOIN
                      dbo.Applications_Users ON dbo.Users.user_id = dbo.Applications_Users.user_id INNER JOIN
                      dbo.Applications ON dbo.Applications_Users.app_id = dbo.Applications.app_id INNER JOIN
                      dbo.Users_Passwords ON dbo.Users.user_password_id = dbo.Users_Passwords.user_password_id INNER JOIN
                      dbo.Rqst_Grps_Pwds ON dbo.Users_Passwords.user_password_id = dbo.Rqst_Grps_Pwds.user_password_id INNER JOIN
                      dbo.Requests_Groups ON dbo.Rqst_Grps_Pwds.rqst_grp_id = dbo.Requests_Groups.rqst_grp_id
GO
PRINT N'Creating [dbo].[vwPwdAS400RqstGrp]...';


GO

CREATE VIEW [dbo].[vwPwdAS400RqstGrp]
AS
SELECT     dbo.Rqst_Grps_Pwds.pwdrqst_grp_pwd_id AS ID, dbo.Users.user_id AS Folio, dbo.User_Types.user_type_id AS IDAmbiente, dbo.User_Types.user_type_desc AS Ambiente, 
                      dbo.AS400.as_server_name + '\' + dbo.Users.username AS Usuario, dbo.Users.active_user AS Activo, dbo.Users.user_critical AS Critico, 
                      dbo.Requests_Groups.rqst_grp_id AS IDGrupo, dbo.Requests_Groups.rqst_grp_name AS Grupo, 
                      dbo.Requests_Groups.rqst_grp_active AS GrupoActivo
FROM         dbo.Users INNER JOIN
                      dbo.User_Types ON dbo.Users.user_type_id = dbo.User_Types.user_type_id INNER JOIN
                      dbo.AS400_users ON dbo.Users.user_id = dbo.AS400_users.user_id INNER JOIN
                      dbo.AS400 ON dbo.AS400_users.as_id = dbo.AS400.as_id INNER JOIN
                      dbo.Users_Passwords ON dbo.Users.user_password_id = dbo.Users_Passwords.user_password_id INNER JOIN
                      dbo.Rqst_Grps_Pwds ON dbo.Users_Passwords.user_password_id = dbo.Rqst_Grps_Pwds.user_password_id INNER JOIN
                      dbo.Requests_Groups ON dbo.Rqst_Grps_Pwds.rqst_grp_id = dbo.Requests_Groups.rqst_grp_id
GO
PRINT N'Creating [dbo].[vwPwdATMRqstGrp]...';


GO


CREATE VIEW [dbo].[vwPwdATMRqstGrp]
AS
SELECT     dbo.Rqst_Grps_Pwds.pwdrqst_grp_pwd_id AS ID, dbo.Users.user_id AS Folio, dbo.User_Types.user_type_id AS IDAmbiente, dbo.User_Types.user_type_desc AS Ambiente, 
                      dbo.ATMs_Users.ATM_name + '\' + dbo.Users.username COLLATE DATABASE_DEFAULT AS Usuario, dbo.Users.active_user AS Activo, 
                      dbo.Users.user_critical AS Critico, dbo.Requests_Groups.rqst_grp_id AS IDGrupo, dbo.Requests_Groups.rqst_grp_name AS Grupo, 
                      dbo.Requests_Groups.rqst_grp_active AS GrupoActivo
FROM         dbo.ATMs_Users INNER JOIN
                      dbo.Users ON dbo.ATMs_Users.user_id = dbo.Users.user_id INNER JOIN
                      dbo.User_Types ON dbo.Users.user_type_id = dbo.User_Types.user_type_id INNER JOIN
                      dbo.Users_Passwords ON dbo.Users.user_password_id = dbo.Users_Passwords.user_password_id INNER JOIN
                      dbo.Rqst_Grps_Pwds ON dbo.Users_Passwords.user_password_id = dbo.Rqst_Grps_Pwds.user_password_id INNER JOIN
                      dbo.Requests_Groups ON dbo.Rqst_Grps_Pwds.rqst_grp_id = dbo.Requests_Groups.rqst_grp_id
GO
PRINT N'Creating [dbo].[vwPwdDBRqstGrp]...';


GO


CREATE VIEW [dbo].[vwPwdDBRqstGrp]
AS
SELECT     dbo.Rqst_Grps_Pwds.pwdrqst_grp_pwd_id AS ID, dbo.Users.user_id AS Folio, dbo.User_Types.user_type_id AS IDAmbiente, dbo.User_Types.user_type_desc AS Ambiente, 
                      dbo.Database_Types.db_type_name + '\' + dbo.Data_Bases.db_name + '\' + dbo.Users.username AS Usuario, dbo.Users.active_user AS Activo, 
                      dbo.Users.user_critical AS Critico, dbo.Requests_Groups.rqst_grp_id AS IDGrupo, dbo.Requests_Groups.rqst_grp_name AS Grupo, 
                      dbo.Requests_Groups.rqst_grp_active AS GrupoActivo
FROM         dbo.Database_Types INNER JOIN
                      dbo.Data_Bases ON dbo.Database_Types.db_type_id = dbo.Data_Bases.db_type_id INNER JOIN
                      dbo.Databases_Users ON dbo.Data_Bases.db_id = dbo.Databases_Users.db_id INNER JOIN
                      dbo.Users INNER JOIN
                      dbo.User_Types ON dbo.Users.user_type_id = dbo.User_Types.user_type_id ON dbo.Databases_Users.user_id = dbo.Users.user_id INNER JOIN
                      dbo.Users_Passwords ON dbo.Users.user_password_id = dbo.Users_Passwords.user_password_id INNER JOIN
                      dbo.Rqst_Grps_Pwds ON dbo.Users_Passwords.user_password_id = dbo.Rqst_Grps_Pwds.user_password_id INNER JOIN
                      dbo.Requests_Groups ON dbo.Rqst_Grps_Pwds.rqst_grp_id = dbo.Requests_Groups.rqst_grp_id
GO
PRINT N'Creating [dbo].[vwPwdECRqstGrp]...';


GO

CREATE VIEW [dbo].[vwPwdECRqstGrp]
AS
SELECT     dbo.Rqst_Grps_Pwds.pwdrqst_grp_pwd_id AS ID, dbo.Users.user_id AS Folio, dbo.User_Types.user_type_id AS IDAmbiente, dbo.User_Types.user_type_desc AS Ambiente, 
                      dbo.Communication_Device_Types.cm_dv_type_name + '\' + dbo.Communication_Devices.cm_dv_name + '\' + dbo.Users.username AS Usuario, 
                      dbo.Users.active_user AS Activo, dbo.Users.user_critical AS Critico, dbo.Requests_Groups.rqst_grp_id AS IDGrupo, 
                      dbo.Requests_Groups.rqst_grp_name AS Grupo, dbo.Requests_Groups.rqst_grp_active AS GrupoActivo
FROM         dbo.Communication_Device_Types INNER JOIN
                      dbo.Communication_Devices ON dbo.Communication_Device_Types.cm_dv_type_id = dbo.Communication_Devices.cm_dv_type_id INNER JOIN
                      dbo.Communication_Device_Users ON dbo.Communication_Devices.cm_dv_id = dbo.Communication_Device_Users.cm_dv_id INNER JOIN
                      dbo.Users INNER JOIN
                      dbo.User_Types ON dbo.Users.user_type_id = dbo.User_Types.user_type_id ON 
                      dbo.Communication_Device_Users.user_id = dbo.Users.user_id INNER JOIN
                      dbo.Users_Passwords ON dbo.Users.user_password_id = dbo.Users_Passwords.user_password_id INNER JOIN
                      dbo.Rqst_Grps_Pwds ON dbo.Users_Passwords.user_password_id = dbo.Rqst_Grps_Pwds.user_password_id INNER JOIN
                      dbo.Requests_Groups ON dbo.Rqst_Grps_Pwds.rqst_grp_id = dbo.Requests_Groups.rqst_grp_id
GO
PRINT N'Creating [dbo].[vwPwdUnixRqstGrp]...';


GO


CREATE VIEW [dbo].[vwPwdUnixRqstGrp]
AS
SELECT     dbo.Rqst_Grps_Pwds.pwdrqst_grp_pwd_id AS ID, dbo.Users.user_id AS Folio, dbo.User_Types.user_type_id AS IDAmbiente, dbo.User_Types.user_type_desc AS Ambiente, 
                      dbo.Unix.unx_server_name + '\' + dbo.Users.username AS Usuario, dbo.Users.active_user AS Activo, dbo.Users.user_critical AS Critico, 
                      dbo.Requests_Groups.rqst_grp_id AS IDGrupo, dbo.Requests_Groups.rqst_grp_name AS Grupo, 
                      dbo.Requests_Groups.rqst_grp_active AS GrupoActivo
FROM         dbo.Users INNER JOIN
                      dbo.User_Types ON dbo.Users.user_type_id = dbo.User_Types.user_type_id INNER JOIN
                      dbo.Unix_users ON dbo.Users.user_id = dbo.Unix_users.user_id INNER JOIN
                      dbo.Unix ON dbo.Unix_users.unx_id = dbo.Unix.unx_id INNER JOIN
                      dbo.Users_Passwords ON dbo.Users.user_password_id = dbo.Users_Passwords.user_password_id INNER JOIN
                      dbo.Rqst_Grps_Pwds ON dbo.Users_Passwords.user_password_id = dbo.Rqst_Grps_Pwds.user_password_id INNER JOIN
                      dbo.Requests_Groups ON dbo.Rqst_Grps_Pwds.rqst_grp_id = dbo.Requests_Groups.rqst_grp_id
GO
PRINT N'Creating [dbo].[vwPwdWinRqstGrp]...';


GO
CREATE VIEW [dbo].[vwPwdWinRqstGrp]
AS
SELECT     dbo.Rqst_Grps_Pwds.pwdrqst_grp_pwd_id AS ID, dbo.Users.user_id AS Folio, dbo.User_Types.user_type_id AS IDAmbiente, dbo.User_Types.user_type_desc AS Ambiente, 
                      dbo.Win_Domains.nt_name + '\' + dbo.Win_PCs.pc_name + '\' + dbo.Users.username AS Usuario, dbo.Users.active_user AS Activo, 
                      dbo.Users.user_critical AS Critico, dbo.Requests_Groups.rqst_grp_id AS IDGrupo, dbo.Requests_Groups.rqst_grp_name AS Grupo, 
                      dbo.Requests_Groups.rqst_grp_active AS GrupoActivo
FROM         dbo.Win_PCs INNER JOIN
                      dbo.Win_Local_Users ON dbo.Win_PCs.win_pc_id = dbo.Win_Local_Users.win_pc_id INNER JOIN
                      dbo.Win_Domains ON dbo.Win_PCs.win_domain_id = dbo.Win_Domains.win_domain_id INNER JOIN
                      dbo.Users ON dbo.Win_Local_Users.user_id = dbo.Users.user_id INNER JOIN
                      dbo.User_Types ON dbo.Users.user_type_id = dbo.User_Types.user_type_id INNER JOIN
                      dbo.Users_Passwords ON dbo.Users.user_password_id = dbo.Users_Passwords.user_password_id INNER JOIN
                      dbo.Rqst_Grps_Pwds ON dbo.Users_Passwords.user_password_id = dbo.Rqst_Grps_Pwds.user_password_id INNER JOIN
                      dbo.Requests_Groups ON dbo.Rqst_Grps_Pwds.rqst_grp_id = dbo.Requests_Groups.rqst_grp_id
GO
PRINT N'Creating [dbo].[vwInventario]...';


GO

CREATE VIEW [dbo].[vwInventario]
AS
SELECT     Folio, Ambiente, Usuario COLLATE DATABASE_DEFAULT as Usuario, Activo, Critico
FROM         dbo.vwInventarioApp
UNION
SELECT     Folio, Ambiente, Usuario COLLATE DATABASE_DEFAULT as Usuario, Activo, Critico
FROM         dbo.vwInventarioUnix
UNION
SELECT     Folio, Ambiente, Usuario COLLATE DATABASE_DEFAULT as Usuario, Activo, Critico
FROM         dbo.vwInventarioDB
UNION
SELECT     Folio, Ambiente, Usuario COLLATE DATABASE_DEFAULT as Usuario, Activo, Critico
FROM         dbo.vwInventarioWin
UNION
SELECT     Folio, Ambiente, Usuario COLLATE DATABASE_DEFAULT as Usuario, Activo, Critico
FROM         dbo.vwInventarioAS400
UNION
SELECT     Folio, Ambiente, Usuario COLLATE DATABASE_DEFAULT as Usuario, Activo, Critico
FROM         vwInventarioEC
UNION
SELECT     Folio, Ambiente, Usuario COLLATE DATABASE_DEFAULT as Usuario, Activo, Critico
FROM         dbo.vwInventarioATM
GO
PRINT N'Creating [dbo].[vwPwdRqstGrp]...';


GO


CREATE VIEW [dbo].[vwPwdRqstGrp]
AS
SELECT     ID, Folio, IDAmbiente, Ambiente, Usuario COLLATE DATABASE_DEFAULT AS Usuario, Activo, Critico, IDGrupo, Grupo, GrupoActivo
FROM         dbo.vwPwdAppRqstGrp
UNION
SELECT     ID, Folio, IDAmbiente, Ambiente, Usuario COLLATE DATABASE_DEFAULT AS Usuario, Activo, Critico, IDGrupo, Grupo, GrupoActivo
FROM         dbo.vwPwdAS400RqstGrp
UNION
SELECT     ID, Folio, IDAmbiente, Ambiente, Usuario COLLATE DATABASE_DEFAULT AS Usuario, Activo, Critico, IDGrupo, Grupo, GrupoActivo
FROM         dbo.vwPwdATMRqstGrp
UNION
SELECT     ID, Folio, IDAmbiente, Ambiente, Usuario COLLATE DATABASE_DEFAULT AS Usuario, Activo, Critico, IDGrupo, Grupo, GrupoActivo
FROM         dbo.vwPwdDBRqstGrp
UNION
SELECT     ID, Folio, IDAmbiente, Ambiente, Usuario COLLATE DATABASE_DEFAULT AS Usuario, Activo, Critico, IDGrupo, Grupo, GrupoActivo
FROM         dbo.vwPwdECRqstGrp
UNION
SELECT     ID, Folio, IDAmbiente, Ambiente, Usuario COLLATE DATABASE_DEFAULT AS Usuario, Activo, Critico, IDGrupo, Grupo, GrupoActivo
FROM         dbo.vwPwdUnixRqstGrp AS vwPwdWinRqstGrp
GO
PRINT N'Creating [dbo].[Applications].[app_field1_desc].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Descripción de campo 1 de datos extra', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Applications', @level2type = N'COLUMN', @level2name = N'app_field1_desc';


GO
PRINT N'Creating [dbo].[Applications_Users].[app_field1_value].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'valor del campo 1 definido en el aplicativo', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Applications_Users', @level2type = N'COLUMN', @level2name = N'app_field1_value';


GO
PRINT N'Creating [dbo].[Applications_Users].[app_field2_value].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'valor del campo 2 definido en el aplicativo', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Applications_Users', @level2type = N'COLUMN', @level2name = N'app_field2_value';


GO
PRINT N'Creating [dbo].[Applications_Users].[app_field3_value].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'valor del campo 3 definido en el aplicativo', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Applications_Users', @level2type = N'COLUMN', @level2name = N'app_field3_value';


GO
PRINT N'Creating [dbo].[audit_usuarios].[operacion].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Indica si es A(alta) B(baja) o M(modificacion)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'audit_usuarios', @level2type = N'COLUMN', @level2name = N'operacion';


GO
PRINT N'Creating [dbo].[audit_usuarios].[terminal_abm].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Terminal desde donde se hace el ABM', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'audit_usuarios', @level2type = N'COLUMN', @level2name = N'terminal_abm';


GO
PRINT N'Creating [dbo].[Data_Bases].[db_server_ip1].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Primer valor de la dir IP', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Data_Bases', @level2type = N'COLUMN', @level2name = N'db_server_ip1';


GO
PRINT N'Creating [dbo].[Data_Bases].[db_server_ip2].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Segundo valor de la dir IP', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Data_Bases', @level2type = N'COLUMN', @level2name = N'db_server_ip2';


GO
PRINT N'Creating [dbo].[Data_Bases].[db_server_ip3].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Tercer valor de la dir IP', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Data_Bases', @level2type = N'COLUMN', @level2name = N'db_server_ip3';


GO
PRINT N'Creating [dbo].[Data_Bases].[db_server_ip4].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Cuarto  valor de la dir IP', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Data_Bases', @level2type = N'COLUMN', @level2name = N'db_server_ip4';


GO
PRINT N'Creating [dbo].[Delegation_Requests].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Grupos de usuarios habilitados para delegación de permisos con sus restricciones', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Delegation_Requests';


GO
PRINT N'Creating [dbo].[Devices].[dv_type_id].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Primer valor de la dir IP', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Devices', @level2type = N'COLUMN', @level2name = N'dv_type_id';


GO
PRINT N'Creating [dbo].[Devices].[dv_ip1].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Primer valor de la dir IP', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Devices', @level2type = N'COLUMN', @level2name = N'dv_ip1';


GO
PRINT N'Creating [dbo].[Devices].[dv_ip2].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Segundo valor de la dir IP', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Devices', @level2type = N'COLUMN', @level2name = N'dv_ip2';


GO
PRINT N'Creating [dbo].[Devices].[dv_ip3].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Tercer valor de la dir IP', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Devices', @level2type = N'COLUMN', @level2name = N'dv_ip3';


GO
PRINT N'Creating [dbo].[Devices].[dv_ip4].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Cuarto  valor de la dir IP', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Devices', @level2type = N'COLUMN', @level2name = N'dv_ip4';


GO
PRINT N'Creating [dbo].[Global_Win_Groups].[win_domain_id].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'dominio al que pertenece el grupo', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Global_Win_Groups', @level2type = N'COLUMN', @level2name = N'win_domain_id';


GO
PRINT N'Creating [dbo].[hist_change_password].[phx_user_id].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Id del usuario que la cambió. Puede ser null por si el que la cambio fue un proceso', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'hist_change_password', @level2type = N'COLUMN', @level2name = N'phx_user_id';


GO
PRINT N'Creating [dbo].[mail_alert].[mail_send_attemp].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Nro de intento de envío del mail', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'mail_alert', @level2type = N'COLUMN', @level2name = N'mail_send_attemp';


GO
PRINT N'Creating [dbo].[Passwords_Requests].[user_password_id].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Password consultado', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Passwords_Requests', @level2type = N'COLUMN', @level2name = N'user_password_id';


GO
PRINT N'Creating [dbo].[Phx_Log].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Tabla para log del sistema', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Phx_Log';


GO
PRINT N'Creating [dbo].[Phx_Log].[log_type].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'tipo de log: W: warning - E: error - I: information - A: audit', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Phx_Log', @level2type = N'COLUMN', @level2name = N'log_type';


GO
PRINT N'Creating [dbo].[Phx_Log].[Code].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'codigo de error', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Phx_Log', @level2type = N'COLUMN', @level2name = N'Code';


GO
PRINT N'Creating [dbo].[Phx_Log].[source].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'origen del log (funcion, programa, etc)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Phx_Log', @level2type = N'COLUMN', @level2name = N'source';


GO
PRINT N'Creating [dbo].[Phx_Roles].[role_code].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Código del Rol. Para no estar pendiente del ID ya que es identity', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Phx_Roles', @level2type = N'COLUMN', @level2name = N'role_code';


GO
PRINT N'Creating [dbo].[Phx_Users].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Usuarios de algún módulo del sistema. Con seguridad integrada con windows serían usuarios de Windows', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Phx_Users';


GO
PRINT N'Creating [dbo].[Phx_Users].[username].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'nombre de usuario. En un principio sería el usuario del dominio', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Phx_Users', @level2type = N'COLUMN', @level2name = N'username';


GO
PRINT N'Creating [dbo].[Phx_Users].[fullname].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'nombre completo del usuario', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Phx_Users', @level2type = N'COLUMN', @level2name = N'fullname';


GO
PRINT N'Creating [dbo].[Phx_Users].[user_domain].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Dominio al cual pertenece el usuario. El nombre del dominio será en formato NT Domain', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Phx_Users', @level2type = N'COLUMN', @level2name = N'user_domain';


GO
PRINT N'Creating [dbo].[Phx_Users].[delete_date].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'fecha de baja', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Phx_Users', @level2type = N'COLUMN', @level2name = N'delete_date';


GO
PRINT N'Creating [dbo].[Phx_Users].[phx_user_file_number].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'legajo', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Phx_Users', @level2type = N'COLUMN', @level2name = N'phx_user_file_number';


GO
PRINT N'Creating [dbo].[Phx_Users].[phx_user_relation_type].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'relacion laboral - I=interno - E=Externo - P=Proveedor', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Phx_Users', @level2type = N'COLUMN', @level2name = N'phx_user_relation_type';


GO
PRINT N'Creating [dbo].[Phx_Users].[phx_user_function].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'funcion - perfil laboral', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Phx_Users', @level2type = N'COLUMN', @level2name = N'phx_user_function';


GO
PRINT N'Creating [dbo].[Phx_Users].[phx_user_building_adress].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Domicilio Edificio', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Phx_Users', @level2type = N'COLUMN', @level2name = N'phx_user_building_adress';


GO
PRINT N'Creating [dbo].[Phx_Users].[phx_user_building_floor].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'piso', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Phx_Users', @level2type = N'COLUMN', @level2name = N'phx_user_building_floor';


GO
PRINT N'Creating [dbo].[Phx_Users].[phx_user_extension_number].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'interno', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Phx_Users', @level2type = N'COLUMN', @level2name = N'phx_user_extension_number';


GO
PRINT N'Creating [dbo].[Pwd_Lock_types].[pwd_lock_type_code].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Código interno del tipo de lockeo', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Pwd_Lock_types', @level2type = N'COLUMN', @level2name = N'pwd_lock_type_code';


GO
PRINT N'Creating [dbo].[Request_States].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Estados de las solicitudes', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Request_States';


GO
PRINT N'Creating [dbo].[Requests].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Se almacenan todas las consultas de passwords y delegación de permisos hechos por los usuarios', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Requests';


GO
PRINT N'Creating [dbo].[Requests].[rqst_user_id].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Usuario que realizó la consulta', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Requests', @level2type = N'COLUMN', @level2name = N'rqst_user_id';


GO
PRINT N'Creating [dbo].[Requests].[request_date].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Fecha en que se hizo la solicitud', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Requests', @level2type = N'COLUMN', @level2name = N'request_date';


GO
PRINT N'Creating [dbo].[Requests].[auth1_usr_id].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Usuario Autorizador 1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Requests', @level2type = N'COLUMN', @level2name = N'auth1_usr_id';


GO
PRINT N'Creating [dbo].[Requests].[auth1_date].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'fecha en que el autorizador 1 autorizó', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Requests', @level2type = N'COLUMN', @level2name = N'auth1_date';


GO
PRINT N'Creating [dbo].[Requests].[auth2_usr_id].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Usuario Autorizador 2', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Requests', @level2type = N'COLUMN', @level2name = N'auth2_usr_id';


GO
PRINT N'Creating [dbo].[Requests].[auth2_date].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'fecha en que el autorizador 2 autorizó', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Requests', @level2type = N'COLUMN', @level2name = N'auth2_date';


GO
PRINT N'Creating [dbo].[Requests].[rqst_state_id].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Estado en que se encuentra la solicitud', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Requests', @level2type = N'COLUMN', @level2name = N'rqst_state_id';


GO
PRINT N'Creating [dbo].[Requests].[hours_requested].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'cantidad de horas solicitadas', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Requests', @level2type = N'COLUMN', @level2name = N'hours_requested';


GO
PRINT N'Creating [dbo].[Requests].[unit_requested].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'h = horas    d = dias   - Unidad de tiempo', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Requests', @level2type = N'COLUMN', @level2name = N'unit_requested';


GO
PRINT N'Creating [dbo].[Requests].[hours_given].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Cantidad de horas concedidas', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Requests', @level2type = N'COLUMN', @level2name = N'hours_given';


GO
PRINT N'Creating [dbo].[Requests].[unit_given].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'h = horas    d = dias   - Unidad de tiempo', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Requests', @level2type = N'COLUMN', @level2name = N'unit_given';


GO
PRINT N'Creating [dbo].[Requests].[request_desc].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Descripción de la solicitud', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Requests', @level2type = N'COLUMN', @level2name = N'request_desc';


GO
PRINT N'Creating [dbo].[Requests].[auth_desc].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Motivo del rechazo', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Requests', @level2type = N'COLUMN', @level2name = N'auth_desc';


GO
PRINT N'Creating [dbo].[Requests].[return_usr_id].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Usuario que devuelve la contraseña. Si es igual al rqst_user_id la devuelve el mismo solicitante', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Requests', @level2type = N'COLUMN', @level2name = N'return_usr_id';


GO
PRINT N'Creating [dbo].[Requests_Groups].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Los query groups son los grupos de usuarios que se relacionan con la consulta de passwords', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Requests_Groups';


GO
PRINT N'Creating [dbo].[Requests_Groups].[rqst_grp_name].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Nombre del grupo', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Requests_Groups', @level2type = N'COLUMN', @level2name = N'rqst_grp_name';


GO
PRINT N'Creating [dbo].[Rqst_Grps_Deleg].[auth1_usr_id].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Autorizador 1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Rqst_Grps_Deleg', @level2type = N'COLUMN', @level2name = N'auth1_usr_id';


GO
PRINT N'Creating [dbo].[Rqst_Grps_Deleg].[auth2_usr_id].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Autorizador 2', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Rqst_Grps_Deleg', @level2type = N'COLUMN', @level2name = N'auth2_usr_id';


GO
PRINT N'Creating [dbo].[Rqst_Grps_Pwds].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Passwords a las que tiene acceso cada Grupo con sus restricciones', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Rqst_Grps_Pwds';


GO
PRINT N'Creating [dbo].[Rqst_Grps_Pwds].[auth1_usr_id].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Usuario autorizador 1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Rqst_Grps_Pwds', @level2type = N'COLUMN', @level2name = N'auth1_usr_id';


GO
PRINT N'Creating [dbo].[Rqst_Grps_Pwds].[auth2_usr_id].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Usuario autorizador 2', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Rqst_Grps_Pwds', @level2type = N'COLUMN', @level2name = N'auth2_usr_id';


GO
PRINT N'Creating [dbo].[Unix].[unx_server_ip1].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Primer valor de la dir IP', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Unix', @level2type = N'COLUMN', @level2name = N'unx_server_ip1';


GO
PRINT N'Creating [dbo].[Unix].[unx_server_ip2].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Segundo valor de la dir IP', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Unix', @level2type = N'COLUMN', @level2name = N'unx_server_ip2';


GO
PRINT N'Creating [dbo].[Unix].[unx_server_ip3].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Tercer valor de la dir IP', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Unix', @level2type = N'COLUMN', @level2name = N'unx_server_ip3';


GO
PRINT N'Creating [dbo].[Unix].[unx_server_ip4].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Cuarto  valor de la dir IP', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Unix', @level2type = N'COLUMN', @level2name = N'unx_server_ip4';


GO
PRINT N'Creating [dbo].[User_Types].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Tipos de usuarios de quienes se administran las passwords', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'User_Types';


GO
PRINT N'Creating [dbo].[User_Types].[user_type_desc].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'tipo de usuario (usuario local windows, usuario de dominio windows, usuario de SQL Server, usuario Unix, etc)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'User_Types', @level2type = N'COLUMN', @level2name = N'user_type_desc';


GO
PRINT N'Creating [dbo].[Users].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Esta tabla contiene a los usuarios de los que se les administrará su password', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Users';


GO
PRINT N'Creating [dbo].[Users].[active_user].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'indica si esta cuenta está activa', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Users', @level2type = N'COLUMN', @level2name = N'active_user';


GO
PRINT N'Creating [dbo].[Users].[user_type_id].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Indica el tipo de usuario (de dominio, de sql server, local de una workstation)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Users', @level2type = N'COLUMN', @level2name = N'user_type_id';


GO
PRINT N'Creating [dbo].[Users].[user_desc].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Descripción del uso del usuario', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Users', @level2type = N'COLUMN', @level2name = N'user_desc';


GO
PRINT N'Creating [dbo].[Users].[user_critical].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'este campo indica si es usuario crítico - 1 = critico - 0= no', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Users', @level2type = N'COLUMN', @level2name = N'user_critical';


GO
PRINT N'Creating [dbo].[Users_Passwords].[password].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'campo de contraseña pensado para encriptación de 448 bits (56 bytes o 112 chars hexa)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Users_Passwords', @level2type = N'COLUMN', @level2name = N'password';


GO
PRINT N'Creating [dbo].[Users_Passwords].[static_pwd].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'indica si la clave es estática (1: si - 0: no)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Users_Passwords', @level2type = N'COLUMN', @level2name = N'static_pwd';


GO
PRINT N'Creating [dbo].[Users_Passwords].[d_next_change].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'indica la fecha en que se debe hacer le próximo cambio de la pwd', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Users_Passwords', @level2type = N'COLUMN', @level2name = N'd_next_change';


GO
PRINT N'Creating [dbo].[Users_Passwords].[d_last_change].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'fecha en que se cambió el pwd por última vez', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Users_Passwords', @level2type = N'COLUMN', @level2name = N'd_last_change';


GO
PRINT N'Creating [dbo].[Users_Passwords].[change_freq].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'frecuencia de cambio. esta es la cantidad. luego se ve en el campo que indica la unidad de medida', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Users_Passwords', @level2type = N'COLUMN', @level2name = N'change_freq';


GO
PRINT N'Creating [dbo].[Users_Passwords].[change_freq_unit].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'unidad de medida de la frecuencia del cambio (H: hrs - D: días - W:semanas - M: meses - Y: años)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Users_Passwords', @level2type = N'COLUMN', @level2name = N'change_freq_unit';


GO
PRINT N'Creating [dbo].[Users_Passwords].[d_next_chk].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'fecha en que se debe realizar el próximo chequee de no alteración de pwd', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Users_Passwords', @level2type = N'COLUMN', @level2name = N'd_next_chk';


GO
PRINT N'Creating [dbo].[Users_Passwords].[d_last_chk].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'fecha en que se chequeó por última vez la contraseña', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Users_Passwords', @level2type = N'COLUMN', @level2name = N'd_last_chk';


GO
PRINT N'Creating [dbo].[Users_Passwords].[chk_freq].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'frecuencia de chequeo. esta es la cantidad. luego se ve en el campo que indica la unidad de medida', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Users_Passwords', @level2type = N'COLUMN', @level2name = N'chk_freq';


GO
PRINT N'Creating [dbo].[Users_Passwords].[chk_freq_unit].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'unidad de medida de la frecuencia de chequeo (H: hrs - D: días - W:semanas - M: meses - Y: años)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Users_Passwords', @level2type = N'COLUMN', @level2name = N'chk_freq_unit';


GO
PRINT N'Creating [dbo].[Users_Passwords].[pwd_lock_type_id].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'id del tipo de lockeo que tiene la contraseña', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Users_Passwords', @level2type = N'COLUMN', @level2name = N'pwd_lock_type_id';


GO
PRINT N'Creating [dbo].[Users_Passwords].[chk_pwd].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Indica si la contraseña debe ser chequeada', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Users_Passwords', @level2type = N'COLUMN', @level2name = N'chk_pwd';


GO
PRINT N'Creating [dbo].[Users_Passwords].[d_lock_pwd].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Fecha en que se lockeó la contraseña', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Users_Passwords', @level2type = N'COLUMN', @level2name = N'd_lock_pwd';


GO
PRINT N'Creating [dbo].[Users_Passwords].[d_in_use_until].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Fecha hasta que la contraseña está en uso por visualización. Lock type debe tener lockeo por contraseña en uso', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Users_Passwords', @level2type = N'COLUMN', @level2name = N'd_in_use_until';


GO
PRINT N'Creating [dbo].[Users_Passwords].[concurrent].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Indica si la contraseña puede ser visualizada por mas de una persona a la vez', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Users_Passwords', @level2type = N'COLUMN', @level2name = N'concurrent';


GO
PRINT N'Creating [dbo].[vwCantFollowRqstGrpPwd].[MS_DiagramPane1]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "frgp1"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 108
               Right = 214
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vwCantFollowRqstGrpPwd';


GO
PRINT N'Creating [dbo].[vwCantFollowRqstGrpPwd].[MS_DiagramPaneCount]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 1, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vwCantFollowRqstGrpPwd';


GO
PRINT N'Creating [dbo].[vwCantRqstGrpPwd].[MS_DiagramPane1]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "rgp1"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 141
               Right = 228
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vwCantRqstGrpPwd';


GO
PRINT N'Creating [dbo].[vwCantRqstGrpPwd].[MS_DiagramPaneCount]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 1, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vwCantRqstGrpPwd';


GO
PRINT N'Creating [dbo].[Win_Domain_Controllers].[win_domain_id].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'dominio al que corresponde el domain controller', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Win_Domain_Controllers', @level2type = N'COLUMN', @level2name = N'win_domain_id';


GO
PRINT N'Creating [dbo].[Win_Domain_Controllers].[dc_type].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'tipo de DC, P: primary - B: backup', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Win_Domain_Controllers', @level2type = N'COLUMN', @level2name = N'dc_type';


GO
PRINT N'Creating [dbo].[Win_Domain_Controllers].[impersonate_user_id].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'usuario que se usa para hacer el impersonate', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Win_Domain_Controllers', @level2type = N'COLUMN', @level2name = N'impersonate_user_id';


GO
PRINT N'Creating [dbo].[Win_Domain_Users].[user_domain_id].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'id asignado para el usuario en el dominio por el domain controller', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Win_Domain_Users', @level2type = N'COLUMN', @level2name = N'user_domain_id';


GO
PRINT N'Creating [dbo].[Win_Domains].[nt_name].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'nombre del dominio según formato NT', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Win_Domains', @level2type = N'COLUMN', @level2name = N'nt_name';


GO
PRINT N'Creating [dbo].[Win_Domains].[ad_name].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'nombre del dominio según formato active directory', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Win_Domains', @level2type = N'COLUMN', @level2name = N'ad_name';


GO
PRINT N'Creating [dbo].[Win_Groups].[ad_group_name].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'nobre del grupo de 64 caracteres para active directory', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Win_Groups', @level2type = N'COLUMN', @level2name = N'ad_group_name';


GO
PRINT N'Creating [dbo].[Win_Groups].[nt_group_name].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'nombre del grupo compatible con dominios nt', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Win_Groups', @level2type = N'COLUMN', @level2name = N'nt_group_name';


GO
PRINT N'Creating [dbo].[Win_Local_Users].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Subtipo de Users. Es para usuario Locales de una PC', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Win_Local_Users';


GO
PRINT N'Creating [dbo].[Win_PCs].[win_domain_id].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'dominio al que pertenece la PC', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Win_PCs', @level2type = N'COLUMN', @level2name = N'win_domain_id';


GO
-- Refactoring step to update target server with deployed transaction logs
CREATE TABLE  [dbo].[__RefactorLog] (OperationKey UNIQUEIDENTIFIER NOT NULL PRIMARY KEY)
GO
sp_addextendedproperty N'microsoft_database_tools_support', N'refactoring log', N'schema', N'dbo', N'table', N'__RefactorLog'
GO

GO
/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

GO
PRINT N'Checking existing data against newly created constraints';


GO
USE [$(DatabaseName)];


GO
ALTER TABLE [dbo].[Applications_Users] WITH CHECK CHECK CONSTRAINT [FK_Applications_Users_Applications];

ALTER TABLE [dbo].[Applications_Users] WITH CHECK CHECK CONSTRAINT [FK_Applications_Users_Users];

ALTER TABLE [dbo].[AS400_users] WITH CHECK CHECK CONSTRAINT [FK_AS400_users_AS400];

ALTER TABLE [dbo].[AS400_users] WITH CHECK CHECK CONSTRAINT [FK_AS400_users_Users];

ALTER TABLE [dbo].[ATMs_Users] WITH CHECK CHECK CONSTRAINT [FK_ATMs_Users_Users];

ALTER TABLE [dbo].[audit_login] WITH CHECK CHECK CONSTRAINT [FK_audit_login_audit_application];

ALTER TABLE [dbo].[audit_login] WITH CHECK CHECK CONSTRAINT [FK_audit_login_evento_login];

ALTER TABLE [dbo].[audit_login_historico] WITH CHECK CHECK CONSTRAINT [FK_audit_login_historico_audit_application];

ALTER TABLE [dbo].[audit_login_historico] WITH CHECK CHECK CONSTRAINT [FK_audit_login_historico_evento_login];

ALTER TABLE [dbo].[audit_usuarios] WITH CHECK CHECK CONSTRAINT [FK_audit_usuarios_audit_phx_user_new];

ALTER TABLE [dbo].[audit_usuarios] WITH CHECK CHECK CONSTRAINT [FK_audit_usuarios_audit_phx_user_old];

ALTER TABLE [dbo].[Communication_Device_User_Protocol] WITH CHECK CHECK CONSTRAINT [FK_Communication_Device_User_Protocol_Communication_Device_Protocols];

ALTER TABLE [dbo].[Communication_Device_User_Protocol] WITH CHECK CHECK CONSTRAINT [FK_Communication_Device_User_Protocol_Communication_Device_Users];

ALTER TABLE [dbo].[Communication_Device_Users] WITH CHECK CHECK CONSTRAINT [FK_Communication_Device_Users_Communication_Devices];

ALTER TABLE [dbo].[Communication_Device_Users] WITH CHECK CHECK CONSTRAINT [FK_Communication_Device_Users_Users];

ALTER TABLE [dbo].[Communication_Devices] WITH CHECK CHECK CONSTRAINT [FK_Communication_Devices_Communication_Device_Types];

ALTER TABLE [dbo].[Data_Bases] WITH CHECK CHECK CONSTRAINT [FK_Data_Bases_DataBase_Types];

ALTER TABLE [dbo].[Data_Bases] WITH CHECK CHECK CONSTRAINT [FK_Data_Bases_Unix];

ALTER TABLE [dbo].[Data_Bases] WITH CHECK CHECK CONSTRAINT [FK_Data_Bases_Win_PCs];

ALTER TABLE [dbo].[Databases_Users] WITH CHECK CHECK CONSTRAINT [FK_Databases_Users_Data_Bases];

ALTER TABLE [dbo].[Databases_Users] WITH CHECK CHECK CONSTRAINT [FK_Databases_Users_Users];

ALTER TABLE [dbo].[Delegation_Requests] WITH CHECK CHECK CONSTRAINT [FK_Delegation_Requests_Requests];

ALTER TABLE [dbo].[Delegation_Requests] WITH CHECK CHECK CONSTRAINT [FK_Delegation_Requests_Win_Groups];

ALTER TABLE [dbo].[Devices] WITH CHECK CHECK CONSTRAINT [FK_Devices_Devices_types];

ALTER TABLE [dbo].[Devices_users] WITH CHECK CHECK CONSTRAINT [FK_Devices_users_Devices];

ALTER TABLE [dbo].[Devices_users] WITH CHECK CHECK CONSTRAINT [FK_Devices_users_Users];

ALTER TABLE [dbo].[followup_request_group_default] WITH CHECK CHECK CONSTRAINT [FK_followup_request_group_default_followup_request_group];

ALTER TABLE [dbo].[followup_request_group_default] WITH CHECK CHECK CONSTRAINT [FK_followup_request_group_default_User_Types];

ALTER TABLE [dbo].[followup_request_group_password] WITH CHECK CHECK CONSTRAINT [FK_followup_request_group_password_followup_request_group];

ALTER TABLE [dbo].[followup_request_group_password] WITH CHECK CHECK CONSTRAINT [FK_followup_request_group_password_Users_Passwords];

ALTER TABLE [dbo].[followup_request_group_user] WITH CHECK CHECK CONSTRAINT [FK_followup_rqst_grp_user_followup_request_group];

ALTER TABLE [dbo].[followup_request_group_user] WITH CHECK CHECK CONSTRAINT [FK_followup_rqst_grp_user_Phx_Users];

ALTER TABLE [dbo].[Global_Win_Groups] WITH CHECK CHECK CONSTRAINT [FK_Global_Win_Groups_Win_Domains];

ALTER TABLE [dbo].[Global_Win_Groups] WITH CHECK CHECK CONSTRAINT [FK_Global_Win_Groups_Win_Groups];

ALTER TABLE [dbo].[hist_change_password] WITH CHECK CHECK CONSTRAINT [FK_hist_change_password_Phx_Users];

ALTER TABLE [dbo].[hist_change_password] WITH CHECK CHECK CONSTRAINT [FK_hist_change_password_Users];

ALTER TABLE [dbo].[hist_change_password_historico] WITH CHECK CHECK CONSTRAINT [FK_hist_change_password_historico_Phx_Users];

ALTER TABLE [dbo].[hist_change_password_historico] WITH CHECK CHECK CONSTRAINT [FK_hist_change_password_historico_Users];

ALTER TABLE [dbo].[item_lote_chk_win_local_users] WITH CHECK CHECK CONSTRAINT [FK_item_lote_chk_win_local_users_accion_item_chk_win_local_user];

ALTER TABLE [dbo].[item_lote_chk_win_local_users] WITH CHECK CHECK CONSTRAINT [FK_item_lote_chk_win_local_users_lote_chk_win_local_users];

ALTER TABLE [dbo].[item_lote_chk_win_local_users] WITH CHECK CHECK CONSTRAINT [FK_item_lote_chk_win_local_users_Win_Local_Users];

ALTER TABLE [dbo].[Local_Win_Groups] WITH CHECK CHECK CONSTRAINT [FK_Local_Win_Groups_Win_Groups];

ALTER TABLE [dbo].[Local_Win_Groups] WITH CHECK CHECK CONSTRAINT [FK_Local_Win_Groups_Win_PCs];

ALTER TABLE [dbo].[mail_alert] WITH CHECK CHECK CONSTRAINT [FK_mail_alert_Mail_type];

ALTER TABLE [dbo].[Passwords_Requests] WITH CHECK CHECK CONSTRAINT [FK_Passwords_Requests_Requests];

ALTER TABLE [dbo].[Passwords_Requests] WITH CHECK CHECK CONSTRAINT [FK_Passwords_Requests_Users_Passwords];

ALTER TABLE [dbo].[phx_privilege] WITH CHECK CHECK CONSTRAINT [FK_phx_privilege_phx_privilege_group];

ALTER TABLE [dbo].[phx_privilege_role] WITH CHECK CHECK CONSTRAINT [FK_phx_privilege_role_phx_privilege];

ALTER TABLE [dbo].[phx_privilege_role] WITH CHECK CHECK CONSTRAINT [FK_phx_privilege_role_Phx_Roles];

ALTER TABLE [dbo].[Phx_Roles_Users] WITH CHECK CHECK CONSTRAINT [FK_Phx_Roles_Users_Phx_Roles];

ALTER TABLE [dbo].[Phx_Roles_Users] WITH CHECK CHECK CONSTRAINT [FK_Phx_Roles_Users_Phx_Users];

ALTER TABLE [dbo].[Phx_Users] WITH CHECK CHECK CONSTRAINT [FK_Phx_Users_Phx_User_Superior];

ALTER TABLE [dbo].[Phx_Users_Groups] WITH CHECK CHECK CONSTRAINT [FK_Phx_Users_Groups_Phx_Users];

ALTER TABLE [dbo].[Phx_Users_Groups] WITH CHECK CHECK CONSTRAINT [FK_Phx_Users_Groups_Qry_Groups];

ALTER TABLE [dbo].[Protocol_Communication_Device] WITH CHECK CHECK CONSTRAINT [FK_Protocol_Communication_Device_Communication_Device_Protocols];

ALTER TABLE [dbo].[Protocol_Communication_Device] WITH CHECK CHECK CONSTRAINT [FK_Protocol_Communication_Device_Communication_Devices];

ALTER TABLE [dbo].[Requests] WITH CHECK CHECK CONSTRAINT [FK_Password_Requests_Request_States];

ALTER TABLE [dbo].[Requests] WITH CHECK CHECK CONSTRAINT [FK_Password_Requests_rqst_User];

ALTER TABLE [dbo].[Requests] WITH CHECK CHECK CONSTRAINT [FK_Requests_Phx_Auth1_Users];

ALTER TABLE [dbo].[Requests] WITH CHECK CHECK CONSTRAINT [FK_Requests_Phx_Auth2_Users];

ALTER TABLE [dbo].[Requests] WITH CHECK CHECK CONSTRAINT [FK_Requests_Return_User];

ALTER TABLE [dbo].[Requests_Notes] WITH CHECK CHECK CONSTRAINT [FK_Requests_Notes_Phx_Users];

ALTER TABLE [dbo].[Requests_Notes] WITH CHECK CHECK CONSTRAINT [FK_Requests_Notes_Requests];

ALTER TABLE [dbo].[Rqst_Grps_Deleg] WITH CHECK CHECK CONSTRAINT [FK_Rqst_Grps_Deleg_Phx_Auth1Users];

ALTER TABLE [dbo].[Rqst_Grps_Deleg] WITH CHECK CHECK CONSTRAINT [FK_Rqst_Grps_Deleg_Phx_Auth2Users];

ALTER TABLE [dbo].[Rqst_Grps_Deleg] WITH CHECK CHECK CONSTRAINT [FK_Rqst_Grps_Deleg_Requests_Groups];

ALTER TABLE [dbo].[Rqst_Grps_Deleg] WITH CHECK CHECK CONSTRAINT [FK_Rqst_Grps_Deleg_Win_Groups];

ALTER TABLE [dbo].[Rqst_Grps_Pwds] WITH CHECK CHECK CONSTRAINT [FK_Qry_Grps_Pwds_Phx_Users_Auth1];

ALTER TABLE [dbo].[Rqst_Grps_Pwds] WITH CHECK CHECK CONSTRAINT [FK_Qry_Grps_Pwds_Phx_Users_Auth2];

ALTER TABLE [dbo].[Rqst_Grps_Pwds] WITH CHECK CHECK CONSTRAINT [FK_Qry_Grps_Pwds_Qry_Groups];

ALTER TABLE [dbo].[Rqst_Grps_Pwds] WITH CHECK CHECK CONSTRAINT [FK_Qry_Grps_Pwds_Users_Passwords];

ALTER TABLE [dbo].[ticket_notificacion_clave] WITH CHECK CHECK CONSTRAINT [FK_ticket_notificacion_clave_aplicacion_notificacion_clave];

ALTER TABLE [dbo].[Unix_users] WITH CHECK CHECK CONSTRAINT [FK_Unix_users_Unix];

ALTER TABLE [dbo].[Users] WITH CHECK CHECK CONSTRAINT [FK_Users_User_Types];

ALTER TABLE [dbo].[Users] WITH CHECK CHECK CONSTRAINT [FK_Users_Users_Passwords];

ALTER TABLE [dbo].[Users_Passwords] WITH CHECK CHECK CONSTRAINT [FK_Users_Passwords_Pwd_Lock_types];

ALTER TABLE [dbo].[Win_Domain_Controllers] WITH CHECK CHECK CONSTRAINT [FK_Win_Domain_Controllers_Win_Domain_Users];

ALTER TABLE [dbo].[Win_Domain_Controllers] WITH CHECK CHECK CONSTRAINT [FK_Win_Domain_Controllers_Win_Domains];

ALTER TABLE [dbo].[Win_Domain_Controllers] WITH CHECK CHECK CONSTRAINT [FK_Win_Domain_Controllers_Win_PCs];

ALTER TABLE [dbo].[Win_Domain_Users] WITH CHECK CHECK CONSTRAINT [FK_Win_Domain_Users_Users];

ALTER TABLE [dbo].[Win_Domain_Users] WITH CHECK CHECK CONSTRAINT [FK_Win_Domain_Users_Win_Domains];

ALTER TABLE [dbo].[Win_Local_Users] WITH CHECK CHECK CONSTRAINT [FK_Win_Local_Users_Users];

ALTER TABLE [dbo].[Win_Local_Users] WITH CHECK CHECK CONSTRAINT [FK_Win_Local_Users_Win_PCs];

ALTER TABLE [dbo].[Win_PCs] WITH CHECK CHECK CONSTRAINT [FK_Win_PCs_Win_Domains];


GO
ALTER DATABASE [$(DatabaseName)]
    SET MULTI_USER 
    WITH ROLLBACK IMMEDIATE;


GO
