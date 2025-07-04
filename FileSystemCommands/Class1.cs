using CommandLib;

namespace FileSystemCommands;

public class DirectorySizeCommand : ICommand
{
    private readonly string path;

    public long size = 0;

    public DirectorySizeCommand(string path)
    {
        this.path = path;
    }
    
    public void Execute()
    {
        if (!Directory.Exists(path))
        {
            size = 0;
            return;
        }
        
        foreach (var file in Directory.GetFiles(path, "*", SearchOption.AllDirectories))
        {
            size += new FileInfo(file).Length;
        }
    }
}
public class FindFilesCommand : ICommand
{
    private readonly string path;
    private readonly string pattern;
    public string[] found_files = Array.Empty<string>();
    public FindFilesCommand(string path, string pattern)
    {
        this.path = path;
        this.pattern = pattern;
    }
    public void Execute()
    {
        if (!Directory.Exists(path))
        {
            found_files = Array.Empty<string>();
            return;
        }
        found_files = Directory.GetFiles(path, pattern, SearchOption.TopDirectoryOnly);
    }
}