using System.Collections.Generic;


namespace MathLib
{
    public class MyFunction : IFunctionNode
    {
        public IFunctionNode RootNode { get; private set; }

        public MyFunction(IFunctionNode rootnode)
        {
            RootNode = rootnode;
        }

        public override string ToString()
        {
            return RootNode.ToString();
        }

        public MyFraction GetValue(MyFraction x, Dictionary<string, MyFraction> parameter)
        {
            return RootNode.GetValue(x, parameter);
        }
        public double GetValueFloat(double x, Dictionary<string, double> parameter)
        {
            return RootNode.GetValueFloat(x, parameter);
        }
        public bool IsFractionFunction()
        {
            return RootNode.IsFractionFunction();
        }
        public IFunctionNode Minimize()
        {
            RootNode = RootNode.Minimize();

            return this;
        }

        public MyFraction Integrate(MyFraction from, MyFraction to, int samples, Dictionary<string, MyFraction> parameter)
        {
            MyFraction integralValue = 0;
            MyFraction sampleWidth = (to - from) / samples;
            for (int sampleIndex = 0; sampleIndex < samples; sampleIndex++)
            {
                MyFraction currentX = ((from + (sampleIndex * sampleWidth)) + (from + ((sampleIndex + 1) * sampleWidth))) / 2;
                integralValue += RootNode.GetValue(currentX, parameter) * sampleWidth;
            }
            return integralValue;
        }
    }
}
