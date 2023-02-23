using DataAccess.Models;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;
using vouchers.dtos;
using vouchers.Services;

namespace vouchers.Controllers;
[Route("api/[controller]")]
[ApiController]
public class VoucherController : ControllerBase
{
    private readonly IVoucherService _voucherService;

    public VoucherController(IVoucherService voucherService)
    {
        _voucherService = voucherService;
    }

    [HttpGet]
    public async Task<IActionResult> GetVouchers()
    {
        var result = await _voucherService.GetAllVouchersWithoutCodes();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetVoucher(int id)
    {
        var result = await _voucherService.GetVoucher(id);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateVoucher(string name)
    {
        var result = await _voucherService.CreateVoucher(name);
        return Ok(result);
    }

    [HttpPost("generate-codes")]
    public async Task<IActionResult> GenerateVucherCodes([FromBody]GenerateVoucherCodesRequestDto request)
    {
        var result = await _voucherService.GenerateVoucherCodes(request.VoucherId, request.Count,
            request.CodeSymbolCount);
        return Ok(result);
    }

    [HttpPost("use-code")]
    public async Task<IActionResult> UseCode([FromBody] UseVoucherCodeRequestDto request)
    {
        var result = await _voucherService.UseVoucherCode(request.VoucherId, request.Code);
        return Ok(result);
    }
}
