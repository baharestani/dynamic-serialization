This project desializes a binary serialized object without needing to reference the original or a proxy type. 


## How to build ##

Some C# 7.0 features are used, so you need VS2017 or MsBuild 15.0 to build.

## How to use ##
1. Run the serializer: It serializes an instanc of `SampleType` and dumps it in a file on c:\object.dat
2. Run the deserializer: It sends the content of the file as a memory stream to the `Deserialize` function and converts it to JSON.

P.S: Self-referencing objects are not detected and attempting to deserialize them results in a StackOverFlowException.
