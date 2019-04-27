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
        private void Statistic_Menu()
        {

            Console.Clear();

            UI.Menu StatisticMenu = new UI.Menu("Statistic Menu");

            UI.MenuItem StatisticMovie = new UI.MenuItem()
            {
                Text = "Statistic of Movie    ",
               action = () => { Show_Session("Statistic of Movie"); }


            };
            UI.MenuItem StatisticSesseoin = new UI.MenuItem()
            {
                Text = "Statistic of Sesseoin",
                action = () => { Show_Session("Statistic of Sesseoin"); }
            };


            StatisticMenu.menus.Add(StatisticSesseoin);
            StatisticMenu.menus.Add(StatisticMovie);
            StatisticMenu.menus.Add(Back());
            Add_Back(StatisticMenu);
        }

        private void Statistic_Movie(Session session)
        {
            Console.WriteLine(session.movie.ToString());
            Console.WriteLine();
            int percent = (100 / (session.hall.num_rows * session.hall.num_rows)) * session.tickets.Count;

            Console.WriteLine("General percentage of seats sold" + percent);

            Console.ReadKey();
            DialogResult res = MessageBox.Show("Seve station?", "Caption of window", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                XmlWriter writer = new XmlWriter();
                writer.Write(session, $"{session}.xml");
            }


        }
        private void Statistic_Session(Session session)
        {
            Console.WriteLine(session.ToString());
            Console.WriteLine();
            int percent = (100 / (session.hall.num_rows * session.hall.num_rows)) * session.tickets.Count;

            Console.WriteLine("General percentage of seats sold" + percent);

            Console.ReadKey();
            DialogResult res = MessageBox.Show("Seve station?", "Caption of window", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                XmlWriter writer = new XmlWriter();
                writer.Write(session.movie, $"{session.movie}.xml");
            }

        }
        private void Statistic_Time()
        {



        }


    }
}
