using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System;

namespace NAA_Task_07
{
    class Program
    {
        static void RandomFill(int[] array)
        {
            Random random = new Random();

            for (int i = 0; i < array.Length; ++i)
            {
                array[i] = random.Next();
            }
        }

        static void Print(int[] array)
        {
            for (int i = 0; i < array.Length; ++i)
            {
                Console.WriteLine(i + ": " + array[i]);
            }
        }

        static int[] Shuffle(int[] array)
        {
            Random random = new Random();

            int temporaryElement, randomPosition;

            for (int i = array.Length - 1; i > 0; i--)
            {
                randomPosition = random.Next(i);
                temporaryElement = array[i];
                array[i] = array[randomPosition];
                array[randomPosition] = temporaryElement;
            }

            return array;
        }

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n        Введите размерность массива: ");
            uint arraySize = Convert.ToUInt32(Console.ReadLine());

            int[] array = new int[arraySize];
            RandomFill(array);

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\n        Вывод исходного массива: ");
            Print(array);

            Shuffle(array);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n        Вывод перемешанного массива: ");
            Print(array);

            Console.ReadKey();
        }
    }
}