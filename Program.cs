using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SpiralizeMatrix
{
	class Program
	{
		static void Main(string[] args)
		{
			int MatrixSize = 0; 
			string UserInput;
			try
			{
				Console.WriteLine("Enter Size of Matrix to Spiralize it, The Size of Matrix should be greater than or equal 5");
				UserInput = Console.ReadLine();
				if (UserInput != null) MatrixSize = int.Parse(UserInput);
				InitiateMatrix(MatrixSize);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message.ToString());
				Console.ReadKey();
			}
		}

		private static void InitiateMatrix(int matrixSize)
		{
			var matrix = new Matrix(matrixSize);
			if (matrix.CheckSize())
			{
				matrix.SprializeMatrix();
				matrix.Print();
				Console.WriteLine(matrix.MatrixSerialization());
				Console.ReadKey();
			}
			else
			Console.ReadKey();
		}
	}

}


