using System.Collections.Generic;


namespace MathLib
{
    public class NodeSubtraction : IFunctionNode
    {
        public IFunctionNode LeftOperandNode { get; private set; }
        public IFunctionNode RightOperandNode { get; private set; }

        public NodeSubtraction(IFunctionNode leftoperandnode, IFunctionNode rightoperandnode)
        {
            LeftOperandNode = leftoperandnode;
            RightOperandNode = rightoperandnode;
        }

        public override string ToString()
        {
            return "(" + LeftOperandNode.ToString() + " - " + RightOperandNode.ToString() + ")";
        }
        public override bool Equals(object obj)
        {
            if (obj.GetType() == typeof(NodeSubtraction))
                return this == ((NodeSubtraction)obj);

            return false;
        }

        public MyFraction GetValue(MyFraction x, Dictionary<string, MyFraction> parameter)
        {
            return LeftOperandNode.GetValue(x, parameter) - RightOperandNode.GetValue(x, parameter);
        }
        public double GetValueFloat(double x, Dictionary<string, double> parameter)
        {
            return LeftOperandNode.GetValueFloat(x, parameter) - RightOperandNode.GetValueFloat(x, parameter);
        }
        public bool IsFractionFunction()
        {
            return LeftOperandNode.IsFractionFunction() && RightOperandNode.IsFractionFunction();
        }
        public IFunctionNode Minimize()
        {
            LeftOperandNode = LeftOperandNode.Minimize();
            RightOperandNode = RightOperandNode.Minimize();

            if (LeftOperandNode is NodeConstant && RightOperandNode is NodeConstant)
                return new NodeConstant(((NodeConstant)LeftOperandNode).ConstantValue - ((NodeConstant)RightOperandNode).ConstantValue);
            else if (LeftOperandNode is NodeConstant)
            {
                if (((NodeConstant)LeftOperandNode).ConstantValue == 0)
                    return (new NodeMinus(RightOperandNode)).Minimize();
            }
            else if (RightOperandNode is NodeConstant)
            {
                if (((NodeConstant)RightOperandNode).ConstantValue == 0)
                    return LeftOperandNode;
            }

            return this;
        }

        public static bool operator ==(NodeSubtraction op1, NodeSubtraction op2)
        {
            return op1.LeftOperandNode.Equals(op2.LeftOperandNode) && op1.RightOperandNode.Equals(op2.RightOperandNode);
        }
        public static bool operator !=(NodeSubtraction op1, NodeSubtraction op2)
        {
            return !op1.LeftOperandNode.Equals(op2.LeftOperandNode) || !op1.RightOperandNode.Equals(op2.RightOperandNode);
        }
    }
}
