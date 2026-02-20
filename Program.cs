
using Solution;

class MainClass
{
    static void Main()
    {
        DebugArray();
    }
    
    static void DebugArray()
    {
        
        int[][] jaggedArray = new int[][]{
            new int[] { 2, 4, 8} ,
            new int[] { 1, 3},
            null,
            new int[] { 0, 5, 10, 15},
            new int[] {},
        };

        // 3 x 4 multidimensional array
        int[,] multiDimArray = new int[,] { 
            { 1,   2,   3,   4 }, 
            { 5,   6,   7,  -8 }, 
            { 9,  10,  11,  12 } 
        };

        Tuple<int, int, int>[] RGB = new Tuple<int, int, int>[]{
            Tuple.Create(1,2,3),
            Tuple.Create(11,22,33),
            Tuple.Create(111,222,333),
            Tuple.Create(10,20,30),
            Tuple.Create(101,202,303),
            Tuple.Create(10101,20202,30303),
        };

        var a = new int[] { 1, 2, 3 };
        var b = new int[] { 10, 12, 13 };

        var a_ = new string[] { "1", "2", "3" };
        var b_ = new string[] { "10", "12", "13" };

        var actualValue = MultiArray.RowSum(multiDimArray);
        actualValue = MultiArray.ColSum(multiDimArray);

        var maxRowIndexSum = MultiArray.MaxRowIndexSum(jaggedArray);
        var maxCol = MultiArray.MaxCol(jaggedArray);

        var split = MultiArray.Split(RGB);
        var zip = MultiArray.Zip(a, b);
        var zip_ = MultiArray.Zip(a_, b_);
        System.Console.WriteLine();
    }
}