namespace BoxTypeMonad;

internal class Program
{
    static void Main(string[] args)
    {
        var myNumberBox1 = new Box<int>();
        myNumberBox1.Item = 99;
    }
}
