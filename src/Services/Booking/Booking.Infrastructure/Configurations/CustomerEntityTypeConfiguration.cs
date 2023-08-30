using Booking.Domain.AggregatesModel.BookingAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Booking.Infrastructure.Configurations
{
    public class CustomerEntityTypeConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Clientes");

            builder.HasKey(b => b.Id);
            builder.Ignore(b => b.DomainEvents);

            builder.Property(p => p.Id)
               .HasColumnName("Id")
               .IsRequired(true);

            builder.Property(p => p.Name)
                .HasColumnName("Nome")
                .HasColumnType("varchar(100)")
                .IsRequired(true);

            builder.Property(p => p.Contact)
                .HasColumnName("Contato")
                .HasColumnType("varchar(100)")
                .IsRequired(true);

            builder.HasMany(b => b.GetBookings())
                .WithOne()
                .HasForeignKey("ClienteId")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
