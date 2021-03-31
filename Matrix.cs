using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpiralizeMatrix
{
    public class Matrix
    {
        int[,] Array;
        int ArraySize;
        public Matrix(int Size)
        {
            ArraySize = Size;
            if (CheckSize()) Array = SetInitialValues(ArraySize);
            else
            Console.WriteLine("Size of Matrix should be greater than or equal 5");

        }

        public bool CheckSize()
        {
            if (ArraySize < 5) return false; else return true; 
        }

        public int[,] SetInitialValues(int Size)
        {
            
            var InitialMatrix = new int[ArraySize, ArraySize];
            for (int Row = 0; Row < ArraySize; Row++)
                for (int Column = 0; Column < Size; Column++)
                    InitialMatrix[Row, Column] = 0;
            return InitialMatrix;
        }

        public int[,] SprializeMatrix()
        {
            int Rows = Array.GetLength(0);
            int Columns = Array.GetLength(1);
            int Rotation = 0;
            int TopEdge = 0;
            int leftEdge = 0;
            int BottomEdge = Rows - 1;
            int RightEdge = Columns - 1;
            var direction = Direction.Right;
            while (TopEdge <= BottomEdge && leftEdge <= RightEdge)
            {
                switch (direction)
                {
                    case Direction.Right:
                        MoveLeft(ref TopEdge, ref leftEdge,ref RightEdge,ref Rotation);
                        direction = Direction.Down;
                        break;
                    case Direction.Down:
                        MoveDown(ref TopEdge, ref BottomEdge, ref RightEdge);
                        direction = Direction.Left;
                        break;
                    case Direction.Left:
                        MoveLeft(ref BottomEdge, ref RightEdge, ref leftEdge);
                        direction = Direction.Up;
                        break;
                    case Direction.Up:
                        MoveUp(ref BottomEdge, ref TopEdge, ref leftEdge,ref Rotation);
                        direction = Direction.Right;
                        break;
                }
            }
            return Array;
        }
        private void MoveUp(ref int BottomEdge, ref int TopEdge, ref int leftEdge, ref int Rotation)
        {
            for (int i = BottomEdge; (i >= TopEdge); i--)
                Array[i, leftEdge] = 1;
            leftEdge++;
            BottomEdge--;
            Rotation++;
        }

        private void MoveLeft(ref int BottomEdge, ref int RightEdge, ref int leftEdge)
        {
            for (int i = RightEdge; (i >= leftEdge); i--)
                Array[BottomEdge, i] = 1;
            BottomEdge--;
            RightEdge--;
        }

        private void MoveDown(ref int TopEdge, ref int BottomEdge, ref int RightEdge)
        {
            for (int i = TopEdge; (i <= BottomEdge); i++)
                Array[i, RightEdge] = 1;
            RightEdge--;
            TopEdge++;
        }

        private void MoveLeft(ref int TopEdge, ref int leftEdge, ref int RightEdge, ref int Rotation)
        {
            for (int i = leftEdge; (i <= RightEdge); i++)
                Array[TopEdge, i] = 1;
            TopEdge++;
            leftEdge += Rotation;
        }

        public void Print()
        {
            var Rows = Array.GetLength(0);
            var Columns = Array.GetLength(1);
            for (int Row = 0; Row < Rows; Row++)
            {
                for (int col = 0; col < Columns; col++)
                    Console.Write(Array[Row, col] + "\t");
                Console.WriteLine();
            }
        }

        public string MatrixSerialization()
        {
            string Result = "[";
            Result += string.Join(",", Enumerable.Range(0, Array.GetUpperBound(0) + 1)
                .Select(x => Enumerable.Range(0, Array.GetUpperBound(1) + 1)
                .Select(y => Array[x, y])).Select(z => "[" + string.Join(",", z) + "]"));
            Result += "]";
            return Result;
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
