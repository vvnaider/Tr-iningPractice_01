using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAA_Task_01
{
    class Program
    {
        static void Main(string[] args)
        {
            
            
            bool chek;//булевая переменная для проврки
            Console.WriteLine("- * - - - - - - - - - - - - - - - - - - - -  - * - - - - - - - - - - - - - - - - - - - - - * - ");
            Console.WriteLine(" Торговец,- \" Рад вновь тебя видеть! Все как обычно: травы, медикаменты и то, что я нахожу по дороге. Всего понемногу.\"" +
             "\nВы,- \" Боюсь, сегодня ничего не куплю, однако, если интересует, я бы обменял кое-какой товар на все кристаллы, которые у тебя имеются.\"" +
            "\nТорговец: \" Выкладывай что там у тебя есть, а я скажу сколько за это дам.... \"" +
            "\n>> - * - - - - - - - - - - - - - - - - - - - -  - * - - - - - - - - - - - - - - - - - - - - - * -" +
            "\nТорговец,- \"...Ого! золотые монеты в наших краях? Откуда? Они точно твои?\"" +
            "\nВы,- \" Да вот выдалась удачная вылазка в Пустошь на той неделе. Конечно, мои. А за разумную цену могут стать твоими.\"" +
             "\n>> Введите количество монет в вашей сумке: ");
            double coins = Convert.ToDouble(Console.ReadLine()); //наше золото
            Console.WriteLine("\n>> Введите цену кристалла в золотых монетах: "); ;
            double crystalPrice = Convert.ToDouble(Console.ReadLine()); //цена кристала

            double crystalBuy = 9; //количество кристаллов
            Console.WriteLine("\nТорговец,- \" Кхм, сейчас есть в наличии " + crystalBuy + " кристаллов. \"");
            double crystals = 0;
            Console.Write("\nВведите сколько вам нужно кристалов: ");
            crystalBuy = Convert.ToInt32(Console.ReadLine());
          
            chek = (crystalBuy * crystalPrice) <= coins;

            if (chek)
            {
                crystalBuy *= Convert.ToInt32(chek);
                coins -= crystalPrice * crystalBuy;
               
                Console.WriteLine("\nВы,- \" Прекрасно.\"" +
                    "\nТорговец,- \" Славная сделка вышла. До встречи и будь здоров\"");
            }
            else
            {
                Console.WriteLine("\nТорговец,- \" О, какое рвение, но у тебя не хватает монет. \"");
            }
            Console.WriteLine("- * - - - - - - - - - - - - - - - - - - - -  - * - - - - - - - - - - - - - - - - - - - - - * - ");
            Console.WriteLine("\nВаша сумка: {0} кристаллов, {1} золотых монет", crystalBuy, coins);

            Console.ReadKey();
        }
    }
}