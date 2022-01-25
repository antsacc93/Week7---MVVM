using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Week7.WPF.BindingDemo
{
    public class RelayCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;
        //Puntatore ad un metodo che esegue il comando richiesto
        private Action<object?> executeMethod;
        //Puntatore ad un metodo che restituisce true/false a seconda che venga rispettata 
        //una determinata condizione
        //Equivalente a Func<object, bool> canExecuteMethod;
        private Predicate<object?> canExecuteMethod;

        public RelayCommand(Action<object?> Execute, Predicate<object?> CanExecute)
        {
            executeMethod = Execute;
            canExecuteMethod = CanExecute;
        }

        public bool CanExecute(object? parameter)
        {
            if(canExecuteMethod == null)
            {
                return true; //se non è stato istanziato il metodo canExecuteMethod
                //questo comando sarà sempre abilitato
            }
            return canExecuteMethod.Invoke(parameter);

            //return (canExecuteMethod == null) ? true : canExecuteMethod.Invoke(parameter);
        }

        public void Execute(object? parameter)
        {
            //Vado a richiamre il metodo puntato come da eseguire
            executeMethod?.Invoke(parameter);
            //if(executeMethod != null)
            //{
            //    executeMethod.Invoke(parameter);
            //}
        }

        internal void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
