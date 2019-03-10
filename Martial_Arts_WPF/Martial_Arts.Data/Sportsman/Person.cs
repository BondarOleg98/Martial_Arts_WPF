using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Martial_Arts.Data
{
    public class Person : Base
    {
        private int age;
        public string Country { get; set; }
        public string Belt { get; set; }
        public string SportTitle { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public Person()
        {

        }
        public int Age
        {
            get { return age; }
            set
            {
                if (value < 0)
                    age = 0;
                else
                    age = value;
            }
        }
        public Person(string name, string surname, string belt, string sportTitle, int age, string country)
        {
            Name = name;
            Surname = surname;
            Belt = belt;
            SportTitle = sportTitle;
            Age = age;
            Country = country;
        }

        public Person(string name, string surname, string belt, int age)
        {
            Name = name;
            Surname = surname;
            Belt = belt;
            this.age = age;
        }
    }
}
