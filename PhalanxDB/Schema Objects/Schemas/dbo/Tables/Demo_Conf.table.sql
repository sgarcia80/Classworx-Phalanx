CREATE TABLE [dbo].[Demo_Conf] (
    [demo_conf_id] INT           IDENTITY (1, 1) NOT NULL,
    [conf_code]    VARCHAR (50)  COLLATE Latin1_General_CI_AS NOT NULL,
    [conf_value]   VARCHAR (100) COLLATE Latin1_General_CI_AS NULL
);

