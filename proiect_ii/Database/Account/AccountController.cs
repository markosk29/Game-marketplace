using System.Windows.Documents;
using Npgsql;

namespace proiect_ii.Database.Account
{

    public class AccountController : DBController
    {
        public void AddToDatabase(Account account)
        {
            using (var conn = new NpgsqlConnection(GetConnectionString()))
            {
                conn.Open();

                using (var command = new NpgsqlCommand("INSERT INTO accounts (username, password, email, security_question1, security_answer1, " +
                                                       "security_question2, security_answer2, security_question3, security_answer3) " +
                                                       "VALUES (@ac_user, @ac_pass, @ac_email, @ac_question1, @ac_answer1, @ac_question2, @ac_answer2, @ac_question3, @ac_answer3)", conn))
                {
                    command.Parameters.AddWithValue("ac_user", account.username);
                    command.Parameters.AddWithValue("ac_pass", account.password);
                    command.Parameters.AddWithValue("ac_email", account.email);
                    command.Parameters.AddWithValue("ac_question1", account.securityQuestion1);
                    command.Parameters.AddWithValue("ac_answer1", account.securityAnswer1);
                    command.Parameters.AddWithValue("ac_question2", account.securityQuestion2);
                    command.Parameters.AddWithValue("ac_answer2", account.securityAnswer2);
                    command.Parameters.AddWithValue("ac_question3", account.securityQuestion3);
                    command.Parameters.AddWithValue("ac_answer3", account.securityAnswer3);

                    command.ExecuteNonQuery();
                }

                conn.Close();
            }
        }

        public Account GetAccountByUsername(string username)
        {
            Account account = new Account();

            using (var conn = new NpgsqlConnection(GetConnectionString()))
            {
                conn.Open();

                using (var command = new NpgsqlCommand("SELECT * FROM accounts WHERE username = @username", conn))
                {
                    command.Parameters.AddWithValue("username", username);

                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        account.username = reader.GetString(1);
                        account.password = reader.GetString(2);
                        account.email = reader.GetString(3);
                        account.securityQuestion1 = reader.GetString(4);
                        account.securityAnswer1 = reader.GetString(5);
                        account.securityQuestion2 = reader.GetString(6);
                        account.securityAnswer2 = reader.GetString(7);
                        account.securityQuestion3 = reader.GetString(8);
                        account.securityAnswer3 = reader.GetString(9);
                    }
                }

                conn.Close();
            }

            return account;
        }

        public Account GetAccountByEmail(string email)
        {
            Account account = new Account();

            using (var conn = new NpgsqlConnection(GetConnectionString()))
            {
                conn.Open();

                using (var command = new NpgsqlCommand("SELECT * FROM accounts WHERE email = @email", conn))
                {
                    command.Parameters.AddWithValue("email", email);

                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        account.username = reader.GetString(1);
                        account.password = reader.GetString(2);
                        account.email = reader.GetString(3);
                        account.securityQuestion1 = reader.GetString(4);
                        account.securityAnswer1 = reader.GetString(5);
                        account.securityQuestion2 = reader.GetString(6);
                        account.securityAnswer2 = reader.GetString(7);
                        account.securityQuestion3 = reader.GetString(8);
                        account.securityAnswer3 = reader.GetString(9);
                    }
                }

                conn.Close();
            }

            return account;
        }

        public void UpdatePassword(Account account)
        {
            using (var conn = new NpgsqlConnection(GetConnectionString()))
            {
                conn.Open();

                using (var command = new NpgsqlCommand("UPDATE accounts SET password = @password WHERE email = @email", conn))
                {
                    command.Parameters.AddWithValue("password", account.password);
                    command.Parameters.AddWithValue("email", account.email);

                    command.ExecuteNonQuery();
                }

                conn.Close();
            }
        }

        public void DeleteAccount(Account account)
        {
            using (var conn = new NpgsqlConnection(GetConnectionString()))
            {
                conn.Open();

                using (var command = new NpgsqlCommand("DELETE FROM accounts WHERE '" + account.username + "' ~ username", conn))
                {
                    command.ExecuteNonQuery();
                }

                conn.Close();
            }
        }
    }
}
