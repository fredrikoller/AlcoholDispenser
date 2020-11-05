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
            int numberOfBags = 0;

            List<string> fileContent = FileHandler.ReadFile(filePath);
            // List<float> listContent = fileContent
            //                 .Select(x => float.Parse(x, CultureInfo.InvariantCulture.NumberFormat))
            //                 .OrderByDescending(l => l)
            //                 .ToList();

            List<float> listContent = fileContent
                                    .Select(x => float.Parse(x, CultureInfo.InvariantCulture.NumberFormat))
                                    .ToList();


            float currentWeight = 0f;
            var totalWeight = listContent.Sum();
            var tempWeightSum = 0f;
            System.Console.WriteLine(totalWeight);
            foreach (var item in listContent)
            {
                // bag is empty or current weight + item weight is less than max weight
                if (currentWeight == 0f || (currentWeight + item) < bagMaxWeight)
                {
                    currentWeight += item;
                }
                else {
                    tempWeightSum += currentWeight;
                    numberOfBags++;
                    currentWeight = 0;
                }
                
                Console.WriteLine($"TempBagAmount: {currentWeight}");
                
            }
            Console.WriteLine($"Amount of bags: {numberOfBags}");
            Console.WriteLine($"Temp Weigth Sum: {tempWeightSum}");
            Console.WriteLine($"Difference: {tempWeightSum - currentWeight}");
        }
    }
}
