using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cinema.Entities;

namespace Cinema.Entities
{/// <summary>
/// БилетЖ
/// </summary>
    public class Ticket
    {
        /// <summary>
        /// Ряд
        /// </summary>
       public int row { set; get; }
        /// <summary>
        /// Места
        /// </summary>
       public int seats { set; get; }
        /// <summary>
        /// Продан или нет
        /// </summary>
       public bool IsSold { get; set; }
        /// <summary>
        /// курсор
        /// </summary>
        public bool IsCursor { get; set; } 

        /// <summary>
        /// Рисовка Зала
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        public void Draw_Hall(int X, int Y)
        {
            if (IsCursor)
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            int curX = Console.CursorLeft+3, curY = Console.CursorTop;
            Console.SetCursorPosition(X, Y);
            Console.Write("┌─┐");
            Console.SetCursorPosition(X, Y +1);
            if (IsSold)
            {
                Console.Write("│X│ ");
            }
            else
            {
                Console.Write("│ │ ");
            }
            Console.SetCursorPosition(X, Y + 2);
            Console.Write("└─┘");
            Console.SetCursorPosition(curX, curY);
            if (IsCursor)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }

        }

    }
}
