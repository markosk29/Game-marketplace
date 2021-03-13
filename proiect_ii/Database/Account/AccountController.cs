using Npgsql;

namespace proiect_ii.Database.Account
{

    class AccountController : DBController
    {

        //tabelul e deja creat, nu apela aceasta metoda, l-am folosit doar la inceput
        public void CreateTable()
        {
            using (var conn = new NpgsqlConnection(GetConnectionString()))
            {
                conn.Open();

                using (var command = new NpgsqlCommand("CREATE TABLE accounts(id serial PRIMARY KEY, username VARCHAR(50), password VARCHAR(50), email VARCHAR(50))", conn))
                {
                    command.ExecuteNonQuery();
                }

                conn.Close();
            }
        }
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
    }
}
