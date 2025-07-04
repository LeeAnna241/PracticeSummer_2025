using FileSystemCommands;
using CommandLib;

class Consolo_app
{
    static void Main()
    {
        var path_d = @"C:\Users\User\PracticeSummer_2025\";
        var test_DirectorySizeCommand = new DirectorySizeCommand(path_d);
        test_DirectorySizeCommand.Execute();
        Console.WriteLine(test_DirectorySizeCommand);

        var path_t = @"C:\Users\User\SummerPractice_2025\task08Tests\";
        var pattern_t = ".cs";
        var test_FindFilesCommand = new FindFilesCommand(path_t, pattern_t);
        test_FindFilesCommand.Execute();
        if (test_FindFilesCommand.found_files.Length != 0) foreach (var file in test_FindFilesCommand.found_files) Console.WriteLine(file);
    }
}