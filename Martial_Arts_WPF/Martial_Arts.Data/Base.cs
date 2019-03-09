using System;
using System.Collections.Generic;
using System.Text;

namespace Martial_Arts.Data
{
    public class Base
    {
        public Guid Id { get; set; }
        public Base()
        {
            Id = Guid.NewGuid();
        }
    }
}
