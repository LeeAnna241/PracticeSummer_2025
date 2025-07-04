using FileSystemCommands;
namespace task08Tests;

public class FileSystemCommandsTests
{
    [Fact]
    public void DirectorySizeCommand_ShouldCalculateSize()
    {
        var testDir = Path.Combine(Path.GetTempPath(), "TestDir");
        Directory.CreateDirectory(testDir);
        var file1 = Path.Combine(testDir,  "test1.txt");
        var file2 = Path.Combine(testDir, "test2.txt");
        File.WriteAllText(file1, "Hello");
        File.WriteAllText(file2, "World");

        var command = new DirectorySizeCommand(testDir);
        command.Execute(); // Проверяем, что не возникает исключений

        long result = new FileInfo(file1).Length + new FileInfo(file2).Length;
        Assert.Equal(result, command.size);

        Directory.Delete(testDir, true);
    }

    [Fact]
    public void FindFilesCommand_ShouldFindMatchingFiles()
    {
        var testDir = Path.Combine(Path.GetTempPath(), "TestDir");
        Directory.CreateDirectory(testDir);
        var file1_txt = Path.Combine(testDir, "file1.txt");
        var file2_log = Path.Combine(testDir, "file2.log");
        File.WriteAllText(file1_txt, "Text");
        File.WriteAllText(file2_log, "Log");

        var command = new FindFilesCommand(testDir, "*.txt");
        command.Execute(); // Должен найти 1 файл

        Assert.Single(command.found_files);
        Assert.Contains(file1_txt, command.found_files[0]);

        Directory.Delete(testDir, true);
    }
}