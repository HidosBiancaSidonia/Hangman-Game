using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Tema_2_Hangman_Game.Model;
using Tema_2_Hangman_Game.View;
using Tema_2_Hangman_Game.ViewModel;

namespace Tema_2_Hangman_Game.LogIn
{
    class Operation
    {
        private UserViewModel userVM;

        public Operation(UserViewModel user)
        {
            this.userVM = user;
        }

        public void New(object param)
        {
            String s = param as String;
            NewUser newUser = new NewUser();
            newUser.ShowDialog();
            userVM.Users = new ObservableCollection<User>();
            string[] lines = File.ReadAllLines(@"..\..\..\players.txt");
            foreach (var it in lines)
            {
                if (it != "")
                {
                    string[] words = it.Split(',');
                    userVM.Users.Add(new User() { Name = words[0], Icon = words[1] });
                }
            }

        }

        public void Save(object param)
        {
            UserViewModel s = param as UserViewModel;
            User user = new User() { Name = userVM.NameN, Icon = userVM.ImgPathN };

            if (userVM.NameN != null && userVM.ImgPathN != null)
            {
                userVM.Users.Add(user);

                using (StreamWriter outputFile = new StreamWriter(Path.Combine(@"..\..\players.txt", @"..\..\players.txt"), true))
                {
                    outputFile.WriteLine(user.Name + "," + user.Icon);
                }

               
            }
            else
                System.Windows.Forms.MessageBox.Show("Name or photo are missing!","Warning!",MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public void Img(object param)
        {
            String s = param as String;
            userVM.ImgPathN = s;
            System.Windows.MessageBox.Show("The image has been selected!");
        }

        public void Play(object param)
        {
            String s = param as String;
            String source="";
            foreach (var it in userVM.Users)
                if (it.Name == s)
                {
                    source = it.Icon;
                }
            if (s != null)
            {
                HangmanGame user = new HangmanGame(s, source);
                user.ShowDialog();
            }
            else
                System.Windows.Forms.MessageBox.Show("No player was selected!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        public void Delete(object param)
        {
            String s = param as String;

            if (s != null)
            {
                for (int i = 0; i < userVM.Users.Count; ++i)
                    if (userVM.Users.ElementAt(i).Name == s)
                        userVM.Users.RemoveAt(i);

                if (File.Exists(@"..\..\..\players.txt"))
                    File.Delete(@"..\..\..\players.txt");
                if (File.Exists(@"..\..\Players\" + s + ".xml"))
                    File.Delete(@"..\..\Players\" + s + ".xml");

                using (StreamWriter outputFile = new StreamWriter(Path.Combine(@"..\..\players.txt", @"..\..\players.txt"), true))
                {
                    foreach (var it in userVM.Users)
                        outputFile.WriteLine(it.Name + "," + it.Icon);
                }
            }
            else
                System.Windows.Forms.MessageBox.Show("In order to delete a player,\n please select the player you\n want to delete from the game!","Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
           
        }
    }
}
