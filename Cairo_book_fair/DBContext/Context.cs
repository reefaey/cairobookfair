using Cairo_book_fair.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Cairo_book_fair.DBContext
{
    public class Context : IdentityDbContext<User>
    {
        public DbSet<User> User { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Block> Blocks { get; set; }
        public DbSet<Donation> Donations { get; set; }
        public DbSet<Hall> Halls { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<UsedBook> UsedBooks { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<BookCategory> BooksCategories { get; set; }
        public DbSet<BookCart> BooksCarts { get; set; }
        public DbSet<BookOrder> BooksOrders { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Shipment> Shipments { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        //public DbSet<UsedBook> UsedBooks { get; set; }

        public Context(DbContextOptions dbContextOptions) : base(dbContextOptions) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Set precision and scale for decimal properties
            modelBuilder.Entity<Book>()
                .Property(b => b.Price)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<Cart>()
                .Property(c => c.TotalCost)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<Order>()
                .Property(o => o.TotalPrice)
                .HasColumnType("decimal(18, 2)");

            // Other configurations
            modelBuilder.Entity<BookCategory>()
                .HasKey(bc => new { bc.BookId, bc.CategoryId });

            modelBuilder.Entity<BookCart>()
                .HasKey(bc => new { bc.BookId, bc.CartId });

            modelBuilder.Entity<BookOrder>()
                .HasKey(bo => new { bo.BookId, bo.OrderId });

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Shipment)
                .WithOne(s => s.Order)
                .HasForeignKey<Order>(o => o.ShipmentId);

            //modelBuilder.Entity<Block>()
            //.HasOne(b => b.Publisher)
            //.WithOne(p => p.Block)
            //.HasForeignKey<Publisher>(p => p.BlockId);
        }


    }
}
