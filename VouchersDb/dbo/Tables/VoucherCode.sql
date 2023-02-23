CREATE TABLE [dbo].[VoucherCode]
(
	[Code] NVARCHAR(8) NOT NULL PRIMARY KEY, 
    [Voucher_id] INT NOT NULL, 
    [Is_used] BIT NULL DEFAULT 0, 
    CONSTRAINT [FK_VoucherCode_ToVoucher] FOREIGN KEY ([Voucher_id]) REFERENCES [Voucher]([Id]),
    CONSTRAINT [UNIQUE_CODE] UNIQUE (Code,Voucher_id)
)
