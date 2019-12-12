using System;
using System.Collections.Generic;
using System.Text;
//using System.Math;

namespace Math.Approximation
{
    public class AffineApproximation
    {
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
            Func<double, double> d = (x) => { return System.Math.Abs(g(x) - f(x)); };

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
            Func<double, double> f = (x) => { return x * x; };

            // approximating function:
            Func<double, double> g = (x) => { return a * x + b; };

            // uniform distance:
            Func<double, double> d = (x) => { return System.Math.Abs(g(x) - f(x)); };

            double step = 0.0001;

            while (a < 2)
            {
                double distance = d(0);
                for (double t = 0 + step; t < 1; t = t + step)
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
