IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Usuario] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(60) NOT NULL,
    [Email] nvarchar(60) NOT NULL,
    [Senha] nvarchar(10) NOT NULL,
    [Administrador] bit NOT NULL,
    [Ativo] bit NOT NULL,
    [DataDoCadastro] datetime2 NOT NULL,
    [UltimoAcesso] datetime2 NOT NULL,
    CONSTRAINT [PK_Usuario] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230923002547_Initial', N'6.0.21');
GO

COMMIT;
GO

