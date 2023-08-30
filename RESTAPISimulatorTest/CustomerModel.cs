using System.Text.Json.Serialization;

namespace RESTAPISimulatorTest
{
    public class Customer
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("firstname")]
        public string FirstName { get; set; }
        [JsonPropertyName("lastname")]
        public string LastName { get; set; }
        [JsonPropertyName("age")]
        public int Age { get; set; }
    }

}
