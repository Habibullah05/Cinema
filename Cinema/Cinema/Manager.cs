using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cinema.UI;
using Cinema.Logic;
using Cinema.Entities;
using System.Windows.Forms;

using Cinema.Logic;


namespace Cinema
{
    /// <summary>
    /// 
    /// </summary>
    partial class Manager
    {
         private Stack<UI.Menu> manager { set; get; } = new Stack<UI.Menu>();
        DataBase dataBase { set; get; } 

         private void Add_Back(UI.Menu menu)
        {
         
            manager.Push(menu);
           
            manager.Peek().Run();
        }
         private void Pop_Back()
        {
           
            manager.Pop();
             
            manager.Peek().Run();
        }
     
         private UI.MenuItem Back()
        {
            UI.MenuItem back = new UI.MenuItem()
            {
                Text = "Back              ",
                action = () => { Pop_Back(); }
            };
            return back;
        }

       
         private void Main_Menu()
        {
            Console.Clear();
            UI.Menu MainMenu = new UI.Menu("Main Menu");
            UI.MenuItem HallMenu = new UI.MenuItem()
            {
                Text = "Hall menu      ",
                action = () => {Hall_Menu(); }


            };
            UI.MenuItem MovieMenu = new UI.MenuItem()
            {
                Text = "Movie menu     ",
                action = () => { Movie_Menu(); }
            };
            UI.MenuItem TicketMenu = new UI.MenuItem()
            {
                Text = "Ticket menu    ",
                 action = () => Show_Movie("Select Movie")
            };
            UI.MenuItem StatisticsMenu = new UI.MenuItem()
            {
                Text = "Statistics menu",
                 action = () => Statistic_Menu()
            };
            UI.MenuItem SessionMenu = new UI.MenuItem()
            {
                Text = "Session menu   ",
                action = () =>{ Session_Menu(); }
            };
            UI.MenuItem Exit = new UI.MenuItem()
            {
                Text = "Exit           ",
                action = () => { Exit_save(); }
            };
            MainMenu.menus.Add(HallMenu);
            MainMenu.menus.Add(MovieMenu);
            MainMenu.menus.Add(SessionMenu);
            MainMenu.menus.Add(TicketMenu);
            MainMenu.menus.Add(StatisticsMenu);
            MainMenu.menus.Add(Exit);
            Add_Back(MainMenu);
            // MainMenu.Run();



        }

        /// <summary>
        /// Начало программы
        /// </summary>
        public void Start()
        {
            dataBase = DataBase.Load();
        
            Main_Menu();

        }
        private void Exit_save()
        {
           // XmlWriter.MyXmlSerializable(dataBase.halls, dataBase.movies, dataBase.sessions);

            Environment.Exit(0);

        }


















    }
}
