using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Windows.Input;
using Tema_2_Hangman_Game.Command;
using Tema_2_Hangman_Game.LogIn;
using Tema_2_Hangman_Game.Model;

namespace Tema_2_Hangman_Game.ViewModel
{
    class UserViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<User> users { get; set; }
        private Operation operation;

        public UserViewModel()
        {
            Users = new ObservableCollection<User>();
            string[] lines = File.ReadAllLines(@"..\..\..\players.txt");
            foreach (var it in lines)
            {
                if (it != "")
                {
                    string[] words = it.Split(',');
                    Users.Add(new User() { Name = words[0], Icon = words[1] });
                }
            }
            operation = new Operation(this);
        }

        public ObservableCollection<User> Users
        {
            get
            {
                return users;
            }
            set
            {
                users = value;
                OnPropertyChanged("User");
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

        private bool canExecuteCommand = true;
        public bool CanExecuteCommand
        {
            get
            {
                return canExecuteCommand;
            }
            set
            {
                if (canExecuteCommand == value)
                    return;
                canExecuteCommand = value;
            }
        }

        private ICommand newUser;
        public ICommand NewUser
        {
            get
            {
                if (newUser == null)
                    newUser = new Commands(operation.New, param => CanExecuteCommand);
                return newUser;
            }
        }

        private ICommand saveCommand;
        public ICommand SaveCommand
        {
            get
            {
                if (saveCommand == null)
                    saveCommand = new Commands(operation.Save, param => CanExecuteCommand);
                
                return saveCommand;
            }
        }

        private string nameN;
        public string NameN
        {
            get { return nameN; }
            set
            {
                nameN = value;
                canExecuteCommand = Validator.CanExecuteOperation(NameN);
            }
        }

        private string imgPathN;
        public string ImgPathN
        {
            get { return imgPathN; }
            set
            {
                imgPathN = value;
            }
        }

        private ICommand imageCommand;
        public ICommand ImageCommand
        {
            get
            {
                if (imageCommand == null)
                    imageCommand = new Commands(operation.Img, param => CanExecuteCommand);
                return imageCommand;
            }
        }

        private ICommand playCommand;
        public ICommand PlayCommand
        {
            get
            {
                if (playCommand == null)
                    playCommand = new Commands(operation.Play, param => CanExecuteCommand);
                return playCommand;
            }
        }

        private ICommand deleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                if (deleteCommand == null)
                    deleteCommand = new Commands(operation.Delete, param => CanExecuteCommand);
                return deleteCommand;
            }
        }
    }
}


