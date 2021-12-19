CREATE PROCEDURE [dbo].[EngineProcedure]
	@Action VARCHAR(20)
AS
BEGIN
if @Action = 'PopulateEngine'
BEGIN
	SELECT * FROM [dbo].[Engine]
	if @@ROWCOUNT = 0
	BEGIN
		--populate engine table
		INSERT INTO [dbo].[Engine] (Fuel, Capacity, Power, Transmission, Price) VALUES ('Petrol','2.0 TSI',147,'Automatic', 50200);
		INSERT INTO [dbo].[Engine] (Fuel, Capacity, Power, Transmission, Price) VALUES ('Petrol','1.0 TSI',85,'Automatic', 77200);
		INSERT INTO [dbo].[Engine] (Fuel, Capacity, Power, Transmission, Price) VALUES ('Petrol','1.4 TSI',110,'Automatic', 0);
		INSERT INTO [dbo].[Engine] (Fuel, Capacity, Power, Transmission, Price) VALUES ('Petrol','2.0 TSI',140,'Automatic', 60500);
		INSERT INTO [dbo].[Engine] (Fuel, Capacity, Power, Transmission, Price) VALUES ('Diesel','3.0 TDI',190,'Automatic', 214300);
		INSERT INTO [dbo].[Engine] (Fuel, Capacity, Power, Transmission, Price) VALUES ('Diesel','2.0 BiTDI',132,'Automatic', 5100);
		INSERT INTO [dbo].[Engine] (Fuel, Capacity, Power, Transmission, Price) VALUES ('Diesel','2.0 BiTDI',132,'Manual', 0);
	END
END

END
