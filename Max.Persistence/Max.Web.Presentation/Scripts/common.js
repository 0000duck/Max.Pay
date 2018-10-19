//格式化日期 type type有值时 表示不需要 小时 分
function getDatetime(datetime, type) {
    if (datetime) {
        var d = StrToDate(datetime);
        if (type) {
            return d.getFullYear() + "-" + parseInt(d.getMonth() + 1) + "-" + d.getDate();
        }
        var hour = d.getHours() < 10 ? "0" + d.getHours() : d.getHours();
        var min = d.getMinutes() < 10 ? "0" + d.getMinutes() : d.getMinutes();
        var sec = d.getSeconds() < 10 ? "0" + d.getSeconds() : d.getSeconds();
        return d.getFullYear() + "-" + parseInt(d.getMonth() + 1) + "-" + d.getDate() + "  " + hour + ":" + min + ":" + sec;
    }
    return "";
}

function StrToDate(strDate) {
    var date = eval('new Date(' + strDate.replace(/\d+(?=-[^-]+$)/,
    function (a) { return parseInt(a, 10) - 1; }).match(/\d+/g) + ')');
    return date;
}