if (manage == null) {
    var manage = new window.top.Manage();
}

$(function () {
    $("#newcontact").click(function () {
        manage.messagebox({ title: "新建联系人", width: "550px", height: "300px", boxID: "dialog-newcontact", showborder: true, showbg: true, fixed: true, content: "iframe:AddLinkMan.aspx" });
    });
    $("#importContact").click(function () {
        manage.messagebox({ title: "导入联系人", width: "550px", height: "200px", boxID: "dialog-importContact", showborder: true, showbg: true, fixed: true, content: "iframe:ImportLinkMan.aspx" });
    });
//    $("#exportContact").click(function () {
//        manage.messagebox({ title: "导出", width: "550px", height: "400px", boxID: "dialog-exportContact", showborder: true, showbg: true, fixed: true, content: "iframe:export_contact.html" });
//    });
});