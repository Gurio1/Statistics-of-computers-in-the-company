using System;
using System.Windows.Input;

namespace WPF_46731r.Commands
{
    public abstract class CommandBase : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public virtual bool CanExecute(object? parameter) => true;

        public abstract void Execute(object? parameter);

        protected void OnCanExecuteChanget()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }
    }
}
