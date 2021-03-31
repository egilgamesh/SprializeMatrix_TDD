using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpiralizeMatrix
{
    public class Matrix
    {
        //Fill Matrix initially with 0 on all indecies
        public int[,] SetInitialValues(int Size)
        {
            var InitialMatrix = new int[Size, Size];
            for (int row = 0; row < Size; row++)
                for (int column = 0; column < Size; column++)
                {
                    InitialMatrix[row, column] = 0;
                }
            return InitialMatrix;
        }

        //Sprialize Matrix 
        public int[,] SprializeMatrix(int[,] array)
        {
            //Define Number of rows and columns, with Rotation parameter
            int rows = array.GetLength(0);
            int cols = array.GetLength(1);
            int rotation = 0;

            //Define Boundaries of the matrix
            int TopEdge = 0;
            int leftEdge = 0;
            int BottomEdge = rows - 1;
            int RightEdge = cols - 1;
            Direction direction = Direction.Right;

            while (TopEdge <= BottomEdge && leftEdge <= RightEdge)
            {
                switch (direction)
                {
                    case Direction.Right:
                        //moving Left -> RightEdge
                        MoveLeft(ref array, ref TopEdge, ref leftEdge,ref RightEdge,ref rotation);
                        direction = Direction.Down;
                        break;
                    case Direction.Down:
                        //moving top -> BottomEdge
                        MoveDown(ref array, ref TopEdge, ref BottomEdge, ref RightEdge);
                        //Since we have traversed the whole last column, move leftEdge to previous columnm.
                        direction = Direction.Left;
                        break;
                    case Direction.Left:
                        //Move RightEdge -> leftEdge
                        MoveLeft(ref array, ref BottomEdge, ref RightEdge, ref leftEdge);
                        // Since we have traversed the whole last row, move up to the previous row.
                        direction = Direction.Up;
                        break;
                    case Direction.Up:
                        // Move BottomEdge -> TopEdge
                        MoveUp(ref array, ref BottomEdge, ref TopEdge, ref leftEdge,ref rotation);
                        // Since we have traversed the whole first column, move RightEdge to the next column
                        direction = Direction.Right;
                        break;
                }
            }
            return array;

        }

        private void MoveUp(ref int[,] array, ref int BottomEdge, ref int TopEdge, ref int leftEdge, ref int rotation)
        {
            for (int i = BottomEdge; (i >= TopEdge); i--)
            {
                array[i, leftEdge] = 1;
            }

            leftEdge++;
            BottomEdge--;
            rotation++;
        }

        private void MoveLeft(ref int[,] array, ref int BottomEdge, ref int RightEdge, ref int leftEdge)
        {
            for (int i = RightEdge; (i >= leftEdge); i--)
            {
                array[BottomEdge, i] = 1;
            }
            BottomEdge--;
            RightEdge--;
        }

        private void MoveDown(ref int[,] array, ref int TopEdge, ref int BottomEdge, ref int RightEdge)
        {
            for (int i = TopEdge; (i <= BottomEdge); i++)
            {
                array[i, RightEdge] = 1;
            }
            //Since we have traversed the whole last column, move leftEdge to previous columnm.
            RightEdge--;
            TopEdge++;
        }

        private void MoveLeft(ref int[,] array, ref int TopEdge, ref int leftEdge, ref int RightEdge, ref int rotation)
        {
            for (int i = leftEdge; (i <= RightEdge); i++)
            {
                array[TopEdge, i] = 1;
            }
            //Since we have traversed the whole first row,move BottomEdge the next row
            TopEdge++;
            leftEdge += rotation; //Start new Sprialize Rotation
        }

        //Print Matrix
        public void Print(int[,] matrix)
        {
            var rowCount = matrix.GetLength(0);
            var colCount = matrix.GetLength(1);
            for (int row = 0; row < rowCount; row++)
            {
                for (int col = 0; col < colCount; col++)
                {
                    Console.Write(matrix[row, col] + "\t");

                }
                Console.WriteLine();
            }
        }

        public string MatrixSerialization(int[,] array)
        {
            string result = "[";
            result += string.Join(",", Enumerable.Range(0, array.GetUpperBound(0) + 1)
                .Select(x => Enumerable.Range(0, array.GetUpperBound(1) + 1)
                .Select(y => array[x, y])).Select(z => "[" + string.Join(",", z) + "]"));
            result += "]";
            return result;

        }

        private enum Direction
        {
            Right,
            Down,
            Left,
            Up
        }
    }
}
