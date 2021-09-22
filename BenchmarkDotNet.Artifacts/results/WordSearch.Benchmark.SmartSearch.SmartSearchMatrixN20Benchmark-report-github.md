``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19042.1052 (20H2/October2020Update)
Intel Core i7-6600U CPU 2.60GHz (Skylake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=5.0.101
  [Host]     : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  DefaultJob : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT


```
|                      Method | wordstream |       Mean |     Error |    StdDev |   Gen 0 | Allocated |
|---------------------------- |----------- |-----------:|----------:|----------:|--------:|----------:|
|    **SearcherMatrixSequential** | **String[12]** |  **92.590 μs** | **1.1414 μs** | **1.0119 μs** | **60.5469** |    **124 KB** |
|      SearcherMatrixParallel | String[12] | 100.022 μs | 1.9797 μs | 3.0232 μs | 75.3174 |    153 KB |
| SearcherFlyweightSequential | String[12] |  46.919 μs | 0.8888 μs | 0.7422 μs | 24.0479 |     49 KB |
|   SeracherFlyweightParallel | String[12] |  68.509 μs | 1.3404 μs | 3.7587 μs | 32.8369 |     67 KB |
|    **SearcherMatrixSequential** |  **String[1]** |   **8.284 μs** | **0.1375 μs** | **0.1219 μs** |  **5.0812** |     **10 KB** |
|      SearcherMatrixParallel |  String[1] |  20.691 μs | 0.3066 μs | 0.5606 μs |  7.6599 |     16 KB |
| SearcherFlyweightSequential |  String[1] |   5.068 μs | 0.0783 μs | 0.0732 μs |  2.6474 |      5 KB |
|   SeracherFlyweightParallel |  String[1] |  17.835 μs | 0.4097 μs | 1.1820 μs |  4.1504 |      8 KB |
|    **SearcherMatrixSequential** |  **String[3]** |  **22.983 μs** | **0.3344 μs** | **0.2965 μs** | **15.0146** |     **31 KB** |
|      SearcherMatrixParallel |  String[3] |  35.082 μs | 0.6832 μs | 0.8390 μs | 18.3716 |     37 KB |
| SearcherFlyweightSequential |  String[3] |  11.358 μs | 0.1808 μs | 0.1602 μs |  5.5389 |     11 KB |
|   SeracherFlyweightParallel |  String[3] |  26.228 μs | 0.5178 μs | 0.5755 μs |  8.1177 |     16 KB |
|    **SearcherMatrixSequential** |  **String[6]** |  **46.467 μs** | **0.9165 μs** | **0.9412 μs** | **30.2124** |     **62 KB** |
|      SearcherMatrixParallel |  String[6] |  59.780 μs | 1.1505 μs | 1.4129 μs | 39.5508 |     80 KB |
| SearcherFlyweightSequential |  String[6] |  23.417 μs | 0.4425 μs | 0.4346 μs | 11.6577 |     24 KB |
|   SeracherFlyweightParallel |  String[6] |  42.586 μs | 0.6970 μs | 1.0644 μs | 17.0898 |     35 KB |
|    **SearcherMatrixSequential** |  **String[9]** |  **66.205 μs** | **1.0162 μs** | **0.9506 μs** | **45.5322** |     **93 KB** |
|      SearcherMatrixParallel |  String[9] |  80.188 μs | 1.1283 μs | 1.0002 μs | 57.4951 |    116 KB |
| SearcherFlyweightSequential |  String[9] |  32.816 μs | 0.3846 μs | 0.3003 μs | 17.4561 |     36 KB |
|   SeracherFlyweightParallel |  String[9] |  55.068 μs | 0.9392 μs | 1.0816 μs | 24.9023 |     50 KB |
