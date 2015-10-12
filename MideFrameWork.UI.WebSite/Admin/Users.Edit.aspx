<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UsersEdit.aspx.cs" Inherits="MideFrameWork.UI.WebSite.Admin.UsersEdit" %>

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
                    子账号：
                </td>
                <td>                    
                                                                       <asp:TextBox id="TextBox_ChildAccount" runat="server" Width="200px"></asp:TextBox>
                               </td>
            </tr>
                      		            <tr>
                <td>
                    企业账号：
                </td>
                <td>                    
                                                                       <asp:TextBox id="TextBox_ParentAccount" runat="server" Width="200px"></asp:TextBox>
                               </td>
            </tr>
                      		            <tr>
                <td>
                    状态(0：正常，1:停用，2：删除)：
                </td>
                <td>                    
                                                                       <asp:TextBox id="TextBox_Status" runat="server" Width="200px"></asp:TextBox>
                               </td>
            </tr>
                      		            <tr>
                <td>
                    分组ID：
                </td>
                <td>                    
                                                                       <asp:TextBox id="TextBox_GroupID" runat="server" Width="200px"></asp:TextBox>
                               </td>
            </tr>
                      		            <tr>
                <td>
                    是否是管理员：
                </td>
                <td>                    
                                                                       <asp:TextBox id="TextBox_IsAdmin" runat="server" Width="200px"></asp:TextBox>
                               </td>
            </tr>
                      		            <tr>
                <td>
                    密码：
                </td>
                <td>                    
                                                                       <asp:TextBox id="TextBox_Password" runat="server" Width="200px"></asp:TextBox>
                               </td>
            </tr>
                      		            <tr>
                <td>
                    企业名称：
                </td>
                <td>                    
                                                                       <asp:TextBox id="TextBox_CorpName" runat="server" Width="200px"></asp:TextBox>
                               </td>
            </tr>
                      		            <tr>
                <td>
                    个人签名：
                </td>
                <td>                    
                                                                       <asp:TextBox id="TextBox_Signature" runat="server" Width="200px"></asp:TextBox>
                               </td>
            </tr>
                      		            <tr>
                <td>
                    通道ID：
                </td>
                <td>                    
                                                                       <asp:TextBox id="TextBox_ChannelID" runat="server" Width="200px"></asp:TextBox>
                               </td>
            </tr>
                      		            <tr>
                <td>
                    余额(默认为0)：
                </td>
                <td>                    
                                                                       <asp:TextBox id="TextBox_Balance" runat="server" Width="200px"></asp:TextBox>
                               </td>
            </tr>
                      		            <tr>
                <td>
                    邮箱：
                </td>
                <td>                    
                                                                       <asp:TextBox id="TextBox_Email" runat="server" Width="200px"></asp:TextBox>
                               </td>
            </tr>
                      		            <tr>
                <td>
                    电话：
                </td>
                <td>                    
                                                                       <asp:TextBox id="TextBox_TelePhone" runat="server" Width="200px"></asp:TextBox>
                               </td>
            </tr>
                      		            <tr>
                <td>
                    手机：
                </td>
                <td>                    
                                                                       <asp:TextBox id="TextBox_MobilePhone" runat="server" Width="200px"></asp:TextBox>
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