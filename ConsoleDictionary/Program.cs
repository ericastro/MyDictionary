
namespace ConsoleDictionary
{
    public class Program
    {
        public int LastKey { get; set; }
        public char Exit { get; set; }
        public Dictionary<int,string>? MyDictionary { get; set; }

        private static void Main()
        {
            Program prog = new()
            {
                MyDictionary = [],
                LastKey = 0,
                Exit = 'N'
            };

            do {
                prog.MainMenuCreate();
            } while (prog.Exit == 'N');

            Console.Clear();
            Console.WriteLine("Programa encerrado com exito!");
            return;
        }

        public void ChoiceOption()
        {
            string? option = Console.ReadLine();

            if ( Int32.TryParse(option, out int result) )
            {
                PressAnyKey("Você digitou uma opção inválida!");
                return;
            }

            switch (result)
            {
                case 1:
                    ValueAdd();
                    break;
                case 2:
                    GetValueById();
                    break;
                case 3:
                    DictionaryValuesShow();
                    break;
                case 4:
                    ClearDictionary();
                    break;
                case 5:
                    Exit = 'S';
                    break;
                default:
                    PressAnyKey("Você digitou uma opção que não existe no menu.");
                    break;
            }
        }

        public void MainMenuCreate()
        {
            Console.Clear();
            Console.WriteLine(" ** O que deseja fazer com seu dicionário? **" );
            Console.WriteLine(" 1 - Adcionar um novo valor : ");
            Console.WriteLine(" 2 - Retornar valor pela chave : ");
            Console.WriteLine(" 3 - Mostrar os valores gravados no dicionário : ");
            Console.WriteLine(" 4 - Limpar os valores do dicionário : ");
            Console.WriteLine(" 5 - Para sair do programa!");
            ChoiceOption();
        }

        private void ClearDictionary()
        {
            if (MyDictionary is null)
            {
                PressAnyKey("O Dicionário esta com valor nulo a aplicação não pode processeguir");
                return;
            }

            Console.Clear();
            Console.WriteLine("Tem certeza que deseja limpar os valores do dicionário? Digite : (S/N)");
            string? option = Console.ReadLine();

            if (option != "S")
            {
                if( option == "N")
                {
                    PressAnyKey("Você não quis apagar os valores do dicionário.");
                    return;
                }

                PressAnyKey("Você digitou um valor inválido!, Digite (S ou N)");
                return;
            }

            if (option.CompareTo("S") == 0)
            {
                MyDictionary.Clear();
                PressAnyKey("Valores do Dicinário excluidos com sucesso");
                return;
            }

            if (MyDictionary is null)
            {
                PressAnyKey("O Dicionário esta com valor nulo a aplicação não pode processeguir");
                return;
            }
        }

        public void ValueAdd()
        {
            Console.Clear();
            Console.Write("Qual o valor você vai adcionar : ");
            string? value = Console.ReadLine();

            if (value is null)
            {
                PressAnyKey("Um valor nulo não é válido, Operação Encerrada sem incluir o novo valor");
                return;
            }

            if (MyDictionary is null)
            {
                PressAnyKey("O Dicionário esta com valor nulo a aplicação não pode processeguir");
                return;
            }


            MyDictionary.Add(LastKey,value);
            LastKey++;
            PressAnyKey("Valor Adcionado com sucesso!");
        }

        public void DictionaryValuesShow()
        {
            Console.Clear();
            Console.WriteLine("Estes são os Valores armazenados no dicionário : ");

            if (MyDictionary is null)
            {
                PressAnyKey("O Dicionário esta com valor nulo a aplicação não pode processeguir");
                return;
            }

            foreach (var item in MyDictionary)
            {
                Console.WriteLine($"{item.Key} => {item.Value}");
            }

            Console.WriteLine("\nPressione uma tecla para continuar");
            Console.ReadKey();
        }

        public void GetValueById()
        {
            Console.Clear();
            Console.WriteLine("Digite a chave a ser pesquisada : ");
            int key = Convert.ToInt16( Console.ReadLine() );

            if (MyDictionary is null)
            {
                PressAnyKey("O Dicionário esta com valor nulo a aplicação não pode processeguir");
                return;
            }

            if (MyDictionary.TryGetValue(key, out string? value))
            {
                Console.WriteLine(key + " => " + value);
            }
            else
            {
                Console.WriteLine("Dicionário não contém a chave digitada!");
            }
            Console.WriteLine("Pressione uma tecla para continuar");
            Console.ReadKey();
        }

        private void PressAnyKey(string msg)
        {
            Console.Clear();
            Console.WriteLine(msg);
            Console.WriteLine("Pressione uma tecla para continuar");
            Console.ReadKey();
        }
    }
}
