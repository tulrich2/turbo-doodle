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
    }
}
