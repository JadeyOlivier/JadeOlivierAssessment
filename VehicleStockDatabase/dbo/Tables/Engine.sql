CREATE TABLE [dbo].[Engine]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [Fuel] NVARCHAR(10) NOT NULL, 
    [Capacity] NVARCHAR(10) NOT NULL, 
    [Power] INT NOT NULL, 
    [Transmission] NVARCHAR(10) NOT NULL, 
    [Price] DECIMAL(10, 2) NOT NULL
)
