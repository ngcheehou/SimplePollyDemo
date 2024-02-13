namespace PollyDemo
{
    public class DatabaseReconnectSettings
    {
        public int RetryCount { get; set; }
        public int RetryWaitPeriodInSeconds { get; set; }
    }
}
