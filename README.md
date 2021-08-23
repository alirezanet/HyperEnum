# HyperEnum
A C# library that make working with Enums more than 18 times faster without any memory allocation using csharp source generator. 

# Performance Comparision

|           Method |      Mean |     Error |    StdDev |  Gen 0 | Allocated |
|----------------- |----------:|----------:|----------:|-------:|----------:|
|   NormalToString | 20.248 ns | 0.1086 ns | 0.1016 ns | 0.0038 |      24 B |
|      EnumGetName | 41.523 ns | 0.1619 ns | 0.1352 ns | 0.0038 |      24 B |
| HyperEnumGetName |  2.122 ns | 0.0189 ns | 0.0177 ns |      - |         - |

```c#
[Benchmark]
public void NormalToString() => HumanStates.Idle.ToString(); // output = "Idle"
[Benchmark]
public void EnumGetName() => Enum.GetName(typeof(HumanStates), HumanStates.Idle);
[Benchmark]
public void HyperEnumGetName() => HumanStates.Idle.GetName(); // output = "Idle"
```


