using System;
using System.ComponentModel.DataAnnotations;

namespace IntroLibrary.Core.DTOs
{
    public class BookDto
    {
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Author is required")]
        public string Author { get; set; }
        [Required(ErrorMessage = "Release Date is required")]
        [DataType(DataType.Date)]
        public DateTime? ReleaseDate { get; set; }
    }
}
