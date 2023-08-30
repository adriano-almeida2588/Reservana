using Booking.Domain.AggregatesModel.BookingAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Booking.Infrastructure.Configurations
{
    public class ServiceEntityTypeConfiguration : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.ToTable("Servicos");

            builder.HasKey(x => x.Id);

            builder.Ignore(b => b.DomainEvents);

            builder.Property(p => p.Id);

            builder.Property(p => p.Name)
                .HasColumnName("Nome")
                .HasColumnType("varchar(100)")
                .IsRequired(true);

            builder.Property(p => p.DefaultDuration)
                .HasColumnName("DuracaoPadrao")
                .HasColumnType("datetime2")
                .IsRequired(true);

            builder.HasMany(p => p.GetBookings())
                .WithOne()
                .HasForeignKey("ServicoId")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
