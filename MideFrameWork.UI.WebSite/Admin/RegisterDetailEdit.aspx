<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterDetailEdit.aspx.cs"
    Inherits="MideFrameWork.UI.WebSite.Admin.RegisterDetailEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="../js/calendar.js"></script>
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
    <div>
        <table>
            <tr>
                <td>
                    用户ID
                </td>
                <td>
                    <asp:TextBox ID="TextBox_UserID" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    MAC:
                </td>
                <td>
                    <asp:TextBox ID="TextBox_Mac" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    IP:
                </td>
                <td>
                    <asp:TextBox ID="TextBox_IP" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    CreateDate:
                </td>
                <td>
                    <asp:TextBox ID="TextBox_CreateDate" runat="server"></asp:TextBox>
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
