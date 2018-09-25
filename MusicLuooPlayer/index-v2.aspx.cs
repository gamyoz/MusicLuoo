using System;
using System.Collections.Generic;
using MusicLuooUnity;
using MusicLuooUnity.BLL;

public partial class index_v2 : System.Web.UI.Page
{
    protected List<LuooVolSongModel> Songs;
    protected List<string> Keywords;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int count;
            if (!int.TryParse(Request["c"], out count))
                count = 1000;
            //Keywords = LuooVolHelper.GetVolKeywords();
            Songs = LuooSongHelper.GetListPager(1, count, "金属");
        }
    }
}