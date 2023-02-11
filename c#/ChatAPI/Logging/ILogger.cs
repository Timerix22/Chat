namespace ChatAPI;

public interface ILogger
{ 
    bool DebugLogEnabled { get; set; }
    bool InfoLogEnabled { get; set; }
    bool WarnLogEnabled { get; set; }
    bool ErrorLogEnabled { get; set; }
    
    void Log(LogSeverity severity, string message);
    void LogDebug(string message);
    void LogInfo(string message);
    void LogWarn(string message);
    void LogWarn(Exception exception); 
    void LogError(string message);
    void LogError(Exception exception);
}