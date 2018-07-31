using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Entities
{
    public class User
    {
        public string Domain { get; set; }

        public string Username { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public string Office { get; set; }

        public bool Enable { get; set; }

        public bool Locked { get; set; }
    }
}
