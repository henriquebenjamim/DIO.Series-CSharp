using System;

namespace DIO.Series
{   

    public class Serie : BaseEntities
    {
        // Attributes 
        private Categories Categories { get; set; }
        private string Title { get; set; }
        private string Description { get; set; }
        private int Year { get; set; }
        private bool Erased {get; set;}

        private string Address { get; set; }

        // Methods 
        public Serie(int id, Categories categories, string title, string description, int year, string address)
        {
            this.Id = id; 
            this.Categories = categories;
            this.Title = title;
            this.Description = description;
            this.Year = year;
            this.Erased = false;
            this.Address = address;
        }
        
        // To String 

        public override string ToString()
        {
            
            // string returning = System.Console.WriteLine($"Categorie: {this.Categorie} \r\n Title: {this.Title} \r\n Description: {this.Description} \r\n Start Year: {this.Year} \r\n Erased: {this.Erased}");
            string returning = "";
            returning += $"Categorie: {this.Categories}\r\n"; 
            returning += $"Title: {this.Title}\r\n";
            returning += $"Description: {this.Description}\r\n";
            returning += $"Start Year: {this.Year}\r\n";
            returning += $"Erased: {this.Erased}\r\n";
            return returning;
        }

        // Encapsulating 

        public string returningTitle()
        {
            return this.Title;
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