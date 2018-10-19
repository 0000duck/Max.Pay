$(function () {
    var $listTableHead = $(".listTableHead");
    var $listTableBody = $(".listTableBody");
    var $dataTables_scrollBody = $(".dataTables_scrollBody");
    var tbWidth = 0;
    var tableHeadTh = $(".listTableHead th");
    var tableBodyFisrtTd = $(".listTableBody tr:eq(0) td");
    var $listTableBodyTr = $(".listTableBody").find("tr");

    for (var i = 0; i < tableHeadTh.length; i++) {
        if (tableBodyFisrtTd.length > 0) {
            if (parseFloat($(tableHeadTh[i]).css("width")) > parseFloat($(tableBodyFisrtTd[i]).css("width"))) {
                tbWidth = parseFloat(tbWidth) + parseFloat($(tableHeadTh[i]).css("width"));
            } else {
                tbWidth = parseFloat(tbWidth) + parseFloat($(tableBodyFisrtTd[i]).css("width"));
            }
        } else {
            $(".listTableHead th").each(function (idex, domel) {
                tableBodyFisrtTdWidth
                tbWidth = parseFloat(tbWidth) + parseFloat(domel.width);
            });
        }
    }

    $dataTables_scrollBody.css("width", parseFloat(tbWidth) + 24);
    $listTableHead.css("width", tbWidth);
    $listTableBody.css("width", tbWidth);
    CalWindowHeigth();
    for (var i = 0; i < tableHeadTh.length; i++) {
        if (tableBodyFisrtTd.length > 0) {
            var tableHeadThWidth = parseFloat($(tableHeadTh[i]).css("width"));
            var tableBodyFisrtTdWidth = parseFloat($(tableBodyFisrtTd[i]).css("width"));
            if (tableHeadThWidth > tableBodyFisrtTdWidth) {
                $dataTables_scrollBody.css("width", parseFloat($dataTables_scrollBody.css("width")) + tableHeadThWidth - tableBodyFisrtTdWidth)
                $listTableBody.css("width", parseFloat($listTableBody.css("width")) + tableHeadThWidth - tableBodyFisrtTdWidth);
                // $dataTables_scrollBody.width(parseFloat($listTableBody.css("width"))+24)
                $listTableBodyTr.children("td").eq(i).css("width", tableHeadThWidth);
                $(tableHeadTh[i]).css("width", tableHeadThWidth);
            } else {
                $listTableHead.css("width", parseFloat($listTableHead.css("width")) + tableBodyFisrtTdWidth - tableHeadThWidth);
                $(tableHeadTh[i]).css("width", tableBodyFisrtTdWidth);
                $listTableBodyTr.children("td").eq(i).css("width", tableBodyFisrtTdWidth);
            }
        }
    }
  

});

$(window).resize(function () {
    CalWindowHeigth();
});

function CalWindowHeigth() {
    var $dataTables_scrollBody = $(".dataTables_scrollBody");
    var topheight = $(".page-header-inner .page-top").height();
    var titleheight = $(".portlet .portlet-title").height();
    var fromheight = $(".portlet .portlet-body form").height();
    var tableheight = $("table.listTableHead").height();
    //console.log(pageheight);
    var bodyheight = $(window).height();
    $dataTables_scrollBody.css("max-height", parseInt(bodyheight) - parseInt(topheight) - parseInt(titleheight) - parseInt(fromheight) - parseInt(tableheight) - 140);
}