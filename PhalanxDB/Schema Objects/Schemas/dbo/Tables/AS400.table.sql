CREATE TABLE [dbo].[AS400] (
    [as_id]          INT           IDENTITY (1, 1) NOT NULL,
    [as_server_name] VARCHAR (100) COLLATE Latin1_General_CI_AS NOT NULL,
    [as_desc]        VARCHAR (200) COLLATE Latin1_General_CI_AS NULL,
    [as_ip]          VARCHAR (15)  COLLATE Latin1_General_CI_AS NULL,
    [active]         BIT           NOT NULL
);

