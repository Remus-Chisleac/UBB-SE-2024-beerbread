using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.src.SqlDataStorageAndRetrival
{
    internal class SqlPlaylistService
    {
        private List<Playlist> playlists = [];
        Microsoft.Data.SqlClient.SqlConnection sqlconnection;
        public SqlPlaylistService()
        {
            sqlconnection = SqlConnectionGenerator.GetConnection();
        }

        public List<Playlist> GetPlaylists(Guid owner)
        {
            sqlconnection.Open();
            Microsoft.Data.SqlClient.SqlCommand command = new("SELECT * FROM Playlists where owner = (select id from accounts where guid='" + owner.ToString() + "')", sqlconnection);
            Microsoft.Data.SqlClient.SqlDataReader reader = command.ExecuteReader();
            var conn2 = new Microsoft.Data.SqlClient.SqlConnection(SqlConnectionGenerator.GetConnectionString());
            while (reader.Read())
            {
                conn2.Open();
                Microsoft.Data.SqlClient.SqlCommand command2 = new("Select urlImage from songs where id = (SELECT TOP 1 idSong FROM songs_in_playlist Where idPlaylist = " + reader.GetInt32("id") + ")", conn2);
                Microsoft.Data.SqlClient.SqlDataReader reader2 = command2.ExecuteReader();
                string imgpath = "";
                try
                {
                    reader2.Read();
                    imgpath = reader2.GetString("urlImage");
                }
                catch (Exception e)
                {
                    imgpath = "";
                }
                playlists.Add(new Playlist(reader.GetInt32("id"),
                                            reader.GetInt32("owner"),
                                            reader.GetString("name"),
                                            reader.GetBoolean("isPrivate"),
                                            imgpath));
                conn2.Close();
            }
            reader.Close();
            sqlconnection.Close();
            return playlists;
        }
        public List<Playlist> GetPlaylistsExcept(Guid owner, List<int> ids)
        {
            sqlconnection.Open();
            Microsoft.Data.SqlClient.SqlCommand command = new("SELECT * FROM Playlists WHERE id NOT IN (" + string.Join(",", ids) + ") and owner = (select id from accounts where guid='" + owner.ToString() + "'", sqlconnection);
            Microsoft.Data.SqlClient.SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Microsoft.Data.SqlClient.SqlCommand command2 = new("Select urlImage from songs where id = (SELECT TOP 1 idSong FROM songs_in_playlist Where idPlaylist = " + reader.GetInt32("id") + ")", sqlconnection);
                Microsoft.Data.SqlClient.SqlDataReader reader2 = command2.ExecuteReader();
                string imgpath = "";
                try
                {
                    reader2.Read();
                    imgpath = reader2.GetString("urlImage");
                }
                catch (Exception e)
                {
                    imgpath = "";
                }
                playlists.Add(new Playlist(reader.GetInt32("id"),
                                            reader.GetInt32("owner"),
                                            reader.GetString("name"),
                                            reader.GetBoolean("isPrivate"),
                                            imgpath));
            }
            reader.Close();
            sqlconnection.Close();
            return playlists;
        }
        public Playlist GetPlaylist(int id)
        {
            sqlconnection.Open();
            Microsoft.Data.SqlClient.SqlCommand command = new("SELECT * FROM Playlists WHERE id = " + id, sqlconnection);
            Microsoft.Data.SqlClient.SqlDataReader reader = command.ExecuteReader();

            Microsoft.Data.SqlClient.SqlCommand command2 = new("Select urlImage from songs where id = (SELECT TOP 1 idSong FROM songs_in_playlist Where idPlaylist = " + reader.GetInt32("id") + ")", sqlconnection);
            Microsoft.Data.SqlClient.SqlDataReader reader2 = command.ExecuteReader();
            string imgpath = "";
            try
            {
                reader2.Read();
                imgpath = reader2.GetString("urlImage");
            }
            catch (Exception e)
            {
                imgpath = "";
            }
            reader.Read();
            Playlist playlist = new Playlist(reader.GetInt32("id"),
                                        reader.GetInt32("owner"),
                                        reader.GetString("name"),
                                        reader.GetBoolean("isPrivate"),
                                        imgpath);
            reader.Close();
            sqlconnection.Close();
            return playlist;
        }

        public bool AddPlaylist(Playlist playlist, Guid owner)
        {
            sqlconnection.Open();
            int isPrivate = 0;
            if (playlist.IsPrivate)
            {
                isPrivate = 1;
            }
            Microsoft.Data.SqlClient.SqlCommand command = new(
                "INSERT INTO Playlists (owner, name, isPrivate) " +
                "VALUES ((select id from accounts where guid='" + owner.ToString() + "'), '" +
                playlist.Name + "', " + isPrivate + ")", sqlconnection);
            command.ExecuteNonQuery();
            sqlconnection.Close();
            return true;
        }
    }
}
