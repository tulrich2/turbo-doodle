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
        public override bool Equals(object obj)
        {
            if (obj.GetType() == typeof(NodeMultiplication))
                return this == ((NodeMultiplication)obj);

            return false;
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
        public IFunctionNode Minimize()
        {
            LeftOperandNode = LeftOperandNode.Minimize();
            RightOperandNode = RightOperandNode.Minimize();

            if (LeftOperandNode is NodeConstant && RightOperandNode is NodeConstant)
                return new NodeConstant(((NodeConstant)LeftOperandNode).ConstantValue * ((NodeConstant)RightOperandNode).ConstantValue);
            else if (LeftOperandNode is NodeConstant)
            {
                NodeConstant constNode = (NodeConstant)LeftOperandNode;
                if (constNode.ConstantValue == 0)
                    return new NodeConstant(0);
                else if (constNode.ConstantValue == 1)
                    return RightOperandNode.Minimize();
                else if (constNode.ConstantValue == -1)
                    return (new NodeMinus(RightOperandNode.Minimize())).Minimize();
            }
            else if (RightOperandNode is NodeConstant)
            {
                NodeConstant constNode = (NodeConstant)RightOperandNode;
                if (constNode.ConstantValue == 0)
                    return new NodeConstant(0);
                else if (constNode.ConstantValue == 1)
                    return LeftOperandNode.Minimize();
                else if (constNode.ConstantValue == -1)
                    return (new NodeMinus(LeftOperandNode.Minimize())).Minimize();
            }
            else if (LeftOperandNode.Equals(RightOperandNode))
                return (new NodePowerInt(LeftOperandNode, new NodeConstant(2)));
            else if (LeftOperandNode is NodePowerInt) // ((a^b) * c)
            {
                NodePowerInt powerNode = (NodePowerInt)LeftOperandNode;
                if (powerNode.Base.Equals(RightOperandNode)) // ((a^b) * a) = (a^(b + 1))
                    return (new NodePowerInt(powerNode.Base, new NodeAddition(powerNode.Exponent, new NodeConstant(1)))).Minimize();
            }
            else if (RightOperandNode is NodePowerInt) // (c * (a^b))
            {
                NodePowerInt powerNode = (NodePowerInt)RightOperandNode;
                if (powerNode.Base.Equals(LeftOperandNode)) // (a * (a^b)) = (a^(b + 1))
                    return (new NodePowerInt(powerNode.Base, new NodeAddition(powerNode.Exponent, new NodeConstant(1)))).Minimize();
            }

            return this;
        }
        public IFunctionNode Differentiate()
        {
            return new NodeAddition(new NodeMultiplication(LeftOperandNode.Differentiate(), RightOperandNode), new NodeMultiplication(LeftOperandNode, RightOperandNode.Differentiate()));
        }

        public static bool operator ==(NodeMultiplication op1, NodeMultiplication op2)
        {
            return (op1.LeftOperandNode.Equals(op2.LeftOperandNode) && op1.RightOperandNode.Equals(op2.RightOperandNode)) || (op1.LeftOperandNode.Equals(op2.RightOperandNode) && op1.RightOperandNode.Equals(op2.LeftOperandNode));
        }
        public static bool operator !=(NodeMultiplication op1, NodeMultiplication op2)
        {
            return (!op1.LeftOperandNode.Equals(op2.LeftOperandNode) || !op1.RightOperandNode.Equals(op2.RightOperandNode)) && (!op1.LeftOperandNode.Equals(op2.RightOperandNode) || !op1.RightOperandNode.Equals(op2.LeftOperandNode));
        }
    }
}
