CREATE TABLE [dbo].[Vehicles] (
    [ID]             INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    [VehicleKey]     INT NOT NULL,
    [EngineKey]      INT NOT NULL,
    [PaintKey]       INT NOT NULL,
    [InteriorKey]    INT NOT NULL,
    [QuantityOnHand] INT            NOT NULL,
    [Price]          DECIMAL(10, 2)           NOT NULL,
    
    CONSTRAINT [FK_PaintKey] FOREIGN KEY (PaintKey) REFERENCES [dbo].[Paint] (Id), 
    CONSTRAINT [FK_VehicleKey] FOREIGN KEY (VehicleKey) REFERENCES [dbo].[BaseVehicle] (Id),
    CONSTRAINT [FK_EngineKey] FOREIGN KEY (EngineKey) REFERENCES [dbo].[Engine] (Id),
    CONSTRAINT [FK_InteriorKey] FOREIGN KEY (InteriorKey) REFERENCES [dbo].[Interior] (Id)
);



