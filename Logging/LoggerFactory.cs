using Microsoft.Extensions.Logging;

namespace EY.CabinCrew.Logging
{
    public static class LoggerFactory
    {
        public static ILoggerFactory Factory {get;set;}

        public static ILogger<T> CreateLogger<T>() => Factory.CreateLogger<T>();
    }
}
