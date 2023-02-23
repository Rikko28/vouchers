namespace DataAccess.Models;
public class VoucherCode : IEquatable<VoucherCode>
{
    public static char[] CodeSymbols = "abcdefghijklmnopqrstuwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ01234567890".ToCharArray();
    public VoucherCode(string code, int voucherId)
    {
        VoucherId = voucherId;
        Code = code;
    }

    private VoucherCode(string code, int voucherId, bool isUsed) : this(code, voucherId)
    {
        IsUsed = isUsed;
    }

    public string Code { get; }
    public int VoucherId { get; }
    public bool IsUsed { get; private set; }

    public byte Use()
    {
        if (IsUsed) return 0;
        IsUsed = true;
        return 1;
    }

    public bool Equals(VoucherCode? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return Code == other.Code && VoucherId == other.VoucherId;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((VoucherCode)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Code, VoucherId);
    }
}
