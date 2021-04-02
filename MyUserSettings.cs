using System.Configuration;

public class MyUserSettings : ApplicationSettingsBase
{
    private bool breakLines;

    private int blankSpace;
    private int copyrightYear;
    private int dancerSize;
    private int lineHeight;
    private int marginBottom;
    private int margintop;
    private int maxLineLength;
    private int noseSize;

    private string copyrightName;



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

    [UserScopedSetting()]
    [DefaultSettingValue("6;18;26;50;15;40;6;2021;t;Caller")]
    //BlankSpace;DancerSize;LineHeight;MarginBottom;Margintop;MaxLineLenght;NoseSize
    public string Scalars
    {
        get { return ((string)this["Scalars"]); }
        set { this["Scalars"] = (string)value; }
    }
  

 
    public new void Reload()
    {
//      base.Reset();
        base.Reload();
        char[] sep = new char[] { ';' };
        string[] scalarsSplit = Scalars.Split(sep);
        BlankSpace = System.Int32.Parse(scalarsSplit[0]);
        DancerSize = System.Int32.Parse(scalarsSplit[1]);
        LineHeight = System.Int32.Parse(scalarsSplit[2]);
        MarginBottom = System.Int32.Parse(scalarsSplit[3]);
        MarginTop = System.Int32.Parse(scalarsSplit[4]);
        MaxLineLength = System.Int32.Parse(scalarsSplit[5]);
        NoseSize = System.Int32.Parse(scalarsSplit[6]);
        CopyrightYear= System.Int32.Parse(scalarsSplit[7]);
        BreakLines = scalarsSplit[8] == "t";
        CopyrightName = scalarsSplit[9];

    }

    public new void Save()
    {
        Scalars = string.Format("{0};{1};{2};{3};{4};{5};{6};{7};{8};{9}",
            BlankSpace, DancerSize, LineHeight, MarginBottom, MarginTop, MaxLineLength, NoseSize,
            CopyrightYear, BreakLines, CopyrightName);
        base.Save();
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