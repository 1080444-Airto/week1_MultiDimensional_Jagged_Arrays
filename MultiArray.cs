

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

        T[][] colJagged = new T[maxColLength][];

        for (int col = 0; col < maxColLength; col++)
        {
            colJagged[col] = new T[rowCount];

            for (int row = 0; row < rowCount; row++)
            {
                if (arrJagged[row] != null && arrJagged[row].Length > col)
                {
                    colJagged[col][row] = arrJagged[row][col];
                }
                else
                {
                    colJagged[col][row] = T.Zero;
                }
            }
        }

        var resultTuple = MaxRowIndexSum(colJagged);

        if (resultTuple == null)
            return null;

        int index = resultTuple.Item1;

        return colJagged[index];
    }

    public static T[][]? Split<T>(Tuple<T, T, T>[] input)
    {        
        if (input == null)
            return null;

        int inputLength = input.Length;

        T[][] result = new T[3][];
        result[0] = new T[inputLength];
        result[1] = new T[inputLength];
        result[2] = new T[inputLength];

        for (int i = 0; i < inputLength; i++)
        {
            result[0][i] = input[i].Item1;
            result[1][i] = input[i].Item2;
            result[2][i] = input[i].Item3;
        }

        return result;
    }

    public static T[,]? Zip<T>(T[] a, T[] b)
    {
        if (a == null || b == null)
            return null;

        int maxLength = (a.Length > b.Length) ? a.Length : b.Length;

        T[,] result = new T[maxLength, 2];

        for (int row = 0; row < maxLength; row++)
        {
            result[row, 0] = (row < a.Length) ? a[row] : default(T);
            result[row, 1] = (row < b.Length) ? b[row] : default(T);
        }

        return result;
    }
}