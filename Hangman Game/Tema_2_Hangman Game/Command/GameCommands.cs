using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Tema_2_Hangman_Game.View;
using Tema_2_Hangman_Game.ViewModel;

namespace Tema_2_Hangman_Game.Command
{
    class GameCommands 
    {
        private GameViewModel gameVM;
        int okA_1 = 0, okC_1 = 0, okM_1 = 0, okS_1 = 0;

        public GameCommands(GameViewModel userVm)
        {
            this.gameVM = userVm;
            gameVM.CurrentCategories = 1;
        }

        public void Categories(object obj)
        {
            int cat = Convert.ToInt32(obj);
            gameVM.CurrentCategories = cat;
            gameVM.UserGame.CurrentCat = cat;
            HangmanGame.HangmanWindow.ChangeView(cat);
        }

        public void Check(object obj)
        {
            int okLOSE;
            gameVM.UserGame.Statistics[0] += 1;
            if (gameVM.CurrentCategories == 1)
            {
                okC_1 = 0;
                okM_1 = 0;
                okS_1 = 0;
                okLOSE= All_categories.All_categoriesWindow.getOKLOSE();
                gameVM.UserGame.CurrentCat = 1;
                if (okLOSE == 1)
                {
                    gameVM.UserGame.Statistics[1] += 1;
                    okA_1 = 0;
                }
                else
                {
                    okA_1 += 1;
                }
               
            }
            if (gameVM.CurrentCategories == 2)
            {
                okA_1 = 0;
                okM_1 = 0;
                okS_1 = 0;
                okLOSE = Cars.CarsWindow.getOKLOSE();
                gameVM.UserGame.CurrentCat = 2;
                if (okLOSE == 1)
                {
                    gameVM.UserGame.Statistics[1] += 1;
                    okC_1 = 0;
                }
                else
                {
                    okC_1 += 1;
                }
            }
            if (gameVM.CurrentCategories == 3)
            {
                okA_1 = 0;
                okC_1 = 0;
                okS_1 = 0;
                okLOSE = Movies.MoviesWindow.getOKLOSE();
                gameVM.UserGame.CurrentCat = 3;
                if (okLOSE == 1)
                {
                    gameVM.UserGame.Statistics[1] += 1;
                    okM_1 = 0;
                }
                else
                {
                    okM_1 += 1;
                }
            }
            if (gameVM.CurrentCategories == 4)
            {
                okA_1 = 0;
                okC_1 = 0;
                okM_1 = 0;
                okLOSE = States.StatesWindow.getOKLOSE();
                gameVM.UserGame.CurrentCat = 4;
                if (okLOSE == 1)
                {
                    gameVM.UserGame.Statistics[1] += 1;
                    okS_1 = 0;
                }
                else
                {
                    okS_1 += 1;
                }
            }

            if(okA_1%5==0 && okA_1!=0)   
            {
                gameVM.UserGame.Statistics[2] += 1;
                MessageBox.Show("YOU WON THE GAME IN CATEGORY: ~All categories~", "You won!");

            }
            if (okC_1 % 5 == 0 && okC_1 != 0)
            {
                gameVM.UserGame.Statistics[3] += 1;
                MessageBox.Show("YOU WON THE GAME IN CATEGORY: ~Cars~", "You won!");
            }
            if (okM_1 % 5 == 0 && okM_1 != 0)
            {
                gameVM.UserGame.Statistics[4] += 1;
                MessageBox.Show("YOU WON THE GAME IN CATEGORY: ~Movies~", "You won!");
            }
            if (okS_1 % 5 == 0 && okS_1 != 0)
            {
                gameVM.UserGame.Statistics[5] += 1;
                MessageBox.Show("YOU WON THE GAME IN CATEGORY: ~States~", "You won!");
            }

            gameVM.serialzation(gameVM.UserGame.PlayerName, gameVM.UserGame);
        }

