using System;
using System.Collections.Generic;
using System.Configuration;
using System.Windows.Documents;
using Npgsql;

namespace proiect_ii.Database.Game
{
    class GameController : DBController
    {

        private List<string> databaseOutput;

        public GameController()
        {
            this.databaseOutput = new List<string>();
        }

        public void AddToDatabase(Game game)
        {
            using (var conn = new NpgsqlConnection(GetConnectionString()))
            {
                conn.Open();

                using (var command = new NpgsqlCommand("INSERT INTO games (name, publisher, developer, categories, description)" +
                                                       " VALUES (@game_name, @game_publisher, @game_dev, @game_desc, @game_category1, @game_category2, @game_category3)", conn))
                {
                    command.Parameters.AddWithValue("game_name", game.name);
                    command.Parameters.AddWithValue("game_publisher", game.publisher);
                    command.Parameters.AddWithValue("game_dev", game.developer);
                    command.Parameters.AddWithValue("game_desc", game.description);
                    command.Parameters.AddWithValue("game_category1", game.category1);
                    command.Parameters.AddWithValue("game_category2", game.category2);
                    command.Parameters.AddWithValue("game_category3", game.category3);

                    command.ExecuteNonQuery();
                }

                conn.Close();
            }
        }

        public List<string> ReadFromDatabase(string column)
        {
            using (var conn = new NpgsqlConnection(GetConnectionString()))
            {
                conn.Open();

                using (var command = new NpgsqlCommand("SELECT " + column + " FROM games", conn))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        databaseOutput.Add(reader.GetString(0));
                    }
                }

                conn.Close();
            }

            return databaseOutput;
        }

    }
}
