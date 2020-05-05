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
using Tema_2_Hangman_Game.LogIn;

namespace Tema_2_Hangman_Game.View
{
    /// <summary>
    /// Interaction logic for LogInView.xaml
    /// </summary>
    public partial class LogInView : Window
    {
        public LogInView()
        {
            InitializeComponent();
        }

        private void ExitBttn(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit the program?", "", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            NewUser window = new NewUser();
            Close();
            
        }
    }
}
