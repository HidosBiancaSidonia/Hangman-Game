using System;
using System.Collections.Generic;
using System.IO;
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

namespace Tema_2_Hangman_Game.View
{
    /// <summary>
    /// Interaction logic for Movies.xaml
    /// </summary>
    public partial class Movies : UserControl
    {
        public static Movies MoviesWindow;
        int okM = 1;
        int okLOSE = 0;
        string file;
        int i = 0;
        public string target;
        public string word = "";
        public List<char> wrong_letter = new List<char>();
        int tries = 0;

        public Movies()
        {
            HangmanGame.HangmanWindow.startGame = 0;
            HangmanGame.HangmanWindow.delay = 0;
            HangmanGame.HangmanWindow.delaySec = 30;
            InitializeComponent();
            MoviesWindow = this;
            RandomWord();
            img.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(@"..\..\Images\1.png");
        }

        public Movies(string str, string targ, int tries1, List<char> wrong)
        {
            InitializeComponent();
            MoviesWindow = this;
            word = str;
            target = targ;
            tries = tries1;
            wrong_letter = wrong;
            label.Content = word;
            key_lock(wrong_letter);
        }

        private void RandomWord()
        {
            file = "..\\..\\movies.txt";

            string[] allLines = File.ReadAllLines(file);
            Random rnd1 = new Random();
            target = allLines[rnd1.Next(allLines.Length)];

            for (i = 0; i < target.Length; i++)
            {
                word += "*";
            }
            label.Content = word;
        }

        private void Guess(char letter)
        {
            bool hit = false;
            for (i = 0; i < target.Length; i++)
            {
                if (target[i] == letter)
                {

                    hit = true;
                    word = word.Remove(i, 1);
                    word = word.Insert(i, letter.ToString());
                }
            }
            label.Content = word;


            if (!hit)
            {
                tries++;
                switch (tries)
                {
                    case 1:
                        txt1.Text = "X";
                        img.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(@"..\..\Images\2.png");

                        break;
                    case 2:
                        txt2.Text = "X";
                        img.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(@"..\..\Images\3.png");

                        break;
                    case 3:
                        txt3.Text = "X";
                        img.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(@"..\..\Images\4.png");

                        break;
                    case 4:
                        txt4.Text = "X";
                        img.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(@"..\..\Images\5.png");

                        break;
                    case 5:
                        txt5.Text = "X";
                        img.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(@"..\..\Images\6.png");

                        break;
                    case 6:
                        txt6.Text = "X";
                        img.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(@"..\..\Images\7.png");
                        this.IsEnabled = false;
                        HangmanGame.HangmanWindow.dispatcherTimer.Stop();
                        status.Content = "You lost the game!";
                        okLOSE = 1;
                        HangmanGame.HangmanWindow.menu.IsEnabled = false;
                        HangmanGame.HangmanWindow.GameFrame.IsEnabled = false;
                        HangmanGame.HangmanWindow.grid.Visibility = Visibility.Visible;
                        HangmanGame.HangmanWindow.lbl.Content = "You lost the game!\nClick OK to access the game menu!";
                        break;
                }

            }
            if (!word.Contains("*"))
            {
                this.IsEnabled = false;
                HangmanGame.HangmanWindow.dispatcherTimer.Stop();
                status.Content = "You won the level!";
                HangmanGame.HangmanWindow.grid.Visibility = Visibility.Visible;
                HangmanGame.HangmanWindow.menu.IsEnabled = false;
                HangmanGame.HangmanWindow.GameFrame.IsEnabled = false;
                HangmanGame.HangmanWindow.lbl.Content = "To win the game you must win 5 levels of the ~ MOVIES ~ category !\nClick OK to access the game menu!";

                okM = 1;
            }
        }

