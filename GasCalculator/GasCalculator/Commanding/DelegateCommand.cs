using System;
using System.Windows.Input;

namespace GasCalculator.Commanding
{
    /// <summary>
    /// Klasa implementująca interfejs ICommand
    /// </summary>
    public class DelegateCommand : ICommand
    {
        private readonly Predicate<object> _canExecute;
        private readonly Action<object> _execute;

        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Konstruktor klasy
        /// </summary>
        /// <param name="execute">Delegat metody Execute</param>
        public DelegateCommand(Action<object> execute) : this(execute, null) { }

        /// <summary>
        /// Konstruktor klasy
        /// </summary>
        /// <param name="execute">Delegat metody Execute</param>
        /// <param name="canExecute">Delegat metody CanExecute</param>
        public DelegateCommand(Action<object> execute, Predicate<object> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        /// <summary>
        /// Metoda sprawdzająca czy polecenie można wykonać
        /// </summary>
        /// <param name="parameter">Parametr</param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            if (_canExecute == null)
            {
                return true;
            }

            return _canExecute(parameter);
        }

        /// <summary>
        /// Metoda wykonująca polecenie
        /// </summary>
        /// <param name="parameter">Parametr</param>
        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        /// <summary>
        /// Metoda informująca, że zmieniła się wartość zwracan przez CanExecute
        /// </summary>
        public void RaiseCanExecuteChanged()
        {
            if (CanExecuteChanged != null)
            {
                CanExecuteChanged(this, EventArgs.Empty);
            }
        }
    }
}
