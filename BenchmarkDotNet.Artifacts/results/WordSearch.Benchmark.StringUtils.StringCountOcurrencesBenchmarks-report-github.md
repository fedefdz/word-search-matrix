``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19042.1052 (20H2/October2020Update)
Intel Core i7-6600U CPU 2.60GHz (Skylake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=5.0.101
  [Host]     : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  DefaultJob : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT


```
|                 Method |  N |                 word |         Mean |      Error |      StdDev |       Median |  Gen 0 | Allocated |
|----------------------- |--- |--------------------- |-------------:|-----------:|------------:|-------------:|-------:|----------:|
|        **CountOucrrences** |  **8** |                   **ab** |    **60.124 ns** |  **1.2296 ns** |   **1.8023 ns** |    **60.071 ns** | **0.0153** |      **32 B** |
|    CountOucrrencesSpan |  8 |                   ab |    43.472 ns |  0.8832 ns |   1.7434 ns |    43.079 ns |      - |         - |
| CountOucrrencesPattern |  8 |                   ab |   454.749 ns |  9.1077 ns |  11.1851 ns |   450.867 ns | 0.2675 |     560 B |
|        **CountOucrrences** |  **8** |             **abcdabcd** |    **42.666 ns** |  **0.7053 ns** |   **0.5506 ns** |    **42.537 ns** | **0.0114** |      **24 B** |
|    CountOucrrencesSpan |  8 |             abcdabcd |    16.032 ns |  0.3451 ns |   0.3059 ns |    15.977 ns |      - |         - |
| CountOucrrencesPattern |  8 |             abcdabcd |   286.704 ns |  5.7009 ns |   8.8757 ns |   285.424 ns | 0.1683 |     352 B |
|        **CountOucrrences** |  **8** |     **abcdabcdabcdabcd** |     **7.863 ns** |  **0.1793 ns** |   **0.3140 ns** |     **7.760 ns** |      **-** |         **-** |
|    CountOucrrencesSpan |  8 |     abcdabcdabcdabcd |     7.475 ns |  0.1182 ns |   0.0987 ns |     7.462 ns |      - |         - |
| CountOucrrencesPattern |  8 |     abcdabcdabcdabcd |    80.691 ns |  1.6613 ns |   2.7295 ns |    80.125 ns | 0.0421 |      88 B |
|        **CountOucrrences** |  **8** | **abcda(...)dabcd [32]** |     **7.706 ns** |  **0.1877 ns** |   **0.1756 ns** |     **7.672 ns** |      **-** |         **-** |
|    CountOucrrencesSpan |  8 | abcda(...)dabcd [32] |     7.522 ns |  0.1623 ns |   0.1355 ns |     7.506 ns |      - |         - |
| CountOucrrencesPattern |  8 | abcda(...)dabcd [32] |    81.120 ns |  1.6134 ns |   2.0979 ns |    80.378 ns | 0.0421 |      88 B |
|        **CountOucrrences** | **16** |                   **ab** |   **105.840 ns** |  **2.3038 ns** |   **6.3454 ns** |   **103.655 ns** | **0.0191** |      **40 B** |
|    CountOucrrencesSpan | 16 |                   ab |    78.173 ns |  1.8671 ns |   5.2966 ns |    76.530 ns |      - |         - |
| CountOucrrencesPattern | 16 |                   ab |   796.998 ns | 15.7713 ns |  27.2047 ns |   790.595 ns | 0.4663 |     976 B |
|        **CountOucrrences** | **16** |             **abcdabcd** |    **62.323 ns** |  **1.2850 ns** |   **1.1391 ns** |    **62.284 ns** | **0.0114** |      **24 B** |
|    CountOucrrencesSpan | 16 |             abcdabcd |    31.745 ns |  0.6384 ns |   0.5972 ns |    31.707 ns |      - |         - |
| CountOucrrencesPattern | 16 |             abcdabcd |   487.813 ns |  9.6479 ns |   9.4756 ns |   486.174 ns | 0.2670 |     560 B |
|        **CountOucrrences** | **16** |     **abcdabcdabcdabcd** |    **54.207 ns** |  **1.0550 ns** |   **1.2559 ns** |    **53.861 ns** | **0.0114** |      **24 B** |
|    CountOucrrencesSpan | 16 |     abcdabcdabcdabcd |    16.745 ns |  0.2816 ns |   0.2351 ns |    16.674 ns |      - |         - |
| CountOucrrencesPattern | 16 |     abcdabcdabcdabcd |   319.699 ns |  5.8917 ns |  11.0660 ns |   317.732 ns | 0.1683 |     352 B |
|        **CountOucrrences** | **16** | **abcda(...)dabcd [32]** |     **7.868 ns** |  **0.1872 ns** |   **0.1563 ns** |     **7.883 ns** |      **-** |         **-** |
|    CountOucrrencesSpan | 16 | abcda(...)dabcd [32] |     7.597 ns |  0.1832 ns |   0.1530 ns |     7.604 ns |      - |         - |
| CountOucrrencesPattern | 16 | abcda(...)dabcd [32] |    85.928 ns |  1.7543 ns |   1.6410 ns |    85.741 ns | 0.0421 |      88 B |
|        **CountOucrrences** | **64** |                   **ab** |   **379.474 ns** |  **7.3341 ns** |   **8.7307 ns** |   **377.002 ns** | **0.0420** |      **88 B** |
|    CountOucrrencesSpan | 64 |                   ab |   305.677 ns |  6.1426 ns |  14.5986 ns |   301.256 ns |      - |         - |
| CountOucrrencesPattern | 64 |                   ab | 2,951.095 ns | 54.4652 ns | 124.0448 ns | 2,923.082 ns | 1.7700 |   3,712 B |
|        **CountOucrrences** | **64** |             **abcdabcd** |   **184.984 ns** |  **3.7313 ns** |   **7.5373 ns** |   **183.118 ns** | **0.0114** |      **24 B** |
|    CountOucrrencesSpan | 64 |             abcdabcd |   145.813 ns |  2.9455 ns |   5.0016 ns |   144.117 ns |      - |         - |
| CountOucrrencesPattern | 64 |             abcdabcd | 1,698.263 ns | 31.8145 ns |  71.1576 ns | 1,674.502 ns | 0.9060 |   1,896 B |
|        **CountOucrrences** | **64** |     **abcdabcdabcdabcd** |   **145.726 ns** |  **2.7896 ns** |   **3.1007 ns** |   **144.706 ns** | **0.0114** |      **24 B** |
|    CountOucrrencesSpan | 64 |     abcdabcdabcdabcd |    71.874 ns |  1.4200 ns |   1.4583 ns |    71.702 ns |      - |         - |
| CountOucrrencesPattern | 64 |     abcdabcdabcdabcd |   985.573 ns | 16.7419 ns |  13.9802 ns |   982.708 ns | 0.4654 |     976 B |
|        **CountOucrrences** | **64** | **abcda(...)dabcd [32]** |   **127.470 ns** |  **1.4692 ns** |   **1.2268 ns** |   **127.080 ns** | **0.0114** |      **24 B** |
|    CountOucrrencesSpan | 64 | abcda(...)dabcd [32] |    32.913 ns |  0.6540 ns |   0.5797 ns |    32.889 ns |      - |         - |
| CountOucrrencesPattern | 64 | abcda(...)dabcd [32] |   688.198 ns | 12.5080 ns |  20.8980 ns |   683.345 ns | 0.2670 |     560 B |
