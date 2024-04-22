namespace app.Data.SqlCommandHandlers
{
    using System;
    using System.Data;
    using System.Diagnostics;
    using System.Text;
    using app.Data.ServerHandlers;
    using app.Interfaces;
    using Microsoft.Data.SqlClient;

    public interface ISqlUserTableCommandExecutor
    {
        bool ExecuteNonQueryCommandFromString(string query);

        IPlaylist? GetHistoryPlaylistForUserWithId(int userId);

        IPlaylist? GetLikedPlaylistForUserWithId(int userId);

        IPlaylist? GetBlockedPlaylistForUserWithId(int userId);

        List<IPlaylist> GetUserDefinedPlaylistsForUserWithId(int userId, int historyPlaylistId, int likedPlaylistId, int blockedPlaylistId);
    }

    internal class SqlUserTableCommandExecutor : SqlCommandExecutor, ISqlUserTableCommandExecutor
    {
        private readonly SqlConnection currentSqlConnection;

        public SqlUserTableCommandExecutor()
        {
            this.currentSqlConnection = StaticSqlConnectionGenerator.GetConnection();
        }

        public IPlaylist? GetBlockedPlaylistForUserWithId(int userId)
        {
            try
            {
                this.currentSqlConnection.Open();
                SqlCommand command = new ("select * from playlists where id = (select likedPlaylist from users where id=" + userId + ")", this.currentSqlConnection);
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                IPlaylist likedPlaylist = new Playlist(
                    int.Parse(reader.GetString("id")),
                    int.Parse(reader.GetString("owner")),
                    reader.GetString("name"),
                    reader.GetBoolean("isPrivate"));
                reader.Close();
                this.currentSqlConnection.Close();
                return likedPlaylist;
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
                return null;
            }
        }

        public IPlaylist? GetHistoryPlaylistForUserWithId(int userId)
        {

            try
            {
                this.currentSqlConnection.Open();
                SqlCommand command = new ("select * from playlists where id = (select historyPlaylist from users where id=" + userId + ")", this.currentSqlConnection);
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                IPlaylist historyPlaylist = new Playlist(
                    int.Parse(reader.GetString("id")),
                    int.Parse(reader.GetString("owner")),
                    reader.GetString("name"),
                    reader.GetBoolean("isPrivate"));
                reader.Close();
                this.currentSqlConnection.Close();
                return historyPlaylist;
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
                return null;
            }
        }

        public IPlaylist? GetLikedPlaylistForUserWithId(int userId)
        {
            try
            {
                this.currentSqlConnection.Open();
                SqlCommand command = new ("select * from playlists where id = (select blockedplaylist from users where id=" + userId + ")", this.currentSqlConnection);
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                IPlaylist blockedPlaylist = new Playlist(
                    int.Parse(reader.GetString("id")),
                    int.Parse(reader.GetString("owner")),
                    reader.GetString("name"),
                    reader.GetBoolean("isPrivate"));
                reader.Close();
                this.currentSqlConnection.Close();
                return blockedPlaylist;
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
                return null;
            }
        }

        public List<IPlaylist> GetUserDefinedPlaylistsForUserWithId(int userId, int historyPlaylistId, int likedPlaylistId, int blockedPlaylistId)
        {
            List<IPlaylist> userDefinedPlaylists = [];
            try
            {
                this.currentSqlConnection.Open();
                SqlCommand command = new ("select * from playlists where owner=" + userId + " and id not in(" + historyPlaylistId + "," + likedPlaylistId + "," + blockedPlaylistId + ")", this.currentSqlConnection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    userDefinedPlaylists.Add(new Playlist(
                        int.Parse(reader.GetString("id")),
                        int.Parse(reader.GetString("owner")),
                        reader.GetString("name"),
                        reader.GetBoolean("isPrivate")));
                }

                reader.Close();
                this.currentSqlConnection.Close();
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }

            return userDefinedPlaylists;
        }
    }
}
