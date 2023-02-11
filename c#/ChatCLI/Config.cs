namespace ChatCLI;

public class Config
{
    public string ProgramDataDir;

    public Config(string programDataDir)
    {
        ProgramDataDir = programDataDir;
    }

    public static Config Default = new Config("program_data");
}