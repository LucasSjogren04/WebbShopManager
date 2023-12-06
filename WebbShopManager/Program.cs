using WebbShopManager.Views;
class Program
{
    static void Main(string[] args)
    {
        UserInterface userInterface = new UserInterface();

        userInterface.ViewMainMenu();     
        userInterface.ViewSearchMeny();
    }
}