CREATE TABLE [dbo].[Sale]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [CashierId] NVARCHAR(128) NOT NULL, 
    [SaleDate] DATETIME2 NOT NULL, 
    [SubTotal] MONEY NOT NULL,
    [Shipping] MONEY NULL,
    [Tax] MONEY NOT NULL, 
    [Total] MONEY NOT NULL
)
