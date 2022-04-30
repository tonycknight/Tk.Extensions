namespace Tk.Extensions
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
