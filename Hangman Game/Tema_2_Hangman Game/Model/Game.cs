using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Tema_2_Hangman_Game.Model
{
    public class Game : INotifyPropertyChanged
    {
        private string playerName;
        private int currentCat;
        private List<int> statistics;
        private double timeM, timeS;
        private List<string> savedGame;
        private List<List<char>> press;

        public Game()
        {
            playerName = "Name";
            currentCat = 1;
            statistics = new List<int>();
            savedGame = new List<string>();
            press = new List<List<char>>();

            timeM = 0;
            timeS = 30;
        }

        private List<List<char>> SetZero()
        {
            List<List<char>> list = new List<List<char>>();

            for (int i = 0; i < 1; i++)
            {
                List<char> z = new List<char>();
                for (int j = 0; j < 1; j++)
                    z.Add('a');
                list.Add(z);
            }

            return list;
        }

        public Game(string name)
        {
            statistics = new List<int>();
            savedGame = new List<string>();
            press = new List<List<char>>();
            playerName = name;
            currentCat = 1;
            timeM = 0;
            timeS = 30;

            for (int i = 0; i < 6; i++)
                statistics.Insert(i,0);
            for (int i = 0; i < 8; i++)
                savedGame.Insert(i, "");
            press = SetZero();
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

        public int CurrentCat
        {
            get
            {
                return currentCat;
            }
            set
            {
                currentCat = value;
                OnPropertyChanged("Categories");
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
                OnPropertyChanged("TimeM");
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
                OnPropertyChanged("TimeS");
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

        public List<List<char>> Press
        {
            get
            {
                return press;
            }
            set
            {
                press = value;
                OnPropertyChanged("SavedGame");
            }
        }

        public List<int> Statistics
        {
            get
            {
                return statistics;
            }
            set
            {
                statistics = value;
                OnPropertyChanged("Statistics");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
