CREATE TABLE [dbo].[Requests_Notes] (
    [request_note_id]      INT           IDENTITY (1, 1) NOT NULL,
    [request_id]           INT           NOT NULL,
    [phx_user_id]          INT           NOT NULL,
    [request_note_date]    DATETIME      NOT NULL,
    [request_note_descrip] VARCHAR (200) COLLATE Latin1_General_CI_AS NOT NULL
);

