namespace Tk.Extensions.Time
{
    public interface ITimeProvider
    {
        /// <summary>
        /// Retrieve the current UTC date time.
        /// </summary>
        /// <returns></returns>
        DateTime UtcNow();
    }

    public class TimeProvider : ITimeProvider
    {
        /// <inheritdoc/>        
        public DateTime UtcNow() => DateTime.UtcNow;
    }
}
