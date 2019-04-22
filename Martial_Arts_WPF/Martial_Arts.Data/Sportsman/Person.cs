using Martial_Arts.Data.Sportsman;
using System;
using System.Configuration;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Runtime.Serialization;

namespace Martial_Arts.Data
{
    [DataContract]
    [KnownType(typeof(Student))]
    [KnownType(typeof(Coach))]
    [Table]
    [InheritanceMapping(Code = "S", Type = typeof(Student),IsDefault = true)]
    public class Person :DataContext
    {
        [Column(IsDiscriminator = true, DbType = "varchar(50)")]
        public string DiscKey;

        [Column(DbType = "int")]
        public int Fk_Coach_id { get; set; }

        [DataMember]
        private int age;

        [Column(IsPrimaryKey = true, IsDbGenerated = true, DbType = "Int NOT NULL IDENTITY")]
        public int Pk_Person_Id { get; set; }

        [DataMember]
        [Column(DbType = "varchar(50)")]
        public string Belt { get; set; }


        [DataMember]
        [Column(DbType = "varchar(50)")]
        public string Name { get; set; }

        [DataMember]
        [Column(DbType = "varchar(50)")]
        public string Surname { get; set; }

        public Person():base(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString)
        {

        }
        [Column(DbType = "Int")]
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
        
    }
}
