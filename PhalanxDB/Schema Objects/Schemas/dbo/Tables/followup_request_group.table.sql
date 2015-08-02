CREATE TABLE [dbo].[followup_request_group] (
    [frg_id]     INT          IDENTITY (1, 1) NOT NULL,
    [frg_name]   VARCHAR (50) NOT NULL,
    [frg_active] BIT          NOT NULL
);

