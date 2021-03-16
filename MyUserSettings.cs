using System.Configuration;

public class MyUserSettings : ApplicationSettingsBase
{
    [UserScopedSetting()]
    [DefaultSettingValue("6")]
    public int BlankSpace
    {
        get { return ((int)this["BlankSpace"]); }
        set { this["BlankSpace"] = (int)value; }
    }

    [UserScopedSetting()]
    [DefaultSettingValue("18")]
    public int DancerSize
    {
        get { return ((int)this["DancerSize"]); }
        set { this["DancerSize"] = (int)value; }
    }

    [UserScopedSetting()]
    [DefaultSettingValue("26")]
    public int LineHeight
    {
        get { return ((int)this["LineHeight"]); }
        set { this["LineHeight"] = (int)value; }
    }
    [UserScopedSetting()]
    [DefaultSettingValue("50")]
    public int MarginBottom
    {
        get { return ((int)this["MarginBottom"]); }
        set { this["MarginBottom"] = (int)value; }
    }

    [UserScopedSetting()]
    [DefaultSettingValue("40")]
    public int MaxLineLenght
    {
        get { return ((int)this["MaxLineLenght"]); }
        set { this["MaxLineLenght"] = (int)value; }
    }

    [UserScopedSetting()]
    [DefaultSettingValue("6")]
    public int NoseSize
    {
        get { return ((int)this["NoseSize"]); }
        set { this["NoseSize"] = (int)value; }
    }

    [UserScopedSetting()]
    [DefaultSettingValue("15")]
    public int Margintop
    {
        get { return ((int)this["Margintop"]); }
        set { this["Margintop"] = (int)value; }
    }

    [UserScopedSetting()]
    [DefaultSettingValue("true")]
    public bool Breaklines
    {
        get { return ((bool)this["Breaklines"]); }
        set { this["Breaklines"] = (bool)value; }
    }

    [UserScopedSetting()]
    [DefaultSettingValue("2021")]
    public int Copyrightyear
    {
        get { return ((int)this["Copyrightyear"]); }
        set { this["Copyrightyear"] = (int)value; }
    }

    [UserScopedSetting()]
    [DefaultSettingValue("NN")]
    public string Copyrightname
    {
        get { return ((string)this["Copyrightname"]); }
        set { this["Copyrightname"] = (string)value; }
    }


    [UserScopedSetting()]
    [DefaultSettingValue("#0000FF;1;dotted")]
    public string PhantomPen {
        get { return ((string)this["PhantomPen"]); }
        set { this["PhantomPen"] = (string)value; }
    }

    [UserScopedSetting()]
    [DefaultSettingValue("#00FF00;1;solid")]
    public string CallerPen {
        get { return ((string)this["CallerPen"]); }
        set { this["CallerPen"] = (string)value; }
    }

    [UserScopedSetting()]
    [DefaultSettingValue("#000000;1;solid")]
    public string DancerPen {
        get { return ((string)this["DancerPen"]); }
        set { this["DancerPen"] = (string)value; }
    }

    [UserScopedSetting()]
    [DefaultSettingValue("#FF0000;1;solid")]
    public string DancerNosePen {
        get { return ((string)this["DancerNosePen"]); }
        set { this["DancerNosePen"] = (string)value; }
    }

    [UserScopedSetting()]
    [DefaultSettingValue("#FF0000;1;solid")]
    public string CalleNosePen {
        get { return ((string)this["CalleNosePen"]); }
        set { this["CalleNosePen"] = (string)value; }
    }
    /*
     *   CalleNosePen
     */
}