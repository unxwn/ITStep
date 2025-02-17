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
CREATE TABLE [Studios] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Studios] PRIMARY KEY ([Id])
);

CREATE TABLE [Games] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [StudioId] int NOT NULL,
    [Genre] nvarchar(max) NOT NULL,
    [ReleaseYear] int NOT NULL,
    [Multiplayer] bit NOT NULL,
    CONSTRAINT [PK_Games] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Games_Studios_StudioId] FOREIGN KEY ([StudioId]) REFERENCES [Studios] ([Id]) ON DELETE CASCADE
);

CREATE INDEX [IX_Games_StudioId] ON [Games] ([StudioId]);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250217164410_InitialCreate', N'9.0.2');

COMMIT;
GO

