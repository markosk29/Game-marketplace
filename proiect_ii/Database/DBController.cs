using System;

namespace proiect_ii.Database
{
    class DBController
    {
        private static string Host = "proiect-ii.postgres.database.azure.com";
        private static string User = "proiectii222admin@proiect-ii";
        private static string DBname = "postgres";
        private static string Password = "@root123";
        private static string Port = "5432";

        private string connString =
            String.Format(
                "Server={0};Username={1};Database={2};Port={3};Password={4};SSLMode=Prefer",
                Host,
                User,
                DBname,
                Port,
                Password);

        public String GetConnectionString()
        {
            return this.connString;
        }
    }
}
