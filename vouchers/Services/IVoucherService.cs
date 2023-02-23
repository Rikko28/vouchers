using DataAccess.Models;

namespace vouchers.Services;
public interface IVoucherService
{
    Task<Voucher> CreateVoucher(string name);
    Task<bool> GenerateVoucherCodes(int voucherId, ushort count, byte codeSymbolCount);
    Task<IEnumerable<Voucher>> GetAllVouchersWithoutCodes();
    Task<Voucher?> GetVoucher(int id);
    Task<byte> UseVoucherCode(int voucherId, string code);
}