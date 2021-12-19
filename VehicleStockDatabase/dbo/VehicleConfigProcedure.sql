CREATE PROCEDURE [dbo].[VehicleConfigProcedure]
	@Action VARCHAR(10),
	@VehicleID int = NULL

AS
BEGIN
	--SELECT ALL QUERY
	if @Action = 'SELECT ALL'
	BEGIN
		SELECT ID,VehicleKey,EngineKey,PaintKey,InteriorKey,QuantityOnHand,Price 
		FROM [dbo].[Vehicles]
	END
END
