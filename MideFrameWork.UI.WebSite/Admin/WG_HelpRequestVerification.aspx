<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WG_HelpRequestVerification.aspx.cs" Inherits="MideFrameWork.UI.WebSite.Admin.WG_HelpRequestVerification" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script type="text/javascript" src="../js/calendar.js"></script>
    <title></title>
    <style type="text/css">
        table {
            width: 100%;
            padding: 0px;
            margin: 0px;
            border-collapse: collapse;
        }

        td {
            border: 1px solid #C1DAD7;
            background: #fff;
            font-size: 11px;
            padding: 6px 6px 6px 12px;
            color: #4f6b72;
            text-align: center;
        }

        th {
            background: #F5FAFA;
            color: #797268;
            text-align: center;
            padding: 6px 6px 6px 12px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="padding-bottom: 200px;">
            <table>
                <tr>
                    <td>认证等级：
                    </td>
                    <td>
                        <asp:CheckBox ID="chk_agentVer" runat="server" Text="机构认证"></asp:CheckBox>
                        <asp:CheckBox ID="chk_CommunityVer" runat="server" Text="社区认证"></asp:CheckBox>
                        <asp:CheckBox ID="chk_gorvVer" runat="server" Text="政府认证"></asp:CheckBox>
                    </td>
                </tr>


                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="Button_submit" runat="server" Text="确定" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