        void key_lock(List<char> word)
        {
            for (int i = 0; i < word.Count; i++)
            {
                if (word[i] == 'A') { A.IsEnabled = false; }
                else if (word[i] == 'B') { B.IsEnabled = false; }
                else if (word[i] == 'C') { C.IsEnabled = false; }
                else if (word[i] == 'D') { D.IsEnabled = false; }
                else if (word[i] == 'E') { E.IsEnabled = false; }
                else if (word[i] == 'F') { F.IsEnabled = false; }
                else if (word[i] == 'G') { G.IsEnabled = false; }
                else if (word[i] == 'H') { H.IsEnabled = false; }
                else if (word[i] == 'I') { I.IsEnabled = false; }
                else if (word[i] == 'J') { J.IsEnabled = false; }
                else if (word[i] == 'K') { K.IsEnabled = false; }
                else if (word[i] == 'L') { L.IsEnabled = false; }
                else if (word[i] == 'M') { M.IsEnabled = false; }
                else if (word[i] == 'N') { N.IsEnabled = false; }
                else if (word[i] == 'O') { O.IsEnabled = false; }
                else if (word[i] == 'P') { P.IsEnabled = false; }
                else if (word[i] == 'Q') { Q.IsEnabled = false; }
                else if (word[i] == 'R') { R.IsEnabled = false; }
                else if (word[i] == 'S') { S.IsEnabled = false; }
                else if (word[i] == 'T') { T.IsEnabled = false; }
                else if (word[i] == 'U') { U.IsEnabled = false; }
                else if (word[i] == 'V') { V.IsEnabled = false; }
                else if (word[i] == 'W') { W.IsEnabled = false; }
                else if (word[i] == 'X') { X.IsEnabled = false; }
                else if (word[i] == 'Y') { Y.IsEnabled = false; }
                else if (word[i] == 'Z') { Z.IsEnabled = false; }
            }
        }

        int nrA = 0;
        private void A_Click(object sender, EventArgs e)
        {
            char c = 'A';
            Guess(c);
            nrA++;
            if (nrA > 0)
                A.IsEnabled = false;
        }

        int nrB = 0;
        private void B_Click(object sender, RoutedEventArgs e)
        {
            char c = 'B';
            Guess(c);
            nrB++;
            if (nrB > 0)
                B.IsEnabled = false;
        }

        int nrC = 0;
        private void C_Click(object sender, RoutedEventArgs e)
        {
            char c = 'C';
            Guess(c);
            nrC++;
            if (nrC > 0)
                C.IsEnabled = false;
        }

        int nrD = 0;
        private void D_Click(object sender, RoutedEventArgs e)
        {
            char c = 'D';
            Guess(c);
            nrD++;
            if (nrD > 0)
                D.IsEnabled = false;
        }

        int nrE = 0;
        private void E_Click(object sender, RoutedEventArgs e)
        {
            char c = 'E';
            Guess(c);
            nrE++;
            if (nrE > 0)
                E.IsEnabled = false;
        }

        int nrF = 0;
        private void F_Click(object sender, RoutedEventArgs e)
        {
            char c = 'F';
            Guess(c);
            nrF++;
            if (nrF > 0)
                F.IsEnabled = false;
        }

        int nrG = 0;
        private void G_Click(object sender, RoutedEventArgs e)
        {
            char c = 'G';
            Guess(c);
            nrG++;
            if (nrG > 0)
                G.IsEnabled = false;
        }

        int nrH = 0;
        private void H_Click(object sender, RoutedEventArgs e)
        {
            char c = 'H';
            Guess(c);
            nrH++;
            if (nrH > 0)
                H.IsEnabled = false;
        }

        int nrI = 0;
        private void I_Click(object sender, RoutedEventArgs e)
        {
            char c = 'I';
            Guess(c);
            nrI++;
            if (nrI > 0)
                I.IsEnabled = false;
        }

        int nrJ = 0;
        private void J_Click(object sender, RoutedEventArgs e)
        {
            char c = 'J';
            Guess(c);
            nrJ++;
            if (nrJ > 0)
                J.IsEnabled = false;
        }

