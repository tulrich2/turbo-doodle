using System.Collections.Generic;


namespace MathLib
{
    public class NodeMultiplication : IFunctionNode
    {
        public IFunctionNode LeftOperandNode { get; private set; }
        public IFunctionNode RightOperandNode { get; private set; }

        public NodeMultiplication(IFunctionNode leftoperandnode, IFunctionNode rightoperandnode)
        {
            LeftOperandNode = leftoperandnode;
            RightOperandNode = rightoperandnode;
        }

        public override string ToString()
        {
            return "(" + LeftOperandNode.ToString() + " * " + RightOperandNode.ToString() + ")";
        }

        public MyFraction GetValue(MyFraction x, Dictionary<string, MyFraction> parameter)
        {
            return LeftOperandNode.GetValue(x, parameter) * RightOperandNode.GetValue(x, parameter);
        }
        public double GetValueFloat(double x, Dictionary<string, double> parameter)
        {
            return LeftOperandNode.GetValueFloat(x, parameter) * RightOperandNode.GetValueFloat(x, parameter);
        }
        public bool IsFractionFunction()
        {
            return LeftOperandNode.IsFractionFunction() && RightOperandNode.IsFractionFunction();
        }
    }
}
