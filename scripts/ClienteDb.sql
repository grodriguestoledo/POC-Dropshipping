IF OBJECT_ID(N'__EFMigrationsHistory') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Clientes] (
    [CLIENTE_ID] int NOT NULL IDENTITY,
    [CONTA_UID] uniqueidentifier NOT NULL,
    [EMAIL] nvarchar(max) NOT NULL,
    [NOME] nvarchar(max) NOT NULL,
    [SOBRENOME] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Clientes] PRIMARY KEY ([CLIENTE_ID])
);

GO

CREATE TABLE [Enderecos] (
    [ENDERECO_ID] int NOT NULL IDENTITY,
    [BAIRRO] nvarchar(max) NOT NULL,
    [CEP] nvarchar(max) NOT NULL,
    [CLIENTE_ID] int NOT NULL,
    [CIDADE] nvarchar(max) NOT NULL,
    [COMPLEMENTO] nvarchar(max) NULL,
    [DESCRICAO] nvarchar(max) NOT NULL,
    [ENDERECO_PRINCIPAL] bit NOT NULL,
    [LOGRADOURO] nvarchar(max) NOT NULL,
    [NUMERO] nvarchar(max) NOT NULL,
    [UF] nvarchar(max) NOT NULL,
    [UID] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_Enderecos] PRIMARY KEY ([ENDERECO_ID]),
    CONSTRAINT [FK_Enderecos_Clientes_CLIENTE_ID] FOREIGN KEY ([CLIENTE_ID]) REFERENCES [Clientes] ([CLIENTE_ID]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_Clientes_CONTA_UID] ON [Clientes] ([CONTA_UID]);

GO

CREATE INDEX [IX_Enderecos_CLIENTE_ID] ON [Enderecos] ([CLIENTE_ID]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20180811004029_InitialCliente', N'2.0.3-rtm-10026');

GO

INSERT INTO [Clientes] VALUES ('331EDE85-A37C-4F77-89BF-BB1F168C8305','cliente@poc.com.br','Cliente','da Poc')

DECLARE @CLI_ID INT = SCOPE_IDENTITY() 

INSERT INTO Enderecos VALUES 
('dos Casa','09850090',@CLI_ID,'São Bernardo do Campo',NULL,'Casa',1,'R Wadia Jafet Assad',450,'SP',NEWID()),
('Morumbi','04794000',@CLI_ID,'São Paulo','Ala A 15º andar','Trabalho',0,'Av das Nações Unidas',14261,'SP',NEWID()),
('Coração Eucarístico','30535901',@CLI_ID,'Belo Horizonte',NULL,'Pós',0,'Av Dom José Gaspar',500,'MG',NEWID())