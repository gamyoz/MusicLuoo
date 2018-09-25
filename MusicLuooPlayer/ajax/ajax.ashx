<%@ WebHandler Language="C#" Class="ajax" %>

using System;
using System.Collections.Generic;
using System.Web;
using MusicLuooUnity;
using Newtonsoft.Json;

public class ajax : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {

        ResponseModel<dynamic> resp = new ResponseModel<dynamic>();
        try
        {
            context.Response.ContentType = "text/plain";

            string action = context.Request["action"];
            switch (action)
            {
                case "Init":
                    resp.code = 1;
                    resp.data = Init(int.Parse(context.Request["pageindex"]), int.Parse(context.Request["pagesize"]));
                    break;
                default:
                    resp.code = -1;
                    resp.message = "没有找到方法";
                    break;
            }
        }
        catch (Exception)
        {
            resp.code = -1;
            resp.message = "系统错误";
        }
        context.Response.Write(JsonConvert.SerializeObject(resp));
    }

    private List<LuooVolSongModel> Init(int pageIndex, int pageSize)
    {
        var songs = MusicLuooUnity.LuooSongHelper.GetListPager(pageIndex, pageSize, "");
        return songs;
    }

    private class ResponseModel<T>
    {
        public int code { get; set; }
        public string message { get; set; }
        public T data { get; set; }
    }
    public bool IsReusable {
        get {
            return false;
        }
    }

}