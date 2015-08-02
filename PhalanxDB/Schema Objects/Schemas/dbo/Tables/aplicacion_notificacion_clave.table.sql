CREATE TABLE [dbo].[aplicacion_notificacion_clave] (
    [anc_id]          INT          IDENTITY (1, 1) NOT NULL,
    [anc_code]        VARCHAR (50) NOT NULL,
    [anc_name]        VARCHAR (50) NOT NULL,
    [anc_notificable] BIT          DEFAULT ((1)) NOT NULL
);

