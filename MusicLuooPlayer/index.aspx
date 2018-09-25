<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>

    <link rel="stylesheet" type="text/css" href="/css/jquery.mCustomScrollbar.css" />
    <link rel="stylesheet" type="text/css" href="/css/xiami.css" />
    <style type="text/css">
        #tableList table { width: 100%; }
        #tableList th { border-bottom: 1px solid #ccc; height: 55px; text-align: left; color: #999; font-weight: normal; }
        #tableList td { border-bottom: 1px solid #EBEBEB; height: 42px; color: #999; font-size: 14px; letter-spacing: 0.5px; }
        #tableList tr:hover { background: #EBEBEB; }
        /*#tableList td em{ font-style: normal; font-family: Arial; color: #aaa; }*/
    </style>
</head>
<body>
    <!--模糊画布-->
    <div class="blur">
        <canvas style="width: 1366px; height: 700px; opacity: 0;" width="1366" height="700" id="canvas"></canvas>
    </div>
    <div class="top">
        <!--<a href="#" class="logo"></a>-->
        <div class="search">
            <div type="submit" class="searchBtn"></div>
            <input type="text" class="searchTxt" />
        </div>
        <%--   <div class="mainNav">
                        <label style="color: #fff;">2018-03-05 21:55:40</label>
                    </div>--%>
    </div>
    <div class="middle">
        <table style="width: 100%">
            <tr>
                <td style="width: 250px"></td>
                <td>
                    <div id="tableList">
                        <table cellpadding="0" cellspacing="0" id="tblist">
                            <thead>
                                <tr>
                                    <th style="width: 16px"></th>
                                    <th style="width: 30px"></th>
                                    <th style="width: 230px">歌曲(1000)</th>
                                    <th style="width: 230px">演唱者</th>
                                    <th style="width: 230px">专辑</th>
                                </tr>
                            </thead>
                            <tbody>
                                <% for (int i = 0; i < Songs.Count; i++)
                                    {%>
                                <tr class="songList" index="<%=Songs[i].SongIndex %>">
                                    <td style="text-align: center">
                                        <input class="checkIn" type="checkbox" select="0" /></td>
                                    <td style="text-align: center">
                                        <div class="start">
                                            <em sonn="<%=Songs[i].DownloadUrl %>" sonindex="<%=Songs[i].SongIndex %>" volpic="<%=Songs[i].VolPicUrl.Split('!')[0] %>"><%=Songs[i].SongIndex %></em>
                                        </div>
                                    </td>
                                    <td>
                                        <span id="songName<%=Songs[i].SongIndex %>"><%=Songs[i].SongName %></span>
                                    </td>
                                    <td>
                                        <span id="songAuthor<%=Songs[i].SongIndex %>"><%=Songs[i].Author %></span>
                                    </td>
                                    <td>
                                        <%=Songs[i].AlbumName %>
                                    </td>
                                </tr>
                                <% } %>
                            </tbody>
                        </table>
                    </div>
                </td>
                <td style="width: 250px; vertical-align: top">
                    <div>
                        <img src="<%=Songs[0].VolPicUrl.Split('!')[0] %>" id="canvas1" style="width: 180px; height: 180px">
                    </div>
                    <div id="lyr"></div>
                </td>
            </tr>
        </table>
    </div>
    <div class="bottom">
        <div class="playerWrap">
            <div class="playerCon">
                <a href="#" class="pbtn prevBtn"></a>
                <a href="#" class="pbtn playBtn" isplay="0"></a>
                <a href="#" class="pbtn nextBtn"></a>
                <a href="#" class="mode mode-loop"></a>
            </div>
            <div class="playInfo">
                <div class="trackInfo">
                    <a href="#" class="songName"><%=Songs[0].SongName %></a>
                    -
                        <a href="#" class="songPlayer"><%=Songs[0].Author %></a>
                    <div class="trackCon">
                        <a href="#" class="tc1"></a>
                        <a href="#" class="tc2"></a>
                        <a href="#" class="tc3"></a>
                    </div>
                </div>
                <div class="playerLength">
                    <div class="position">00:00</div>
                    <div class="progress">
                        <div class="pro1"></div>
                        <div class="pro2">
                            <a href="#" class="dian"></a>
                        </div>
                    </div>
                    <div class="duration">03:35</div>
                </div>
            </div>
            <div class="vol">
                <a href="#" class="pinBtn"></a>
                <div class="volm">
                    <div class="volSpeaker"></div>
                    <div class="volControl">
                        <a href="#" class="dian2"></a>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <audio id="audio" src="<%=Songs[0].DownloadUrl %>"></audio>
    <script type="text/javascript">
        var _songCount = <%=Count%>;
    </script>
    <script type="text/javascript" src="/js/jquery-1.10.2.js"></script>
    <script type="text/javascript" src="/js/jquery-ui.js"></script>
    <script type="text/javascript" src="/js/canvas.js"></script>
    <script type="text/javascript" src="/js/mousewheel.js"></script>
    <script type="text/javascript" src="js/jquery.mCustomScrollbar.js"></script>
    <script type="text/javascript" src="/js/common.js"></script>
    <script type="text/javascript" src="/js/xiami.js?v=20180504003"></script>
    <script type="text/javascript">
        $(function () {
            //luoo_player.init();
            
        });
    </script>
</body>
</html>
