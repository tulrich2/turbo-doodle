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
        public override bool Equals(object obj)
        {
            if (obj.GetType() == typeof(NodeVariable))
                return this == ((NodeVariable)obj);

            return false;
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
        public IFunctionNode Minimize()
        {
            return this;
        }

        public static bool operator ==(NodeVariable op1, NodeVariable op2)
        {
            return true;
        }
        public static bool operator !=(NodeVariable op1, NodeVariable op2)
        {
            return false;
        }
    }
}
