IF OBJECT_ID(N'__EFMigrationsHistory') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Fornecedores] (
    [FORNECEDOR_ID] int NOT NULL IDENTITY,
    [FORNECEDOR_UID] uniqueidentifier NOT NULL,
    [NOME] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Fornecedores] PRIMARY KEY ([FORNECEDOR_ID])
);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20180813213555_FornecedoresInitialMigration', N'2.0.3-rtm-10026');

GO

INSERT INTO [Fornecedores] 
VALUES
('8d58b0c7-7ca0-4e10-a738-579aa1919ffe','Golden'),
('8efef7d5-3f52-49b4-bed6-804bc514b49a','Animais Pet'),
('5d0566c9-12d4-4321-bccc-22a4c15cf16a','Lorem Ipsum'),
('d2b54244-daf0-4a6f-ad10-d6441e4cbcbc','Mundo das Tartarugas')
