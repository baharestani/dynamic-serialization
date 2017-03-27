using System;
using System.Runtime.Serialization;

namespace Deserializer
{
    sealed class ObjectDescriptorDeserializationBinder : SerializationBinder
    {
        public override Type BindToType(string assemblyName, string typeName)
        {
            return typeof(ObjectDescriptor);
        }
    }
}