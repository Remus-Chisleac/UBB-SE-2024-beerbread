using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using app.Data.ServerHandlers;

namespace app.src.SqlDataStorageAndRetrival
{
    public class SqlSongService
    {
        private List<Song> songs = [];
        Microsoft.Data.SqlClient.SqlConnection sqlconnection;
        public SqlSongService()
        {
            sqlconnection = StaticSqlConnectionGenerator.GetConnection();
        }

        public List<int> GetSongIds()
        {
            //todo optimise this
            List<int> result = new List<int>();
            sqlconnection.Open();
            Microsoft.Data.SqlClient.SqlCommand command = new("SELECT id FROM songs", sqlconnection);
            Microsoft.Data.SqlClient.SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                result.Add(reader.GetInt32("id"));
            }
            reader.Close();
            sqlconnection.Close();
            return result;
        }
        public List<Song> GetSongs()
        {
            //todo optimise this
            sqlconnection.Open();
            Microsoft.Data.SqlClient.SqlCommand command = new Microsoft.Data.SqlClient.SqlCommand("SELECT * FROM Songs", sqlconnection);
            Microsoft.Data.SqlClient.SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                songs.Add(new Song(int.Parse(reader.GetString("id")),
                    reader.GetString("songName"),
                    reader.GetString("artistName"),
                    reader.GetString("urlSong"),
                    reader.GetString("urlImage")));
            }
            reader.Close();
            sqlconnection.Close();
            return songs;
        }

        public List<Song> GetSongs(List<int> listId)
        {
            //todo optimise this
            List<Song> result = new List<Song>();
            string ids = "";
            foreach (int id in listId)
            {
                ids += id + ",";
            }

            sqlconnection.Open();
            Microsoft.Data.SqlClient.SqlCommand command = new("SELECT * FROM Songs WHERE id in (" + ids.Substring(0, ids.Length - 1) + ")", sqlconnection);
            Microsoft.Data.SqlClient.SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                result.Add(new Song(reader.GetInt32("id"),
                           reader.GetString("songName"),
                           reader.GetString("artistName"),
                           reader.GetString("urlSong"),
                           reader.GetString("urlImage")));
            }
            reader.Close();
            sqlconnection.Close();
            return result;
        }

        public List<int> GetSongIdsExcept(List<int> listId)
        {
            //todo optimise this
            List<int> result = new List<int>();
            string ids = "";
            foreach (int id in listId)
            {
                ids += id + ",";
            }

            sqlconnection.Open();
            Microsoft.Data.SqlClient.SqlCommand command = new("SELECT id FROM Songs WHERE id not in (" + ids + ")", sqlconnection);
            Microsoft.Data.SqlClient.SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                result.Add(int.Parse(reader.GetString("id")));
            }
            reader.Close();
            sqlconnection.Close();
            return result;
        }
        public List<Song> GetSongsExcept(List<int> listId)
        {
            //todo optimise this
            List<Song> result = new List<Song>();
            string ids = "";
            foreach (int id in listId)
            {
                ids += id + ",";
            }

            sqlconnection.Open();
            Microsoft.Data.SqlClient.SqlCommand command = new("SELECT * FROM Songs WHERE id not in (" + ids + ")", sqlconnection);
            Microsoft.Data.SqlClient.SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                result.Add(new Song(int.Parse(reader.GetString("id")),
                           reader.GetString("songName"),
                           reader.GetString("artistName"),
                           reader.GetString("urlSong"),
                           reader.GetString("urlImage")));
            }
            reader.Close();
            sqlconnection.Close();
            return result;
        }
    }
}
