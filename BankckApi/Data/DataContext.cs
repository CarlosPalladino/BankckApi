using BankckApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BankckApi.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Account> Account { get; set; }

        public DbSet<Transaction> Transaction { get; set; }
        public DbSet<Currency> Currency { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<ExchangeRate> ExchangeRate { get; set; }


        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración de claves primarias
            modelBuilder.Entity<Account>()
                    .Property(a => a.Balance)
                    .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Transaction>()
                .Property(t => t.Amount)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<ExchangeRate>()
                .Property(er => er.Rate)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Account>().HasKey(a => a.Id);
            modelBuilder.Entity<Transaction>().HasKey(t => t.Id);
            modelBuilder.Entity<Currency>().HasKey(c => c.Id);
            modelBuilder.Entity<Customer>().HasKey(c => c.Id);
            modelBuilder.Entity<ExchangeRate>().HasKey(er => er.Id);

            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Account)
                .WithMany(a => a.Transactions)
                .HasForeignKey(t => t.AccountId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ExchangeRate>()
                .HasOne(er => er.TargetCurrency)
                .WithMany()
                .HasForeignKey(er => er.TargetCurrencyId)
                .OnDelete(DeleteBehavior.Restrict);

            // Otras configuraciones de relaciones y claves aquí...

            base.OnModelCreating(modelBuilder);
        }
    }
}


