using DataAccess.DbAccess;
using DataAccess.Models;

namespace DataAccess.Repositories;
public class VoucherSqlRepository : IVoucherRepository
{
    private readonly ISqlDataAccess _dataAccess;

    public VoucherSqlRepository(ISqlDataAccess dataAccess)
    {
        _dataAccess = dataAccess;
    }

    public async Task<Voucher?> Get(int id)
    {
        var voucher = await _dataAccess.Get<Voucher>("dbo.spVoucher_Get", new { id });
        if (voucher == null)
            return null;
        var codes = await _dataAccess.GetMany<VoucherCode>("dbo.spVoucherCode_GetByVoucherId", new { id });
        voucher.SetCodes(codes);
        return voucher;
    }

    public async Task<int> Insert(Voucher voucher)
    {
        return await _dataAccess.Get<int>("dbo.spVoucher_Insert", new { voucher.Name });
    }

    public async Task<int> Update(Voucher voucher)
    {
        return await _dataAccess.Execute("dbo.spVoucher_Update", new { voucher.Name });
    }

    public async Task<int> IsertVoucherCodes(IEnumerable<VoucherCode> codes)
    {
        using var transaction = _dataAccess.StartTransaction();
        var result = await _dataAccess.Execute("dbo.spVoucherCode_Insert", codes, transaction);
        _dataAccess.CommitTransaction(transaction);
        return result;
    }

    public async Task<int> UpdateVoucherCode(VoucherCode code)
    {
        return await _dataAccess.Execute("dbo.spVoucherCode_Update", code);
    }

    public async Task<IEnumerable<Voucher>> GetAll()
    {
        var vouchers = await _dataAccess.GetMany<Voucher>("dbo.spVoucher_GetAll");
        return vouchers;
    }

    public async Task<Voucher?> GetByName(string name)
    {
        var vouchers = await _dataAccess.Get<Voucher>("dbo.spVoucher_GetByName", new { name });
        return vouchers;
    }

    public async Task<VoucherCode?> GetVoucherCode(int voucherId, string code)
    {
        var voucherCode = await _dataAccess.Get<VoucherCode>("dbo.spVoucherCode_Get", new { voucherId, code });
        return voucherCode;
    }
}
