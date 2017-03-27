using System;
using System.Runtime.Serialization;

namespace ConsoleApp5
{
    sealed class ObjectDescriptorDeserializationBinder : SerializationBinder
    {
        public override Type BindToType(string assemblyName, string typeName)
        {
            return typeof(ObjectDescriptor);
        }
    }
}