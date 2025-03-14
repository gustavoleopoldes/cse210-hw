using System;
//I added automatic cleaning after pressing a key, to make it easier to view and make the code cleaner after using the functions it provides.
//I also created some notifications so we know when things worked and were added
public class Program
{
    public static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

       while (true)
       {
        Console.Clear();
        Console.WriteLine("Welcome to the Journal App!\nPlease select one of the following choices: ");
        Console.WriteLine("1. Write");
        Console.WriteLine("2. Display");
        Console.WriteLine("3. Save");
        Console.WriteLine("4. Load");
        Console.WriteLine("5. Exit");
        Console.WriteLine("What would you like to do? ");
        string choice = Console.ReadLine();

        if (choice == "1")
        {
            string prompt = promptGenerator.GetRandomPrompt();
            Console.WriteLine("Prompt: " + prompt);
            Console.Write("Your response: ");
            string response = Console.ReadLine();
            string date = DateTime.Now.ToShortDateString();  

            Entry newEntry = new Entry(date, prompt, response);  
            journal.AddEntry(newEntry);  
            Console.WriteLine("Entry added successfully!\n");
        }
        else if (choice == "2")
        {
            journal.DisplayAll();
        }
        else if (choice == "3")
        {
            Console.Write("Enter filename to save: ");
            string fileName = Console.ReadLine();
            journal.SaveToFile(fileName);
            Console.WriteLine("Journal saved successfully!\n");
        }
        else if (choice == "4")
        {
            Console.Write("Enter filename to load: ");
            string fileName = Console.ReadLine();
            journal.LoadFromFile(fileName);  
            Console.WriteLine("Journal loaded successfully!\n");
        }
        else if (choice == "5")
        {
            break;
        }
        else
        {
            Console.WriteLine("Invalid choice. Please try again. ");
        }
        Console.WriteLine("Press any key to continue... ");
        Console.ReadKey();
       }
    }
}