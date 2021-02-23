using System;


namespace MathLib
{
    /// <summary>
    /// Eine Klasse zur Darstellung von Matrizen.
    /// </summary>
    public class MyMatrix
    {
        /// <summary>
        /// Indexer zum Abrufen einzelner Elemente einer Matrix.
        /// </summary>
        /// <param name="lineindex">Der Index der Zeile, in der sich das gewünschte Element befindet.</param>
        /// <param name="columnindex">Der Index der Spalte, in der sich das gewünschte Element befindet.</param>
        /// <returns>Das gwünschte Element.</returns>
        public MyFraction this[int lineindex, int columnindex] { get { return values[lineindex, columnindex]; } }
        /// <summary>
        /// Gibt die Anzahl Zeilen dieser Matrix an.
        /// </summary>
        public int Lines { get { return values.GetLength(0); } }
        /// <summary>
        /// Gibt die Anzahl Spalten dieser Matrix an.
        /// </summary>
        public int Columns { get { return values.GetLength(1); } }

        /// <summary>
        /// Privates Array zum speichern der einzelnen Elemente der Matrix.
        /// </summary>
        private MyFraction[,] values;

        /// <summary>
        /// Erstellt eine neue Matrix-Instanz mit den angegebenen Elementen.
        /// </summary>
        /// <param name="newvalues">Die Elemente der neuen Instanz.</param>
        public MyMatrix(MyFraction[,] newvalues)
        {
            if (newvalues.GetLength(0) == 0 || newvalues.GetLength(1) == 0)
                throw new ArithmeticException("Es kann keine leere Matrix erzeugt werden.");

            values = newvalues;
        }
        /// <summary>
        /// Damit keine leeren Instanzen erstellt werden können, also Matrizen ohne Elemente, wurde der Parameterlose Konstruktor privat gemacht. Er wird nicht verwendet.
        /// </summary>
        private MyMatrix()
        {
            values = new MyFraction[0, 0];
        }

        public override string ToString()
        {
            string matrixString = "";

            int[] columnWidths = new int[Columns];
            for (int columnIndex = 0; columnIndex < Columns; columnIndex++)
            {
                columnWidths[columnIndex] = 0;
                for (int lineIndex = 0; lineIndex < Lines; lineIndex++)
                {
                    int currentElementWidth = values[lineIndex, columnIndex].ToString().Length;
                    if (currentElementWidth > columnWidths[columnIndex])
                        columnWidths[columnIndex] = currentElementWidth;
                }
            }

            if (Lines == 1)
            {
                matrixString = "[ ";
                for (int columnIndex = 0; columnIndex < Columns; columnIndex++)
                {
                    matrixString += values[0, columnIndex].ToString();
                    if (columnIndex < Columns - 1)
                        matrixString += "  ";
                }
                matrixString += " ]";
            }
            else
            {
                matrixString += "┌ ";
                for (int columnIndex = 0; columnIndex < Columns; columnIndex++)
                {
                    string currentElementString = values[0, columnIndex].ToString();
                    matrixString += new string(' ', columnWidths[columnIndex] - currentElementString.Length) + currentElementString;
                    if (columnIndex < Columns - 1)
                        matrixString += "  ";
                }
                matrixString += " ┐\n";

                for (int lineIndex = 1; lineIndex < Lines - 1; lineIndex++)
                {
                    matrixString += "│ ";
                    for (int columnIndex = 0; columnIndex < Columns; columnIndex++)
                    {
                        string currentElementString = values[lineIndex, columnIndex].ToString();
                        matrixString += new string(' ', columnWidths[columnIndex] - currentElementString.Length) + currentElementString;
                        if (columnIndex < Columns - 1)
                            matrixString += "  ";
                    }
                    matrixString += " │\n";
                }

                matrixString += "└ ";
                for (int columnIndex = 0; columnIndex < Columns; columnIndex++)
                {
                    string currentElementString = values[Lines - 1, columnIndex].ToString();
                    matrixString += new string(' ', columnWidths[columnIndex] - currentElementString.Length) + currentElementString;
                    if (columnIndex < Columns - 1)
                        matrixString += "  ";
                }
                matrixString += " ┘";
            }

            return matrixString;
        }

