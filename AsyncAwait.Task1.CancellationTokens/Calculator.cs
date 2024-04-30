using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwait.Task1.CancellationTokens;

internal static class Calculator
{
    public static async Task<long> CalculateAsync(int n, CancellationToken cancellationToken)
    {
        long sum = 0;

        await Task.Run(() =>
        {
            for (var i = 0; i < n; i++)
            {
                // i + 1 is to allow 2147483647 (Max(Int32)) 
                sum = sum + (i + 1);

                cancellationToken.ThrowIfCancellationRequested();

                // Simulate some work
                Thread.Sleep(10);
                Console.WriteLine($"Sum {sum}");
            }
        }, cancellationToken);

        return sum;
    }
}