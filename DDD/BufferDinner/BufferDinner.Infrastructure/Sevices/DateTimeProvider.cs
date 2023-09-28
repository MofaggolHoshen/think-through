using BufferDinner.Application.Common.Interfaces.Services;

namespace BufferDinner.Infrastructure.Sevices;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}
