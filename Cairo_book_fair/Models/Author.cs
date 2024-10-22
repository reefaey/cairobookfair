﻿namespace Cairo_book_fair.Models
{
    public class Author
    {
        public int Id {  get; set; }
        public string Name { get; set; }
        public string? Image { get; set; }
        public string? Description { get; set; }
        public int NumberOfBooks { get; set; } = 0;
        public List<Book> Books { get; set;}
    }
}
