using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proiect_ii.Database.Account;
using NUnit.Framework;

namespace proiect_ii.Tests.DatabaseTest.AccountTest
{
    [TestFixture]
    public class AccountControllerTest
    {
        protected Account generateTestAccount()
        {
            Account account = new Account();
            account.username = "test";
            account.password = "3334";
            account.email = "test@mait.com";
            account.securityQuestion1 = "q1";
            account.securityQuestion2 = "q2";
            account.securityQuestion3 = "q3";
            account.securityAnswer1 = "one";
            account.securityAnswer2 = "two";
            account.securityAnswer3 = "three";
            return account;
        }


        [Test]
        public void Test_AddDataBase_VerifThroughUsername()
        {

            Account account = generateTestAccount();
            AccountController accountController = new AccountController();
            accountController.AddToDatabase(account);
            Account verif_through_user = accountController.GetAccountByUsername(account.username);
              
            Assert.AreEqual(account.username, verif_through_user.username);
            Assert.AreEqual(account.password, verif_through_user.password );
            Assert.AreEqual(account.email, verif_through_user.email);
            Assert.AreEqual(account.securityQuestion1, verif_through_user.securityQuestion1);
            Assert.AreEqual(account.securityAnswer1, verif_through_user.securityAnswer1);
            Assert.AreEqual(account.securityQuestion2, verif_through_user.securityQuestion2);
            Assert.AreEqual(account.securityAnswer2, verif_through_user.securityAnswer2 );
            Assert.AreEqual(account.securityQuestion3, verif_through_user.securityQuestion3);
            Assert.AreEqual(account.securityAnswer3, verif_through_user.securityAnswer3);
            accountController.DeleteAccount(account);
        }

        [Test]
        public void Test_UpdatePassword_VerifThroughEmail()
        {
            Account account = generateTestAccount();
            account.password = "7778";

            AccountController accountController = new AccountController();
            accountController.AddToDatabase(account);
            accountController.UpdatePassword(account);
            Account verif_through_email = accountController.GetAccountByEmail(account.email);

            Assert.AreEqual(account.username, verif_through_email.username);
            Assert.AreEqual(account.password, verif_through_email.password);
            Assert.AreEqual(account.email, verif_through_email.email);
            Assert.AreEqual(account.securityQuestion1, verif_through_email.securityQuestion1);
            Assert.AreEqual(account.securityAnswer1, verif_through_email.securityAnswer1);
            Assert.AreEqual(account.securityQuestion2, verif_through_email.securityQuestion2);
            Assert.AreEqual(account.securityAnswer2, verif_through_email.securityAnswer2);
            Assert.AreEqual(account.securityQuestion3, verif_through_email.securityQuestion3);
            Assert.AreEqual(account.securityAnswer3, verif_through_email.securityAnswer3);
            accountController.DeleteAccount(account);
        }
    }
}
