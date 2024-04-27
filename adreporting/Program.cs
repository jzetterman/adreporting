// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

using System.ComponentModel.DataAnnotations;
using System.Reflection.PortableExecutable;
using System.DirectoryServices.AccountManagement;

DirectoryEntry directoryEntry = new DirectoryEntry("LDAP://ua.ad.alaska.edu");
DirectorySearcher searcher = new DirectorySearcher(directoryEntry) {
    PageSize = int.MaxValue,
    FilterUIHintAttribute = "(&(objectCategory=person))"
}

searcher.PropertiesToLoad.Add("sn");

var result = searcher.FindOne();

if (result == null) {
    return;
}

string surname;

if (result.Properties.Contains("sn")) {
    surname = result.Properties["sn"][0].ToString();
    Console.WriteLine(surname);
} else {
    Console.WriteLine("No user found!");
}