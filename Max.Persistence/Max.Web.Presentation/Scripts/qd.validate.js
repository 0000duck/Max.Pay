// 验证中文名称
function isChinaName(name) {
    if (isEmpty(name)) {
        return false;
    }

    var pattern = /^[\u4E00-\u9FA5]{1,6}$/;
    return pattern.test(name);
}

// 验证手机号
function isPhoneNo(phone) {
    if (isEmpty(phone)) {
        return false;
    }

    var pattern = /^1\d{10}$/;
    return pattern.test(phone);
}

// 验证身份证 
function isCardNo(card) {
    if (isEmpty(card)) {
        return false;
    }

    var pattern = /(^\d{15}$)|(^\d{18}$)|(^\d{17}(\d|X|x)$)/;
    return pattern.test(card);
}

// 验证邮箱
function isEmail(email)
{
    if (isEmpty(email)) {
        return false;
    }
    var pattern = /^([a-zA-Z0-9]+[_|\_|\.]?)*[a-zA-Z0-9]+@([a-zA-Z0-9]+[_|\_|\.]?)*[a-zA-Z0-9]+\.[a-zA-Z]{2,3}$/;

    return pattern.test(email);
}

// 车架号验证
function isRackNo(rackNo) {
    if (isEmpty(rackNo)) {
        return false;
    }
    var pattern = /^[a-zA-Z0-9]{17}$/;

    return pattern.test(rackNo);
}

// 发动机号验证
function isEngineNo(engineNo) {
    if (isEmpty(engineNo)) {
        return false;
    }
    var pattern = /^[a-zA-Z0-9]{4,20}$/;

    return pattern.test(engineNo);
}

//时间格式判断
function isDateString(dateStr) {
    if (isEmpty(dateStr)) {
        return false;
    }
    var pattern = /^(\d{4})\-(\d{2})\-(\d{2})$/;
    return pattern.test(dateStr);
}

// 是否为空
function isEmpty(str) {
    if (str == undefined || str == "" || str == null) {
        return true;
    }

    return false;
}

//时间格式判断
function isDateString(dateStr) {
    if (isEmpty(dateStr)) {
        return false;
    }
    var pattern = /^(\d{4})\-(\d{2})\-(\d{2})$/;
    return pattern.test(dateStr);
}
//判断是否截止时间前报价 settingTime 格式 hh:mm:ss
function validatePremiumBeforTime(settingTime) {
    if (settingTime == undefined || settingTime == null) {
        return null;
    }
    var timeArray = settingTime.split(':');
    if (timeArray == null || timeArray.length < 3) {
        return false;
    }
    var nowDate = new Date();
    var hour = nowDate.getHours();//当前的时刻，小时数
    var minute = nowDate.getMinutes();//当前的时刻，分钟数
    var second = nowDate.getSeconds();//当前的时刻，秒数

    if (hour > timeArray[0]) {//达到日切点，返回
        return false;
    }
    else if (hour == timeArray[0] && minute > timeArray[1]) {
        return false;
    }
    else if (hour == timeArray[0] && minute == timeArray[1] && second > timeArray[2]) {
        return false;
    }
    //var nowTimeStr = nowDate.toLocaleTimeString();
    //nowDate = nowDate.valueOf();
    //nowDate = nowDate + 1 * 24 * 60 * 60 * 1000;
    //nowDate = new Date(nowDate);
    return true;
}

//生效日期判断
function validateInsuranceDate(insuranceDateStr, minDateStr, maxDateStr) {
    var insrcDate = new Date(insuranceDateStr);
    var minDate = new Date(minDateStr);
    var maxDate = new Date(maxDateStr);
    if (insrcDate >= minDate && insrcDate <= maxDate) {
        return true;
    }
    return false;
}

function getInsuranceDate(insuranceDate, minDateStr, maxDateStr, isT1) {
    var insrcDate = new Date(insuranceDateStr);
    var minDate = new Date(minDateStr);
    var maxDate = new Date(maxDateStr);
    if (isT1) {//T+1生效
        //生效范围为T+1到T+90，T为自然日      
    }
    else {//T+2生效
        //生效范围为T+2到T+90，T为自然日
        minDate = new Date(minDateStr);
        minDate.setDate(minDate.getDate() + 1);
    }
    var dateStr = insrcDate.Format("yyyy-MM-dd");
    if (insrcDate <= minDate) {
        dateStr = minDate.Format("yyyy-MM-dd");
    }
    else if (insrcDate >= maxDate) {
        dateStr = maxDate.Format("yyyy-MM-dd");
    }
    return dateStr;
}

