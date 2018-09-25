<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index-v2.aspx.cs" Inherits="index_v2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>落网-Local</title>
    <link href="/css/index-v2.css" rel="stylesheet" />
    <script src="/js/jquery-1.10.2.js"></script>
    <script src="/js/index-v2.js"></script>

    <style type="text/css">
        .mark { color: #FF5A15; }
        .blue { color: blue; }
        .green { color: green; }
        .red { color: red; }
        .cGray, a.cGray:link, a.cGray:visited { color: #6D6359; }
        .cOrange2, a.cOrange2:link, a.cOrange2:visited { color: #ce0400; }
        .cOrange3, a.cOrange3:link, a.cOrange3:visited { color: #ce0400; text-decoration: underline; }
        a.cOrange3:hover { color: #6D6359; }
        .f12, h5 { font-size: 12px; font-weight: normal; }
        .cGreen2, a.cGreen2:link, a.cGreen2:visited { color: #336600; }
        .en { font-family: Verdana, Arial, Helvetica, sans-serif,"宋体"; }

        div#code { background: #ffffff; }
        fieldset { border: 1px #cccccc solid; padding: 10px; margin-bottom: 10px; display: block; font-family: Verdana, Arial, Helvetica, sans-serif; line-height: 28px; text-align: left; background: #ffffff; }
        fieldset dl dt { line-height: 28px; font-weight: bold; display: inline; }
        fieldset dl dd { line-height: 28px; display: inline; }
    </style>

</head>
<body>
    <div id="myAudio">
        <audio>
            <% for (int i = 0; i < Songs.Count; i++)
                { %>
            <source title="<%=string.Format("{0} - {1}",Songs[i].SongName.Substring(Songs[i].SongName.IndexOf('.')+1), Songs[i].VolName) %>" src="<%=Songs[i].DownloadUrl %>" />
            <% } %>
        </audio>
        <div class="music_info clearfix">
            <div class="cd_holder"><span class="stick"></span>
                <div class="cd"></div>
            </div>
            <div class="meta_data">
                <span class="title"></span>
                <div class="rating">
                    <div class="starbar">
                        <ul class="current-rating" data-score="85">
                            <li class="star5"></li>
                            <li class="star4"></li>
                            <li class="star3"></li>
                            <li class="star2"></li>
                            <li class="star1"></li>
                        </ul>
                    </div>
                </div>
                <div class="volume_control">
                    <a class="icon-volume-decrease"></a>
                    <span class="base_bar">
                        <span class="progress_bar"></span>
                        <a class="slider"></a>
                    </span>
                    <a class="icon-volume-increase" style="margin-left: 10px;"></a>
                </div>
            </div>
            <div style="width: 400px; float: left;">
                <%if (Keywords != null)
                    {
                        foreach (var keyword in Keywords)
                        {
                %>
                <input type="checkbox" name="keyword" id="keyword_<%=keyword %>" /><label for="keyword_<%=keyword %>"><%=keyword %></label>
                <%
                    } %>
                <%} %>
            </div>

        </div>
        <ul class="music_list"></ul>
        <div class="controls">
            <table>
                <tr>
                    <td style="width: 120px;">
                        <div class="play_controls">
                            <a class="icon-previous"></a>
                            <a class="icon-play" id="btn_play"></a>
                            <a class="icon-next"></a>
                        </div>
                    </td>
                    <td style="width: 30px;" align="right">
                        <span class="passed_time" id="passed_time">0:00</span>
                    </td>
                    <td>
                        <div class="time_line">
                            <span class="base_bar" id="play_progress_bar">
                                <span class="progress_bar"></span>
                            </span>
                        </div>
                    </td>
                    <td style="width: 30px;">
                        <span class="total_time" id="total_time">0:00</span>
                    </td>
                    <td class="play_type">
                        <a class="icon-loop" id="btn_play_type"></a>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <script type="text/javascript">
        $(function () {
            $("#myAudio").initAudio();

            $(".music_list").css("max-height", (document.documentElement.clientHeight - 185) + "px");
            //$("#myAudio .time_line").css("width", (document.documentElement.clientWidth - 200) + "px");
            //$("#play_progress_bar").css("width", (document.documentElement.clientWidth - 290) + "px");
            $(".music_list li:eq(0)").click();
        });
    </script>

</body>
</html>
