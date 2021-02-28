using System;
using System.Collections.Generic;


namespace MathLib
{
    public class NodePowerInt : IFunctionNode
    {
        public IFunctionNode Base { get; private set; }
        public IFunctionNode Exponent { get; private set; }

        public NodePowerInt(IFunctionNode _base, IFunctionNode exponent)
        {
            Base = _base;
            Exponent = exponent;
        }

        public override string ToString()
        {
            return "(" + Base.ToString() + " ^ " + Exponent.ToString() + ")";
        }
        public override bool Equals(object obj)
        {
            if (obj.GetType() == typeof(NodePowerInt))
                return this == ((NodePowerInt)obj);

            return false;
        }

        public MyFraction GetValue(MyFraction x, Dictionary<string, MyFraction> parameter)
        {
            MyFraction exponentValue = Exponent.GetValue(x, parameter);

            if (exponentValue.Denominator != 1 || exponentValue.Numerator < 0)
                throw new ArithmeticException("Nur nicht-negative ganzzahlige Exponenten erlaubt.");

            MyFraction baseValue = Base.GetValue(x, parameter);

            MyFraction returnValue = 1;
            for (int i = 0; i < exponentValue.Numerator; i++)
                returnValue *= baseValue;

            return returnValue;
        }
        public double GetValueFloat(double x, Dictionary<string, double> parameter)
        {
            double exponentValue = Exponent.GetValueFloat(x, parameter);

            if ((int)exponentValue != exponentValue || exponentValue < 0)
                throw new ArithmeticException("Nur nicht-negative ganzzahlige Exponenten erlaubt.");

            double baseValue = Base.GetValueFloat(x, parameter);

            double returnValue = 1;
            for (int i = 0; i < exponentValue; i++)
                returnValue *= baseValue;

            return returnValue;
        }
        public bool IsFractionFunction()
        {
            return Base.IsFractionFunction() && Exponent.IsFractionFunction();
        }
        public IFunctionNode Minimize()
        {
            Base = Base.Minimize();
            Exponent = Exponent.Minimize();

            if (Exponent is NodeConstant)
            {
                NodeConstant constExponent = (NodeConstant)Exponent;
                if (constExponent.ConstantValue == 0)
                    return new NodeConstant(1);
                else if (constExponent.ConstantValue == 1)
                    return Base.Minimize();
                else if (Base is NodeConstant)
                {
                    if (constExponent.ConstantValue.Denominator != 1 || constExponent.ConstantValue.Numerator < 0)
                        throw new ArithmeticException("Nur nicht-negative ganzzahlige Exponenten erlaubt.");

                    NodeConstant constBase = (NodeConstant)Base;
                    MyFraction returnValue = 1;
                    for (int i = 0; i < constExponent.ConstantValue.Numerator; i++)
                        returnValue *= constBase.ConstantValue;

                    return new NodeConstant(returnValue);
                }
            }

            return this;
        }
        public IFunctionNode Differentiate()
        {
            return new NodeMultiplication(new NodeMultiplication(Exponent, new NodePowerInt(Base, new NodeSubtraction(Exponent, new NodeConstant(1)))), Base.Differentiate());
        }

        public static bool operator ==(NodePowerInt op1, NodePowerInt op2)
        {
            return op1.Base.Equals(op2.Base) && op1.Exponent.Equals(op2.Exponent);
        }
        public static bool operator !=(NodePowerInt op1, NodePowerInt op2)
        {
            return !op1.Base.Equals(op2.Base) || !op1.Exponent.Equals(op2.Exponent);
        }
    }
}
