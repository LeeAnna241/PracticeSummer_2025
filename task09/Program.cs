using System.Reflection;
namespace task09;

class Console_app
{
    static void Main(string[] path)
    {
        if (!File.Exists(path[0])) Console.WriteLine("Неверный путь!");
        Assembly asm = Assembly.LoadFile(path[0]);

        foreach (var _class in asm.GetTypes())
        {
            Console.WriteLine(_class.Name);

            var Method_Check = _class.GetMethods()
            .Where(n => n != null).ToList();
            foreach (var i in Method_Check) Console.WriteLine(i);

            var Constructor_Check = _class.GetConstructors()
            .Where(n => n != null).ToList();
            foreach (var i in Constructor_Check) Console.WriteLine(i);

            var Attribute_Check = _class.GetCustomAttributes()
            .Where(n => n != null).ToList();
            foreach (var i in Attribute_Check) Console.WriteLine(i);

            foreach (var method_inf in Method_Check)
            {
                var method_name = method_inf.GetParameters()
                .Where(n => n != null).ToList();

                if (method_name.Count != 0)
                {
                    foreach (var property_name in method_name) Console.WriteLine($"{property_name}, {property_name.GetType().Name}");
                }
            }

            foreach (var constructor_inf in Constructor_Check)
            {
                var constructor_name = constructor_inf.GetParameters()
                .Where(n => n != null).ToList();

                if (constructor_name.Count != 0)
                {
                    foreach (var property_name in constructor_name) Console.WriteLine($"{property_name}, {property_name.GetType().Name}");
                }
            }  
        }
    }
}