        /// <summary>
        /// Gibt die Transponierte Matrix zu dieser Instanz zurück.
        /// </summary>
        /// <returns>Die Transponierte Matrix.</returns>
        public MyMatrix Transpose()
        {
            MyFraction[,] newvalues = new MyFraction[Columns, Lines];

            for (int lineIndex = 0; lineIndex < Lines; lineIndex++)
                for (int columnIndex = 0; columnIndex < Columns; columnIndex++)
                    // Die Matrix ist deswegen am Ende transponiert, da in dieser Zuweisung die Indizes für Zeile und Spalte genau vertauscht sind.
                    newvalues[columnIndex, lineIndex] = values[lineIndex, columnIndex];

            return new MyMatrix(newvalues);
        }
        /// <summary>
        /// Gibt die Determinante dieser Instanz zurück.
        /// </summary>
        /// <returns>Die Determinante.</returns>
        public MyFraction Determinant()
        {
            if (Lines != Columns)
                throw new ArithmeticException("Es kann nur von quadratischen Matrizen die Determinante gebildet werden.");

            return determinantRec(this);
        }

        public static bool operator ==(MyMatrix op1, MyMatrix op2)
        {
            if (op1.Lines != op2.Lines || op1.Columns != op2.Columns)
                return false;

            for (int lineIndex = 0; lineIndex < op1.Lines; lineIndex++)
                for (int columnIndex = 0; columnIndex < op1.Columns; columnIndex++)
                    if (op1[lineIndex, columnIndex] != op2[lineIndex, columnIndex])
                        return false;

            return true;
        }
        public static bool operator !=(MyMatrix op1, MyMatrix op2)
        {
            if (op1.Lines != op2.Lines || op1.Columns != op2.Columns)
                return true;

            for (int lineIndex = 0; lineIndex < op1.Lines; lineIndex++)
                for (int columnIndex = 0; columnIndex < op1.Columns; columnIndex++)
                    if (op1[lineIndex, columnIndex] != op2[lineIndex, columnIndex])
                        return true;

            return false;
        }

        // Die Arithmetischen Operatoren folgen den Rechenregeln für Matrizen, es wird zu Beginn jedoch jeweils auf die korrekten Dimensionen der Operanden überprüft.
        public static MyMatrix operator -(MyMatrix op)
        {
            MyFraction[,] newvalues = new MyFraction[op.Lines, op.Columns];

            for (int lineIndex = 0; lineIndex < op.Lines; lineIndex++)
                for (int columnIndex = 0; columnIndex < op.Columns; columnIndex++)
                    newvalues[lineIndex, columnIndex] = -op[lineIndex, columnIndex];

            return new MyMatrix(newvalues);
        }
        public static MyMatrix operator +(MyMatrix op1, MyMatrix op2)
        {
            if (op1.Lines != op2.Lines || op1.Columns != op2.Columns)
                throw new ArithmeticException("Die Dimensionen der beiden Matrizen müssen gleich sein.");

            MyFraction[,] newvalues = new MyFraction[op1.Lines, op1.Columns];

            for (int lineIndex = 0; lineIndex < op1.Lines; lineIndex++)
                for (int columnIndex = 0; columnIndex < op1.Columns; columnIndex++)
                    newvalues[lineIndex, columnIndex] = op1[lineIndex, columnIndex] + op2[lineIndex, columnIndex];

            return new MyMatrix(newvalues);
        }
        public static MyMatrix operator -(MyMatrix op1, MyMatrix op2)
        {
            if (op1.Lines != op2.Lines || op1.Columns != op2.Columns)
                throw new ArithmeticException("Die Dimensionen der beiden Matrizen müssen gleich sein.");

            MyFraction[,] newvalues = new MyFraction[op1.Lines, op1.Columns];

            for (int lineIndex = 0; lineIndex < op1.Lines; lineIndex++)
                for (int columnIndex = 0; columnIndex < op1.Columns; columnIndex++)
                    newvalues[lineIndex, columnIndex] = op1[lineIndex, columnIndex] - op2[lineIndex, columnIndex];

            return new MyMatrix(newvalues);
        }
        public static MyMatrix operator *(MyMatrix op1, MyMatrix op2)
        {
            if (op1.Columns != op2.Lines)
                throw new ArithmeticException("Für die Matrixmultiplikation muss die rechte Matrix so viele Zeilen haben wie die linke Spalten hat.");

            MyFraction[,] newvalues = new MyFraction[op1.Lines, op2.Columns];

            for (int lineIndex = 0; lineIndex < op1.Lines; lineIndex++)
                for (int columnIndex = 0; columnIndex < op2.Columns; columnIndex++)
                {
                    newvalues[lineIndex, columnIndex] = 0;
                    for (int i = 0; i < op1.Columns; i++)
                        newvalues[lineIndex, columnIndex] += op1[lineIndex, i] * op2[i, columnIndex];
                }

            return new MyMatrix(newvalues);
        }
        public static MyMatrix operator *(MyFraction op1, MyMatrix op2)
        {
            MyFraction[,] newvalues = new MyFraction[op2.Lines, op2.Columns];

            for (int lineIndex = 0; lineIndex < op2.Lines; lineIndex++)
                for (int columnIndex = 0; columnIndex < op2.Columns; columnIndex++)
                    newvalues[lineIndex, columnIndex] = op1 * op2[lineIndex, columnIndex];

            return new MyMatrix(newvalues);
        }
        public static MyMatrix operator *(MyMatrix op1, MyFraction op2)
        {
            return op2 * op1;
        }
        public static MyVector operator *(MyMatrix op1, MyVector op2)
        {
            if (op1.Columns != op2.ElementCount)
                throw new ArithmeticException("Der Vektor muss so viele Zeilen haben wie die Matrix Spalten hat.");

            MyFraction[] newvalues = new MyFraction[op1.Lines];

            for (int lineIndex = 0; lineIndex < op1.Lines; lineIndex++)
            {
                newvalues[lineIndex] = 0;
                for (int columnIndex = 0; columnIndex < op1.Columns; columnIndex++)
                    newvalues[lineIndex] += op1[lineIndex, columnIndex] * op2[columnIndex];
            }

            return new MyVector(newvalues);
        }

