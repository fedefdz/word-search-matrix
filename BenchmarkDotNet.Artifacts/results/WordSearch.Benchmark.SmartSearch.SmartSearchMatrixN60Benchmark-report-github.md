``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19042.1052 (20H2/October2020Update)
Intel Core i7-6600U CPU 2.60GHz (Skylake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=5.0.101
  [Host]     : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  DefaultJob : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT


```
|                      Method | wordstream |      Mean |     Error |    StdDev |    Median |    Gen 0 | Allocated |
|---------------------------- |----------- |----------:|----------:|----------:|----------:|---------:|----------:|
|    **SearcherMatrixSequential** | **String[12]** | **593.00 μs** | **11.385 μs** | **13.982 μs** | **592.90 μs** | **398.4375** |    **814 KB** |
|      SearcherMatrixParallel | String[12] | 504.24 μs | 10.005 μs | 19.982 μs | 503.28 μs | 468.7500 |    945 KB |
| SearcherFlyweightSequential | String[12] | 315.13 μs |  5.870 μs |  5.204 μs | 314.61 μs | 151.8555 |    310 KB |
|   SeracherFlyweightParallel | String[12] | 285.53 μs |  5.534 μs |  5.921 μs | 283.03 μs | 188.9648 |    381 KB |
|    **SearcherMatrixSequential** |  **String[1]** |  **51.68 μs** |  **0.682 μs** |  **0.569 μs** |  **51.48 μs** |  **33.2031** |     **68 KB** |
|      SearcherMatrixParallel |  String[1] |  65.54 μs |  1.305 μs |  3.201 μs |  65.46 μs |  42.1143 |     85 KB |
| SearcherFlyweightSequential |  String[1] |  33.12 μs |  0.500 μs |  0.443 μs |  32.98 μs |  16.7236 |     34 KB |
|   SeracherFlyweightParallel |  String[1] |  39.29 μs |  0.777 μs |  1.533 μs |  38.76 μs |  21.5454 |     44 KB |
|    **SearcherMatrixSequential** |  **String[3]** | **134.90 μs** |  **2.588 μs** |  **2.421 μs** | **133.72 μs** |  **99.3652** |    **203 KB** |
|      SearcherMatrixParallel |  String[3] | 159.56 μs |  3.084 μs |  4.010 μs | 160.73 μs | 113.7695 |    229 KB |
| SearcherFlyweightSequential |  String[3] |  82.67 μs |  3.271 μs |  9.540 μs |  83.87 μs |  35.4004 |     72 KB |
|   SeracherFlyweightParallel |  String[3] |  76.66 μs |  1.530 μs |  1.880 μs |  76.41 μs |  41.3818 |     83 KB |
|    **SearcherMatrixSequential** |  **String[6]** | **366.87 μs** | **14.511 μs** | **42.099 μs** | **379.93 μs** | **198.7305** |    **407 KB** |
|      SearcherMatrixParallel |  String[6] | 291.03 μs |  5.791 μs |  7.112 μs | 291.27 μs | 243.1641 |    490 KB |
| SearcherFlyweightSequential |  String[6] | 188.42 μs |  7.350 μs | 21.671 μs | 191.62 μs |  73.7305 |    151 KB |
|   SeracherFlyweightParallel |  String[6] | 166.60 μs |  3.263 μs |  4.575 μs | 166.91 μs |  94.2383 |    190 KB |
|    **SearcherMatrixSequential** |  **String[9]** | **516.09 μs** | **18.382 μs** | **53.330 μs** | **523.17 μs** | **298.8281** |    **611 KB** |
|      SearcherMatrixParallel |  String[9] | 427.48 μs |  7.610 μs |  8.142 μs | 426.11 μs | 365.7227 |    737 KB |
| SearcherFlyweightSequential |  String[9] | 287.55 μs | 14.369 μs | 42.142 μs | 294.08 μs | 108.8867 |    223 KB |
|   SeracherFlyweightParallel |  String[9] | 223.87 μs |  4.388 μs |  8.558 μs | 221.19 μs | 136.2305 |    274 KB |
