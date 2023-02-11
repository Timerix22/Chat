package chat.api;

import chat.api.logging.ILogger;
import chat.api.logging.LogSeverity;

public class ExampleLogger implements ILogger {

    private boolean debugLogEnabled;
    private boolean infoLogEnabled;
    private boolean warnLogEnabled;
    private boolean errorLogEnabled;
    
    @Override
    public void setDebugLogEnabled(boolean enabled) { debugLogEnabled=enabled; }
    @Override
    public boolean isDebugLogEnabled() { return debugLogEnabled; }
    @Override
    public void setInfoLogEnabled(boolean enabled) { infoLogEnabled=enabled; }
    @Override
    public boolean isInfoLogEnabled() { return infoLogEnabled; }
    @Override
    public void setWarnLogEnabled(boolean enabled) { warnLogEnabled=enabled; }
    @Override
    public boolean isWarnLogEnabled() { return warnLogEnabled; }
    @Override
    public void setErrorLogEnabled(boolean enabled) { errorLogEnabled=enabled; }
    @Override
    public boolean isErrorLogEnabled() { return errorLogEnabled; }
    

    @Override
    public void log(LogSeverity severity, String message) {
        System.out.printf("[%s]: %s\n",severity.name(),message);
    }

    @Override
    public void logDebug(String message) { log(LogSeverity.Debug, message); }

    @Override
    public void logInfo(String message) { log(LogSeverity.Info, message); }

    @Override
    public void logWarn(String message) { log(LogSeverity.Warn, message); }

    @Override
    public void logWarn(Exception ex) { log(LogSeverity.Warn, stringifyException(ex)); }

    @Override
    public void logError(String message) { log(LogSeverity.Error, message); }

    @Override
    public void logError(Exception ex) { log(LogSeverity.Error, stringifyException(ex)); }
    
    public String stringifyException(Throwable ex){
        var b=new StringBuilder();
        b.append(ex.getClass().getName());
        String message=ex.getMessage();
        if(message!=null)
            b.append(": ").append(message);
        b.append('\n');
        for (StackTraceElement element : ex.getStackTrace()) 
            b.append("\tat ").append(element).append('\n');
        var cause=ex.getCause();
        if(cause!=null)
            b.append("\t CAUSE: ").append(stringifyException(cause));
        return b.toString();
    }

}