        internal void Statistic(object obj)
        {
            HangmanGame.HangmanWindow.dispatcherTimer.Stop();
            HangmanGame.HangmanWindow.GameFrame.IsEnabled = false;
            if (gameVM.UserGame.Statistics.Count > 0)
            {
                string ni = "User name : " + gameVM.UserGame.PlayerName + "\n" + "Games played : "+gameVM.UserGame.Statistics[0].ToString() + "\nLost games : " + gameVM.UserGame.Statistics[1].ToString() + "\nGames won in ALL CATEGORIES : " + gameVM.UserGame.Statistics[2].ToString()+ "\nGames won in the CARS category : " + gameVM.UserGame.Statistics[3] + "\nGames won in the MOVIES category : " + gameVM.UserGame.Statistics[4] + "\nGames won in the STATES category : " + gameVM.UserGame.Statistics[5];
                MessageBox.Show(ni, "Statistici");
            }
        }

        public void NewGame(object obj)
        {
            HangmanGame.HangmanWindow.dispatcherTimer.Stop();
            HangmanGame.HangmanWindow.GameFrame.IsEnabled = false;

           gameVM.UserGame.Statistics[0] += 1;
            okA_1 = 0;
            okC_1 = 0;
            okM_1 = 0;
            okS_1 = 0;
            if (HangmanGame.HangmanWindow.startGame==1)
            {
                gameVM.UserGame.Statistics[1] += 1;
            }

            gameVM.CurrentCategories = 1;
            gameVM.UserGame.CurrentCat = 1;
            HangmanGame.HangmanWindow.ChangeView(1);
            HangmanGame.HangmanWindow.all.IsEnabled = true;
            HangmanGame.HangmanWindow.car.IsEnabled = true;
            HangmanGame.HangmanWindow.movies.IsEnabled = true;
            HangmanGame.HangmanWindow.states.IsEnabled = true;
            HangmanGame.HangmanWindow.start.IsEnabled = true;
            HangmanGame.HangmanWindow.stop.IsEnabled = true;

            gameVM.serialzation(gameVM.UserGame.PlayerName, gameVM.UserGame);
        }

        public void Save(object obj)
        {
            HangmanGame.HangmanWindow.GameFrame.IsEnabled = false;
            gameVM.UserGame.CurrentCat = gameVM.CurrentCategories;
            string word="",tries="",target="";
            List<char> wrong_letter = new List<char>();

            if (gameVM.UserGame.CurrentCat == 1)
            {
                word = All_categories.All_categoriesWindow.getWORD();
                tries = All_categories.All_categoriesWindow.getTRIES().ToString();
                target = All_categories.All_categoriesWindow.target;
                wrong_letter = All_categories.All_categoriesWindow.wrong_letter;
            }
            if (gameVM.UserGame.CurrentCat == 2)
            {
                word = Cars.CarsWindow.getWORD();
                tries = Cars.CarsWindow.getTRIES().ToString();
                target = Cars.CarsWindow.target;
                wrong_letter = Cars.CarsWindow.wrong_letter;
            }
            if (gameVM.UserGame.CurrentCat == 3)
            {
                word = Movies.MoviesWindow.getWORD();
                tries = Movies.MoviesWindow.getTRIES().ToString();
                target = Movies.MoviesWindow.target;
                wrong_letter = Movies.MoviesWindow.wrong_letter;
            }
            if (gameVM.UserGame.CurrentCat == 4)
            {
                word = States.StatesWindow.getWORD();
                tries = States.StatesWindow.getTRIES().ToString();
                target = States.StatesWindow.target;
                wrong_letter = States.StatesWindow.wrong_letter;
            }

            gameVM.UserGame.SavedGame[0] = okA_1.ToString();
            gameVM.UserGame.SavedGame[1] = okC_1.ToString();
            gameVM.UserGame.SavedGame[2] = okM_1.ToString();
            gameVM.UserGame.SavedGame[3] = okS_1.ToString();

            gameVM.UserGame.TimeM = HangmanGame.HangmanWindow.getDel();
            gameVM.UserGame.TimeS = HangmanGame.HangmanWindow.getDelS();

            if (gameVM.UserGame.TimeS < 0)
            {
                MessageBox.Show("You cannot save the game to continue later \nbecause you have already lost it!\n Time is up!");
            }
            else
            {
                gameVM.TimeM = gameVM.UserGame.TimeM;
                gameVM.TimeS = gameVM.UserGame.TimeS;
                if (!word.Contains("*"))
                {
                    MessageBox.Show("You cannot save the game to continue later \nbecause you have already won it!");
                }
                else
                {
                    if (tries == "6")
                    {
                        MessageBox.Show("You cannot save the game to continue later \nbecause you have already lost it!");
                    }
                    else
                    {
                        gameVM.UserGame.SavedGame[5] = word;

                        gameVM.UserGame.SavedGame[6] = tries;
                        gameVM.UserGame.SavedGame[7] = target;
                        gameVM.UserGame.Press[0] = wrong_letter;
                    }
                }

            }

            gameVM.UserGame.SavedGame[4] = gameVM.UserGame.CurrentCat.ToString();
            

            gameVM.serialzation(gameVM.UserGame.PlayerName, gameVM.UserGame);
        }

