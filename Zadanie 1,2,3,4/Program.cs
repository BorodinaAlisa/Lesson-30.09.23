using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Zadanie_1_2_3_4
{
    internal class Program
    {
        static int[] GenerateRandomArray(int size)
        {
            Random random = new Random();
            int[] array = new int[size];
            for (int i = 0; i < size; i++)
            {
                array[i] = random.Next(1, 100); // Генерация случайного числа от 1 до 100
            }
            return array;
        }
        static int GetSum(params int[] array)
        {
            int sum = 0;
            foreach (int num in array)
            {
                sum += num;
            }
            return sum;
        }
        static void GetProduct(int[] array, out int product)
        {
            product = 1;
            foreach (int num in array)
            {
                product *= num;
            }
        }
        static void GetAverage(int[] array, out double average)
        {
            int sum = GetSum(array);
            average = (double)sum / array.Length;
        }
        public static void DrawNumber(int number)
        {
            string[] digitImages =
            {
                " ### \n # # \n # # \n # # \n ### ", // 0
                " # \n # \n # \n # \n # ", // 1
                " ### \n # \n ### \n # \n ### ", // 2
                " ### \n # \n ### \n # \n ### ", // 3
                " # \n # # \n # # \n ##### \n # ", // 4
                " ##### \n # \n ### \n # \n ### ", // 5
                " ### \n # \n ### \n # # \n ### ", // 6
                " ##### \n # \n # \n # \n # ", // 7
                " ### \n # # \n ### \n # # \n ### ", // 8
                " ### \n # # \n #### \n # \n ### " // 9
            };

            string image = digitImages[number];
            Console.WriteLine(image);
        }     
        public static int Getsum(params int[] numbers)
        {
            int sum = 0;
            foreach (int num in numbers)
            {
                sum += num;
            }
            return sum;
        }
        public static void GetProduct(ref int product, params int[] numbers)
        {
            product = 1;
            foreach (int num in numbers)
            {
                product *= num;
            }
        }
        public static void GetAverage(out double average, params int[] numbers)
        {
            int sum = GetSum(numbers);
            average = (double)sum / numbers.Length;
        }
        enum GrumpinessLevel
        {
            Неворчливый,
            Средне_ворчливый,
            Сильно_ворчливый
        }
        struct Grandpa
        {
            public string Name;
            public GrumpinessLevel Grumpiness;
            public string[] GrumblePhrases;
            public int Bruises;
            public Grandpa(string n, GrumpinessLevel g, string[] p)
            {
                Name = n;
                Grumpiness = g;
                GrumblePhrases = p;
                Bruises = 0;
            }
            public int CheckSwearWords(params string[] swearWords)
            {
                int bruisesCount = 0;
                foreach (var phrase in GrumblePhrases)
                {
                    foreach (var word in swearWords)
                    {
                        if (phrase.Contains(word))
                        {
                            bruisesCount++;
                            break;
                        }
                    }
                }
                Bruises += bruisesCount;
                return bruisesCount;
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Задание 1.Вывести на экран массив из 20 случайных чисел. Ввести два числа из этого массива, которые нужно поменять местами. Вывести на экран получившийся массив.");
            Random random = new Random();
            int[] array = new int[20];
            for (int i = 0; i < 20; i++)
            {
                array[i] = random.Next(1, 100);
            }
            Console.WriteLine("Исходный массив:");
            foreach (int num in array)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
            Console.Write("Введите индекс первого числа для замены: ");
            int index1 = int.Parse(Console.ReadLine());
            Console.Write("Введите индекс второго числа для замены: ");
            int index2 = int.Parse(Console.ReadLine());
            if (index1 < 0 || index1 >= 20 || index2 < 0 || index2 >= 20)
            {
                Console.WriteLine("Введенные индексы выходят за пределы массива.");
                return;
            }

            int temp = array[index1];
            array[index1] = array[index2];
            array[index2] = temp;
            Console.WriteLine("Получившийся массив:");
            foreach (int num in array)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Задание 2.Написать метод, где в качества аргумента будет передан массив (ключевое слово params). Вывести сумму элементов массива (вернуть). Вывести (ref) произведение массива. Вывести (out) среднее арифметическое в массиве.");
            int[] nums = { 1, 2, 3, 4, 5 };
            int sum = Getsum(nums);
            Console.WriteLine("Сумма элементов: " + sum);
            int product = 0;
            GetProduct(ref product, nums);
            Console.WriteLine("Произведение элементов: " + product);
            double average;
            GetAverage(out average, nums);
            Console.WriteLine("Среднее арифметическое: " + average);
            Console.WriteLine("Задание 3.Пользователь вводит числа. Если числа от 0 до 9, то необходимо в консоли нарисовать изображение цифры в виде символа #.Если число больше 9 или меньше 0, то консоль должна окраситься в красный цвет на 3 секунды и вывести сообщение об ошибке. Если\r\nпользователь ввёл не цифру, то программа должна выпасть в исключение. Программа завершает работу, если пользователь введёт слово: exit или закрыть (оба варианта должны сработать) - консоль закроется.");
            string input;
            do
            {
                Console.Write("Введите число (exit для выхода): ");
                input = Console.ReadLine();
                if (input.ToLower() == "exit" || input.ToLower() == "закрыть")
                    break;
                int number;
                if (!Int32.TryParse(input, out number))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ошибка! Введено не число");
                    Console.ResetColor();
                }
                else if (number >= 0 && number <= 9)
                {
                    Console.Clear();
                    DrawNumber(number);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ошибка! Введено число не от 0 до 9");
                    Console.ResetColor();
                    System.Threading.Thread.Sleep(3000);
                }
            }
            while (true);
            Console.WriteLine("Задание 4.Создать структуру Дед. У деда есть имя, уровень ворчливости (перечисление), массив фраз для ворчания (прим.: “Проститутки!”, “Гады!”), количество синяков от ударов бабки = 0 по умолчанию. Создать 5 дедов. У каждого деда - разное количество фраз для ворчания. Напишите метод (внутри структуры), который на вход принимает деда, список матерных слов (params). Если дед содержит в своей лексике матерные слова изсписка, то бабка ставит фингал за каждое слово. Вернуть количество фингалов.");
            string[] swearings = { "Сука", "Блять", "Пидор", "Ебанутый"};
            string[] phrase5 = { "Проститутки", "Мразь", "Ебанутый" };
            string[] phrase4 = { "Блять", "Дебил", "Пидор", "Тупой" };
            string[] phrase3 = { "Долбоеб", "Гады", "Тупица", "Хрень", "Осел" };
            string[] phrase2 = { "Чмо", "Дурак", "Скотина" };
            string[] phrase1 = { "Олень", "Дурак" };
            Grandpa[] grandpas = new Grandpa[5];
            grandpas[0] = new Grandpa("Максим", GrumpinessLevel.Неворчливый, phrase1);
            grandpas[1] = new Grandpa("Алексей", GrumpinessLevel.Средне_ворчливый, phrase3);
            grandpas[2] = new Grandpa("Михаил", GrumpinessLevel.Неворчливый, phrase2);
            grandpas[3] = new Grandpa("Анатолий", GrumpinessLevel.Сильно_ворчливый, phrase5);
            grandpas[4] = new Grandpa("Валерий", GrumpinessLevel.Средне_ворчливый, phrase4);
            Console.WriteLine($"Дед {grandpas[0].Name} получил {grandpas[0].CheckSwearWords(swearings)} синяков.");
            Console.WriteLine($"Дед {grandpas[1].Name} получил {grandpas[1].CheckSwearWords(swearings)} синяков.");
            Console.WriteLine($"Дед {grandpas[2].Name} получил {grandpas[2].CheckSwearWords(swearings)} синяков.");
            Console.WriteLine($"Дед {grandpas[3].Name} получил {grandpas[3].CheckSwearWords(swearings)} синяков.");
            Console.WriteLine($"Дед {grandpas[4].Name} получил {grandpas[4].CheckSwearWords(swearings)} синяков.");
            Console.ReadKey();
        }   
        
    }
}
