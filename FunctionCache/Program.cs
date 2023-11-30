
class Program
{
    public static void Main()
    {
        var cache = new FunctionCache<int, string>(TimeSpan.FromMinutes(1));

        var result1 = cache.Get(1, (key) => "asd");

        var result2 = cache.Get(2, (key) => "qwe");

        var result3 = cache.Get(1, (key) => "zxc");

        Console.WriteLine(result1);
        Console.WriteLine(result2);
        Console.WriteLine(result3);
    }
}
