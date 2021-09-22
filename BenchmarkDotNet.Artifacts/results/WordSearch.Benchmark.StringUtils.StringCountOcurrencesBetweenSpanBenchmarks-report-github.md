``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19042.1052 (20H2/October2020Update)
Intel Core i7-6600U CPU 2.60GHz (Skylake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=5.0.101
  [Host]     : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  DefaultJob : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT


```
|                      Method |  N |            word |       Mean |     Error |    StdDev |     Median | Allocated |
|---------------------------- |--- |---------------- |-----------:|----------:|----------:|-----------:|----------:|
|         **CountOucrrencesSpan** |  **5** |            **cold** |  **21.986 ns** | **0.3690 ns** | **0.3082 ns** |  **21.864 ns** |         **-** |
| CountOucrrencesSpanOptimist |  5 |            cold |  24.473 ns | 0.5263 ns | 0.4923 ns |  24.283 ns |         - |
|     CountOucrrencesSpanLoop |  5 |            cold |  19.246 ns | 0.3833 ns | 0.8169 ns |  19.013 ns |         - |
|         **CountOucrrencesSpan** |  **5** |           **coldx** |  **16.056 ns** | **0.3401 ns** | **0.3492 ns** |  **15.965 ns** |         **-** |
| CountOucrrencesSpanOptimist |  5 |           coldx |  26.428 ns | 0.5271 ns | 0.7726 ns |  26.214 ns |         - |
|     CountOucrrencesSpanLoop |  5 |           coldx |  17.323 ns | 0.2244 ns | 0.1874 ns |  17.394 ns |         - |
|         **CountOucrrencesSpan** |  **5** | **coldxcoldxcoldx** |   **8.642 ns** | **0.4296 ns** | **1.2187 ns** |   **8.317 ns** |         **-** |
| CountOucrrencesSpanOptimist |  5 | coldxcoldxcoldx |   9.846 ns | 0.6577 ns | 1.8549 ns |   9.057 ns |         - |
|     CountOucrrencesSpanLoop |  5 | coldxcoldxcoldx |   7.427 ns | 0.1814 ns | 0.1514 ns |   7.396 ns |         - |
|         **CountOucrrencesSpan** | **15** |            **cold** |  **54.757 ns** | **1.0241 ns** | **1.1383 ns** |  **54.616 ns** |         **-** |
| CountOucrrencesSpanOptimist | 15 |            cold |  55.467 ns | 0.6271 ns | 0.4896 ns |  55.719 ns |         - |
|     CountOucrrencesSpanLoop | 15 |            cold |  44.954 ns | 0.8658 ns | 1.7489 ns |  44.373 ns |         - |
|         **CountOucrrencesSpan** | **15** |           **coldx** |  **50.209 ns** | **0.7851 ns** | **0.6129 ns** |  **50.042 ns** |         **-** |
| CountOucrrencesSpanOptimist | 15 |           coldx |  58.446 ns | 1.1683 ns | 1.0929 ns |  58.095 ns |         - |
|     CountOucrrencesSpanLoop | 15 |           coldx |  44.532 ns | 0.9115 ns | 0.8526 ns |  44.383 ns |         - |
|         **CountOucrrencesSpan** | **15** | **coldxcoldxcoldx** |  **16.624 ns** | **0.2255 ns** | **0.1883 ns** |  **16.645 ns** |         **-** |
| CountOucrrencesSpanOptimist | 15 | coldxcoldxcoldx |  27.869 ns | 0.5948 ns | 1.2016 ns |  27.547 ns |         - |
|     CountOucrrencesSpanLoop | 15 | coldxcoldxcoldx |  18.945 ns | 0.4224 ns | 1.0038 ns |  18.468 ns |         - |
|         **CountOucrrencesSpan** | **30** |            **cold** | **103.016 ns** | **2.0759 ns** | **2.3074 ns** | **101.970 ns** |         **-** |
| CountOucrrencesSpanOptimist | 30 |            cold | 107.480 ns | 1.4439 ns | 1.1273 ns | 107.095 ns |         - |
|     CountOucrrencesSpanLoop | 30 |            cold |  85.425 ns | 1.7479 ns | 3.3256 ns |  84.565 ns |         - |
|         **CountOucrrencesSpan** | **30** |           **coldx** | **104.312 ns** | **2.0971 ns** | **2.0596 ns** | **103.889 ns** |         **-** |
| CountOucrrencesSpanOptimist | 30 |           coldx | 115.867 ns | 2.1724 ns | 2.0321 ns | 116.058 ns |         - |
|     CountOucrrencesSpanLoop | 30 |           coldx |  87.023 ns | 1.0876 ns | 0.8491 ns |  87.225 ns |         - |
|         **CountOucrrencesSpan** | **30** | **coldxcoldxcoldx** |  **34.593 ns** | **0.3593 ns** | **0.3001 ns** |  **34.542 ns** |         **-** |
| CountOucrrencesSpanOptimist | 30 | coldxcoldxcoldx |  43.535 ns | 0.7921 ns | 0.8134 ns |  43.414 ns |         - |
|     CountOucrrencesSpanLoop | 30 | coldxcoldxcoldx |  33.337 ns | 0.7040 ns | 1.7531 ns |  32.701 ns |         - |
|         **CountOucrrencesSpan** | **60** |            **cold** | **202.708 ns** | **4.0600 ns** | **8.5639 ns** | **199.918 ns** |         **-** |
| CountOucrrencesSpanOptimist | 60 |            cold | 218.309 ns | 3.0473 ns | 2.7013 ns | 218.251 ns |         - |
|     CountOucrrencesSpanLoop | 60 |            cold | 162.099 ns | 2.1489 ns | 1.6777 ns | 162.777 ns |         - |
|         **CountOucrrencesSpan** | **60** |           **coldx** | **207.162 ns** | **3.2456 ns** | **3.0359 ns** | **206.730 ns** |         **-** |
| CountOucrrencesSpanOptimist | 60 |           coldx | 225.674 ns | 3.5560 ns | 3.1523 ns | 225.247 ns |         - |
|     CountOucrrencesSpanLoop | 60 |           coldx | 176.101 ns | 3.1866 ns | 4.7695 ns | 174.994 ns |         - |
|         **CountOucrrencesSpan** | **60** | **coldxcoldxcoldx** |  **72.721 ns** | **1.0848 ns** | **1.0654 ns** |  **72.531 ns** |         **-** |
| CountOucrrencesSpanOptimist | 60 | coldxcoldxcoldx |  82.672 ns | 1.4652 ns | 1.2989 ns |  82.230 ns |         - |
|     CountOucrrencesSpanLoop | 60 | coldxcoldxcoldx |  63.165 ns | 0.7732 ns | 0.6456 ns |  63.129 ns |         - |
