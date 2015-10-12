
function Addcontact() {
};
Addcontact.prototype.selectTag = function (showContent, selfObj) {
    // 操作标签
    var tag = $("#tags li");

    tag.removeClass("selectTag");

    selfObj.addClass("selectTag");
    // 操作内容
    for (i = 0; j = document.getElementById("tagContent" + i); i++) {
        j.style.display = "none";
    }
    document.getElementById(showContent).style.display = "block";

}

if (manage == null) {
    var manage = new window.top.Manage();
}

$(function () {

    $(".input_checkbox").change(function () {
        alert("checked");
    });

    var tag = $("#tags li");
    var tagContent = $("#tagContent .tagContent ");

    tag.click(function () {
        var index = $(this).attr("index");
        ui.selectTag(tag, tagContent, index, "selectTag");
        app.setCookie('displayDiv', index);
    });

    var index = app.getCookie('displayDiv');
    if (index != null) {
        if (index < tagContent.length) {
            ui.selectTag(tag, tagContent, index, "selectTag");
        } else { ui.selectTag(tag, tagContent, 0, "selectTag"); }
    }
    else {
        ui.selectTag(tag, tagContent, 0, "selectTag");
    }

});