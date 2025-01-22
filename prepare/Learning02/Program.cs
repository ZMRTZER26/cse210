using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._jobTitle = "Software Engineer";
        job1._company = "O.W.C.A.";
        job1._startYear = 2007;
        job1._endYear = 2015;

        Job job2 = new Job();
        job2._jobTitle = "Janitor";
        job2._company = "Doofenshmirtz Evil Incorporated";
        job2._startYear = 2007;
        job2._endYear = 2015;

        Resume myResume = new Resume();
        myResume._name = "Henchman #1";

        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        myResume.Display();
    }
}