CREATE PROCEDURE [dbo].[PaintProcedure]
	@Action VARCHAR(10)
AS
BEGIN
if @Action = 'PopulatePaint'
BEGIN
	SELECT * FROM [dbo].Paint
	if @@ROWCOUNT = 0
	BEGIN
		--populate paint table
		INSERT INTO [dbo].Paint VALUES ('Limestone Grey Metallic',0,'Metallic');
		INSERT INTO [dbo].Paint VALUES ('Real Blue Metallic',0,'Metallic');
		INSERT INTO [dbo].Paint VALUES ('Reflex Silver Metallic',0,'Metallic');
		INSERT INTO [dbo].Paint VALUES ('Flash Red',0,'Solid');
		INSERT INTO [dbo].Paint VALUES ('Pure White',0,'Solid');
	END
END

END
