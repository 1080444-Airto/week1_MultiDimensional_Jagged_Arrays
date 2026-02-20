

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
        if (arrJagged == null)
            return null;

        int rowCount = arrJagged.Length;

        int maxColLength = 0;
        for (int i = 0; i < rowCount; i++)
        {
            if (arrJagged[i] != null && arrJagged[i].Length > maxColLength)
            {
                maxColLength = arrJagged[i].Length;
            }
        }

        int maxColIndex = 0;
        T maxSum = T.Zero;

        for (int col = 0; col < maxColLength; col++)
        {
            T sum = T.Zero;

            for (int row = 0; row < rowCount; row++)
            {
                if (arrJagged[row] != null && arrJagged[row].Length > col)
                {
                    sum += arrJagged[row][col];
                }
            }

            if (col == 0 || sum > maxSum)
            {
                maxSum = sum;
                maxColIndex = col;
            }
        }

        T?[] result = new T?[rowCount];
        for (int row = 0; row < rowCount; row++)
        {
            if (arrJagged[row] != null && arrJagged[row].Length > maxColIndex)
            {
                result[row] = arrJagged[row][maxColIndex];
            }
            else
            {
                result[row] = T.Zero;
            }
        }

        return result;
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
