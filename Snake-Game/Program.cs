using System;
using System.Collections.Generic;
using System.Text;

namespace Snake_Game
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Snake snake = new Snake();
            snake.Run();
            Console.ReadLine();
        }
    }
}
