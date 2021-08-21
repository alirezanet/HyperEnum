# HyperEnum
A C# library that make working with Enums more than 18 times faster without any memory allocation using csharp source generator. 

# Performance Comparision

|           Method |      Mean |     Error |    StdDev |  Gen 0 | Allocated |
|----------------- |----------:|----------:|----------:|-------:|----------:|
|   NormalToString | 19.413 ns | 0.3114 ns | 0.2913 ns | 0.0038 |      24 B |
| HyperEnumGetName |  1.897 ns | 0.0258 ns | 0.0215 ns |      - |         - |



