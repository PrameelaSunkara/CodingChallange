public class Program
{
    static void Main(string[] args)
    {
        int[] denominations = { 10, 50, 100 };
        int[] amounts = { 100, 30, 50, 60, 80, 140, 230, 370, 610, 980 };

        foreach (int amount in amounts)
        {
            Console.WriteLine($"Possible combinations for {amount} EUR:");
            List<List<int>> combinations = CalculateCombinations(denominations, amount);

            foreach (List<int> combination in combinations)
            {
                int i = 0;
                foreach (var item in combination.GroupBy(x=>x))
                {
                    Console.Write((i>0?" + ":"")+item.Count()+" X "+item.Key);
                    i++;
                }
                Console.WriteLine();
            }

            Console.WriteLine();
        }
        Console.ReadKey();
    }

    static List<List<int>> CalculateCombinations(int[] denominations, int amount)
    {
        List<List<int>> result = new List<List<int>>();
        CalculateCombinationsHelper(denominations, amount, 0, new List<int>(), result);
        return result;
    }

    static void CalculateCombinationsHelper(int[] denominations, int amount, int index, List<int> currentCombination, List<List<int>> result)
    {
        if (amount == 0)
        {
            result.Add(new List<int>(currentCombination));
            return;
        }

        if (index >= denominations.Length || amount < 0)
        {
            return;
        }

        // Include the current denomination
        currentCombination.Add(denominations[index]);
        CalculateCombinationsHelper(denominations, amount - denominations[index], index, currentCombination, result);
        currentCombination.RemoveAt(currentCombination.Count - 1);

        // Skip the current denomination
        CalculateCombinationsHelper(denominations, amount, index + 1, currentCombination, result);
    }
}