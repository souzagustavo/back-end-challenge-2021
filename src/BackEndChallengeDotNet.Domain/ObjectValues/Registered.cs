using System;

namespace BackEndChallengeDotNet.Domain.ObjectValues
{
    public class Registered
    {
        public Registered(DateTime date, int age)
        {
            Date = date;
            Age = age;
        }

        public DateTime Date { get; private set; }
        public int Age { get; private set; }
    }
}
