CREATE TABLE [dbo].[Database_Types] (
    [db_type_id]   INT           IDENTITY (1, 1) NOT NULL,
    [db_type_code] VARCHAR (50)  COLLATE Latin1_General_CI_AS NOT NULL,
    [db_type_name] VARCHAR (100) COLLATE Latin1_General_CI_AS NOT NULL
);

