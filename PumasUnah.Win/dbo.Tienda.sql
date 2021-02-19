CREATE TABLE [dbo].[Tienda] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Descripcion] NVARCHAR (MAX) NULL,
    [Precio] INT NOT NULL, 
    CONSTRAINT [PK_dbo.Tienda] PRIMARY KEY CLUSTERED ([Id] ASC)
);

