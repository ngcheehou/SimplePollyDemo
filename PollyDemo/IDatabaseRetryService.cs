using System.Runtime.CompilerServices;

namespace PollyDemo
{
    public interface IDatabaseRetryService
    {
        Task ExecuteWithRetryAsync(Func<Task> action);
     
    }
}
