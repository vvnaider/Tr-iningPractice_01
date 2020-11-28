using System;
using System.IO;

namespace NAA_Task_05
{
    class Program
    {

        static string[] newFile = File.ReadAllLines($"maps/map.txt");//Файл с лабиринтом
        static char[,] map = new char[newFile.Length, newFile[0].Length];//Массив символов и лабиринт

        static int HeroX;//Координаты игрока
        static int HeroY;

        static int E_enX;//Координаты врагов : Е, V, Y
        static int E_enY;

        static int W_enX;
        static int W_enY;

        static int Y_enX;
        static int Y_enY;

        static int Fx;//Координаты финиша
        static int Fy;


        static ConsoleKeyInfo key;
        static Random rnd = new Random();
        static int Helth = 5;//Жизни
        static bool mist = false;//Проверка на попытку войти в стену

        static char[,] ReadMap()//Чтение лабиринта в массив
        {
            HeroX = 0;
            HeroY = 0;

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    map[i, j] = newFile[i][j];

                    if (map[i, j] == 'V')
                    {
                        HeroX = i;
                        HeroY = j;
                    }
                    else if (map[i, j] == 'F')
                    {             
                        Fx = i;
                        Fy = j;
                    }
                    else if (map[i, j] == 'E')
                    {
                        E_enX = i;
                        E_enY = j;
                    }
                    else if (map[i, j] == 'W')
                    {
                        W_enX = i;
                        W_enY = j;
                    }
                    else if (map[i, j] == 'Y')
                    {
                        Y_enX = i;
                        Y_enY = j;
                    }
                }
            }
            return map;
        }


        static void DrawMap(char[,] map)//Функция вывода лабиринта в консоль
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(map[i, j]);
                }
                Console.WriteLine();
            }
        }

        static void En_way(char n, ref int x, ref int y)//Расчёт хода врагов
        {
            int w;

        Sicl:
            w = rnd.Next(1, 5);
            if (x == 1) w = 4;

            switch (w)
            {
                case 1:
                    if (map[x, y - 1] != '█')
                    {
                        map[x, y - 1] = n;
                        map[x, y] = ' ';
                        y--;
                    }
                    else goto Sicl;
                    break;

                case 2:
                    if (map[x - 1, y] != '█')
                    {
                        map[x - 1, y] = n;
                        map[x, y] = ' ';
                        x--;
                    }
                    else goto Sicl;
                    break;

                case 3:
                    if (map[x, y + 1] != '█')
                    {
                        map[x, y + 1] = n;
                        map[x, y] = ' ';
                        y++;
                    }
                    else goto Sicl;
                    break;

                case 4:
                    if (map[x + 1, y] != '█')
                    {
                        map[x + 1, y] = n;
                        map[x, y] = ' ';
                        x++;
                    }
                    else goto Sicl;
                    break;
            }
            Console.WriteLine(Convert.ToString(W_enX));
        }

        static void HP_Mistakes() //Правила здоровье и ошибки
        {
            Console.Write("HP:[");
            for (int i = 0; i < Helth; i++)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write('#');
                Console.ResetColor();
            }
            if (Helth < 5)
            {
                for (int i = 0; i < 5 - Helth; i++)
                {
                    Console.Write('_');
                }
            }
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("]\n");
            Console.WriteLine("\n   Дойдите до выхода из лабиринта (F).");
            Console.WriteLine("\n       V - Вы.");
            Console.WriteLine("\n   Опасайтесь врагов (Y, E, W.)");
            Console.WriteLine("\n   Управляйте стрелками. Для выхода из лабиринта нажмите: ESC");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkGray;

            if (mist == true)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\n    Вы наткнулись на стену. " +
                    "\n                                                        ");
                Console.ResetColor();
                mist = false;
            }
            else Console.Write("\n\n");
        }

        static void Walk()
        {
            do
            {
                HP_Mistakes();
                DrawMap(map);

                key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.LeftArrow)//Чтение стрелочек Лево
                {
                    if ((map[HeroX, HeroY - 1] != '█') && (HeroY != 0))
                    {
                        map[HeroX, HeroY - 1] = 'V';
                        map[HeroX, HeroY] = '%';
                        HeroY--;
                    }
                    else mist = true;
                }
                else if (key.Key == ConsoleKey.RightArrow)//Право
                {
                    if ((map[HeroX, HeroY + 1] != '█') && (HeroY != map.GetLength(1)))
                    {
                        map[HeroX, HeroY + 1] = 'V';
                        map[HeroX, HeroY] = '%';
                        HeroY++;
                    }
                    else mist = true;
                }
                else if (key.Key == ConsoleKey.UpArrow)//Верх
                {
                    if ((map[HeroX - 1, HeroY] != '█') && (HeroX != 0))
                    {
                        map[HeroX - 1, HeroY] = 'V';
                        map[HeroX, HeroY] = '%';
                        HeroX--;
                    }
                    else mist = true;
                }
                else if (key.Key == ConsoleKey.DownArrow)//Низ
                {
                    if ((map[HeroX + 1, HeroY] != '█') && (HeroX != map.GetLength(0)))
                    {
                        map[HeroX + 1, HeroY] = 'V';
                        map[HeroX, HeroY] = '%';
                        HeroX++;
                    }
                }
                else if (key.Key == ConsoleKey.Escape)
                {
                    Console.Clear();
                    Console.WriteLine("\n Вы вышли из лабиринта." +
                        "\n Нажмите любую клавишу.");
                    Console.ReadKey();
                    System.Environment.Exit(1);
                }
                if ((HeroX == E_enX) && (HeroY == E_enY) || (HeroX == W_enX) && (HeroY == W_enY) || (HeroX == Y_enX) && (HeroY == W_enY)) Helth--;

                    En_way('E', ref E_enX, ref E_enY);//Ход врагов
                    En_way('W', ref W_enX, ref W_enY);
                    En_way('Y', ref Y_enX, ref Y_enY);

                  if ((HeroX == E_enX) && (HeroY == E_enY) || (HeroX == W_enX) && (HeroY == W_enY) || (HeroX == Y_enX) && (HeroY == Y_enY)) Helth--;//проверка на урон от монстров

                    Console.Clear();

                    } while ((map[HeroX, HeroY] != map[Fx, Fy]) && (Helth > 0)) ;

                    if (map[HeroX, HeroY] == map[Fx, Fy])//победа
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine("\n                                              " +
                      "\n                           Вы прошли лабиринт!                                ");
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine("\n                                                          " +
                      "\n         __                                                      __             " +
                      "\n        (**)                                                    (**)            " +
                      "\n        IIII                                                    IIII            " +
                      "\n        ####                                                    ####            " +
                      "\n        HHHH         Far over the Misty Mountains cold          HHHH            " +
                      "\n        HHHH         To dungeons deep and caverns old           HHHH            " +
                      "\n        ####         We must away ere break of day              ####            " +
                      "\n     ___IIII___      To find our long forgotten gold.        ___IIII___         " +
                      "\n  .-`_._ * *_._`-.                                        .-`_._ * *_._`-.      " +
                      "\n  |/``  .`V`.  ` N                                        |/``  .`V`.  ``N      " +
                      "\n  `  ' }    { '    The pines were roaring on the height,     ' }    { '         " +
                      "\n       ) () (      The winds were moaning in the night         ) () (           " +
                      "\n       | :: |      The fire was red, it flaming spread;        | :: |      '    " +
                      "\n       | )( |     The trees like torches blazed with light     | )( |           " +
                      "\n       | || |                                                  | || |           " +
                      "\n       | || |                                                  | || |           " +
                      "\n       | || |                                                  | || |           " +
                      "\n       | || |                                                  | || |           " +
                      "\n       | || |                                                  | || |           " +
                      "\n        (())                                                    (())            " +
                      "\n        V  /                                                    V  /            " +
                      "\n         II                                                      II             " +
                      "\n                                                                                " +
                      "\n                                                                                ");
                        Console.ReadKey();
                    }
                    else
                    {//поражение
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("\n" +
        "\n                                   Вы мертвы         ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n   " +
        "\n                              " +
        "\n                           ██████████████████████████" +
        "\n                           ███████▀▀▀░░░░░░░▀▀▀██████" +
        "\n                           ████▀░░░░░░░░░░░░░░░░░▀███" +
        "\n                           ██│░░░░░░░░░░░░░░░░░░░│███" +
        "\n                           ▌n│░░░░░░░░░░░░░░░░░░░│▐██" +
        "\n                           █░└┐░░░░░░░░░░░░░░░░░┌┘░██" +
        "\n                            ░░└┐░░░░░░░░░░░░░░░┌┘░░██" +
        "\n                           █░░┌┘▄▄▄▄▄░░░░░▄▄▄▄▄└┐░░██" +
        "\n                           █ ░│██████▌░░░▐██████│░▐██" +
        "\n                           ██░│▐███▀▀░░▄░░▀▀███▌│░███" +
        "\n                           █▀─┘░░░░░░░▐█▌░░░░░░░└─▀██" +
        "\n                           █▄░░░▄▄▄▓░░▀█▀░░▓▄▄▄░░░▄██" +
        "\n                           ███▄─┘██▌░░░░░░░▐██└─▄████" +
        "\n                           ████░░▐█─┬┬┬┬┬┬┬─█▌░░█████" +
        "\n                           ███▌░░░▀┬┼┼┼┼┼┼┼┬▀░░░▐████" +
        "\n                           ████▄░░░└┴┴┴┴┴┴┴┘░░░▄█████" +
        "\n                           ██████▄░░░░░░░░░░░▄███████" +
        "\n                           █████████▄▄▄▄▄▄▄██████████" +
        "\n                           ██████████████████████████ ");
                        Console.ReadKey();
                    }
                }

                static void Main(string[] args)
                {
                    int origWidth, origHeight;

                    origWidth = Console.WindowWidth;
                    origHeight = Console.WindowHeight;

                    Console.SetWindowSize(origWidth / 1, origHeight * 1);

                    map = ReadMap();

                    Walk();
                }
            }

}