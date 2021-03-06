﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DistrictEdit.aspx.cs" Inherits="MideFrameWork.UI.WebSite.Admin.DistrictEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
    <div>
    <table>
        <tr>
            <td>父ID</td>
            <td>
                <asp:DropDownList ID="DropDownList_ParentID" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>地区名称</td>
            <td>
                <asp:TextBox ID="TextBox_DistrictName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>状态</td>
            <td>
                <asp:DropDownList ID="DropDownList_Status" runat="server">
                </asp:DropDownList>
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
