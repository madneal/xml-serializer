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
        }
    }

    [XmlRoot]
	public class TestClass {
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
