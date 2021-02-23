using System;

using MathLib;


namespace Tests
{
    public static class SolverTests
    {
        public static void Test()
        {
            testGauss();
        }

        private static void testGauss()
        {
            MyMatrix matrix_0 = new MyMatrix(new MyFraction[,] { { new MyFraction(2, 3) } });
            MyVector vector_0 = new MyVector(new MyFraction[] { new MyFraction(3, 4) });
            if (Solver.Gauss(matrix_0, vector_0) != new MyVector(new MyFraction[] { new MyFraction(9, 8) }))
                Console.Out.WriteLine("[SolverTests/testGauss] Test 0 failed.");

            MyMatrix matrix_1 = new MyMatrix(new MyFraction[,] { { 1, 2 }, { 2, 5 } });
            MyVector vector_1 = new MyVector(new MyFraction[] { 3, 1 });
            if (Solver.Gauss(matrix_1, vector_1) != new MyVector(new MyFraction[] { 13, -5 }))
                Console.Out.WriteLine("[SolverTests/testGauss] Test 1 failed.");

            MyMatrix matrix_2 = new MyMatrix(new MyFraction[,] { { 2, 1, 4 }, { 4, 8, 2 }, { 5, 5, 2 } });
            MyVector vector_2 = new MyVector(new MyFraction[] { 7, 1, 3 });
            if (Solver.Gauss(matrix_2, vector_2) != new MyVector(new MyFraction[] { new MyFraction(5, 11), new MyFraction(-17, 33), new MyFraction(109, 66) }))
                Console.Out.WriteLine("[SolverTests/testGauss] Test 2 failed.");

            MyMatrix matrix_3 = new MyMatrix(new MyFraction[,] { { 5, 5, 6, 7 }, { 4, 3, 6, 2 }, { 8, 4, 5, 4 }, { 3, 4, 3, 2 } });
            MyVector vector_3 = new MyVector(new MyFraction[] { 2, 1, 4, 1 });
            if (Solver.Gauss(matrix_3, vector_3) != new MyVector(new MyFraction[] { new MyFraction(165, 251), new MyFraction(-27, 251), new MyFraction(-64, 251), new MyFraction(28, 251) }))
                Console.Out.WriteLine("[SolverTests/testGauss] Test 3 failed.");
        }
    }
}
