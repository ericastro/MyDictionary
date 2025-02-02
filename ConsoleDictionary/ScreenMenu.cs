namespace ConsoleDictionary
{
    public class ScreenMenu
    {
        public char Exit { get; set; } = 'N';
        public const int MajorOptionMenu = 5;
        public void MainMenuCreate()
        {
            Console.Clear();
            Console.WriteLine(" ** O que deseja fazer com seu dicionário? **");
            Console.WriteLine(" 1 - Adcionar um novo valor : ");
            Console.WriteLine(" 2 - Retornar valor pela chave : ");
            Console.WriteLine(" 3 - Mostrar os valores gravados no dicionário : ");
            Console.WriteLine(" 4 - Limpar os valores do dicionário : ");
            Console.WriteLine(" 5 - Para sair do programa!");
            ChoiceOption();
        }
        public void ChoiceOption()
        {
            Services services = new Services();
            Repository repo = new Repository();
            string? option = Console.ReadLine();

            if (Int32.TryParse(option, out int result))
            {
                if (result < 1 || result > MajorOptionMenu)
                {
                    PressAnyKey("Você digitou uma opção inválida!");
                    return;
                }

                switch (result)
                {
                    case 1:
                        PressAnyKey(services.ValueAdd());
                        break;
                    case 2:
                        PressAnyKey(repo.GetValueById());
                        break;
                    case 3:
                        PressAnyKey(repo.DictionaryValuesShow(), false);
                        break;
                    case 4:
                        PressAnyKey(services.ClearDictionary());
                        break;
                    case 5:
                        Exit = 'S';
                        break;
                    default:
                        PressAnyKey("Você digitou uma opção que não existe no menu.");
                        break;
                }
            }
        }

        public void PressAnyKey(string msg, bool clear = true)
        {
            if (clear)
            {
                Console.Clear();
                Console.WriteLine(msg);
            }
            Console.WriteLine("Pressione uma tecla para continuar");
            Console.ReadKey();
        }

    }
}