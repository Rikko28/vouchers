CREATE PROCEDURE [dbo].[spVoucher_Update]
	@VoucherName NVARCHAR(50),
	@Id int
AS
	UPDATE dbo.Voucher 
	SET Name = @VoucherName
	WHERE Id = @Id

