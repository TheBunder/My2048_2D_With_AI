using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace My2048_2D_With_AI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            /*
            Console.WriteLine("how big do you want the borad to be");
            int size = int.Parse(Console.ReadLine());
            My2048 row = new My2048(size);
            Console.Clear();
            row.Draw2048();
            bool end = false;

            do
            {
                if (Console.KeyAvailable)
                {
                    Console.Clear();
                    ConsoleKeyInfo k = Console.ReadKey();
                    while (Console.KeyAvailable)
                    {
                        Console.ReadKey();
                    }

                    if (k.Key == ConsoleKey.Escape)
                        end = true;

                    if (k.Key == ConsoleKey.RightArrow)
                        row.Right2048();

                    else if (k.Key == ConsoleKey.LeftArrow)
                        row.Left2048();
                    else if (k.Key == ConsoleKey.DownArrow)
                        row.Down2048();
                    else if (k.Key == ConsoleKey.UpArrow)
                        row.Up2048();


                    row.Draw2048();

                    if (row.GameOver())
                        end = true;
                }
                Thread.Sleep(200);
            } while (!end);

            Console.WriteLine("Game Over");
            Console.ReadLine();

            */

            AI();
           
           
        }
        public static void AI()
        {
            /*
            Console.WriteLine("how big do you want the borad to be");
            int size = int.Parse(Console.ReadLine());
            */
            My2048 row = new My2048(4);
            Console.Clear();
            row.Draw2048();
            bool end = false;

            do
            {


                /*
                    ConsoleKeyInfo k = Console.ReadKey();

                    if (k.Key == ConsoleKey.Escape)
                        end = true;
                */
                if (row.move5() == 0)
                    row.Right2048();
                else if (row.move5() == 1)
                    row.Left2048();
                else if (row.move5() == 2)
                    row.Down2048();
                else if (row.move5() == 3)
                    row.Up2048();


                row.Draw2048();

                if (row.GameOver())
                    end = true;
                Thread.Sleep(600);
            } while (!end);
            Console.SetCursorPosition(0,4 * 7+ 1);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(@" ▄▄▄▄▄▄▄▄▄▄▄  ▄▄▄▄▄▄▄▄▄▄▄  ▄▄       ▄▄  ▄▄▄▄▄▄▄▄▄▄▄       ▄▄▄▄▄▄▄▄▄▄▄  ▄               ▄  ▄▄▄▄▄▄▄▄▄▄▄  ▄▄▄▄▄▄▄▄▄▄▄ 
▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌▐░░▌     ▐░░▌▐░░░░░░░░░░░▌     ▐░░░░░░░░░░░▌▐░▌             ▐░▌▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌
▐░█▀▀▀▀▀▀▀▀▀ ▐░█▀▀▀▀▀▀▀█░▌▐░▌░▌   ▐░▐░▌▐░█▀▀▀▀▀▀▀▀▀      ▐░█▀▀▀▀▀▀▀█░▌ ▐░▌           ▐░▌ ▐░█▀▀▀▀▀▀▀▀▀ ▐░█▀▀▀▀▀▀▀█░▌
▐░▌          ▐░▌       ▐░▌▐░▌▐░▌ ▐░▌▐░▌▐░▌               ▐░▌       ▐░▌  ▐░▌         ▐░▌  ▐░▌          ▐░▌       ▐░▌
▐░▌ ▄▄▄▄▄▄▄▄ ▐░█▄▄▄▄▄▄▄█░▌▐░▌ ▐░▐░▌ ▐░▌▐░█▄▄▄▄▄▄▄▄▄      ▐░▌       ▐░▌   ▐░▌       ▐░▌   ▐░█▄▄▄▄▄▄▄▄▄ ▐░█▄▄▄▄▄▄▄█░▌
▐░▌▐░░░░░░░░▌▐░░░░░░░░░░░▌▐░▌  ▐░▌  ▐░▌▐░░░░░░░░░░░▌     ▐░▌       ▐░▌    ▐░▌     ▐░▌    ▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌
▐░▌ ▀▀▀▀▀▀█░▌▐░█▀▀▀▀▀▀▀█░▌▐░▌   ▀   ▐░▌▐░█▀▀▀▀▀▀▀▀▀      ▐░▌       ▐░▌     ▐░▌   ▐░▌     ▐░█▀▀▀▀▀▀▀▀▀ ▐░█▀▀▀▀█░█▀▀ 
▐░▌       ▐░▌▐░▌       ▐░▌▐░▌       ▐░▌▐░▌               ▐░▌       ▐░▌      ▐░▌ ▐░▌      ▐░▌          ▐░▌     ▐░▌  
▐░█▄▄▄▄▄▄▄█░▌▐░▌       ▐░▌▐░▌       ▐░▌▐░█▄▄▄▄▄▄▄▄▄      ▐░█▄▄▄▄▄▄▄█░▌       ▐░▐░▌       ▐░█▄▄▄▄▄▄▄▄▄ ▐░▌      ▐░▌ 
▐░░░░░░░░░░░▌▐░▌       ▐░▌▐░▌       ▐░▌▐░░░░░░░░░░░▌     ▐░░░░░░░░░░░▌        ▐░▌        ▐░░░░░░░░░░░▌▐░▌       ▐░▌
 ▀▀▀▀▀▀▀▀▀▀▀  ▀         ▀  ▀         ▀  ▀▀▀▀▀▀▀▀▀▀▀       ▀▀▀▀▀▀▀▀▀▀▀          ▀          ▀▀▀▀▀▀▀▀▀▀▀  ▀         ▀");
            Console.ReadLine();

        }
    }
}
