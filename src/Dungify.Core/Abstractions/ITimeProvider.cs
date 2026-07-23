namespace Dungify.Core.Abstractions;

public interface ITimeProvider
{
    /// <summary>
    /// Get current date and time in Coordinated Universal Time (UTC).
    /// </summary>
    public DateTimeOffset UtcNow { get; }
}