using System;

namespace proiect_ii.Database.Account
{
    public class Account
    {
        public int id { get; set; }

        public String username { get; set; }

        public String password { get; set; }

        public String email { get; set; }

        public String securityQuestion1 { get; set; }

        public String securityAnswer1 { get; set; }

        public String securityQuestion2 { get; set; }

        public String securityAnswer2 { get; set; }

        public String securityQuestion3 { get; set; }

        public String securityAnswer3 { get; set; }

        public double balance { get; set; }

    }
}
