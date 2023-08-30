using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTAPISimulatorTest
{
    internal class GenerateTestData
    {
        private static readonly string[] FirstNames = { "Leia", "Sadie", "Jose", "Sara", "Frank", "Dewey", "Tomas", "Joel", "Lukas", "Carlos" };
        private static readonly string[] LastNames = { "Liberty", "Ray", "Harrison", "Ronan", "Drew", "Powell", "Larsen", "Chan", "Anderson", "Lane" };
        public static Customer GenerateRandomCustomer(int id)
        {
            var random = new Random();
            return new Customer
            {
                FirstName = FirstNames[random.Next(FirstNames.Length)],
                LastName = LastNames[random.Next(LastNames.Length)],
                Age = random.Next(19, 91),
                Id = id
            };
        }

    }
}
