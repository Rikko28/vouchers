CREATE PROCEDURE [dbo].[spVoucher_Get]
	@Id int
AS
begin
	SELECT *
	FROM dbo.Voucher
	WHERE Id = @Id;
end
