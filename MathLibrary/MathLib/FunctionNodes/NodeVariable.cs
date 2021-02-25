using System.Collections.Generic;


namespace MathLib
{
    public class NodeVariable : IFunctionNode
    {
        public NodeVariable() { }

        public override string ToString()
        {
            return "x";
        }

        public MyFraction GetValue(MyFraction x, Dictionary<string, MyFraction> parameter)
        {
            return x;
        }
        public double GetValueFloat(double x, Dictionary<string, double> parameter)
        {
            return x;
        }
        public bool IsFractionFunction()
        {
            return true;
        }
    }
}
