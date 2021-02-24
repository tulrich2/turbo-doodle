using System;


namespace MathLib
{
    /// <summary>
    /// Eine Klasse zur Darstellung von Spaltenvektoren.
    /// </summary>
    public class MyVector
    {
        /// <summary>
        /// Indexer zum Abrufen einzelner Elemente des Vektors.
        /// </summary>
        /// <param name="elementindex">Der Index des gewünschten Elements.</param>
        /// <returns>Das gewünschte Element.</returns>
        public MyFraction this[int elementindex] { get { return values[elementindex]; } }
        /// <summary>
        /// Gibt die Anzahl Elemente in diesem Vektor an.
        /// </summary>
        public int ElementCount { get { return values.Length; } }

        /// <summary>
        /// Privates Array zum Speichern der einzelnen Elemente des Vektors.
        /// </summary>
        private MyFraction[] values;

        /// <summary>
        /// Erstellt eine neue Vektor-Instanz mit den angegebenen Elementen.
        /// </summary>
        /// <param name="newvalues">Die Elemente der neuen Vektor-Instanz.</param>
        public MyVector(MyFraction[] newvalues)
        {
            if (newvalues.Length == 0)
                throw new ArithmeticException("Es kann kein leerer Vektor erzeugt werden.");

            values = newvalues;
        }
        /// <summary>
        /// Damit kein leerer Vektor erzeugt werden kann wird der paramterlose Konstruktor private gemacht.
        /// </summary>
        private MyVector()
        {
            values = new MyFraction[0];
        }

        public static bool operator ==(MyVector op1, MyVector op2)
        {
            if (op1.values.Length != op2.values.Length)
                return false;

            for (int i = 0; i < op1.values.Length; i++)
                if (op1.values[i] != op2.values[i])
                    return false;

            return true;
        }
        public static bool operator !=(MyVector op1, MyVector op2)
        {
            if (op1.values.Length != op2.values.Length)
                return true;

            for (int i = 0; i < op1.values.Length; i++)
                if (op1.values[i] != op2.values[i])
                    return true;

            return false;
        }

        public static MyVector operator -(MyVector op)
        {
            MyFraction[] newvalues = new MyFraction[op.ElementCount];

            for (int i = 0; i < op.ElementCount; i++)
                newvalues[i] = -op.values[i];

            return new MyVector(newvalues);
        }
        public static MyVector operator +(MyVector op1, MyVector op2)
        {
            if (op1.ElementCount != op2.ElementCount)
                throw new ArithmeticException("Die Anzahl Elemente beider Vektoren muss gleich sein.");

            MyFraction[] newvalues = new MyFraction[op1.ElementCount];

            for (int i = 0; i < op1.ElementCount; i++)
                newvalues[i] = op1[i] + op2[i];

            return new MyVector(newvalues);
        }
        public static MyVector operator -(MyVector op1, MyVector op2)
        {
            if (op1.ElementCount != op2.ElementCount)
                throw new ArithmeticException("Die Anzahl Elemente beider Vektoren muss gleich sein.");

            MyFraction[] newvalues = new MyFraction[op1.ElementCount];

            for (int i = 0; i < op1.ElementCount; i++)
                newvalues[i] = op1[i] - op2[i];

            return new MyVector(newvalues);
        }
        public static MyFraction operator *(MyVector op1, MyVector op2)
        {
            if (op1.ElementCount != op2.ElementCount)
                throw new ArithmeticException("Die Anzahl Elemente beider Vektoren muss gleich sein.");

            MyFraction scalar = 0;

            for (int i = 0; i < op1.ElementCount; i++)
                scalar += op1[i] * op2[i];

            return scalar;
        }
        public static MyVector operator *(MyFraction op1, MyVector op2)
        {
            MyFraction[] newvalues = new MyFraction[op2.ElementCount];

            for (int i = 0; i < op2.ElementCount; i++)
                newvalues[i] = op1 * op2[i];

            return new MyVector(newvalues);
        }
        public static MyVector operator *(MyVector op1, MyFraction op2)
        {
            return op2 * op1;
        }
    }
}
