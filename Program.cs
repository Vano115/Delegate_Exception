using Delegate_Exception.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Delegate_Exception
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Задание 1, перехват исключений

            int input = 0;
            int[] arrayInput = {1, 3};
            string str = null;
            while (true)
            {
                try
                {
                    Console.WriteLine("\nВводим значение (при вводе 125 - выход из цикла первой задачи): ");
                    if (int.TryParse(Console.ReadLine(), out input) is false)
                    {
                        throw new FormatException();
                    }
                    // Исключение если введено не число

                    if (input == 125)
                    {
                        break;
                    }
                    // Выход из цикла первой части ДЗ

                    if (input != 4 && input != 5)
                    {
                        if (input == 0)
                        {
                            throw new NullException();
                        }
                        throw new NonNeedNumberException();
                    }
                    // Исключения если введено не 4 или 5

                    if (input == 4)
                    {
                        Console.WriteLine(str[2]);
                    }
                    // Демонстрация перехвата 1 системного исключения

                    if (input == 5)
                    { 
                        Console.WriteLine(arrayInput[5]);
                    }
                    // Демонстрация перехвата 2 системного исключения
                }
                catch (Exception ex)
                {
                    if (ex is NonNeedNumberException)
                    {
                        Console.WriteLine("Введённое значение не равно 4 или 5");
                    }

                    if (ex is FormatException)
                    {
                        Console.WriteLine("Введено не целое число");
                    }

                    if (ex is NullException)
                    {
                        Console.WriteLine("Введён 0");
                    }
                    if (ex is IndexOutOfRangeException)
                    {
                        Console.WriteLine("Несуществующий элемент массива");
                    }
                    if (ex is NullReferenceException)
                    {
                        Console.WriteLine("Пустая строковая переменная");
                    }
                }
            }

            // Задание 2

            List<string> surnames = new List<string>();
            surnames.Add("Иванов");
            surnames.Add("Бардов");
            surnames.Add("Скопцов");
            surnames.Add("Вишняков");
            surnames.Add("Иванова");
            // Создание списка-примера

            Console.WriteLine("Не сортированный список:");
            foreach (string s in surnames)
            {
                Console.WriteLine(s);
            }
            // Вывод необработанного списка

            EventChoice eventChoice = new EventChoice();
            eventChoice.ChoiceEvent += ChoicedSort;

            try
            {
                eventChoice.CheckNum(surnames);
            }
            catch(Exception ex)
            {
                if (ex is FormatException)
                {
                    Console.WriteLine("Введено не число");
                }
                if (ex is NonNeedNumberException)
                {
                    Console.WriteLine("Введено неподходящее число");
                }
            }

            Console.WriteLine("Сортированый список:");
            foreach (string s in surnames)
            {
                Console.WriteLine(s);
            }
            // Вывод обработанного списка
        }

        static void ChoicedSort(int number, List<string> surnames)
        {
            switch (number)
            {
                case 1: surnames.Sort();
                    break;
                case 2:
                    surnames.Sort();surnames.Reverse();
                    break;
            }
        }
        // Метод-сортировщик
    }
}
