using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_30._09._23
{
    internal class Program
    {
        public static int Max(int number1, int number2) => number1 > number2 ? number1 : number2;
        static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
        static bool CalculateFactorial(int n, out long result)
        {
            result = 1;
            try
            {
                checked
                {
                    for (int i = 2; i <= n; i++)
                    {
                        result *= i;
                    }
                }
                return true;
            }
            catch (OverflowException)
            {
                return false;
            }
        }
        static int CalculateFactorial(int n)
        {
            if (n == 0 || n == 1) // Базовый случай: факториал 0 или 1 равен 1
            {
                return 1;
            }
            else
            {
                return n * CalculateFactorial(n - 1);// Рекурсивный случай: факториал числа n равен n * факториал (n-1)
            }
        }
        static int FindGCD(int a, int b)
        {
            while (b != 0)
            {
                int remainder = a % b;
                a = b;
                b = remainder;
            }
            return a;
        }

        static int FindGCD(int a, int b, int c)
        {
            return FindGCD(FindGCD(a, b), c);
        }
        static int Fibonacci(int n)
        {
            if (n <= 1)
                return n;

            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Упражнение 5.1. Написать метод, возвращающий наибольшее из двух чисел.");
            Console.WriteLine("Введите два целых числа:");
            int number1 = Convert.ToInt32(Console.ReadLine());
            int number2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Наибольшее: {Max(number1, number2)}");
            Console.WriteLine("Упражнение 5.2. Написать метод, который меняет местами значения двух передаваемых параметров.");
            Console.WriteLine("Введите первое число:");
            int num1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите второе число:");
            int num2 = int.Parse(Console.ReadLine());
            Swap(ref num1, ref num2);
            Console.WriteLine($"Числа после обмена: {num1}, {num2}");
            Console.WriteLine("Упражнение 5.3. Написать метод вычисления факториала числа, результат вычислений передавать в выходном параметре. Если метод отработал успешно, то вернуть значение true; если в процессе вычисления возникло переполнение, то вернуть значение false. Для отслеживания переполнения значения использовать блок checked.");
            Console.Write("Введите число: ");
            int number = int.Parse(Console.ReadLine());
            if (CalculateFactorial(number, out long factorial))
            {
                Console.WriteLine($"Факториал числа {number} равен {factorial}");
            }
            else
            {
                Console.WriteLine("Переполнение при вычислении факториала");               
            }
            Console.WriteLine("Упражнение 5.4.Написать рекурсивный метод вычисления факториала числа.");
            Console.WriteLine("Введите число:");
            int n1 = int.Parse(Console.ReadLine());
            int factorial1 = CalculateFactorial(n1);
            Console.WriteLine($"Факториал числа {n1} равен {factorial1}");
            Console.WriteLine("Домашнее задание 5.1. Написать метод, который вычисляет НОД двух натуральных чисел (алгоритм Евклида). Написать метод с тем же именем, который вычисляет НОД трех натуральных чисел.");
            int num11 = 15;
            int num22 = 39;
            int num33 = 52;
            int gcd2 = FindGCD(num11, num22);
            Console.WriteLine("НОД двух чисел {0} и {1} равен {2}", num11, num22, gcd2);
            int gcd3 = FindGCD(num11, num22, num33);
            Console.WriteLine("НОД трех чисел {0}, {1} и {2} равен {3}", num11, num22, num33, gcd3);           
            Console.WriteLine("Домашнее задание 5.2. Написать рекурсивный метод, вычисляющий значение n-го числа ряда Фибоначчи. Ряд Фибоначчи – последовательность натуральных чисел 1, 1, 2, 3, 5, 8,13... Для таких чисел верно соотношение Fk = Fk-1 + Fk-2 .");
            int n = 10; 
            int result = Fibonacci(n);
            Console.WriteLine($"Число Фибоначчи для n = {n} равно:{result}");
            Console.ReadKey();
        }

    }
}
