CREATE PROCEDURE [dbo].[BaseVehicleProcedure]
	@Action VARCHAR(10)
AS
BEGIN
if @Action = 'PopulateBaseVehicle'
BEGIN
	SELECT * FROM [dbo].[BaseVehicle]
	if @@ROWCOUNT = 0
	BEGIN
		--populate base vehicle table
		INSERT INTO [dbo].[BaseVehicle] (Model, Year, Price) VALUES ('Polo Vivo Hatch','2021', 227900);
		INSERT INTO [dbo].[BaseVehicle] (Model, Year, Price) VALUES ('Polo Sedan','2021', 257500);
		INSERT INTO [dbo].[BaseVehicle] (Model, Year, Price) VALUES ('Polo','2021', 298800);
		INSERT INTO [dbo].[BaseVehicle] (Model, Year, Price) VALUES ('Golf GTi','2022', 669300);
		INSERT INTO [dbo].[BaseVehicle] (Model, Year, Price) VALUES ('T-Cross','2021', 357900);
		INSERT INTO [dbo].[BaseVehicle] (Model, Year, Price) VALUES ('Tiguan','2021', 528800);
		INSERT INTO [dbo].[BaseVehicle] (Model, Year, Price) VALUES ('Amarok','2021', 738800);
		INSERT INTO [dbo].[BaseVehicle] (Model, Year, Price) VALUES ('Kombi 6.1','2021', 757100);
		INSERT INTO [dbo].[BaseVehicle] (Model, Year, Price) VALUES ('Caravelle 6.1','2021', 1230100);
	END
END

END