        int nrK = 0;
        private void K_Click(object sender, RoutedEventArgs e)
        {
            char c = 'K';
            Guess(c);
            nrK++;
            if (nrK > 0)
                K.IsEnabled = false;
        }

        int nrL = 0;
        private void L_Click(object sender, RoutedEventArgs e)
        {
            char c = 'L';
            Guess(c);
            nrL++;
            if (nrL > 0)
                L.IsEnabled = false;
        }

        int nrM = 0;
        private void M_Click(object sender, RoutedEventArgs e)
        {
            char c = 'M';
            Guess(c);
            nrM++;
            if (nrM > 0)
                M.IsEnabled = false;
        }

        int nrN = 0;
        private void N_Click(object sender, RoutedEventArgs e)
        {
            char c = 'N';
            Guess(c);
            nrN++;
            if (nrN > 0)
                N.IsEnabled = false;
        }

        int nrO = 0;
        private void O_Click(object sender, RoutedEventArgs e)
        {
            char c = 'O';
            Guess(c);
            nrO++;
            if (nrO > 0)
                O.IsEnabled = false;
        }

        int nrP = 0;
        private void P_Click(object sender, RoutedEventArgs e)
        {
            char c = 'P';
            Guess(c);
            nrP++;
            if (nrP > 0)
                P.IsEnabled = false;
        }

        int nrQ = 0;
        private void Q_Click(object sender, RoutedEventArgs e)
        {
            char c = 'Q';
            Guess(c);
            nrQ++;
            if (nrQ > 0)
                Q.IsEnabled = false;
        }

        int nrR = 0;
        private void R_Click(object sender, RoutedEventArgs e)
        {
            char c = 'R';
            Guess(c);
            nrR++;
            if (nrR > 0)
                R.IsEnabled = false;
        }

        int nrS = 0;
        private void S_Click(object sender, RoutedEventArgs e)
        {
            char c = 'S';
            Guess(c);
            nrS++;
            if (nrS > 0)
                S.IsEnabled = false;
        }

        int nrT = 0;
        private void T_Click(object sender, RoutedEventArgs e)
        {
            char c = 'T';
            Guess(c);
            nrT++;
            if (nrT > 0)
                T.IsEnabled = false;
        }

        int nrU = 0;
        private void U_Click(object sender, RoutedEventArgs e)
        {
            char c = 'U';
            Guess(c);
            nrU++;
            if (nrU > 0)
                U.IsEnabled = false;
        }

        int nrV = 0;
        private void V_Click(object sender, RoutedEventArgs e)
        {
            char c = 'V';
            Guess(c);
            nrV++;
            if (nrV > 0)
                V.IsEnabled = false;
        }

        int nrW = 0;
        private void W_Click(object sender, RoutedEventArgs e)
        {
            char c = 'W';
            Guess(c);
            nrW++;
            if (nrW > 0)
                W.IsEnabled = false;
        }

        int nrX = 0;
        private void X_Click(object sender, RoutedEventArgs e)
        {
            char c = 'X';
            Guess(c);
            nrX++;
            if (nrX > 0)
                X.IsEnabled = false;
        }

        int nrY = 0;
        private void Y_Click(object sender, RoutedEventArgs e)
        {
            char c = 'Y';
            Guess(c);
            nrY++;
            if (nrY > 0)
                Y.IsEnabled = false;
        }

        int nrZ = 0;
        private void Z_Click(object sender, RoutedEventArgs e)
        {
            char c = 'Z';
            Guess(c);
            nrZ++;
            if (nrZ > 0)
                Z.IsEnabled = false;
        }

        public int getOKM()
        {
            return okM;
        }

        public void setOKM(int val = 0)
        {
            okM = val;
        }

        public int getOKLOSE()
        {
            return okLOSE;
        }

        public void setOKLOSE(int val)
        {
            okLOSE = val;
        }

        public string getWORD()
        {
            return word;
        }

        public int getTRIES()
        {
            return tries;
        }
    }
}
