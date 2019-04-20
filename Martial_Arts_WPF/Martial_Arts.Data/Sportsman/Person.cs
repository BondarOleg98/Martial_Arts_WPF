using Martial_Arts.Data.Sportsman;
using System;
using System.Data.Linq.Mapping;
using System.Runtime.Serialization;

namespace Martial_Arts.Data
{
    [DataContract]
    [KnownType(typeof(Student))]
    [KnownType(typeof(Coach))]
    [Table]
    [InheritanceMapping(Code = "S", Type = typeof(Student),
    IsDefault = true)]
    public class Person : Base
    {
        [Column(IsDiscriminator = true)]
        public string DiscKey;

        [DataMember]
        private int age;
       
        public string Country { get; set; }
        [DataMember]   
        [Column]
        public string Belt { get; set; }

        public string SportTitle { get; set; }

        [DataMember]
        [Column]
        public string Name { get; set; }

        [DataMember]
        [Column]
        public string Surname { get; set; }

        public Person()
        {

        }
        [Column]
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
