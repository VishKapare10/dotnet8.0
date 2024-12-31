public class LoggerService
{
    private readonly string _logFileName;
    private static int _instanceCount = 0;

    public LoggerService()
    {
        _logFileName = "log.txt";
        _instanceCount++;
        Console.WriteLine($"LoggerService instance count: {_instanceCount}");
    }

    public void Log(string message)
    {
        Console.WriteLine($"{DateTime.Now}: {message}");
        System.IO.File.AppendAllText(_logFileName, $"{DateTime.Now}: {message}\n");
    }
}
