using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Newtonsoft.Json;

namespace Deserializer
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var fs = new FileStream(@"C:\object.dat", FileMode.Open))
            {
                Deserialize(fs);
            }
        }

        private static void Deserialize(Stream stream)
        {
            var formatter = new BinaryFormatter
            {
                Binder = new ObjectDescriptorDeserializationBinder()
            };

            dynamic obj = ((ObjectDescriptor)formatter.Deserialize(stream)).ToDynamicObject();

            string json = JsonConvert.SerializeObject(obj, Formatting.Indented);

            Console.WriteLine(json);
        }


    }
}
