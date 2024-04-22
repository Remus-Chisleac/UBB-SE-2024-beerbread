namespace app.Data.SqlCommandHandlers
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics;
    using System.Text;
    using app.Data.ServerHandlers;
    using Microsoft.Data.SqlClient;

    public interface ISqlSongTableCommandExecutor
    {
        List<int> GetAllSongIdsInDatabase();

        List<Song> GetSongsWithIds(List<int> songIds);
    }

    internal class SqlSongTableCommandExecutor : SqlCommandExecutor, ISqlSongTableCommandExecutor
    {
        private readonly SqlConnection currentSqlConnection;

        public SqlSongTableCommandExecutor()
        {
            this.currentSqlConnection = StaticSqlConnectionGenerator.GetConnection();
        }

        public List<int> GetAllSongIdsInDatabase()
        {

            List<int> allSongIds = new List<int>();
            try
            {
                this.currentSqlConnection.Open();
                SqlCommand command = new ("SELECT id FROM songs", this.currentSqlConnection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    allSongIds.Add(reader.GetInt32("id"));
                }

                reader.Close();
                this.currentSqlConnection.Close();
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }

            return allSongIds;
        }

        public List<Song> GetSongsWithIds(List<int> songIds)
        {
            List<Song> songs = new List<Song>();
            try
            {
                this.currentSqlConnection.Open();
                string stringIds = string.Empty;
                foreach (int id in songIds)
                {
                    stringIds += id + ",";
                }

                SqlCommand command = new ("SELECT * FROM Songs WHERE id in (" + stringIds.Substring(0, stringIds.Length - 1) + ")", this.currentSqlConnection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    songs.Add(new Song(
                               reader.GetInt32("id"),
                               reader.GetString("songName"),
                               reader.GetString("artistName"),
                               reader.GetString("urlSong"),
                               reader.GetString("urlImage")));
                }

                reader.Close();
                this.currentSqlConnection.Close();
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }

            return songs;
        }
    }
}
