using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Journal myJournal = new Journal();

        int choice;
        do
        {
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice (1-5): ");

            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 5)
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 5.");
                Console.Write("Enter your choice (1-5): ");
            }

            switch (choice)
            {
                case 1:
                    myJournal.WriteNewEntry();
                    break;
                case 2:
                    myJournal.DisplayJournal();
                    break;
                case 3:
                    myJournal.SaveToFile();
                    break;
                case 4:
                    myJournal.LoadFromFile();
                    break;
            }

        } while (choice != 5);
    }
}

class JournalEntry
{
    public string Prompt { get; set; }
    public string Response { get; set; }
    public DateTime Date { get; set; }

    public JournalEntry(string prompt, string response)
    {
        Prompt = prompt;
        Response = response;
        Date = DateTime.Now;
    }

    public void DisplayEntry()
    {
        Console.WriteLine($"Date: {Date.ToShortDateString()}\nPrompt: {Prompt}\nResponse: {Response}\n");
    }
}

class Journal
{
    private List<JournalEntry> entries = new List<JournalEntry>();

    public void WriteNewEntry()
    {
        Console.WriteLine("Selecting a random prompt...");
        string randomPrompt = GetRandomPrompt();
        Console.WriteLine($"Prompt: {randomPrompt}");
        Console.Write("Enter your response: ");
        string response = Console.ReadLine();

        JournalEntry newEntry = new JournalEntry(randomPrompt, response);
        entries.Add(newEntry);
        Console.WriteLine("Entry added successfully!\n");
    }

    public void DisplayJournal()
    {
        Console.WriteLine("Journal Entries:");
        foreach (var entry in entries)
        {
            entry.DisplayEntry();
        }
    }

    public void SaveToFile()
    {
        Console.Write("Enter the filename to save the journal: ");
        string fileName = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            foreach (var entry in entries)
            {
                outputFile.WriteLine($"{entry.Date},{entry.Prompt},{entry.Response}");
            }
        }

        Console.WriteLine($"Journal saved to {fileName} successfully!\n");
    }

    public void LoadFromFile()
    {
        Console.Write("Enter the filename to load the journal: ");
        string fileName = Console.ReadLine();

        if (File.Exists(fileName))
        {
            entries.Clear(); 

            string[] lines = File.ReadAllLines(fileName);
            foreach (var line in lines)
            {
                string[] parts = line.Split(",");
                DateTime date = DateTime.Parse(parts[0]);
                string prompt = parts[1];
                string response = parts[2];

                JournalEntry loadedEntry = new JournalEntry(prompt, response) { Date = date };
                entries.Add(loadedEntry);
            }

            Console.WriteLine($"Journal loaded from {fileName} successfully!\n");
        }
        else
        {
            Console.WriteLine($"File {fileName} does not exist. Unable to load.\n");
        }
    }

    public string GetRandomPrompt()
    {
        List<string> prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?"
        };
        
            Random random = new Random();
        int index = random.Next(prompts.Count);

        return prompts[index];
    }
}