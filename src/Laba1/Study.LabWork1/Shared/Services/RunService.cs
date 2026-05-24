using System;
using Study.LabWork1.Shared.Abstractions;
using Study.LabWork1.Features.Task1;

namespace Study.LabWork1.Shared.Services
{
    /// <summary>
    /// Реализация заданий Л/Р
    /// </summary>
    public class RunService : IRunService
    {
        /// <summary>
        /// Задание 1
        /// </summary>
        public void RunTask1()
        {
            Console.WriteLine("=== Тестирование класса RationalNumber ===\n");
            RationalNumber r1 = new RationalNumber(5, 10);
            Console.WriteLine($"Сокращение дроби 5/10: {r1}");
            RationalNumber r2 = new RationalNumber(6, 3);
            Console.WriteLine($"Целая дробь 6/3: {r2}");
            RationalNumber r3 = new RationalNumber(1, -3);
            Console.WriteLine($"Отрицательный знаменатель 1/-3: {r3}");
            RationalNumber a = new RationalNumber(1, 2);
            RationalNumber b = new RationalNumber(1, 3);
            Console.WriteLine($"{a} + {b} = {a + b}");
            Console.WriteLine($"{a} * {b} = {a * b}");
            Console.WriteLine($"{a} > {b}: {a > b}");
            Console.WriteLine();
            try
            {
                RationalNumber error = new RationalNumber(5, 0);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Ошибка при знаменателе 0 перехвачена: {ex.Message}");
            }
        }

        /// <summary>
        /// Задание 2
        /// </summary>
        public void RunTask2() => throw new NotImplementedException();

        /// <summary>
        /// Задание 3
        /// </summary>
        public void RunTask3() => throw new NotImplementedException();
    }
}
