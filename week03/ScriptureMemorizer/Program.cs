//I added another class to pull a text file where we can put the scriptures we want to learn following the format Book|Chapter|starting verse|ending verse|scripture
//I made a small menu to select which scripture you want to start decorating, then it clears and we can choose another one, following the same initial steps of pressing Enter and quit if you want to exit the program.
//and I put a title to make it "pretty", i had a little help from my uncle to understand some functions that we use to make my code easier.
class Program
{
    static void Main()
    {
        try
        {
            var scriptures = new ScriptureLoader().LoadFromFile("scriptures.txt");
            RunMemorizer(scriptures);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }
    }

    static void RunMemorizer(List<Scripture> scriptures)
    {
        while (true) 
        {
            ShowMenu(scriptures);

            var input = Console.ReadLine().ToLower();

            if (input == "quit") break;

            if (int.TryParse(input, out int choice) && choice > 0 && choice <= scriptures.Count)
            {
                StudyScripture(scriptures[choice - 1]);
            }
        }
    }

    static void ShowMenu(List<Scripture> scriptures)
    {
        Console.Clear();
        Console.WriteLine("=== Scripture Memorizer Program ===\n");
        Console.WriteLine("Choose a scripture:");

        for (int i = 0; i < scriptures.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {scriptures[i].GetText()}");
        }
        
        Console.WriteLine("\nEnter the number or 'quit' to exit:");
    }

    static void StudyScripture(Scripture scripture)
    {
        while (!scripture.IsComplete())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetText());
            Console.WriteLine("\nPress Enter to continue or 'quit' to go back");

            if (Console.ReadLine().ToLower() == "quit") break;

            scripture.HideRandomWords(3);
        }
    }
}