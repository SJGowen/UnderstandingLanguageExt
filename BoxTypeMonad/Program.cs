using System.Diagnostics;

namespace BoxTypeMonad;

public class Program
{
    static void Main(string[] args)
    {
        var myNumberBox1 = new Box<int>();
        myNumberBox1.Item = 99;
        Debug.WriteLine($"myNumberBox1.Item: {myNumberBox1.Item}");

        Box<int> selectResult = myNumberBox1.Select(x => x + 1);
        // The above uses the Linq Fluent syntax. An alternative is to use the Query syntax:
        // var result = from number in myNumberBox1
        //              select number + 1;
        Debug.WriteLine($"selectedResult.Item: {selectResult.Item}");

        Box<int[]> numbers1 = new([ 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 ]);
        Box<int[]> numbers2 = new([ 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 ]);

        Box<int[]> bindResult = numbers1.Bind(contents => MyFunction(contents));
        Box<int[]> mapResult = numbers2.Map(contents => MyFunction2(contents));

        Debug.WriteLine($"bindResult.Item: {string.Join(", ", bindResult.Item)}");
        Debug.WriteLine($"mapResult.Item: {string.Join(", ", mapResult.Item)}");

        Box<string> mapStringResult = numbers1.Map(contents => "I'm a string!");
        Debug.WriteLine($"mapStringResult.Item: {mapStringResult.Item}");
    }

    private static Box<int[]> MyFunction(int[] integerArray)
    {
        return new Box<int[]>([1, 2]);
    }

    private static int[] MyFunction2(int[] integerArray)
    {
        return new int[] { 3, 4, 5 };
    }
}
