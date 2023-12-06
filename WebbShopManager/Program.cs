using WebbShopManager.Views;
using WebbShopManager.Repositry;
using WebbShopManager.Entities;
class Program
{
    static void Main(string[] args)
    {
        UserInterface userInterface = new UserInterface();

        List<Advertisement> advertisements = AdvertisementRepo.SearchForAdvertisement();

        Console.WriteLine("List of Advertisements:");
        foreach (var ad in advertisements)
        {
            Console.WriteLine($"ID: {ad.AdvertisementID}, Title: {ad.Title}, Description: {ad.DescriptionColumn}, {ad.Price}");
            // Add more properties as needed
        }

        //userInterface.ViewMainMenu();     
        //userInterface.ViewSearchMeny();
    }
}