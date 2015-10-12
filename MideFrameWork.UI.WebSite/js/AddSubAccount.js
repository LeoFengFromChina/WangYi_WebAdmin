if (manage == null) {
    var manage = window.top.manage;
}
function CloseBox() {
    parent.CloseMsgBox('dialog-addSubAccount');
}
function checkInput() {
    var tem1 = document.getElementById("txt_ChildAccount").value;
    var tem2 = document.getElementById("txt_ParentAccount").value;
    var tem3 = document.getElementById("txt_Psw").value;
    var tem4 = document.getElementById("txt_ConfimPsw").value;
    var tem5 = document.getElementById("txt_Signature").value;
    var tem6 = document.getElementById("txt_Balance").value;
    var tem7 = document.getElementById("txt_Mobile").value;
    if (tem1.length <= 0
            || tem2.length <= 0
            || tem3.length <= 0
            || tem4.length <= 0
            || tem5.length <= 0
            || tem6.length <= 0
            || tem7.length <= 0) {
        alert("不能为空！"); return false;
    }
    else if (tem3 != tem4) {
        alert("确认密码不相同！"); return false;
    }
    else
    { return true; }

    //还要加上电话号码格式的判断、数字的判断
}