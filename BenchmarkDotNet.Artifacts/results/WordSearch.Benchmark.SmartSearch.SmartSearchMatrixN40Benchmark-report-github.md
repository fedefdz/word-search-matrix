``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19042.1052 (20H2/October2020Update)
Intel Core i7-6600U CPU 2.60GHz (Skylake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=5.0.101
  [Host]     : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  DefaultJob : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT


```
|                      Method | wordstream |      Mean |    Error |    StdDev |    Median |    Gen 0 | Allocated |
|---------------------------- |----------- |----------:|---------:|----------:|----------:|---------:|----------:|
|    **SearcherMatrixSequential** | **String[12]** | **292.51 μs** | **5.776 μs** | **10.266 μs** | **289.01 μs** | **192.3828** |    **394 KB** |
|      SearcherMatrixParallel | String[12] | 305.75 μs | 8.023 μs | 23.404 μs | 313.70 μs | 232.4219 |    469 KB |
| SearcherFlyweightSequential | String[12] | 153.47 μs | 2.935 μs |  3.816 μs | 152.98 μs |  73.7305 |    151 KB |
|   SeracherFlyweightParallel | String[12] | 158.83 μs | 4.577 μs | 13.495 μs | 154.76 μs |  91.3086 |    184 KB |
|    **SearcherMatrixSequential** |  **String[1]** |  **24.89 μs** | **0.489 μs** |  **0.775 μs** |  **24.66 μs** |  **16.1133** |     **33 KB** |
|      SearcherMatrixParallel |  String[1] |  43.38 μs | 0.836 μs |  2.288 μs |  42.60 μs |  22.7051 |     46 KB |
| SearcherFlyweightSequential |  String[1] |  15.16 μs | 0.278 μs |  0.246 μs |  15.10 μs |   8.1482 |     17 KB |
|   SeracherFlyweightParallel |  String[1] |  33.25 μs | 0.657 μs |  1.549 μs |  33.65 μs |  12.2070 |     25 KB |
|    **SearcherMatrixSequential** |  **String[3]** |  **86.46 μs** | **3.867 μs** | **11.218 μs** |  **83.63 μs** |  **47.9736** |     **98 KB** |
|      SearcherMatrixParallel |  String[3] |  86.17 μs | 1.696 μs |  2.019 μs |  86.80 μs |  56.0303 |    113 KB |
| SearcherFlyweightSequential |  String[3] |  36.72 μs | 0.734 μs |  1.730 μs |  36.32 μs |  17.2119 |     35 KB |
|   SeracherFlyweightParallel |  String[3] |  48.48 μs | 0.913 μs |  1.474 μs |  48.15 μs |  21.7896 |     44 KB |
|    **SearcherMatrixSequential** |  **String[6]** | **158.99 μs** | **2.997 μs** |  **2.803 μs** | **159.19 μs** |  **96.1914** |    **197 KB** |
|      SearcherMatrixParallel |  String[6] | 179.05 μs | 3.508 μs |  3.281 μs | 178.91 μs | 123.0469 |    248 KB |
| SearcherFlyweightSequential |  String[6] |  80.99 μs | 1.577 μs |  1.549 μs |  81.25 μs |  36.0107 |     74 KB |
|   SeracherFlyweightParallel |  String[6] |  96.16 μs | 1.692 μs |  1.500 μs |  95.67 μs |  48.7061 |     98 KB |
|    **SearcherMatrixSequential** |  **String[9]** | **237.48 μs** | **4.628 μs** |  **4.752 μs** | **236.94 μs** | **144.5313** |    **296 KB** |
|      SearcherMatrixParallel |  String[9] | 233.11 μs | 4.433 μs |  6.067 μs | 231.14 μs | 181.3965 |    366 KB |
| SearcherFlyweightSequential |  String[9] | 121.56 μs | 2.420 μs |  3.060 μs | 120.77 μs |  53.3447 |    109 KB |
|   SeracherFlyweightParallel |  String[9] | 134.12 μs | 2.192 μs |  2.050 μs | 134.10 μs |  69.8242 |    141 KB |
