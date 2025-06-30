using System.Reflection;
namespace task07
{
    public class DisplayNameAttribute : Attribute
    {
        public string DisplayName; 
        public DisplayNameAttribute(string displayName)
        {
            DisplayName = displayName;
        }
    }
    public class VersionAttribute : Attribute
    {
        public int Major;
        public int Minor;
        public VersionAttribute(string version)
        {
            string[] splited = version.Split('.');
            Major = Convert.ToInt32(splited[0]);
            Minor = Convert.ToInt32(splited[1]);
        }
    }

    [DisplayName("Пример класса")]
    [Version("1.0")]

    public class SampleClass
    {
        [DisplayName("Тестовый метод")]
        public void TestMethod() { }

        [DisplayName("Числовое свойство")]
        public int Number{ get; }
    }
    public static class ReflectionHelper
    {
        public static void ClassInf(Type type)
        {
            var Class_Check = type.GetCustomAttribute<DisplayNameAttribute>();
            if (Class_Check != null) Console.WriteLine(Class_Check.DisplayName);

            var Method_Check = type.GetMethods()
            .Where(n => n != null)
            .Select(m => m.GetCustomAttribute<DisplayNameAttribute>());
            foreach (var i in Method_Check) Console.WriteLine(i.DisplayName);

            var Property_Check = type.GetProperties()
            .Where(n => n != null)
            .Select(m => m.GetCustomAttribute<DisplayNameAttribute>());
            foreach (var i in Property_Check) Console.WriteLine(i.DisplayName);

            var Version_Check = type.GetCustomAttribute<VersionAttribute>();
            if (Version_Check != null)
            {
                Console.WriteLine($"{Version_Check.Major}.{Version_Check.Minor}");
            }
        }
    }
}
