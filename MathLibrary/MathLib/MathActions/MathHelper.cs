using System;
using System.Collections.Generic;


namespace MathLib
{
    public static class MathHelper
    {
        /// <summary>
        /// Diese Funktion liefert den größten gemeinsamen Teiler (englisch: greatest common divisor, daher GCD) von zwei Integer-Zahlen zurück.
        /// </summary>
        /// <param name="op1">Operand 1.</param>
        /// <param name="op2">Operand 2.</param>
        /// <returns>Der größte gemeinsame Teiler der beiden Operanden.</returns>
        public static int GetGCD(int op1, int op2)
        {
            // Zunächst werden die Primfaktoren der beiden Operanden bestimmt.
            Dictionary<int, int> op1PrimeFactors = GetPrimeFactors(op1);
            Dictionary<int, int> op2PrimeFactors = GetPrimeFactors(op2);

            // Ein Dictionary für die Primfaktoren des größten gemeinsamen Teilers wird angelegt.
            Dictionary<int, int> gcdPrimeFactors = new Dictionary<int, int>();
            // Hier wird der Enumerator der Primfaktoren von op1 bestimmt. Mit diesem ist es möglich über alle Elemente des Dictionary zu iterieren. Im
            // Vergleich zu Listen ist dies sonst nicht so ohne weiteres möglich. In Listen gibt es Einträge mit Indices, angefangen bei 0 bis hin zu
            // der Länge der Liste - 1. In diesem Dictionary müssen allerdings nicht alle Zahlen von 0 beginnend vorliegen, können sogar gar nicht da 0
            // keine Primzahl ist. Dies macht dann noch mehr Sinn wenn man bedenkt, dass der Key eines Dictionarys keine Zahl sein muss, jeder Datentyp
            // kann Key sein.
            Dictionary<int, int>.Enumerator op1FactorsEnum = op1PrimeFactors.GetEnumerator();
            // Mit MoveNext() wird der Enumerator auf das nächste Element des Dictionary gelegt (im ersten Moment zeigt er auf kein Element, sondern
            // quasi auf ein Element vor dem ersten Element, was natürlich nicht existiert). Die Funktion gibt true zurück, solange das Setzen auf das
            // nächste Element erfolgreich war, also noch Elemente vorhanden waren, ansonsten false. Daher kann man sehr einfach mit einer while-Schleife
            // über ein Dictionary iterieren.
            while (op1FactorsEnum.MoveNext())
                if (op2PrimeFactors.ContainsKey(op1FactorsEnum.Current.Key))
                    // Wenn die Primfaktoren von op1 und op2 beide eine gewisse Primzahl erhalten, dann wird das Minimum der beiden Anzahlen zu den Primfaktoren
                    // des größten gemeinsamen Teilers hinzugefügt.
                    gcdPrimeFactors.Add(op1FactorsEnum.Current.Key, Math.Min(op1FactorsEnum.Current.Value, op2PrimeFactors[op1FactorsEnum.Current.Key]));

            int gcd = 1;
            Dictionary<int, int>.Enumerator gcdFactorsEnum = gcdPrimeFactors.GetEnumerator();
            // Hier wird erneut mit MoveNext() über ein Dictionary iteriert, diesmal allerdings über die Primfaktoren des größten gemeinsamen Teilers.
            while (gcdFactorsEnum.MoveNext())
                // Dann wird der aktuelle Primfaktor so oft auf den größten gemeinsamen Teiler multipliziert wie es im Value des aktuellen Eintrags in den
                // Primfaktoren steht.
                for (int i = 0; i < gcdFactorsEnum.Current.Value; i++)
                    gcd *= gcdFactorsEnum.Current.Key;

            return gcd;
        }
        /// <summary>
        /// Diese Funktion liefert das kleinste gemeinsame Vielfache (englisch: least common multiple, daher LCM) von zwei Integer-Zahlen zurück.
        /// </summary>
        /// <param name="op1">Operand 1.</param>
        /// <param name="op2">Operand 2.</param>
        /// <returns>Das kleinste gemeinsame Vielfache der beiden Operanden.</returns>
        public static int GetLCM(int op1, int op2)
        {
            Dictionary<int, int> op1PrimeFactors = GetPrimeFactors(op1);
            Dictionary<int, int> op2PrimeFactors = GetPrimeFactors(op2);

            Dictionary<int, int> lcmPrimeFactors = new Dictionary<int, int>();

            // Im Unterschied zu GetGCD() weiter oben muss hier über die Prinfaktoren beider Operanden iteriert werden. Im ersten Durchgang werden alle Primfaktoren
            // von op1 zu den Faktoren des kleinsten gemeinsamen Vielfachen hinzugefügt, allerdings wird hierbei, falls der Faktor ebenfalls in den Faktoren von op2
            // enthalten ist, das Maximum der beiden Anzahlen gebildet und hinzugefügt. Falls es in den Faktoren von op2 nicht vorhanden ist wird einfach die Anzahl
            // von op1 hinzugefügt.
            Dictionary<int, int>.Enumerator op1FactorsEnum = op1PrimeFactors.GetEnumerator();
            while (op1FactorsEnum.MoveNext())
            {
                if (op2PrimeFactors.ContainsKey(op1FactorsEnum.Current.Key))
                    lcmPrimeFactors.Add(op1FactorsEnum.Current.Key, Math.Max(op1FactorsEnum.Current.Value, op2PrimeFactors[op1FactorsEnum.Current.Key]));
                else
                    lcmPrimeFactors.Add(op1FactorsEnum.Current.Key, op1FactorsEnum.Current.Value);
            }

            // In der zweiten Schleife werden dann nur noch die Primfaktoren von op2, die nicht in op1 vorkommen (und somit noch nicht zu den Faktoren des kleinsten
            // gemeinsamen Vielfachen hinzugefügt wurden) mit ihrer entsprechenden Anzahl hinzugefügt.
            Dictionary<int, int>.Enumerator op2FactorsEnum = op2PrimeFactors.GetEnumerator();
            while (op2FactorsEnum.MoveNext())
                if (!lcmPrimeFactors.ContainsKey(op2FactorsEnum.Current.Key))
                    lcmPrimeFactors.Add(op2FactorsEnum.Current.Key, op2FactorsEnum.Current.Value);

            int lcm = 1;
            Dictionary<int, int>.Enumerator lcmFactorsEnum = lcmPrimeFactors.GetEnumerator();
            while (lcmFactorsEnum.MoveNext())
                for (int i = 0; i < lcmFactorsEnum.Current.Value; i++)
                    lcm *= lcmFactorsEnum.Current.Key;

            return lcm;
        }
        /// <summary>
        /// Diese Funktion gibt die Primfaktoren einer angegebenen Zahl zurück.
        /// </summary>
        /// <param name="op">Die Zahl, von der die Primfaktoren berechnet werden sollen.</param>
        /// <returns>Die berechneten Primfaktoren.</returns>
        public static Dictionary<int, int> GetPrimeFactors(int op)
        {
            // Ein Dictionary wird angelegt, in dem die Primfaktoren gespeichert werden. Die erste Integer-Zahl (Key des Dictionary) beschreibt
            // hierbei die entsprechende Primzahl, die zweite Integer-Zahl (Value des Dictionary) die Anzahl, mit der diese in der ursprünglichen
            // Zahl als Primfaktor enthalten ist.
            Dictionary<int, int> primeFactors = new Dictionary<int, int>();

            // Wenn op negativ ist bilden wir den Betrag von dieser Zahl.
            if (op < 0)
                op = Math.Abs(op);

            // Wenn op 0 oder 1 ist geben wir ein Dictionary zurück, welches nur die 1 einmal enthält (auch wenn die 1 keine Primzahl ist, so wie
            // wir diese Funktion später verwenden macht die 1 aber nichts kaputt).
            if (op <= 1)
                primeFactors.Add(1, 1);
            // Ansonsten berechnen wir die Primfaktoren.
            else
            {
                // Wir iterieren durch alle Primzahlen, solange wie op größer 1 ist (wo op verändert wird kommt weiter unten).
                for (int primeIndex = 0; op > 1; primeIndex++)
                {
                    // Wir lassen uns die Primzahl am aktuellen Index zurückgeben.
                    int currentPrime = SimplePrimeFinder.GetPrimeWithIndex(primeIndex);
                    // Solange op durch die aktuelle Primzahl teilbar ist...
                    while (op % currentPrime == 0)
                    {
                        // ... wird op durch diese Zahl geteilt ...
                        op /= currentPrime;

                        // ... und fügen sie zu den Primfaktoren hinzu. Entweder die gespeicherten Primfaktoren enthalten bereits einen Eintrag zu
                        // dieser Zahl, dann Inkrementieren wir ihr Value, ansonsten fügen wir einen neuen Eintrag hinzu.
                        if (primeFactors.ContainsKey(currentPrime))
                            primeFactors[currentPrime]++;
                        else
                            primeFactors.Add(currentPrime, 1);
                    }
                }
            }

            return primeFactors;
        }
    }
}
