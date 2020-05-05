using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Tema_2_Hangman_Game.View
{
    /// <summary>
    /// Interaction logic for HangmanGame.xaml
    /// </summary>
    public partial class HangmanGame : Window
    {
        public static HangmanGame HangmanWindow;
        public object DisplayViewModel;
       
        public int CurrentView { get; set; }
        public int startGame;
        public DispatcherTimer dispatcherTimer = new DispatcherTimer();
        public string NameN { get; set; }
        public double delay;
        public double delaySec;
        public DateTime deadline;
        public DateTime deadlineMin;

        public HangmanGame(string nume,string source)
        {
            NameN = nume;
            HangmanWindow = this;

            DisplayViewModel = new All_categories();
            InitializeComponent();
            GameFrame.Children.Clear();
            GameFrame.Children.Add(new All_categories());
            CurrentView = 1;
            GameFrame.IsEnabled = false;
            player.Content = nume;
            dispatcherTimer.Tick += new EventHandler(DispatcherTimer_Tick);
            icon.Source= (ImageSource)new ImageSourceConverter().ConvertFromString(@"..\..\Images\"+source);
            Enable();
            delay = 0;
            delaySec = 30;
    }

        void Enable()
        {
            if (GameFrame.IsEnabled == false)
            {
                dispatcherTimer.Stop();
            }
        }

        public void ChangeView(int i)
        {
            if (i == 1)
            {
                DisplayViewModel = new All_categories();
                GameFrame.Children.Clear();
                GameFrame.Children.Add(new All_categories());
                CurrentView = 1;
            }
            else if (i == 2)
            {
                DisplayViewModel = new Cars();
                GameFrame.Children.Clear();
                GameFrame.Children.Add(new Cars());
                CurrentView = 2;
            }
            else if (i == 3)
            {
                DisplayViewModel = new Movies();
                GameFrame.Children.Clear();
                GameFrame.Children.Add(new Movies());
                CurrentView = 3;
            }
            else if (i == 4)
            {
                DisplayViewModel = new States();
                GameFrame.Children.Clear();
                GameFrame.Children.Add(new States());
                CurrentView = 4;
            }
        }

        public string name()
        {
            return NameN;
        }

        private void AboutBttn(object sender, RoutedEventArgs e)
        {
            string text = "Name: Hidoș Bianca - Sidonia \nGroup: 10LF381\nSpecialization: Applied Informatics (IA)";
            MessageBox.Show(text, "About");
        }

        public void timeLoad(double del, double del2)
        {
            delay = del;
            delaySec = del2;
            deadline = DateTime.Now.AddMinutes(delay);
            int secondsRemaining = (deadline - DateTime.Now).Seconds;
            int minutesRemaining = (deadline - DateTime.Now).Minutes;

            if (secondsRemaining >= 10)
                labelTime.Content = minutesRemaining.ToString() + " : " + secondsRemaining.ToString();
            else
                labelTime.Content = minutesRemaining.ToString() + " : 0" + secondsRemaining.ToString();

        }

        public void StartTimer()
        {
            //se seteaza momentul in care trebuie sa se opreaqsca timer-ul
            //se adauga la data curenta un numar de secunde egal cu delay-ul
            //mai exact, peste 20 de secunde, trebuie sa se opreasca timer-ul
            //se pot adauga si minute, ore, etc... la data curenta
            deadline = DateTime.Now.AddSeconds(delaySec);
            deadlineMin = DateTime.Now.AddMinutes(delay);
            dispatcherTimer.Start();
        }

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            int secondsRemaining = (deadline - DateTime.Now).Seconds;
            int minutesRemaining = (deadlineMin - DateTime.Now).Minutes;
            if (secondsRemaining == 0 && minutesRemaining == 0)
            {
                dispatcherTimer.Stop();
                dispatcherTimer.IsEnabled = false;
                GameFrame.IsEnabled = false;
                              
                delay = 0;
                stop.IsEnabled = false;
                start.IsEnabled = false;
                switch(CurrentView)
                {
                    case 1:
                        All_categories.All_categoriesWindow.setOKLOSE(1);
                        break;
                    case 2:
                        Cars.CarsWindow.setOKLOSE(1);
                        break;
                    case 3:
                        Movies.MoviesWindow.setOKLOSE(1);
                        break;
                    case 4:
                        States.StatesWindow.setOKLOSE(1);
                        break;
                }

                menu.IsEnabled = false;
                GameFrame.IsEnabled = false;
                grid.Visibility = Visibility.Visible;
                lbl.Content = "Time has expired!\n You lost the game!\nClick OK to access the game menu!";
            }
            else
            {
                Enable();
                if (secondsRemaining >= 10)
                    labelTime.Content = minutesRemaining.ToString() + " : " + secondsRemaining.ToString();
                else
                    labelTime.Content = minutesRemaining.ToString() + " : 0" + secondsRemaining.ToString();
                
            }
           
        }
        
        private void StartBttn(object sender, RoutedEventArgs e)
        {
            startGame = 1;
            GameFrame.IsEnabled = true;
            StartTimer();
        }

        private void StopBttn(object sender, EventArgs e)
        {
            GameFrame.IsEnabled = false;
            dispatcherTimer.Stop();
            delay = (deadline - DateTime.Now).Minutes;
            delaySec = (deadline - DateTime.Now).Seconds + delay * 60;
            deadline = DateTime.Now.AddSeconds(delaySec);
        }

        public double getDel()
        {
            dispatcherTimer.Stop();
            delay = (deadline - DateTime.Now).Minutes;
            
            return (deadline - DateTime.Now).Minutes;
        }

        public double getDelS()
        {
            dispatcherTimer.Stop();
                    
            delaySec = (deadline - DateTime.Now).Seconds + delay * 60;
            
            return (deadline - DateTime.Now).Seconds;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            menu.IsEnabled = true;
            grid.Visibility = Visibility.Hidden;
        }
    }
}
