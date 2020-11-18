using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    namespace NAA_Task_02
    {
        class Program
        {
            static void Main(string[] args)
            {

                string exit;//переменная для чтения текста

                Console.WriteLine("Программа будет выполняться до тех пор, пока не будет введено слово 'exit'");
                do//цикл
                {
                    Console.WriteLine("- * - - - - - - - - - - - - - - - - - - - - - * - - - - - - - - - - - - - - - - - - - - - * - ");
                    exit = Convert.ToString(Console.ReadLine());

                } while (exit != "exit");//условие завершения - пользователь ввёл exit


                Console.WriteLine("\n");
                Console.WriteLine("- * - - - - - - - - - - - - - - - - - - - - - * - - - - - - - - - - - - - - - - - - - - - * - ");
                Console.WriteLine(" Окончание программы...");
                Console.WriteLine("- * - - - - - - - - - - - - - - - - - - - - - * - - - - - - - - - - - - - - - - - - - - - * -  ");

            }
        }
    }
