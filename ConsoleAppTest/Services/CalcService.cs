using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppTest.Services
{
    public class CalcService
    {
        public void AccelerationCalculationMethod()
        {
            Console.WriteLine("Input origin. amount, origin. velocity, acceleration, steps");
            string inputStartAmountString = Console.ReadLine();
            string inputStartIncrString = Console.ReadLine();
            string inputAccelerationString = Console.ReadLine();
            string stepsString = Console.ReadLine();

            float amount;
            float velocity;
            float acceleration;
            float steps;

            float.TryParse(inputStartAmountString, out amount);
            float.TryParse(inputStartIncrString, out velocity);
            float.TryParse(inputAccelerationString, out acceleration);
            float.TryParse(stepsString, out steps);

            for (int i = 0; i < steps; i++)
            {
                velocity *= acceleration;
                amount *= velocity;
                Console.WriteLine("Step: {0}; Amount: {1}", i, amount);

            }

            Console.WriteLine("Amount: {0}", amount);

            // 20   1,04   0,999   100
        }

        public void CalcEulerNumber()
        {

        }

        public void CalcPiNumber()
        {
            int n = 25;
            double t = 0;
            decimal pi = 0;
            double deno = 0;
            double piopp = 0;

            for (int k = 0; k < n; k++)
            {
                t = (double)((-1) ^ k) * (Factorial(6*k)) * (double)(13591409 + 545140134 * k);
                deno = Factorial(3 * k) * (Math.Pow( Factorial(k), 3)) * (double)(640320 ^ (3 * k));
                piopp += t / deno;
            }
            piopp = piopp * 12 / Math.Pow(640320,1.5);
            pi = (decimal)(1 / piopp);
            Console.WriteLine(pi);
        }

        public static double Factorial(int v)
        {
            double fact = 1;
            for (int i = 1; i < v + 1; i++)
            {
                fact = fact * (double)i;
            }
            return fact;
        }

        public void CalcAffineApproximation()
        {

        }
    }
}
