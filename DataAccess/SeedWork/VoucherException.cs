using DataAccess.Models;

namespace DataAccess.SeedWork;
public class VoucherException : Exception
{
	public VoucherException(Voucher voucher, string message) :
		base($"{message} \n {nameof(Voucher)}: {voucher.Name}")
	{
	}

	public VoucherException(string message) : base(message) { }
}
