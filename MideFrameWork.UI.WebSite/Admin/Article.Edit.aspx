﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ArticleEdit.aspx.cs" Inherits="MideFrameWork.UI.WebSite.Admin.ArticleEdit" %>

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
                    中文标题：
                </td>
                <td>                    
                                                                       <asp:TextBox id="TextBox_TitleCN" runat="server" Width="200px"></asp:TextBox>
                               </td>
            </tr>
                      		            <tr>
                <td>
                    英文标题：
                </td>
                <td>                    
                                                                       <asp:TextBox id="TextBox_TitleEN" runat="server" Width="200px"></asp:TextBox>
                               </td>
            </tr>
                      		            <tr>
                <td>
                    类别ID：
                </td>
                <td>                    
                                                                       <asp:TextBox id="TextBox_TypeID" runat="server" Width="200px"></asp:TextBox>
                               </td>
            </tr>
                      		            <tr>
                <td>
                    正文：
                </td>
                <td>                    
                                                                       <asp:TextBox id="TextBox_Context" runat="server" Width="200px"></asp:TextBox>
                               </td>
            </tr>
                      		            <tr>
                <td>
                    模板：
                </td>
                <td>                    
                                                                       <asp:TextBox id="TextBox_Template" runat="server" Width="200px"></asp:TextBox>
                               </td>
            </tr>
                      		            <tr>
                <td>
                    图标地址：
                </td>
                <td>                    
                                                                       <asp:TextBox id="TextBox_IconUrl" runat="server" Width="200px"></asp:TextBox>
                               </td>
            </tr>
                      		            <tr>
                <td>
                    附件：
                </td>
                <td>                    
                                                                       <asp:TextBox id="TextBox_Attachment" runat="server" Width="200px"></asp:TextBox>
                               </td>
            </tr>
                      		            <tr>
                <td>
                    是否启用：
                </td>
                <td>                    
                                                                       <asp:TextBox id="TextBox_IsEnable" runat="server" Width="200px"></asp:TextBox>
                               </td>
            </tr>
                      		            <tr>
                <td>
                    显示顺序：
                </td>
                <td>                    
                                                                       <asp:TextBox id="TextBox_DisplayIndex" runat="server" Width="200px"></asp:TextBox>
                               </td>
            </tr>
                      		            <tr>
                <td>
                    所属者ID：
                </td>
                <td>                    
                                                                       <asp:TextBox id="TextBox_OwnerID" runat="server" Width="200px"></asp:TextBox>
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