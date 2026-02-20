

using System.Numerics;

namespace Solution;

public class MultiArray : IMultiArray
{
    public static T[]? RowSum<T>(T[,] arr2D) where T : INumber<T>
    {
        if (arr2D == null) return null;
        
        int rows = arr2D.GetLength(0);
        int cols = arr2D.GetLength(1);
        T[] result = new T[rows];

        for(int i = 0; i < rows; i++)
        {
            T sum = T.Zero;
            for(int j = 0; j < cols; j++)
            {
                sum += arr2D[i, j];
            }
            result[i] = sum;
        }
        return result;
    }

    public static T[]? ColSum<T>(T[,] arr2D) where T : INumber<T>
    {        
        if (arr2D == null)
            return null;

        int rows = arr2D.GetLength(0);
        int cols = arr2D.GetLength(1);

        T[] result = new T[cols];

        for (int i = 0; i < cols; i++)
        {
            T sum = T.Zero;
            for (int j = 0; j < rows; j++)
            {
                sum += arr2D[j, i];
            }
            result[i] = sum;
        }

        return result;
    }

    public static Tuple<int, T>? MaxRowIndexSum<T>(T[][] arrJagged) where T : INumber<T>
    {        
        if (arrJagged == null)
            return null;

        T maxSum = T.Zero;
        int maxIndex = -1;
        for(int i = 0; i < arrJagged.Length; i++)
        {
            if (arrJagged[i] == null)
                continue;

            T sum = T.Zero;
            foreach (T value in arrJagged[i])
            {
                sum += value;
            }

            if(sum > maxSum)
            {
                maxSum = sum;
                maxIndex = i;
            }
        }
        return Tuple.Create(maxIndex, maxSum);
    }

    public static T?[] MaxCol<T>(T[][] arrJagged) where T : INumber<T>
    {
        T maxSum = T.Zero;
        int maxColLength = arrJagged.Where(row => row != null).Max(row => row.Length);

        List<T[]> colArrays = new List<T[]>();

        for (int col = 0; col < maxColLength; col++)
        {
            List<T> colArray = new List<T>();
            for (int row = 0; row < arrJagged.Length; row++)
            {
                if (arrJagged[row] != null && arrJagged[row].Length > col)
                {
                    colArray.Add(arrJagged[row][col]);
                }
                else
                {
                    colArray.Add(T.Zero);
                }
            }
            colArrays.Add(colArray.ToArray());
        }
        T[][] colJagged = colArrays.ToArray();

        var (index, sum) = MaxRowIndexSum(colJagged);

        return colJagged[index];
    }

    public static T[][]? Split<T>(Tuple<T, T, T>[] input)
    {        
        //ToDo
        throw new NotImplementedException();
    }

    public static T[,]? Zip<T>(T[] a, T[] b)
    {        
        //ToDo
        throw new NotImplementedException();
    }
}
