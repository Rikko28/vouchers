using DataAccess.Models;
using DataAccess.Repositories;

namespace vouchers.Services;

public class VoucherService : IVoucherService
{
    private readonly IVoucherRepository _voucherRepository;

    public VoucherService(IVoucherRepository voucherRepository)
    {
        _voucherRepository = voucherRepository;
    }

    public async Task<IEnumerable<Voucher>> GetAllVouchersWithoutCodes()
    {
        var result = await _voucherRepository.GetAll();
        return result;
    }

    public async Task<Voucher?> GetVoucher(int id)
    {
        var result = await _voucherRepository.Get(id);
        return result;
    }

    public async Task<Voucher> CreateVoucher(string name)
    {
        var voucher = await _voucherRepository.GetByName(name);

        if (voucher != null)
            throw new Exception($"Voucher already exist: {voucher}");

        voucher = new Voucher(name);
        var voucherId = await _voucherRepository.Insert(voucher);
        voucher.SetId(voucherId);

        return voucher;
    }

    public async Task<bool> GenerateVoucherCodes(int voucherId, ushort count, byte codeSymbolCount)
    {
        var voucher = await _voucherRepository.Get(voucherId);
        if (voucher == null || count < 1000 || count > 2000 || codeSymbolCount < 7 || codeSymbolCount > 8)
            return false;

        var codes = voucher.GenerateCodes(count, codeSymbolCount);
        if (codes != null)
            await _voucherRepository.IsertVoucherCodes(codes);

        return codes != null;
    }

    public async Task<byte> UseVoucherCode(int voucherId, string code)
    {
        var voucherCode = await _voucherRepository.GetVoucherCode(voucherId, code);
        if (voucherCode == null)
            return 0;

        var codeUsed = voucherCode.Use();

        if (codeUsed == 1)
            await _voucherRepository.UpdateVoucherCode(voucherCode);

        return codeUsed;
    }
}
