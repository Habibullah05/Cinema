/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cinema.UI;
using Cinema.Entities;


namespace Cinema.Menus
{
    class Halls : Hall
    {
        public List<Hall> halls;

        public Halls()
        {
            halls = new List<Hall>();
        }
        public void Add_Hall()
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

            Console.Clear();
            MenuItem showAll = new MenuItem()
            {
                Text = "Show all halls",
                //action = () => { halls.}

                // action = () =>;
            };
            MenuItem AddHall = new MenuItem()
            {
                Text = "Add hall      ",
                // action = () => Halls.Run()
            };
            MenuItem EditHall = new MenuItem()
            {
                Text = "Edit hall     ",
                // action = () => Halls.Run()
            };
            MenuItem RemoveHall = new MenuItem()
            {
                Text = "Remove hall   ",
                // action = () => Halls.Run()
            };
            menus.Add(showAll);
            menus.Add(AddHall);
            menus.Add(EditHall);
            menus.Add(RemoveHall);
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
