<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WelcomePage.aspx.cs" Inherits="MideFrameWork.UI.WebSite.WelcomePage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>飞扬短信营销平台-欢迎界面</title>
    <link href="css/reset.css" rel="stylesheet" type="text/css" />
    <link href="css/home_content.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="content_bg">
        <div class="left_cont">
            <div class="salutation">
                <span>晚上好，<a id="lbl_UserName" name="lbl_UserName" href="#"><%=UserName%></a>，</span><span>在忙吗，是否该问候一下远方的朋友？</span>
            </div>
            <div class="tips">
                <span>提示：</span><span class="tips_cont">草稿箱有<a href="#">5</a>条未处理，</span><span class="tips_cont">问候较少的联系人有<a
                    href="#">10</a>个</span>
            </div>
            <div class="msg_box sms_box wrapfix">
                <span class="title">短信管理</span><a href="" class="btn">新增短信</a>
                <div class="msg_cont">
                    <div class="icon">
                    </div>
                    <div class="msg_main">
                        本月已发短信： <a href="#" class=" ">0</a> 次 计费条数： <a href="#" class=" ">0</a> 条<br>
                        草稿箱：共 <a href="#" class=" ">0</a> 条</div>
                </div>
            </div>
            <div class="msg_box contact_box wrapfix">
                <span class="title">联系人管理</span><a href="" class="btn">新建联系人</a>
                <div class="msg_cont">
                    <div class="icon">
                    </div>
                    <div class="msg_main">
                        所有联系人 <a href="#" class=" ">0</a> 人
                        <br>
                        <a href="#" class=" fc_16">导入联系人</a> <a href="#" class="#">导出联系人</a></div>
                </div>
            </div>
            <div class="msg_box account_box wrapfix">
                <span class="title">账户管理</span><a href="" class="btn">立刻充值</a>
                <div class="msg_cont">
                    <div class="icon">
                    </div>
                    <div class="msg_main">
                        所剩短信 <a href="#" class="">
                            <%=SmsCount %></a> 条
                        <br>
                        <span class="">如果余额不足，请尽快充值。</span></div>
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
