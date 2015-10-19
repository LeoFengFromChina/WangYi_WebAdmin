﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WG_Menber_Operation.aspx.cs" Inherits="MideFrameWork.UI.WebSite.Admin.WG_Menber_Operation" %>

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
                    <td>选择模块：
                    </td>
                    <td>
                        <asp:DropDownList ID="ddl_Module" runat="server"></asp:DropDownList>
                    </td>
                </tr>

                <tr>
                    <td>权限：
                    </td>
                    <td>
                        <asp:Repeater ID="Base_ButtonList" runat="server">

                            <ItemTemplate>
                                <asp:CheckBox ID="chkItem" runat="server"></asp:CheckBox><%#Eval("Memo")%>
                                <asp:HiddenField ID="hdfID" runat="server" Value='<%# Eval("ID")%>' />
                                <br />
                            </ItemTemplate>
                        </asp:Repeater>
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
