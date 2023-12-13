# Module 02 - AsyncBasics - Threading

Homework:

1. Implement methods from `ThreadPool.Exercises.Core` project to pass tests from `ThreadPoolExercises.Tests`.
2. Use `ThreadPoolExercises.Benchmarks` to benchmark implemented methods.

```ini
BenchmarkDotNet=v0.12.1
AMD Ryzen 9 5950X, 1 CPU, 32 logical and 16 physical cores
.NET Core SDK=8.0.100
```

| Method               |        Mean |     Error |    StdDev |
| -------------------- | ----------: | --------: | --------: |
| ExecuteSynchronously |    508.2 ns |   1.66 ns |   1.30 ns |
| ExecuteOnThread      | 74,602.4 ns | 681.61 ns | 637.58 ns |
| ExecuteOnThreadPool  |  6,827.5 ns | 135.36 ns | 176.00 ns |
