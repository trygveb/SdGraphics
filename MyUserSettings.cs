using System;
using System.Configuration;
using System.Drawing;

public class MyUserSettings : ApplicationSettingsBase
{
    [UserScopedSetting()]
    [DefaultSettingValue("26")]
    public int LineHeight
    {
        get
        {
            return ((int)this["LineHeight"]);
        }
        set
        {
            this["LineHeight"] = (int)value;
        }
    }
}