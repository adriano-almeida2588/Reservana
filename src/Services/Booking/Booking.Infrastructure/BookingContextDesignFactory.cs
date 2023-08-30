using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Booking.Infrastructure
{
    public class BookingContextDesignFactory : IDesignTimeDbContextFactory<BookingContext>
    {
        public BookingContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<BookingContext>()
                .UseSqlServer("Server=.;Initial Catalog=Booking;Integrated Security=true");

            return new BookingContext(optionsBuilder.Options, new NoMediator());
        }
    }
}
