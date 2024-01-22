using System;

class Program
{
    static void Main(string[] args)
    {
        // The Job class
        Job job1 = new Job("Microsoft", "Software Engineer", 2019, 2022);
        Job job2 = new Job("Apple", "Manager", 2022, 2023);

        // Display job details using the Display method
        job1.Display();
        job2.Display();

        // New Resume class
        Resume myResume = new Resume("Allison Rose");

        // Adding jobs to the resume
        myResume.AddJob(job1);
        myResume.AddJob(job2);

        // Display resume using Display method
        myResume.Display();
    }
}