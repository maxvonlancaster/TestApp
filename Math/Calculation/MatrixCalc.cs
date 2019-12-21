using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Mathematics.Calculation
{
    public class MatrixCalc
    {
        public void MatrixReader()
        {
            string json;
            using (StreamReader r = new StreamReader("../../../models.json"))
            {
                json = r.ReadToEnd();
            }
            double[,] matrix = Newtonsoft.Json.JsonConvert.DeserializeObject<double[,]>(json);
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            Console.WriteLine(DeterminantN(matrix, rows)); // TODO: rang checking logic
            Console.WriteLine(MatrixRangChecker(matrix));
        }

        public int MatrixRangChecker(double[,] m) 
        {
            int rang = 0;
            foreach (var elem in m) 
            {
                if (elem != 0) 
                {
                    rang = 1;
                    break;
                }
            }

            int n = 2;
            int rows = m.GetLength(0);
            int cols = m.GetLength(1);
            while (n <= Math.Max(rows, cols)) 
            {
                int[] rowInd = new int[n];
                int[] colInd = new int[n];
            }
            return rang;
        }

        public double DeterminantTwo(double[,] m) 
        {
            return m[0, 0] * m[1, 1] - m[0, 1] * m[1, 0];
        }

        public double DeterminantN(double[,] m, int n)
        {
            if (n == 2)
            {
                return DeterminantTwo(m);
            }
            else
            {
                int length = m.GetLength(0);
                double res = 0.0;
                for (var i = 0; i < length; i++)
                {
                    res += Math.Pow(-1, i) * m[0, i] * DeterminantN( GetSlice(m, i), n-1); 
                }
                return res;
            }
        }

        // Gets T-slice of matrix 
        public double[,] GetSlice(double[,] m, int row) 
        {
            int dim = m.GetLength(0) - 1;
            double[,] res = new double[dim,dim];
            for (int i = 0; i < dim; i++) 
            {
                for (int j = 0; j < row; j++) 
                {
                    res[i, j] = m[i + 1, j];
                }
                for (int j = row ; j < dim; j++) 
                {
                    res[i, j] = m[i + 1, j + 1];
                }
            }
            return res;
        }

        // Gets slice with indexes from int[,] -> m*2 array, returns matrix m*m
        public double[,] GetMatrixSlice(double[,] m, int[,] indexes) 
        {
            int dim = indexes.GetLength(1);
            double[,] res = new double[dim, dim];
            for (int i = 0; i < dim; i++) 
            {
                for (int j = 0; j < dim; j++) 
                {
                    res[i, j] = m[indexes[0,i], indexes[1,j]];
                }
            }
            return res;
        }
    }
}
