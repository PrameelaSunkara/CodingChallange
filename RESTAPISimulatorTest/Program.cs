using System.Text;
using RESTAPISimulatorTest;
public class Program
{
    static async Task Main(string[] args)
    {
        int numRequests = 5;

        await SimulateData.SimulatePostRequests(numRequests);
        await SimulateData.SimulateGetRequest();
        Console.ReadKey();
    }   
}



