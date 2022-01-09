using System;

namespace DIO.Series
{
    class Program
    {   
        
    
        static RepositorySerie repository = new RepositorySerie();

        static void Main(string[] args)
        {   
            string userOption = ObtainUserOptions();

            while (userOption.ToUpper() != "X")
            {
                switch (userOption)
                {
                    case "1":
                        ListingSeries();
                        break;
                    case "2":
                        InsertSeries();
                        break;
                    case "3":
                        UpdateSeries();
                        break;
                    case "4":
                        EraseSeries();
                        break;
                    case "5":
                        ViewSeries();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                userOption = ObtainUserOptions();

            }

            Console.WriteLine("Obrigado por usar vossos serviços :)");
            Console.ReadLine();
        }


        private static void EraseSeries()
        {
            Console.Write("Digite o id do matriculado que deseja remover:");
            int idSerie = int.Parse(Console.ReadLine());

            Console.Write("Está seguro disso? 1 para 'SIM' 0 para 'NAO'");
            int answ = int.Parse(Console.ReadLine());

            if (answ == 1) {
                repository.Erase(idSerie);
            }
            else 
            { 
                Console.Write("Removido");
            }
            //repository.Erase(idSerie);
            Console.Write("Concluído!");
        }

        private static void ViewSeries()
        {
            Console.WriteLine("Digite o id do matriculado: ");
            int idSerie =   int.Parse(Console.ReadLine());

            var serie = repository.ReturningById(idSerie);

            Console.WriteLine(serie);
        }

        private static void UpdateSeries()
        {
            Console.Write("Digite o id do matriculado: ");
            int idSerie = int.Parse(Console.ReadLine());


            foreach (int i in Enum.GetValues(typeof(Categories)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Categories), i));
            }
            Console.Write("Digite o tipo de matricula: ");
            int inputCategorie = int.Parse(Console.ReadLine());

            Console.Write("Digite o seu nome: ");
            string inputTitle = Console.ReadLine();

            Console.Write("Data de nascimento: ");
            int inputRelease = int.Parse(Console.ReadLine());

            Console.Write("CPF: ");
            string inputDescription = Console.ReadLine();

            Console.WriteLine("Endereço: ");
            string inputAddress = Console.ReadLine();

            Serie UpdateSeries = new Serie(id: idSerie,
                                        categories: (Categories)inputCategorie,
                                        title: inputTitle,
                                        year: inputRelease,
                                        description: inputDescription,
                                        address: inputAddress);
            
            repository.Update(idSerie, UpdateSeries);

        }

        private static void ListingSeries()
        {
            Console.WriteLine("Listando alunos(as)...");

            var listt = repository.Listing();

            if (listt.Count == 0)
            {
                Console.WriteLine("Nenhum matriculado.");
                return;
            }

            foreach (var serie in listt)
            {   
                var erased = serie.returnErased();
                
                Console.WriteLine("#ID {0}: - {1} - {2}", serie.returningId(), serie.returningTitle(), (erased ? "*Removido(a)-" : ""));
            }
        }

        private static void InsertSeries()
        {
            Console.WriteLine("Matricular novo(a) aluno(a)");

            foreach (int i in Enum.GetValues(typeof(Categories)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Categories), i));
            }

            Console.Write("Escolha o tipo de matricula: ");
            int inputCategorie = int.Parse(Console.ReadLine());

            Console.Write("Digite o seu nome: ");
            string inputTitle = Console.ReadLine();

            Console.Write("Data de nascimento: ");
            int year = int.Parse(Console.ReadLine());

            Console.Write("CPF: ");
            string inputDescription = Console.ReadLine();

            Console.WriteLine("Endereço: ");
            string inputAddress = Console.ReadLine();

            Serie newSerie = new Serie(id: repository.NextId(),
                                       categories: (Categories)inputCategorie,
                                       title: inputTitle,
                                       year: year,
                                       description: inputDescription,
                                       address: inputAddress);   

            repository.Insert(newSerie);
        }


        private static string ObtainUserOptions()
        {
            Console.WriteLine();
            Console.WriteLine("-----------------------------");
            Console.WriteLine("-=- Bem vindo(a) a academia da DIO -=-");
            Console.WriteLine("¨¨¨¨¨ O que deseja? ¨¨¨¨¨¨¨");
            Console.WriteLine("");
            
            Console.WriteLine("1 - Listar alunos(as)");
            Console.WriteLine("2 - Matricular novo(a) aluno(a)");
            Console.WriteLine("3 - Atualizar matricula");
            Console.WriteLine("4 - Deletar aluno");
            Console.WriteLine("5 - Visualizar matricula");
            Console.WriteLine("6 - Suspender matricula");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string userOption = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return userOption;
        }
    }
}
