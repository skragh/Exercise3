﻿using System;

namespace ECS.Redesign
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Testing ECS.Legacy");

            // Make an ECS with a threshold of 23
            IHeater heater = new Heater();
            ITempSensor tempSensor = new TempSensor();
            var control = new ECS(23,tempSensor,heater);

            for (int i = 1; i <= 15; i++)
            {
                Console.WriteLine($"Running regulation number {i}");

                control.Regulate();
            }

        }
    }
}
