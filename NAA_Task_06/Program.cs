using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

namespace NAA_Task_06
{
    class Program
    {
        static void search(string[] addNames, string[] addProfessions, string[] secondNames)
        {
            bool prov = false;
            string secondName;
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("\n   Введите фамилию для поиска: ");
            Console.ForegroundColor = ConsoleColor.Gray;
            secondName = Console.ReadLine();
            while (prov == false)
            {
                for (int i = 1; i < secondNames.Length; i++)
                {
                    if (secondName == secondNames[i])
                    {
                        Console.Write(addNames[i]);
                        Console.Write(" - ");
                        Console.WriteLine(addProfessions[i]);
                    }
                    prov = true;
                }
            }
            Console.WriteLine("\n  Нажмите любую клавишу для продолжения");
            Console.ReadKey();
            Console.Clear();

        }
        static void removeAt(ref string[] removedName, ref string[] removedProf, int index)
        {
            string[] newRemovedName = new string[removedName.Length - 1];
            string[] newRemovedProf = new string[removedProf.Length - 1];
            for (int i = 0; i < index; i++)
                newRemovedName[i] = removedName[i];
            for (int i = index + 1; i < removedName.Length; i++)
                newRemovedName[i - 1] = removedName[i];
            for (int i = 0; i < index; i++)
                newRemovedProf[i] = removedProf[i];
            for (int i = index + 1; i < removedName.Length; i++)
                newRemovedProf[i - 1] = removedProf[i];
            removedName = newRemovedName;
            removedProf = newRemovedProf;

        }
        static void resizePlus(ref string[] resizeName, ref string[] resizeProf, ref string[] resizeSecondNames, int newSize)
        {
            string[] newSizeName = new string[newSize];
            string[] newSizeProf = new string[newSize];
            string[] newSizeSecondNames = new string[newSize];
            for (int i = 0; i < resizeName.Length; i++)
            {
                newSizeName[i] = resizeName[i];
                newSizeProf[i] = resizeProf[i];
                newSizeSecondNames[i] = resizeSecondNames[i];
            }
            resizeName = newSizeName;
            resizeProf = newSizeProf;
            resizeSecondNames = newSizeSecondNames;
        }
        private static void addName(string[] names, string[] professions, string[] secondNames, int i, int j, int size)
        {
            string a, b, c;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n  - - - Добавить досье. - - - ");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("\n  Введите фамилию: ");
            Console.ForegroundColor = ConsoleColor.Gray;
            a = Console.ReadLine();
            secondNames[i] = a;
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("\n  Введите имя: ");
            Console.ForegroundColor = ConsoleColor.Gray;
            b = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("\n  Введите отчество: ");
            Console.ForegroundColor = ConsoleColor.Gray;
            c = Console.ReadLine();
            names[i] = a + " " + b + " " + c;
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("\n  Введите должность: ");
            Console.ForegroundColor = ConsoleColor.Gray;
            professions[j] = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n - - - /Досье добавлено/ - - -");
        }
        private static void Main(string[] args)
        {
            int menu = 0, i = 0, j = 0, countProf = 1, size = 1, number;
            string[] addNames = new string[size];
            string[] addProfessions = new string[size];
            string[] addSecondName = new string[size];
            while (menu != 5)
            {
                countProf = 1;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n  - - - - - - -   Отдел кадров   - - - - - - -");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("\n 1 - Добавить досье");
                Console.WriteLine("\n 2 - Вывести все досье");
                Console.WriteLine("\n 3 - Удалить досье");
                Console.WriteLine("\n 4 - Поиск по фамилии");
                Console.WriteLine("\n 5 - Выйти из программы");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write("\n  Введите нужный Вам пункт: ");
                Console.ForegroundColor = ConsoleColor.Gray;
                menu = Convert.ToInt32(Console.ReadLine());
                if (menu == 1)
                {
                    size += 1;
                    i++;
                    j++;
                    resizePlus(ref addNames, ref addProfessions, ref addSecondName, size);
                    addName(addNames, addProfessions, addSecondName, i, j, size);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("\n  Нажмите любую клавишу для продолжения");
                    Console.ReadKey();
                    Console.Clear();

                }
                if (menu == 2)
                {
                    for (int countNames = 1; countNames < addNames.Length; countNames++)
                    {
                        Console.Write($"{countNames}. ");
                        Console.Write(addNames[countNames]);
                        Console.Write(" - ");
                        Console.WriteLine(addProfessions[countProf]);
                        countProf++;
                    }
                    Console.WriteLine("\n  Нажмите любую клавишу для продолжения");
                    Console.ReadKey();
                    Console.Clear();
                }
                if (menu == 3)
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("\n  Введите номер удаляемого досье");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    number = Convert.ToInt32(Console.ReadLine());
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n - - - /Досье удалено/ - - - ");
                    removeAt(ref addNames, ref addProfessions, number);
                    Console.WriteLine("\n  Нажмите любую клавишу для продолжения");
                    Console.ReadKey();
                    Console.Clear();
                }
                if (menu == 4)
                {
                    search(addNames, addProfessions, addSecondName);
                }
            }
        }
    }
}