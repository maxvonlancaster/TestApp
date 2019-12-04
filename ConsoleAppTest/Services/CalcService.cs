using System;
using System.Collections.Generic;
using System.Diagnostics;
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
                t = (double)((-1) ^ k) * (Factorial(6 * k)) * (double)(13591409 + 545140134 * k);
                deno = Factorial(3 * k) * (Math.Pow(Factorial(k), 3)) * (double)(640320 ^ (3 * k));
                piopp += t / deno;
            }
            piopp = piopp * 12 / Math.Pow(640320, 1.5);
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

        double a = 1;
        double b = -1;
        public class Points
        {
            public double A;
            public double B;
            public double D;
        }

        public void CalcAffineApproximation()
        {
            a = 0.005;
            Points p = new Points() { A = a, B = b, D = 100 };
            // approximated funtion:
            Func<double, double> f = (x) => { return x * x * x; };

            // approximating function:
            Func<double, double> g = (x) => { return a * x + b; };

            // uniform distance:
            Func<double, double> d = (x) => { return Math.Abs(g(x) - f(x)); };

            double step = 0.001;

            while (a < 2)
            {
                while (b < 1)
                {
                    double distance = d(-1);
                    for (double t = -1 + step; t < 1; t = t + step)
                    {
                        if (d(t) > distance)
                        {
                            distance = d(t);
                        }
                    }
                    if (distance < p.D)
                    {
                        p.D = distance;
                        p.A = a;
                        p.B = b;
                    }
                    b += step;
                }
                a += step;
                b = -1;
            }

            Console.WriteLine("A = {0}, B = {1}, D = {2}", p.A, p.B, p.D);
            // TODO: Graphic representation!, Optimize!
        }

        public void CalcLinearApproximation()
        {
            a = 0.0001;
            b = 0;
            Points p = new Points() { A = a, B = 0, D = 100 };
            // approximated funtion:
            Func<double, double> f = (x) => { return x * x * x; };

            // approximating function:
            Func<double, double> g = (x) => { return a * x + b; };

            // uniform distance:
            Func<double, double> d = (x) => { return Math.Abs(g(x) - f(x)); };

            double step = 0.0001;

            while (a < 2)
            {
                double distance = d(-1);
                for (double t = -1 + step; t < 1; t = t + step)
                {
                    if (distance < d(t))
                    {
                        distance = d(t);
                    }
                }
                if (distance < p.D)
                {
                    p.D = distance;
                    p.A = a;
                    p.B = b;
                }
                a += step;
            }

            Console.WriteLine("A = {0}, B = {1}, D = {2}", p.A, p.B, p.D);
        }
    }
}
