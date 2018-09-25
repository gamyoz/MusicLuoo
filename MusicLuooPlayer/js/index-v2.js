(function ($) {
    jQuery.fn.extend({
        "initAudio": function () {
            var myAudio = $("audio", this)[0];
            var $sourceList = $("source", this);
            var currentSrcIndex = 0;
            var currentSrc = "";

            /*添加播放器UI组件
            this.append(
				'<div class="music_info clearfix">\
					<div class="cd_holder"><span class="stick"></span><div class="cd"></div></div>\
					<div class="meta_data">\
						<span class="title"></span>\
						<div class="rating">\
							<div class="starbar">\
								<ul class="current-rating" data-score="85">\
									<li class="star5"></li>\
									<li class="star4"></li>\
									<li class="star3"></li>\
									<li class="star2"></li>\
									<li class="star1"></li>\
								</ul>\
							</div>\
						</div>\
						<div class="volume_control">\
							<a class="icon-volume-decrease"></a>\
							<span class="base_bar">\
								<span class="progress_bar"></span>\
								<a class="slider"></a>\
							</span>\
							<a class="icon-volume-increase" style="margin-left: 10px;"></a>\
						</div>\
					</div>\
				</div>\
				<ul class="music_list"></ul>\
				<div class="controls">\
                    <table>\
                        <tr>\
                            <td style="width:120px;">\
                                <div class="play_controls">\
						            <a class="icon-previous"></a>\
						            <a class="icon-play" id="btn_play"></a>\
						            <a class="icon-next"></a>\
					            </div>\
                            </td>\
                            <td style="width:30px;" align="right">\
                                <span class="passed_time" id="passed_time">0:00</span>\
                            </td>\
                            <td>\
                                <div class="time_line">\
                                    <span class="base_bar" id="play_progress_bar">\
						                <span class="progress_bar"></span>\
						            </span>\
                                </div>\
                            </td>\
                            <td style="width:30px;">\
                                <span class="total_time" id="total_time">0:00</span>\
                            </td>\
                            <td class="play_type">\
                                <a class="icon-loop" id="btn_play_type"></a>\
                            </td>\
                        </tr>\
                    </table>\
				</div>'
			);*/
            /*为播放列表添加歌曲信息*/
            for (var i = 0; i < $sourceList.length; i++) {
                $(".music_list").append("<li>" + $sourceList[i].title + "</li>");
            };
            /*调控音量方法*/
            HTMLAudioElement.prototype.changeVolumeTo = function (volume) {
                this.volume = volume;
                $(".volume_control .progress_bar").css("width", volume * 100 + "%");
                $(".volume_control .slider").css("left", volume * 100 - 7 + "px");
            }
            /*为播放器添加事件监听*/
            /*播放、暂停、上一首、下一首功能实现*/
            $(".icon-play,.icon-pause").click(function () {
                if (myAudio.paused) {
                    mplay();
                } else {
                    myAudio.pause();
                }
            });
            $(".icon-next").click(function () {
                var type = 0;//循环
                if ($("#btn_play_type").hasClass("icon-shuffle")) type = 1;
                else if ($("#btn_play_type").hasClass("icon-infinite")) type = 2;

                var sid = 0;
                switch (type) {
                    case 1:
                        sid = getRandom();
                        break;
                    case 2:
                        sid = currentSrcIndex;
                        break;
                    default:
                        sid = currentSrcIndex + 1;
                        var max = $("#myAudio source").length;
                        if (sid > max) sid = 0;
                        break;
                }

                currentSrcIndex = sid;
                currentSrc = $("#myAudio source").eq(currentSrcIndex).prop("src");
                myAudio.src = currentSrc;
                mplay();
            });
            $(".icon-previous").click(function () {
                var type = 0;//循环
                if ($("#btn_play_type").hasClass("icon-shuffle")) type = 1;
                else if ($("#btn_play_type").hasClass("icon-infinite")) type = 2;

                var sid = 0;
                switch (type) {
                    case 1:
                        sid = getRandom();
                        break;
                    case 2:
                        sid = currentSrcIndex;
                        break;
                    default:
                        sid = currentSrcIndex - 1;
                        var max = $("#myAudio source").length;
                        if (sid < 0) sid = max;
                        break;
                }

                currentSrcIndex = sid;
                currentSrc = $("#myAudio source").eq(currentSrcIndex).prop("src");
                myAudio.src = currentSrc;
                mplay();
            });
            function getRandom() {//获取随机数
                var max = $("#myAudio source").length;
                var rand = Math.floor(Math.random() * (max - 0 + 1) + 0);
                while (rand == currentSrcIndex) {
                    rand = Math.floor(Math.random() * (max - 0 + 1) + 0);
                }
                return rand;
            }
            /* */
            $("#btn_play_type").click(function() {
                var cur = $(this).attr("class");
                if (cur == "icon-loop") {
                    cur = "icon-shuffle";
                }else if (cur == "icon-shuffle") {
                    cur = "icon-infinite";
                } else {
                    cur = "icon-loop";
                }
                $(this).attr("class", cur);
            });
            /*音量调控功能实现*/
            $(".volume_control .decrease").click(function () {
                var volume = myAudio.volume - 0.1;
                volume < 0 && (volume = 0);
                myAudio.changeVolumeTo(volume);
            });
            $(".volume_control .increase").click(function () {
                var volume = myAudio.volume + 0.1;
                volume > 1 && (volume = 1);
                myAudio.changeVolumeTo(volume);
            });
            $(".volume_control .base_bar").mousedown(function (ev) {
                var posX = ev.clientX;
                var targetLeft = $(this).offset().left;
                var volume = (posX - targetLeft) / 100;
                volume > 1 && (volume = 1);
                volume < 0 && (volume = 0);
                myAudio.changeVolumeTo(volume);
            });
            $(".volume_control .slider").mousedown(starDrag = function (ev) {
                ev.preventDefault();
                var origLeft = $(this).position().left;      /*滑块初始位置*/
                var origX = ev.clientX;						/*鼠标初始位置*/
                var target = this;
                var progress_bar = $(".volume_control .progress_bar")[0];
                $(document).mousemove(doDrag = function (ev) {
                    ev.preventDefault();
                    var moveX = ev.clientX - origX;        /*计算鼠标移动的距离*/
                    var curLeft = origLeft + moveX;			/*用鼠标移动的距离表示滑块的移动距离*/
                    (curLeft < -7) && (curLeft = -7);
                    (curLeft > 93) && (curLeft = 93);
                    target.style.left = curLeft + "px";
                    progress_bar.style.width = curLeft + 7 + "%";
                    myAudio.changeVolumeTo((curLeft + 7) / 100);
                });
                $(document).mouseup(stopDrag = function () {
                    $(document).unbind("mousemove", doDrag);
                    $(document).unbind("mouseup", stopDrag);
                });
            });
            /*音频进度条调控功能实现*/
            $(".time_line .base_bar").mousedown(function (ev) {
                var posX = ev.clientX;
                var targetLeft = $(this).offset().left;
                var percentage = (posX - targetLeft) / ((document.documentElement.clientWidth - 290)) * 100;
                myAudio.currentTime = myAudio.duration * percentage / 100;
            });
            $(".music_info .cd").click(function () {
                $(".music_list").slideToggle(600);
            });
            $(".music_list").click(function (ev) {
                var index = $(ev.target).index();
                currentSrcIndex = index;
                currentSrc = $("#myAudio source:eq(" + currentSrcIndex + ")").prop("src");
                myAudio.src = currentSrc;
                mplay();
            });
            /*audio元素事件绑定*/
            $(myAudio).bind("loadedmetadata", function () {
                var totalTime = formatTime(myAudio.duration);
                var title = $("#myAudio source:eq(" + currentSrcIndex + ")").attr("title");
                $("#total_time").text(totalTime);
                $(".meta_data .title").text(title);
            });
            $(myAudio).bind("timeupdate", function () {
                var duration = this.duration;
                var curTime = this.currentTime;
                var percentage = curTime / duration * 100;
                $(".time_line .progress_bar").css("width", percentage + "%");

                var passedTime = formatTime(curTime);
                $("#passed_time").text(passedTime);
            });
            $(myAudio).bind("play", function () {
                try {
                    $(".icon-play").text("");
                    $(".music_list li").eq(currentSrcIndex).addClass("active")
                    .siblings().removeClass("active");
                    $(".music_info .cd").addClass("rotate");
                    $(".cd_holder .stick").addClass("play");
                    $("#btn_play").removeClass("icon-play").addClass("icon-pause");
                } catch (e) {
                    console.log("error:" + e.message);
                    $(".icon-next").click();
                } 
            });
            myAudio.addEventListener("error", function (e) {
                console.log(e);
                $(".icon-next").click();
                return false;
            });
            $(myAudio).bind("pause", function () {
                $(".icon-play").text("");
                $(".music_info .cd").removeClass("rotate");
                $(".cd_holder .stick").removeClass("play");
                $("#btn_play").removeClass("icon-pause").addClass("icon-play");
            });
            $(myAudio).bind("ended", function () {
                $(".icon-next").triggerHandler("click");
            });
            $(myAudio).bind("progress", function () {
                if (myAudio.buffered.length == 1) {
                    // only one range
                    if (myAudio.buffered.start(0) == 0) {
                        // The one range starts at the beginning and ends at
                        // the end of the video, so the whole thing is loaded
                        var buffered = myAudio.buffered.end(0);
                        var percentage = buffered / myAudio.duration * 100;
                        $(".time_line .base_bar").css("background-size", percentage + "% 100%");
                    }
                }
                
            });
            $(myAudio).trigger("loadedmetadata");
            /*歌曲播放时间的格式化，将秒数格式化为“分:秒”的形式*/
            function formatTime(time) {
                var minutes = parseInt(time / 60);
                var seconds = parseInt(time % 60);
                seconds < 10 && (seconds = "0" + seconds);
                return minutes + ":" + seconds;
            };

            function mplay() {
                try {
                    myAudio.play();
                } catch (e) {
                    console.log("error:" + e.message);
                    $(".icon-next").click();
                } 
            }
        }
    });
})(jQuery)