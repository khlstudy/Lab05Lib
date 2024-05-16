using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab05Lib;
using static Lab05Lib.ClassesLib;

namespace Lab05App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            int countryCount = (int)GetValidNumber("кількість країн");

            Country[] countries = new Country[countryCount];

            for (int i = 0; i < countryCount; i++)
            {
                Console.WriteLine($"\nКраїна {i + 1}:");

                Console.Write("Введіть назву країни: ");
                string countryName = Console.ReadLine();

                Console.Write("Введіть материк, на якому знаходиться країна: ");
                string continent = Console.ReadLine();

                Console.Write("Введіть столицю країни: ");
                string capitalCity = Console.ReadLine();

                double population = GetValidNumber("кількість населення");
                double area = GetValidNumber("площу, кв. км");
                double lifeExpectancy = GetValidNumber("середній вік життя");
                int independenceYear = (int)GetValidNumber("рік незалежності");

                Console.Write("Чи є країна членом Європейського Союзу? (y - так, n - ні): ");
                ConsoleKeyInfo keyIsInEU = Console.ReadKey();
                Console.WriteLine();

                Console.Write("Чи є країна членом НАТО? (y - так, n - ні): ");
                ConsoleKeyInfo keyIsInNATO = Console.ReadKey();
                Console.WriteLine();

                countries[i] = new Country
                {
                    CountryName = countryName,
                    Continent = continent,
                    CapitalCity = capitalCity,
                    Population = population,
                    Area = area,
                    LifeExpectancy = lifeExpectancy,
                    IndependenceYear = independenceYear,
                    IsInEU = keyIsInEU.Key == ConsoleKey.Y,
                    IsInNATO = keyIsInNATO.Key == ConsoleKey.Y
                };
            }

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("ІНФОРМАЦІЯ ПРО КРАЇНИ");
            Console.ResetColor();

            foreach (var country in countries)
            {
                Console.WriteLine($"\nНазва країни: {country.CountryName}");
                Console.WriteLine($"Материк: {country.Continent}");
                Console.WriteLine($"Столиця країни: {country.CapitalCity}");
                Console.WriteLine($"Кількість населення: {country.Population}");
                Console.WriteLine($"Площа: {country.Area:F3}");
                Console.ForegroundColor = country.IsInEU ? ConsoleColor.Green : ConsoleColor.Red;
                Console.WriteLine(country.IsInEU ? "Країна є членом ЄС" : "Країна не є членом ЄС");
                Console.ResetColor();
                Console.ForegroundColor = country.IsInNATO ? ConsoleColor.Green : ConsoleColor.Red;
                Console.WriteLine(country.IsInNATO ? "Країна є членом НАТО" : "Країна не є членом НАТО");
                Console.ResetColor();
                Console.WriteLine($"Рік незалежності: {country.IndependenceYear}");
                Console.WriteLine($"Густина населення: {country.CalculatePopulationDensity():F2}");
                if (country.IsPopulationDensityAboveAverage())
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Густина населення країни більше середньої густини населення Землі");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Густина населення країни менше або рівна середній густині населення Землі");
                }
                Console.ResetColor();
            }

            Console.ReadLine();
        }

        static double GetValidNumber(string prompt)
        {
            double number = 0;
            bool validInput = false;
            while (!validInput)
            {
                Console.Write($"Введіть {prompt}: ");
                string userInput = Console.ReadLine();
                validInput = double.TryParse(userInput, out number);
                if (!validInput)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine($"Помилка: Некоректне значення для {prompt}. Будь ласка, введіть число.");
                    Console.ResetColor();
                }
            }
            return number;
        }
    }
}
    

