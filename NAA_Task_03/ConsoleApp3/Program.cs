using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

namespace NAA_Task_03
{
    class Program
    {
        static void Main(string[] args)
        {
            int ошибки = 0; 
            string пароль = "Боуи";
            string подсказка;
            bool результат = true; //булевая переменная для результата

            Console.WriteLine("Введите пароль:" +
            "\n>> Введите 'Space Oddity' для получения подсказки" +
            "\n  - * - - - - - - - - - - - - - - - - - - - -  - * - - - - - - - - - - - - - - - - - - - - - - ");

            do//цикл
            {
                Console.WriteLine($"> Попыток {3 - ошибки}"); //количество попыток
                подсказка = Convert.ToString(Console.ReadLine());
                if (подсказка == "Space Oddity")
                {
                    Console.WriteLine(" Имя английского музыканта, написавшего песню Space Oddity (о вымышленном астронавте по имени майор Том, затерявшемся в открытом космосе. Выпущена песня на отдельном сингле в 1969 году.");
                }
                else if (пароль == подсказка)
                {
                    результат = false;
                }
                else
                {
                    ошибки++;
                    if (ошибки == 3)
                    {
                        Console.WriteLine("Ваши попытки закончились.");
                        Console.ReadKey();
                        Environment.Exit(0);
                    }
                }

            } while (результат); //условие завершения выполнено

            Console.WriteLine("Вход выполнен успешно. Нажмите Enter для получения секретного сообщения.");
            

            Console.WriteLine("\n                                                            " +
                              "\n   This is   major Tom   to " +
                              "\n                             ground control, " +
                              "\n                                                         " +
                              "\n           I'm stepping through     the door" +
                              "\n                                                         " +
                              "\n   And  I'm  floating in  a  most peculiar   way" +
                              "\n                                                         " +
                              "\n   And the stars look very different   " +
                              "\n                                        today" +
                              "\n                                                         " +
                              "\n                                                         " +
                              "\n                                                         " +
                              "\n   For here " +
                              "\n              am I sitting in a tin can " +
                              "\n                                            far above the world" +
                              "\n                                                         " +
                              "\n                                                         " +
                              "\n    Planet Earth is blue and there's nothing I can do" +
                              "\n                                                         " +
                              "\n                                                         " +
                              "\n                                                         " +
                              "\n                                                         " +
                              "\n    Though I'm past one hundred thousand miles, " +
                              "\n                                                  I'm feeling very still" +
                              "\n                                                         " +
                              "\n    And I think my spaceship knows which way to go" +
                              "\n                                                         " +
                              "\n                                                         " +
                              "\n    Tell my wife I love her very much, " +
                              "\n                                           she knows" +
                              "\n                                                         " +
                              "\n     Ground control to major Tom," +
                              "\n     Your circuit's dead, " +
                              "\n                                     there's something wrong" +
                              "\n                                                         " +
                              "\n                    Can you hear me, major Tom ?" +
                              "\n                    Can you hear me, major Tom ?" +
                              "\n                    Can you hear me, major Tom ?" +
                              "\n                             Can you...");
          
            Console.ReadKey();

        }
    }
}
