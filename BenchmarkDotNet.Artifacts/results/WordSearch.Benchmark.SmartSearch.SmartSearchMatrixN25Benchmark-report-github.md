``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19042.1052 (20H2/October2020Update)
Intel Core i7-6600U CPU 2.60GHz (Skylake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=5.0.101
  [Host]     : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  DefaultJob : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT


```
|                      Method | wordstream |       Mean |     Error |    StdDev |     Median |    Gen 0 | Allocated |
|---------------------------- |----------- |-----------:|----------:|----------:|-----------:|---------:|----------:|
|    **SearcherMatrixSequential** | **String[12]** | **131.563 μs** | **2.5599 μs** | **2.6288 μs** | **131.270 μs** |  **88.8672** |    **182 KB** |
|      SearcherMatrixParallel | String[12] | 128.161 μs | 2.4460 μs | 2.2879 μs | 127.385 μs | 107.6660 |    218 KB |
| SearcherFlyweightSequential | String[12] |  69.749 μs | 1.3756 μs | 1.6376 μs |  69.250 μs |  35.1563 |     72 KB |
|   SeracherFlyweightParallel | String[12] |  84.709 μs | 1.6414 μs | 1.6856 μs |  84.598 μs |  46.1426 |     93 KB |
|    **SearcherMatrixSequential** |  **String[1]** |  **11.645 μs** | **0.2237 μs** | **0.1868 μs** |  **11.624 μs** |   **7.4615** |     **15 KB** |
|      SearcherMatrixParallel |  String[1] |  25.148 μs | 0.4917 μs | 0.5050 μs |  25.112 μs |  11.1694 |     23 KB |
| SearcherFlyweightSequential |  String[1] |   7.335 μs | 0.1181 μs | 0.1105 μs |   7.311 μs |   3.8986 |      8 KB |
|   SeracherFlyweightParallel |  String[1] |  20.203 μs | 0.4036 μs | 0.9748 μs |  19.983 μs |   5.8899 |     12 KB |
|    **SearcherMatrixSequential** |  **String[3]** |  **31.174 μs** | **0.4715 μs** | **0.6454 μs** |  **30.912 μs** |  **22.0947** |     **45 KB** |
|      SearcherMatrixParallel |  String[3] |  43.496 μs | 1.0821 μs | 3.1907 μs |  42.102 μs |  26.3062 |     53 KB |
| SearcherFlyweightSequential |  String[3] |  16.058 μs | 0.3094 μs | 0.3439 μs |  15.915 μs |   8.0872 |     17 KB |
|   SeracherFlyweightParallel |  String[3] |  30.814 μs | 0.6063 μs | 0.8887 μs |  30.835 μs |  11.1084 |     22 KB |
|    **SearcherMatrixSequential** |  **String[6]** |  **66.114 μs** | **1.1943 μs** | **1.1172 μs** |  **65.799 μs** |  **44.4336** |     **91 KB** |
|      SearcherMatrixParallel |  String[6] |  80.477 μs | 1.5269 μs | 2.6338 μs |  79.991 μs |  58.1055 |    118 KB |
| SearcherFlyweightSequential |  String[6] |  34.782 μs | 0.5069 μs | 0.4742 μs |  34.541 μs |  17.0288 |     35 KB |
|   SeracherFlyweightParallel |  String[6] |  49.906 μs | 0.9782 μs | 1.0873 μs |  49.361 μs |  24.0479 |     49 KB |
|    **SearcherMatrixSequential** |  **String[9]** |  **94.725 μs** | **1.2603 μs** | **1.0524 μs** |  **94.530 μs** |  **66.8945** |    **137 KB** |
|      SearcherMatrixParallel |  String[9] | 110.117 μs | 1.3824 μs | 1.0793 μs | 110.406 μs |  87.2803 |    177 KB |
| SearcherFlyweightSequential |  String[9] |  48.825 μs | 0.8314 μs | 0.7777 μs |  48.751 μs |  25.3906 |     52 KB |
|   SeracherFlyweightParallel |  String[9] |  67.064 μs | 1.3315 μs | 1.7313 μs |  66.715 μs |  34.3018 |     69 KB |
