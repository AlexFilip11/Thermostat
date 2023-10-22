using System;
using System.Threading;

namespace termostat2
{
    class Program
    {
        static void Main(string[] args)
        {
 
            // Generate a random initial temperature between 18°C and 22°C
            Random random = new Random();
            double initialTemperature = random.NextDouble() * (22.0 - 18.0) + 18.0; // Initial random temperature in Celsius
            double desiredTemperature;
            do
            {
                Console.WriteLine("Enter the desired temperature in Celsius(17° and above): ");
            } while (!double.TryParse(Console.ReadLine(), out desiredTemperature) || desiredTemperature < 17.0);

            double temperature = initialTemperature;
            bool thermostatOn = true;
            if (desiredTemperature < initialTemperature)
                thermostatOn = false; 
            while (true)
            {
                Console.WriteLine($"Thermostat is {(thermostatOn ? "ON" : "OFF")}. Current Temperature: {Math.Round(temperature, 2)}°C");

                if (thermostatOn)
                {
                    // Gradually increase the temperature every 1 second by 0.1°C
                    if (temperature < desiredTemperature)
                    {
                        temperature += 0.1;
                    }
                    else if (temperature >= desiredTemperature)
                    {
                        temperature = desiredTemperature;
                        Console.WriteLine("Thermostat reached the desired temperature. Turning OFF the thermostat...");
                        thermostatOn = false;
                    }
                }
                else
                {
                    // Gradually decrease the temperature every 1 second by 0.1°C
                    if (temperature > desiredTemperature - 2.0)
                    {
                        temperature -= 0.1;
                    }
                    else
                    {
                        Console.WriteLine("Temperature dropped 2 degrees below the desired temperature. Turning ON the thermostat...");
                        thermostatOn = true;
                    }
                }

                // Wait for 1 second
                Thread.Sleep(1000);
            }
        }
    }
}
