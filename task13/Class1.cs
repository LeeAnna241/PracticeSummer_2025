using System.Text.Json.Serialization;

namespace task13;

public class Subject
{
  public string? Name {get; set; }
  public int Grade {get; set; }
}

public class Student
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public DateOnly? BirthDate { get; set; }
    public List<Subject>? Grades { get; set; }
}

