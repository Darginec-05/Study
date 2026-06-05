using System;
using System.Threading;

namespace Study.LabWork2.Feature.Task1.SubTask1;

public sealed class MutexService
{
    private static readonly Mutex _mutex = new Mutex();
    private int _totalPrimeCount = 0;
    private bool IsPrime(int number)
    {
        if (number < 2) return false;
        if (number == 2) return true;
        if (number % 2 == 0) return false;

        for (int i = 3; i * i <= number; i += 2)
        {
            if (number % i == 0) return false;
        }
        return true;
    }
    public void CountPrimes(int start, int end, int threadCount)
    {
        _totalPrimeCount = 0;
        Thread[] threads = new Thread[threadCount];
        int numbersPerThread = (end - start + 1) / threadCount;
        for (int i = 0; i < threadCount; i++)
        {
            int threadStart = start + i * numbersPerThread;
            int threadEnd = (i == threadCount - 1) ? end : threadStart + numbersPerThread - 1;
            int threadId = i + 1;

            threads[i] = new Thread(() => ProcessRange(threadStart, threadEnd, threadId));
            threads[i].Start();
        }

        foreach (var t in threads) t.Join();
        Console.WriteLine($"\nОбщее количество простых чисел: {_totalPrimeCount}");
    }
    private void ProcessRange(int start, int end, int threadId)
    {
        int localCount = 0;
        for (int number = start; number <= end; number++)
        {
            bool isPrime = IsPrime(number);
            _mutex.WaitOne();
            try
            {
                Console.WriteLine($"Поток {threadId}: число {number} - {(isPrime ? "простое" : "составное")}");
            }
            finally
            {
                _mutex.ReleaseMutex();
            }
            if (isPrime) localCount++;
        }

        _mutex.WaitOne();
        try
        {
            _totalPrimeCount += localCount;
        }
        finally
        {
            _mutex.ReleaseMutex();
        }
    }
}
