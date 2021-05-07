using System;
using System.Collections.Generic;
using System.Configuration;
using System.Windows.Documents;
using Npgsql;

namespace proiect_ii.Database.Game
{
    public class GameController : DBController
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

                // am modificat linia 26, rezolv cand imi trimiti structura tabelului ca nu pot sa-l reglez, eu ma folosesc de BD local pentru al testa, oricum ordinea se schimba putin, in rest se face repede
                /*using (var command = new NpgsqlCommand("INSERT INTO games (name, publisher, developer, categories, description)" +
                                                       " VALUES (@game_name, @game_publisher, @game_dev, @game_desc, @game_category1, @game_category2, @game_category3)", conn))
                */
                using (var command = new NpgsqlCommand("INSERT INTO games (name, publisher, developer, description, category1, category2, category3)" +
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

        public Game GetGameByName(string gameName)
        {
            Game game = new Game();

            using (var conn = new NpgsqlConnection(GetConnectionString()))
            {
                conn.Open();

                using (var command = new NpgsqlCommand("SELECT * FROM games WHERE '" + gameName + "' ~ name", conn))
                {
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        game.name = reader.GetString(1);
                        game.publisher = reader.GetString(2);
                        game.developer = reader.GetString(3);
                        game.description = reader.GetString(4);
                        game.category1 = reader.GetString(5);
                        game.category2 = reader.GetString(6);
                        game.category3 = reader.GetString(7);
                    }
                }

                conn.Close();
            }

            return game;
        }

        public void DeleteGame(Game game)
        {
            using (var conn = new NpgsqlConnection(GetConnectionString()))
            {
                conn.Open();

                using (var command = new NpgsqlCommand("DELETE FROM games WHERE '" + game.name + "' ~ name", conn))
                {
                    command.ExecuteNonQuery();
                }

                conn.Close();
            }
        }

    }
}
