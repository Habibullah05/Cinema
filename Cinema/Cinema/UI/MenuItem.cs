using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cinema.UI
{
    public class MenuItem
    {
        public Action action;
        public string Text { get; set; }
        public bool IsCursor { get; set; }

        public MenuItem() {
            Text = " ";
            action = null;
            IsCursor = false;
        }

        public MenuItem(string text)
        {
            Text = text;
            action = null;
            IsCursor = false;
        }

        public virtual void  Draw(int Y, int X =0)
        {
            
            int Height = 3;
            int Width = Text.Length + 4;
            
            for (int j = 0; j < Height; ++j)
            {
                for (int i = 0; i < Width; ++i)
                {
                    if (IsCursor)
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                    else
                        Console.ForegroundColor = ConsoleColor.White;

                    Console.SetCursorPosition(X + i, Y + 2 + j);
                    if (i == 0 && j == 0) Console.Write('┌');

                        else if (i == 0 && j == Height - 1) Console.Write('└');

                        else if (i == Width - 1 && j == 0) Console.Write('┐');

                        else if (i == Width - 1 && j == Height - 1) Console.WriteLine('┘');

                        else if (i == 0 || i == Width - 1) Console.Write('│');

                        else if (j == 0 || j == Height - 1) Console.Write('─');

                        else if (i == 1 || i == Width - 2) Console.Write(' '); 

                    else Console.Write(Text[i - 2]);
                }
            }

        }

    }
}
