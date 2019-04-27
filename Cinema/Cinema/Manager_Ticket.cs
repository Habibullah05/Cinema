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
        

        private void Ticket_Run(Session session)
        {
            int cursorCols = 0;
            int cursorRols = 0;
            Ticket[,] tickets = new Ticket[session.hall.num_rows, session.hall.num_seats];

            for (int i = 0; i < session.hall.num_rows; i++)
            {
                for (int l = 0; l < session.hall.num_seats; l++)
                {
                    //Console.Write(i + "," + l + " ");
                   
                    
                        tickets[i, l] = new Ticket
                        {
                            row = i,
                            seats = l,
                            IsSold = false,
                            IsCursor = false
                        };
                    
                }

            }
            foreach (var item in session.tickets)
            {
                tickets[item.row, item.seats].IsSold = true;

            }
            Console.WriteLine("Enter Backspace");
            while (true)
            {
                Console.Clear();
         
           
                
                Console.WriteLine("Enter Backspace");
            
            tickets[cursorCols, cursorRols].IsCursor = true;
          
                for (int i = 0; i <= session.hall.num_rows; i++)
                {
                    for (int l = 0; l <=session.hall.num_seats; l++)
                    {
                        if (i == 0&&l>0)
                        {
                            Console.Write(" " +l + " ");

                        }
                        else if  (i ==0)
                        {
                            Console.WriteLine("  ");
                        }
                       else if (l == 0&&i>0)
                        {
                            Console.Write("\n"+ i + "\n ");

                        }

                       else if (i>0&&l>0)
                        {
                            tickets[i-1, l-1].Draw_Hall(i *3, l *3);
                        }
                           
                       
                    }
                    
                    Console.WriteLine();
                }
                

                ConsoleKeyInfo key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (cursorRols >0)
                        {
                            tickets[cursorCols, cursorRols].IsCursor = false;
                           // menus[cursor].IsCursor = false;
                            --cursorRols;
                            tickets[cursorCols, cursorRols].IsCursor = true;

                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (cursorRols < session.hall.num_rows-1)
                        {
                            tickets[cursorCols, cursorRols].IsCursor = false;
                            // menus[cursor].IsCursor = false;
                            ++cursorRols;
                            tickets[cursorCols, cursorRols].IsCursor = true;


                        }
                        break;
                    case ConsoleKey.LeftArrow:
                        if (cursorCols >0)
                        {
                            tickets[cursorCols, cursorRols].IsCursor = false;
                            // menus[cursor].IsCursor = false;
                           --cursorCols;
                            tickets[cursorCols, cursorRols].IsCursor = true;

                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (cursorCols < session.hall.num_seats-1)
                        {
                            tickets[cursorCols, cursorRols].IsCursor = false;
                            // menus[cursor].IsCursor = false;
                            ++cursorCols;
                            tickets[cursorCols, cursorRols].IsCursor = true;

                        }
                        break;
                    case ConsoleKey.Backspace:
                        Pop_Back();
                        break;
                    case ConsoleKey.Enter:
                        if (tickets[cursorCols, cursorRols].IsSold ==false)
                        {                    
                        tickets[cursorCols, cursorRols].IsSold = true;
                        session.tickets.Add(tickets[cursorCols, cursorRols]);
                        dataBase.Write(dataBase);
                        DialogResult res = MessageBox.Show("Print ticket?", "Caption of window", MessageBoxButtons.YesNo);
                        if (res == DialogResult.Yes)
                        {
                            XmlWriter writer = new XmlWriter();
                                writer.Write(tickets[cursorCols, cursorRols], $"{cursorCols}.{cursorRols}.{session.movie.title}.{session.hall.title}");
                           // string path = $"_{session.tickets[session.tickets.Count].row}_{session.tickets[session.tickets.Count].seats}.xml";
                          // writer.Print_Ticet(session);
                            
                            Pop_Back();
                        }
                        }
                        break;
                    default:
                        break;
                }
            }
        }

           


        }
    }

