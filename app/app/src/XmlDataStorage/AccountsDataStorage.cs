using app;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

internal class AccountsXmlDataStorage
{
	//Predefined file, containing the accounts
	public string filePath = "embed://XMLDataStorageAccounts.xml";
	List<Account> accounts = new List<Account>();
	
	// Serialize list of accounts to XML file
	public void SaveAccounts(List<Account> accounts)
	{
		XmlSerializer serializer = new XmlSerializer(typeof(List<Account>));
		Device.BeginInvokeOnMainThread(async () =>
        {
            await LoadAccounts();
        });
	}

    // Deserialize list of accounts from XML file
    public async Task<List<Account>> LoadAccounts()
    {
        string mainDir = FileSystem.Current.AppDataDirectory;
        var fullpath = Path.Combine(mainDir, "XMLDataStorageAccounts.xml");
        XmlSerializer serializer = new XmlSerializer(typeof(List<Account>));
        try
        {
            Stream fileStream = await FileSystem.Current.OpenAppPackageFileAsync("XMLDataStorageAccounts.xml");
            StreamReader reader = new StreamReader(fileStream);

            accounts = (List<Account>)serializer.Deserialize(reader);
        }
        catch (Exception e)
        {
            var i = 1;
            return [];
        }
        return accounts;

    }
	// Check if an account with the given username exists
	public bool AccountExistsByUsername(string username)
	{
        Device.BeginInvokeOnMainThread(async () =>
        {
            await LoadAccounts();
        });
        return accounts.Any(account => account.Username == username);
	}

	// Check if an account with the given email exists
	public bool AccountExistsByEmail(string email)
	{
        Device.BeginInvokeOnMainThread(async () =>
        {
            await LoadAccounts();
        });
        return accounts.Any(account => account.Email == email);
	}


}