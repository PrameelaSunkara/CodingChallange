using CodingChallenge.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CodingChallenge.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetCustomers()
        {
            return Ok(Program.customers);
        }

        [HttpPost]
        public IActionResult PostCustomers([FromBody] List<Customer> newCustomers)
        {
            if (newCustomers == null || newCustomers.Count == 0)
                return BadRequest("Invalid request format");

            foreach (var customer in newCustomers)
            {
                if (string.IsNullOrEmpty(customer.FirstName) ||
                    string.IsNullOrEmpty(customer.LastName) ||
                    customer.Age <= 18 ||
                    Program.customers.Exists(c => c.Id == customer.Id))
                {
                    return BadRequest("Invalid customer data");
                }
                InsertSorted(customer);
            }

            SaveCustomersToFile(); // Save customers data to file

            return Created("", "Customers added successfully");
        }

        private void InsertSorted(Customer customer)
        {
            int index = 0;
            while (index < Program.customers.Count &&
                   (string.Compare(Program.customers[index].LastName, customer.LastName, StringComparison.OrdinalIgnoreCase) < 0 ||
                    (string.Compare(Program.customers[index].LastName, customer.LastName, StringComparison.OrdinalIgnoreCase) == 0 &&
                     string.Compare(Program.customers[index].FirstName, customer.FirstName, StringComparison.OrdinalIgnoreCase) < 0)))
            {
                index++;
            }
            Program.customers.Insert(index, customer);
        }

        private void SaveCustomersToFile()
        {
            System.IO.File.WriteAllText(Program.FileName, JsonConvert.SerializeObject(Program.customers));
        }
    }
}
