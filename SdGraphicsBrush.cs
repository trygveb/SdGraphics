using System;
using System.Drawing;
using System.Windows.Forms;

namespace SdGraphics
{
    /// <summary>
    /// Only Solid brushes are allowed
    /// </summary>
    public class SdGraphicsBrush: PenOrBrush
    {
        #region  ---------------------------------------- Attributes
        private SolidBrush myBrush;
        private string fillType;

        public string FillType {
            get { return fillType; }
            set { fillType = value; }
        }

        public SolidBrush Brush {
            get { return myBrush; }
            set { myBrush = value; }
        }
 

        #endregion  ------------------------------------- Attributes

        #region  ---------------------------------------- Methods
        public SdGraphicsBrush(String name, String hexColor, String fillType)
        {
            Name = name;
            Color color = ColorTranslator.FromHtml(hexColor);
            Brush = new SolidBrush(color);
            FillType = fillType;
            if (fillType !="Solid") {
                this.Brush = null;  // Only Solid brushes supported
            }
        }
        public String getHexColor()
        {
            return this.toHex(this.Brush.Color);
        }
        public void setColor(Color color)
        {
            this.Brush.Color = color;
        }
        public override string ToString()
        {
            String x = String.Format("{0};{1}",
                this.Name, this.toHex(this.Brush.Color));
            return x;
        }
        #endregion  ------------------------------------- Methods

    }
}
