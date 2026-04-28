CREATE TABLE [dbo].[Devices_types] (
    [dv_type_id]   INT          IDENTITY (1, 1) NOT NULL,
    [dv_type_code] VARCHAR (50) COLLATE Latin1_General_CI_AS NOT NULL,
    [dv_type_desc] VARCHAR (50) COLLATE Latin1_General_CI_AS NOT NULL
);

