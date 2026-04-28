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

