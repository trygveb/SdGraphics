using System.Configuration;
using Newtonsoft.Json;
//using System;
//using System.Collections.Generic;
//using System.Drawing;
//using System.Drawing.Drawing2D;
//using System.Linq;
//using Newtonsoft.Json;


namespace SdGraphics
{
    public class Preferences : ApplicationSettingsBase
    {
        #region -------------------------------------------------- Settings

        [UserScopedSetting()]
        [DefaultSettingValue("")]
        public string JsonPreferences {
            get { return ((string)this["JsonPreferences"]); }
            set { this["JsonPreferences"] = (string)value; }
        }
        #endregion ----------------------------------------------- Settings

        #region -------------------------------------------------- Private attributes

        private PreferencesValues preferencesValues;

        #endregion ----------------------------------------------- Private attributes

        #region -------------------------------------------------- Properties

        public PreferencesValues PreferencesValues {
            get { return preferencesValues; }
            set { preferencesValues = value; }

        }

        public PreferencesValues.FocusDancerStruct FocusDancer {
            get { return preferencesValues.FocusDancer; }
            set { preferencesValues.FocusDancer = value; }
        }
        public PreferencesValues.ViewEnum SdView {
            get { return preferencesValues.SdView; }
            set { preferencesValues.SdView = value; }
        }
        public bool CreateZipFile {
            get { return preferencesValues.CreateZipFile; }
            set { preferencesValues.CreateZipFile = value; }
        }
        public bool DrawBorder {
            get { return preferencesValues.DrawBorder; }
            set { preferencesValues.DrawBorder = value; }
        }
        public string InitialDirectory {
            get { return preferencesValues.InitialDirectory; }
            set { preferencesValues.InitialDirectory = value; }
        }

        public bool ShowPartner {
            get { return preferencesValues.ShowPartner; }
            set { preferencesValues.ShowPartner = value; }
        }
        
        #endregion ----------------------------------------------- Properties
        public new void Reload()
        {
            base.Reload();
            if (JsonPreferences== null || JsonPreferences.Equals("null") || JsonPreferences.Equals("")) {
                //base.Reset();
                PreferencesValues = new PreferencesValues();
                JsonPreferences = JsonConvert.SerializeObject(PreferencesValues);
            } else {
                PreferencesValues = JsonConvert.DeserializeObject<PreferencesValues>(JsonPreferences);
            }

        }

        public void MyReset()
        {
            base.Reset();
        }
        public new void Save()
        {

            JsonPreferences = JsonConvert.SerializeObject(PreferencesValues);
            base.Save();
        }


    }
}
