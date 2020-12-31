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

using T0_FontViewer.Utility;

namespace T0_FontViewer.ViewModels
{
    /// <summary>
    /// The MainWindowViewModel handles a simple DataTemplate based navigation
    /// </summary>
    public class MainWindowViewModel : ViewModelBase
    {
        #region Members

        private object selectedViewModel;

        #endregion

        #region ctor

        public MainWindowViewModel()
        {
            this.SelectedViewModel = new FontViewViewModel();
        }

        #endregion

        #region Properties

        public object SelectedViewModel
        {
            get { return selectedViewModel; }
            set
            {
                selectedViewModel = value;
                OnPropertyChanged(nameof(SelectedViewModel));
            }
        }

        #endregion
    }
}
