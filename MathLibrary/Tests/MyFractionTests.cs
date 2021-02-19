using System;

using MathLib;


namespace Tests
{
    public static class MyFractionTests
    {
        public static void Test()
        {
            testConstructor();
            testToString();
            testAddition();
            testSubtraction();
            testMultiplication();
            testDivision();
        }

        private static void testConstructor()
        {
            MyFraction generatedFraction_0 = new MyFraction(0, 1);
            if (generatedFraction_0.Numerator != 0 || generatedFraction_0.Denominator != 1)
                Console.Out.WriteLine("[MyFractionTests/testConstructor] Test 0 failed.");

            MyFraction generatedFraction_1 = new MyFraction(0, 10);
            if (generatedFraction_1.Numerator != 0 || generatedFraction_1.Denominator != 1)
                Console.Out.WriteLine("[MyFractionTests/testConstructor] Test 1 failed.");

            MyFraction generatedFraction_2 = new MyFraction(2, 4);
            if (generatedFraction_2.Numerator != 1 || generatedFraction_2.Denominator != 2)
                Console.Out.WriteLine("[MyFractionTests/testConstructor] Test 2 failed.");

            MyFraction generatedFraction_3 = new MyFraction(-10, 5);
            if (generatedFraction_3.Numerator != -2 || generatedFraction_3.Denominator != 1)
                Console.Out.WriteLine("[MyFractionTests/testConstructor] Test 3 failed.");
        }
        private static void testToString()
        {
            if ((new MyFraction(0, 1)).ToString() != "0")
                Console.Out.WriteLine("[MyFractionTests/testToString] Test 0 failed.");

            if ((new MyFraction(-3, 1)).ToString() != "-3")
                Console.Out.WriteLine("[MyFractionTests/testToString] Test 1 failed.");

            if ((new MyFraction(1, 2)).ToString() != "1 / 2")
                Console.Out.WriteLine("[MyFractionTests/testToString] Test 2 failed.");

            if ((new MyFraction(-100, 25)).ToString() != "-4")
                Console.Out.WriteLine("[MyFractionTests/testToString] Test 3 failed.");

            if ((new MyFraction(-3, 15)).ToString() != "- 1 / 5")
                Console.Out.WriteLine("[MyFractionTests/testToString] Test 4 failed.");
        }
        private static void testAddition()
        {
            MyFraction generatedFraction_0 = new MyFraction(0, 1) + new MyFraction(0, 10);
            if (generatedFraction_0.Numerator != 0 || generatedFraction_0.Denominator != 1)
                Console.Out.WriteLine("[MyFractionTests/testAddition] Test 0 failed.");

            MyFraction generatedFraction_1 = new MyFraction(1, 2) + new MyFraction(1, 3);
            if (generatedFraction_1.Numerator != 5 || generatedFraction_1.Denominator != 6)
                Console.Out.WriteLine("[MyFractionTests/testAddition] Test 1 failed.");

            MyFraction generatedFraction_2 = new MyFraction(-4, 6) + new MyFraction(12, 5);
            if (generatedFraction_2.Numerator != 26 || generatedFraction_2.Denominator != 15)
                Console.Out.WriteLine("[MyFractionTests/testAddition] Test 2 failed.");
        }
        private static void testSubtraction()
        {
            MyFraction generatedFraction_0 = new MyFraction(0, 1) - new MyFraction(0, 10);
            if (generatedFraction_0.Numerator != 0 || generatedFraction_0.Denominator != 1)
                Console.Out.WriteLine("{MyFractionTests/testSubtraction] Test 0 failed.");

            MyFraction generatedFraction_1 = new MyFraction(1, 2) - new MyFraction(1, 3);
            if (generatedFraction_1.Numerator != 1 || generatedFraction_1.Denominator != 6)
                Console.Out.WriteLine("{MyFractionTests/testSubtraction] Test 1 failed.");

            MyFraction generatedFraction_2 = new MyFraction(-4, 6) - new MyFraction(12, 5);
            if (generatedFraction_2.Numerator != -46 || generatedFraction_2.Denominator != 15)
                Console.Out.WriteLine("{MyFractionTests/testSubtraction] Test 2 failed.");
        }
        private static void testMultiplication()
        {
            MyFraction generatedFraction_0 = new MyFraction(0, 1) * new MyFraction(0, 10);
            if (generatedFraction_0.Numerator != 0 || generatedFraction_0.Denominator != 1)
                Console.Out.WriteLine("[MyFractionTests/testMultiplication] Test 0 failed.");

            MyFraction generatedFraction_1 = new MyFraction(1, 1) * new MyFraction(13, 10);
            if (generatedFraction_1.Numerator != 13 || generatedFraction_1.Denominator != 10)
                Console.Out.WriteLine("[MyFractionTests/testMultiplication] Test 1 failed.");

            MyFraction generatedFraction_2 = new MyFraction(2, 5) * new MyFraction(-3, 8);
            if (generatedFraction_2.Numerator != -3 || generatedFraction_2.Denominator != 20)
                Console.Out.WriteLine("[MyFractionTests/testMultiplication] Test 2 failed.");
        }
        private static void testDivision()
        {
            MyFraction generatedFraction_0 = new MyFraction(0, 1) / new MyFraction(100, 10);
            if (generatedFraction_0.Numerator != 0 || generatedFraction_0.Denominator != 1)
                Console.Out.WriteLine("[MyFractionTests/testDivision] Test 0 failed.");

            MyFraction generatedFraction_1 = new MyFraction(1, 1) / new MyFraction(2, 3);
            if (generatedFraction_1.Numerator != 3 || generatedFraction_1.Denominator != 2)
                Console.Out.WriteLine("[MyFractionTests/testDivision] Test 1 failed.");

            MyFraction generatedFraction_2 = new MyFraction(7, 13) / new MyFraction(-5, 8);
            if (generatedFraction_2.Numerator != -56 || generatedFraction_2.Denominator != 65)
                Console.Out.WriteLine("[MyFractionTests/testDivision] Test 2 failed.");
        }
    }
}
