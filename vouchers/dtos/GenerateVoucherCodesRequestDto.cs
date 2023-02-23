namespace vouchers.dtos;

public record GenerateVoucherCodesRequestDto(int VoucherId, ushort Count, byte CodeSymbolCount);