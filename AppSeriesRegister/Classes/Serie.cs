using AppSeriesRegister.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppSeriesRegister.Classes
{
    public class Serie : EntityBase
    {
        //Attributes
        private Genre Genre { get; set; }
        private string Title { get; set; }
        private string Description { get; set; }
        private int Year { get; set; }

        //Methods
        public Serie(int id, Genre genre, string title, string description, int year)
        {
            Id = id;
            Genre = genre;
            Title = title;
            Description = description;
            Year = year;
        }

        public override string ToString()
        {
            string _return = "";
            _return += "Genre: " + this.Genre + Environment.NewLine;
            _return += "Title: " + this.Title + Environment.NewLine;
            _return += "Description: " + this.Description + Environment.NewLine;
            _return += "Release date: " + this.Year;
            return _return;
        }

        public string returnTitle()
        {
            return this.Title;
        }

        public int returnId()
        {
            return this.Id;
        }
    }
}
