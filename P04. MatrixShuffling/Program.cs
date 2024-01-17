using System;
using System.Data;

namespace P04._MatrixShuffling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int rows = matrixSize[0];
            int cols = matrixSize[1];

            string[,] matrix = new string[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string[] rowData = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = rowData[col];
                }
            }

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] tokens = input.Split(" ").ToArray();
                string command = tokens[0];

                if (command != "swap" || tokens.Length != 5)
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                int rowFirstElement = int.Parse(tokens[1]);
                int colFirstElement = int.Parse(tokens[2]);
                int rowSecondElement = int.Parse(tokens[3]);
                int colSecondElement = int.Parse(tokens[4]);

                if (CheckValidity(rowFirstElement, colFirstElement, rowSecondElement, colSecondElement, rows, cols))
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }
                else
                {
                    string temp = matrix[rowFirstElement, colFirstElement];
                    matrix[rowFirstElement, colFirstElement] = matrix[rowSecondElement, colSecondElement];
                    matrix[rowSecondElement, colSecondElement] = temp;

                    for (int row = 0; row < rows; row++)
                    {
                        for (int col = 0; col < cols; col++)
                        {
                            Console.Write(matrix[row, col] + " ");
                        }

                        Console.WriteLine();
                    }
                }
            }
        }

        static bool CheckValidity(int row1, int col1, int row2, int col2, int rows, int cols)
        {
            return (row1 < 0 || row2 < 0 || row1 > rows - 1 || row2 > rows - 1 ||
                col1 < 0 || col2 < 0 || col1 > cols - 1 || col2 > cols - 1);
        }
    }
}