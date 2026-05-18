namespace InfoBookAlgebra.Core
{
    public class MathSolver
    {
        public static List<double> SolveVietteTheorem(double a, double b, double c)
        {
            // ax^2 + bx + c = 0
            // a - 1st coeff, != 0
            // b - 2nd coeff
            // c - free member

            // can have 2 different roots, one root or no roots at all, depends by D

            // D = b^2 - 4ac

            //D > 0 = 2 diff roots
            //D = 0 = 1 root
            //D < 0 = no roots

            // when x^2 = 1
            // x^2 + bx + c = 0

            // okay for example we got
            // eq. = ax^2 - 5x + 6 = 0

            List<double> roots = new List<double>();

            double discriminant = Math.Sqrt(b * b - 4 * a * c);

            if (discriminant < 0)
            {
                return roots;
            }

            roots.Add((-b + discriminant) / (2 * a));

            if (discriminant == 0)
            {
                return roots;
            }

            roots.Add((-b - discriminant) / (2 * a));

            return roots;

            // Formula theorem Viette
            // x1+x2 = -b
            // x1*x2=c
            // sum roots = 2nd coeff with inv
            // multiplic roots = free member
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
