using Microsoft.EntityFrameworkCore;
using Zdenac_API.Models;

namespace Zdenac_API.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Child> Children { get; set; }
    
    }
}
