CREATE PROCEDURE [dbo].[VehicleConfigProcedure]
	@Action VARCHAR(20),
	@VehicleID int = NULL
AS
BEGIN
	--SELECT ALL QUERY
	if @Action = 'SELECT_ALL'
	BEGIN
		SELECT a.ID, b.Model ,c.Capacity AS "Engine",d.PaintName AS "Paint",e.InteriorName AS "Interior",a.QuantityOnHand AS "Quantity",a.Price 
		FROM [dbo].[Vehicles] AS a 
		JOIN [dbo].[BaseVehicle] AS b ON b.Id = a.VehicleKey
		JOIN [dbo].[Engine] AS c ON c.Id = a.EngineKey
		JOIN [dbo].[Paint] AS d ON d.Id = a.PaintKey
		JOIN [dbo].[Interior] AS e ON e.Id = a.InteriorKey
	END
		
	--INSERT NEW VEHICLECONFIG QUERY
	if @Action = 'INSERT_NEW_VEH'
	BEGIN
	
		INSERT INTO [dbo].[Paint] (PaintName, Price, Finish) VALUES ('Limestone Grey Metallic',0,'Metallic');
	END

	--GET ALL BASE VEHICLE MODELS QUERY
	if @Action = 'GET_BASE_VEHICLES'
	BEGIN
		SELECT Id, Model FROM [dbo].[BaseVehicle] ORDER BY Model 
	END

		--GET ALL ENGINES  QUERY
	if @Action = 'GET_ENGINES'
	BEGIN
		SELECT Id, CONCAT(Power,'kw ',Capacity,' ', Fuel, ' (', Transmission, ')') AS EngineSpec FROM [dbo].[Engine] ORDER BY EngineSpec
	END

		--GET ALL PAINTS QUERY
	if @Action = 'GET_PAINTS'
	BEGIN
	
		SELECT Id, PaintName FROM [dbo].[Paint] ORDER BY PaintName 
	END

	--GET ALL INTERIORS QUERY
	if @Action = 'GET_INTERIORS'
	BEGIN
	
		SELECT Id, InteriorName FROM [dbo].[Interior] ORDER BY InteriorName 
	END

END
