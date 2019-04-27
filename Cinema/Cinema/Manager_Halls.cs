using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cinema.Logic;
using Cinema.UI;
using Cinema.Entities;
using System.Windows.Forms;
using System.ComponentModel.DataAnnotations;

namespace Cinema
{
    partial class Manager
    {
         private void Hall_Menu()
        {
            Console.Clear();

            UI.Menu HallMenu = new UI.Menu("Hall Menu");

            UI.MenuItem showAll = new UI.MenuItem()
            {
                Text = "Show all halls    ",
                action = () => { Show_Hall("Show Hall"); }


            };
            UI.MenuItem AddHall = new UI.MenuItem()
            {
                Text = "Add hall          ",
                action = () => { Add_Hall(); }
            };

            Action ac = () => Edit_Hall(null);
            UI.MenuItem EditHall = new UI.MenuItem()
            {
                Text = "Edit hall         ",
                action = () => { Show_Hall("Edit hall"); }
            };


            UI.MenuItem RemoveHall = new UI.MenuItem()
            {
                Text = "Remove hall       ",
                action = () => { Show_Hall("Remove hall"); }
            };

            HallMenu.menus.Add(showAll);
            HallMenu.menus.Add(AddHall);
            HallMenu.menus.Add(EditHall);
            HallMenu.menus.Add(RemoveHall);
            HallMenu.menus.Add( Back());
             Add_Back(HallMenu);
        }

         private void Show_Hall(string str ,Session session=null)
        {
            Console.Clear();
            UI.Menu ShowHall = new UI.Menu(str);


            ShowHall.menus.Add( Back());
            UI.MenuItem tmp = new UI.MenuItem();
            Action action;
            foreach (Hall hall in dataBase.halls)
            {
                if (str == "Edit hall")
                {
                    tmp = new UI.MenuItem()
                    {
                        Text = hall.ToString(),
                        action = () => { Edit_Hall(hall); }
                    };
                }
                else if (str == "Remove hall")
                {
                    tmp = new UI.MenuItem()
                    {
                        Text = hall.ToString(),
                        action = () => { Remove_Hall(hall); }
                    };

                }
                else
                {
                    tmp = new UI.MenuItem()
                    {
                        Text = hall.ToString(),

                    };
                }
                ShowHall.menus.Add(tmp);
            }


             Add_Back(ShowHall);

        }

         private Hall GetHall2(Hall hall)
        {

            Show_Hall("Session hall");


            return hall;
        }

         private void Add_Hall()
        {
            Console.Clear();
            Console.WriteLine("Entr data new hall");
            Hall hall = new Hall();
            Console.Write("Title:");
            hall.title = Console.ReadLine();
            Console.Write("Rows:");
            hall.num_rows = byte.Parse(Console.ReadLine());
            Console.Write("Seats by row:");
            hall.num_seats = byte.Parse(Console.ReadLine());
            Console.Write("Type(1. 2D, 2. 3D,  3. IMAX )");

            hall.enumType = Int32.Parse(Console.ReadLine());
            switch (hall.enumType)
            {
                case (int)Hall.types._2: hall.TypeStr = "2D"; break;
                case (int)Hall.types._3D: hall.TypeStr = "3D"; break;
                case (int)Hall.types._IMAX: hall.TypeStr = "IMAX"; break;
            }
            var results = new List<ValidationResult>();
            var context = new ValidationContext(hall);
            if (!Validator.TryValidateObject(hall, context, results, true))
            {
                foreach (var error in results)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
            }

           
            MessageBox.Show("Hall added!!");
            dataBase.halls.Add(hall);
            dataBase.Write(dataBase);
            

        }

         private void Edit_Hall(Hall hall)
        {
            Console.Clear();
            Console.WriteLine("Edited hall!!!");
            Console.WriteLine();
            Console.Write("Title:");
            hall.title = Console.ReadLine();
            Console.Write("Rows:");
            hall.num_rows = byte.Parse(Console.ReadLine());
            Console.Write("Seats by row:");
            hall.num_seats = byte.Parse(Console.ReadLine());
            Console.Write("Type(1. 2D, 2. 3D,  3. IMAX )");
            Console.Write("\nType (1. 2D   2. 3D  3. IMAX): ");
            switch (Console.ReadLine())
            {
                case "1": hall.TypeStr = "2D"; break;
                case "2": hall.TypeStr = "3D"; break;
                case "3": hall.TypeStr = "IMAX"; break;
            }

            MessageBox.Show("Hall edited!!");
            dataBase.Write(dataBase);
            Pop_Back();

        }

         private void Remove_Hall(Hall hall)
        {
            //Console.Clear();
            DialogResult res = MessageBox.Show("Remove Hall?", "Caption of window", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                //Console.WriteLine("Your answer is YES");
                dataBase.halls.Remove(hall);
                 Pop_Back();
            }
            else
            {
                Show_Hall("Remove hall");
                // Console.WriteLine("Your answer is NO");
            }



        }



    }
}
