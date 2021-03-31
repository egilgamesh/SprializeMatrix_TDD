using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpiralizeMatrix;
using System;


namespace SprialUnitsTestProject
{
    [TestClass]
    public class TestSpiralize
    {
        [TestMethod]
        public void CheckSprialSerliazeMatrixWith5()
        {
            int ArraySize = 5;
            var matrix = new Matrix(ArraySize);
            matrix.SprializeMatrix();
            string Expected = "[[1,1,1,1,1],[0,0,0,0,1],[1,1,1,0,1],[1,0,0,0,1],[1,1,1,1,1]]";
            string Response = matrix.MatrixSerialization();
            Assert.AreEqual(Expected, Response);
        }
        [TestMethod]
        public void CheckMatrixAllowedOnlySizeGreaterThanOrEqual5()
        {
            int ArraySize = 5;
            var matrix = new Matrix(ArraySize);
            Assert.IsTrue( matrix.CheckSize());
        }
        [TestMethod]
        public void NotMatchSprialSerliazeMatrixWith5()
        {
            int ArraySize = 5;
            var matrix = new Matrix(ArraySize);
            matrix.SprializeMatrix();
            string Expected = "[[1,1,1,1,1],[0,0,1,0,1],[1,1,1,1,1],[1,0,0,0,1],[1,1,1,1,1]]";
            string Response = matrix.MatrixSerialization();
            Assert.AreNotEqual(Expected, Response);
        }
        [TestMethod]
        public void CheckSprialSerliazeMatrixWith10()
        {
            int ArraySize = 10;
            var matrix = new Matrix(ArraySize);
            matrix.SprializeMatrix();
            string Expected = "[[1,1,1,1,1,1,1,1,1,1],[0,0,0,0,0,0,0,0,0,1],[1,1,1,1,1,1,1,1,0,1],[1,0,0,0,0,0,0,1,0,1],[1,0,1,1,1,1,0,1,0,1],[1,0,1,0,0,1,0,1,0,1],[1,0,1,0,0,0,0,1,0,1],[1,0,1,1,1,1,1,1,0,1],[1,0,0,0,0,0,0,0,0,1],[1,1,1,1,1,1,1,1,1,1]]";
            string Response = matrix.MatrixSerialization();
            Assert.AreEqual(Expected, Response);
        }
        [TestMethod]
        public void CheckAllFirstRightColumnCellsAreSnakeTouch()
        {
            int ArraySize = 5;
            var matrix = new Matrix(ArraySize);
            bool Response = CheckFirstRightColumn(matrix.SprializeMatrix());
            Assert.IsTrue(Response);
        }
        private bool CheckFirstRightColumn(int[,] Array)
        {
            bool Result =false;
            int Rows = Array.GetLength(0);
            int Columns = Array.GetLength(1);
            int Top = 0;
            int Bottom = Rows - 1;
            int Right = Columns - 1;
            for (int i = Top; i <= Bottom; i++) 
                if (Array[i, Right] == 1) Result = true; else return false;
            return Result;
        }
    }
}
