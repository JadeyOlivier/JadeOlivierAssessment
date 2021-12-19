CREATE PROCEDURE [dbo].[PaintProcedure]
	@Action VARCHAR(20)
AS
BEGIN
if @Action = 'PopulatePaint'
BEGIN
	SELECT * FROM [dbo].[Paint]
	if @@ROWCOUNT = 0
	BEGIN
		--populate paint table
		INSERT INTO [dbo].[Paint] (Name, Price, Finish) VALUES ('Limestone Grey Metallic',0,'Metallic');
		INSERT INTO [dbo].[Paint] (Name, Price, Finish) VALUES ('Real Blue Metallic',0,'Metallic');
		INSERT INTO [dbo].[Paint] (Name, Price, Finish) VALUES ('Reflex Silver Metallic',0,'Metallic');
		INSERT INTO [dbo].[Paint] (Name, Price, Finish) VALUES ('Flash Red',0,'Solid');
		INSERT INTO [dbo].[Paint] (Name, Price, Finish) VALUES ('Pure White',0,'Solid');
	END
END

END
