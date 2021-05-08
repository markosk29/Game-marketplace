using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proiect_ii.Panels;


namespace proiect_ii.Tests.PanelsTests
{
    [TestFixture]
    public class RegisterPanelTests
    {
        [TestCase("sdsds", false)]
        [TestCase("1111", false)]
        [TestCase("paprika@mail.com", true)]
        [TestCase("Paprika@mail.com", true)]
        [TestCase("paprikamail.com", false)]
        [TestCase("paprika@mailcom", false)]
        //[TestCase("MCT_XXI156@gmail.com", false)]   // trebuie sa de-a false pt ca exista in baza de date
        public void Test_IsValidEmail_ReturnBoolean(string email, bool expect)
        {
            Utilities rp = new Utilities();
            bool answer = rp.IsValidEmail(email);
            Assert.That(answer, Is.EqualTo(expect));
        }

        [TestCase("sdsds", false)]
        [TestCase("1111", false)]
        [TestCase("ABCD", false)]
        [TestCase("PPaprika11@mail.com", true)]
        [TestCase("12345BrdBank@1**", true)]
        [TestCase("Boru23@Vali", true)]
        [TestCase("paprikamail.com", false)]
        [TestCase("paprika@mailcom", false)]
        [TestCase("121212#$%", false)]
        [TestCase("AHSHS#$%", false)]
        [TestCase("adaksdhk#$%", false)]
        [TestCase("paprika@mailcom", false)]
        public void Test_ValidPass_ReturnBoolean(string pass, bool expect)
        {
            Utilities rp = new Utilities();
            bool answer = rp.StrongPass(pass);
            Assert.That(answer, Is.EqualTo(expect));
        }
    }
}
