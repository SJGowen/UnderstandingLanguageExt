using System.Diagnostics;

namespace BoxTypeMonad;

public class Program
{
    static void Main(string[] args)
    {
        var myNumberBox1 = new Box<int>();
        myNumberBox1.Item = 99;
        Debug.WriteLine($"myNumberBox1.Item: {myNumberBox1.Item}");

        Box<int> result = myNumberBox1.Select(x => x + 1);
        // The above uses the Linq Fluent syntax. An alternative is to use the Query syntax:
        // var result = from number in myNumberBox1
        //              select number + 1;
        Debug.WriteLine($"result.Item: {result.Item}");
    }
}
