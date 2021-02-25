using System.Collections.Generic;


namespace MathLib
{
    public interface IFunctionNode
    {
        public MyFraction GetValue(MyFraction x, Dictionary<string, MyFraction> parameter);
        public double GetValueFloat(double x, Dictionary<string, double> parameter);
        public bool IsFractionFunction();
    }
}
