using System.Collections.Generic;


namespace MathLib
{
    public class NodeConstant : IFunctionNode
    {
        public MyFraction ConstantValue { get; private set; }

        public NodeConstant(MyFraction constantvalue)
        {
            ConstantValue = constantvalue;
        }

        public override string ToString()
        {
            string constantString = ConstantValue.ToString();
            if (constantString.Contains('/'))
                constantString = "(" + constantString + ")";
            return constantString;
        }

        public MyFraction GetValue(MyFraction x, Dictionary<string, MyFraction> parameter)
        {
            return ConstantValue;
        }
        public double GetValueFloat(double x, Dictionary<string, double> parameter)
        {
            return ConstantValue.Numerator / (double)ConstantValue.Denominator;
        }
        public bool IsFractionFunction()
        {
            return true;
        }
    }
}
