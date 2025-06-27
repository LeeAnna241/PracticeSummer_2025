using System.Reflection;
using Xunit;
using task05;

namespace task05tests
{
    public class TestClass
    {
        public int PublicField;
        private readonly string? _privateField;
        public int Property { get; set; }

        public void Method() { }
    }

    [Serializable]
    public class AttributedClass { }

    public class ClassAnalyzerTests
    {
        [Fact]
        public void GetPublicMethods_ReturnsCorrectMethods()
        {
            var analyzer = new ClassAnalyzer(typeof(TestClass));
            var methods = analyzer.GetPublicMethods();

            Assert.Contains("Method", methods);
        }

        [Fact]
        public void GetAllFields_IncludesPrivateFields()
        {
            var analyzer = new ClassAnalyzer(typeof(TestClass));
            var fields = analyzer.GetAllFields();

            Assert.Contains("_privateField", fields);
            Assert.Contains("PublicField", fields);
        }

        [Fact]
        public void GetMethodParams_MethodName()
        {
            string methodname = "Method";
            var analyzer = new ClassAnalyzer(typeof(TestClass));
            var methodParams = analyzer.GetMethodParams(methodname);
            Assert.Empty(methodParams); 
        }

        [Fact]
        public void GetProperties_AllProperties()
        {
            var analyzer = new ClassAnalyzer(typeof(TestClass));
            var properties = analyzer.GetProperties();
            Assert.Contains("Property", properties);
        }

        [Fact]
        public void HasAttribute_IsContainsInThisClass()
        {
            var analyzer = new ClassAnalyzer(typeof(AttributedClass));
            var hasAttribute = analyzer.HasAttribute<SerializableAttribute>();
            Assert.True(hasAttribute);
        }
    }
}