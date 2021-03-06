``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19042.1052 (20H2/October2020Update)
Intel Core i7-6600U CPU 2.60GHz (Skylake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=5.0.101
  [Host]     : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  DefaultJob : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT


```
|                      Method | wordstream |      Mean |     Error |    StdDev |    Median |   Gen 0 | Allocated |
|---------------------------- |----------- |----------:|----------:|----------:|----------:|--------:|----------:|
|    **SearcherMatrixSequential** | **String[12]** | **58.199 μs** | **1.1390 μs** | **1.3117 μs** | **58.053 μs** | **40.4053** |     **83 KB** |
|      SearcherMatrixParallel | String[12] | 76.434 μs | 1.5271 μs | 2.9054 μs | 76.651 μs | 51.0254 |    104 KB |
| SearcherFlyweightSequential | String[12] | 32.042 μs | 0.5969 μs | 0.5862 μs | 31.945 μs | 16.6016 |     34 KB |
|   SeracherFlyweightParallel | String[12] | 55.798 μs | 0.9351 μs | 0.8747 μs | 55.788 μs | 24.0479 |     49 KB |
|    **SearcherMatrixSequential** |  **String[1]** |  **5.070 μs** | **0.0908 μs** | **0.0849 μs** |  **5.092 μs** |  **3.4103** |      **7 KB** |
|      SearcherMatrixParallel |  String[1] | 17.871 μs | 0.3542 μs | 0.7922 μs | 17.862 μs |  5.3711 |     11 KB |
| SearcherFlyweightSequential |  String[1] |  3.186 μs | 0.0501 μs | 0.0445 μs |  3.176 μs |  1.8044 |      4 KB |
|   SeracherFlyweightParallel |  String[1] | 17.235 μs | 0.7086 μs | 2.0894 μs | 16.355 μs |  3.1128 |      6 KB |
|    **SearcherMatrixSequential** |  **String[3]** | **14.011 μs** | **0.2607 μs** | **0.2177 μs** | **13.982 μs** |  **9.9640** |     **20 KB** |
|      SearcherMatrixParallel |  String[3] | 30.109 μs | 0.5975 μs | 1.6357 μs | 29.344 μs | 12.8174 |     26 KB |
| SearcherFlyweightSequential |  String[3] |  7.365 μs | 0.1253 μs | 0.1046 μs |  7.361 μs |  3.7079 |      8 KB |
|   SeracherFlyweightParallel |  String[3] | 23.455 μs | 0.4583 μs | 0.3827 μs | 23.513 μs |  5.8899 |     12 KB |
|    **SearcherMatrixSequential** |  **String[6]** | **29.930 μs** | **0.5811 μs** | **0.5152 μs** | **29.939 μs** | **20.1111** |     **41 KB** |
|      SearcherMatrixParallel |  String[6] | 46.880 μs | 0.8371 μs | 0.7421 μs | 46.923 μs | 26.5503 |     54 KB |
| SearcherFlyweightSequential |  String[6] | 15.738 μs | 0.2579 μs | 0.2153 μs | 15.695 μs |  7.9956 |     16 KB |
|   SeracherFlyweightParallel |  String[6] | 35.656 μs | 0.6534 μs | 0.5792 μs | 35.623 μs | 12.3901 |     25 KB |
|    **SearcherMatrixSequential** |  **String[9]** | **43.086 μs** | **0.8198 μs** | **0.7668 μs** | **42.976 μs** | **30.3955** |     **62 KB** |
|      SearcherMatrixParallel |  String[9] | 62.612 μs | 0.9330 μs | 1.3676 μs | 62.344 μs | 38.6963 |     78 KB |
| SearcherFlyweightSequential |  String[9] | 22.447 μs | 0.4402 μs | 0.4710 μs | 22.381 μs | 12.1155 |     25 KB |
|   SeracherFlyweightParallel |  String[9] | 45.965 μs | 0.8801 μs | 0.8233 μs | 45.492 μs | 18.4937 |     37 KB |
