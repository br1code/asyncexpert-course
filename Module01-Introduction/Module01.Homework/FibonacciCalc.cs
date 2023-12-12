
using BenchmarkDotNet.Attributes;

namespace Module01.Homework
{
    [DisassemblyDiagnoser(exportCombinedDisassemblyReport: true)]
    [MemoryDiagnoser]
    public class FibonacciCalc
    {
        [Benchmark(Baseline = true)]
        [ArgumentsSource(nameof(Data))]
        public ulong Recursive(ulong n)
        {
            if (n == 1 || n == 2) return 1;
            return Recursive(n - 2) + Recursive(n - 1);
        }

        [Benchmark]
        [ArgumentsSource(nameof(Data))]
        public ulong RecursiveWithMemoization(ulong n)
        {
            var memo = new Dictionary<ulong, ulong>();
            return RecursiveMemo(n, memo);
        }

        private ulong RecursiveMemo(ulong n, Dictionary<ulong, ulong> memo)
        {
            if (memo.TryGetValue(n, out ulong value))
            {
                return value;
            }

            if (n <= 2)
            {
                memo[n] = 1;
            }
            else
            {
                memo[n] = RecursiveMemo(n - 1, memo) + RecursiveMemo(n - 2, memo);
            }

            return memo[n];
        }


        [Benchmark]
        [ArgumentsSource(nameof(Data))]
        public ulong Iterative(ulong n)
        {
            if (n <= 2) return 1;

            ulong a = 1, b = 1, c = 0;
            for (ulong i = 3; i <= n; i++)
            {
                c = a + b;
                a = b;
                b = c;
            }
            return c;
        }


        public IEnumerable<ulong> Data()
        {
            yield return 15;
            yield return 35;
        }
    }
}
