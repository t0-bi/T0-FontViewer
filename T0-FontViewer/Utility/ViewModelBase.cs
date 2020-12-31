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

using System.ComponentModel;

namespace T0_FontViewer.Utility
{
    /// <summary>
    /// The ViewModelBase is a helper to reduce redundant code when the INotifyPropertyChanged is needed in a ViewModel
    /// </summary>
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
