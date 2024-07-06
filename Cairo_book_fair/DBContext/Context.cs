using Cairo_book_fair.Models;
using Microsoft.AspNetCore.Identity;
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
        public DbSet<UsedBookRequest> UsedBookRequests { get; set; }
        /// here
        public DbSet<Transportation> Transportations { get; set; }
        public DbSet<Visitors> Visitors { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<ReviewRequest> ReviewRequests {  get; set; }
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

            modelBuilder.Entity<Ticket>()
                .Property(o => o.Price)
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

            //for Review ///////
            /* modelBuilder.Entity<Review>()
                .HasOne(r => r.Book)
                .WithMany(b => b.Reviews)
                .HasForeignKey(r => r.BookId);

            modelBuilder.Entity<Review>()
                .HasOne(r => r.User)
                .WithMany(u => u.Reviews)
                .HasForeignKey(r => r.UserId); */



            //modelBuilder.Entity<Block>()
            //.HasOne(b => b.Publisher)
            //.WithOne(p => p.Block)
            //.HasForeignKey<Publisher>(p => p.BlockId);

            modelBuilder.Entity<IdentityRole>().HasData(
             new IdentityRole()
             {
                 Id = "1",
                 Name = "Admin",
                 NormalizedName = "ADMIN"
             },
              new IdentityRole()
              {
                  Id = "2",
                  Name = "User",
                  NormalizedName = "USER"
              }
           );


            //User user = new ()
            //{
            //    Id = "5",
            //    UserName = "admin",
            //    NormalizedUserName = "ADMIN",
            //    Email = "admin@gmail.com",
            //    NormalizedEmail = "ADMIN@GMAIL.COM",
            //    EmailConfirmed = true
            //};

            //string passwordHash = new PasswordHasher<User>().HashPassword(user, "@Asc123456");

            //user.PasswordHash = passwordHash;

            //modelBuilder.Entity<User>().HasData(user);

            ////modelBuilder.Entity<Context>().HasData(
            //// new IdentityUserRole<string>
            //// {
            ////     UserId = "1",
            ////     RoleId = "1"
            //// });

            //modelBuilder.Entity<IdentityUserRole<string>>().HasData(
            //new IdentityUserRole<string>
            //{
            //    UserId = "1",
            //    RoleId = "1"
            //});

            var adminUserId = Guid.NewGuid().ToString();
            var hasher = new PasswordHasher<User>();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = adminUserId,
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@example.com",
                NormalizedEmail = "ADMIN@EXAMPLE.COM",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "@Abc123456")
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                UserId = adminUserId,
                RoleId = "1"
            });
        }
    }
}
