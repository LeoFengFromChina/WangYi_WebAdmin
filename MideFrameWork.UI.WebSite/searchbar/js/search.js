function dropdownTab(id) {
    $("#" + id + " .selectContent a").width($("#" + id).width());
    $("#" + id + " .selectContent").width($("#" + id).width());
    $("#" + id + "  .selectTitle").click(function () {
        $("#" + id + " .selectContent").removeClass("fd-hide");
    });
    $("#" + id + " .selectContent li a").click(function () {
        $("#" + id + " .selectTitle").attr("value", $(this).attr("value")).html($(this).html());
        $("#" + id + " .selectTitle").attr("index", $(this).attr("index")).html($(this).html());
        $("#" + id + " .hidvalueSave").attr("value", $(this).attr("value") + ";" + $(this).html());

        $("#" + id + " .selectContent").addClass("fd-hide");
    });

    $("#" + id).mouseleave(function (e) {
        $("#" + id + "  .selectContent").addClass("fd-hide");

    });
};
function DropdownClick(id) {
    $("#" + id + " .selectContent li a").click(function () {
        var $this = $(this);
        var index = $this.attr("index");

        $(".selectList").each(function (obj, domEle) {
            if (index == $(domEle).attr("index")) {
                $(domEle).css("display", "block");
            } else {
                $(domEle).css("display", "none");
            }
        });
    });
}

$(function () {
//    if (manage == null) {
//   //     var manage = new window.top.Manage();
//        $("#myQueryHelper_datetxt1").click(function () {
//          //  manage.SetDate(this);
//        }); $("#myQueryHelper_datetxt2").click(function () {
//     //       manage.SetDate(this);
//        });
//    }
    dropdownTab("selectAll");
    dropdownTab("selectStatus");
    DropdownClick("selectAll");
}); 