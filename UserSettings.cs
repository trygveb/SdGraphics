using System.Configuration;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
//using Newtonsoft.Json;

using System.Text.Json;
using System.Text.Json.Serialization;


namespace SdGraphics
{
    public class UserSettings : ApplicationSettingsBase
    {
        #region -------------------------------------------------- Settings
        [UserScopedSetting()]
        // Each Pen or Brush is defined by a semicolon separated string
        // Each pen is defined by:   P; Name; hex color; width; dashStyle
        // Each brush is defined by: B; Name; hex color; fillstyle
        // Currently only brushes with fillStyle Solid is supported
        [DefaultSettingValue(
            "P;PhantomPen;#0000FF;1;Dash&" +
            "P;CallerPen;#00FF00;1;Solid&" +
            "P;DancerPen;#000000;1;Solid&" +
            "B;CallTextBrush;#000000;Solid&" +
            "B;DancerTextBrush;#000000;Solid&" +
            "B;DancerNoseBrush;#FF0000;Solid&" +
            "B;CallerNoseBrush;#FF0000;Solid&"
            )]
        public String PensAndBrushes {
            get { return ((String)this["PensAndBrushes"]); }
            set { this["PensAndBrushes"] = (String)value; }
        }

        [UserScopedSetting()]
        [DefaultSettingValue("6;18;26;50;15;40;6;2021;t;Caller")]
        //BlankSpace;DancerSize;LineHeight;MarginBottom;Margintop;MaxLineLenght;NoseSize
        public string Scalars {
            get { return ((string)this["Scalars"]); }
            set { this["Scalars"] = (string)value; }
        }
        #endregion ----------------------------------------------- Settings


        #region -------------------------------------------------- Private attributes

        private int blankSpace;
        private bool breakLines;
        private string copyrightName;
        private int copyrightYear;
        private int dancerSize;
        private int lineHeight;
        private int marginBottom;
        private int margintop;
        private int maxLineLength;
        private List<SdGraphicsBrush> mySdGraphicBrushes = new List<SdGraphicsBrush>();
        private List<SdGraphicsPen> mySdGraphicPens = new List<SdGraphicsPen>();
        private int noseSize;
        #endregion ----------------------------------------------- Private attributes


        #region -------------------------------------------------- Properties

        public int BlankSpace {
            get { return blankSpace; }
            set { blankSpace = value; }
        }

        public bool BreakLines {
            get { return breakLines; }
            set { breakLines = value; }
        }

        public Brush BrushForCallerNose {
            get { return SdGraphicBrushes.Where(f => f.Name.Equals("CallerNoseBrush")).FirstOrDefault().Brush; }
        }

        public Brush BrushForCallText {
            get { return SdGraphicBrushes.Where(f => f.Name.Equals("CallTextBrush")).FirstOrDefault().Brush; }
        }

        public Brush BrushForDancerNoses {
            get { return SdGraphicBrushes.Where(f => f.Name.Equals("DancerNoseBrush")).FirstOrDefault().Brush; }
        }

        public Brush BrushForDancerText {
            get { return SdGraphicBrushes.Where(f => f.Name.Equals("DancerTextBrush")).FirstOrDefault().Brush; }
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
            get { return margintop; }
            set { margintop = value; }
        }

        public int MaxLineLength {
            get { return maxLineLength; }
            set { maxLineLength = value; }
        }

        public int NoseSize {
            get { return noseSize; }
            set { noseSize = value; }
        }

        public Pen penForCaller {
            get { return SdGraphicPens.Where(f => f.Name.Equals("CallerPen")).FirstOrDefault().Pen; }
        }

        public Pen penForDancer {
            get { return SdGraphicPens.Where(f => f.Name.Equals("DancerPen")).FirstOrDefault().Pen; }
        }

        public Pen penForPhantom {
            get { return SdGraphicPens.Where(f => f.Name.Equals("PhantomPen")).FirstOrDefault().Pen; }
        }

        public List<SdGraphicsBrush> SdGraphicBrushes {
            get { return mySdGraphicBrushes; }
            set { mySdGraphicBrushes = value; }
        }

