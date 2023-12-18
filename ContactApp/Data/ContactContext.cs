using ContactApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactApp.Data
{
    public class ContactContext : DbContext
    {
        public ContactContext(DbContextOptions<ContactContext> options) : base(options)
        {
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<EmailAddress> EmailAddresses { get; set; }
        public DbSet<PhoneNumber> PhoneNumbers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .ToTable("Person")
                .HasMany(p => p.EmailAddresses)
                .WithOne(p => p.Person)
                .HasForeignKey(e => e.PersonID);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.PhoneNumbers)
                .WithOne(ph => ph.Person)
                .HasForeignKey(e => e.PersonID);

            modelBuilder.Entity<EmailAddress>().ToTable("EmailAddress");
            modelBuilder.Entity<PhoneNumber>().ToTable("PhoneNumber");

            base.OnModelCreating(modelBuilder);
        }
    }
}
