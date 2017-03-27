using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Serializer
{
    class Program
    {
        static void Main(string[] args)
        {
            Serialize("C:\\object.dat");
        }


        static void Serialize(string fileName)
        {
            using (var stream = new FileStream(fileName, FileMode.Create))
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(stream, new SampleType());
            }

        }
    }
}
