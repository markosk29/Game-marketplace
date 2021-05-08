using proiect_ii.Database.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proiect_ii.Panels
{
    public class Utilities
    {
        AccountController checkEmails;
        public bool IsValidEmail(string email)
        {
            checkEmails = new AccountController();
            List<string> foundEmails = checkEmails.ReadFromDatabaseAccounts("email");


            if (!email.Contains("@") || !email.Contains("."))
                return false;
            if (email.StartsWith("[0 - 9]"))
                return false;
            foreach (string selectedEmail in foundEmails)
            {
                if (selectedEmail.Equals(email))
                    return false;
            }

            return true;
        }
        public bool StrongPass(string pass)
        {
            int ct = 0;
            if (pass.Any(c => char.IsLower(c)))
                ct++;
            if (pass.Any(c => char.IsUpper(c)))
                ct++;
            if (pass.Any(c => char.IsDigit(c)))
                ct++;
            if (pass.IndexOfAny("\\|£$%./?\"^&*+-=[]()@#~<>¬¦`!_{};:', ".ToCharArray()) >= 0)
                ct++;
            if (ct == 4)
                return true;
            return false;
        }
    }
}
