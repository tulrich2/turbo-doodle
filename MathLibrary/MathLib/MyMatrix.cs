using System;


namespace MathLib
{
    public class MyMatrix
    {
        public MyFraction this[int lineindex, int columnindex] { get { return values[lineindex, columnindex]; } }
        public int Lines { get { return values.GetLength(0); } }
        public int Columns { get { return values.GetLength(1); } }

        private MyFraction[,] values;

        public MyMatrix(MyFraction[,] newvalues)
        {
            if (newvalues.GetLength(0) == 0 || newvalues.GetLength(1) == 0)
                throw new ArithmeticException("Es kann keine leere Matrix erzeugt werden.");

            values = newvalues;
        }
        private MyMatrix()
        {
            values = new MyFraction[0, 0];
        }

        public MyMatrix Transpose()
        {
            MyFraction[,] newvalues = new MyFraction[Columns, Lines];

            for (int lineIndex = 0; lineIndex < Lines; lineIndex++)
                for (int columnIndex = 0; columnIndex < Columns; columnIndex++)
                    newvalues[columnIndex, lineIndex] = values[lineIndex, columnIndex];

            return new MyMatrix(newvalues);
        }
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

        private static MyFraction determinantRec(MyMatrix matrix)
        {
            if (matrix.Lines == 1)
                return matrix.values[0, 0];
            else if (matrix.Lines == 2)
                return (matrix.values[0, 0] * matrix.values[1, 1]) - (matrix.values[0, 1] * matrix.values[1, 0]);
            else if (matrix.Lines == 3)
                return (matrix.values[0, 0] * matrix.values[1, 1] * matrix.values[2, 2]) + (matrix.values[0, 1] * matrix.values[1, 2] * matrix.values[2, 0]) + (matrix.values[0, 2] * matrix.values[1, 0] * matrix.values[2, 1])
                     - (matrix.values[0, 2] * matrix.values[1, 1] * matrix.values[2, 0]) - (matrix.values[0, 1] * matrix.values[1, 0] * matrix.values[2, 2]) - (matrix.values[0, 0] * matrix.values[1, 2] * matrix.values[2, 1]);
            else
            {
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