        public List<SdGraphicsPen> SdGraphicPens {
            get { return mySdGraphicPens; }
            set { mySdGraphicPens = value; }
        }
        #endregion ----------------------------------------------- Properties

        #region -------------------------------------------------- Methods

        public new void Reload()
        {
#if DEBUG
            // use only when settings are added or deleted, or defualt values changed
            //base.Reset();  
#endif
            base.Reload();
            char[] sep1 = new char[] { ';' };
            string[] scalarsSplit = Scalars.Split(sep1);

            BlankSpace = System.Int32.Parse(scalarsSplit[0]);
            DancerSize = System.Int32.Parse(scalarsSplit[1]);
            LineHeight = System.Int32.Parse(scalarsSplit[2]);
            MarginBottom = System.Int32.Parse(scalarsSplit[3]);
            MarginTop = System.Int32.Parse(scalarsSplit[4]);
            MaxLineLength = System.Int32.Parse(scalarsSplit[5]);
            NoseSize = System.Int32.Parse(scalarsSplit[6]);
            CopyrightYear = System.Int32.Parse(scalarsSplit[7]);
            BreakLines = scalarsSplit[8] == "t";
            CopyrightName = scalarsSplit[9];
            mySdGraphicPens.Clear();

            char[] sep2 = new char[] { '&' };
            string[] pensSplit2 = PensAndBrushes.Split(sep2);

            foreach (string penSpec in pensSplit2) {
                if (penSpec != null && penSpec.Length > 0) {
                    string[] penAttributes = penSpec.Split(sep1);
                    if (penAttributes.Length > 1) {
                        string type = penAttributes[0];
                        if (type.Equals("P")) {
                            addPen(penAttributes.Skip(1).ToArray());  //Remove type
                        } else if (type.Equals("B")) {
                            addBrush(penAttributes.Skip(1).ToArray());  //Remove type
                        }
                    }
                }
            }
            //string json = JsonConvert.SerializeObject(this);  (Newtonsoft, gives error)
            //string json = JsonSerializer.Serialize(this, typeof(MyUserSettings)); (Gives error)
            // string json = JsonSerializer.Serialize(mySdGraphicPens, typeof(List<SdGraphicsPen>)); (Gives error)
        }

        public new void Save()
        {
            Scalars = string.Format("{0};{1};{2};{3};{4};{5};{6};{7};{8};{9}",
                BlankSpace, DancerSize, LineHeight, MarginBottom, MarginTop, MaxLineLength, NoseSize,
                CopyrightYear, BreakLines, CopyrightName);
            PensAndBrushes = "";
            foreach (SdGraphicsPen sdGraphicPen in mySdGraphicPens) {
                //"P;PhantomPen;#0000FF;1;dotted&" +
                string pen = String.Format("P;{0};{1};{2};{3}&",
                    sdGraphicPen.Name, sdGraphicPen.getHexColor(), sdGraphicPen.Pen.Width, sdGraphicPen.Pen.DashStyle.ToString());
                PensAndBrushes += pen;
            }
            foreach (SdGraphicsBrush sdGraphicBrush in mySdGraphicBrushes) {
                string pen = String.Format("B;{0};{1};{2}&",
                    sdGraphicBrush.Name, sdGraphicBrush.getHexColor(), sdGraphicBrush.FillType);
                PensAndBrushes += pen;
            }
            base.Save();
        }

        private void addBrush(string[] brushAttributes)
        {
            mySdGraphicBrushes.Add(new SdGraphicsBrush(
                brushAttributes[0], // name
                brushAttributes[1],  // hex color
                brushAttributes[2]  // fillType, only solid allowed
                ));
        }

        private void addPen(string[] penAttributes)
        {
            mySdGraphicPens.Add(new SdGraphicsPen(
                penAttributes[0], // name
                penAttributes[1],  // hex color
                System.Int32.Parse(penAttributes[2]), //width
                penAttributes[3] == "solid" ? DashStyle.Solid : DashStyle.Dash));
        }
        #endregion ----------------------------------------------- Methods

    }
}