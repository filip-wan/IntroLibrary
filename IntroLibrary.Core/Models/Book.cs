using System;
using System.ComponentModel.DataAnnotations;

namespace IntroLibrary.Core.Models
{
    public class Book
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Author is required")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Release Date is required")]
        [DataType(DataType.Date)]
        public DateTime? ReleaseDate { get; set; }
    }
}
