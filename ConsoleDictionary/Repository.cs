using System.Diagnostics;

namespace ConsoleDictionary
{
    public class Repository
    {
        public int LastKey;
        private object myDictionary;

        public int lastKey
        {
            get => lastKey;
            set
            {
                if (value > 0)
                {
                    lastKey = value;
                }
                else
                {
                    lastKey = 0;
                }
            }
        }

        public Dictionary<int,string> MyDictionary
        {
            get
            {
                if (myDictionary is null)
                {
                    myDictionary = [];
                }
                return myDictionary;
            }    
            set
            {
                if (value is not null)
                {
                    myDictionary = value;
                }
                if (myDictionary is null)
                {
                    myDictionary = [];
                }
            }

        }

        public string DictionaryValuesShow()
        {
            Console.Clear();
            Console.WriteLine("Estes são os Valores armazenados no dicionário : ");

            if (MyDictionary is null)
            {
                return "O Dicionário esta com valor nulo a aplicação não pode processeguir";
            }

            foreach (var item in MyDictionary)
            {
                Console.WriteLine($"{item.Key} => {item.Value}");
            }

            return "Pressione uma tecla para continuar";
        }

        public string GetValueById()
        {
            Console.Clear();
            Console.WriteLine("Digite a chave a ser pesquisada : ");
            int key = Convert.ToInt16(Console.ReadLine());

            if (MyDictionary is null)
            {
                return "O Dicionário esta com valor nulo a aplicação não pode processeguir";
            }

            if (MyDictionary.TryGetValue(key, out string? value))
            {
                Console.WriteLine(key + " => " + value);
            }
            else
            {
                Console.WriteLine("Dicionário não contém a chave digitada!");
            }
            return "";
        }
    }
}
