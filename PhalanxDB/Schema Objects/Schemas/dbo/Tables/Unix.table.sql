CREATE TABLE [dbo].[Unix] (
    [unx_id]          INT           IDENTITY (1, 1) NOT NULL,
    [unx_server_name] VARCHAR (100) COLLATE Latin1_General_CI_AS NOT NULL,
    [unx_server_ip1]  TINYINT       NULL,
    [unx_server_ip2]  TINYINT       NULL,
    [unx_server_ip3]  TINYINT       NULL,
    [unx_server_ip4]  TINYINT       NULL,
    [unx_desc]        VARCHAR (200) COLLATE Latin1_General_CI_AS NULL,
    [unx_ip]          VARCHAR (15)  COLLATE Latin1_General_CI_AS NULL,
    [active]          BIT           NOT NULL
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Primer valor de la dir IP', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Unix', @level2type = N'COLUMN', @level2name = N'unx_server_ip1';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Segundo valor de la dir IP', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Unix', @level2type = N'COLUMN', @level2name = N'unx_server_ip2';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Tercer valor de la dir IP', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Unix', @level2type = N'COLUMN', @level2name = N'unx_server_ip3';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Cuarto  valor de la dir IP', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Unix', @level2type = N'COLUMN', @level2name = N'unx_server_ip4';

