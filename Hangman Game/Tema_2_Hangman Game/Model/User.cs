using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema_2_Hangman_Game.Model
{

    class User : INotifyPropertyChanged
    {
        private string name;
        private string iconPath;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }
        public string Icon
        {
            get
            {
                return @iconPath;
            }
            set
            {
                iconPath = value;
                OnPropertyChanged("Icon");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
