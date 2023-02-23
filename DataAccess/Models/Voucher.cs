using DataAccess.SeedWork;

namespace DataAccess.Models;
public class Voucher
{
    private static readonly Random _random = new Random();

    private HashSet<VoucherCode> _codes = new HashSet<VoucherCode>();
    public Voucher(int id, string name) : this(name)
    {
        SetId(id);
    }

    public Voucher(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new VoucherException("Voucher name can't be empty");
        Name = name;
    }

    public int Id { get; private set; }
    public string Name { get; }
    public IReadOnlyCollection<VoucherCode> Codes => _codes;

    public void SetCodes(IEnumerable<VoucherCode> codes)
    {
        _codes = codes.ToHashSet();
    }

    public void SetId(int id)
    {
        if (id <= 0)
            throw new VoucherException($"Invalid id: {id}");
        Id = id;
    }

    public IEnumerable<VoucherCode>? GenerateCodes(ushort count, byte codeSymbolCount)
    {
        var tryCount = 0;
        const int maxTryCount = 1000;
        var result = new HashSet<VoucherCode>();
        Console.WriteLine($"Started generating {count} codes");
        while (count != 0 && tryCount != maxTryCount)
        {
           
            Console.WriteLine(count);
            tryCount++;
            var voucher = GenerateVoucher(VoucherCode.CodeSymbols, codeSymbolCount);
            var wasAdded = _codes.Add(voucher);
            if (wasAdded)
            {
                result.Add(voucher);
                tryCount = 0;
                count--;
            }
        }

        if (tryCount == maxTryCount)
        {
            Console.WriteLine("Couldn't finish generating codes, because maximum try count reached");
            return null;
        }

        Console.WriteLine($"Finished generating codes. Total generated count: {result.Count}");
        return result;
    }

    private VoucherCode GenerateVoucher(char[] keys, int lengthOfVoucher)
    {
        var code = Enumerable
            .Range(1, lengthOfVoucher)
            .Select(k => keys[_random.Next(0, keys.Length - 1)])
            .Aggregate("", (e, c) => e + c);
        return new VoucherCode(code, Id);
    }

    public override string ToString()
    {
        return $"Id: {Id}, Name: {Name}";
    }
}
