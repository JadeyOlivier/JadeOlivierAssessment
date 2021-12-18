CREATE TABLE [dbo].[Interior]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(25) NOT NULL, 
    [Seats] NVARCHAR(25) NOT NULL, 
    [Dash] NVARCHAR(25) NOT NULL, 
    [Carpet] NVARCHAR(25) NOT NULL, 
    [Headliner] NVARCHAR(25) NOT NULL, 
    [Price] DECIMAL(10, 2) NOT NULL
)
