``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19042.1052 (20H2/October2020Update)
Intel Core i7-6600U CPU 2.60GHz (Skylake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=5.0.101
  [Host]     : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  DefaultJob : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT


```
|                      Method | wordstream |      Mean |    Error |    StdDev |    Gen 0 | Allocated |
|---------------------------- |----------- |----------:|---------:|----------:|---------:|----------:|
|    **SearcherMatrixSequential** | **String[12]** | **360.41 μs** | **5.875 μs** |  **5.496 μs** | **241.2109** |    **493 KB** |
|      SearcherMatrixParallel | String[12] | 306.62 μs | 5.696 μs |  5.594 μs | 284.1797 |    573 KB |
| SearcherFlyweightSequential | String[12] | 198.96 μs | 2.405 μs |  2.132 μs |  93.0176 |    190 KB |
|   SeracherFlyweightParallel | String[12] | 183.54 μs | 3.036 μs |  2.691 μs | 115.9668 |    234 KB |
|    **SearcherMatrixSequential** |  **String[1]** |  **30.99 μs** | **0.615 μs** |  **0.732 μs** |  **20.1416** |     **41 KB** |
|      SearcherMatrixParallel |  String[1] |  49.84 μs | 0.832 μs |  0.738 μs |  28.9917 |     58 KB |
| SearcherFlyweightSequential |  String[1] |  19.82 μs | 0.288 μs |  0.241 μs |  10.2844 |     21 KB |
|   SeracherFlyweightParallel |  String[1] |  34.23 μs | 0.678 μs |  1.637 μs |  14.0991 |     28 KB |
|    **SearcherMatrixSequential** |  **String[3]** |  **82.25 μs** | **1.616 μs** |  **1.349 μs** |  **60.1807** |    **123 KB** |
|      SearcherMatrixParallel |  String[3] |  94.07 μs | 1.411 μs |  1.785 μs |  68.7256 |    139 KB |
| SearcherFlyweightSequential |  String[3] |  41.25 μs | 0.494 μs |  0.438 μs |  21.6064 |     44 KB |
|   SeracherFlyweightParallel |  String[3] |  47.67 μs | 0.917 μs |  1.056 μs |  26.0620 |     53 KB |
|    **SearcherMatrixSequential** |  **String[6]** | **179.49 μs** | **3.179 μs** |  **3.904 μs** | **120.6055** |    **246 KB** |
|      SearcherMatrixParallel |  String[6] | 174.99 μs | 3.361 μs |  3.597 μs | 150.3906 |    304 KB |
| SearcherFlyweightSequential |  String[6] |  93.24 μs | 1.566 μs |  1.307 μs |  45.1660 |     92 KB |
|   SeracherFlyweightParallel |  String[6] | 103.61 μs | 1.326 μs |  1.241 μs |  59.3262 |    120 KB |
|    **SearcherMatrixSequential** |  **String[9]** | **266.88 μs** | **5.173 μs** |  **4.839 μs** | **181.1523** |    **370 KB** |
|      SearcherMatrixParallel |  String[9] | 283.46 μs | 5.644 μs | 10.320 μs | 226.8066 |    458 KB |
| SearcherFlyweightSequential |  String[9] | 139.59 μs | 2.470 μs |  2.062 μs |  66.8945 |    137 KB |
|   SeracherFlyweightParallel |  String[9] | 142.08 μs | 2.498 μs |  2.086 μs |  84.7168 |    171 KB |
