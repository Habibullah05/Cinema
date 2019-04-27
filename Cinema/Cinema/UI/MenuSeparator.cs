using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cinema.UI
{
    class MenuSeparator : MenuItem
    {
        public override void Draw(int Y, int X = 0)
        {
            //base.Draw(Y, X);


            int Height = 3;
            int Width = Text.Length;

            
                for (int i = 0; i < Width; ++i)
                {
                if (IsCursor)
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                else
                    Console.ForegroundColor = ConsoleColor.White;

                Console.SetCursorPosition(X + i, Y + 2);
                     Console.Write(Text);
                }

            
        }
    }
}

