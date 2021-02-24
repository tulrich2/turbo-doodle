using System.Collections.Generic;


namespace MathLib
{
    /// <summary>
    /// Diese statische Klasse findet mit einem einfachen Algorithmus Primzahlen.
    /// </summary>
    public static class SimplePrimeFinder
    {
        /// <summary>
        /// Eine Liste die alle bisher berechneten Primzahlen enthält.
        /// </summary>
        private static List<int> primes = new List<int>(0);

        /// <summary>
        /// Diese Funktion liefert alle Primzahlen bis zu einer angegebenen Grenze als Array zurück.
        /// </summary>
        /// <param name="until">Die Grenze bis zu welcher die Primzahlen berechnet und zurückgegeben werden sollen.</param>
        /// <returns>Ein Array mit allen Primzahlen bis zur angegebenen Grenze.</returns>
        public static int[] GetPrimesUntil(int until)
        {
            // Anlegen einer Liste, in der die Primzahlen gespeichert werden die zurückgegeben werden sollen.
            List<int> returnPrimes = new List<int>(0);

            // Wenn noch keine Primzahl hinzugefügt wurde, fügen wir eine manuell hinzu.
            if (primes.Count == 0)
                findNextPrime();

            // Mit dieser Schleife werden die benötigten Primzahlen berechnet (falls nötig).
            while (primes[primes.Count - 1] < until)
                findNextPrime();

            // Jetzt müssen nur noch die benötigten Primzahlen in die Rückgabeliste geschrieben werden
            for (int i = 0; i < primes.Count && primes[i] <= until; i++)
                returnPrimes.Add(primes[i]);

            // Rückgabe der Liste mit den gefundenen Primzahlen, allerdings wird diese zuvor in ein Array umgewandelt.
            return returnPrimes.ToArray();
        }
        /// <summary>
        /// Diese Funktion liefert eine Primzahl mit dem angegebenen Index zurück.
        /// </summary>
        /// <param name="index">Der Index der Primzahl die gewollt ist.</param>
        /// <returns>Die Primzahl mit Index "index".</returns>
        public static int GetPrimeWithIndex(int index)
        {
            // Berechne alle Primzahlen bis zum angegebenen Index (falls nötig).
            while (primes.Count < index + 1)
                findNextPrime();

            // Gib die gewollte Primzahl zurück.
            return primes[index];
        }

        /// <summary>
        /// Diese private Funktion findet die nächste Primzahl die auf die zuletzt generierte folgt.
        /// </summary>
        private static void findNextPrime()
        {
            if (primes.Count == 0) // Wenn bisher noch keine Primzahlen berechnet wurden:
                primes.Add(2);
            else if (primes.Count == 1) // Wenn bisher nur die 2 hinzugefügt wurde:
                primes.Add(3);
            else // Ansonsten:
            {
                // Die nächste mögliche Primzahl ist um 2 größer als die zuletzt hinzugefügte (gerade Zahlen sind niemals Primzahlen, deswegen +2 und nicht +1)
                int possiblePrime = primes[primes.Count - 1] + 2;
                while (true)
                {
                    // Überprüfe ob die mögliche Primzahl durch irgendeine der bisher berechneten Primzahlen ohne Rest teilbar ist:
                    for (int primeIndex = 0; primeIndex < primes.Count; primeIndex++)
                    {
                        if ((possiblePrime % primes[primeIndex]) == 0)
                            // Wenn sie ohne Rest teilbar ist, verlasse die for-Schleife
                            break;
                        else if (primeIndex == primes.Count - 1)
                        {
                            // Diese Abfrage ist nur true, wenn primeIndex == Index des letzten Elements in primes ist und die mögliche Primzahl nicht durch die
                            // letzte berechnete Primzahl teilbar ist (nur wenn das "if" oben false ist, wird dieses "else if" überhaupt überprüft).
                            // Wenn dies der Fall ist, dann ist die mögliche Primzahl tatsächlich eine Primzahl und kann zu primes hinzugefügt werden
                            primes.Add(possiblePrime);

                            // Jetzt können wir die Funktion verlassen, wir haben die nächste Primzahl gefunden.
                            return;
                        }
                    }

                    // Da wir hier nur hinkommen wenn die aktuelle mögliche Primzahl keine Primzahl war, erhöhen wir diese um 2 vor dem nächsten Schleifendurchlauf.
                    possiblePrime += 2;
                }
            }
        }
    }
}
