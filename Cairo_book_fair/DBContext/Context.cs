using Cairo_book_fair.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;

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
        public DbSet<Category> Categories { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<BookCategory> BooksCategories { get; set; }
        public DbSet<BookCart> BooksCarts { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Shipment> Shipments { get; set; }
        public DbSet<Ticket> Tickets { get; set; }


        public Context(DbContextOptions dbContextOptions) : base(dbContextOptions) { }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    //// for default data in database like this ^_^

        //    //modelBuilder.Entity<Books>()
        //    //    .HasData(new Book() { Id = 1, Name = "A", Description = "Expinsive one", Price = 20000, Quentity = 10 });

        //}


    }
}
