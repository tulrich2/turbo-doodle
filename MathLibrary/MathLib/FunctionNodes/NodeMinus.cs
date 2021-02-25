using System.Collections.Generic;


namespace MathLib
{
    public class NodeMinus : IFunctionNode
    {
        public IFunctionNode OperandNode { get; private set; }

        public NodeMinus(IFunctionNode operandnode)
        {
            OperandNode = operandnode;
        }

        public override string ToString()
        {
            return "-" + OperandNode.ToString();
        }

        public MyFraction GetValue(MyFraction x, Dictionary<string, MyFraction> parameter)
        {
            return -OperandNode.GetValue(x, parameter);
        }
        public double GetValueFloat(double x, Dictionary<string, double> parameter)
        {
            return -OperandNode.GetValueFloat(x, parameter);
        }
        public bool IsFractionFunction()
        {
            return OperandNode.IsFractionFunction();
        }
    }
}
