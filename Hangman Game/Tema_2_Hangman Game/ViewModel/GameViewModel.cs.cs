using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Xml.Serialization;
using Tema_2_Hangman_Game.Command;
using Tema_2_Hangman_Game.Model;
using Tema_2_Hangman_Game.View;

namespace Tema_2_Hangman_Game.ViewModel
{
    class GameViewModel : INotifyPropertyChanged
    {
        private GameCommands gameOP;
        private Game userGame = new Game();

        private string playerName;
        private int currentCategories;
        private double timeM;
        private double timeS;
        private List<string> savedGame;
        private List<List<int>> currentGame;
        private List<int> statistici;
        private bool canExecuteCommand = true;

        public GameViewModel()
        {
            userGame = new Game();
            string name = "name";
            name = HangmanGame.HangmanWindow.name();
            if (File.Exists(@"..\..\Players\" + name + ".xml"))
            {
                XmlSerializer xmlser = new XmlSerializer(typeof(Game));
                FileStream file = new FileStream(@"..\..\Players\" + name + ".xml", FileMode.Open);
                var entity = xmlser.Deserialize(file);
                file.Dispose();
                userGame = entity as Game;
            }
            else
            {

                XmlSerializer xmlser = new XmlSerializer(typeof(Game));
                Game newuser = new Game(name);
                newuser.PlayerName = name;
                FileStream fileStr = new FileStream(@"..\..\Players\" + name + ".xml", FileMode.Create);
                xmlser.Serialize(fileStr, newuser);
                fileStr.Dispose();

            }
            gameOP = new GameCommands(this);

        }
        
        public void serialzation(string name, Game user)
        {
            XmlSerializer xmlser = new XmlSerializer(typeof(Game));
            FileStream fileStr = new FileStream(@"..\..\Players\" + user.PlayerName + ".xml", FileMode.Create);
            xmlser.Serialize(fileStr, user);
            fileStr.Dispose();
        }

        public Game UserGame
        {
            get
            {
                return userGame;
            }
            set
            {
                userGame = value;
                OnPropertyChanged("userGame");
            }
        }

        public bool CanExecuteCommand
        {
            get
            {
                return canExecuteCommand;
            }

            set
            {
                if (canExecuteCommand == value)
                {
                    return;
                }
                canExecuteCommand = value;
            }
        }

        public double TimeM
        {
            get
            {
                return timeM;
            }
            set
            {
                timeM = value;
                OnPropertyChanged("timeM");
            }
        }

        public double TimeS
        {
            get
            {
                return timeS;
            }
            set
            {
                timeS = value;
                OnPropertyChanged("timeS");
            }
        }

        public string PlayerName
        {
            get
            {
                return playerName;
            }
            set
            {
                playerName = value;
                OnPropertyChanged("Name");
            }
        }

        public int CurrentCategories
        {
            get
            {
                return currentCategories;
            }
            set
            {
                currentCategories = value;
                OnPropertyChanged("Categories");
            }
        }

        public List<int> Statistici
        {
            get
            {
                return statistici;
            }
            set
            {
                statistici = value;
                OnPropertyChanged("Statistici");
            }
        }

        public List<string> SavedGame
        {
            get
            {
                return savedGame;
            }
            set
            {
                savedGame = value;
                OnPropertyChanged("SavedGame");
            }
        }

        public List<List<int>> CurrentGame
        {
            get
            {
                return currentGame;
            }
            set
            {
                currentGame = value;
                OnPropertyChanged("CurrentGame");
            }
        }

        
        private ICommand categoriesCommand;
        public ICommand CategoriesCommand
        {
            get
            {
                if (categoriesCommand == null)
                {
                    categoriesCommand = new Commands(gameOP.Categories, param => CanExecuteCommand);
                }
                return categoriesCommand;
            }
        }

        private ICommand checkCommand;
        public ICommand CheckCommand
        {
            get
            {
                if (checkCommand == null)
                {
                    checkCommand = new Commands(gameOP.Check, param => CanExecuteCommand);
                }
                return checkCommand;
            }
        }

        private ICommand statisticiCommand;
        public ICommand StatisticiCommand
        {
            get
            {
                if (statisticiCommand == null)
                {
                    statisticiCommand = new Commands(gameOP.Statistic, param => CanExecuteCommand);
                }
                return statisticiCommand;
            }
        }

        private ICommand newGameCommand;
        public ICommand NewGameCommand
        {
            get
            {
                if (newGameCommand == null)
                {
                    newGameCommand = new Commands(gameOP.NewGame, param => CanExecuteCommand);
                }
                return newGameCommand;
            }
        }

        private ICommand saveCommand;
        public ICommand SaveCommand
        {
            get
            {
                if (saveCommand == null)
                {
                    saveCommand = new Commands(gameOP.Save, param => CanExecuteCommand);
                }
                return saveCommand;
            }
        }

        private ICommand openSaveCommand;
        public ICommand OpenSaveCommand
        {
            get
            {
                if (openSaveCommand == null)
                {
                    openSaveCommand = new Commands(gameOP.OpenSave, param => CanExecuteCommand);
                }
                return openSaveCommand;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
