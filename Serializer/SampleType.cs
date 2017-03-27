using System;
using System.Collections.Generic;
using System.Linq;

namespace Serializer
{
    [Serializable]
    public class SampleType
    {
        private int number = 4;

        public string StringFiled = "Hello";

        public string MyProperty { get; set; } = "My Value";

        public ComplexType Second = new ComplexType();

        public List<int> Numbers { get; set; } = Enumerable.Range(1, 5).ToList();

        public string F()
        {
            return "Function";
        }
    }

    [Serializable]
    public class ComplexType
    {
        public int X;

        public string Y = "Hi";
    }
}