using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace IntroLibrary.Core.Models
{
    public class dbContext
    {
        public dbContext()
        {
            InitializeDatabase();
        }

        public virtual List<Book> Books { get; set ; }

        private void InitializeDatabase()
        {
            Books = new List<Book>
            {
                new Book
                {
                    ID = 1, Author = "Jules Verne", Title = "Twenty Thousand Leagues Under the Sea",
                    ReleaseDate = new DateTime(1992, 04, 15)
                },
                new Book
                {
                    ID = 2, Author = "Jules Verne", Title = "Journey to the Center of the Earth",
                    ReleaseDate = new DateTime(1993, 11, 01)
                }
            };
        }

    }
}
