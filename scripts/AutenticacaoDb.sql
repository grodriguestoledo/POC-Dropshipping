IF OBJECT_ID(N'__EFMigrationsHistory') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [PersistedGrants] (
    [Key] nvarchar(200) NOT NULL,
    [ClientId] nvarchar(200) NOT NULL,
    [CreationTime] datetime2 NOT NULL,
    [Data] nvarchar(max) NOT NULL,
    [Expiration] datetime2 NULL,
    [SubjectId] nvarchar(200) NULL,
    [Type] nvarchar(50) NOT NULL,
    CONSTRAINT [PK_PersistedGrants] PRIMARY KEY ([Key])
);

GO

CREATE INDEX [IX_PersistedGrants_SubjectId_ClientId_Type] ON [PersistedGrants] ([SubjectId], [ClientId], [Type]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20180726164450_InitialIdentityServerMigration', N'2.0.3-rtm-10026');

GO

IF OBJECT_ID(N'__EFMigrationsHistory') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Conta] (
    [CONTA_ID] int NOT NULL IDENTITY,
    [UID] uniqueidentifier NOT NULL,
    [LOGIN] nvarchar(max) NOT NULL,
    [NOME] nvarchar(max) NOT NULL,
    [SENHA] nvarchar(max) NOT NULL,
    [SOBRENOME] nvarchar(max) NOT NULL,
    [TIPO] int NOT NULL,
    CONSTRAINT [PK_Conta] PRIMARY KEY ([CONTA_ID])
);

GO

CREATE INDEX [IX_Conta_UID] ON [Conta] ([UID]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20180727193954_AutenticacaoInicialMigration', N'2.0.3-rtm-10026');

GO

INSERT INTO [Conta] VALUES (NEWID(),'admin','Administrador','jGl25bVBBBW96Qi9Te4V37Fnqchz/Eu4qB9vKrRIqRg=','da Loja',1)

