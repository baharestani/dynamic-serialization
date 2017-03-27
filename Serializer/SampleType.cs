using System;

namespace Serializer
{
    [Serializable]
    public class SampleType
    {
        private int number = 4;

        public string StringFiled = "Hello";

        public string MyProperty { get; set; } = "My Value";

        public SecondType Second = new SecondType { X = 8 };

        public string F()
        {
            return "Function";
        }
    }

    [Serializable]
    public class SecondType
    {
        public int X;
    }
}