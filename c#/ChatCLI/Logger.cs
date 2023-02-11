using DTLib.Logging.New;
using ILogger = ChatAPI.ILogger;
using LogSeverity = ChatAPI.LogSeverity;
using Path = DTLib.Filesystem.Path;

namespace ChatCLI;

public class Logger : ILogger
{
    private ContextLogger dtlibLogger;

    public Logger(string context)
    {
        dtlibLogger = new ContextLogger(context: context, parentLogger: 
            new CompositeLogger(
                new ConsoleLogger(),
                new FileLogger(
                    Path.Concat(Program.config.ProgramDataDir, "logs").Str, 
                    context)));
    }

    public bool DebugLogEnabled
    {
        get => dtlibLogger.DebugLogEnabled;
        set => dtlibLogger.DebugLogEnabled = value;
    }

    public bool InfoLogEnabled
    {
        get => dtlibLogger.InfoLogEnabled;
        set => dtlibLogger.InfoLogEnabled = value;
    }

    public bool WarnLogEnabled
    {
        get => dtlibLogger.WarnLogEnabled;
        set => dtlibLogger.WarnLogEnabled = value;
    }

    public bool ErrorLogenabled
    {
        get => dtlibLogger.ErrorLogenabled;
        set => dtlibLogger.ErrorLogenabled = value;
    }

    public void Log(LogSeverity severity, string message) => 
        dtlibLogger.Log(
            // one ChatAPI.LogSeverity can be converted to DTLib.Logging.New.LogSeverity
            // because their members are the same
            (DTLib.Logging.New.LogSeverity)(int)severity,
            message);

    public void LogDebug(string message) => dtlibLogger.LogDebug(message);

    public void LogInfo(string message) => dtlibLogger.LogInfo(message);

    public void LogWarn(string message) => dtlibLogger.LogWarn(message);

    public void LogWarn(Exception exception) => dtlibLogger.LogWarn(exception);

    public void LogError(string message) => dtlibLogger.LogError(message);

    public void LogError(Exception exception) => dtlibLogger.LogError(exception);
}