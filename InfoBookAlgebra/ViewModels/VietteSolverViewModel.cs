using InfoBookAlgebra.Core;
using InfoBookAlgebra.Helpers;

namespace InfoBookAlgebra.ViewModels
{
    public class VietteSolverViewModel : NotifablePropertyChanged
    {
        public double a = 1;
        public double A
        { 
            get { return a; }
            set
            { 
                a = value;
                OnPropertyChanged(nameof(A));
                Solve();
            } 
        }
        
        public double b = -5;
        public double B
        { 
            get { return b; }
            set
            { 
                b = value;
                OnPropertyChanged(nameof(B));
                Solve();
            } 
        }
        
        public double c = 6;
        public double C
        { 
            get { return c; }
            set
            { 
                b = value;
                OnPropertyChanged(nameof(C));
                Solve();
            } 
        }

        private double r1;
        public double R1
        {
            get { return r1; }
            set
            {
                r1 = value;
                OnPropertyChanged(nameof(R1));
            }
        }

        private double r2;
        public double R2
        {
            get { return r2; }
            set
            {
                r2 = value;
                OnPropertyChanged(nameof(R2));
            }
        }

        public string R1Text 
        {
            get { return roots.Count > 1 ? $"r1 = {r1}" : "Корней нет"; } 
            set { }
        }

        public string R2Text 
        {
            get { return roots.Count > 2 ? $"r2 = {r2}" : "-"; } 
            set { } 
        }

        private List<double> roots = new List<double>();

        #region Commands
        private RelayCommand? _solveCommand;
        public RelayCommand SolveCommand
        {
            get
            {
                return _solveCommand ??= new RelayCommand(obj => { Solve(); });
            }
        }
        #endregion

        // For some reason bindings are not working in here......

        public void Solve()
        {
            roots = MathSolver.SolveVietteTheorem(A, B, C);

            R1 = roots[0];
            R2 = roots[0];
        }
    }
}
