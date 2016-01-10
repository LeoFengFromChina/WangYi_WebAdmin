<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" EnableSessionState="True"
    CodeBehind="Left.aspx.cs" Inherits="MideFrameWork.UI.WebSite.Left" %>

<%@ Register Src="~/UserControl/ucMenu.ascx" TagName="ucMenu" TagPrefix="uc" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="css/styles.css" type="text/css" />
    <link rel="stylesheet" href="css/jquery-tool.css" type="text/css" />
    <script type="text/javascript" src="js/jquery-1.8.2.min.js"></script>
    <script type="text/javascript" src="js/jquery.tools.min.js"></script>
    <script type="text/javascript" src="js/main.js"></script>
    <script type="text/javascript">
        function alertAndgoBack() {
            parent.AlertAndgoBack();
        }
        function showFileUpload() {
            $("#ful_logo").show();
        }
        function hideFileUpload() {
            $("#ful_logo").hide();
        }

    </script>
    <style type="text/css">
        #ful_logo
        {
            display: none;
            z-index: 3;
            position: absolute;
        }
    </style>
</head>
<body runat="server">
    <form runat="server">
    <div id="home_menu">
        <div class="head_pic" onmouseover="showFileUpload();" onmouseout="hideFileUpload();">
            <asp:Image ID="eLogo" ImageUrl="images/head.gif" runat="server" Width="200px" Height="160px" />
            <div id="editHead">
                <asp:FileUpload ID="ful_logo" CssClass="file" runat="server" Width="200px" onchange="javascript:__doPostBack('lbUploadPhoto','')" />
                <div class="eadiBtn">
                    更改头像</div>
                <asp:LinkButton ID="lbUploadPhoto" runat="server" OnClick="lbUploadPhoto_Click"></asp:LinkButton>
            </div>
        </div>
        <div class="userInfo line">
            <div class="userTip line_paddingleft">
                <span>用户:</span><span><asp:Label ID="lbl_UserName" runat="server" Text="User"></asp:Label></span>
            </div>
            <div class="balanceTip line_paddingleft">
                <span>积分:</span><span><asp:Label ID="lbl_Balance" runat="server" Text="0"></asp:Label></span>
            </div>
        </div>
        <div>
            <uc:ucMenu ID="myMenu" runat="server" />
        </div>
    </div>
    </form>
</body>
</html>
