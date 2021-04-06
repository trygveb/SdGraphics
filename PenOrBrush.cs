using System;
using System.Drawing;

namespace SdGraphics
{
    public class PenOrBrush
    {
        private String name;

        public String Name {
            get { return name; }
            set { name = value; }
        }
        protected String toHex(Color color)
        {
            String retVal = String.Format("#{0}{1}{2}", color.R.ToString("x2"),
                color.G.ToString("x2"), color.B.ToString("x2"));
            return retVal;
        }

    }
}
