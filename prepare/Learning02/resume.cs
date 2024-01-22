using System;

public class Resume
{
    public string _personName;
    public List<Job> _jobs;

    // initialize the resume details
    public Resume(string personName)
    {
        _personName = personName;
        _jobs = new List<Job>();
    }

    // Method to add a job to the list
    public void AddJob(Job job)
    {
        _jobs.Add(job);
    }

    // Displaying the method to show the resume details
    public void Display()
    {
        Console.WriteLine($"Name: {_personName}");
        Console.WriteLine("Jobs:");

        foreach (var job in _jobs)
        {
            job.Display();
        }
    }
}