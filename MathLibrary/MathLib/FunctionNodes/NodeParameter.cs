using System;
using System.Collections.Generic;


namespace MathLib
{
    public class NodeParameter : IFunctionNode
    {
        public string ParameterName { get; private set; }

        public NodeParameter(string parametername)
        {
            ParameterName = parametername;
        }

        public override string ToString()
        {
            return ParameterName;
        }

        public MyFraction GetValue(MyFraction x, Dictionary<string, MyFraction> parameter)
        {
            if (parameter.ContainsKey(ParameterName))
                return parameter[ParameterName];
            else
                throw new Exception("Parametername nicht gefunden.");
        }
        public double GetValueFloat(double x, Dictionary<string, double> parameter)
        {
            if (parameter.ContainsKey(ParameterName))
                return parameter[ParameterName];
            else
                throw new Exception("Parametername nicht gefunden.");
        }
        public bool IsFractionFunction()
        {
            return true;
        }
    }
}
