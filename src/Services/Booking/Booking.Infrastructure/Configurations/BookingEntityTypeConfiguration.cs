using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Booking.Infrastructure.Configurations
{
    public class BookingEntityTypeConfiguration : IEntityTypeConfiguration<Domain.AggregatesModel.BookingAggregate.Booking>
    {
        public void Configure(EntityTypeBuilder<Domain.AggregatesModel.BookingAggregate.Booking> builder)
        {
            builder.ToTable("Reservas");
            builder.HasKey(a => a.Id);
            builder.Ignore(a => a.DomainEvents);

            builder.Property(p => p.Id)
                .HasColumnName("Id")
                .IsRequired(true);

            builder.Property(p => p.CustomerId)
                .HasColumnName("ClienteId")
                .IsRequired(true);

            builder.Property(p => p.ServiceId)
                .HasColumnName("ServicoId")
                .IsRequired(true);

            builder.OwnsOne(p => p.Schedule, s =>
            {
                s.Property(p => p.StartTime)
                    .HasColumnName("HoraInicio")
                    .HasColumnType("datetime2");

                s.Property(p => p.Duration)
                    .HasColumnName("Duracao")
                    .HasColumnType("datetime2");
            });

            builder.OwnsOne(p => p.BookingStatus, b =>
            {
                b.Property(p => p.Id)
                .HasColumnName("Id");

                b.Property(p => p.Name)
                    .HasColumnName("Nome")
                    .HasColumnType("varchar(100)");
            });

            builder.Property(p => p.Comment)
                .HasColumnName("Comentario")
                .HasColumnType("text");
        }
    }
}
