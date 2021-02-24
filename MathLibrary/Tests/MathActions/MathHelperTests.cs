using System;
using System.Collections.Generic;

using MathLib;


namespace Tests
{
    public static class MathHelperTests
    {
        public static void Test()
        {
            testGetPrimeFactors();
            testGetGCD();
            testGetLCM();
        }

        private static void testGetPrimeFactors()
        {
            Dictionary<int, int> expectedPrimeFactors_0 = new Dictionary<int, int>() { { 1, 1 } };
            Dictionary<int, int> generatedPrimeFactors_0 = MathHelper.GetPrimeFactors(0);
            if (!arePrimeFactorsEqual(expectedPrimeFactors_0, generatedPrimeFactors_0))
                Console.Out.WriteLine("[MathHelperTests/testGetPrimeFactors] Test 0 failed.");

            Dictionary<int, int> expectedPrimeFactors_1 = new Dictionary<int, int>() { { 1, 1 } };
            Dictionary<int, int> generatedPrimeFactors_1 = MathHelper.GetPrimeFactors(-1);
            if (!arePrimeFactorsEqual(expectedPrimeFactors_1, generatedPrimeFactors_1))
                Console.Out.WriteLine("[MathHelperTests/testGetPrimeFactors] Test 2 failed.");

            Dictionary<int, int> expectedPrimeFactors_2 = new Dictionary<int, int>() { { 2, 1 } };
            Dictionary<int, int> generatedPrimeFactors_2 = MathHelper.GetPrimeFactors(2);
            if (!arePrimeFactorsEqual(expectedPrimeFactors_2, generatedPrimeFactors_2))
                Console.Out.WriteLine("[MathHelperTests/testGetPrimeFactors] Test 2 failed.");

            Dictionary<int, int> expectedPrimeFactors_3 = new Dictionary<int, int>() { { 3, 3 } };
            Dictionary<int, int> generatedPrimeFactors_3 = MathHelper.GetPrimeFactors(27);
            if (!arePrimeFactorsEqual(expectedPrimeFactors_3, generatedPrimeFactors_3))
                Console.Out.WriteLine("[MathHelperTests/testGetPrimeFactors] Test 3 failed.");

            Dictionary<int, int> expectedPrimeFactors_4 = new Dictionary<int, int>() { { 2, 1 }, { 3, 1 }, { 13, 1 } };
            Dictionary<int, int> generatedPrimeFactors_4 = MathHelper.GetPrimeFactors(78);
            if (!arePrimeFactorsEqual(expectedPrimeFactors_4, generatedPrimeFactors_4))
                Console.Out.WriteLine("[MathHelperTests/testGetPrimeFactors] Test 4 failed.");
        }
        private static void testGetGCD()
        {
            if (MathHelper.GetGCD(0, 1) != 1)
                Console.Out.WriteLine("[MathHelperTests/testGetGCD] Test 0 failed.");

            if (MathHelper.GetGCD(2, 2) != 2)
                Console.Out.WriteLine("[MathHelperTests/testGetGCD] Test 1 failed.");

            if (MathHelper.GetGCD(12, 36) != 12)
                Console.Out.WriteLine("[MathHelperTests/testGetGCD] Test 2 failed.");

            if (MathHelper.GetGCD(15, 10) != 5)
                Console.Out.WriteLine("[MathHelperTests/testGetGCD] Test 3 failed.");

            if (MathHelper.GetGCD(480, 168) != 24)
                Console.Out.WriteLine("[MathHelperTests/testGetGCD] Test 4 failed.");
        }
        private static void testGetLCM()
        {
            if (MathHelper.GetLCM(0, 1) != 1)
                Console.Out.WriteLine("[MathHelperTests/testGetLCM] Test 0 failed.");

            if (MathHelper.GetLCM(2, 3) != 6)
                Console.Out.WriteLine("[MathHelperTests/testGetLCM] Test 1 failed.");

            if (MathHelper.GetLCM(9, 54) != 54)
                Console.Out.WriteLine("[MathHelperTests/testGetLCM] Test 1 failed.");
        }

        private static bool arePrimeFactorsEqual(Dictionary<int, int> expectedprimefactors, Dictionary<int, int> generatedprimefactors)
        {
            if (generatedprimefactors.Count != expectedprimefactors.Count)
                return false;

            Dictionary<int, int>.Enumerator expectedEnum = expectedprimefactors.GetEnumerator();
            while (expectedEnum.MoveNext())
            {
                if (!generatedprimefactors.ContainsKey(expectedEnum.Current.Key))
                    return false;

                if (generatedprimefactors[expectedEnum.Current.Key] != expectedprimefactors[expectedEnum.Current.Key])
                    return false;
            }

            return true;
        }
    }
}
