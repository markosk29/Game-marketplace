using System;

namespace proiect_ii.Database
{
    public class DBController
    {
        
        private static string Host = "proiect-ii.postgres.database.azure.com";
        private static string User = "proiectii222admin@proiect-ii";
        private static string DBname = "postgres";
        private static string Password = "@root123";
        private static string Port = "5432";
        
/*
        // BD local MCT-XXI
        private static string Host = "localhost";
        private static string User = "postgres";
        private static string DBname = "proiect_ii";
        private static string Password = "greSql";
        private static string Port = "5432";
        //*/

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
