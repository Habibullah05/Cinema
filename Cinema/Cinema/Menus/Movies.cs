/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cinema.Entities;
using Cinema.UI;

namespace Cinema.Menus
{
    class Movies : Movie
    {
        public List<Movie> movies;

        public Movies()
        {
            movies = new List<Movie>();
        }
        public void Add_Movie()
        {
            Hall hall = new Hall();
            Console.Write("Title:");
            hall.title = Console.ReadLine();
            Console.Write("Rows:");
            hall.num_rows = Int32.Parse(Console.ReadLine());
            Console.Write("Seats by row:");
            hall.num_seats = Int32.Parse(Console.ReadLine());
            Console.Write(" type(1. 2D, 2. 3D,3. IMAX )");



        }
        public override string ToString()
        {
            return base.ToString();
        }



        public override void Run()
        {
            int cursor = 0;

           
            //  menus.Add(HallMenu);
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

                        break;
                    default:
                        break;
                }
            }
        }
    }
}*/
