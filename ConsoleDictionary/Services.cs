
using System.Security.Cryptography.X509Certificates;

namespace ConsoleDictionary
{
    public class Services
    {
        public Repository Repo = new();

        public string ClearDictionary()
        {
            try
            {
                if (Repo.myDictionary is null)
                {
                    return "O Dicionário esta com valor nulo a aplicação não pode processeguir";
                }
            }
            catch (Exception)
            {
                throw;
            }


            Console.Clear();
            Console.WriteLine("Tem certeza que deseja limpar os valores do dicionário? Digite : (S/N)");
            string? option = Console.ReadLine();

            if (option != "S")
            {
                if (option == "N")
                {
                    return "Você não quis apagar os valores do dicionário.";
                }

                return "Você digitou um valor inválido!, Digite (S ou N)";
            }

            if (Repo.MyDictionary is null)
            {
                return "O Dicionário esta com valor nulo a aplicação não pode processeguir";
            }

            if (option.CompareTo("S") == 0)
            {
                Repo.MyDictionary.Clear();
                return "Valores do Dicinário excluidos com sucesso";
            }
            else
            {
                return "";
            }
        }

        public string ValueAdd()
        {
            Console.Clear();
            Console.Write("Qual o valor você vai adcionar : ");
            string? value = Console.ReadLine();

            if (value is null)
            {
                return "Um valor nulo não é válido, Operação Encerrada sem incluir o novo valor";
            }

            try
            {
                if (Repo.myDictionary is null)
                {
                    return "O Dicionário esta com valor nulo a aplicação não pode processeguir";
                }
            }
            catch (Exception)
            {
                throw;
            }



            Repo.MyDictionary.Add(Repo.LastKey, value);
            Repo.LastKey++;
            return "Valor Adcionado com sucesso!";
        }
    }
}
