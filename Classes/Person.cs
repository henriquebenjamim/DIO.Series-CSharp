using System;

namespace DIO.Series
{   

    public class Person : BaseEntities
    {
        // Atributos
        private Categories Categories { get; set; }
        private string Name { get; set; }
        private string CPF { get; set; }
        private string BirthdayYear { get; set; }

        private bool Erased {get; set;}

        private string Address { get; set; }

        // Methods 
        public Person(int id, Categories categories, string name, string cpf, string birthdayYear, string address)
        {
            this.Id = id; 
            this.Categories = categories;
            this.Name = name;
            this.CPF = cpf;
            this.BirthdayYear = birthdayYear;
            this.Erased = false;
            this.Address = address;
        }
        
        // Método To String 

        public override string ToString()
        { 
            string returning = "";
            returning += $"Categoria: {this.Categories}\r\n"; 
            returning += $"Nome: {this.Name}\r\n";
            returning += $"CPF: {this.CPF}\r\n";
            returning += $"Data Nascimento: {this.BirthdayYear}\r\n";
            returning += $"Endereço: {this.Address}\r\n";
            returning += $"Erased: {this.Erased}\r\n";
            return returning;
        }

        // Encapsulando

        public string returningName()
        {
            return this.Name;
        }

        public int returningId()
        {
            return this.Id;
        }

        public bool returnErased()
        {
            return this.Erased;
        }

        public void Erase() {
            this.Erased = true;
        }
    }
}