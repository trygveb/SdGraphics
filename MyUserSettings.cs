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

 
 }