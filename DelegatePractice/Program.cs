using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
//只用一支method, 傳入委派來畫出 正、倒的靠左、靠右、置中三角形（共六種）

namespace DelegatePractice
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int Rows = 5;
			//靠左正三角形
			Func<int, int, string> leftTriangle = ((currentRow, totalRows) => new string('*', currentRow));
            var left = new Triangle();
			Console.WriteLine(left.GetTriangle(Rows, leftTriangle));


			//靠右正三角形
			Func<int, int, string> rightTriangle = ((currentRow, totalRows) => new string('*', currentRow).PadLeft(totalRows));
			var right = new Triangle();
			Console.WriteLine(right.GetTriangle(Rows,rightTriangle));

			//置中正三角形
			Func<int, int, string> isoscelesTriangle = ((currentRow, totalRows) => new string(' ', totalRows - currentRow) + new string('*', currentRow * 2 - 1));
			var isosceles = new Triangle();
			Console.WriteLine(isosceles.GetTriangle(Rows, isoscelesTriangle));

			//靠左倒三角形
			Func<int, int, string> invertedLeftTriangle = ((currentRow, totalRows) => new string('*', totalRows - currentRow + 1));
			var invertedLeft = new Triangle();
			Console.WriteLine(invertedLeft.GetTriangle(Rows,invertedLeftTriangle));

			//靠右倒三角形
			Func<int, int, string> invertedRightTriangle = ((currentRow, totalRows) => new string('*', totalRows - currentRow + 1).PadLeft(totalRows));
			var invertedRight = new Triangle();
			Console.WriteLine(invertedRight.GetTriangle(Rows,invertedRightTriangle));

			//置中倒三角形
			Func<int, int, string> invertedIsoscelesTriangle = ((currentRow, totalRows) => new string(' ', currentRow - 1) + new string('*', (totalRows - currentRow + 1) * 2 - 1));
			var invertedIsosceles = new Triangle();
			Console.WriteLine(invertedIsosceles.GetTriangle(Rows,invertedIsoscelesTriangle));
		}
	}
	public class Triangle
	{
		public string GetTriangle(int totalRows, Func<int,int, string> triangle)
		{
			string result = "";
			for (int currentRow = 1; currentRow <= totalRows; currentRow++)
			{
				result += (triangle(currentRow,totalRows)) + "\n";
			}
			return result;
		}
	}
}
