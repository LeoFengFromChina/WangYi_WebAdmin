<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserEdit.aspx.cs" Inherits="MideFrameWork.UI.WebSite.Admin.UserEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<script type="text/javascript" src="../js/calendar.js"></script>
    <title></title>
    <style type="text/css">
        table
        {
            width: 100%;
            padding: 0px;
            margin: 0px;
            border-collapse: collapse;
        }
        td
        {
            border: 1px solid #C1DAD7;
            background: #fff;
            font-size: 11px;
            padding: 6px 6px 6px 12px;
            color: #4f6b72;
            text-align: center;
        }
        th
        {
            background: #F5FAFA;
            color: #797268;
            text-align: center;
            padding: 6px 6px 6px 12px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="padding-bottom:200px;">
        <table>
            <tr>
                <td>
                    子帐号：
                </td>
                <td>
                    <asp:TextBox ID="TextBox_ChildAccount" runat="server"></asp:TextBox>*
                </td>
            </tr>
            <tr>
                <td>
                    企业帐号：
                </td>
                <td>
                    <asp:TextBox ID="TextBox_ParentAccount" runat="server"></asp:TextBox>*
                </td>
            </tr>
            <tr>
                <td>
                    状态：
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList_Status" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    组ID：
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList_GroupID" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    是否为企业管理员：
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList_IsAdmin" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    密码：
                </td>
                <td>
                    <asp:TextBox ID="TextBox_Password" runat="server"></asp:TextBox>*
                </td>
            </tr>
            <tr>
                <td>
                    企业名称：
                </td>
                <td>
                    <asp:TextBox ID="TextBox_CorpName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    企业签名：
                </td>
                <td>
                    <asp:TextBox ID="TextBox_Signature" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    通道ID：
                </td>
                <td>
                    <asp:TextBox ID="TextBox_ChannelID" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    余额：
                </td>
                <td>
                    <asp:TextBox ID="TextBox_Balance" runat="server"></asp:TextBox>*
                </td>
            </tr>
            <tr>
                <td>
                    邮箱：
                </td>
                <td>
                    <asp:TextBox ID="TextBox_Email" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    固定电话：
                </td>
                <td>
                    <asp:TextBox ID="TextBox_TelePhone" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    移动电话：
                </td>
                <td>
                    <asp:TextBox ID="TextBox_MobilePhone" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    创建时间：
                </td>
                <td>
                    <asp:TextBox ID="TextBox_CreateDate" runat="server"></asp:TextBox>*
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <asp:Button ID="Button_submit" runat="server" Text="确定" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
