using System;
using System.Threading;

namespace Snake_Game
{
    public class Snake
    {
        public int Width = Console.WindowWidth;
        public int Height = Console.WindowHeight;

        public int[] X = new int[100];
        public int[] Y = new int[100];

        public int FoodX;
        public int FoodY;

        public int SnakeBody = 3;
        public bool FoodNeeded = true;
        public bool GameRunning = true;

        public char Key;
        Random Rdm = new Random();

        public Snake()
        {
            X[0] = 5;
            Y[0] = 5;
        }

        public void Run()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.CursorVisible = false;

            DrawBorder();
            MainMenue();
            ConsoleKeyInfo menueKey = Console.ReadKey();
            FoodX = Rdm.Next(2, Width - 2);
            FoodY = Rdm.Next(2, Height - 2);

            if (menueKey.KeyChar.Equals('p'))
            {
                while (GameRunning)
                {
                    DrawBorder();
                    Input();
                    Logic();
                }

            }
        }

        public void Logic()
        {
            if (foodEaten())
            {
                SnakeBody += 5;
                FoodX = Rdm.Next(2, Width - 2);
                FoodY = Rdm.Next(2, Height - 2);
            }

            for (int i = SnakeBody; i > 1; i--)
            {
                X[i - 1] = X[i - 2];
                Y[i - 1] = Y[i - 2];
            }

            Movement();

            for (int i = 1; i <= (SnakeBody - 1); i++)
            {
                WriteHead(X[0], Y[0]);
                WritePoint(X[i], Y[i]);
                GenerateFood(FoodX,FoodY); ;
            }
            Thread.Sleep(5);
        }

        private void WriteHead(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write("O");
        }

        public void Input()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey(true);
                Key = consoleKeyInfo.KeyChar;
            }
        }

        private void Movement()
        {
            switch (Key)
            {
                case 'w':
                    Y[0]--;
                    break;
                case 's':
                    Y[0]++;
                    break;
                case 'a':
                    X[0]--;
                    break;
                case 'd':
                    X[0]++;
                    break;
            }
        }

        public void GenerateFood(int FoodX,int FoodY)
        {
            if (FoodX != X[0] && FoodY != Y[0])
            {
                WriteFood(FoodX, FoodY);
            }

            FoodNeeded = false;
        }

        public bool foodEaten()
        {
            if (FoodX == X[0] && FoodY == Y[0])
            {
                return true;
            }
            return false;
        }

        public void WritePoint(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write("■");
        }

        public void WriteFood(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write("#");
        }

        private void MainMenue()
        {
            string titel = "SNAKE";
            Console.SetCursorPosition((Width / 2) - (titel.Length / 2), Height / 2);
            Console.Write(titel);
            string menue = "NEW GAME - PRESS P";
            Console.SetCursorPosition((Width / 2) - (menue.Length / 2), Height / 2 + 1);
            Console.Write(menue);
            string info = "CONTROL THE SNAKE WITH W-A-S-D";
            Console.SetCursorPosition((Width / 2) - (info.Length / 2), (Height / 2) + 2);
            Console.Write(info);
        }

        public void DrawBorder()
        {
            Console.Clear();
            for (int i = 0; i < Width - 2; i++)
            {
                Console.SetCursorPosition(i + 1, 1);
                Console.Write("#");
            }
            for (int i = 0; i < Height - 2; i++)
            {
                Console.SetCursorPosition(1, i + 1);
                Console.Write("#");
            }
            for (int i = 0; i < Width - 2; i++)
            {
                Console.SetCursorPosition(i + 1, Height - 1);
                Console.Write("#");
            }
            for (int i = 0; i < Height - 2; i++)
            {
                Console.SetCursorPosition(Width - 2, i + 1);
                Console.Write("#");
            }
        }
    }
}
