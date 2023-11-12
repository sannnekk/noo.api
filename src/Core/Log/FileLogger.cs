using AutoDependencyRegistration.Attributes;

namespace noo.api.Core.Log;

[RegisterClassAsSingleton]
public class FileLogger : ILogger
{
    private readonly string _logPath;

    public FileLogger()
    {
        _logPath = Path.Combine(
            Directory.GetCurrentDirectory(),
            "log.txt"
        );
    }

    public void Log(string message)
    {
        File.AppendAllText(_logPath, message);
    }

    public void Log(Exception exception)
    {
        File.AppendAllText(_logPath, exception.Message);
    }

    private void WriteLog(string txt, bool error = false)
    {
        var dateTime = DateTime.Now.ToString();
        var message = dateTime + ": ";

        if (error)
            message += " ERROR: ";

        message += txt;

        File.AppendAllText(_logPath, message);
    }
}
