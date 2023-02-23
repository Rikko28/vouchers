CREATE PROCEDURE [dbo].[spVoucherCode_GetByVoucherId]
	@Id int
AS
begin
	SELECT Code, Voucher_id VoucherId, Is_used IsUsed
	FROM dbo.VoucherCode
	WHERE Voucher_id = @Id;
end
