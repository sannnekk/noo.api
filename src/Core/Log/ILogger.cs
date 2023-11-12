namespace noo.api.Core.Log;

public interface ILogger
{
    void Log(string message);
    void Log(Exception exception);
}