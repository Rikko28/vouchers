using DataAccess.Models;

namespace DataAccess.SeedWork;
public class VoucherCodeException : Exception
{
	public VoucherCodeException(VoucherCode code, string message) :
		base($"{message} \n {nameof(VoucherCode)}: {code.Code} {nameof(Voucher)}: {code.VoucherId}")
	{

	}
}
