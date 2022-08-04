using InnerDinner.Application.Common.Services;

namespace InnerDinner.Infrastructure.Services;

public sealed class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}