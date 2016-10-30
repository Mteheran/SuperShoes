CREATE TABLE [dbo].[Articles]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(256) NOT NULL, 
    [Description] NVARCHAR(MAX) NULL, 
    [Price] FLOAT NOT NULL, 
    [Total_in_shelf] INT NOT NULL, 
    [Total_in_vault] INT NOT NULL, 
    [Store_id] INT NOT NULL, 
    CONSTRAINT [FK_Articles_Store] FOREIGN KEY (Store_id) REFERENCES [Stores](Id)
)
