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
                        ListingPeople();
                        break;
                    case "2":
                        InsertPeople();
                        break;
                    case "3":
                        UpdateInformation();
                        break;
                    case "4":
                        ErasePerson();
                        break;
                    case "5":
                        ViewPerson();
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


        private static void ErasePerson()
        {
            Console.Write("Digite o id do matriculado que deseja remover:");
            int idPerson = int.Parse(Console.ReadLine());

            Console.Write("Está seguro disso? 1 para 'SIM' 0 para 'NAO'");
            int answ = int.Parse(Console.ReadLine());

            if (answ == 1) {
                repository.Erase(idPerson);
            }
            else 
            { 
                Console.Write("Removido");
            }
            //repository.Erase(idSerie);
            Console.Write("Concluído!");
        }

        private static void ViewPerson()
        {
            Console.WriteLine("Digite o id do matriculado: ");
            int idPerson =   int.Parse(Console.ReadLine());

            var person = repository.ReturningById(idPerson);

            Console.WriteLine(person);
        }

        private static void UpdateInformation()
        {
            Console.Write("Digite o id do matriculado: ");
            int idPerson = int.Parse(Console.ReadLine());


            foreach (int i in Enum.GetValues(typeof(Categories)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Categories), i));
            }
            Console.Write("Digite o tipo de matricula: ");
            int inputCategorie = int.Parse(Console.ReadLine());

            Console.Write("Digite o seu nome: ");
            string inputName = Console.ReadLine();

            Console.Write("Data de nascimento: ");
            string birthdayYear = Console.ReadLine();

            Console.Write("CPF: ");
            string inputPPC = Console.ReadLine();

            Console.WriteLine("Endereço: ");
            string inputAddress = Console.ReadLine();

            Serie UpdateInformation = new Serie(id: idPerson,
                                        categories: (Categories)inputCategorie,
                                        title: inputName,
                                        year: birthdayYear,
                                        description: inputPPC,
                                        address: inputAddress);
            
            repository.Update(idPerson, UpdateInformation);

        }

        private static void ListingPeople()
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

        private static void InsertPeople()
        {
            Console.WriteLine("Matricular novo(a) aluno(a)");

            foreach (int i in Enum.GetValues(typeof(Categories)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Categories), i));
            }

            Console.Write("Escolha o tipo de matricula: ");
            int inputCategorie = int.Parse(Console.ReadLine());

            Console.Write("Digite o seu nome: ");
            string inputName = Console.ReadLine();

            Console.Write("Data de nascimento: ");
            string birthdayDate = Console.ReadLine();

            Console.Write("CPF: ");
            string inputPPC = Console.ReadLine();

            Console.WriteLine("Endereço: ");
            string inputAddress = Console.ReadLine();

            Serie newSerie = new Serie(id: repository.NextId(),
                                       categories: (Categories)inputCategorie,
                                       title: inputName,
                                       year: birthdayDate,
                                       description: inputPPC,
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
