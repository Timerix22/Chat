namespace ChatAPI;

public enum LogSeverity
{
    Debug,
    Info,
    Warn,
    Error
}

public interface ILogger
{ 
    bool DebugLogEnabled { get; set; }
    bool InfoLogEnabled { get; set; }
    bool WarnLogEnabled { get; set; }
    bool ErrorLogenabled { get; set; }
    
    void Log(LogSeverity severity, string message);
    void LogDebug(string message);
    void LogInfo(string message);
    void LogWarn(string message);
    void LogWarn(Exception exception); 
    void LogError(string message);
    void LogError(Exception exception);
    
}