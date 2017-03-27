using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Newtonsoft.Json;

namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            Deserialize(@"C:\object.dat");
        }

        private static void Deserialize(string fileName)
        {
            using (var fs = new FileStream(fileName, FileMode.Open))
            {
                var formatter = new BinaryFormatter
                {
                    Binder = new ObjectDescriptorDeserializationBinder()
                };

                dynamic obj = ((ObjectDescriptor)formatter.Deserialize(fs)).ToDynamicObject();

                string json = JsonConvert.SerializeObject(obj, Formatting.Indented);

                Console.WriteLine(json);
            }

        }


    }
}
