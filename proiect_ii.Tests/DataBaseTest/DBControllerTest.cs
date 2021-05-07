using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using proiect_ii.Database;

namespace proiect_ii.Tests.DatabaseTest
{
    [TestFixture]
    public class DBControllerTest
    {
        [Test]
        public void GetConnectionString_SetValue_ReturnMatch()
        {
            String connectStr = "Server=localhost;Username=postgres;Database=proiect_ii;Port=5432;Password=greSql;SSLMode=Prefer";
            DBController db = new DBController();

            Assert.That(db.GetConnectionString(), Is.EqualTo(connectStr));
            }
    }
}
