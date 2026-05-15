using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfoBookAlgebraCore;

namespace InfoBookAlgebra.Tests
{
    public class MathSolverTests
	{
		[Test]
		public void Test_GetSquareTable_At0ShouldBe0()
		{
			var table = MathSolver.GetSquareTable();
			var index = 0;
			var value = table[index];

			Assert.That(value == 0, $"{index}.{value}");
		}

		[Test]
		public void Test_GetSquareTable_At1ShouldBe1()
		{
			var table = MathSolver.GetSquareTable();
			var index = 1;
			var value = table[index];

			Assert.That(value == 1, $"{index}.{value}");
		}

		[Test]
		public void Test_GetSquareTable_At2ShouldBe4()
		{
			var table = MathSolver.GetSquareTable();
			var index = 2;
			var value = table[index];

			Assert.That(value == 4, $"{index}.{value}");
		}

		[Test]
		public void Test_GetSquareTable_At2ShouldBe4()
		{
			var table = MathSolver.GetSquareTable();
			var index = 2;
			var value = table[index];

			Assert.That(value == 4, $"{index}.{value}");
		}

	}
}
