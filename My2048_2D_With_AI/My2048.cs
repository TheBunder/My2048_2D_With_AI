using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My2048_2D_With_AI
{
    class My2048
    {

        private int[,] array;
        private int Score;

        public My2048(int size)
        {
            array = new int[size, size];
            reset(array);
            Score = 0;
            addNum();
            addNum();
        }
        public void addNum()
        {
            Random rand = new Random();
            int num2or4 = rand.Next(100);
            int num = 0;
            if (num2or4 < 85)
                num = 2;
            else
                num = 4;


            int place = rand.Next(cnt0s());
            bool found = false;
            int index0 = 0;
            int corantIndex = 0;
            for (int i = 0; i < array.GetLength(0) && !found; i++)
            {
                for (int j = 0; j < array.GetLength(0) && !found; j++)
                {
                    if (array[j, i] == 0)
                    {
                        if (index0 == place)
                        {
                            array[j, i] = num;
                            found = true;
                        }
                        index0++;
                    }
                    corantIndex++;
                }
            }

        }
        public void Right2048()
        {
            array = moveRight(array);
            array = fusionRight();
            array = moveRight(array);
            addNum();
        }
        public void Down2048()
        {
            array = moveDown(array);
            array = fusionDown();
            array = moveDown(array);
            addNum();
        }

        public void Left2048()
        {
            array = moveLeft(array);
            array = fusionLeft();
            array = moveLeft(array);
            addNum();
        }
        public void Up2048()
        {
            array = moveUp(array);
            array = fusionUp();
            array = moveUp(array);
            addNum();
        }
        private int[,] moveRight(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int u = array.GetLength(0) - 2; u >= 0; u--)
                {
                    bool blocked = false;
                    for (int j = 0; j < array.GetLength(0) && !blocked; j++)
                    {
                        if (u + 1 + j < array.GetLength(0) && array[i, u + 1 + j] == 0)
                        {
                            array[i, u + 1 + j] = array[i, u + j];
                            array[i, u + j] = 0;
                        }
                        else
                            blocked = true;
                    }
                }

            }
            return array;
        }
        private int[,] moveDown(int[,] array)
        {
            for (int i = array.GetLength(0) - 2; i >= 0; i--)
            {
                for (int u = 0; u < array.GetLength(0); u++)
                {
                    bool blocked = false;
                    for (int j = 0; j < array.GetLength(0) && !blocked; j++)
                    {
                        if (i + 1 + j < array.GetLength(0) && array[i + 1 + j, u] == 0)
                        {
                            array[i + 1 + j, u] = array[i + j, u];
                            array[i + j, u] = 0;
                        }
                        else
                            blocked = true;
                    }
                }

            }
            return array;
        }
        private int[,] moveLeft(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int u = 1; u < array.GetLength(0); u++)
                {
                    bool blocked = false;
                    for (int j = 0; j < array.GetLength(0) && !blocked; j++)
                    {
                        if (u - 1 - j >= 0 && array[i, u - 1 - j] == 0)
                        {
                            array[i, u - 1 - j] = array[i, u - j];
                            array[i, u - j] = 0;
                        }
                        else
                            blocked = true;
                    }
                }

            }
            return array;
        }
        private int[,] moveUp(int[,] array)
        {

            for (int i = 1; i < array.GetLength(0); i++)
            {
                for (int u = 0; u < array.GetLength(0); u++)
                {
                    bool blocked = false;
                    for (int j = 0; j < array.GetLength(0) && !blocked; j++)
                    {
                        if (i - 1 - j >= 0 && array[i - 1 - j, u] == 0)
                        {
                            array[i - 1 - j, u] = array[i - j, u];
                            array[i - j, u] = 0;
                        }
                        else
                            blocked = true;
                    }
                }

            }
            return array;
        }
        private int[,] fusionRight()
        {
            int[,] array = this.array;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = array.GetLength(0) - 2; j >= 0; j--)
                {
                    if (array[i, j] == array[i, j + 1])
                    {
                        array[i, j + 1] += array[i, j];
                        Score += array[i, j + 1];
                        array[i, j] = 0;
                    }
                }
            }
            return array;
        }
        private int[,] fusionDown()
        {
            int[,] array = this.array;
            for (int i = array.GetLength(0) - 2; i >= 0; i--)
            {
                for (int j = 0; j < array.GetLength(0); j++)
                {
                    if (array[i, j] == array[i + 1, j])
                    {
                        array[i + 1, j] += array[i, j];
                        Score += array[i + 1, j];
                        array[i, j] = 0;
                    }
                }
            }
            return array;
        }
        private int[,] fusionLeft()
        {
            int[,] array = this.array;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 1; j < array.GetLength(0); j++)
                {
                    if (array[i, j] == array[i, j - 1])
                    {
                        array[i, j - 1] += array[i, j];
                        Score += array[i, j - 1];
                        array[i, j] = 0;
                    }
                }
            }
            return array;
        }
        private int[,] fusionUp()
        {
            int[,] array = this.array;
            for (int i = 1; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(0); j++)
                {
                    if (array[i, j] == array[i - 1, j])
                    {
                        array[i - 1, j] += array[i, j];
                        Score += array[i - 1, j];
                        array[i, j] = 0;
                    }
                }
            }
            return array;
        }
        private int fakeFusionRight(int[,] arr, int times)
        {
            int fakeScore = 0;
            if (times <= 0)
            {
                return 0;
            }
            int[,] array = arr;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = array.GetLength(0) - 2; j >= 0; j--)
                {
                    if (array[i, j] == array[i, j + 1])
                    {
                        array[i, j + 1] += array[i, j];
                        fakeScore += array[i, j + 1];
                        array[i, j] = 0;
                    }
                }
            }
            times--;
            return fakeScore + Math.Max(Math.Max(fakeFusionDown((int[,])arr.Clone(), times), fakeFusionUp((int[,])arr.Clone(), times)), Math.Max(fakeFusionRight((int[,])arr.Clone(), times), fakeFusionLeft((int[,])arr.Clone(), times)));
        }
        private int fakeFusionLeft(int[,] arr, int times)
        {
            int fakeScore = 0;
            if (times <= 0)
            {
                return 0;
            }
            int[,] array = arr;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 1; j < array.GetLength(0); j++)
                {
                    if (array[i, j] == array[i, j - 1])
                    {
                        array[i, j - 1] += array[i, j];
                        fakeScore += array[i, j - 1];
                        array[i, j] = 0;
                    }
                }
            }
            times--;
            return fakeScore + Math.Max(Math.Max(fakeFusionDown((int[,])arr.Clone(), times), fakeFusionUp((int[,])arr.Clone(), times)), Math.Max(fakeFusionRight((int[,])arr.Clone(), times), fakeFusionLeft((int[,])arr.Clone(), times)));
        }
        private int fakeFusionDown(int[,] arr, int times)
        {
            int fakeScore = 0;
            if (times <= 0)
            {
                return 0;
            }

            int[,] array = arr;
            for (int i = array.GetLength(0) - 2; i >= 0; i--)
            {
                for (int j = 0; j < array.GetLength(0); j++)
                {
                    if (array[i, j] == array[i + 1, j])
                    {
                        array[i + 1, j] += array[i, j];
                        fakeScore += array[i + 1, j];
                        array[i, j] = 0;
                    }
                }
            }
            times--;
            return fakeScore + Math.Max(Math.Max(fakeFusionDown((int[,])arr.Clone(), times), fakeFusionUp((int[,])arr.Clone(), times)), Math.Max(fakeFusionRight((int[,])arr.Clone(), times), fakeFusionLeft((int[,])arr.Clone(), times)));//+left +right
        }

        private int fakeFusionUp(int[,] arr, int times)
        {
            int fakeScore = 0;
            if (times <= 0)
            {
                return 0;
            }

            int[,] array = arr;
            for (int i = 1; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(0); j++)
                {
                    if (array[i, j] == array[i - 1, j])
                    {
                        array[i - 1, j] += array[i, j];
                        fakeScore += array[i - 1, j];
                        array[i, j] = 0;
                    }
                }
            }
            times--;
            return fakeScore + Math.Max(Math.Max(fakeFusionDown((int[,])arr.Clone(), times), fakeFusionUp((int[,])arr.Clone(), times)), Math.Max(fakeFusionRight((int[,])arr.Clone(), times), fakeFusionLeft((int[,])arr.Clone(), times)));
        }
        public int move5()
        {
            int times = 2;
            int up = fakeFusionUp(moveUp((int[,])array.Clone()), times);
            int down = fakeFusionDown(moveDown((int[,])array.Clone()), times);
            int right = fakeFusionRight(moveRight((int[,])array.Clone()), times);
            int left = fakeFusionLeft(moveRight((int[,])array.Clone()), times);

            int max = Math.Max(Math.Max(left, right), Math.Max(up, down)); 
            if (max == right)
                return 0;
            else if (max == left)
                return 1;
            else if (max == down)
                return 2;
            else
                return 3;


        }
        enum Direction { RIGHT, LEFT, DOWN, UP }
        public bool isMovedRight()
        {
            bool canChang = false;
            if (array != moveRight(array))
            {
                canChang = true;
            }
            if (array != fusionRight())
            {
                canChang = true;
            }
            return canChang;
        }
        public bool isMovedLeft()
        {
            bool canChang = false;
            if (array != moveLeft(array))
            {
                canChang = true;
            }
            if (array != fusionLeft())
            {
                canChang = true;
            }
            return canChang;
        }
        private int cnt0s()
        {
            int cnt = 0;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(0); j++)
                {
                    if (array[i, j] == 0)
                    {
                        cnt++;
                    }
                }
            }

            return cnt;
        }
        private void reset(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
                for (int j = 0; j < array.GetLength(0); j++)
                {
                    array[i, j] = 0;
                }
        }
        //public void Draw2048()
        //{

        //    TRect piec = new TRect(0, 0, 8, 4, ConsoleColor.White);
        //    Console.ForegroundColor = ConsoleColor.White;

        //    for (int i = 0; i < array.GetLength(0); i++)
        //    {
        //        piec.SetY(4 * i);
        //        for (int j = 0; j < array.GetLength(0); j++)
        //        {
        //            piec.SetX(8 * j);
        //            if (array[i, j] != 0)
        //            {
        //                piec.SetFcolor((ConsoleColor)Math.Log(array[i, j], 2));
        //                piec.Draw();
        //                Console.SetCursorPosition(j * 8 + 1, i * 4 + 1);

        //                Console.WriteLine(("" + array[i, j]).PadRight(5, ' '));
        //            }
        //            else
        //            {
        //                piec.SetFcolor(ConsoleColor.White);
        //                piec.Draw();
        //                Console.SetCursorPosition(j * 8 + 1, i * 4 + 1);
        //                Console.Write("     ");
        //            }
        //        }

        //    }
        //    Console.ForegroundColor = ConsoleColor.White;
        //    Console.SetCursorPosition(0, 24);
        //    Console.WriteLine("SCORE: {0} POINTS", Score);
        //}

        public void Draw2048()
        {

            TRect piec = new TRect(0, 0, 8, 4, ConsoleColor.White);
            Console.ForegroundColor = ConsoleColor.White;

            for (int i = 0; i < array.GetLength(0); i++)
            {
                piec.SetY(4 * i);
                for (int j = 0; j < array.GetLength(0); j++)
                {
                    piec.SetX(8 * j);
                    if (array[i, j] != 0)
                    {
                        piec.SetFcolor((ConsoleColor)Math.Log(array[i, j], 2));
                        piec.Draw();
                        Console.SetCursorPosition(j * 8 + 1, i * 4 + 1);

                        Console.WriteLine(("" + array[i, j]).PadRight(5, ' '));
                    }
                    else
                    {
                        piec.SetFcolor(ConsoleColor.White);
                        piec.Draw();
                        Console.SetCursorPosition(j * 8 + 1, i * 4 + 1);
                        Console.Write("     ");
                    }
                }

            }
            TRect scr = new TRect(array.GetLength(0) * 8 + 3, 1, 22, 3, ConsoleColor.Yellow);
            scr.Draw();
            Console.SetCursorPosition(array.GetLength(0) * 8 + 4, 2);
            Console.WriteLine("SCORE: {0} POINTS", Score);
        }

        public void draw()
        {

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(0); j++)
                {
                    if (array[i, j] != 0)
                    {
                        Console.ForegroundColor = (ConsoleColor)Math.Log(array[i, j], 2);
                        Console.Write("|" + array[i, j] + "|");
                        Console.ResetColor();
                    }
                    else
                        Console.Write("| |");
                }
                Console.WriteLine();
            }

            Console.WriteLine("SCORE: {0} POINTS", Score);
        }
        
        public bool GameOver()
        {
            for (int i = 0; i < array.GetLength(0) - 1; i++)
            {
                for (int j = 0; j < array.GetLength(0) - 1; j++)
                {
                    if (array[i, j] == array[i + 1, j] || array[i, j] == array[i, j + 1])
                        return false;
                }
            }
            if (cnt0s() != 0)
                return false;
            return true;
        }
    }
}
