<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePsw.aspx.cs" Inherits="MideFrameWork.UI.WebSite.ChangePsw" EnableSessionState="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>修改密码</title>
    <link href="css/reset.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .line
        {
            width: 214px;
            margin: 0 auto;
            margin-top: 10px;
            vertical-align: middle;
            line-height: 22px;
        }
        .Title
        {
            float: left;
            height: 20px;
            color: #808080;
            font-size:12px;
            line-height:20px;
        }
        .Psw
        {
            border: 1px solid #6E9FDE;
            height: 20px;
        }
        .btn
        {
            display: block;
            width: 92px;
            height: 26px;
            line-height: 26px;
            text-align: center;
            background: url(../images/cont_images/btn.png) no-repeat;
            color: #334968;
            text-decoration: none;
            font-size: 14px;
            margin: 0 auto;
        }
    </style>
    <script type="text/javascript">
        function CheckTextBox() {
            var txt_CurPsw = document.getElementById("txt_CurPsw").value;
            var txt_NewPsw = document.getElementById("txt_NewPsw").value;
            var txt_ConfirmPsw = document.getElementById("txt_ConfirmPsw").value;
            txt_CurPsw = txt_CurPsw.replace(/^ +/, ''); txt_CurPsw = txt_CurPsw.replace(/ +$/, '');
            txt_NewPsw = txt_NewPsw.replace(/^ +/, ''); txt_NewPsw = txt_NewPsw.replace(/ +$/, '');
            txt_ConfirmPsw = txt_ConfirmPsw.replace(/^ +/, ''); txt_ConfirmPsw = txt_ConfirmPsw.replace(/ +$/, '');
            if (txt_CurPsw == '') {
                alert("当前密码不能为空，请确认!");
                return false;
            }
            else if (txt_NewPsw == '') {
                alert("新设密码不能为空，请确认!");
                return false;
            }
            else if (txt_ConfirmPsw == '') {
                alert("确认密码不能为空，请确认!");
                return false;
            }
            else if (txt_NewPsw != txt_ConfirmPsw) {
                alert("确认密码不相同，请确认!");
                return false;
            }
            else {
                return true;
            }
        }
        function goLogin() {
            parent.goBack("index.html");
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="margin-top: 40px;">
        <div class="line">
            <div class="Title">
                当前密码：</div>
            <div>
                <input type="password" class="Psw" value="飞扬短信平台" id="txt_CurPsw" runat="server" />
            </div>
        </div>
        <div class="line">
            <div class="Title">
                新设密码：</div>
            <div>
                <input type="password" class="Psw" value="飞扬短信平台" id="txt_NewPsw" runat="server" />
            </div>
        </div>
        <div class="line">
            <div class="Title">
                确认密码：</div>
            <div>
                <input type="password" class="Psw" value="飞扬短信平台" id="txt_ConfirmPsw" runat="server" />
            </div>
        </div>
        <div class="line">
            <asp:LinkButton ID="lbt_Submit" CssClass="send_btn btn" runat="server" OnClientClick=" return CheckTextBox();"
                OnClick="lbt_Submit_Click">确认修改</asp:LinkButton></div>
    </div>
    </form>
</body>
</html>
