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
            int bagCount;

            List<string> fileContent = FileHandler.ReadFile(filePath);
            List<float> listContent = fileContent
                            .Select(x => float.Parse(x, CultureInfo.InvariantCulture.NumberFormat))
                            .OrderByDescending(l => l)
                            .ToList();
        }
    }
}
