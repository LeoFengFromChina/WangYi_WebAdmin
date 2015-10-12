//文档：发送页面JS验证
//说明：主要负责验证发送页面的手机号码、短信内容是否为空；是否包含违法短信；
//           输入字数、短信条数、剩余输入字数的实时提示等；
//作者：fengrd
//时间：2013-6-19 15:45:42

//敏感关键字（后台动态生成所有关键字列表）
var arr = ["杀人", "江泽民", "Fuck", "妓女", "嫖娼", "六合彩", "赌博", "共匪", "达赖", "薄熙来", "发票", "办证", "欧可烨", "冯如德", "测试", "东东"];
$(function () {
    var curObj = document.getElementById("txt_curCount");
    var smsObj = document.getElementById("txt_smsCount");
    var remainObj = document.getElementById("txt_remainCount");
    var signatureObj = document.getElementById("txt_Sinature");
    var curPhoneCountObj = document.getElementById("over_receive");
    var maxPhoneCountObj = document.getElementById("input_receive");

    var singleCount = document.getElementById("txt_singleCount").innerText;
    var totalCount = document.getElementById("txt_totalCount").innerText;

    var phonesStr;
    var phoneArray;
    var phonestrNon;
    function validatePhones() {
        phonesStr = $("#txt_Phones").val();
        phonesStr = phonesStr.replace(/[\r\n]/g, "");
        phonesStr = phonesStr.replace(",", ";");
        phonesStr = phonesStr.replace("，", ";");
        phonesStr = phonesStr.replace("；", ";");

        phonestrNon = phonesStr.replace(";", "");

        curPhoneCountObj.innerHTML = parseInt(phonestrNon.length / 11);
        maxPhoneCountObj.innerHTML = 10000 - parseInt(curPhoneCountObj.innerHTML);
        if (phonesStr.length < 11) {
            curPhoneCountObj.innerHTML = 0;
            maxPhoneCountObj.innerHTML = 10000;
        }
    }




    function validateSms() {
        //剩余可输入字数
        if (totalCount - ($("#txt_SmsContent").val().length + $("#txt_Sinature").val().length) < 0) {
            $("#txt_SmsContent").val($("#txt_SmsContent").val().substring(0, totalCount));
        }
        remainObj.innerText = totalCount - ($("#txt_SmsContent").val().length + $("#txt_Sinature").val().length);
        //设置已经输入的字数
        curObj.innerText = ($("#txt_SmsContent").val().length + $("#txt_Sinature").val().length);
        //按多少条短信收费
        smsObj.innerText = (parseInt(($("#txt_SmsContent").val().length + $("#txt_Sinature").val().length) / singleCount)) + (($("#txt_SmsContent").val().length + $("#txt_Sinature").val().length) % singleCount == 0 ? 0 : 1);

    }

    //点击是否定时
    $("#isScheldue").click(function () {
        if ($("#isScheldue").attr("checked") != "checked") {
            $("#txt_SchecldueDate").val("");
            $("#isScheldueSpan").hide();
        }
        else {
            $("#isScheldueSpan").show();
        }
    });

    $("#txt_Phones").keyup(validatePhones);

    $("#txt_SmsContent").keyup(validateSms);

    $("#txt_SmsContent").mouseup(validateSms);

    $("#txt_SmsContent").change(validateSms);

    $("#btn_Send").click(function () {

        if ($("#txt_Phones").val().replace(/[ ]/g, "") == "") {
            alert("手机号不能为空");
            return false;
        }
        if ($("#txt_SmsContent").val().replace(/[ ]/g, "") == "") {
            alert("短信内容不能为空");
            return false;
        }
        if ($("#chb_recieve").attr("checked") != "checked") {
            alert("请认真阅读短信群发服务条款,并打钩！");
            return false;
        }
        for (var i = 0; i < arr.length; i++) {
            if ($("#txt_SmsContent").val().indexOf(arr[i]) >= 0) {
                alert("发现敏感关键字：" + arr[i]);
                return false;
            }
        }
        if ($("#txt_Sinature").val().length <= 0) {
            alert("签名不能为空！"); return false;
        } if ($("#txt_Sinature").val().length > 8) {
            alert("签名字数不能超过8个字符！"); return false;
        }
        var reg = new RegExp("[\u4e00-\u9fa5]");
        if (!$("#txt_Sinature").val().match(reg)) {
            alert("签名必须包含中文！"); return false;
        }

    });

});
