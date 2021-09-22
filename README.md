# WordSearch
Word Search receives a square matrix N of characters and a flow of words to search in it, returning a ranking of the ten most reptiles in descending order of occurrences.

**Limitations**:
- N <= 65 characteres.
- search is sensitive case.

## Organization of the solution
`Framework net5.0`

```bash
.
├── bench
│   └── WordSearch.Benchmark
├── data
├── src
│   ├── WordSearch
│   └── WordSearch.Sample
└── test
    └── WordSearch.Tests
```
**`bench/WordSerach.Benchmark`** classes benchmark from which the performance analysis of the use of resources is made and it is chosen which classes and methods to use in different contexts.

**`data`** contains the files that are used as input to execute the example of using the `WordFinder.cs` class

**`src/WordSerach`** project that defines the `WordFinder.cs` class and other classes to be able to search for a stream of words within an array of characters.

**`src/WordSerach.Sample`** console project that makes use of the `WordeFinder.cs` class

**`test/WordSerach.Tests`** unit tests project


---
## WordSearch project
It contains the core of the required functionality, the most relevant classes are:
- `WordFinder` When creating an instance, a flyweight matrix is created on which the search for word occurrences is performed when the WordFinder method is invoked `WordFinder.Find(IEnumerable<string> wordstream)`. This method to carry out the search selects which is the best sequential or parallel search engine according to the context.
- `Matrix` class that maintains a square matrix N and is responsible for counting word occurrences by columns or rows. For a better memory use `ReadOnlySpan <T>` is used. For more inforation [An Iintroduction to optimising code using Span<T>](https://www.stevejgordon.co.uk/an-introduction-to-optimising-code-using-span-t).
- `MatrixFlyweight` specialization of Matrix.cs that manages a dictionary with the locations of the letters in the matrix to improve speed when counting the occurrences of a word. This dictionary is a reduced adaptation of flyweight pattern.
- `StringUtils` string extensions to count ocurrences of a word.
- `MatrixSmartSearcherBaseSequential<T>` search for words in a matrix doing a sequential sweep for each row and column, your responsibility is also to look for the words in reverse order and avoid searches that do not generate results such as words longer than the size of the matrix.
- `MatrixSmartSearcherBaseParallel<T>` searches for words in a matrix for each row and column but these searches are in parallel, taking into account the concurrence in the count of occurrences.
- `MatrixSmartSeracherStrategy` selects the most optimal search engine for a context given by the size of the matrix and the number of words to search. Selection is based on the result of the benchmark of specialized search engines.

---
## WordSearch.Benchmark project
The benchmark is based on runtime and memory usage. To facilitate the work [BenchmarkDotNet](https://benchmarkdotnet.org/articles/overview.html) was used. To see a list of the benchmarks designed, execute the command `dotnet run --project bench/WordSearch.Benchmark/  -c Release --list tree`
```bash
WordSearch
 └─Benchmark
    ├─WordFinderN05Benchmark    
    ├─WordFinderN10Benchmark    
    ├─WordFinderN15Benchmark    
    ├─WordFinderN20Benchmark    
    ├─WordFinderN25Benchmark    
    ├─WordFinderN30Benchmark    
    ├─WordFinderN35Benchmark    
    ├─WordFinderN40Benchmark    
    ├─WordFinderN45Benchmark    
    ├─WordFinderN50Benchmark    
    ├─WordFinderN60Benchmark    
    ├─SmartSearch
    │  ├─SmartSearchMatrixN05Benchmark    
    │  ├─SmartSearchMatrixN10Benchmark    
    │  ├─SmartSearchMatrixN15Benchmark    
    │  ├─SmartSearchMatrixN20Benchmark    
    │  ├─SmartSearchMatrixN25Benchmark    
    │  ├─SmartSearchMatrixN30Benchmark    
    │  ├─SmartSearchMatrixN35Benchmark    
    │  ├─SmartSearchMatrixN40Benchmark    
    │  ├─SmartSearchMatrixN45Benchmark    
    │  ├─SmartSearchMatrixN50Benchmark    
    │  └─SmartSearchMatrixN60Benchmark    
    └─StringUtils
       ├─StringCountOcurrencesBenchmarks       
       ├─StringCountOcurrencesBetweenSpanBenchmarks       
       └─StringCountOcurrenceSpanRecursiveBenchmarks          
```
The most important benchmarks are:
- **`SmartSearchMatrixN*Benchmark`** compares sequential and parallel search engines on a `Matrix` and `MatrixFlywieght` class with different sizes of N and length of stream words.
  ```
    ├─SmartSearchMatrixN05Benchmark    
    ├─SmartSearchMatrixN10Benchmark    
    ├─SmartSearchMatrixN15Benchmark    
    ├─SmartSearchMatrixN20Benchmark    
    ├─SmartSearchMatrixN25Benchmark    
    ├─SmartSearchMatrixN30Benchmark    
    ├─SmartSearchMatrixN35Benchmark    
    ├─SmartSearchMatrixN40Benchmark    
    ├─SmartSearchMatrixN45Benchmark    
    ├─SmartSearchMatrixN50Benchmark    
    └─SmartSearchMatrixN60Benchmark    
  ```
- **`StringCountOcurrences*`** compares the methods that count the occurrences of a word in a `string`
  ```
  ├─StringCountOcurrencesBenchmarks       
  ├─StringCountOcurrencesBetweenSpanBenchmarks       
  └─StringCountOcurrenceSpanRecursiveBenchmarks      
  ``` 

### **Analysis of the most optimal search engine**
---
From the result of the execution of the benchmarks we see that for:
- N < 45 should be used `MatrixFlyweightSmartSearcherSequential`
- N >= 45 and N < 60 when wordstream < 12 should be used `MatrixFlyweightSmartSearcherSequential`
- N = 60 when wordstream = 1 should be used `MatrixFlyweightSmartSearcherSequential`
- N = 60 when wordstream > 1 should be used `MatrixFlyweightSmartSearcherParallel`
- N > 60 when wordstream> 1 should be used `MatrixFlyweightSmartSearcherParallel`

The execution of the following command runs the SmartSearchMatrixN05Benchmark benchmark for an N = 5 matrix with wordstream of different lengths, the result is shown in the following table with the runtimes and the managed memory HEAP (Allocated) and the times that garbage collector performs at collections (Gen 0).
The mark `*` is added manually on the right side of the table to indicate which is the winning search engine for each context.

> #### NOTE:
> The full copy of results are `bench/BenchmarkDotNet.Artifacts` with a detailed iterations 
> and in `./BenchmarkDotNet.Artifacts/results` a resume of each benchmarks.
> 
> Execution results are saved in current directory in `BenchmarkDotNet.Artifacts` folder

> #### Warning:
> Benchmark execution takes 15~25 minutes.

`dotnet run --project bench/WordSearch.Benchmark/  -c Release --filter *SmartSearchMatrixN05Benchmark* --memory`

```bash
enchmarkDotNet=v0.13.1, OS=Windows 10.0.19042.1052 (20H2/October2020Update)
Intel Core i7-6600U CPU 2.60GHz (Skylake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=5.0.101
  [Host]     : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  DefaultJob : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT


|                      Method | wordstream |      Mean |     Error |    StdDev |    Median |  Gen 0 | Allocated |
|---------------------------- |----------- |----------:|----------:|----------:|----------:|-------:|----------:|
|    SearcherMatrixSequential | String[12] |  8.883 μs | 0.1596 μs | 0.2185 μs |  8.845 μs | 5.1575 |     11 KB |
|      SearcherMatrixParallel | String[12] | 28.665 μs | 0.8525 μs | 2.4596 μs | 27.937 μs | 8.4839 |     17 KB |
| SearcherFlyweightSequential | String[12] |  6.786 μs | 0.1278 μs | 0.1195 μs |  6.751 μs | 2.6779 |      5 KB |* sequential
|   SeracherFlyweightParallel | String[12] | 24.462 μs | 0.4643 μs | 1.0762 μs | 24.260 μs | 5.9204 |     12 KB |
|    SearcherMatrixSequential |  String[1] |  1.439 μs | 0.0258 μs | 0.0229 μs |  1.436 μs | 0.8869 |      2 KB |
|      SearcherMatrixParallel |  String[1] |  7.741 μs | 0.1580 μs | 0.4559 μs |  7.655 μs | 2.0447 |      4 KB |
| SearcherFlyweightSequential |  String[1] |  1.196 μs | 0.0239 μs | 0.0461 μs |  1.183 μs | 0.5760 |      1 KB |* sequential
|   SeracherFlyweightParallel |  String[1] |  6.902 μs | 0.1379 μs | 0.3935 μs |  6.824 μs | 1.6632 |      3 KB |
|    SearcherMatrixSequential |  String[3] |  4.525 μs | 0.2831 μs | 0.7749 μs |  4.157 μs | 2.3956 |      5 KB |
|      SearcherMatrixParallel |  String[3] | 22.213 μs | 0.4741 μs | 1.3980 μs | 22.206 μs | 4.3335 |      9 KB |
| SearcherFlyweightSequential |  String[3] |  4.929 μs | 0.4720 μs | 1.3918 μs |  4.667 μs | 1.0910 |      2 KB |
|   SeracherFlyweightParallel |  String[3] | 19.280 μs | 0.5458 μs | 1.6006 μs | 19.463 μs | 2.9907 |      6 KB |
|    SearcherMatrixSequential |  String[6] |  9.444 μs | 0.7784 μs | 2.2950 μs |  9.567 μs | 3.3112 |      7 KB |* sequential
|      SearcherMatrixParallel |  String[6] | 24.558 μs | 0.7684 μs | 2.2657 μs | 24.310 μs | 5.7983 |     12 KB |
| SearcherFlyweightSequential |  String[6] |  4.530 μs | 0.0875 μs | 0.1255 μs |  4.501 μs | 1.6251 |      3 KB |
|   SeracherFlyweightParallel |  String[6] | 16.544 μs | 0.3288 μs | 0.3075 μs | 16.485 μs | 4.0131 |      8 KB |
|    SearcherMatrixSequential |  String[9] |  5.977 μs | 0.1131 μs | 0.0883 μs |  5.958 μs | 3.5629 |      7 KB |* sequential
|      SearcherMatrixParallel |  String[9] | 22.747 μs | 0.5524 μs | 1.5848 μs | 22.458 μs | 5.8899 |     12 KB |
| SearcherFlyweightSequential |  String[9] |  4.572 μs | 0.0854 μs | 0.0713 μs |  4.544 μs | 1.8768 |      4 KB |
|   SeracherFlyweightParallel |  String[9] | 18.791 μs | 0.7997 μs | 2.3200 μs | 18.200 μs | 4.1199 |      8 KB |

``` 
The following tables only show the winning rows for ease of reading.

`dotnet run --project bench/WordSearch.Benchmark/  -c Release --filter *SmartSearchMatrixN10Benchmark* --memory`
```bash
|                      Method | wordstream |      Mean |     Error |    StdDev |   Gen 0 | Allocated |
|---------------------------- |----------- |----------:|----------:|----------:|--------:|----------:|
| SearcherFlyweightSequential | String[12] | 15.596 μs | 0.2332 μs | 0.2181 μs |  7.8125 |     16 KB |
| SearcherFlyweightSequential |  String[1] |  2.024 μs | 0.0399 μs | 0.0333 μs |  1.1139 |      2 KB |
| SearcherFlyweightSequential |  String[3] |  4.994 μs | 0.0871 μs | 0.0772 μs |  2.3041 |      5 KB |
| SearcherFlyweightSequential |  String[6] | 10.443 μs | 0.1834 μs | 0.4393 μs |  4.8676 |     10 KB |
| SearcherFlyweightSequential |  String[9] | 10.481 μs | 0.2000 μs | 0.2600 μs |  5.1270 |     10 KB |
```

`dotnet run --project bench/WordSearch.Benchmark/  -c Release --filter *SmartSearchMatrixN15Benchmark* --memory`
```bash
|                      Method | wordstream |      Mean |     Error |    StdDev |    Median |   Gen 0 | Allocated |
|---------------------------- |----------- |----------:|----------:|----------:|----------:|--------:|----------:|
| SearcherFlyweightSequential | String[12] | 32.042 μs | 0.5969 μs | 0.5862 μs | 31.945 μs | 16.6016 |     34 KB |
| SearcherFlyweightSequential |  String[1] |  3.186 μs | 0.0501 μs | 0.0445 μs |  3.176 μs |  1.8044 |      4 KB |
| SearcherFlyweightSequential |  String[3] |  7.365 μs | 0.1253 μs | 0.1046 μs |  7.361 μs |  3.7079 |      8 KB |
| SearcherFlyweightSequential |  String[6] | 15.738 μs | 0.2579 μs | 0.2153 μs | 15.695 μs |  7.9956 |     16 KB |
| SearcherFlyweightSequential |  String[9] | 22.447 μs | 0.4402 μs | 0.4710 μs | 22.381 μs | 12.1155 |     25 KB |
```

`dotnet run --project bench/WordSearch.Benchmark/  -c Release --filter *SmartSearchMatrixN20Benchmark* --memory`
```bash
|                      Method | wordstream |       Mean |     Error |    StdDev |   Gen 0 | Allocated |
|---------------------------- |----------- |-----------:|----------:|----------:|--------:|----------:|
| SearcherFlyweightSequential | String[12] |  46.919 μs | 0.8888 μs | 0.7422 μs | 24.0479 |     49 KB |
| SearcherFlyweightSequential |  String[1] |   5.068 μs | 0.0783 μs | 0.0732 μs |  2.6474 |      5 KB |
| SearcherFlyweightSequential |  String[3] |  11.358 μs | 0.1808 μs | 0.1602 μs |  5.5389 |     11 KB |
| SearcherFlyweightSequential |  String[6] |  23.417 μs | 0.4425 μs | 0.4346 μs | 11.6577 |     24 KB |
| SearcherFlyweightSequential |  String[9] |  32.816 μs | 0.3846 μs | 0.3003 μs | 17.4561 |     36 KB |
```

`SmartSearchMatrixN25Benchmark` `SmartSearchMatrixN30Benchmark` `SmartSearchMatrixN35Benchmark` `SmartSearchMatrixN40Benchmark` show the same winners so it shows the results of `SmartSearchMatrixN45Benchmark` onwards

`dotnet run --project bench/WordSearch.Benchmark/  -c Release --filter *SmartSearchMatrixN45Benchmark* --memory`
```bash
|                      Method | wordstream |      Mean |    Error |    StdDev |    Gen 0 | Allocated |
|---------------------------- |----------- |----------:|---------:|----------:|---------:|----------:|
|   SeracherFlyweightParallel | String[12] | 183.54 μs | 3.036 μs |  2.691 μs | 115.9668 |    234 KB |* parallel
| SearcherFlyweightSequential |  String[1] |  19.82 μs | 0.288 μs |  0.241 μs |  10.2844 |     21 KB |* sequential
| SearcherFlyweightSequential |  String[3] |  41.25 μs | 0.494 μs |  0.438 μs |  21.6064 |     44 KB |* sequential
| SearcherFlyweightSequential |  String[6] |  93.24 μs | 1.566 μs |  1.307 μs |  45.1660 |     92 KB |* sequential
| SearcherFlyweightSequential |  String[9] | 139.59 μs | 2.470 μs |  2.062 μs |  66.8945 |    137 KB |* sequential
```

`dotnet run --project bench/WordSearch.Benchmark/  -c Release --filter *SmartSearchMatrixN50Benchmark* --memory`
```bash
|                      Method | wordstream |      Mean |    Error |    StdDev |    Median |    Gen 0 | Allocated |
|---------------------------- |----------- |----------:|---------:|----------:|----------:|---------:|----------:|
|   SeracherFlyweightParallel | String[12] | 224.31 μs | 5.012 μs | 14.777 μs | 219.55 μs | 137.2070 |    277 KB |* parallel
| SearcherFlyweightSequential |  String[1] |  25.47 μs | 1.419 μs |  3.907 μs |  23.80 μs |  12.4207 |     25 KB |* sequential
| SearcherFlyweightSequential |  String[3] |  49.86 μs | 0.983 μs |  1.616 μs |  49.23 μs |  26.3672 |     54 KB |* sequential
| SearcherFlyweightSequential |  String[6] | 111.63 μs | 1.766 μs |  2.357 μs | 111.37 μs |  54.9316 |    112 KB |* sequential
| SearcherFlyweightSequential |  String[9] | 163.31 μs | 3.255 μs |  5.256 μs | 162.73 μs |  81.2988 |    166 KB |* sequential
```

`dotnet run --project bench/WordSearch.Benchmark/  -c Release --filter *SmartSearchMatrixN60Benchmark* --memory`
```bash
|                      Method | wordstream |      Mean |     Error |    StdDev |    Median |    Gen 0 | Allocated |
|---------------------------- |----------- |----------:|----------:|----------:|----------:|---------:|----------:|
|   SeracherFlyweightParallel | String[12] | 285.53 μs |  5.534 μs |  5.921 μs | 283.03 μs | 188.9648 |    381 KB |* parallel
| SearcherFlyweightSequential |  String[1] |  33.12 μs |  0.500 μs |  0.443 μs |  32.98 μs |  16.7236 |     34 KB |* sequential
|   SeracherFlyweightParallel |  String[3] |  76.66 μs |  1.530 μs |  1.880 μs |  76.41 μs |  41.3818 |     83 KB |* parallel
|   SeracherFlyweightParallel |  String[6] | 166.60 μs |  3.263 μs |  4.575 μs | 166.91 μs |  94.2383 |    190 KB |* parallel
|   SeracherFlyweightParallel |  String[9] | 223.87 μs |  4.388 μs |  8.558 μs | 221.19 μs | 136.2305 |    274 KB |* parallel
```

### **Analysis of the most optimal ocurrences word counter**
---
From the result of the execution of the benchmarks we see that 
`StringUtils.CountOcurrencesSpanLoop(ReadOnlySpan<char> source, ReadOnlySpan<char> word)` is the winner.

`dotnet run --project bench/WordSearch.Benchmark/  -c Release --filter *StringCountOcurrencesBenchmarks* --memory` shows that use Span<T> is more optimal to managed memory. `N` is length of a string and `word` is the pattern to count ocurrences.

```bash
|                 Method |  N |                 word |         Mean |      Error |      StdDev |       Median |  Gen 0 | Allocated |
|----------------------- |--- |--------------------- |-------------:|-----------:|------------:|-------------:|-------:|----------:|
|        CountOucrrences |  8 |                   ab |    60.124 ns |  1.2296 ns |   1.8023 ns |    60.071 ns | 0.0153 |      32 B |
|    CountOucrrencesSpan |  8 |                   ab |    43.472 ns |  0.8832 ns |   1.7434 ns |    43.079 ns |      - |         - |*
| CountOucrrencesPattern |  8 |                   ab |   454.749 ns |  9.1077 ns |  11.1851 ns |   450.867 ns | 0.2675 |     560 B |
|        CountOucrrences |  8 |             abcdabcd |    42.666 ns |  0.7053 ns |   0.5506 ns |    42.537 ns | 0.0114 |      24 B |
|    CountOucrrencesSpan |  8 |             abcdabcd |    16.032 ns |  0.3451 ns |   0.3059 ns |    15.977 ns |      - |         - |*
| CountOucrrencesPattern |  8 |             abcdabcd |   286.704 ns |  5.7009 ns |   8.8757 ns |   285.424 ns | 0.1683 |     352 B |
|        CountOucrrences |  8 |     abcdabcdabcdabcd |     7.863 ns |  0.1793 ns |   0.3140 ns |     7.760 ns |      - |         - |
|    CountOucrrencesSpan |  8 |     abcdabcdabcdabcd |     7.475 ns |  0.1182 ns |   0.0987 ns |     7.462 ns |      - |         - |*
| CountOucrrencesPattern |  8 |     abcdabcdabcdabcd |    80.691 ns |  1.6613 ns |   2.7295 ns |    80.125 ns | 0.0421 |      88 B |
|        CountOucrrences |  8 | abcda(...)dabcd [32] |     7.706 ns |  0.1877 ns |   0.1756 ns |     7.672 ns |      - |         - |
|    CountOucrrencesSpan |  8 | abcda(...)dabcd [32] |     7.522 ns |  0.1623 ns |   0.1355 ns |     7.506 ns |      - |         - |*
| CountOucrrencesPattern |  8 | abcda(...)dabcd [32] |    81.120 ns |  1.6134 ns |   2.0979 ns |    80.378 ns | 0.0421 |      88 B |
|        CountOucrrences | 16 |                   ab |   105.840 ns |  2.3038 ns |   6.3454 ns |   103.655 ns | 0.0191 |      40 B |
|    CountOucrrencesSpan | 16 |                   ab |    78.173 ns |  1.8671 ns |   5.2966 ns |    76.530 ns |      - |         - |*
| CountOucrrencesPattern | 16 |                   ab |   796.998 ns | 15.7713 ns |  27.2047 ns |   790.595 ns | 0.4663 |     976 B |
|        CountOucrrences | 16 |             abcdabcd |    62.323 ns |  1.2850 ns |   1.1391 ns |    62.284 ns | 0.0114 |      24 B |
|    CountOucrrencesSpan | 16 |             abcdabcd |    31.745 ns |  0.6384 ns |   0.5972 ns |    31.707 ns |      - |         - |*
| CountOucrrencesPattern | 16 |             abcdabcd |   487.813 ns |  9.6479 ns |   9.4756 ns |   486.174 ns | 0.2670 |     560 B |
|        CountOucrrences | 16 |     abcdabcdabcdabcd |    54.207 ns |  1.0550 ns |   1.2559 ns |    53.861 ns | 0.0114 |      24 B |
|    CountOucrrencesSpan | 16 |     abcdabcdabcdabcd |    16.745 ns |  0.2816 ns |   0.2351 ns |    16.674 ns |      - |         - |*
| CountOucrrencesPattern | 16 |     abcdabcdabcdabcd |   319.699 ns |  5.8917 ns |  11.0660 ns |   317.732 ns | 0.1683 |     352 B |
|        CountOucrrences | 16 | abcda(...)dabcd [32] |     7.868 ns |  0.1872 ns |   0.1563 ns |     7.883 ns |      - |         - |
|    CountOucrrencesSpan | 16 | abcda(...)dabcd [32] |     7.597 ns |  0.1832 ns |   0.1530 ns |     7.604 ns |      - |         - |*
| CountOucrrencesPattern | 16 | abcda(...)dabcd [32] |    85.928 ns |  1.7543 ns |   1.6410 ns |    85.741 ns | 0.0421 |      88 B |
|        CountOucrrences | 64 |                   ab |   379.474 ns |  7.3341 ns |   8.7307 ns |   377.002 ns | 0.0420 |      88 B |
|    CountOucrrencesSpan | 64 |                   ab |   305.677 ns |  6.1426 ns |  14.5986 ns |   301.256 ns |      - |         - |*
| CountOucrrencesPattern | 64 |                   ab | 2,951.095 ns | 54.4652 ns | 124.0448 ns | 2,923.082 ns | 1.7700 |   3,712 B |
|        CountOucrrences | 64 |             abcdabcd |   184.984 ns |  3.7313 ns |   7.5373 ns |   183.118 ns | 0.0114 |      24 B |
|    CountOucrrencesSpan | 64 |             abcdabcd |   145.813 ns |  2.9455 ns |   5.0016 ns |   144.117 ns |      - |         - |*
| CountOucrrencesPattern | 64 |             abcdabcd | 1,698.263 ns | 31.8145 ns |  71.1576 ns | 1,674.502 ns | 0.9060 |   1,896 B |
|        CountOucrrences | 64 |     abcdabcdabcdabcd |   145.726 ns |  2.7896 ns |   3.1007 ns |   144.706 ns | 0.0114 |      24 B |
|    CountOucrrencesSpan | 64 |     abcdabcdabcdabcd |    71.874 ns |  1.4200 ns |   1.4583 ns |    71.702 ns |      - |         - |*
| CountOucrrencesPattern | 64 |     abcdabcdabcdabcd |   985.573 ns | 16.7419 ns |  13.9802 ns |   982.708 ns | 0.4654 |     976 B |
|        CountOucrrences | 64 | abcda(...)dabcd [32] |   127.470 ns |  1.4692 ns |   1.2268 ns |   127.080 ns | 0.0114 |      24 B |
|    CountOucrrencesSpan | 64 | abcda(...)dabcd [32] |    32.913 ns |  0.6540 ns |   0.5797 ns |    32.889 ns |      - |         - |*
| CountOucrrencesPattern | 64 | abcda(...)dabcd [32] |   688.198 ns | 12.5080 ns |  20.8980 ns |   683.345 ns | 0.2670 |     560 B |
```

`dotnet run --project bench/WordSearch.Benchmark/  -c Release --filter *StringCountOcurrencesBetweenSpanBenchmarks* --memory` show results between many methods with `ReadOnlySpan<char>` input
```bash
|                      Method |  N |            word |       Mean |     Error |    StdDev |     Median | Allocated |
|---------------------------- |--- |---------------- |-----------:|----------:|----------:|-----------:|----------:|
|         CountOucrrencesSpan |  5 |            cold |  21.986 ns | 0.3690 ns | 0.3082 ns |  21.864 ns |         - |
| CountOucrrencesSpanOptimist |  5 |            cold |  24.473 ns | 0.5263 ns | 0.4923 ns |  24.283 ns |         - |
|     CountOucrrencesSpanLoop |  5 |            cold |  19.246 ns | 0.3833 ns | 0.8169 ns |  19.013 ns |         - |*
|         CountOucrrencesSpan |  5 |           coldx |  16.056 ns | 0.3401 ns | 0.3492 ns |  15.965 ns |         - |*
| CountOucrrencesSpanOptimist |  5 |           coldx |  26.428 ns | 0.5271 ns | 0.7726 ns |  26.214 ns |         - |
|     CountOucrrencesSpanLoop |  5 |           coldx |  17.323 ns | 0.2244 ns | 0.1874 ns |  17.394 ns |         - |
|         CountOucrrencesSpan |  5 | coldxcoldxcoldx |   8.642 ns | 0.4296 ns | 1.2187 ns |   8.317 ns |         - |
| CountOucrrencesSpanOptimist |  5 | coldxcoldxcoldx |   9.846 ns | 0.6577 ns | 1.8549 ns |   9.057 ns |         - |
|     CountOucrrencesSpanLoop |  5 | coldxcoldxcoldx |   7.427 ns | 0.1814 ns | 0.1514 ns |   7.396 ns |         - |*
|         CountOucrrencesSpan | 15 |            cold |  54.757 ns | 1.0241 ns | 1.1383 ns |  54.616 ns |         - |
| CountOucrrencesSpanOptimist | 15 |            cold |  55.467 ns | 0.6271 ns | 0.4896 ns |  55.719 ns |         - |
|     CountOucrrencesSpanLoop | 15 |            cold |  44.954 ns | 0.8658 ns | 1.7489 ns |  44.373 ns |         - |*
|         CountOucrrencesSpan | 15 |           coldx |  50.209 ns | 0.7851 ns | 0.6129 ns |  50.042 ns |         - |
| CountOucrrencesSpanOptimist | 15 |           coldx |  58.446 ns | 1.1683 ns | 1.0929 ns |  58.095 ns |         - |
|     CountOucrrencesSpanLoop | 15 |           coldx |  44.532 ns | 0.9115 ns | 0.8526 ns |  44.383 ns |         - |*
|         CountOucrrencesSpan | 15 | coldxcoldxcoldx |  16.624 ns | 0.2255 ns | 0.1883 ns |  16.645 ns |         - |*
| CountOucrrencesSpanOptimist | 15 | coldxcoldxcoldx |  27.869 ns | 0.5948 ns | 1.2016 ns |  27.547 ns |         - |
|     CountOucrrencesSpanLoop | 15 | coldxcoldxcoldx |  18.945 ns | 0.4224 ns | 1.0038 ns |  18.468 ns |         - |
|         CountOucrrencesSpan | 30 |            cold | 103.016 ns | 2.0759 ns | 2.3074 ns | 101.970 ns |         - |
| CountOucrrencesSpanOptimist | 30 |            cold | 107.480 ns | 1.4439 ns | 1.1273 ns | 107.095 ns |         - |
|     CountOucrrencesSpanLoop | 30 |            cold |  85.425 ns | 1.7479 ns | 3.3256 ns |  84.565 ns |         - |*
|         CountOucrrencesSpan | 30 |           coldx | 104.312 ns | 2.0971 ns | 2.0596 ns | 103.889 ns |         - |
| CountOucrrencesSpanOptimist | 30 |           coldx | 115.867 ns | 2.1724 ns | 2.0321 ns | 116.058 ns |         - |
|     CountOucrrencesSpanLoop | 30 |           coldx |  87.023 ns | 1.0876 ns | 0.8491 ns |  87.225 ns |         - |*
|         CountOucrrencesSpan | 30 | coldxcoldxcoldx |  34.593 ns | 0.3593 ns | 0.3001 ns |  34.542 ns |         - |
| CountOucrrencesSpanOptimist | 30 | coldxcoldxcoldx |  43.535 ns | 0.7921 ns | 0.8134 ns |  43.414 ns |         - |
|     CountOucrrencesSpanLoop | 30 | coldxcoldxcoldx |  33.337 ns | 0.7040 ns | 1.7531 ns |  32.701 ns |         - |*
|         CountOucrrencesSpan | 60 |            cold | 202.708 ns | 4.0600 ns | 8.5639 ns | 199.918 ns |         - |
| CountOucrrencesSpanOptimist | 60 |            cold | 218.309 ns | 3.0473 ns | 2.7013 ns | 218.251 ns |         - |
|     CountOucrrencesSpanLoop | 60 |            cold | 162.099 ns | 2.1489 ns | 1.6777 ns | 162.777 ns |         - |*
|         CountOucrrencesSpan | 60 |           coldx | 207.162 ns | 3.2456 ns | 3.0359 ns | 206.730 ns |         - |
| CountOucrrencesSpanOptimist | 60 |           coldx | 225.674 ns | 3.5560 ns | 3.1523 ns | 225.247 ns |         - |
|     CountOucrrencesSpanLoop | 60 |           coldx | 176.101 ns | 3.1866 ns | 4.7695 ns | 174.994 ns |         - |*
|         CountOucrrencesSpan | 60 | coldxcoldxcoldx |  72.721 ns | 1.0848 ns | 1.0654 ns |  72.531 ns |         - |
| CountOucrrencesSpanOptimist | 60 | coldxcoldxcoldx |  82.672 ns | 1.4652 ns | 1.2989 ns |  82.230 ns |         - |
|     CountOucrrencesSpanLoop | 60 | coldxcoldxcoldx |  63.165 ns | 0.7732 ns | 0.6456 ns |  63.129 ns |         - |*
```

---
## WordSearch.Test project
Unit tests of the methods of the classes of the solution, to see unit test execute `dotnet test test/WordSearch.Tests/ -t`. The most important tests are:

`WordSearch.Tests.MatrixBasicTest`
- Matrix_CountOcurrences_Return_Number_Of_Ocurrences_Horizontal_Of_A_Word
- Matrix_CountOcurrences_Return_Number_Of_Ocurrences_Vertical_Of_A_Word

`WordSearch.Tests.MatrixFlyweightTest`
- Matrix_CountOcurrences_Return_Number_Of_Ocurrences_Horizontal_Of_A_Word
- Matrix_CountOcurrences_Return_Number_Of_Ocurrences_Vertical_Of_A_Word

`WordSearch.Tests.SmartSearcherStrategyTest`
- MatrixSmartSeracherStrategy_SelectBestFor_Matrix_N_LessOrEqual_Than_20_Should_Return_Searcher_Sequential
- MatrixSmartSeracherStrategy_SelectBestFor_Matrix_N_LessOrEqual_Than_20_Should_Return_Searcher_Sequential
- MatrixSmartSeracherStrategy_SelectBestFor_Matrix_N_Less_Than_45_Should_Return_Searcher_Sequential
- MatrixSmartSeracherStrategy_SelectBestFor_Matrix_N_Between_45_And_59_Stream_Less_Than_12_Should_Return_Searcher_Sequential
- MatrixSmartSeracherStrategy_SelectBestFor_Matrix_N_LessOrEqual_Than_60_And_Stream_Equal_01_Should_Return_Searcher_Sequential
- MatrixSmartSeracherStrategy_SelectBestFor_Matrix_N_GreaterOrEqual_Than_60_And_Stream_Greater_Than_01_Should_Return_Searcher_Parallel
- MatrixSmartSeracherStrategy_SelectBestFor_Matrix_N_Greater_Than_60_Should_Return_Searcher_Parallel

`WordSearch.Tests.StringUtilsTest`
- CountOcurrencesWord_Should_Return_Number_Of_Times_That_It_Appears
- CountOcurrencesWordSpan_Should_Return_Number_Of_Times_That_It_Appears
- CountOcurrencesSpanLoop_Should_Return_Number_Of_Times_That_It_Appears

`WordSearch.Tests.WordFinderTest`
- WordFinder_Constructor_Must_Initialize_From_An_NxN_Matrix
- WordFinder_Constructor_When_Matrix_Source_Is_Empty_ThrowException
- WordFinder_Find_When_Word_Stream_Has_Duplicates_Only_Show_One
- WordFinderTest.WordFinder_Find_Show_Ranking_Result

Tu run unit test `dotnet test test/WordSearch.Tests/ --logger "console;verbosity=detailed"`

---
## WordSearch.Sample project
Sample project to demonstrate the use of the WordFinder class. A console application that receives two arguments, the first the path of a file that has the matrix and the second the path of the file that has the streams of words to search for.
Example files are in `data` folder.
```bash
.
└── data
    ├── source_n10.txt
    ├── source_n30.txt
    ├── source_n5.txt
    ├── source_n64.txt
    └── stream.txt
```
Tu run sample `dotnet run --project src/WordSearch.Sample/  -c Release data/source_n10.txt data/stream.txt`