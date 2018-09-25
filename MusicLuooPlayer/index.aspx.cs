using System;
using System.Collections.Generic;
using MusicLuooUnity;
using MusicLuooUnity.BLL;

public partial class index : System.Web.UI.Page
{
    protected List<LuooVolSongModel> Songs;
    protected int Count;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Count = LuooSongHelper.GetAllCount();
            Songs = LuooSongHelper.GetListPager(1, 100,"");
        }
    }


}