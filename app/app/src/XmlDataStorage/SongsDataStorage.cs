using app;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

internal class SongsXmlDataStorage
{
    public static string filePath = "D:\\ISS\\Project\\app\\app\\XMLDataStorageSongs.xml";
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
        return songs.FirstOrDefault(song => song.name == songName);
    }
    //Removing a song by it's id
    public static bool RemoveSong(int id)
    {
        List<Song> songs = LoadSongs();
        Song songToRemove = songs.FirstOrDefault(song => song.id == id);
        if (songToRemove != null)
        {
            songs.Remove(songToRemove);
            SaveSongs(songs);
            return true; 
        }
        else
        {
            return false;
        }
    }
}