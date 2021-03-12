using System;

namespace proiect_ii.DbClasses
{
    public class Account
    {
        protected int Id { get; set; }
        public String Username { get; set; }

        public String Password { get; set; }

        public String Email { get; set; }
    }
}
