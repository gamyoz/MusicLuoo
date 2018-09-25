using System;
using System.Collections.Generic;
using MusicLuooUnity;

public partial class index : System.Web.UI.Page
{
    protected List<LuooVolSongModel> Songs;
    protected int Count;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Count = MusicLuooUnity.LuooSongHelper.GetAllCount();
            Songs = MusicLuooUnity.LuooSongHelper.GetListPager(1, 100,"");
        }
    }


}