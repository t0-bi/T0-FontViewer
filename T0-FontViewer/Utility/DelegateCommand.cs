/*
    This file is part of T0-FontViewer.

    T0-FontViewer is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    T0-FontViewer is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with T0-FontViewer.  If not, see <https://www.gnu.org/licenses/>.
*/

using System;
using System.Windows.Input;

namespace T0_FontViewer.Utility
{
    /// <summary>
    /// The DelegateCommand is a simple implementation of the ICommand interface
    /// </summary>
    public class DelegateCommand : ICommand
    {
        #region Member

        private readonly Predicate<object> _canExecute;
        private readonly Action<object> _execute;

        #endregion

        #region public

        public event EventHandler CanExecuteChanged;

        #endregion

        #region ctor

        public DelegateCommand(Action<object> execute) : this(execute, null)
        {
        }

        public DelegateCommand(Action<object> execute, Predicate<object> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        #endregion

        #region Methods

        public bool CanExecute(object parameter)
        {
            if (_canExecute == null)
            {
                return true;
            }

            return _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        #endregion
    }
}
