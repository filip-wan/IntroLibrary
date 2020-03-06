﻿using System;
using System.ComponentModel.DataAnnotations;

namespace IntroLibrary.Core.DTOs
{
    public class BookDto
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}