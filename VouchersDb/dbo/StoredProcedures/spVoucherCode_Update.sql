CREATE PROCEDURE [dbo].[spVoucherCode_Update]
	@IsUsed bit,
	@VoucherId int,
	@Code NVARCHAR(8)
AS
	UPDATE VoucherCode 
	SET Is_used = @IsUsed
	WHERE Code = @Code AND Voucher_id = @VoucherId
