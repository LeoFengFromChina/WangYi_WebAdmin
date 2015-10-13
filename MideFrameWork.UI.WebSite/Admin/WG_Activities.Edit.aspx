<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WG_ActivitiesEdit.aspx.cs" Inherits="MideFrameWork.UI.WebSite.Admin.WG_ActivitiesEdit" %>

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
                    活动标题：
                </td>
                <td>                    
                                                                       <asp:TextBox id="TextBox_Title" runat="server" Width="200px"></asp:TextBox>
                               </td>
            </tr>
                      		            <tr>
                <td>
                    发起人ID：
                </td>
                <td>                    
                                                                       <asp:TextBox id="TextBox_PromoterID" runat="server" Width="200px"></asp:TextBox>
                               </td>
            </tr>
                      		            <tr>
                <td>
                    联系人ID：
                </td>
                <td>                    
                                                                       <asp:TextBox id="TextBox_LinkMan" runat="server" Width="200px"></asp:TextBox>
                               </td>
            </tr>
                      		            <tr>
                <td>
                    LinkPhone：
                </td>
                <td>                    
                                                                       <asp:TextBox id="TextBox_LinkPhone" runat="server" Width="200px"></asp:TextBox>
                               </td>
            </tr>
                      		            <tr>
                <td>
                    活动类型ID：
                </td>
                <td>                    
                                                                       <asp:TextBox id="TextBox_ActivityType" runat="server" Width="200px"></asp:TextBox>
                               </td>
            </tr>
                      		            <tr>
                <td>
                    区域ID：
                </td>
                <td>                    
                                                                       <asp:TextBox id="TextBox_Region" runat="server" Width="200px"></asp:TextBox>
                               </td>
            </tr>
                      		            <tr>
                <td>
                    联系地址：
                </td>
                <td>                    
                                                                       <asp:TextBox id="TextBox_Address" runat="server" Width="200px"></asp:TextBox>
                               </td>
            </tr>
                      		            <tr>
                <td>
                    人员数量：
                </td>
                <td>                    
                                                                       <asp:TextBox id="TextBox_NeedMenberCount" runat="server" Width="200px"></asp:TextBox>
                               </td>
            </tr>
                      		            <tr>
                <td>
                    活动日期：
                </td>
                <td>                    
                                                                       <asp:TextBox id="TextBox_BeginTime" runat="server" Width="200px"></asp:TextBox>
                               </td>
            </tr>
                      		            <tr>
                <td>
                    活动明细：
                </td>
                <td>                    
                                                                       <asp:TextBox id="TextBox_Detail" runat="server" Width="200px"></asp:TextBox>
                               </td>
            </tr>
                      		            <tr>
                <td>
                    当前状态：
                </td>
                <td>                    
                                                                       <asp:TextBox id="TextBox_Status" runat="server" Width="200px"></asp:TextBox>
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