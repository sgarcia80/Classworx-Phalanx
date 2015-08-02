CREATE TABLE [dbo].[phx_version] (
    [phx_version_id]      INT          IDENTITY (1, 1) NOT NULL,
    [version]             VARCHAR (20) NOT NULL,
    [implementation_date] DATETIME     NOT NULL
);

