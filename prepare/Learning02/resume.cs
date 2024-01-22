using System;

class Program
{
    static void Main()
    {
        // instances of the Job class
        Job job1 = new Job("Microsoft", "Software Engineer", 2019, 2022);
        Job job2 = new Job("Apple", "Manager", 2022, 2023);

        // Displaying job details using the Display method
        job1.Display();
        job2.Display();

        // Creating an instance of the Resume class
        Resume myResume = new Resume("Allison Rose");

        // Adding jobs to the resume
        myResume.AddJob(job1);
        myResume.AddJob(job2);

        // Display resume details using the Display method
        myResume.Display();
    }
}