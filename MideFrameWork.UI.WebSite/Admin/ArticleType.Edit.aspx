<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ArticleTypeEdit.aspx.cs" Inherits="MideFrameWork.UI.WebSite.Admin.ArticleTypeEdit" %>

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
                    中文名称：
                </td>
                <td>                    
                                                                       <asp:TextBox id="TextBox_TypeNameCN" runat="server" Width="200px"></asp:TextBox>
                               </td>
            </tr>
                      		            <tr>
                <td>
                    英文名称：
                </td>
                <td>                    
                                                                       <asp:TextBox id="TextBox_TypeNameEN" runat="server" Width="200px"></asp:TextBox>
                               </td>
            </tr>
                      		            <tr>
                <td>
                    图标路径：
                </td>
                <td>                    
                                                                       <asp:TextBox id="TextBox_IconUrl" runat="server" Width="200px"></asp:TextBox>
                               </td>
            </tr>
                      		            <tr>
                <td>
                    连接地址：
                </td>
                <td>                    
                                                                       <asp:TextBox id="TextBox_LinkUrl" runat="server" Width="200px"></asp:TextBox>
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
                    父ID：
                </td>
                <td>                    
                                                                       <asp:TextBox id="TextBox_ParentID" runat="server" Width="200px"></asp:TextBox>
                               </td>
            </tr>
                      		            <tr>
                <td>
                    所属用户ID：
                </td>
                <td>                    
                                                                       <asp:TextBox id="TextBox_OwerID" runat="server" Width="200px"></asp:TextBox>
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