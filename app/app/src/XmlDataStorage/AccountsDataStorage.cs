using app;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

internal class AccountsXmlDataStorage
{
    public static string GetFilePath()
    {
        string fileName = "XMLDataStorageAccounts.xml";
        switch (Device.RuntimePlatform)
        {
            case Device.Android:
                return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), fileName);
            case Device.iOS:
                return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "..", "Library", fileName);
            case Device.UWP:
                return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), fileName);
            default:
                throw new NotImplementedException("Platform not supported");
        }
    }
    //Predefined file, containing the accounts
    public static string filePath = GetFilePath();

	// Serialize list of accounts to XML file
	public static void SaveAccounts(List<Account> accounts)
	{
		XmlSerializer serializer = new XmlSerializer(typeof(List<Account>));
		using (StreamWriter writer = new StreamWriter(filePath))
		{
			serializer.Serialize(writer, accounts);
		}
	}

	// Deserialize list of accounts from XML file
	public static List<Account> LoadAccounts()
	{
		XmlSerializer serializer = new XmlSerializer(typeof(List<Account>));
		using (StreamReader reader = new StreamReader(filePath))
		{
			return (List<Account>)serializer.Deserialize(reader);
		}
	}
	// Check if an account with the given username exists
	public static bool AccountExistsByUsername(string username)
	{
		List<Account> accounts = LoadAccounts();
		return accounts.Any(account => account.Username == username);
	}

	// Check if an account with the given email exists
	public static bool AccountExistsByEmail(string email)
	{
		List<Account> accounts = LoadAccounts();
		return accounts.Any(account => account.Email == email);
	}
}