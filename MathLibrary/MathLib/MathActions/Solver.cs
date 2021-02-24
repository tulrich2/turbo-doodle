using System;


namespace MathLib
{
    public static class Solver
    {
        public static MyVector Gauss(MyMatrix matrix, MyVector vector)
        {
            if (matrix.Lines != matrix.Columns)
                throw new ArithmeticException("Die Matrix muss quadratisch sein.");

            if (matrix.Determinant() == 0)
                throw new ArithmeticException("Das Gleichungssystem kann nicht gelöst werden da die Determinante 0 ist.");

            if (matrix.Columns != vector.ElementCount)
                throw new ArithmeticException("Der Vektor muss so viele Elemente haben wie die Matrix Spalten hat.");

            MyFraction[,] internalMatrixValues = new MyFraction[matrix.Lines, matrix.Columns];
            for (int lineIndex = 0; lineIndex < matrix.Lines; lineIndex++)
                for (int columnIndex = 0; columnIndex < matrix.Columns; columnIndex++)
                    internalMatrixValues[lineIndex, columnIndex] = matrix[lineIndex, columnIndex];

            MyFraction[] internalVectorValues = new MyFraction[vector.ElementCount];
            for (int i = 0; i < vector.ElementCount; i++)
                internalVectorValues[i] = vector[i];

            for (int step = 0; step < matrix.Columns - 1; step++)
            {
                MyFraction upperValue = internalMatrixValues[step, step];
                for (int lineIndex = step + 1; lineIndex < matrix.Lines; lineIndex++)
                {
                    MyFraction lowerValue = internalMatrixValues[lineIndex, step];
                    for (int columnIndex = step; columnIndex < matrix.Columns; columnIndex++)
                        internalMatrixValues[lineIndex, columnIndex] = (upperValue * internalMatrixValues[lineIndex, columnIndex]) - (lowerValue * internalMatrixValues[step, columnIndex]);
                    internalVectorValues[lineIndex] = (upperValue * internalVectorValues[lineIndex]) - (lowerValue * internalVectorValues[step]);
                }
            }

            MyFraction[] newvalues = new MyFraction[matrix.Lines];

            for (int lineIndex = matrix.Lines - 1; lineIndex >= 0; lineIndex--)
            {
                newvalues[lineIndex] = internalVectorValues[lineIndex];
                for (int columnIndex = matrix.Columns - 1; columnIndex > lineIndex; columnIndex--)
                    newvalues[lineIndex] -= internalMatrixValues[lineIndex, columnIndex] * newvalues[columnIndex];
                newvalues[lineIndex] /= internalMatrixValues[lineIndex, lineIndex];
            }

            return new MyVector(newvalues);
        }
    }
}
