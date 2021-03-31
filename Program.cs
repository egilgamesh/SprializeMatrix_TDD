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
			string UserInput; // User input to resize matrix dimensions
			try
			{
				while (MatrixSize < 5)
				{
					Console.WriteLine("Enter Size of Matrix to Spiralize it, The Size of Matrix should be greater than or equal 5");
					UserInput = Console.ReadLine();
					if (UserInput != null) MatrixSize = int.Parse(UserInput);
				}
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

			var matrix = new Matrix();
			int[,] ListElements = matrix.SetInitialValues(matrixSize);
			matrix.SprializeMatrix(ListElements);
			matrix.Print(ListElements);
			Console.WriteLine(matrix.MatrixSerialization(ListElements));
			Console.ReadKey();
		}
	}

}


