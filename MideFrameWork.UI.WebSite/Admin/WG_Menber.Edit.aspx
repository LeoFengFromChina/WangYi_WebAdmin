<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WG_Menber.Edit.aspx.cs" Inherits="MideFrameWork.UI.WebSite.Admin.WG_MenberEdit" %>

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
                    <td>昵称：
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox_NickName" runat="server" Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>账号：
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox_Name" runat="server" ReadOnly="true" Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>密码：
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox_Psw" runat="server" Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>积分：
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox_Scores" runat="server" Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>性别：
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox_Sex" runat="server" Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>出身年月：
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox_Birthday" runat="server" Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>邮箱：
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox_Email" runat="server" Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>会员标识[游客，求助者，自愿者]：
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox_Flag" runat="server" Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>头像地址：
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox_PhotoUrl" runat="server" Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>国家：
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox_Country" runat="server" Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>省份：
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox_Province" runat="server" Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>市：
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox_City" runat="server" Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>区：
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox_District" runat="server" Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>镇：
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox_Town" runat="server" Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>社区/小区：
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox_Community" runat="server" Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>联系电话：
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox_Phone" runat="server" Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>微信号：
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox_WeChat" runat="server" Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>QQ号：
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox_QQ" runat="server" Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>身份证：
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox_PersonalID" runat="server" Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>联系地址：
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox_Address" runat="server" Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>学历：
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox_Education" runat="server" Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>专业：
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox_Major" runat="server" Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>擅长技能：
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox_SpecialSkill" runat="server" Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>服务意向：
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox_ServiceIntention" runat="server" Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>服务时段：
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox_ServiceTimeInterval" runat="server" Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>服务总时长：
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox_ServiceHours" runat="server" Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>当前状态：
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox_Status" runat="server" Width="200px"></asp:TextBox>
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
