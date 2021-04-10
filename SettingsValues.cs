using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SdGraphics
{
    public class SettingsValues
    {
        #region -------------------------------------------------- Private attributes

        private int blankSpace = 6;
        private bool breakLines= true;
        private string copyrightName= "Copyright Name";
        private int copyrightYear=2021;
        private int dancerSize=18;
        private int lineHeight=26;
        private int marginBottom=50;
        private int marginTop=15;
        private int maxLineLength=40;
        private int noseSize= 6;
        public struct BrushValuesStruct
        {
            public string Name;
            public string Color;
            public string FillType;
            public BrushValuesStruct( string name, string color, string fillType)
            {
                Color = color;
                Name = name;
                FillType = fillType;
            }
        }
        public struct SizeStruct
        {
            public int Height;
            public int Width;
            public SizeStruct(int width, int height)
            {
                Height = height;
                Width = width;
            }
        }
        public struct PenValuesStruct
        {
            public string Name;
            public string Color;
            public int Width;
            public string DashStyle;
            public PenValuesStruct(string name, string color, int width, string dashStyle)
            {
                Color = color;
                Name = name;
                Width = width;
                DashStyle = dashStyle;
            }
        }

        private Dictionary<String, BrushValuesStruct> brushValues = new Dictionary<String, BrushValuesStruct>();
        private Dictionary<String, PenValuesStruct> penValues = new Dictionary<String, PenValuesStruct>();
        private SizeStruct pageSize = new SizeStruct();

        #endregion ----------------------------------------------- Private attributes
        #region -------------------------------------------------- Properties

        public Dictionary<String, BrushValuesStruct> BrushValues {
            get { return brushValues; }
            set { brushValues = value; }
        }
        public Dictionary<String,PenValuesStruct> PenValues {
            get { return penValues; }
            set { penValues = value; }
        }
        public int BlankSpace {
            get { return blankSpace; }
            set { blankSpace = value; }
        }

        public bool BreakLines {
            get { return breakLines; }
            set { breakLines = value; }
        }
        public string CopyrightName {
            get { return copyrightName; }
            set { copyrightName = value; }
        }

        public int CopyrightYear {
            get { return copyrightYear; }
            set { copyrightYear = value; }
        }

        public int DancerSize {
            get { return dancerSize; }
            set { dancerSize = value; }
        }

        public int LineHeight {
            get { return lineHeight; }
            set { lineHeight = value; }
        }

        public int MarginBottom {
            get { return marginBottom; }
            set { marginBottom = value; }
        }

        public int MarginTop {
            get { return marginTop; }
            set { marginTop = value; }
        }

        public int MaxLineLength {
            get { return maxLineLength; }
            set { maxLineLength = value; }
        }

        public int NoseSize {
            get { return noseSize; }
            set { noseSize = value; }
        }
        public SizeStruct PageSize {
            get { return pageSize; }
            set { pageSize = value; }

        }
        #endregion ----------------------------------------------- Properties
        public SettingsValues()
        {
            penValues.Add("PhantomPen", new PenValuesStruct("PhantomPen", "#0000FF", 1, "Dash"));
            penValues.Add("CallerPen", new PenValuesStruct("CallerPen", "#00FF00", 1, "Solid"));
            penValues.Add("DancerPen", new PenValuesStruct("DancerPen", "#000000", 1, "Solid"));
            BrushValues.Add("CallTextBrush", new BrushValuesStruct("CallTextBrush", "#000000", "Solid"));
            BrushValues.Add("DancerTextBrush", new BrushValuesStruct("DancerTextBrush", "#000000", "Solid"));
            BrushValues.Add("DancerNoseBrush", new BrushValuesStruct("DancerNoseBrush", "#FF0000", "Solid"));
            BrushValues.Add("CallerNoseBrush", new BrushValuesStruct("CallerNoseBrush", "#FF0000", "Solid"));
            PageSize = new SizeStruct(778, 1100); //Size of the each page in pixels.Corresponds to 94 pixels / inch for an A4 page(210 mm × 297 mm)

        }
        //public SettingsValues(int blankSpace, bool breakLines, string copyrightName, int copyrightYear,
        // int dancerSize, int lineHeight, int marginBottom, int marginTop, int maxLineLength, int noseSize)
        //{
        //    BlankSpace = blankSpace;
        //    BreakLines = breakLines;
        //    CopyrightName = copyrightName;
        //    CopyrightYear = copyrightYear;
        //    DancerSize = dancerSize;
        //    LineHeight = lineHeight;
        //    MarginBottom = marginBottom;
        //    MarginTop = marginTop;
        //    MaxLineLength = maxLineLength;
        //    NoseSize = noseSize;
        //}

    }
}
