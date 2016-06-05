<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewDitail.aspx.cs" Inherits="MideFrameWork.UI.WebSite.ViewDitail" EnableSessionState="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>修改密码</title>
    <link href="css/reset.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .content {
            margin-left: 10%;
            margin-right: 10%;
            text-align: left;
            margin-top: 20px;
            font-size: 22px;
            margin-bottom:1%;
        }

            .content img {
                margin-top: 10px;
            }

        .Title {
            margin-top: 20px;
            /* margin-right: auto; */
            text-align: center;
            font-size: 28px;
            font-weight: bold;
        }

        .authortime {
            text-align: center;
            margin-top: 16px;
            font-size: 14px;
            color: silver;
        }

        .btn {
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

        window.onload = function () {

            var title = document.getElementById("hf_title").getAttribute("value");

            var author = document.getElementById("hr_authorTime").getAttribute("value");

            var content = document.getElementById("hf_content").getAttribute("value");

            document.getElementById("title").innerHTML = title;

            document.getElementById("authortime").innerHTML = author;

            document.getElementById("content").innerHTML = content;
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField ID="hf_title" runat="server" />
        <div id="title" class="Title"></div>
        <asp:HiddenField ID="hr_authorTime" runat="server" />
        <div id="authortime" class="authortime"></div>
        <asp:HiddenField ID="hf_content" runat="server" />
        <div id="content" class="content"></div>

    </form>
</body>
</html>
