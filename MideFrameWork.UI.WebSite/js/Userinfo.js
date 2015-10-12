$(function () {
    var docWidth = $("body").width();
    var profile_pinfoWidth = $(".profile_pinfo").outerWidth(true);
    $("#subAccountTable").width(docWidth - profile_pinfoWidth);


    $(".W_btn_round").click(function () {
        var actionData = $(this).attr("action-data");
        if (actionData == "edit=0") {
            $(this).attr("action-data", "edit=1");
            $(this).find("span").html("保存");
            $(".base").show();
            $(".base_view").hide();
        } else if (actionData == "edit=1") {
            $(this).attr("action-data", "edit=0");
            //有更新才确认更新
            if ($("#txt_CorpName_2").val() != document.getElementById("txt_CorpName").innerText
            || $("#txt_Email_2").val() != document.getElementById("txt_Email").innerText
            || $("#txt_Mobile_2").val() != document.getElementById("txt_Mobile").innerText
            || $("#txt_Signature_2").val() != document.getElementById("txt_Signature").innerText
            || $("#txt_Tel_2").val() != document.getElementById("txt_Tel").innerText) {
                __doPostBack('btn_Save', '');
            }
            $(this).find("span").html("编辑");
            $(".base").hide();
            $(".base_view").show();
        }
    });
    $(".addBtn").click(function () {

        manage.messagebox({
            title: "新增子账号",
            width: "500px",
            height: "300px",
            boxID: "dialog-addSubAccount",
            showborder: true,
            showbg: true,
            fixed: true,
            content: "iframe:NewSubAccount.aspx"
        });
    });

});

$(window).resize(function () {
    var docWidth = $("body").width();
    var profile_pinfoWidth = $(".profile_pinfo").outerWidth(true);
    $("#subAccountTable").width(docWidth - profile_pinfoWidth);

    if (docWidth > 700) { }

});