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
        private PreferencesValues.FocusDancerStruct focusDancer;

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
