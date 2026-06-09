using System.Diagnostics;

namespace BoxTypeMonad;

internal class Program
{
    static void Main(string[] args)
    {
        var myNumberBox1 = new Box<int>();
        myNumberBox1.Item = 99;
        Debug.WriteLine($"myNumberBox1.Item: {myNumberBox1.Item}");

        Box<int> result2 = myNumberBox1.Select(x => x + 1);
        Debug.WriteLine($"result2.Item: {result2.Item}");
    }
}
