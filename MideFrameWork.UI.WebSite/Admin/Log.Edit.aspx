<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogEdit.aspx.cs" Inherits="MideFrameWork.UI.WebSite.Admin.LogEdit" %>

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
                    模块名称(触发页面名称)：
                </td>
                <td>                    
                                                                       <asp:TextBox id="TextBox_ModuleName" runat="server" Width="200px"></asp:TextBox>
                               </td>
            </tr>
                      		            <tr>
                <td>
                    操作名称：
                </td>
                <td>                    
                                                                       <asp:TextBox id="TextBox_Operation" runat="server" Width="200px"></asp:TextBox>
                               </td>
            </tr>
                      		            <tr>
                <td>
                    日志正文：
                </td>
                <td>                    
                                                                       <asp:TextBox id="TextBox_LogContent" runat="server" Width="200px"></asp:TextBox>
                               </td>
            </tr>
                      		            <tr>
                <td>
                    日志类型：
                </td>
                <td>                    
                                                                       <asp:TextBox id="TextBox_LogType" runat="server" Width="200px"></asp:TextBox>
                               </td>
            </tr>
                      		            <tr>
                <td>
                    用户ID：
                </td>
                <td>                    
                                                                       <asp:TextBox id="TextBox_FromUserID" runat="server" Width="200px"></asp:TextBox>
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