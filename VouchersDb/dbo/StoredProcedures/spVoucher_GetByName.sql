CREATE PROCEDURE [dbo].[spVoucher_GetByName]
	@Name NVARCHAR(8)
AS
begin
	SELECT *
	FROM dbo.Voucher 
	WHERE Name = @Name;
end
