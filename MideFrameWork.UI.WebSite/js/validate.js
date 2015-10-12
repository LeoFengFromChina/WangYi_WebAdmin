// JavaScript Document
//验证帐号函数
function validate_account(str_account) {
    var reg = new RegExp("^([a-zA-Z]{1})([a-zA-Z0-9]{5,31})$");
    return reg.test($.trim(str_account));
}
//验证密码函数
function validate_password(str_password) {
    var reg = new RegExp("^[a-zA-Z0-9]{6,12}$");
    return reg.test($.trim(str_password));
}
//验证公司名称函数
function validate_company_name(str_company_name) {
    var reg = new RegExp("^[a-zA-Z0-9\u4e00-\u9fa5]{4,32}$");
    return reg.test($.trim(str_company_name));
}
//验证公司签名函数
function validate_signature(str_signature) {
    var reg = new RegExp("^[a-zA-Z0-9\u4e00-\u9fa5]{0,32}$");
    return reg.test($.trim(str_signature));
}
//验证固定电话函数
function validate_fixed_tel(str_telephone) {
    var reg = new RegExp(/^(\d{3}-\d{8}|\d{4}-\d{7})$/);
    var str_telephone = $.trim(str_telephone);
    if (reg.test(str_telephone)) {
        return true;
    } else {
        return false;
    }
}
//验证移动电话函数
function validate_mobile_tel(str_telephone) {
    var reg = new RegExp(/^[1]{1}[3|5|8]{1}[0-9]{9}$/);
    var str_telephone = $.trim(str_telephone);
    if (reg.test(str_telephone)) {
        return true;
    } else {
        return false;
    }
}
//验证邮箱函数
function validate_email(str_email) {
    var reg = new RegExp("^([a-zA-Z0-9_-])+@([a-zA-Z0-9_-])+(.[a-zA-Z0-9_-])+");
    return reg.test($.trim(str_email));
}
$(function () {
    $("#reg input").bind({
        blur: function () {
            var obj = $(this);
            switch (obj.attr("name")) {
                case "user_account":
                    if (obj.attr("value") != "") {
                        if (validate_account(obj.attr("value"))) {
                            $("#tips_account").css({ "visibility": "hidden" });
                            $("#right_icon_account").css({ "display": "block" });
                        } else {
                            $("#right_icon_account").css({ "display": "none" });
                            $("#tips_account_msg").html("帐号须由6-32个字母或数字组成，且以字母开始");
                            $("#tips_account").css({ "visibility": "visible" }).fadeOut(500).fadeIn(200);
                        }
                    } else {
                        $("#tips_account").css({ "visibility": "hidden" });
                        $("#right_icon_account").css({ "display": "none" });
                    }
                    break;
                case "user_password":
                    if (obj.attr("value") != "") {
                        if (validate_password(obj.attr("value"))) {
                            $("#tips_password").css({ "visibility": "hidden" });
                            $("#right_icon_password").css({ "display": "block" });
                        } else {
                            $("#right_icon_password").css({ "display": "none" });
                            $("#tips_password_msg").html("密码由6-12位的数字或字母组成，不区分大小写");
                            $("#tips_password").css({ "visibility": "visible" }).fadeOut(500).fadeIn(200);
                        }
                    } else {
                        $("#tips_password").css({ "visibility": "hidden" });
                        $("#right_icon_password").css({ "display": "none" });
                    }
                    break;
                case "user_password_comfirm":
                    if (obj.attr("value") != "") {
                        if ($("#reg input[name='user_password']").attr("value") != obj.attr("value")) {
                            $("#right_icon_password_comfirm").css({ "display": "none" });
                            $("#tips_password_comfirm_msg").html("两次输入的密码不一致");
                            $("#tips_password_comfirm").css({ "visibility": "visible" }).fadeOut(500).fadeIn(200);
                        } else {
                            $("#tips_password_comfirm").css({ "visibility": "hidden" });
                            $("#right_icon_password_comfirm").css({ "display": "block" });
                        }
                    } else {
                        $("#tips_password_comfirm").css({ "visibility": "hidden" });
                        $("#right_icon_password_comfirm").css({ "display": "none" });
                    }
                    break;
                case "user_company":
                    if (obj.attr("value") != "") {
                        if (validate_company_name(obj.attr("value"))) {
                            $("#tips_company").css({ "visibility": "hidden" });
                            $("#right_icon_company").css({ "display": "block" });
                        } else {
                            $("#right_icon_company").css({ "display": "none" });
                            $("#tips_company_msg").html("企业名称由4-32位的字母、数字或汉字组成");
                            $("#tips_company").css({ "visibility": "visible" }).fadeOut(500).fadeIn(200);
                        }
                    } else {
                        $("#tips_company").css({ "visibility": "hidden" });
                        $("#right_icon_company").css({ "display": "none" });
                    }
                    break;
                case "user_signature":
                    if (obj.attr("value") != "") {
                        if (validate_signature(obj.attr("value"))) {
                            $("#tips_signature").css({ "visibility": "hidden" });
                            $("#right_icon_signature").css({ "display": "block" });
                        } else {
                            $("#right_icon_signature").css({ "display": "none" });
                            $("#tips_signature_msg").html("由数字、字母或汉字组成，限定32个字符以内");
                            $("#tips_signature").css({ "visibility": "visible" }).fadeOut(500).fadeIn(200);
                        }
                    } else {
                        $("#tips_signature").css({ "visibility": "hidden" });
                        $("#right_icon_signature").css({ "display": "none" });
                    }
                    break;
                case "user_fixed_tel":
                    if (obj.attr("value") != "") {
                        if (validate_fixed_tel(obj.attr("value"))) {
                            $("#tips_fixed_tel").css({ "visibility": "hidden" });
                            $("#right_icon_fixed_tel").css({ "display": "block" });
                        } else {
                            $("#right_icon_fixed_tel").css({ "display": "none" });
                            $("#tips_fixed_tel_msg").html('请输入正确的电话号码，中间用"-"分隔');
                            $("#tips_fixed_tel").css({ "visibility": "visible" }).fadeOut(500).fadeIn(200);
                        }
                    } else {
                        $("#tips_fixed_tel").css({ "visibility": "hidden" });
                        $("#right_icon_fixed_tel").css({ "display": "none" });
                    }
                    break;
                case "user_mobile_tel":
                    if (obj.attr("value") != "") {
                        if (validate_mobile_tel(obj.attr("value"))) {
                            $("#tips_mobile_tel").css({ "visibility": "hidden" });
                            $("#right_icon_mobile_tel").css({ "display": "block" });
                        } else {
                            $("#right_icon_mobile_tel").css({ "display": "none" });
                            $("#tips_mobile_tel_msg").html('请输入正确的电话号码');
                            $("#tips_mobile_tel").css({ "visibility": "visible" }).fadeOut(500).fadeIn(200);
                        }
                    } else {
                        $("#tips_mobile_tel").css({ "visibility": "hidden" });
                        $("#right_icon_mobile_tel").css({ "display": "none" });
                    }
                    break;
                case "user_email":
                    if (obj.attr("value") != "") {
                        if (validate_email(obj.attr("value"))) {
                            $("#tips_email").css({ "visibility": "hidden" });
                            $("#right_icon_email").css({ "display": "block" });
                        } else {
                            $("#right_icon_email").css({ "display": "none" });
                            $("#tips_email_msg").html('请输入正确的邮箱');
                            $("#tips_email").css({ "visibility": "visible" }).fadeOut(500).fadeIn(200);
                        }
                    } else {
                        $("#tips_email").css({ "visibility": "hidden" });
                        $("#right_icon_email").css({ "display": "none" });
                    }
                    break;
            }
        }
    });
});
function check_form() {
    if ($("#reg input[name='user_account']").attr("value") == "" || validate_account($("#reg input[name='user_account']").attr("value")) == false) {
        $("#mask_layer").mask_layer('{"opacity":"0.5","color":"#fff","z_index":"550"}');
        $("#pop_layer").pop_layer('{"title":"帐号错误","content":"请输入正确的帐号","z_index":"666"}');
        return false;
    }
    if ($("#reg input[name='user_password']").attr("value") == "" || validate_password($("#reg input[name='user_password']").attr("value")) == false) {
        $("#mask_layer").mask_layer('{"opacity":"0.5","color":"#fff","z_index":"550"}');
        $("#pop_layer").pop_layer('{"title":"密码错误","content":"请输入正确的密码","z_index":"666"}');
        return false;
    }
    if ($("#reg input[name='user_password']").attr("value") != $("#reg input[name='user_password_comfirm']").attr("value")) {
        $("#mask_layer").mask_layer('{"opacity":"0.5","color":"#fff","z_index":"550"}');
        $("#pop_layer").pop_layer('{"title":"密码错误","content":"两次输入的密码不一致","z_index":"666"}');
        return false;
    }
    if ($("#reg input[name='user_email']").attr("value") != "") {
        if (validate_email($("#reg input[name='user_email']").attr("value")) == false) {
            $("#mask_layer").mask_layer('{"opacity":"0.5","color":"#fff","z_index":"550"}');
            $("#pop_layer").pop_layer('{"title":"邮箱错误","content":"请输入正确的邮箱","z_index":"666"}');
            return false;
        }
    }
    if ($("#reg input[name='user_company']").attr("value") != "") {
        if (validate_company_name($("#reg input[name='user_company']").attr("value")) == false) {
            $("#mask_layer").mask_layer('{"opacity":"0.5","color":"#fff","z_index":"550"}');
            $("#pop_layer").pop_layer('{"title":"公司名称错误","content":"请输入正确的公司名称","z_index":"666"}');
            return false;
        }
    }
    if ($("#reg input[name='user_signature']").attr("value") != "") {
        if (validate_signature($("#reg input[name='user_signature']").attr("value")) == false) {
            $("#mask_layer").mask_layer('{"opacity":"0.5","color":"#fff","z_index":"550"}');
            $("#pop_layer").pop_layer('{"title":"企业签名错误","content":"请输入正确的企业签名","z_index":"666"}');
            return false;
        }
    }
    if ($("#reg input[name='user_fixed_tel']").attr("value") != "") {
        if (validate_fixed_tel($("#reg input[name='user_fixed_tel']").attr("value")) == false) {
            $("#mask_layer").mask_layer('{"opacity":"0.5","color":"#fff","z_index":"550"}');
            $("#pop_layer").pop_layer('{"title":"固定电话号码错误","content":"请输入正确的固定电话","z_index":"666"}');
            return false;
        }
    }
    if ($("#reg input[name='user_mobile_tel']").attr("value") != "") {
        if (validate_mobile_tel($("#reg input[name='user_mobile_tel']").attr("value")) == false) {
            $("#mask_layer").mask_layer('{"opacity":"0.5","color":"#fff","z_index":"550"}');
            $("#pop_layer").pop_layer('{"title":"移动电话号码错误","content":"请输入正确的移动电话","z_index":"666"}');
            return false;
        }
    }
    if ($("#reg input[type='checkbox']").attr("checked") != "checked") {
        $("#mask_layer").mask_layer('{"opacity":"0.5","color":"#fff","z_index":"550"}');
        $("#pop_layer").pop_layer('{"title":"提示","content":"请认真阅读许可协议并打勾","z_index":"666"}');
        return false;
    }
    $("#mask_layer").mask_layer('{"opacity":"0.5","color":"#fff","z_index":"550"}');
    $("#pop_layer").pop_layer('{"title":"提示","content":"正在处理数据，请等待...","z_index":"666","close_btn":"true","close_icon":"true","tip_icon":"wait"}');
    $.post("/ashx/Register.ashx",
		{
		    user_account: $("#reg input[name='user_account']").attr("value"),
		    user_password: $("#reg input[name='user_password']").attr("value"),
		    user_email: $("#reg input[name='user_email']").attr("value"),
		    user_company_name: $("#reg input[name='user_company']").attr("value"),
		    user_signature: $("#reg input[name='user_signature']").attr("value"),
		    user_fixed_tel: $("#reg input[name='user_fixed_tel']").attr("value"),
		    user_mobile_tel: $("#reg input[name='user_mobile_tel']").attr("value"),
		    txt_Validate: $("#reg input[name='txt_Validate']").attr("value")
		},
		function (data) {
		    mask_set_none();
		    $("#mask_layer").mask_layer('{"opacity":"0.5","color":"#fff","z_index":"550"}');
		    $("#pop_layer").pop_layer('{"title":"提示","content":"' + data + '","z_index":"666","tip_icon":"right"}');

		}
	);
    return false;
}