namespace Tk.Extensions.Time
{
    public interface ITimeProvider
    {
        DateTime UtcNow();
    }

    public class TimeProvider : ITimeProvider
    {
        public DateTime UtcNow() => DateTime.UtcNow;
    }
}
