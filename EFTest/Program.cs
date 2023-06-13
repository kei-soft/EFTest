using Microsoft.EntityFrameworkCore;

namespace EFTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var db = new MyDbContext())
            {
                db.Database.EnsureCreated();

                var employee = new Employee { Name = "Kang Jun", Age = 40 };
                db.Employees.Add(employee);
                db.SaveChanges();
            }
        }

        public class Employee
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
        }

        public class MyDbContext : DbContext
        {
            public DbSet<Employee> Employees { get; set; }
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlite("Filename=mydb.db");
            }
        }
    }
}