using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Text.RegularExpressions;

namespace ConsoleApp5
{
    [Serializable]
    class ObjectDescriptor : ISerializable
    {
        private readonly SerializationInfoEnumerator enumerator;



        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
        }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        private ObjectDescriptor(SerializationInfo info, StreamingContext context)
        {
            this.enumerator = info.GetEnumerator();
        }

        public IEnumerable<SerializationEntry> GetMembers()
        {
            this.enumerator.Reset();
            while (this.enumerator.MoveNext())
            {
                yield return this.enumerator.Current;
            }
        }

        public dynamic ToDynamicObject()
        {
            return CreateDynamicObject(this);
        }

        private static dynamic CreateDynamicObject(ObjectDescriptor descriptor)
        {
            var nameRegex = new Regex("<(.+)>");

            IDictionary<string, object> expando = new ExpandoObject();

            foreach (SerializationEntry member in descriptor.GetMembers())
            {
                string memberName = nameRegex.IsMatch(member.Name) ? nameRegex.Match(member.Name).Groups[1].Value : member.Name;
                expando[memberName] = member.Value is ObjectDescriptor complexMember ? CreateDynamicObject(complexMember) : member.Value;
            }

            return (ExpandoObject)expando;
        }
    }
}