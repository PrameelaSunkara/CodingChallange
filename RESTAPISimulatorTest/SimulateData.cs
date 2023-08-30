using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace RESTAPISimulatorTest
{
    internal class SimulateData
    {
        private static readonly HttpClient client = new HttpClient();
       public static async Task SimulatePostRequests(int numRequests)
        {
            var getCustomers = await client.GetStringAsync("https://localhost:7288/customer");
            var result = JsonSerializer.Deserialize<List<Customer>>(getCustomers);
            int n=result.Max(x=>x.Id) ;
            for (int i = 0; i < numRequests; i++)
            {
                var customers = new List<Customer>
                {
                    GenerateTestData.GenerateRandomCustomer(n+1),
                    GenerateTestData.GenerateRandomCustomer(n+2)
                };
                n += 2;
                var response = await client.PostAsync("https://localhost:7288/customer", Serialize(customers));
                Console.WriteLine($"Response for POST {i + 1}: {response.StatusCode}");
            }
        }

        public static async Task SimulateGetRequest()
        {
            var response = await client.GetStringAsync("https://localhost:7288/customer");
            Console.WriteLine(response);
        }

        public static StringContent Serialize(object obj)
        {
            return new StringContent(JsonSerializer.Serialize(obj), Encoding.UTF8, "application/json");
        }
    }
}
