CREATE TABLE [dbo].[Devices] (
    [dv_id]      INT           IDENTITY (1, 1) NOT NULL,
    [dv_type_id] INT           NOT NULL,
    [dv_name]    VARCHAR (100) COLLATE Latin1_General_CI_AS NOT NULL,
    [dv_ip1]     TINYINT       NULL,
    [dv_ip2]     TINYINT       NULL,
    [dv_ip3]     TINYINT       NULL,
    [dv_ip4]     TINYINT       NULL,
    [dv_desc]    VARCHAR (200) COLLATE Latin1_General_CI_AS NULL
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Primer valor de la dir IP', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Devices', @level2type = N'COLUMN', @level2name = N'dv_type_id';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Primer valor de la dir IP', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Devices', @level2type = N'COLUMN', @level2name = N'dv_ip1';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Segundo valor de la dir IP', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Devices', @level2type = N'COLUMN', @level2name = N'dv_ip2';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Tercer valor de la dir IP', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Devices', @level2type = N'COLUMN', @level2name = N'dv_ip3';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Cuarto  valor de la dir IP', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Devices', @level2type = N'COLUMN', @level2name = N'dv_ip4';

