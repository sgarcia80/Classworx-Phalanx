CREATE TABLE [dbo].[mail_alert] (
    [mail_alert_id]      INT            IDENTITY (1, 1) NOT NULL,
    [mail_type_id]       INT            NOT NULL,
    [mail_creation_date] DATETIME       NOT NULL,
    [mail_send_date]     DATETIME       NULL,
    [mail_subject]       VARCHAR (100)  NOT NULL,
    [mail_to_name]       VARCHAR (100)  NULL,
    [mail_to_address]    VARCHAR (150)  NOT NULL,
    [mail_cc1_name]      VARCHAR (100)  NULL,
    [mail_cc1_address]   VARCHAR (150)  NULL,
    [mail_cc2_name]      VARCHAR (100)  NULL,
    [mail_cc2_address]   VARCHAR (150)  NULL,
    [mail_cc3_name]      VARCHAR (150)  NULL,
    [mail_cc3_address]   VARCHAR (150)  NULL,
    [mail_cc4_name]      VARCHAR (150)  NULL,
    [mail_cc4_address]   VARCHAR (150)  NULL,
    [mail_cc5_name]      VARCHAR (150)  NULL,
    [mail_cc5_address]   VARCHAR (150)  NULL,
    [mail_cc6_name]      VARCHAR (150)  NULL,
    [mail_cc6_address]   VARCHAR (150)  NULL,
    [mail_cc7_name]      VARCHAR (150)  NULL,
    [mail_cc7_address]   VARCHAR (150)  NULL,
    [mail_cc8_name]      VARCHAR (150)  NULL,
    [mail_cc8_address]   VARCHAR (150)  NULL,
    [mail_cc9_name]      VARCHAR (150)  NULL,
    [mail_cc9_address]   VARCHAR (150)  NULL,
    [mail_cc10_name]     VARCHAR (150)  NULL,
    [mail_cc10_address]  VARCHAR (150)  NULL,
    [mail_cc11_name]     VARCHAR (150)  NULL,
    [mail_cc11_address]  VARCHAR (150)  NULL,
    [mail_cc12_name]     VARCHAR (150)  NULL,
    [mail_cc12_address]  VARCHAR (150)  NULL,
    [mail_body]          VARCHAR (1000) NOT NULL,
    [mail_send_attemp]   INT            NOT NULL
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Nro de intento de envío del mail', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'mail_alert', @level2type = N'COLUMN', @level2name = N'mail_send_attemp';

