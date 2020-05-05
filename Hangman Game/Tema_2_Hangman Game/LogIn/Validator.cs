using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema_2_Hangman_Game.LogIn
{
    class Validator
    {
        public static bool CanExecuteOperation(string item)
        {
            if (item == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
