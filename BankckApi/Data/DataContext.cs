using BankckApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BankckApi.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Account> Account { get; set; } 
    
        public DbSet<Transaction> Transaction { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        {
            
        }
    }
    
}
