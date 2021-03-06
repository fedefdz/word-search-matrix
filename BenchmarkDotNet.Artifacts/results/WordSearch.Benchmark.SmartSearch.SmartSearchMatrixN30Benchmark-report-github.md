``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19042.1052 (20H2/October2020Update)
Intel Core i7-6600U CPU 2.60GHz (Skylake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=5.0.101
  [Host]     : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  DefaultJob : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT


```
|                      Method | wordstream |      Mean |     Error |    StdDev |    Median |    Gen 0 | Allocated |
|---------------------------- |----------- |----------:|----------:|----------:|----------:|---------:|----------:|
|    **SearcherMatrixSequential** | **String[12]** | **216.96 μs** |  **8.079 μs** | **23.694 μs** | **221.71 μs** | **123.0469** |    **251 KB** |
|      SearcherMatrixParallel | String[12] | 197.55 μs |  3.950 μs |  7.223 μs | 198.36 μs | 147.2168 |    298 KB |
| SearcherFlyweightSequential | String[12] | 123.86 μs |  7.425 μs | 20.821 μs | 125.01 μs |  47.6074 |     97 KB |
|   SeracherFlyweightParallel | String[12] | 117.97 μs |  2.316 μs |  3.011 μs | 118.58 μs |  60.4248 |    122 KB |
|    **SearcherMatrixSequential** |  **String[1]** |  **19.21 μs** |  **0.844 μs** |  **2.448 μs** |  **19.86 μs** |  **10.2844** |     **21 KB** |
|      SearcherMatrixParallel |  String[1] |  34.73 μs |  0.667 μs |  0.741 μs |  34.95 μs |  15.6250 |     32 KB |
| SearcherFlyweightSequential |  String[1] |  11.88 μs |  0.493 μs |  1.455 μs |  12.13 μs |   5.2338 |     11 KB |
|   SeracherFlyweightParallel |  String[1] |  26.19 μs |  0.520 μs |  1.140 μs |  26.48 μs |   7.8735 |     16 KB |
|    **SearcherMatrixSequential** |  **String[3]** |  **50.38 μs** |  **1.885 μs** |  **5.527 μs** |  **51.56 μs** |  **30.5786** |     **63 KB** |
|      SearcherMatrixParallel |  String[3] |  60.45 μs |  1.157 μs |  1.136 μs |  60.68 μs |  36.3159 |     74 KB |
| SearcherFlyweightSequential |  String[3] |  25.55 μs |  0.921 μs |  2.700 μs |  25.76 μs |  11.1084 |     23 KB |
|   SeracherFlyweightParallel |  String[3] |  40.59 μs |  0.757 μs |  0.929 μs |  40.91 μs |  14.4043 |     29 KB |
|    **SearcherMatrixSequential** |  **String[6]** | **112.60 μs** |  **5.401 μs** | **15.839 μs** | **116.27 μs** |  **61.2793** |    **125 KB** |
|      SearcherMatrixParallel |  String[6] | 112.43 μs |  2.161 μs |  2.573 μs | 112.72 μs |  78.4912 |    159 KB |
| SearcherFlyweightSequential |  String[6] |  55.53 μs |  2.517 μs |  7.057 μs |  57.60 μs |  23.1323 |     47 KB |
|   SeracherFlyweightParallel |  String[6] |  67.72 μs |  1.341 μs |  2.887 μs |  68.70 μs |  31.1279 |     63 KB |
|    **SearcherMatrixSequential** |  **String[9]** | **185.06 μs** | **11.997 μs** | **35.184 μs** | **181.01 μs** |  **92.2852** |    **189 KB** |
|      SearcherMatrixParallel |  String[9] | 160.61 μs |  2.922 μs |  2.733 μs | 160.18 μs | 114.2578 |    232 KB |
| SearcherFlyweightSequential |  String[9] |  81.43 μs |  3.858 μs | 11.314 μs |  86.44 μs |  34.4238 |     70 KB |
|   SeracherFlyweightParallel |  String[9] |  97.43 μs |  1.941 μs |  3.646 μs |  97.68 μs |  45.4102 |     92 KB |
