jQuery(document).ready(function ($) {

    Util.loadJS("XY_Dialog.js", function () {

        /**新建联系人里的提示 **/
        function tips(referID, tipText) {
            $(Util.getID(referID)).focusout(function () {
                $(Util.getID(referID + "_tips")).hide();
            }).focusin(function () {
                Util.Dialog({
                    type: "tips",
                    boxID: referID + "_tips",
                    referID: referID,
                    width: 100,
                    height: 25,
                    border: {
                        opacity: "0",
                        radius: "3"
                    },
                    closestyle: "red",
                    arrow: "left",
                    fixed: false,
                    arrowset: {
                        val: "10px"
                    },
                    content: "text:" + tipText,
                    position: {
                        left: "0px",
                        top: "0px",
                        lin: false,
                        tin: true
                    }

                });
                $(Util.getID(referID + "_tips")).show();
                return false;
            });
        }
        tips("contactNameText", "请输入姓名");
        tips("contactTelText", "请输入手机号码");
        tips("contactEmailText", "请输入电子邮箱");
        tips("contactAddressText", "请输住址");
        //新建分类
        $("#newTypeBtn").click(function () {
            $("#newTypeBtn").css("display", "none");
            $("#savetext").css("display", "inline-block");
            $("#saveType").css("display", "inline-block");
            $("#cancelType").css("display", "inline-block");
            $("#contactTypeText").val("");
            return false;
        });
        //取消新建分类
        $("#cancelType").click(function () {
            $("#newTypeBtn").css("display", "inline-block");
            $("#savetext").css("display", "none");
            $("#saveType").css("display", "none");
            $("#cancelType").css("display", "none");
            return false;
        });
        //保存分类
        $("#saveType").click(function () {

            //判断分组长度与是否为空 fengrd 2013-7-25 21:32:56
            if ($("#contactTypeText").val().length > 8) {
                alert("分组名不能超过8个字！");
                return false;
            }
            else if ($("#contactTypeText").val().length <= 0) {
                alert("分组名不能为空！");
                return false;
            }
            //判断分组长度与是否为空 fengrd 2013-7-25 21:32:56

            $("#newTypeBtn").css("display", "inline-block");
            $("#savetext").css("display", "none");
            $("#saveType").css("display", "none");
            $("#cancelType").css("display", "none");
            saveSelect("contact_type", $("#contactTypeText").val(), $("#contactTypeText").val());
            return true;
        });

    });
});

function saveSelect(selObj, text, value) {
    var bool = true;
    $("#" + selObj + " option").each(function (index, domele) {
        if ($(domele).text() == text) {
            bool = false;
        }
    });
    if (text != null && text !== "") {
        if (bool) {
            $("#" + selObj).append("<option value='" + value + "'>" + text + "</option>");  //添加一项option
        } else {

        }
        //$("#"+selObj).get(0).selectedIndex=1;  //设置Select索引值为1的项选中 
        $("#" + selObj).val(value);   // 设置Select的Value值为4的项选中
    }


};
