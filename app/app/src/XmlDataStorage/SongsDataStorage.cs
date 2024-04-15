using System.Collections.Generic;
using System.IO;
using System.Linq;

public class SongsXmlDataStorage
{
    public string filePath = "";
    //Serialize Songs to the Xml file
    public static void SaveSongs(List<Song> songs)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(List<Song>));
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            serializer.Serialize(writer, songs);
        }
    }
    //Deserialize Songs from Xml file
    public static List<Song> LoadSongs()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(List<Song>));
        using (StreamReader reader = new StreamReader(filePath))
        {
            return (List<Song>)serializer.Deserialize(reader);
        }
    }
    //Returning a song by it's name
    public static Song SearchSong(string songName)
    {
        List<Song> songs = LoadSongs();
        return songs.Any(song => song.name == songName);
    }
}