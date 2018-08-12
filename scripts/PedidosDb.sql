IF OBJECT_ID(N'__EFMigrationsHistory') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Pedidos] (
    [PEDIDO_ID] int NOT NULL IDENTITY,
    [CLIENTE_UID] uniqueidentifier NOT NULL,
    [PAGAMENTO_UID] uniqueidentifier NULL,
    [UID] uniqueidentifier NOT NULL,
    [DATA_ATUALIZACAO_STATUS] datetime2 NOT NULL,
    [DATA_CADASTRO] datetime2 NOT NULL,
    [STATUS] int NOT NULL,
    CONSTRAINT [PK_Pedidos] PRIMARY KEY ([PEDIDO_ID])
);

GO

CREATE TABLE [Pedidos_Enderecos] (
    [PEDIDO_ID] int NOT NULL,
    [BAIRRO] nvarchar(max) NOT NULL,
    [CEP] nvarchar(max) NOT NULL,
    [CIDADE] nvarchar(max) NOT NULL,
    [COMPLEMENTO] nvarchar(max) NULL,
    [LOGRADOURO] nvarchar(max) NOT NULL,
    [NUMERO] nvarchar(max) NOT NULL,
    [UF] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Pedidos_Enderecos] PRIMARY KEY ([PEDIDO_ID]),
    CONSTRAINT [FK_Pedidos_Enderecos_Pedidos_PEDIDO_ID] FOREIGN KEY ([PEDIDO_ID]) REFERENCES [Pedidos] ([PEDIDO_ID]) ON DELETE CASCADE
);

GO

CREATE TABLE [Pedidos_Fornecedores] (
    [PEDIDO_FORNECEDOR_ID] int NOT NULL IDENTITY,
    [FORNECEDOR_UID] uniqueidentifier NOT NULL,
    [PEDIDO_ID] int NOT NULL,
    [PRAZO_MAXIMO] int NOT NULL,
    [PRAZO_MINIMO] int NOT NULL,
    [VALOR_FRETE] decimal(18, 2) NOT NULL,
    CONSTRAINT [PK_Pedidos_Fornecedores] PRIMARY KEY ([PEDIDO_FORNECEDOR_ID]),
    CONSTRAINT [FK_Pedidos_Fornecedores_Pedidos_PEDIDO_ID] FOREIGN KEY ([PEDIDO_ID]) REFERENCES [Pedidos] ([PEDIDO_ID]) ON DELETE CASCADE
);

GO

CREATE TABLE [Pedido_Itens] (
    [PEDIDO_ITEM_ID] int NOT NULL IDENTITY,
    [PRODUTO_UID] uniqueidentifier NOT NULL,
    [IMAGEM_PRODUTO] nvarchar(max) NOT NULL,
    [NOME_PRODUTO] nvarchar(max) NOT NULL,
    [PEDIDO_FORNECEDOR_ID] int NOT NULL,
    [PRECO_UNITARIO] decimal(18, 2) NOT NULL,
    [QUANTIDADE] int NOT NULL,
    CONSTRAINT [PK_Pedido_Itens] PRIMARY KEY ([PEDIDO_ITEM_ID]),
    CONSTRAINT [FK_Pedido_Itens_Pedidos_Fornecedores_PEDIDO_FORNECEDOR_ID] FOREIGN KEY ([PEDIDO_FORNECEDOR_ID]) REFERENCES [Pedidos_Fornecedores] ([PEDIDO_FORNECEDOR_ID]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_Pedido_Itens_PEDIDO_FORNECEDOR_ID] ON [Pedido_Itens] ([PEDIDO_FORNECEDOR_ID]);

GO

CREATE INDEX [IX_Pedidos_Fornecedores_PEDIDO_ID] ON [Pedidos_Fornecedores] ([PEDIDO_ID]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20180812191519_InitialPedidos', N'2.0.3-rtm-10026');

GO
