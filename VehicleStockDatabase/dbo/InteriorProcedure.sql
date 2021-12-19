CREATE PROCEDURE [dbo].[InteriorProcedure]
	@Action VARCHAR(10)
AS
BEGIN
if @Action = 'PopulateInterior'
BEGIN
	SELECT * FROM [dbo].[Interior]
	if @@ROWCOUNT = 0
	BEGIN
		--populate engine table
		INSERT INTO [dbo].[Interior] (Name, Seats, Dash, Carpet, Headliner, Price) VALUES ('Palladium','Palladium','Titanium Black','Gray','Titanium Black', 0);
		INSERT INTO [dbo].[Interior] (Name, Seats, Dash, Carpet, Headliner, Price) VALUES ('Soul Black Tornado Red','Soul Black Tornado Red','Soul Black','Black','Soul Black', 0);
		INSERT INTO [dbo].[Interior] (Name, Seats, Dash, Carpet, Headliner, Price) VALUES ('Titanium Black-Gray','Titanium Black-Gray','Titanium Black','Black','Pearl Gray', 0);
		INSERT INTO [dbo].[Interior] (Name, Seats, Dash, Carpet, Headliner, Price) VALUES ('Flannel Gray','Flannel Gray','Anthracite Flannel Gray','Flannel Gray','Titanium Black', 0);
		INSERT INTO [dbo].[Interior] (Name, Seats, Dash, Carpet, Headliner, Price) VALUES ('Soul Black Crystal Gray','Soul Black Crystal Gray','Soul Black','Soul Black Crystal Gray','Pearl Gray', 0);
	END
END

END
