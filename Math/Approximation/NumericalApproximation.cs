using System;
using System.Collections.Generic;
using System.Text;

namespace Mathematics.Approximation
{
    public class NumericalApproximation
    {
        public void BabylonianApproximation() 
        {
            double a = 1.0;
            for (int i = 2; i < 40; i++) 
            {
                a = 0.5 * (a + 2/a);
                Console.WriteLine("Step: {0}, value: {1}", i, a);
            }
        }
    }
}
