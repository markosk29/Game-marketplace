using System;
using System.Collections.Generic;
using System.Configuration;
using System.Windows.Documents;
using Npgsql;
using NpgsqlTypes;

namespace proiect_ii.Database.Game
{
    public class GameController : DBController
    {

        private List<Game> databaseOutput;

        public GameController()
        {
            this.databaseOutput = new List<Game>();
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

        public List<Game> ReadAllGames()
        {
            using (var conn = new NpgsqlConnection(GetConnectionString()))
            {
                conn.Open();

                using (var command = new NpgsqlCommand("SELECT * FROM games", conn))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        databaseOutput.Add(new Game()
                        {
                            id = reader.GetInt32(0),
                            name = reader.GetString(1),
                            publisher = reader.GetString(2),
                            developer = reader.GetString(3),
                            description = reader.GetString(4),
                            category1 = reader.GetString(5),
                            category2 = reader.GetString(6),
                            category3 = reader.GetString(7),
                            main_img_link = reader.GetString(8),
                            showoff_img_link_1 = reader.GetString(9),
                            showoff_img_link_2 = reader.GetString(10),
                            showoff_img_link_3 = reader.GetString(11),
                            showoff_img_link_4 = reader.GetString(12),
                            showoff_img_link_5 = reader.GetString(13),
                            showoff_video_link_1 = reader.GetString(14),
                            showoff_video_link_2 = reader.GetString(15),
                            price = reader.GetDouble(16)
                        });
                    }
                }

                conn.Close();
            }

            return databaseOutput;
        }

        public List<Game> ReadFromDatabaseGames(string column, int selectedCategory)
        {
            using (var conn = new NpgsqlConnection(GetConnectionString()))
            {
                conn.Open();

                using (var command = new NpgsqlCommand("SELECT * FROM games WHERE " +column+ "= @category", conn))
                {
                    command.Parameters.AddWithValue("category", selectedCategory.ToString());

                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        databaseOutput.Add(new Game()
                        {
                            id = reader.GetInt32(0),
                            name = reader.GetString(1),
                            publisher = reader.GetString(2),
                            developer = reader.GetString(3),
                            description = reader.GetString(4),
                            category1 = reader.GetString(5),
                            category2 = reader.GetString(6),
                            category3 = reader.GetString(7),
                            main_img_link = reader.GetString(8),
                            showoff_img_link_1 = reader.GetString(9),
                            showoff_img_link_2 = reader.GetString(10),
                            showoff_img_link_3 = reader.GetString(11),
                            showoff_img_link_4 = reader.GetString(12),
                            showoff_img_link_5 = reader.GetString(13),
                            showoff_video_link_1 = reader.GetString(14),
                            showoff_video_link_2 = reader.GetString(15),
                            price = reader.GetDouble(16)
                        });
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

                using (var command = new NpgsqlCommand("SELECT * FROM games WHERE name = @name", conn))
                {
                    command.Parameters.AddWithValue("name", gameName);

                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        game.id = reader.GetInt32(0);
                        game.name = reader.GetString(1);
                        game.publisher = reader.GetString(2);
                        game.developer = reader.GetString(3);
                        game.description = reader.GetString(4);
                        game.category1 = reader.GetString(5);
                        game.category2 = reader.GetString(6);
                        game.category3 = reader.GetString(7);
                        game.main_img_link = reader.GetString(8);
                        game.showoff_img_link_1 = reader.GetString(9);
                        game.showoff_img_link_2 = reader.GetString(10);
                        game.showoff_img_link_3 = reader.GetString(11);
                        game.showoff_img_link_4 = reader.GetString(12);
                        game.showoff_img_link_5 = reader.GetString(13);
                        game.showoff_video_link_1 = reader.GetString(14);
                        game.showoff_video_link_2 = reader.GetString(15);
                        game.price = reader.GetDouble(16);
                    }
                }

                conn.Close();
            }

            return game;
        }

        public Game GetGameById(int id)
        {
            Game game = new Game();

            using (var conn = new NpgsqlConnection(GetConnectionString()))
            {
                conn.Open();

                using (var command = new NpgsqlCommand("SELECT * FROM games WHERE id = @id", conn))
                {
                    command.Parameters.AddWithValue("id", id);

                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        game.id = reader.GetInt32(0);
                        game.name = reader.GetString(1);
                        game.publisher = reader.GetString(2);
                        game.developer = reader.GetString(3);
                        game.description = reader.GetString(4);
                        game.category1 = reader.GetString(5);
                        game.category2 = reader.GetString(6);
                        game.category3 = reader.GetString(7);
                        game.main_img_link = reader.GetString(8);
                        game.showoff_img_link_1 = reader.GetString(9);
                        game.showoff_img_link_2 = reader.GetString(10);
                        game.showoff_img_link_3 = reader.GetString(11);
                        game.showoff_img_link_4 = reader.GetString(12);
                        game.showoff_img_link_5 = reader.GetString(13);
                        game.showoff_video_link_1 = reader.GetString(14);
                        game.showoff_video_link_2 = reader.GetString(15);
                        game.price = reader.GetDouble(16);
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

        public List<Game> SearchGame(string field)
        {
            databaseOutput = new();

            using (var conn = new NpgsqlConnection(GetConnectionString()))
            {
                conn.Open();

                using (var command = new NpgsqlCommand("SELECT * FROM games WHERE name ILIKE '" +field+ "%'", conn))
                {
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        databaseOutput.Add(new Game()
                        {
                            id = reader.GetInt32(0),
                            name = reader.GetString(1),
                            publisher = reader.GetString(2),
                            developer = reader.GetString(3),
                            description = reader.GetString(4),
                            category1 = reader.GetString(5),
                            category2 = reader.GetString(6),
                            category3 = reader.GetString(7),
                            main_img_link = reader.GetString(8),
                            showoff_img_link_1 = reader.GetString(9),
                            showoff_img_link_2 = reader.GetString(10),
                            showoff_img_link_3 = reader.GetString(11),
                            showoff_img_link_4 = reader.GetString(12),
                            showoff_img_link_5 = reader.GetString(13),
                            showoff_video_link_1 = reader.GetString(14),
                            showoff_video_link_2 = reader.GetString(15),
                            price = reader.GetDouble(16)
                        });
                    }
                }

                conn.Close();
            }

            return databaseOutput;
        }
    }
}
