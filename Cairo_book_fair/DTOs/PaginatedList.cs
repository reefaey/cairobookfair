namespace Cairo_book_fair.DTOs
{
    public class PaginatedList<T>
    {

        public IEnumerable<T> Items { get; set; }

        public int TotalItems { get; set; }

        public int TotalPages { get; set; }

        public int CurrentPage { get; set; }
    }
}

