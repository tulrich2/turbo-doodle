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
    }
}
