using System.Windows.Documents;
using Npgsql;

namespace proiect_ii.Database.Account
{

    class AccountController : DBController
    {
        public void AddToDatabase(Account account)
        {
            using (var conn = new NpgsqlConnection(GetConnectionString()))
            {
                conn.Open();

                using (var command = new NpgsqlCommand("INSERT INTO accounts (username, password, email) VALUES (@ac_user, @ac_pass, @ac_email)", conn))
                {
                    command.Parameters.AddWithValue("ac_user", account.username);
                    command.Parameters.AddWithValue("ac_pass", account.password);
                    command.Parameters.AddWithValue("ac_email", account.email);

                    command.ExecuteNonQuery();
                }

                conn.Close();
            }
        }

        public Account GetUser(string username)
        {
            Account account = new Account();

            using (var conn = new NpgsqlConnection(GetConnectionString()))
            {
                conn.Open();

                using (var command = new NpgsqlCommand("SELECT * FROM accounts WHERE '" +username+ "' ~ username", conn))
                {
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        account.username = reader.GetString(1);
                        account.password = reader.GetString(2);
                        account.email = reader.GetString(3);
                    }
                }

                conn.Close();
            }

            return account;
        }
    }
}
