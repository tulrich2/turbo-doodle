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
        public override bool Equals(object obj)
        {
            if (obj.GetType() == typeof(NodeMinus))
                return this == ((NodeMinus)obj);

            return false;
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
        public IFunctionNode Minimize()
        {
            OperandNode = OperandNode.Minimize();

            if (OperandNode is NodeConstant)
            {
                NodeConstant constNode = (NodeConstant)OperandNode;
                if (constNode.ConstantValue == 0)
                    return constNode;
                return new NodeConstant(-constNode.ConstantValue);
            }
            else if (OperandNode is NodeMinus)
                return ((NodeMinus)OperandNode).OperandNode.Minimize();

            return this;
        }

        public static bool operator ==(NodeMinus op1, NodeMinus op2)
        {
            return op1.OperandNode.Equals(op2.OperandNode);
        }
        public static bool operator !=(NodeMinus op1, NodeMinus op2)
        {
            return !op1.OperandNode.Equals(op2.OperandNode);
        }
    }
}
