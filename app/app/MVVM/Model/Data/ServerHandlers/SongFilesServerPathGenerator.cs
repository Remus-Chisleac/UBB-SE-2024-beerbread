namespace app.MVVM.Model.Data.ServerHandlers
{
    public class SongFilesServerPathGenerator
    {
        private static string protocol = "http://";
        private static string ip = "188.24.47.96";
        private static string port = "1444";
        private static string mp3FilePath = "/api/source/mp3";
        private static string pngFilePath = "/api/source/png";

        public static string GetMp3Path()
        {
            return protocol + ip + ":" + port + mp3FilePath;
        }
        public static string GetPngPath()
        {
            return protocol + ip + ":" + port + pngFilePath;
        }
    }
}
