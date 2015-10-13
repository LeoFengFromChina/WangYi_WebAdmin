<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WG_HelpRequestEdit.aspx.cs" Inherits="MideFrameWork.UI.WebSite.Admin.WG_HelpRequestEdit" %>

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
                    求助标题：
                </td>
                <td>                    
                                                                       <asp:TextBox id="TextBox_Title" runat="server" Width="200px"></asp:TextBox>
                               </td>
            </tr>
                      		            <tr>
                <td>
                    类别（1求助，2帮助）：
                </td>
                <td>                    
                                                                       <asp:TextBox id="TextBox_Type" runat="server" Width="200px"></asp:TextBox>
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
                    联系人：
                </td>
                <td>                    
                                                                       <asp:TextBox id="TextBox_LinkMan" runat="server" Width="200px"></asp:TextBox>
                               </td>
            </tr>
                      		            <tr>
                <td>
                    联系电话：
                </td>
                <td>                    
                                                                       <asp:TextBox id="TextBox_LinkPhone" runat="server" Width="200px"></asp:TextBox>
                               </td>
            </tr>
                      		            <tr>
                <td>
                    求助日期：
                </td>
                <td>                    
                                                                       <asp:TextBox id="TextBox_BeginTime" runat="server" Width="200px"></asp:TextBox>
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
                    服务时段：
                </td>
                <td>                    
                                                                       <asp:TextBox id="TextBox_ServiceIntention" runat="server" Width="200px"></asp:TextBox>
                               </td>
            </tr>
                      		            <tr>
                <td>
                    服务时长：
                </td>
                <td>                    
                                                                       <asp:TextBox id="TextBox_Duration" runat="server" Width="200px"></asp:TextBox>
                               </td>
            </tr>
                      		            <tr>
                <td>
                    服务明细：
                </td>
                <td>                    
                                                                       <asp:TextBox id="TextBox_Detail" runat="server" Width="200px"></asp:TextBox>
                               </td>
            </tr>
                      		            <tr>
                <td>
                    承接者：
                </td>
                <td>                    
                                                                       <asp:TextBox id="TextBox_UnderTakerID" runat="server" Width="200px"></asp:TextBox>
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