        public void OpenSave(object obj)
        {
            if (gameVM.UserGame.SavedGame[7] == "")
            {
                MessageBox.Show("You didn't save any games!\nTo open a saved game you must save one!");
            }
            else
            {
                okA_1 = Int32.Parse(gameVM.UserGame.SavedGame[0]);
                okC_1 = Int32.Parse(gameVM.UserGame.SavedGame[1]);
                okM_1 = Int32.Parse(gameVM.UserGame.SavedGame[2]);
                okS_1 = Int32.Parse(gameVM.UserGame.SavedGame[3]);
                HangmanGame.HangmanWindow.delay = gameVM.UserGame.TimeM;
                HangmanGame.HangmanWindow.delaySec = gameVM.UserGame.TimeS + 1;
                HangmanGame.HangmanWindow.StartTimer();

                if (gameVM.UserGame.SavedGame[4] == "1")
                {
                    HangmanGame.HangmanWindow.GameFrame.Children.Clear();
                    HangmanGame.HangmanWindow.GameFrame.Children.Add(new All_categories(gameVM.UserGame.SavedGame[5], gameVM.UserGame.SavedGame[7], int.Parse(gameVM.UserGame.SavedGame[6]), gameVM.UserGame.Press[0]));

                    for (int i = 0; i < int.Parse(gameVM.UserGame.SavedGame[6]); i++)
                    {
                        if (i == 0)
                        {
                            All_categories.All_categoriesWindow.txt1.Text = "X";
                            All_categories.All_categoriesWindow.img.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(@"..\..\Images\2.png");
                        }
                        if (i == 1)
                        {
                            All_categories.All_categoriesWindow.txt2.Text = "X";
                            All_categories.All_categoriesWindow.img.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(@"..\..\Images\3.png");
                        }
                        if (i == 2)
                        {
                            All_categories.All_categoriesWindow.txt3.Text = "X";
                            All_categories.All_categoriesWindow.img.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(@"..\..\Images\4.png");
                        }
                        if (i == 3)
                        {
                            All_categories.All_categoriesWindow.txt4.Text = "X";
                            All_categories.All_categoriesWindow.img.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(@"..\..\Images\5.png");
                        }
                        if (i == 4)
                        {
                            All_categories.All_categoriesWindow.txt5.Text = "X";
                            All_categories.All_categoriesWindow.img.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(@"..\..\Images\6.png");
                        }
                        if (i == 5)
                        {
                            All_categories.All_categoriesWindow.txt6.Text = "X";
                            All_categories.All_categoriesWindow.img.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(@"..\..\Images\7.png");
                        }
                    }
                }
                else if (gameVM.UserGame.SavedGame[4] == "2")
                {
                    HangmanGame.HangmanWindow.GameFrame.Children.Clear();
                    HangmanGame.HangmanWindow.GameFrame.Children.Add(new Cars(gameVM.UserGame.SavedGame[5], gameVM.UserGame.SavedGame[7], int.Parse(gameVM.UserGame.SavedGame[6]), gameVM.UserGame.Press[0]));
                    for (int i = 0; i < int.Parse(gameVM.UserGame.SavedGame[6]); i++)
                    {
                        if (i == 0)
                        {
                            Cars.CarsWindow.txt1.Text = "X";
                            Cars.CarsWindow.img.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(@"..\..\Images\2.png");
                        }
                        if (i == 1)
                        {
                            Cars.CarsWindow.txt2.Text = "X";
                            Cars.CarsWindow.img.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(@"..\..\Images\3.png");
                        }
                        if (i == 2)
                        {
                            Cars.CarsWindow.txt3.Text = "X";
                            Cars.CarsWindow.img.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(@"..\..\Images\4.png");
                        }
                        if (i == 3)
                        {
                            Cars.CarsWindow.txt4.Text = "X";
                            Cars.CarsWindow.img.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(@"..\..\Images\5.png");
                        }
                        if (i == 4)
                        {
                            Cars.CarsWindow.txt5.Text = "X";
                            Cars.CarsWindow.img.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(@"..\..\Images\6.png");
                        }
                        if (i == 5)
                        {
                            Cars.CarsWindow.txt6.Text = "X";
                            Cars.CarsWindow.img.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(@"..\..\Images\7.png");
                        }
                    }

                }
                else if (gameVM.UserGame.SavedGame[4] == "3")
                {
                    HangmanGame.HangmanWindow.GameFrame.Children.Clear();
                    HangmanGame.HangmanWindow.GameFrame.Children.Add(new Movies(gameVM.UserGame.SavedGame[5], gameVM.UserGame.SavedGame[7], int.Parse(gameVM.UserGame.SavedGame[6]), gameVM.UserGame.Press[0]));
                    for (int i = 0; i < int.Parse(gameVM.UserGame.SavedGame[6]); i++)
                    {
                        if (i == 0)
                        {
                            Movies.MoviesWindow.txt1.Text = "X";
                            Movies.MoviesWindow.img.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(@"..\..\Images\2.png");
                        }
                        if (i == 1)
                        {
                            Movies.MoviesWindow.txt2.Text = "X";
                            Movies.MoviesWindow.img.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(@"..\..\Images\3.png");
                        }
                        if (i == 2)
                        {
                            Movies.MoviesWindow.txt3.Text = "X";
                            Movies.MoviesWindow.img.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(@"..\..\Images\4.png");
                        }
                        if (i == 3)
                        {
                            Movies.MoviesWindow.txt4.Text = "X";
                            Movies.MoviesWindow.img.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(@"..\..\Images\5.png");
                        }
                        if (i == 4)
                        {
                            Movies.MoviesWindow.txt5.Text = "X";
                            Movies.MoviesWindow.img.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(@"..\..\Images\6.png");
                        }
                        if (i == 5)
                        {
                            Movies.MoviesWindow.txt6.Text = "X";
                            Movies.MoviesWindow.img.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(@"..\..\Images\7.png");
                        }
                    }
                }
                else if (gameVM.UserGame.SavedGame[4] == "4")
                {
                    HangmanGame.HangmanWindow.GameFrame.Children.Clear();
                    HangmanGame.HangmanWindow.GameFrame.Children.Add(new States(gameVM.UserGame.SavedGame[5], gameVM.UserGame.SavedGame[7], int.Parse(gameVM.UserGame.SavedGame[6]), gameVM.UserGame.Press[0]));
                    for (int i = 0; i < int.Parse(gameVM.UserGame.SavedGame[6]); i++)
                    {
                        if (i == 0)
                        {
                            States.StatesWindow.txt1.Text = "X";
                            States.StatesWindow.img.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(@"..\..\Images\2.png");
                        }
                        if (i == 1)
                        {
                            States.StatesWindow.txt2.Text = "X";
                            States.StatesWindow.img.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(@"..\..\Images\3.png");
                        }
                        if (i == 2)
                        {
                            States.StatesWindow.txt3.Text = "X";
                            States.StatesWindow.img.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(@"..\..\Images\4.png");
                        }
                        if (i == 3)
                        {
                            States.StatesWindow.txt4.Text = "X";
                            States.StatesWindow.img.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(@"..\..\Images\5.png");
                        }
                        if (i == 4)
                        {
                            States.StatesWindow.txt5.Text = "X";
                            States.StatesWindow.img.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(@"..\..\Images\6.png");
                        }
                        if (i == 5)
                        {
                            States.StatesWindow.txt6.Text = "X";
                            States.StatesWindow.img.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(@"..\..\Images\7.png");
                        }
                    }
                }
            }
        }
    }
}
