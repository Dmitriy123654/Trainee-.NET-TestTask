using Microsoft.EntityFrameworkCore;
using TestTask.Enums;
using TestTask.Models;

namespace TestTask.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Order> Orders { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User[]
                {
                    new User { Id=1, Email="user1@gmail.com", Status=UserStatus.Active},
                    new User { Id=2, Email="user2@gmail.com", Status=UserStatus.Active},
                    new User { Id=3, Email="user3@gmail.com", Status=UserStatus.Active},
                    new User { Id=4, Email="user4@gmail.com", Status=UserStatus.Active},
                    new User { Id=5, Email="user5@gmail.com", Status=UserStatus.Inactive},
                    new User { Id=6, Email="user6@gmail.com", Status=UserStatus.Inactive},
                    new User { Id=7, Email="user7@gmail.com", Status=UserStatus.Active},
                });

            modelBuilder.Entity<Order>().HasData(
                new Order[]
                {
                    new Order {Id=1, ProductName="Apple", Price=10, Quantity=5, UserId=1},
                    new Order {Id=2, ProductName="Lemon", Price=30, Quantity=2, UserId=1},
                    new Order {Id=3, ProductName="Cucumber", Price=5, Quantity=10, UserId=1},
                    new Order {Id=4, ProductName="Cabbage", Price=7, Quantity=2, UserId=2},
                    new Order {Id=5, ProductName="Onion", Price=8, Quantity=6, UserId=2},
                    new Order {Id=6, ProductName="Carrot", Price=9, Quantity=5, UserId=2},
                    new Order {Id=7, ProductName="Mango", Price=40, Quantity=2, UserId=3},
                    new Order {Id=8, ProductName="Orange", Price=45, Quantity=5, UserId=4},
                    new Order {Id=9, ProductName="Watermelon", Price=100, Quantity=1, UserId=4},
                    new Order {Id=10, ProductName="Garlic", Price=8, Quantity=12, UserId=4},
                    new Order {Id=11, ProductName="Potato", Price=3, Quantity=100, UserId=7},
                    new Order {Id=12, ProductName="Carrot", Price=9, Quantity=15, UserId=7},
                    new Order {Id=13, ProductName="Onion", Price=8, Quantity=15, UserId=7},
                    new Order {Id=14, ProductName="Pumpkin", Price=50, Quantity=1, UserId=7},
                    new Order {Id=15, ProductName="Watermelon", Price=100, Quantity=12, UserId=7},
                });
        }
    }
}
