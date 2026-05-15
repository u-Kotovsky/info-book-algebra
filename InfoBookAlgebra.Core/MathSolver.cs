using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoBookAlgebra.Core
{
    public class MathSolver
    {
        public static double SolveVietteTheorem()
        {
            // todo: solver

            throw new NotImplementedException();
        }

        public static List<int> GetSquareTable(int min = 0, int max = 100)
        {
            List<int> ints = [];

            for (int i = 0; i < 100; i++)
            {
                // i % 9 = local index per horiz
                ints.Add(i * i);
            }

            return ints;
        }
    }
}
