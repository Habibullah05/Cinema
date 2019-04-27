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
        private void Movie_Menu()
        {
            Console.Clear();
            UI.Menu MovieMenu = new UI.Menu("Movie Menu");
            UI.MenuItem ShowAllMovies = new UI.MenuItem()
            {
                Text = "Show all movies   ",
                action = () => { Show_Movie("Show movie"); }
            };
            UI.MenuItem AddMovies = new UI.MenuItem()
            {
                Text = "Add movies        ",
                action = () => { Add_Movie(); }
            };
            UI.MenuItem EditMovies = new UI.MenuItem()
            {
                Text = "Edit movies       ",
                action = () => { Show_Movie("Edit movie"); }
            };
            UI.MenuItem ChangeMovie = new UI.MenuItem()
            {
                Text = "Change movie state",
                action = () => Show_Movie("Change Movie")
            };
            UI.MenuItem RemoveMovies = new UI.MenuItem()
            {
                Text = "Remove movies     ",
                action = () => { Show_Movie("Remove movie"); }
            };

            MovieMenu.menus.Add(ShowAllMovies);
            MovieMenu.menus.Add(AddMovies);
            MovieMenu.menus.Add(EditMovies);
            MovieMenu.menus.Add(ChangeMovie);
            MovieMenu.menus.Add(RemoveMovies);
            MovieMenu.menus.Add( Back());
             Add_Back(MovieMenu);

        }

        private void Show_Movie(string str)
        {
            Console.Clear();
            UI.Menu ShowMovie = new UI.Menu(str);
            ShowMovie.menus.Add( Back());
            UI.MenuItem tmp = new UI.MenuItem();

            var Past = from dm in dataBase.movies where dm.ConditionStr == "Past" select dm ;

            var Current = from dm in dataBase.movies where dm.ConditionStr == "Current" select dm as Movie;
            var Future = from dm in dataBase.movies where dm.ConditionStr == "Future" select dm as Movie;
            if (str == "Show movie")
            {
                //Console.WriteLine(Past.ToString());
                if (Past!=null)
                {
                    UI.MenuSeparator P_S = new MenuSeparator()
                    {
                        Text = "-Past-----------"
                    };
                    ShowMovie.menus.Add(P_S);
                    foreach (Movie movie in Past)
                    {

                        tmp = new UI.MenuItem()
                        {
                            Text = movie.ToString(),
                            //action = () => { Edit_Movie(movie); }
                        };
                        ShowMovie.menus.Add(tmp);



                    }
                }
                

                UI.MenuSeparator P_C = new MenuSeparator()
                {
                    Text = "-Current-----------"
                };
                ShowMovie.menus.Add(P_C);
                foreach (Movie movie in Current)
                {
                   
                        tmp = new UI.MenuItem()
                        {
                            Text = movie.ToString(),
                            //action = () => { Edit_Movie(movie); }
                        };
                        ShowMovie.menus.Add(tmp);

                    
                }

                UI.MenuSeparator P_F = new MenuSeparator()
                {
                    Text = "-Future-----------"
                };
                ShowMovie.menus.Add(P_F);
                foreach (Movie movie in Future)
                {
                   
                        tmp = new UI.MenuItem()
                        {
                            Text = movie.ToString(),
                           // action = () => { Edit_Movie(movie); }
                        };
                        ShowMovie.menus.Add(tmp);

                    
                }
            }
            else if (str == "Select Movie")
            {
                foreach (Movie movie in Current)
                {

                    tmp = new UI.MenuItem()
                    {
                        Text = movie.ToString(),
                        action = () => { Show_Session("Tecket Session",movie); }
                    };
                    ShowMovie.menus.Add(tmp);



                }

            }
            else
            {

                foreach (Movie movie in dataBase.movies)
                {
                    if (str == "Edit movie")
                    {
                        tmp = new UI.MenuItem()
                        {
                            Text = movie.ToString(),
                            action = () => { Edit_Movie(movie); }
                        };
                    }
                    else if (str == "Remove movie")
                    {
                        tmp = new UI.MenuItem()
                        {
                            Text = movie.ToString(),
                            action = () => { Remove_Movie(movie); }
                        };
                    }
                    else if (str == "Change Movie")
                    {
                        tmp = new UI.MenuItem()
                        {
                            Text = movie.ToString(),
                            action = () => { Change_Movie(movie); }
                        };
                    }
                    ShowMovie.menus.Add(tmp);
                }


            }
             Add_Back(ShowMovie);
        }

        private void Add_Movie()
        {
            Console.Clear();
            Console.WriteLine("Enter data new movie");
            Movie movie = new Movie();
            Console.Write("Title:");
            movie.title = Console.ReadLine();
            Console.Write("Year:");
            movie.yearIssue = Int32.Parse(Console.ReadLine());
            Console.Write("Genre:");
            movie.genre = Console.ReadLine();
            Console.Write("Producer:");
            movie.producer = Console.ReadLine();
            Console.Write("Description:");
            movie.description = Console.ReadLine();
            Console.Write("Condition(1. Past, 2.Current, 3.Future)");
            switch (Int32.Parse(Console.ReadLine()))
            {
                case (int)Movie.condition.Past: movie.ConditionStr = "Past"; break;
                case (int)Movie.condition.Current: movie.ConditionStr = "Current"; break;
                case (int)Movie.condition.Future: movie.ConditionStr = "Future"; break;
            }

            MessageBox.Show("Movie added!!");

            dataBase.movies.Add(movie);
            dataBase.Write(dataBase);

        }

        private void Change_Movie(Movie movie)
        {
            UI.Menu Change = new UI.Menu($"Choose state for '{movie.title}'");

            UI.MenuItem Past = new UI.MenuItem()
            {
                Text = "Past",
                action = () => { movie.ConditionStr = "Past"; }

            };
            UI.MenuItem Current = new UI.MenuItem()
            {
                Text = "Current",
                action = () => { movie.ConditionStr = "Current"; }
            };
            UI.MenuItem Future = new UI.MenuItem()
            {
                Text = "Future",
                action = () => { movie.ConditionStr = "Future"; }
            };

            switch (movie.ConditionStr)
            {
                case "Past": Past.IsCursor = true; break;
                case "Current": Current.IsCursor = true; break;
                case "Future": Future.IsCursor = true; break;
                default:
                    break;
            }
            Change.menus.Add( Back());

            Change.menus.Add(Past);
            Change.menus.Add(Current);
            Change.menus.Add(Future);
             Add_Back(Change);

        }

        private void Edit_Movie(Movie movie)
        {
            //Console.Clear();
            Console.Clear();
            Console.WriteLine("Entr data new hall");
            Console.Write("Title:");
            movie.title = Console.ReadLine();
            Console.Write("Year:");
            movie.yearIssue = Int32.Parse(Console.ReadLine());
            Console.Write("Genre:");
            movie.genre = Console.ReadLine();
            Console.Write("Producer:");
            movie.producer = Console.ReadLine();
            Console.Write("Description:");
            movie.description = Console.ReadLine();
            Console.Write("Condition(1. Past, 2.Current, 3.Future)");
            switch (Int32.Parse(Console.ReadLine()))
            {
                case (int)Movie.condition.Past: movie.ConditionStr = "Past"; break;
                case (int)Movie.condition.Current: movie.ConditionStr = "Current"; break;
                case (int)Movie.condition.Future: movie.ConditionStr = "Future"; break;
            }

            MessageBox.Show("Movie Edided!!");
            dataBase.Write(dataBase);
            //MessageBox.Show("Hall added!!");

        }

        private void Remove_Movie(Movie movie)
        {
            //Console.Clear();
            DialogResult res = MessageBox.Show("Remove Movie?", "Caption of window", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                //Console.WriteLine("Your answer is YES");
                dataBase.movies.Remove(movie);
                Pop_Back();
            }
            else
            {
                // Show_Hall("Remove hall");
                // Console.WriteLine("Your answer is NO");
            }



        }

    }
}
