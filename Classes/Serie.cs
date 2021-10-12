using System;

namespace DIO.Series
{   
    // Serie herdando do BaseEntities
    public class Serie : BaseEntities
    {
        // Attributes 
        private Genre Genre { get; set; }
        private string Title { get; set; }
        private string Description { get; set; }
        private int Year { get; set; }
        private bool Erased {get; set;}

        // Methods 
        public Serie(int id, Genre genre, string title, string description, int year)
        {
            this.Id = id; 
            this.Genre = genre;
            this.Title = title;
            this.Description = description;
            this.Year = year;
            this.Erased = false;
        }
        
        // To String 

        public override string ToString()
        {
            // Environment.NewLine https://docs.microsoft.com/en-us/dotnet/api/system.environment.newline?view=netcore-3.1
            string returning = "";
            returning += "Genre: " + this.Genre; 
            returning += "Title: " + this.Title;
            returning += "Description: " + this.Description;
            returning += "Start Year: " + this.Year;
            returning += "Erased: " + this.Erased;
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