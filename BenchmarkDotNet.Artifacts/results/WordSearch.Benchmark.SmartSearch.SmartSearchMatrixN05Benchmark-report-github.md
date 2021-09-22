``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19042.1052 (20H2/October2020Update)
Intel Core i7-6600U CPU 2.60GHz (Skylake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=5.0.101
  [Host]     : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  DefaultJob : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT


```
|                      Method | wordstream |      Mean |     Error |    StdDev |    Median |  Gen 0 | Allocated |
|---------------------------- |----------- |----------:|----------:|----------:|----------:|-------:|----------:|
|    **SearcherMatrixSequential** | **String[12]** |  **8.883 μs** | **0.1596 μs** | **0.2185 μs** |  **8.845 μs** | **5.1575** |     **11 KB** |
|      SearcherMatrixParallel | String[12] | 28.665 μs | 0.8525 μs | 2.4596 μs | 27.937 μs | 8.4839 |     17 KB |
| SearcherFlyweightSequential | String[12] |  6.786 μs | 0.1278 μs | 0.1195 μs |  6.751 μs | 2.6779 |      5 KB |
|   SeracherFlyweightParallel | String[12] | 24.462 μs | 0.4643 μs | 1.0762 μs | 24.260 μs | 5.9204 |     12 KB |
|    **SearcherMatrixSequential** |  **String[1]** |  **1.439 μs** | **0.0258 μs** | **0.0229 μs** |  **1.436 μs** | **0.8869** |      **2 KB** |
|      SearcherMatrixParallel |  String[1] |  7.741 μs | 0.1580 μs | 0.4559 μs |  7.655 μs | 2.0447 |      4 KB |
| SearcherFlyweightSequential |  String[1] |  1.196 μs | 0.0239 μs | 0.0461 μs |  1.183 μs | 0.5760 |      1 KB |
|   SeracherFlyweightParallel |  String[1] |  6.902 μs | 0.1379 μs | 0.3935 μs |  6.824 μs | 1.6632 |      3 KB |
|    **SearcherMatrixSequential** |  **String[3]** |  **4.525 μs** | **0.2831 μs** | **0.7749 μs** |  **4.157 μs** | **2.3956** |      **5 KB** |
|      SearcherMatrixParallel |  String[3] | 22.213 μs | 0.4741 μs | 1.3980 μs | 22.206 μs | 4.3335 |      9 KB |
| SearcherFlyweightSequential |  String[3] |  4.929 μs | 0.4720 μs | 1.3918 μs |  4.667 μs | 1.0910 |      2 KB |
|   SeracherFlyweightParallel |  String[3] | 19.280 μs | 0.5458 μs | 1.6006 μs | 19.463 μs | 2.9907 |      6 KB |
|    **SearcherMatrixSequential** |  **String[6]** |  **9.444 μs** | **0.7784 μs** | **2.2950 μs** |  **9.567 μs** | **3.3112** |      **7 KB** |
|      SearcherMatrixParallel |  String[6] | 24.558 μs | 0.7684 μs | 2.2657 μs | 24.310 μs | 5.7983 |     12 KB |
| SearcherFlyweightSequential |  String[6] |  4.530 μs | 0.0875 μs | 0.1255 μs |  4.501 μs | 1.6251 |      3 KB |
|   SeracherFlyweightParallel |  String[6] | 16.544 μs | 0.3288 μs | 0.3075 μs | 16.485 μs | 4.0131 |      8 KB |
|    **SearcherMatrixSequential** |  **String[9]** |  **5.977 μs** | **0.1131 μs** | **0.0883 μs** |  **5.958 μs** | **3.5629** |      **7 KB** |
|      SearcherMatrixParallel |  String[9] | 22.747 μs | 0.5524 μs | 1.5848 μs | 22.458 μs | 5.8899 |     12 KB |
| SearcherFlyweightSequential |  String[9] |  4.572 μs | 0.0854 μs | 0.0713 μs |  4.544 μs | 1.8768 |      4 KB |
|   SeracherFlyweightParallel |  String[9] | 18.791 μs | 0.7997 μs | 2.3200 μs | 18.200 μs | 4.1199 |      8 KB |
