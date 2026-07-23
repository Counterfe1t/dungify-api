using Dungify.Core.Abstractions;

namespace Dungify.Infrastructure.Time;

public class TimeProvider : ITimeProvider
{
    public DateTimeOffset UtcNow => DateTimeOffset.UtcNow;
}