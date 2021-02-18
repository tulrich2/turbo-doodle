using System;
using MathLib;


namespace Tests
{
    /// <summary>
    /// Statische Klasse zum Testen des SimplePrimeFinder.
    /// </summary>
    public static class SimplePrimeFinderTests
    {
        /// <summary>
        /// Führe die Tests aus.
        /// </summary>
        public static void Test()
        {
            int[] expectedPrimes_0 = new int[] { 2 };
            int[] generatedPrimes_0 = SimplePrimeFinder.GetPrimesUntil(2);
            if (!arePrimeArraysEqual(expectedPrimes_0, generatedPrimes_0))
                Console.Out.WriteLine("[SimplePrimeFinderTests] Test 0 failed.");

            int[] expectedPrimes_1 = new int[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31 };
            int[] generatedPrimes_1 = SimplePrimeFinder.GetPrimesUntil(35);
            if (!arePrimeArraysEqual(expectedPrimes_1, generatedPrimes_1))
                Console.Out.WriteLine("[SimplePrimeFinderTests] Test 1 failed.");

            int[] expectedPrimes_2 = new int[] { 2, 3, 5, 7 };
            int[] generatedPrimes_2 = SimplePrimeFinder.GetPrimesUntil(7);
            if (!arePrimeArraysEqual(expectedPrimes_2, generatedPrimes_2))
                Console.Out.WriteLine("[SimplePrimeFinderTests] Test 2 failed.");

            int[] expectedPrimes_3 = new int[] { 2, 3, 5, 7, 11, 13, 17, 19 };
            for (int i = 0; i < expectedPrimes_3.Length; i++)
                if (SimplePrimeFinder.GetPrimeWithIndex(i) != expectedPrimes_3[i])
                {
                    Console.Out.WriteLine("[SimplePrimeFinderTests] Test 3 failed.");
                    break;
                }
        }

        /// <summary>
        /// Private Funktion um festzustellen, ob die berechneten Primzahlen gleich den erwarteten sind.
        /// </summary>
        /// <param name="expectedprimes">Die erwarteten Primzahlen.</param>
        /// <param name="generatedprimes">Die berechneten Primzahlen.</param>
        /// <returns>True wenn beide Arrays gleich sind, sonst false.</returns>
        private static bool arePrimeArraysEqual(int[] expectedprimes, int[] generatedprimes)
        {
            // Wenn die Arrays unterschiedlich lang sind können wir direk false zurückgeben.
            if (generatedprimes.Length != expectedprimes.Length)
                return false;

            for (int i = 0; i < generatedprimes.Length; i++)
                // Wenn ein Element in den berechneten Primzahlen ungleich dem entsprechenden Element in den erwarteten Primzahlen ist geben wir false zurück.
                if (generatedprimes[i] != expectedprimes[i])
                    return false;

            // Wir geben nur true zurück wenn wirklich alle Elemente gleich gewesen sind.
            return true;
        }
    }
}
