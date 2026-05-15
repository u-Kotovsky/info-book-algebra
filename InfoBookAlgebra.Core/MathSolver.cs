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

            for (int i = min; i < max; i++)
            {
                // i % 9 = local index per horiz
                ints.Add(i * i);
            }

            return ints;
        }
    }
}
