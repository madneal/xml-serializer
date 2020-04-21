using System;
using System.IO;
using System.Xml.Serialization;

namespace basic_serializer
{
    class Program
    {
        static void Main(string[] args)
        {
            TestClass testClass = new TestClass();
            testClass.Classname = "test";
            testClass.Name = "neal";
            testClass.Age = 18;
            FileStream fileStream = File.OpenWrite("test.txt");
            using (TextWriter writer = new StreamWriter(fileStream))
            {
                XmlSerializer serializers = new XmlSerializer(typeof(TestClass));
                serializers.Serialize(writer, testClass);
            }
            TestClass testClass1;
            // use typeof
            using (var stream = new FileStream("test.txt", FileMode.Open))
            {
                var serializers = new XmlSerializer(typeof(TestClass));
                testClass1 = serializers.Deserialize(stream) as TestClass;
            }
            Console.WriteLine(testClass1.Name);
            // use GetType
            TestClass testClass2 = new TestClass();
            using (var stream = new FileStream("test.txt", FileMode.Open))
            {
                var serializers = new XmlSerializer(testClass2.GetType());
                testClass2 = serializers.Deserialize(stream) as TestClass;
            }
            Console.WriteLine(testClass2.Name);
            // use Type.GetType
            TestClass testClass3;
            using (var stream = new FileStream("test.txt", FileMode.Open))
            {
                var serializers = new XmlSerializer(Type.GetType("basic_serializer.TestClass"));
                testClass3 = serializers.Deserialize(stream) as TestClass;
            }
            Console.WriteLine(testClass.Name);
        }
    }

    [XmlRoot]
    public class TestClass
    {
        private string classname;
        private string name;
        private int age;
        [XmlAttribute]
        public string Classname { get => classname; set => classname = value; }
        [XmlElement]
        public string Name { get => name; set => name = value; }
        [XmlElement]
        public int Age { get => age; set => age = value; }
        public override string ToString()
        {
            return base.ToString();
        }
    }


}
