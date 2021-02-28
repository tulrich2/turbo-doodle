using System.Collections.Generic;


namespace MathLib
{
    public class NodeAddition : IFunctionNode
    {
        public IFunctionNode LeftOperandNode { get; private set; }
        public IFunctionNode RightOperandNode { get; private set; }

        public NodeAddition(IFunctionNode leftoperandnode, IFunctionNode rightoperandnode)
        {
            LeftOperandNode = leftoperandnode;
            RightOperandNode = rightoperandnode;
        }

        public override string ToString()
        {
            return "(" + LeftOperandNode.ToString() + " + " + RightOperandNode.ToString() + ")";
        }
        public override bool Equals(object obj)
        {
            if (obj.GetType() == typeof(NodeAddition))
                return this == ((NodeAddition)obj);

            return false;
        }

        public MyFraction GetValue(MyFraction x, Dictionary<string, MyFraction> parameter)
        {
            return LeftOperandNode.GetValue(x, parameter) + RightOperandNode.GetValue(x, parameter);
        }
        public double GetValueFloat(double x, Dictionary<string, double> parameter)
        {
            return LeftOperandNode.GetValueFloat(x, parameter) + RightOperandNode.GetValueFloat(x, parameter);
        }
        public bool IsFractionFunction()
        {
            return LeftOperandNode.IsFractionFunction() && RightOperandNode.IsFractionFunction();
        }
        public IFunctionNode Minimize()
        {
            LeftOperandNode = LeftOperandNode.Minimize();
            RightOperandNode = RightOperandNode.Minimize();


            if (LeftOperandNode is NodeMultiplication) // ((a * b) + c)
            {
                NodeMultiplication multiplicationNode = (NodeMultiplication)LeftOperandNode;
                if (multiplicationNode.LeftOperandNode.Equals(RightOperandNode)) // ((a * b) + a) = (a * (b + 1))
                {
                    IFunctionNode newLeftOperand = RightOperandNode;
                    IFunctionNode newRightOperand = (new NodeAddition(multiplicationNode.RightOperandNode, new NodeConstant(1))).Minimize();
                    return (new NodeMultiplication(newLeftOperand, newRightOperand)).Minimize();
                }
                else if (multiplicationNode.RightOperandNode.Equals(RightOperandNode)) // ((a * b) + b) = ((a + 1) * b)
                {
                    IFunctionNode newLeftOperand = (new NodeAddition(multiplicationNode.LeftOperandNode, new NodeConstant(1))).Minimize();
                    IFunctionNode newRightOperand = RightOperandNode;
                    return (new NodeMultiplication(newLeftOperand, newRightOperand)).Minimize();
                }
            }
            else if (RightOperandNode is NodeMultiplication) // (c + (a * b))
            {
                NodeMultiplication multiplicationNode = (NodeMultiplication)RightOperandNode;
                if (multiplicationNode.LeftOperandNode.Equals(LeftOperandNode)) // (a + (a * b)) = (a * (b + 1))
                {
                    IFunctionNode newLeftOperand = LeftOperandNode;
                    IFunctionNode newRightOperand = (new NodeAddition(multiplicationNode.RightOperandNode, new NodeConstant(1))).Minimize();
                    return (new NodeMultiplication(newLeftOperand, newRightOperand)).Minimize();
                }
                else if (multiplicationNode.RightOperandNode.Equals(LeftOperandNode)) // (b + (a * b)) = ((a + 1) * b)
                {
                    IFunctionNode newLeftOperand = (new NodeAddition(multiplicationNode.LeftOperandNode, new NodeConstant(1))).Minimize();
                    IFunctionNode newRightOperand = LeftOperandNode;
                    return (new NodeMultiplication(newLeftOperand, newRightOperand)).Minimize();
                }
            }

            if (LeftOperandNode is NodeConstant && RightOperandNode is NodeConstant)
                return new NodeConstant(((NodeConstant)LeftOperandNode).ConstantValue + ((NodeConstant)RightOperandNode).ConstantValue);
            else if (LeftOperandNode is NodeConstant)
            {
                if (((NodeConstant)LeftOperandNode).ConstantValue == 0)
                    return RightOperandNode;
            }
            else if (RightOperandNode is NodeConstant)
            {
                if (((NodeConstant)RightOperandNode).ConstantValue == 0)
                    return LeftOperandNode;
            }
            else if (RightOperandNode is NodeMinus)
                return (new NodeSubtraction(LeftOperandNode, ((NodeMinus)RightOperandNode).OperandNode)).Minimize();
            else if (LeftOperandNode is NodeMinus)
                return (new NodeSubtraction(RightOperandNode, ((NodeMinus)LeftOperandNode).OperandNode)).Minimize();
            else if (LeftOperandNode.Equals(RightOperandNode))
                return (new NodeMultiplication(new NodeConstant(2), RightOperandNode)).Minimize();

            return this;
        }

        public static bool operator ==(NodeAddition op1, NodeAddition op2)
        {
            return (op1.LeftOperandNode.Equals(op2.LeftOperandNode) && op1.RightOperandNode.Equals(op2.RightOperandNode)) || (op1.LeftOperandNode.Equals(op2.RightOperandNode) && op1.RightOperandNode.Equals(op2.LeftOperandNode));
        }
        public static bool operator !=(NodeAddition op1, NodeAddition op2)
        {
            return (!op1.LeftOperandNode.Equals(op2.LeftOperandNode) || !op1.RightOperandNode.Equals(op2.RightOperandNode)) && (!op1.LeftOperandNode.Equals(op2.RightOperandNode) || !op1.RightOperandNode.Equals(op2.LeftOperandNode));
        }
    }
}
