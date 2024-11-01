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

CREATE TABLE [TB_Autor] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NOT NULL,
    [Cpf] nvarchar(max) NOT NULL,
    [Longitude] float NOT NULL,
    [Latitude] float NOT NULL,
    [DataNascimento] datetime2 NOT NULL,
    CONSTRAINT [PK_TB_Autor] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [TB_Livro] (
    [Id] int NOT NULL IDENTITY,
    [IdAutor] int NOT NULL,
    [Nome] nvarchar(max) NOT NULL,
    [Editora] nvarchar(max) NOT NULL,
    [Preco] float NOT NULL,
    [QtdPaginas] int NOT NULL,
    CONSTRAINT [PK_TB_Livro] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_TB_Livro_TB_Autor_IdAutor] FOREIGN KEY ([IdAutor]) REFERENCES [TB_Autor] ([Id])
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Cpf', N'DataNascimento', N'Latitude', N'Longitude', N'Nome') AND [object_id] = OBJECT_ID(N'[TB_Autor]'))
    SET IDENTITY_INSERT [TB_Autor] ON;
INSERT INTO [TB_Autor] ([Id], [Cpf], [DataNascimento], [Latitude], [Longitude], [Nome])
VALUES (1, N'12345678900', '1965-07-31T00:00:00.0000000', 0.0E0, 0.0E0, N'J.K. Rowling');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Cpf', N'DataNascimento', N'Latitude', N'Longitude', N'Nome') AND [object_id] = OBJECT_ID(N'[TB_Autor]'))
    SET IDENTITY_INSERT [TB_Autor] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Editora', N'IdAutor', N'Nome', N'Preco', N'QtdPaginas') AND [object_id] = OBJECT_ID(N'[TB_Livro]'))
    SET IDENTITY_INSERT [TB_Livro] ON;
INSERT INTO [TB_Livro] ([Id], [Editora], [IdAutor], [Nome], [Preco], [QtdPaginas])
VALUES (1, N'PedroBala', 1, N'Harry Potter', 50.0E0, 365);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Editora', N'IdAutor', N'Nome', N'Preco', N'QtdPaginas') AND [object_id] = OBJECT_ID(N'[TB_Livro]'))
    SET IDENTITY_INSERT [TB_Livro] OFF;
GO

CREATE INDEX [IX_TB_Livro_IdAutor] ON [TB_Livro] ([IdAutor]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20241101202410_InitialCreate', N'8.0.10');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20241101202427_Livro', N'8.0.10');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20241101202437_Autor', N'8.0.10');
GO

COMMIT;
GO

