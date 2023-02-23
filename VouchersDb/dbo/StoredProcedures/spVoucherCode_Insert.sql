CREATE PROCEDURE [dbo].[spVoucherCode_Insert]
	@Code NVARCHAR(8),
	@VoucherId int,
	@IsUsed bit
AS
	INSERT INTO VoucherCode (Code, Voucher_id) VALUES(@Code,@VoucherId);
