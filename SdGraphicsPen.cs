using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
namespace SdGraphics
{
    public class SdGraphicsPen
    {
        #region  ---------------------------------------- Attributes
        private Pen myPen;

        public Pen Pen {
            get { return myPen; }
            set { myPen = value; }
        }
        private String name;

        public String Name {
            get { return name; }
            set { name = value; }
        }

        #endregion  ------------------------------------- Attributes

        #region  ---------------------------------------- Methods
        public SdGraphicsPen(String name, String hexColor,  int width, DashStyle dashStyle= DashStyle.Solid)
        {
            this.name = name;
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
        private String toHex(Color color)
        {
            String retVal = String.Format("#{0}{1}{2}", color.R.ToString("x2"),
                color.G.ToString("x2"), color.B.ToString("x2"));
            return retVal;
        }
        #endregion  ------------------------------------- Methods

    }
}
