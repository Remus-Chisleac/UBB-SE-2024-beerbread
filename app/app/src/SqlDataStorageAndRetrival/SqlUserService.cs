namespace app.src.SqlDataStorageAndRetrival
{
    using System.Collections.Generic;
    using System.Data;
    using System.Text;
    using app.Data.ServerHandlers;
    using app.Interfaces;

    public class SqlUserService : ISqlUserService
    {
        private readonly Microsoft.Data.SqlClient.SqlConnection sqlConnection;

        public SqlUserService()
        {
            this.sqlConnection = StaticSqlConnectionGenerator.GetConnection();
        }

        public SqlUserService(Microsoft.Data.SqlClient.SqlConnection sqlConnection)
        {
            this.sqlConnection = sqlConnection;
        }

        public List<IPlaylist> GetPlaylists(int id)
        {
            List<IPlaylist> playlists = new List<IPlaylist>();
            this.sqlConnection.Open();
            Microsoft.Data.SqlClient.SqlCommand command = new ("select * from playlists where id = (select historyPlaylist from users where id=" + id + ")", this.sqlConnection);
            Microsoft.Data.SqlClient.SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            IPlaylist historyPlaylist = new Playlist(
                int.Parse(reader.GetString("id")),
                int.Parse(reader.GetString("owner")),
                reader.GetString("name"),
                reader.GetBoolean("isPrivate"));
            playlists.Add(historyPlaylist);

            command = new ("select * from playlists where id = (select likedPlaylist from users where id=" + id + ")", this.sqlConnection);
            reader = command.ExecuteReader();
            reader.Read();
            IPlaylist likedPlaylist = new Playlist(
                int.Parse(reader.GetString("id")),
                int.Parse(reader.GetString("owner")),
                reader.GetString("name"),
                reader.GetBoolean("isPrivate"));
            playlists.Add(likedPlaylist);
            command = new ("select * from playlists where id = (select blockedplaylist from users where id=" + id + ")", this.sqlConnection);
            reader = command.ExecuteReader();

            reader.Read();
            IPlaylist blockedPlaylist = new Playlist(
                int.Parse(reader.GetString("id")),
                int.Parse(reader.GetString("owner")),
                reader.GetString("name"),
                reader.GetBoolean("isPrivate"));

            playlists.Add(blockedPlaylist);

            command = new ("select * from playlists where owner=" + id + " and id not in(" + historyPlaylist.Id + "," + likedPlaylist.Id + "," + blockedPlaylist.Id + ")", this.sqlConnection);

            reader = command.ExecuteReader();
            while (reader.Read())
            {
                playlists.Add(new Playlist(
                    int.Parse(reader.GetString("id")),
                    int.Parse(reader.GetString("owner")),
                    reader.GetString("name"),
                    reader.GetBoolean("isPrivate")));
            }

            reader.Close();
            this.sqlConnection.Close();
            return playlists;
        }
    }
}
