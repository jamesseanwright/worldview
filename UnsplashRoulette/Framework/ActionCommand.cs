using System;
using System.Windows.Input;

namespace UnsplashRoulette.Framework
{
    public class ActionCommand : ICommand
    {
        readonly Action action;
        
        public ActionCommand(Action action)
        {
            this.action = action;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            this.action();
        }
    }
}
