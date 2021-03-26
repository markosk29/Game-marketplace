using System;
using System.Configuration;
using Npgsql;

namespace proiect_ii.Database.Game
{
    class GameController : DBController
    {
        public void CreateTable()
        {
            using (var conn = new NpgsqlConnection(GetConnectionString()))
            {
                conn.Open();

                using (var command = new NpgsqlCommand("CREATE TABLE games(id serial PRIMARY KEY, name VARCHAR(75), publisher VARCHAR(75), developer VARCHAR(75), categories VARCHAR(10), description VARCHAR(500)", conn))
                {
                    command.ExecuteNonQuery();
                }

                conn.Close();
            }
        }

        public void AddToDatabase(Game game)
        {
            using (var conn = new NpgsqlConnection(GetConnectionString()))
            {
                conn.Open();

                using (var command = new NpgsqlCommand("INSERT INTO games (name, publisher, developer, categories, description) VALUES (@game_name, @game_publisher, @game_dev, @game_categories, @game_desc)", conn))
                {
                    command.Parameters.AddWithValue("game_name", game.name);
                    command.Parameters.AddWithValue("game_publisher", game.publisher);
                    command.Parameters.AddWithValue("game_dev", game.developer);
                    command.Parameters.AddWithValue("game_categories", game.categories);
                    command.Parameters.AddWithValue("game_desc", game.description);

                    command.ExecuteNonQuery();
                }

                conn.Close();
            }
        }

    }
}
