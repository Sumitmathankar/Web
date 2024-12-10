using API_CRUD_PRACT_1.Models;
using Microsoft.EntityFrameworkCore;

namespace API_CRUD_PRACT_1.Repository
{
    public class Appdbcontext:DbContext

    {
        public Appdbcontext(DbContextOptions<Appdbcontext> options)
             : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=(localdb)\ProjectModels;Initial Catalog=ADO_demo;Integrated Security=True");
            }
        }
        public DbSet<Employee> Employees { get; set; }
    }

}

