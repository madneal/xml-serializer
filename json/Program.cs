using System.Diagnostics;
using System;
using Newtonsoft.Json;

namespace json
{
    class Program
    {
        static void Main(string[] args)
        {
            TestClass testClass = new TestClass();
            testClass.Classname = "neal";
            testClass.Name = "madneal";
            testClass.Age = 18;
            string testString = JsonConvert.SerializeObject(testClass);
            Console.WriteLine(testString);
            string testString1 = JsonConvert.SerializeObject(testClass, new JsonSerializerSettings {
                NullValueHandling = NullValueHandling.Ignore,
                TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Full,
                TypeNameHandling = TypeNameHandling.All,
            });
            Console.WriteLine(testString1);
        }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class TestClass
    {
        private string classname;
        private string name;
        private int age;
        [JsonIgnore]
        public string Classname { get => classname; set => classname = value; }
        [JsonProperty]
        public string Name { get => name; set => name = value; }
        [JsonProperty]
        public int Age { get => age; set => age = value; }
        public override string ToString()
        {
            return base.ToString();
        }

        public static void ClassMethod(string value)
        {
            Process.Start(value);
        }
    }
}
