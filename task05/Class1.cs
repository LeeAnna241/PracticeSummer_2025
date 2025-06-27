using System.Reflection;

namespace task05
{
    public class ClassAnalyzer
    {
        private Type _type;

        public ClassAnalyzer(Type type)
        {
            _type = type;
        }

        public IEnumerable<string> GetPublicMethods()
        {
            return _type
                .GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)
                .Where(m => !m.IsSpecialName)
                .Select(m => m.Name);
        }

        public IEnumerable<string> GetMethodParams(string methodname)
        {
            var method_name = _type.GetMethod(methodname);
            if (method_name == null) return Enumerable.Empty<string>();
            return method_name.GetParameters()
                .Select(p => p.Name)
                .Where(name => name != null)!;
        }

        public IEnumerable<string> GetAllFields()
        {
            return _type
                .GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                .Select(f => f.Name); 
        }

        public IEnumerable<string> GetProperties()
        {
            return _type
                .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .Select(p => p.Name); 
        }

        public bool HasAttribute<T>() where T : Attribute
        {
            return _type.GetCustomAttributes(typeof(T), false).Any();
        }
    }
}