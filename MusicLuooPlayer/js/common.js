/****拼接字符串****/
function StringBuffer() {
    this.__strings__ = new Array();
};
StringBuffer.prototype.append = function (str) {
    this.__strings__.push(str);
};
StringBuffer.prototype.toString = function () {
    return this.__strings__.join('');
};

function upper(e) {
    var ev = event.keyCode;
    if (ev >= 65 && ev <= 90) {
        var that = $(e);
        that.val(that.val().toUpperCase());
    }
}

/*js替换所有*/
function replaceAll(str, oldval, newval) {
    return str.replace(new RegExp(oldval, "g"), newval);
}
function replaceJson(str) {
    if (str) {
        str = replaceAll(str, "：", ":");
    }
    return str;
}

/*
 * 将字符串格式化为16进制
 */
function textToHex(str) {
    var val = "";
    var temp;
    for (var i = 0; i < str.length; i++) {
        temp = str.charCodeAt(i).toString(16);
        var distanceStr = '';
        for (var j = 0; j < 4 - temp.length; j++) {
            distanceStr += "0";
        }
        val += distanceStr + temp;
    }
    return val.toUpperCase();
}

/*
 * 将16进制字符串格式化为字符串
 */
function hexToText(str) {
    if (str) {
        if (str.length % 4 != 0) return str;
        var temp = str.length / 4;
        var val = "";
        for (var i = 0; i < temp; i++) {
            val += String.fromCharCode(parseInt(str.substr(i * 4, 4), 16));
        }
        return val;
    }
    return "";
}

/**
 * 对象是否为空
 * 
 * @param obj
 * @returns {Boolean}
 */
function isObjectEmpty(obj) {
    return typeof (obj) == "undefined" || obj == null || obj == "";
}

/**
 * 格式化是否
 * 
 * @param value
 * @param row
 * @param index
 * @returns
 */
function boolFormat(value) {
    return value == "1" ? "是" : "否";
}
/**
 * 格式化性别
 * 
 * @param value
 * @param row
 * @param index
 * @returns
 */
function sexFormat(value) {
    return value == "0" ? "男" : "女";
}

/**
 * 打开对话框
 * 
 * @param dialogId
 * @returns
 */
window.onerror = function (msg) {
    alert(msg);
};

/**
 * Ajax 请求调用后台数据
 * 
 * @param url
 * @param params
 * @param successCallback
 * @param failureCallback
 */
function ajax(url, methodTye, params, successCallback, failureCallback, isAsync) {
    if (isAsync == null || typeof (isAsync) == "undefined")
        isAsync = true;
    $.ajax({
        url: url,
        type: methodTye || "POST",
        data: params,
        contentType: "application/x-www-form-urlencoded; charset=utf-8",
        timeout: 30*1000,
        async: isAsync,
        dataType: 'json',
        success: function (response) {//document.write(response)
            if (response.code == 1 && $.isFunction(successCallback)) {
                var result = response.data || "";
             
                if (result.indexOf('{') == 0 || result.indexOf('[') == 0) {
                    result = $.parseJSON(result);
                }
                successCallback(result);
            } else if (response.code != 1) {
                failureCallback = $.isFunction(failureCallback) ? failureCallback : showError;
                failureCallback(response.message);
            }
        },
        error: function (response) {
            failureCallback = $.isFunction(failureCallback) ? failureCallback : showError;
            failureCallback("ERROR");
        }
    });
}

function showError(msg) {
    alert("错误：" + msg);
}

/**
 * 获取url后的搜索串
 */
function request(key, seachUrl) {
    // var seachUrl = window.location.search.replace("?", "");
    seachUrl = seachUrl || window.location.href;
    if (seachUrl.indexOf("?") < 0) {
        return "";
    }
    seachUrl = seachUrl.replace(/#/g, "").split("?")[1];
    var ss = seachUrl.split("&");
    var keyStr = "";
    var keyIndex = -1;
    for (var i = 0; i < ss.length; i++) {
        keyIndex = ss[i].indexOf("=");
        keyStr = ss[i].substring(0, keyIndex);
        if (keyStr.toLowerCase() == key.toLowerCase()) {
            return decodeURIComponent(ss[i].substring(keyIndex + 1, ss[i].length));
        }
    }
    return "";
}
/**
 * 判断是否为数字，是则返回true,否则返回false
 */
function check_number(obj) {
    if (/^\d+$/.test(obj)) {
        return true;
    } else {
        return false;
    }
}

/**
 * 格式化字符串
 * 
 * @returns
 */
String.Format = function () {
    if (arguments.length == 0)
        return null;

    var str = arguments[0];
    for (var i = 1; i < arguments.length; i++) {
        var re = new RegExp('\\{' + (i - 1) + '\\}', 'gm');
        str = str.replace(re, arguments[i]);
    }
    return str;
};

function getIndexFromArray(arr, val, key) {
    var index = -1;
    $(arr).each(function (i) {
        if (key && this[key] == val) {
            index = i;
            return i;
        }
        if (!key && this == val) {
            index = i;
            return i;
        }
    });
    return index;
}

/**
 * 为JS数组对象定义删除操作
 * 
 * @param n
 * @returns
 */
Array.prototype.del = function (dx) {
    if (isNaN(dx) || dx > this.length) {
        return false;
    }
    for (var i = 0, n = 0; i < this.length; i++) {
        if (this[i] != this[dx]) {
            this[n++] = this[i];
        }
    }
    this.length -= 1;
};

//js 去除元素中的 html标签
function setContent(str) {
    str = str.replace(/<\/?[^>]*>/g, ''); //去除HTML tag
    str = str.replace(/[ | ]*\n/g, '\n'); //去除行尾空白
    str = str.replace(/\n[\s| | ]*\r/g, '\n'); //去除多余空行
    return str;
}

//判断图片类型  
function checkImgType(fileName) {
    if (fileName.Trim() == "") {
        return true;
    }
    fileName = fileName.toLowerCase();
    if (!/\.(gif|jpg|jpeg|png|txt|doc|xls|pdf)$/.test(fileName)) {
        showInfo("附件的文件格式不正确，必须是gif|jpg|jpeg|png|txt|doc|xls|pdf中的一种");
        return false;
    }
    return true;
}

/*cookie操作*/
$.cookie = {
    addCookie: function (objName, objValue, objHours) {
        var str = objName + "=" + encodeURIComponent(objValue);
        objHours = objHours || 1;
        var date = new Date();
        var ms = objHours * 3600 * 1000;
        date.setTime(date.getTime() + ms);
        str += "; path=/; expires=" + date.toGMTString();
        document.cookie = str;
    },
    getCookie: function (objName) {
        var arrStr = document.cookie.split("; ");
        var cookie = null;
        for (var i = 0; i < arrStr.length; i++) {
            var temp = arrStr[i].split("=");
            if (temp[0] == objName) {
                cookie = decodeURIComponent(temp[1]);
                break;
            }
        }
        return cookie;
    },
    delCookie: function (objName) {
        var expdate = new Date();
        expdate.setTime(expdate.getTime() - (86400 * 1000 * 1));
        $.cookie.addCookie(objName, "", expdate);
    }
};