        /// <summary>
        /// Private, statische und rekursive Funktion zur Berechnung der Determinante einer Matrix.
        /// </summary>
        /// <param name="matrix">Die Matrix von der die Determinante berechnet werden soll.</param>
        /// <returns>Die Determinante.</returns>
        private static MyFraction determinantRec(MyMatrix matrix)
        {
            // Bis zur Größe 3 können wir direkt das Ergebnis für die Determinante berechnen, ohne diese Funktion rekursiv aufrufen zu müssen.
            if (matrix.Lines == 1)
                return matrix.values[0, 0];
            else if (matrix.Lines == 2)
                return (matrix.values[0, 0] * matrix.values[1, 1]) - (matrix.values[0, 1] * matrix.values[1, 0]);
            else if (matrix.Lines == 3)
                return (matrix.values[0, 0] * matrix.values[1, 1] * matrix.values[2, 2]) + (matrix.values[0, 1] * matrix.values[1, 2] * matrix.values[2, 0]) + (matrix.values[0, 2] * matrix.values[1, 0] * matrix.values[2, 1])
                     - (matrix.values[0, 2] * matrix.values[1, 1] * matrix.values[2, 0]) - (matrix.values[0, 1] * matrix.values[1, 0] * matrix.values[2, 2]) - (matrix.values[0, 0] * matrix.values[1, 2] * matrix.values[2, 1]);
            else
            {
                // In diesem Teil wird einfach der Laplace Algorithmus zur Berechnung der Determinante angewandt.

                MyFraction returnvalue = 0;
                MyFraction factor = 1;
                for (int i = 0; i < matrix.Lines; i++)
                {
                    MyFraction[,] tmpValues = new MyFraction[matrix.Lines - 1, matrix.Lines - 1];
                    int tmpColumnIndex = 0;
                    for (int columnIndex = 0; columnIndex < matrix.Columns; columnIndex++)
                    {
                        if (columnIndex == i)
                            continue;

                        for (int lineIndex = 1; lineIndex < matrix.Lines; lineIndex++)
                            tmpValues[lineIndex - 1, tmpColumnIndex] = matrix.values[lineIndex, columnIndex];

                        tmpColumnIndex++;
                    }

                    returnvalue += factor * matrix.values[0, i] * determinantRec(new MyMatrix(tmpValues));

                    factor = -factor;
                }

                return returnvalue;
            }
        }
    }
}
