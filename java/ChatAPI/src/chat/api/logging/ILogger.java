package chat.api.logging;

public interface ILogger {
    void setDebugLogEnabled(boolean enabled);
    boolean isDebugLogEnabled();
    void setInfoLogEnabled(boolean enabled);
    boolean isInfoLogEnabled();
    void setWarnLogEnabled(boolean enabled);
    boolean isWarnLogEnabled();
    void setErrorLogEnabled(boolean enabled);
    boolean isErrorLogEnabled();

    void log(LogSeverity severity, String message);
    void logDebug(String message);
    void logInfo(String message);
    void logWarn(String message);
    void logWarn(Exception exception);
    void logError(String message);
    void logError(Exception exception);
}
