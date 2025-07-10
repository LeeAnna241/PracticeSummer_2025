using System.Reflection.Metadata.Ecma335;
using System.Text.Json;
using task13;

namespace Serializer_Deserializer
{
    public static class Program
    {
        static void Main()
        {
            var example = new Student
            {
                FirstName = "Adam",
                LastName = "Smith",
                BirthDate = DateOnly.Parse("1997-10-3"),
                Grades = new List<Subject>
                {
                    new Subject {Name = "PE", Grade = 5},
                    new Subject {Name = "Maths", Grade = 4},
                    new Subject {Name = "English", Grade = 5}
                }
            };

            string to_json = JsonSerializer.Serialize<Student>(example);
            Console.WriteLine(to_json);

            string student_file_path = @"D:\student.json";
            File.WriteAllText(student_file_path, to_json);

            Student? from_json = JsonSerializer.Deserialize<Student>(to_json);
            if (from_json == null) Console.WriteLine("Ошибка");
            else
            {
                if (from_json.FirstName == null) Console.WriteLine("Информация отсутствует");
                else Console.WriteLine($"FirstName: {from_json.FirstName}");

                if (from_json.LastName == null) Console.WriteLine("Информация отсутствует");
                else Console.WriteLine($"LastName: {from_json.LastName}");

                if (from_json.Grades == null) Console.WriteLine("Информация отсутствует");
                else
                {
                    foreach (var inf in from_json.Grades)
                    {
                        Console.WriteLine($"{inf.Name} -> {inf.Grade}");
                    }
                }

                if (from_json.BirthDate == null) Console.WriteLine("Информация отсутствует");
                else Console.WriteLine($"Birthday: {from_json.BirthDate}");
            }
        }
    }
}

