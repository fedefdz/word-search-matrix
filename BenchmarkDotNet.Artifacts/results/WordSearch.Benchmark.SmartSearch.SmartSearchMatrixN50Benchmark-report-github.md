``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19042.1052 (20H2/October2020Update)
Intel Core i7-6600U CPU 2.60GHz (Skylake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=5.0.101
  [Host]     : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  DefaultJob : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT


```
|                      Method | wordstream |      Mean |    Error |    StdDev |    Median |    Gen 0 | Allocated |
|---------------------------- |----------- |----------:|---------:|----------:|----------:|---------:|----------:|
|    **SearcherMatrixSequential** | **String[12]** | **438.33 μs** | **8.322 μs** | **10.822 μs** | **436.75 μs** | **295.4102** |    **604 KB** |
|      SearcherMatrixParallel | String[12] | 388.70 μs | 7.741 μs |  9.215 μs | 389.18 μs | 354.0039 |    713 KB |
| SearcherFlyweightSequential | String[12] | 231.30 μs | 4.042 μs |  3.584 μs | 231.00 μs | 112.7930 |    231 KB |
|   SeracherFlyweightParallel | String[12] | 224.31 μs | 5.012 μs | 14.777 μs | 219.55 μs | 137.2070 |    277 KB |
|    **SearcherMatrixSequential** |  **String[1]** |  **39.84 μs** | **1.174 μs** |  **3.291 μs** |  **38.79 μs** |  **24.6582** |     **50 KB** |
|      SearcherMatrixParallel |  String[1] |  57.46 μs | 1.141 μs |  1.401 μs |  57.39 μs |  34.3628 |     69 KB |
| SearcherFlyweightSequential |  String[1] |  25.47 μs | 1.419 μs |  3.907 μs |  23.80 μs |  12.4207 |     25 KB |
|   SeracherFlyweightParallel |  String[1] |  35.94 μs | 0.712 μs |  0.974 μs |  35.50 μs |  16.2964 |     33 KB |
|    **SearcherMatrixSequential** |  **String[3]** |  **99.91 μs** | **1.924 μs** |  **2.821 μs** |  **99.27 μs** |  **73.7305** |    **151 KB** |
|      SearcherMatrixParallel |  String[3] |  99.61 μs | 1.983 μs |  1.948 μs |  99.76 μs |  85.9375 |    173 KB |
| SearcherFlyweightSequential |  String[3] |  49.86 μs | 0.983 μs |  1.616 μs |  49.23 μs |  26.3672 |     54 KB |
|   SeracherFlyweightParallel |  String[3] |  60.14 μs | 0.830 μs |  0.736 μs |  60.14 μs |  31.7993 |     64 KB |
|    **SearcherMatrixSequential** |  **String[6]** | **212.91 μs** | **3.587 μs** |  **2.995 μs** | **212.75 μs** | **147.7051** |    **302 KB** |
|      SearcherMatrixParallel |  String[6] | 205.68 μs | 3.114 μs |  2.761 μs | 206.37 μs | 183.8379 |    370 KB |
| SearcherFlyweightSequential |  String[6] | 111.63 μs | 1.766 μs |  2.357 μs | 111.37 μs |  54.9316 |    112 KB |
|   SeracherFlyweightParallel |  String[6] | 126.68 μs | 3.156 μs |  9.306 μs | 123.89 μs |  71.1670 |    144 KB |
|    **SearcherMatrixSequential** |  **String[9]** | **318.13 μs** | **6.237 μs** |  **5.529 μs** | **317.94 μs** | **221.6797** |    **453 KB** |
|      SearcherMatrixParallel |  String[9] | 314.67 μs | 6.110 μs | 14.520 μs | 309.35 μs | 270.5078 |    545 KB |
| SearcherFlyweightSequential |  String[9] | 163.31 μs | 3.255 μs |  5.256 μs | 162.73 μs |  81.2988 |    166 KB |
|   SeracherFlyweightParallel |  String[9] | 166.77 μs | 3.323 μs |  7.961 μs | 164.79 μs | 104.4922 |    211 KB |
