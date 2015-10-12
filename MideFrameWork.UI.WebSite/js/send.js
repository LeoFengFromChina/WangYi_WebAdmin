if (manage == null) {
    var manage = new window.top.Manage();
}
$(function () {
    $("#add_conntact").click(function () {
        manage.messagebox({ title: "导入发送", width: "900px", height: "600px", boxID: "dialog-addConntact", showborder: true, showbg: true, fixed: true, content: "iframe:AddPhoneToSend.aspx"
        });
    });
    $(window).resize(function () {
        $(".text_area").width($("body").width() - 2);
    });
    $(".text_area").width($("body").width() - 2);
});

function setView(Data) {
    parent.SetFrameContentView("menuframe", "lbl_Balance", Data);
}


if (manage == null) {
    var manage = new window.top.Manage();
}


function getText(value) {
    $("#txt_Phones").val(value);
};
