``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19042.1052 (20H2/October2020Update)
Intel Core i7-6600U CPU 2.60GHz (Skylake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=5.0.101
  [Host]     : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  DefaultJob : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT


```
|                      Method | wordstream |      Mean |     Error |    StdDev |    Median |    Gen 0 | Allocated |
|---------------------------- |----------- |----------:|----------:|----------:|----------:|---------:|----------:|
|    **SearcherMatrixSequential** | **String[12]** | **231.79 μs** |  **3.801 μs** |  **3.174 μs** | **231.62 μs** | **156.0059** |    **319 KB** |
|      SearcherMatrixParallel | String[12] | 200.05 μs |  2.532 μs |  2.368 μs | 199.54 μs | 189.4531 |    384 KB |
| SearcherFlyweightSequential | String[12] | 117.81 μs |  1.578 μs |  1.476 μs | 117.96 μs |  60.4248 |    123 KB |
|   SeracherFlyweightParallel | String[12] | 118.37 μs |  2.145 μs |  1.791 μs | 118.26 μs |  75.0732 |    152 KB |
|    **SearcherMatrixSequential** |  **String[1]** |  **19.28 μs** |  **0.317 μs** |  **0.365 μs** |  **19.20 μs** |  **13.0310** |     **27 KB** |
|      SearcherMatrixParallel |  String[1] |  35.74 μs |  0.697 μs |  0.906 μs |  35.69 μs |  19.1040 |     39 KB |
| SearcherFlyweightSequential |  String[1] |  12.12 μs |  0.127 μs |  0.119 μs |  12.15 μs |   6.6223 |     14 KB |
|   SeracherFlyweightParallel |  String[1] |  25.65 μs |  0.429 μs |  0.358 μs |  25.66 μs |   9.5825 |     19 KB |
|    **SearcherMatrixSequential** |  **String[3]** |  **54.22 μs** |  **0.887 μs** |  **0.741 μs** |  **54.18 μs** |  **38.8794** |     **79 KB** |
|      SearcherMatrixParallel |  String[3] |  62.80 μs |  2.063 μs |  6.082 μs |  61.22 μs |  45.8374 |     93 KB |
| SearcherFlyweightSequential |  String[3] |  27.05 μs |  0.535 μs |  0.937 μs |  26.79 μs |  13.9160 |     28 KB |
|   SeracherFlyweightParallel |  String[3] |  36.56 μs |  0.709 μs |  1.062 μs |  36.35 μs |  16.9067 |     34 KB |
|    **SearcherMatrixSequential** |  **String[6]** | **111.19 μs** |  **1.686 μs** |  **1.408 μs** | **110.86 μs** |  **77.8809** |    **159 KB** |
|      SearcherMatrixParallel |  String[6] | 132.28 μs |  3.527 μs | 10.400 μs | 134.99 μs |  97.6563 |    198 KB |
| SearcherFlyweightSequential |  String[6] |  60.10 μs |  1.195 μs |  3.291 μs |  58.62 μs |  29.2969 |     60 KB |
|   SeracherFlyweightParallel |  String[6] |  70.19 μs |  1.371 μs |  1.683 μs |  69.83 μs |  39.5508 |     80 KB |
|    **SearcherMatrixSequential** |  **String[9]** | **170.49 μs** |  **1.989 μs** |  **1.763 μs** | **170.66 μs** | **117.1875** |    **239 KB** |
|      SearcherMatrixParallel |  String[9] | 178.23 μs |  5.131 μs | 15.128 μs | 176.05 μs | 141.8457 |    287 KB |
| SearcherFlyweightSequential |  String[9] | 111.10 μs | 10.816 μs | 30.858 μs |  99.65 μs |  43.5791 |     89 KB |
|   SeracherFlyweightParallel |  String[9] | 112.21 μs |  2.193 μs |  3.663 μs | 112.08 μs |  57.6172 |    116 KB |
