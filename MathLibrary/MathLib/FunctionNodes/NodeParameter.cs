﻿using System;
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
        public override bool Equals(object obj)
        {
            if (obj.GetType() == typeof(NodeParameter))
                return this == ((NodeParameter)obj);

            return false;
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
        public IFunctionNode Minimize()
        {
            return this;
        }
        public IFunctionNode Differentiate()
        {
            return new NodeConstant(0);
        }

        public static bool operator ==(NodeParameter op1, NodeParameter op2)
        {
            return op1.ParameterName == op2.ParameterName;
        }
        public static bool operator !=(NodeParameter op1, NodeParameter op2)
        {
            return op1.ParameterName != op2.ParameterName;
        }
    }
}