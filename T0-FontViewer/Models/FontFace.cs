using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace T0_FontViewer.Models
{
    /// <summary>
    /// The FontFace is a model to wrap the data for the selected font, type and weight into one object
    /// </summary>
    public class FontFace
    {
        private FontFamily fontFamily;
        private FontStyle fontStyle;
        private FontWeight fontWeight;
        private List<char> glyphs;

        public FontFace(FontFamily fontFamily, FontStyle fontStyle, FontWeight fontWeight, List<char> glyphs)
        {
            FontFamily = fontFamily;
            FontStyle = fontStyle;
            FontWeight = fontWeight;
            Glyphs = glyphs;
        }

        public FontFamily FontFamily { get => fontFamily; set => fontFamily = value; }
        public FontStyle FontStyle { get => fontStyle; set => fontStyle = value; }
        public FontWeight FontWeight { get => fontWeight; set => fontWeight = value; }
        public List<char> Glyphs { get => glyphs; set => glyphs = value; }

        public override string ToString()
        {
            return FontWeight.ToString() + ", " + FontStyle.ToString();
        }
    }
}
