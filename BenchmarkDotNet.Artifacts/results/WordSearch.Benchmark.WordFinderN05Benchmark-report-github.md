``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19042.1052 (20H2/October2020Update)
Intel Core i7-6600U CPU 2.60GHz (Skylake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=5.0.101
  [Host]     : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  DefaultJob : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT


```
| Method | wordstream |     Mean |     Error |    StdDev |  Gen 0 | Allocated |
|------- |----------- |---------:|----------:|----------:|-------:|----------:|
|   **Find** | **String[12]** | **8.023 μs** | **0.1478 μs** | **0.2882 μs** | **2.8381** |      **6 KB** |
|   **Find** |  **String[1]** | **1.477 μs** | **0.0296 μs** | **0.0304 μs** | **0.7038** |      **1 KB** |
|   **Find** |  **String[3]** | **3.546 μs** | **0.0706 μs** | **0.1427 μs** | **1.2512** |      **3 KB** |
|   **Find** |  **String[6]** | **4.913 μs** | **0.0946 μs** | **0.1754 μs** | **1.7548** |      **4 KB** |
|   **Find** |  **String[9]** | **5.009 μs** | **0.0914 μs** | **0.0714 μs** | **2.0065** |      **4 KB** |
