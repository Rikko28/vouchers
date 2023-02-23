CREATE PROCEDURE [dbo].[spVoucher_Insert]
	@Name NVARCHAR(50)
AS
	INSERT INTO dbo.Voucher (Name)
	VALUES (@Name);
	SELECT @@IDENTITY;

