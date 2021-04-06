using System;
using System.Drawing;
using System.Drawing.Drawing2D;
namespace SdGraphics
{
    public class SdGraphicsPen: PenOrBrush
    {
        #region  ---------------------------------------- Properties
        private Pen myPen;

        public Pen Pen {
            get { return myPen; }
            set { myPen = value; }
        }


        #endregion  ------------------------------------- Properties

        #region  ---------------------------------------- Methods
        public SdGraphicsPen(String name, String hexColor,  int width, DashStyle dashStyle= DashStyle.Solid)
        {
            Name = name;
            Color color= ColorTranslator.FromHtml(hexColor);
            this.Pen = new Pen(color, width);
            this.Pen.DashStyle = dashStyle;
        }
        public String getHexColor()
        {
            return this.toHex(this.Pen.Color);
        }
        public void setColor(Color color)
        {
            this.Pen.Color = color;
        }
        public override string ToString()
        {
            String x = String.Format("{0};{1};{2};{3}",
                this.Name, this.toHex(this.Pen.Color), this.Pen.Width, this.Pen.DashStyle.ToString());
            return x;
        }

        #endregion  ------------------------------------- Methods

    }
}
