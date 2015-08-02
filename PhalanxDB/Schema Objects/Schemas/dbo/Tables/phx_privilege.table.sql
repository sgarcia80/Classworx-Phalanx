CREATE TABLE [dbo].[phx_privilege] (
    [phx_privilege_id]   INT           IDENTITY (1, 1) NOT NULL,
    [phx_privilege_name] VARCHAR (150) NOT NULL,
    [phx_privilege_code] VARCHAR (50)  NOT NULL,
    [phx_prv_grp_id]     INT           NOT NULL
);

