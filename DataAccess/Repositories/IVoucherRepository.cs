using DataAccess.Models;

namespace DataAccess.Repositories;
public interface IVoucherRepository
{
    Task<IEnumerable<Voucher>> GetAll();
    Task<Voucher?> GetByName(string name);
    Task<Voucher?> Get(int id);
    Task<VoucherCode?> GetVoucherCode(int voucherId, string code);
    Task<int> Insert(Voucher voucher);
    Task<int> Update(Voucher voucher);
    Task<int> IsertVoucherCodes(IEnumerable<VoucherCode> voucher);
    Task<int> UpdateVoucherCode(VoucherCode code);
}