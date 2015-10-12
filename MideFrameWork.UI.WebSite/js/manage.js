function Manage() {
};
var manage = new Manage();

$(window).load(function () {
    manage.init();
    $(window).resize(function () {
        manage.init();
    });
    $("#mainframe").load(function () {
        manage.init();
        //manage.setFramesHeight(this,$("#mainframe").contents().find("body").height());
    });
    $("#messageframe").load(function () {
        manage.setFramesHeight(this, $("#messageframe").contents().find("body").height());
    });
});

Manage.prototype.setFramesHeight = function (iframe, height) {
    $(iframe).height(height);
}
var width_win = null;
var width_menuframe = null;
var width_messagemain = null;
var width_appmain = null;
var width_contentmain = null;
Manage.prototype.setFramesWidth = function () {
    width_win = $("body").width();
    width_menuframe = $("#menuframe").width();
    width_messagemain = $("#message_main").width();
    width_appmain = $("#app_main").width(width_win - width_menuframe);


    if (width_win > 600) {
        $("#content_main").width(width_win - width_menuframe - width_messagemain - 35);
    } else {
        $("#app_main").width(385);
        $("#content_main").width(385);
    }

    width_contentmain = $("#content_main").width();

    if (width_contentmain < 500 || width_contentmain == 500) {
        $("#message_main").css("display", "none");
        $("#content_main").width(width_win - width_menuframe - 35);
    } else {
        $("#message_main").css("display", "block");
    }
};
Manage.prototype.init = function () {
    manage.setFramesHeight("#mainframe", $("#mainframe").contents().find("body").height());
    manage.setFramesHeight("#messageframe", $("#messageframe").contents().find("body").height());
    manage.setFramesWidth();
}
/***读取值***/
Manage.prototype.setValue = function (value) {
    return value;
}
/***读取值***/
Manage.prototype.getValue = function () {

    var child = document.getElementById("dialog-addConntactframe").contentWindow; //mainFrame这个id是父页面iframe的id 
    //在AddPhoneToSend.aspx页面用隐藏的textArea控件暂时保存要传递的号码；
    return $(child.document.getElementById("txt_Value")).val();
}
Manage.prototype.newcontact = function () {
    /**新建联系人显示**/
    Util.Dialog({
        title: "新建联系人",
        width: "550px",
        height: "350px",
        boxID: "dialog-newcontact",
        showborder: true,
        showbg: true,
        fixed: true,
        content: "iframe:AddLinkMan.aspx"
    });
}
Manage.prototype.importContact = function () {
    /**导入联系人显示**/
    Util.Dialog({
        title: "导入联系人",
        width: "550px",
        height: "350px",
        boxID: "dialog-importContact",
        showborder: true,
        showbg: true,
        fixed: true,
        content: "iframe:ImportLinkMan.aspx"
    });
}
/**在联系人管理页面弹出导入页面**/
Manage.prototype.exportContact = function () {

    Util.Dialog({ title: "导出联系人", width: "550px", height: "350px", boxID: "dialog-exportContact", showborder: true, showbg: true, fixed: true, content: "iframe:export_contact.html"
    });
}
/**在群发页面弹出导入联系人**/
Manage.prototype.messagebox = function (json) {
    Util.Dialog(json);
}
/**在群发页面弹出导入联系人**/
Manage.prototype.CloseMsgBox = function (boxID) {
    Util.Dialog.close(boxID, "");
}