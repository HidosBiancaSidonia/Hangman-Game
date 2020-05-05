using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Tema_2_Hangman_Game.Command
{
    class Commands : ICommand
    {
        private Action<object> commandTask;
        private Predicate<object> canExecuteTask;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public Commands(Action<object> workToDo) : this(workToDo, DefaultCanExecute)
        {
            commandTask = workToDo;
        }

        public Commands(Action<object> workToDo, Predicate<object> canExecute)
        {
            commandTask = workToDo;
            canExecuteTask = canExecute;
        }

        private static bool DefaultCanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            commandTask(parameter);
        }
    }
}
