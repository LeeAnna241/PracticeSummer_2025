using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using Microsoft.VisualBasic;

namespace task02;

public class Student
{
    public required string Name { get; set; }
    public required string Faculty { get; set; }
    public required List<int> Grades { get; set; }
}

public class StudentService
{
    private readonly List<Student> _students;

    public StudentService(List<Student> students) => _students = students;

    // 1. Возвращает студентов указанного факультета
    public IEnumerable<Student> GetStudentsByFaculty(string faculty)
    => _students.Where(s => s.Faculty == faculty);

    // 2. Возвращает студентов со средним баллом >= minAverageGrade
    public IEnumerable<Student> GetStudentsWithMinAverageGrade(double minAverageGrade)
     => _students.Where(s => s.Grades.Average() >= minAverageGrade);

    // 3. Возвращает студентов, отсортированных по имени (A-Z)
    public IEnumerable<Student> GetStudentsOrderedByName()
    => _students.OrderBy(s => s.Name);

    // 4. Группировка по факультету
    public ILookup<string, Student> GroupStudentsByFaculty()
   => _students.ToLookup(s => s.Faculty);

    // 5. Находит факультет с максимальным средним баллом
    public string GetFacultyWithHighestAverageGrade()
    => _students
            .GroupBy(s => s.Faculty)
            .Select(g => new
            {
                Faculty = g.Key,
                AvgGrade = g.Average(s => s.Grades.Average())
            })
            .OrderByDescending(x => x.AvgGrade)
            .First()
            .Faculty;
}