//返回生效日期提示语
function showInsuranceDateTips(minDateStr, maxDateStr) {
    var minDate = new Date(minDateStr);
    var maxDate = new Date(maxDateStr);
    var dateMsg = ("您的期望起保生效日期选择范围在 {0}年{1}月{2}日~{3}年{4}月{5}日！").format(
                     minDate.getFullYear(), minDate.getMonth() + 1, minDate.getDate(),
                     maxDate.getFullYear(), maxDate.getMonth() + 1, maxDate.getDate());

    return dateMsg;
}

//超过日切点提示
function showTipsBeforeApply(minDateStr, settingTime) {
    var tips = "很遗憾，您未在{0}前完成下单，请您修改保险生效日期为{1}以后进行报价。";
    var minDate = new Date(minDateStr);
    //minDate.setDate(minDate.getDate() + 1);
    var dateStr = minDate.Format("yyyy-MM-dd");
    var timeTips = getCutOffTimeMsg(settingTime);
    tips = tips.format(timeTips, dateStr);
    return tips;
}

function getCutOffTimeMsg(cutOffTime) {
    if (cutOffTime == undefined || cutOffTime == null) {
        return "";
    }
    var timeArray = cutOffTime.split(':');
    if (timeArray == null || timeArray.length < 3) {
        return "";
    }
    var timeTips = "";
    if (parseInt(timeArray[0]) != 0 && parseInt(timeArray[1]) == 0 && parseInt(timeArray[2]) == 0) {
        timeTips = "{0}点".format(timeArray[0]);
    }
    else if (parseInt(timeArray[0]) != 0 && parseInt(timeArray[1]) != 0 && parseInt(timeArray[2]) == 0) {
        timeTips = "{0}点{1}分".format(timeArray[0], timeArray[1]);
    }
    else if (parseInt(timeArray[0]) != 0 && parseInt(timeArray[1]) != 0 && parseInt(timeArray[2]) != 0) {
        timeTips = "{0}点{1}分{2}秒".format(timeArray[0], timeArray[1], timeArray[2]);
    }
    return timeTips;
}

String.prototype.format = function (args) {
    if (arguments.length > 0) {
        var result = this;
        if (arguments.length == 1 && typeof (args) == "object") {
            for (var key in args) {
                var reg = new RegExp("({" + key + "})", "g");
                result = result.replace(reg, args[key]);
            }
        }
        else {
            for (var i = 0; i < arguments.length; i++) {
                if (arguments[i] == undefined) {
                    return "";
                }
                else {
                    var reg = new RegExp("({[" + i + "]})", "g");
                    result = result.replace(reg, arguments[i]);
                }
            }
        }
        return result;
    }
    else {
        return this;
    }
}

// 对Date的扩展，将 Date 转化为指定格式的String
// 月(M)、日(d)、小时(h)、分(m)、秒(s)、季度(q) 可以用 1-2 个占位符， 
// 年(y)可以用 1-4 个占位符，毫秒(S)只能用 1 个占位符(是 1-3 位的数字) 
// 例子： 
// (new Date()).Format("yyyy-MM-dd hh:mm:ss.S") ==> 2006-07-02 08:09:04.423 
// (new Date()).Format("yyyy-M-d h:m:s.S")      ==> 2006-7-2 8:9:4.18 
Date.prototype.Format = function (fmt) {
    var o = {
        "M+": this.getMonth() + 1, //月份 
        "d+": this.getDate(), //日 
        "h+": this.getHours(), //小时 
        "m+": this.getMinutes(), //分 
        "s+": this.getSeconds(), //秒 
        "q+": Math.floor((this.getMonth() + 3) / 3), //季度 
        "S": this.getMilliseconds() //毫秒 
    };
    if (/(y+)/.test(fmt)) fmt = fmt.replace(RegExp.$1, (this.getFullYear() + "").substr(4 - RegExp.$1.length));
    for (var k in o)
        if (new RegExp("(" + k + ")").test(fmt)) fmt = fmt.replace(RegExp.$1, (RegExp.$1.length == 1) ? (o[k]) : (("00" + o[k]).substr(("" + o[k]).length)));
    return fmt;
}