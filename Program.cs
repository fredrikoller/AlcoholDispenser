using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace AlcoholDispenser
{
    class Program
    {
        
        static void Main(string[] args)
        {
            var filePath = @"Vikter.txt";
            float bagMaxWeight = 15.0f;
            int bagCount = 0;

            List<string> fileContent = FileHandler.ReadFile(filePath);
            List<float> listContent = fileContent
                            .Select(x => float.Parse(x, CultureInfo.InvariantCulture.NumberFormat))
                            .OrderByDescending(l => l)
                            .ToList();

            float tempBagAmount = 0f;

            foreach (var item in listContent)
            {
                // temporary bag is empty
                if (tempBagAmount == 0f)
                {
                    tempBagAmount += item;

                }
                // temporary bag + item is less than max weight
                else if ((tempBagAmount + item) < bagMaxWeight)
                {
                    tempBagAmount += item;
                }
                // temporary bag is full
                else if (tempBagAmount == bagMaxWeight)
                {
                    bagCount++;
                    tempBagAmount = 0;
                }
                
                System.Console.WriteLine($"TempBagAmount: ${tempBagAmount}");

            }
            System.Console.WriteLine($"Amount of bags: ${bagCount}");
        }
    }
}
