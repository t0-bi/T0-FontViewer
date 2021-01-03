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
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using T0_FontViewer.Models;

namespace T0_FontViewer.ViewModels
{
    /// <summary>
    /// The FontViewViewModel handles the data for the available SystemFonts
    /// </summary>
    public class FontViewViewModel : ViewModelBase
    {
        #region Members

        private FontFamily selectedFont;

        private ICollection<FontFamily> systemFonts;

        private ObservableCollection<char> fontCharacters;

        private ObservableCollection<FontFace> fontFaces;

        private FontFace selectedFontFace;


        #endregion

        #region ctor

        public FontViewViewModel()
        {
            this.SelectIconCommand = new DelegateCommand(SelectIcon);
            this.FontCharacters = new ObservableCollection<char>();
            this.FontFaces = new ObservableCollection<FontFace>();
            this.SystemFonts = Fonts.SystemFontFamilies;
        }

        #endregion

        #region Properties

        public ICommand SelectIconCommand { get; set; }

        public FontFamily SelectedFont
        {
            get { return selectedFont; }
            set
            {
                selectedFont = value;
                OnSelectedFontChanged(selectedFont);
                OnPropertyChanged(nameof(SelectedFont));
            }
        }

        public ICollection<FontFamily> SystemFonts
        {
            get { return systemFonts; }
            set
            {
                systemFonts = value;
                OnPropertyChanged(nameof(SystemFonts));
            }
        }

        public ObservableCollection<char> FontCharacters
        {
            get { return fontCharacters; }
            set
            {
                fontCharacters = value;
                OnPropertyChanged(nameof(FontCharacters));
            }
        }

        public ObservableCollection<FontFace> FontFaces
        {
            get { return fontFaces; }
            set
            {
                fontFaces = value;
                OnPropertyChanged(nameof(FontFaces));
            }
        }

        public FontFace SelectedFontFace
        {
            get { return selectedFontFace; }
            set
            {
                selectedFontFace = value;
                OnPropertyChanged(nameof(SelectedFontFace));
            }
        }

        #endregion

        #region Methods

        private void OnSelectedFontChanged(FontFamily selectedFont)
        {
            this.FontCharacters.Clear();
            this.FontFaces.Clear();

            var typefaces = selectedFont.GetTypefaces();

            foreach (Typeface typeface in typefaces)
            {
                var glyphs = new List<char>();
                typeface.TryGetGlyphTypeface(out GlyphTypeface glyph);
                if (glyph == null)
                {
                    return;
                }

                IDictionary<int, ushort> characterMap = glyph.CharacterToGlyphMap;

                foreach (KeyValuePair<int, ushort> kvp in characterMap)
                {
                    this.FontCharacters.Add((char)kvp.Key);
                    glyphs.Add((char)kvp.Key);

                }

                this.FontFaces.Add(new FontFace(selectedFont, typeface.Style, typeface.Weight, glyphs));
            }


            this.SelectedFontFace = this.FontFaces[0];
        }

        private void SelectIcon(object obj)
        {
            if(obj is char character)
            {
                Clipboard.SetData(DataFormats.UnicodeText, character);
            }
        }

        #endregion
    }
}