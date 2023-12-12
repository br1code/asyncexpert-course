# Module 01 - Introduction

Homework:

1. Write implementations for RecursiveWithMemoization and Iterative solutions ✅

2. Add MemoryDiagnoser to the benchmark ✅

3. Run with release configuration and compare results ✅

```
BenchmarkDotNet v0.13.11,
AMD Ryzen 9 5950X, 1 CPU, 32 logical and 16 physical cores
.NET SDK 8.0.100
```
| Method                   | n  | Mean              | Error          | StdDev         | Ratio | Code Size | Gen0   | Allocated | Alloc Ratio |
|------------------------- |--- |------------------:|---------------:|---------------:|------:|----------:|-------:|----------:|------------:|
| **Recursive**                | **15** |        **985.456 ns** |      **8.0129 ns** |      **7.4953 ns** | **1.000** |     **162 B** |      **-** |         **-** |          **NA** |
| RecursiveWithMemoization | 15 |        247.759 ns |      4.9783 ns |      7.7507 ns | 0.254 |   1,361 B | 0.0591 |     992 B |          NA |
| Iterative                | 15 |          2.780 ns |      0.0208 ns |      0.0194 ns | 0.003 |      60 B |      - |         - |          NA |
|                          |    |                   |                |                |       |           |        |           |             |
| **Recursive**                | **35** | **14,957,703.646 ns** | **60,104.5918 ns** | **56,221.8724 ns** | **1.000** |     **162 B** |      **-** |       **6 B** |        **1.00** |
| RecursiveWithMemoization | 35 |        559.291 ns |     10.7145 ns |     10.5230 ns | 0.000 |   1,361 B | 0.1240 |    2080 B |      346.67 |
| Iterative                | 35 |          7.777 ns |      0.0605 ns |      0.0566 ns | 0.000 |      60 B |      - |         - |        0.00 |


4. Open [disassembler report](https://github.com/br1code/asyncexpert-course/blob/master/Module01-Introduction/Module01.Homework.FibonacciCalc-disassembly-report.html) and compare machine code ✅
