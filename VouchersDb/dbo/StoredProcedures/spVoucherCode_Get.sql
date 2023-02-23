CREATE PROCEDURE [dbo].[spVoucherCode_Get]
	@VoucherId int,
	@Code NVARCHAR(8)
AS
	SELECT Code, Voucher_id voucherId, Is_used isUsed FROM dbo.VoucherCode
	WHERE Voucher_id = @VoucherId AND Code = @Code
