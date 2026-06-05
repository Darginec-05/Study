using System;
using System.Diagnostics;
using Study.LabWork2.Feature.Task1.SubTask1;

namespace Study.LabWork2;

public static class Program
{
    public static void Main()
    {
        int start = 1;
        int end = 10000;
        int threadCount = 4;

        var monitor = new MonitorService();
        var sw1 = Stopwatch.StartNew();
        monitor.CountPrimes(start, end, threadCount);
        sw1.Stop();
        
        var mutex = new MutexService();
        var sw2 = Stopwatch.StartNew();
        mutex.CountPrimes(start, end, threadCount);
        sw2.Stop();

        var semaphore = new SemaphoreService();
        var sw3 = Stopwatch.StartNew();
        semaphore.CountPrimes(start, end, threadCount);
        sw3.Stop();

        Console.WriteLine("Monitor");
        Console.WriteLine($"Время: {sw1.ElapsedMilliseconds} мс\n");
        Console.WriteLine("Mutex");
        Console.WriteLine($"Время: {sw2.ElapsedMilliseconds} мс\n");
        Console.WriteLine("Semaphore");
        Console.WriteLine($"Время: {sw3.ElapsedMilliseconds} мс\n");

    }
}
