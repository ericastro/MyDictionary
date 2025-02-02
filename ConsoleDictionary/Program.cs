
namespace ConsoleDictionary
{
    public class Program
    {
        private static void Main()
        {
            ScreenMenu menu = new();
            
            do {
                menu.MainMenuCreate();
            } while (menu.Exit == 'N');

            menu.PressAnyKey("Programa encerrado com exito!");
        }
    }
}
