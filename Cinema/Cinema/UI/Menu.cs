using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cinema.Entities;
//using Cinema.Menus;
using Cinema.Logic;

namespace Cinema.UI
{
    class Menu
    {
        public List<MenuItem> menus { get; set; }
        string Title { get; set; }
        public Menu(string name = "MainMenu")
        {
            this.menus = new List<MenuItem>();
            Title = name;
          
        }


        public virtual void Run()
        {

            Console.Clear();
            Console.WriteLine("\t" + Title);
            int cursor = 0;
            menus[cursor].IsCursor = true;
            while (true)
            {
                for (int i = 0; i < menus.Count; i++)
                {
                    menus[i].Draw(i * 3);
                }

                ConsoleKeyInfo key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (cursor > 0)
                        {
                            menus[cursor].IsCursor = false;
                            --cursor;
                            menus[cursor].IsCursor = true;

                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (cursor < menus.Count - 1)
                        {
                            menus[cursor].IsCursor = false;
                            ++cursor;
                            menus[cursor].IsCursor = true;

                        }
                        break;
                    case ConsoleKey.Enter:
                       
                        if (menus[cursor].action!=null)
                        {
                            Console.Clear();
                            menus[cursor].IsCursor = false;
                            menus[cursor].action.Invoke();
                            cursor = 0;
                            menus[cursor].IsCursor = true;
                           
                        }
                            break;
                            default:
                        break;
                        }




                }


            }

        }
    }
