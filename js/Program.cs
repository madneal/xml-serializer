using System;

namespace js
{
    class Program
    {
        static void Main(string[] args)
        {
            TestClass testClass = new TestClass();
            testClass.Name = "mmadneal";
            testClass.Classname = "neal";
            testClass.Age = 18;
            JavaScriptSerializer jss = new JavaScriptSerializer();
            var jsonReq = jss.Serialize(testClass);
            Console.WriteLine(jsonReq);
            Console.ReadKey();

            
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
