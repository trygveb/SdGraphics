using System.Configuration;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using Newtonsoft.Json;


namespace SdGraphics
{
    public class UserSettings : ApplicationSettingsBase
    {
        #region -------------------------------------------------- Settings
 
        [UserScopedSetting()]
        [DefaultSettingValue("")]

        public string JsonUserSettings {
            get { return ((string)this["JsonUserSettings"]); }
            set { this["JsonUserSettings"] = (string)value; }
        }

        #endregion ----------------------------------------------- Settings


        #region -------------------------------------------------- Private attributes
        private SettingsValues settingsValues;
        
        private Dictionary<string, SdGraphicsBrush> mySdGraphicBrushes = new Dictionary<string, SdGraphicsBrush>();
        private Dictionary<string, SdGraphicsPen> mySdGraphicPens = new Dictionary<string,SdGraphicsPen>();
        //private int noseSize;
        #endregion ----------------------------------------------- Private attributes


        #region -------------------------------------------------- Properties

        public int BlankSpace {
            get { return SettingsValues.BlankSpace; }
            set { SettingsValues.BlankSpace = value; }
        }

        public bool BreakLines {
            get { return SettingsValues.BreakLines; }
            set { SettingsValues.BreakLines = value; }
        }

        public Brush BrushForCallerNose {
           get { return SdGraphicBrushes.Where(f => f.Key.Equals("CallerNoseBrush")).FirstOrDefault().Value.Brush; }
          // get {return new SdGraphicBrush() }
        }

        public Brush BrushForCallText {
            get { return SdGraphicBrushes.Where(f => f.Key.Equals("CallTextBrush")).FirstOrDefault().Value.Brush; }
        }

        public Brush BrushForDancerNoses {
            get { return SdGraphicBrushes.Where(f => f.Key.Equals("DancerNoseBrush")).FirstOrDefault().Value.Brush; }
        }

        public Brush BrushForDancerText {
            get { return SdGraphicBrushes.Where(f => f.Key.Equals("DancerTextBrush")).FirstOrDefault().Value.Brush; }
        }

        public string CopyrightName {
            get { return SettingsValues.CopyrightName; }
            set { SettingsValues.CopyrightName = value; }
        }

        public int CopyrightYear {
            get { return SettingsValues.CopyrightYear; }
            set { SettingsValues.CopyrightYear = value; }
        }

        public int DancerSize {
            get { return SettingsValues.DancerSize; }
            set { SettingsValues.DancerSize = value; }
        }

 
        public int LineHeight {
            get { return SettingsValues.LineHeight; }
            set { SettingsValues.LineHeight = value; }
        }

        public int MarginBottom {
            get { return SettingsValues.MarginBottom; }
            set { SettingsValues.MarginBottom = value; }
        }

        public int MarginTop {
            get { return SettingsValues.MarginTop; }
            set { SettingsValues.MarginTop = value; }
        }

        public int MaxLineLength {
            get { return SettingsValues.MaxLineLength; }
            set { SettingsValues.MaxLineLength = value; }
        }

        public int NoseSize {
            get { return SettingsValues.NoseSize; }
            set { SettingsValues.NoseSize = value; }
        }

        public bool PageHeaders {
            get { return SettingsValues.PageHeaders; }
            set { SettingsValues.PageHeaders = value; }
        }

        public SettingsValues.SizeStruct PageSize {
            get { return SettingsValues.PageSize; }
            set { SettingsValues.PageSize = value; }
        }

        public Pen penForBorder {

            get { return SdGraphicPens.Where(f => f.Key.Equals("BorderPen")).FirstOrDefault().Value.Pen; }
        }
        public Pen penForCaller {

            get { return SdGraphicPens.Where(f => f.Key.Equals("CallerPen")).FirstOrDefault().Value.Pen; }
        }

        public Pen penForDancer {
            get { return SdGraphicPens.Where(f => f.Key.Equals("DancerPen")).FirstOrDefault().Value.Pen; }
        }

        public Pen penForPhantom {
            get { return SdGraphicPens.Where(f => f.Key.Equals("PhantomPen")).FirstOrDefault().Value.Pen; }
        }

        public Dictionary<string, SdGraphicsBrush> SdGraphicBrushes {
            get { return mySdGraphicBrushes; }
            set { mySdGraphicBrushes = value; }
        }

        public Dictionary<string,SdGraphicsPen> SdGraphicPens {
            get { return mySdGraphicPens; }
            set { mySdGraphicPens = value; }
        }
        public SettingsValues SettingsValues {
            get { return settingsValues; }
            set { settingsValues = value; }

        }
        #endregion ----------------------------------------------- Properties

        #region -------------------------------------------------- Methods

        public new void Reload()
        {
            base.Reload();
            if (JsonUserSettings == null || JsonUserSettings.Equals("null") || JsonUserSettings.Equals("")) {
                //base.Reset();
                SettingsValues = new SettingsValues();
                JsonUserSettings = JsonConvert.SerializeObject(SettingsValues);
            } else {
                SettingsValues = JsonConvert.DeserializeObject<SettingsValues>(JsonUserSettings);
            }
            mySdGraphicPens.Clear();
            mySdGraphicBrushes.Clear();

            foreach (KeyValuePair<string, SettingsValues.PenValuesStruct> kvp in SettingsValues.PenValues) {
                bool isSolid= String.Equals(kvp.Value.DashStyle, "solid", StringComparison.OrdinalIgnoreCase);
                mySdGraphicPens.Add(kvp.Key, new SdGraphicsPen(kvp.Key, kvp.Value.Color, kvp.Value.Width,
                     isSolid ? DashStyle.Solid : DashStyle.Dash));
            }
            foreach (KeyValuePair<string, SettingsValues.BrushValuesStruct> kvp in SettingsValues.BrushValues) {
                mySdGraphicBrushes.Add(kvp.Key, new SdGraphicsBrush(kvp.Key, kvp.Value.Color, kvp.Value.FillType));
            }

        }



        public void MyReset()
        {
            base.Reset();
        }
        public new void Save()
        {
            SettingsValues.PenValues.Clear();
            foreach (KeyValuePair<string, SdGraphicsPen> kvp in mySdGraphicPens) {
                SettingsValues.PenValues.Add(kvp.Key, new SettingsValues.PenValuesStruct(
                    kvp.Key, kvp.Value.getHexColor(), (int) kvp.Value.Pen.Width, kvp.Value.Pen.DashStyle.ToString()));
            }
            SettingsValues.BrushValues.Clear();
            foreach (KeyValuePair<string, SdGraphicsBrush> kvp in mySdGraphicBrushes) {
                SettingsValues.BrushValues.Add(kvp.Key, new SettingsValues.BrushValuesStruct(
                    kvp.Key, kvp.Value.getHexColor(), kvp.Value.FillType));
            }

            JsonUserSettings = JsonConvert.SerializeObject(SettingsValues);
            base.Save();
        }

          #endregion ----------------------------------------------- Methods

    }
}