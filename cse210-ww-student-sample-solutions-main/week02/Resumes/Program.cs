using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._jobTitle = "Robotics Instructor";
        job1._company = "";
        job1._startYear = 2019;
        job1._endYear = 2022;

        Job job2 = new Job();
        job2._jobTitle = "Technical Officer";
        job2._company = "Ghana Meteorological Agency";
        job2._startYear = 2011;
        job2._endYear = 2012;

        Resume myResume = new Resume();
        myResume._name = "Jonah Quarshie";

        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        myResume.Display();
    }
}
