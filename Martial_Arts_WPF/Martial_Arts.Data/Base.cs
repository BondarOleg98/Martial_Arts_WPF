using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Martial_Arts.Data
{
    [DataContract]
    public class Base
    {
        [DataMember]
        public Guid Id { get; set; }
        public Base()
        {
            Id = Guid.NewGuid();
        }
    }
}
