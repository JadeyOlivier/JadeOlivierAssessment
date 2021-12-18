CREATE TABLE [dbo].[BaseVehicle]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Model] NVARCHAR(50) NOT NULL, 
    [Year] NCHAR(4) NOT NULL, 
    [Price] DECIMAL(10, 2) NOT NULL
)
