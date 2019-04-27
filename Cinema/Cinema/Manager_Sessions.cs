using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cinema.Logic;
using Cinema.UI;
using Cinema.Entities;
using System.Windows.Forms;

namespace Cinema
{
    partial class Manager
    {
        private void Session_Menu()
        {
            Console.Clear();

            UI.Menu SessionMenu = new UI.Menu("Session Menu");

            UI.MenuItem showAll = new UI.MenuItem()
            {
                Text = "Show all Sessions    ",
                action = () => { Show_Session("Show Session"); }


            };
            UI.MenuItem AddSession = new UI.MenuItem()
            {
                Text = "Add Session          ",
                action = () => { Print_Hall(null); }
            };

            //Action ac = () => Edit_Session(null);
            UI.MenuItem EditSession = new UI.MenuItem()
            {
                Text = "Edit Session         ",
                action = () => { Show_Session("Edit Session"); }
            };


            UI.MenuItem RemoveSession = new UI.MenuItem()
            {
                Text = "Remove Session       ",
                action = () => { Show_Session("Remove Session"); }
            };

            SessionMenu.menus.Add(showAll);
            SessionMenu.menus.Add(AddSession);
            SessionMenu.menus.Add(EditSession);
            SessionMenu.menus.Add(RemoveSession);
            SessionMenu.menus.Add(Back());
            Add_Back(SessionMenu);
        }

        private void Show_Session(string str, Movie movie = null)
        {
            Console.Clear();
            UI.Menu ShowSession = new UI.Menu(str);


            ShowSession.menus.Add(Back());
            UI.MenuItem tmp = new UI.MenuItem();
            if (str == "Tecket Session")
            {
                var MovieTec = from ds in dataBase.sessions where ds.movie.title == movie.title select ds;
                MovieTec = from mt in MovieTec orderby mt.time.ToString().Sum(c => Convert.ToInt32(c)) select mt;

                foreach (Session session in MovieTec)
                {
                    tmp = new UI.MenuItem()
                    {
                        Text = session.ToString(),
                        action = () => { Ticket_Run(session); }
                    };
                   
                        ShowSession.menus.Add(tmp);
                    
                }


            }
            else if(str== "Statistic of Sesseoin")
            {
                foreach (Session session in dataBase.sessions)
                {
                    tmp = new UI.MenuItem()
                    {
                        Text = session.ToString(),
                        action = () => { Statistic_Session(session); }
                    };

                    ShowSession.menus.Add(tmp);

                }

            }
            else if (str == "Statistic of Movie")
            {
                foreach (Session session in dataBase.sessions)
                {
                    tmp = new UI.MenuItem()
                    {
                        Text = session.movie.ToString(),
                        action = () => { Statistic_Movie(session); }
                    };

                    ShowSession.menus.Add(tmp);

                }

            }
            else
            {
                foreach (Session session in dataBase.sessions)
                {
                    if (str == "Edit Session")
                    {
                        tmp = new UI.MenuItem()
                        {
                            Text = session.ToString(),
                            action = () => { Print_Hall(session); }
                        };
                    }
                    else if (str == "Remove Session")
                    {
                        tmp = new UI.MenuItem()
                        {
                            Text = session.ToString(),
                            action = () => { Remove_Session(session); }
                        };

                    }
                    else
                    {
                        tmp = new UI.MenuItem()
                        {
                            Text = session.ToString(),

                        };
                    }

                 
                        ShowSession.menus.Add(tmp);
                    

                }
            }


            Add_Back(ShowSession);

        }

        private void Print_Hall(Session session)
        {
            Console.Clear();

            UI.Menu menu = new UI.Menu("Select hall");
            Action action;
            menu.menus.Add(Back());
            foreach (var item in dataBase.halls)
            {
               

                UI.MenuItem tmp = new UI.MenuItem()
                {
                    Text = item.ToString(),
                    action = () => { Print_Movie(item, session); }
                };

                menu.menus.Add(tmp);

            }
            Add_Back(menu);

        }

        private void Print_Movie(Hall hall, Session session)
        {
            Console.Clear();
            UI.Menu menu = new UI.Menu("Select hall");
          
            menu.menus.Add(Back());
            UI.MenuItem tmp = new UI.MenuItem();
            foreach (var item in dataBase.movies)
            {
                if (session == null)
                {
                    tmp = new UI.MenuItem()
                    {
                        Text = item.ToString(),
                        action = () => { Add_Session(hall, item); }

                    };
                  
                }
                else
                {
                     tmp = new UI.MenuItem()
                    {
                        Text = item.ToString(),
                        action = () => { Edit_Session(session, hall, item); }

                    };
            

                }
               // action += Pop_Back;

               

                menu.menus.Add(tmp);

            }
            Add_Back(menu);
            Pop_Back();

        }



        private void Add_Session(Hall hall, Movie movie)
        {
            Console.Clear();
            Console.WriteLine("Enter data new sessions");
            Session session = new Session();
            Console.Write("Select Session:");
            session.hall = hall;
            session.movie = movie;
            bool end = true;
            while (end)
            {
                end = false;
                try
                {
                    Console.WriteLine("Enter time");
                    Console.WriteLine("Enter day");
                    int day = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("Enter Month");
                    int Month = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("Enter Year");
                    int Year = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("Enter Hour");
                    int Hour = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("Enter Minute");
                    int Minute = Int32.Parse(Console.ReadLine());

                    session.time = new DateTime(Year, Month, day, Hour, Minute, 0);
                }
                catch (Exception)
                {
                    Console.Clear();
                    end = true;
                    Console.WriteLine("you entered an incorrect date");

                }


            }




            MessageBox.Show("Session added!!");

            dataBase.sessions.Add(session);
            dataBase.Write(dataBase);
            manager.Pop();
             manager.Pop();


        }
        private void Edit_Session(Session session, Hall hall, Movie movie)
        {
            Console.WriteLine("Enter data new sessions");

            Console.Write("Select Session:");
            session.hall = hall;
            session.movie = movie;
            Console.WriteLine("Enter time");
            bool end = true;
            while (end)
            {
                end = false;
                try
                {
                    Console.WriteLine("Enter time");
                    Console.WriteLine("Enter day");
                    int day = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("Enter Month");
                    int Month = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("Enter Year");
                    int Year = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("Enter Hour");
                    int Hour = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("Enter Minute");
                    int Minute = Int32.Parse(Console.ReadLine());

                    session.time = new DateTime(Year, Month, day, Hour, Minute, 0);
                }
                catch (Exception)
                {
                    Console.Clear();
                    end = true;
                    Console.WriteLine("you entered an incorrect date");

                }


            }



            MessageBox.Show("Session edited!!");
            manager.Pop();

        }
        private void Remove_Session(Session session)
        {
            //Console.Clear();
            DialogResult res = MessageBox.Show("Remove Session?", "Caption of window", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                //Console.WriteLine("Your answer is YES");
                dataBase.sessions.Remove(session);
                Pop_Back();
            }
            else
            {
                Show_Session("Remove sessions");
                // Console.WriteLine("Your answer is NO");
            }



        }
    }
}
