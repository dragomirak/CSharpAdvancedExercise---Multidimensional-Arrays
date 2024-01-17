namespace P01.DiagonalDifference
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixDim = int.Parse(Console.ReadLine());
            int[,] matrix = new int[matrixDim, matrixDim];

            int sumDiagonal1 = 0;
            int sumDiagonal2 = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] rowData = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowData[col];

                    if (row == col)
                    {
                        sumDiagonal1 += matrix[row, col];
                    }

                    if (col == matrixDim - 1 - row)
                    {
                        sumDiagonal2 += matrix[row, col];
                    }
                }
            }

            Console.WriteLine(Math.Abs(sumDiagonal1 - sumDiagonal2));

        }
    }
}