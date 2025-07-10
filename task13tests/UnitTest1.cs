using task13;
using System.Text.Json;
using Microsoft.VisualBasic;
using System.Runtime.InteropServices;
namespace task13tests;

public class Tests
{
    [Fact]
    public void Serialize_ShouldDefineNullFirstName()
    {
        var null_FirstName = new Student
        {
            FirstName = null,
            LastName = "Smith",
            BirthDate = DateOnly.Parse("1997-10-3"),
            Grades = new List<Subject> { new Subject { Name = "PE", Grade = 5 } }
        };

        string to_json = JsonSerializer.Serialize<Student>(null_FirstName);

        Assert.Contains("Smith", to_json);
        Assert.Contains("1997-10-03", to_json);
        Assert.Contains("PE", to_json);
        Assert.Contains("5", to_json);
        Assert.DoesNotContain("FirstName", to_json);  
    }

    

    [Fact]
    public void Deserialize_ShouldDefineNullLastName()
    {
        var null_Grades = new Student
        {
            FirstName = "Anna",
            LastName = "Smith",
            BirthDate = DateOnly.Parse("1997-10-03"),
            Grades = null
        };
        string to_json = JsonSerializer.Serialize<Student>(null_Grades);
        Student? from_json = JsonSerializer.Deserialize<Student>(to_json);

        Assert.Equal(new DateOnly(1997,10,3),from_json!.BirthDate);
        Assert.Equal("Anna", from_json.FirstName);
        Assert.Equal("Smith",from_json.LastName);
        Assert.Null(from_json.Grades);
    }  
}

