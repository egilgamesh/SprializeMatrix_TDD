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
            //Arrange
            int Array_Size = 5;
            var matrix = new Matrix();
            int[,] ListElements = matrix.SetInitialValues(Array_Size);
            matrix.SprializeMatrix(ListElements);
            string expected = "[[1,1,1,1,1],[0,0,0,0,1],[1,1,1,0,1],[1,0,0,0,1],[1,1,1,1,1]]";

            //Act
            string response = matrix.MatrixSerialization(ListElements);
            //Assert
            Assert.AreEqual(expected, response);
        }

        [TestMethod]
        public void CheckSprialSerliazeMatrixWith10()
        {
            //Arrange
            int Array_Size = 10;
            var matrix = new Matrix();
            int[,] ListElements = matrix.SetInitialValues(Array_Size);
            matrix.SprializeMatrix(ListElements);
            string expected = "[[1,1,1,1,1,1,1,1,1,1],[0,0,0,0,0,0,0,0,0,1],[1,1,1,1,1,1,1,1,0,1],[1,0,0,0,0,0,0,1,0,1],[1,0,1,1,1,1,0,1,0,1],[1,0,1,0,0,1,0,1,0,1],[1,0,1,0,0,0,0,1,0,1],[1,0,1,1,1,1,1,1,0,1],[1,0,0,0,0,0,0,0,0,1],[1,1,1,1,1,1,1,1,1,1]]";

            //Act
            string response = matrix.MatrixSerialization(ListElements);
            //Assert
            Assert.AreEqual(expected, response);
        }

        [TestMethod]
        public void CheckAllFirstRightColumnCellsAreSnakeTouch()
        {
            //Arrange
            int Array_Size = 5;
            var matrix = new Matrix();
            int[,] ListElements = matrix.SetInitialValues(Array_Size);
            //Act
            bool response = CheckFirstRightColumn(matrix.SprializeMatrix(ListElements));
            //Assert
            Assert.IsTrue(response);
        }

        private bool CheckFirstRightColumn(int[,] array)
        {
            bool result =false;
            int rows = array.GetLength(0);
            int columns = array.GetLength(1);
            int top = 0;
            int bottom = rows - 1;
            int right = columns - 1;
            for (int i = top; i <= bottom; i++)
            {
                if (array[i,right] ==1)
                {
                    result = true;
                }
                else
                {
                    return false;
                }
            }

            return result;
        }
    }
}
