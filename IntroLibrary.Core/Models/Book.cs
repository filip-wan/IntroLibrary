using System;
using System.ComponentModel.DataAnnotations;

namespace IntroLibrary.Core.Models
{
    public class Book
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime? ReleaseDate { get; set; }
    }
}
