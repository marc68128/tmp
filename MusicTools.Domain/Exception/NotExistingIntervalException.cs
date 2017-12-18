namespace MusicTools.Domain.Exception
{
    public class NotExistingIntervalException : System.Exception
    {
        public NotExistingIntervalException()
        {
        }

        public NotExistingIntervalException(string message) : base(message)
        {
        }
    }
}