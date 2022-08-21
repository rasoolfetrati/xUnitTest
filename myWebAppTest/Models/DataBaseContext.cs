using Microsoft.EntityFrameworkCore;
using myWebAppTest.Models.Entities;

namespace myWebAppTest.Models
{
    public class DataBaseContext:DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options):base(options)
        {

        }
        public DbSet<Product> products { get; set; }
    }
}
