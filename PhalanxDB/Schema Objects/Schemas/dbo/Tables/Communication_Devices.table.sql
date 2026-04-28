CREATE TABLE [dbo].[Communication_Devices] (
    [cm_dv_id]          INT           IDENTITY (1, 1) NOT NULL,
    [cm_dv_name]        VARCHAR (100) COLLATE Latin1_General_CI_AS NOT NULL,
    [cm_dv_ip]          VARCHAR (15)  NOT NULL,
    [cm_dv_type_id]     INT           NOT NULL,
    [cm_dv_description] VARCHAR (200) NULL,
    [cm_dv_active]      TINYINT       NOT NULL
);

