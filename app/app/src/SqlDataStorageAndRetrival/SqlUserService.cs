using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.src.SqlDataStorageAndRetrival
{
    public class SqlUserService
    {
        Microsoft.Data.SqlClient.SqlConnection sqlconnection;
        public SqlUserService()
        {
            sqlconnection = SqlConnection.GetConnection();
        }

        public List<Playlist> GetPlaylists(int id)
        {
            List<Playlist> playlists = new List<Playlist>();
            sqlconnection.Open();
            Microsoft.Data.SqlClient.SqlCommand command = new("select * from playlists where id = (select historyPlaylist from users where id=" + id + ")", sqlconnection);
            Microsoft.Data.SqlClient.SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            Playlist historyPlaylist = new Playlist(int.Parse(reader.GetString("id")),
                                               int.Parse(reader.GetString("owner")),
                                               reader.GetString("name"),
                                               reader.GetBoolean("isPrivate"));
            playlists.Add(historyPlaylist);

            command = new("select * from playlists where id = (select likedPlaylist from users where id=" + id + ")", sqlconnection);
            reader = command.ExecuteReader();
            reader.Read();
            Playlist likedPlaylist = new Playlist(int.Parse(reader.GetString("id")),
                                                  int.Parse(reader.GetString("owner")),
                                                  reader.GetString("name"),
                                                  reader.GetBoolean("isPrivate"));
            playlists.Add(likedPlaylist);
            command = new("select * from playlists where id = (select blockedplaylist from users where id=" + id + ")", sqlconnection);
            reader = command.ExecuteReader();

            reader.Read();
            Playlist blockedPlaylist = new Playlist(int.Parse(reader.GetString("id")),
                                                    int.Parse(reader.GetString("owner")),
                                                    reader.GetString("name"),
                                                    reader.GetBoolean("isPrivate"));

            playlists.Add(blockedPlaylist);

            command = new("select * from playlists where owner=" + id + " and id not in(" + historyPlaylist.id + "," + likedPlaylist.id + "," + blockedPlaylist.id + ")", sqlconnection);

            reader = command.ExecuteReader();
            while (reader.Read())
            {
                playlists.Add(new Playlist(int.Parse(reader.GetString("id")),
                                           int.Parse(reader.GetString("owner")),
                                           reader.GetString("name"),
                                           reader.GetBoolean("isPrivate")));
            }



            reader.Close();
            sqlconnection.Close();
            return playlists;
        }
    }
}
