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
    }
}
