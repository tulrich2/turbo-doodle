using System;

using MathLib;


namespace Tests
{
    public static class MyMatrixTests
    {
        public static void Test()
        {
            testAddition();
            testSubtraction();
            testMultiplication();
            testTranspose();
            testDeterminant();
        }

        private static void testAddition()
        {
            MyMatrix matrix_00 = new MyMatrix(new MyFraction[,] { { 1 } });
            MyMatrix matrix_01 = new MyMatrix(new MyFraction[,] { { 2 } });
            MyMatrix result_0 = matrix_00 + matrix_01;
            if (result_0 != new MyMatrix(new MyFraction[,] { { 3 } }))
                Console.Out.WriteLine("[MyMatrixTests/testAddition] Test 0 failed.");

            MyMatrix matrix_10 = new MyMatrix(new MyFraction[,] { { 1, 2 }, { 3, 4 } });
            MyMatrix matrix_11 = new MyMatrix(new MyFraction[,] { { 2, 3 }, { 4, 5 } });
            MyMatrix result_1 = matrix_10 + matrix_11;
            if (result_1 != new MyMatrix(new MyFraction[,] { { 3, 5 }, { 7, 9 } }))
                Console.Out.WriteLine("[MyMatrixTests/testAddition] Test 1 failed.");
        }
        private static void testSubtraction()
        {
            MyMatrix matrix_00 = new MyMatrix(new MyFraction[,] { { 1 } });
            MyMatrix matrix_01 = new MyMatrix(new MyFraction[,] { { 2 } });
            MyMatrix result_0 = matrix_00 - matrix_01;
            if (result_0 != new MyMatrix(new MyFraction[,] { { -1 } }))
                Console.Out.WriteLine("[MyMatrixTests/testSubtraction] Test 0 failed.");

            MyMatrix matrix_10 = new MyMatrix(new MyFraction[,] { { 1, 2 }, { 3, 4 } });
            MyMatrix matrix_11 = new MyMatrix(new MyFraction[,] { { 2, 5 }, { 3, 3 } });
            MyMatrix result_1 = matrix_10 - matrix_11;
            if (result_1 != new MyMatrix(new MyFraction[,] { { -1, -3 }, { 0, 1 } }))
                Console.Out.WriteLine("[MyMatrixTests/testSubtraction] Test 1 failed.");
        }
        private static void testMultiplication()
        {
            MyMatrix matrix_00 = new MyMatrix(new MyFraction[,] { { 1 } });
            MyMatrix matrix_01 = new MyMatrix(new MyFraction[,] { { 2 } });
            MyMatrix result_0 = matrix_00 * matrix_01;
            if (result_0 != new MyMatrix(new MyFraction[,] { { 2 } }))
                Console.Out.WriteLine("[MyMatrixTests/testAddition] Test 0 failed.");

            MyMatrix matrix_10 = new MyMatrix(new MyFraction[,] { { 1, 2 }, { 3, 4 } });
            MyMatrix matrix_11 = new MyMatrix(new MyFraction[,] { { 2, 3 }, { 4, 5 } });
            MyMatrix result_1 = matrix_10 * matrix_11;
            if (result_1 != new MyMatrix(new MyFraction[,] { { 10, 13 }, { 22, 29 } }))
                Console.Out.WriteLine("[MyMatrixTests/testAddition] Test 1 failed.");

            MyMatrix matrix_20 = new MyMatrix(new MyFraction[,] { { 1, 2 }, { 3, 4 } });
            MyMatrix matrix_21 = new MyMatrix(new MyFraction[,] { { 2, 3, 5 }, { 4, 5, 4 } });
            MyMatrix result_2 = matrix_20 * matrix_21;
            if (result_2 != new MyMatrix(new MyFraction[,] { { 10, 13, 13 }, { 22, 29, 31 } }))
                Console.Out.WriteLine("[MyMatrixTests/testAddition] Test 2 failed.");
        }
        private static void testTranspose()
        {
            MyMatrix expectedMatrix_0 = new MyMatrix(new MyFraction[,] { { 1 } });
            if ((new MyMatrix(new MyFraction[,] { { 1 } })).Transpose() != expectedMatrix_0)
                Console.Out.WriteLine("[MyMatrixTests/testTranspose] Test 0 failed.");

            MyMatrix expectedMatrix_1 = new MyMatrix(new MyFraction[,] { { 1, 3 }, { 2, 4 } });
            if ((new MyMatrix(new MyFraction[,] { { 1, 2 }, { 3, 4 } })).Transpose() != expectedMatrix_1)
                Console.Out.WriteLine("[MyMatrixTests/testTranspose] Test 1 failed.");

            MyMatrix expectedMatrix_2 = new MyMatrix(new MyFraction[,] { { 1, 4 }, { 2, 5 }, { 3, 6 } });
            if ((new MyMatrix(new MyFraction[,] { { 1, 2, 3 }, { 4, 5, 6 } })).Transpose() != expectedMatrix_2)
                Console.Out.WriteLine("[MyMatrixTests/testTranspose] Test 2 failed.");
        }
        private static void testDeterminant()
        {
            if ((new MyMatrix(new MyFraction[,] { { 1 } })).Determinant() != 1)
                Console.Out.WriteLine("[MyMatrixTests/testDeterminant] Test 0 failed.");

            if ((new MyMatrix(new MyFraction[,] { { 1, 2 }, { 3, 4 } })).Determinant() != -2)
                Console.Out.WriteLine("[MyMatrixTests/testDeterminant] Test 1 failed.");

            if ((new MyMatrix(new MyFraction[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } })).Determinant() != 0)
                Console.Out.WriteLine("[MyMatrixTests/testDeterminant] Test 2 failed.");

            if ((new MyMatrix(new MyFraction[,] { { 1, 1, 2, 3 }, { 2, 3, 1, 2 }, { 1, 1, 3, 1 }, { 3, 1, 1, 1 } })).Determinant() != -38)
                Console.Out.WriteLine("[MyMatrixTests/testDeterminant] Test 3 failed.");

            if ((new MyMatrix(new MyFraction[,] { { 1, 1, 2, 3, 4 }, { 2, 3, 1, 2, 4 }, { 1, 1, 3, 1, 4 }, { 3, 1, 1, 1, 4 }, { 3, 3, 2, 1, 3 } })).Determinant() != 86)
                Console.Out.WriteLine("[MyMatrixTests/testDeterminant] Test 4 failed.");
        }
    }
}
