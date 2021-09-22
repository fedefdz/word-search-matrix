``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19042.1052 (20H2/October2020Update)
Intel Core i7-6600U CPU 2.60GHz (Skylake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=5.0.101
  [Host]     : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  DefaultJob : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT


```
|                      Method | wordstream |      Mean |     Error |    StdDev |   Gen 0 | Allocated |
|---------------------------- |----------- |----------:|----------:|----------:|--------:|----------:|
|    **SearcherMatrixSequential** | **String[12]** | **26.867 μs** | **0.4573 μs** | **0.4277 μs** | **17.9443** |     **37 KB** |
|      SearcherMatrixParallel | String[12] | 47.390 μs | 0.9334 μs | 1.5336 μs | 24.2310 |     49 KB |
| SearcherFlyweightSequential | String[12] | 15.596 μs | 0.2332 μs | 0.2181 μs |  7.8125 |     16 KB |
|   SeracherFlyweightParallel | String[12] | 40.150 μs | 0.7873 μs | 1.3154 μs | 12.8784 |     26 KB |
|    **SearcherMatrixSequential** |  **String[1]** |  **3.065 μs** | **0.0359 μs** | **0.0280 μs** |  **2.0332** |      **4 KB** |
|      SearcherMatrixParallel |  String[1] | 15.058 μs | 0.2994 μs | 0.5165 μs |  3.5248 |      7 KB |
| SearcherFlyweightSequential |  String[1] |  2.024 μs | 0.0399 μs | 0.0333 μs |  1.1139 |      2 KB |
|   SeracherFlyweightParallel |  String[1] | 12.272 μs | 0.4979 μs | 1.4444 μs |  2.2888 |      5 KB |
|    **SearcherMatrixSequential** |  **String[3]** |  **8.830 μs** | **0.1753 μs** | **0.3581 μs** |  **5.8441** |     **12 KB** |
|      SearcherMatrixParallel |  String[3] | 24.755 μs | 0.4033 μs | 0.5244 μs |  8.3618 |     17 KB |
| SearcherFlyweightSequential |  String[3] |  4.994 μs | 0.0871 μs | 0.0772 μs |  2.3041 |      5 KB |
|   SeracherFlyweightParallel |  String[3] | 18.684 μs | 0.3723 μs | 0.7435 μs |  4.3640 |      9 KB |
|    **SearcherMatrixSequential** |  **String[6]** | **17.530 μs** | **0.3110 μs** | **0.2909 μs** | **11.8408** |     **24 KB** |
|      SearcherMatrixParallel |  String[6] | 37.070 μs | 0.7288 μs | 0.9218 μs | 16.6016 |     34 KB |
| SearcherFlyweightSequential |  String[6] | 10.443 μs | 0.1834 μs | 0.4393 μs |  4.8676 |     10 KB |
|   SeracherFlyweightParallel |  String[6] | 29.688 μs | 0.5802 μs | 1.0754 μs |  8.6060 |     18 KB |
|    **SearcherMatrixSequential** |  **String[9]** | **17.597 μs** | **0.2992 μs** | **0.3326 μs** | **12.0850** |     **25 KB** |
|      SearcherMatrixParallel |  String[9] | 39.315 μs | 0.7419 μs | 0.6195 μs | 16.4795 |     33 KB |
| SearcherFlyweightSequential |  String[9] | 10.481 μs | 0.2000 μs | 0.2600 μs |  5.1270 |     10 KB |
|   SeracherFlyweightParallel |  String[9] | 30.393 μs | 0.5876 μs | 0.5771 μs |  8.7585 |     18 KB |
