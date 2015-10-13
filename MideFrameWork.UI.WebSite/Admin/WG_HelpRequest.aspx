﻿
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WG_HelpRequest.aspx.cs" Inherits="MideFrameWork.UI.WebSite.Admin.WG_HelpRequestList" %>

<%@ Register Src="~/UserControl/ucToolBarButton.ascx" TagName="ucToolBarButton" TagPrefix="uc" %>
<%@ Register Src="~/UserControl/ucPagination.ascx" TagName="ucPagination" TagPrefix="uc" %>
<%@ Register Src="~/UserControl/ucQueryHelper2.ascx" TagName="ucQueryHelper2" TagPrefix="uc" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../static/bootstrap/css/bootstrap.min.css" rel="stylesheet">
    <link href="../css/reset.css" rel="stylesheet" type="text/css" />
    <link href="../static/css/admin.css" rel="stylesheet">
    <script type="text/javascript" src="../js/jquery-1.9.1.min.js"></script>
    <script type="text/javascript">
        var manage = new window.top.Manage();
        function aa(json) {
            manage.messagebox(json);
        }
        $(function () {
            $("th").click(function () {

            });

        });

        function box_create_item() {
            manage.messagebox({ title: '求助表管理', width: '600px', height: '350px', boxID: 'dialog-addConntact', showborder: true, showbg: true, fixed: true, content: 'iframe:/Admin/WG_HelpRequest.Edit.aspx' });
            return false;
        }
    </script>
    <script type="text/javascript">
        //全选		
        function SelectAll(chkVal, idVal) {
            var thisfrm = document.forms[0];

            if (idVal.indexOf('chkAll') != -1) {
                for (i = 0; i < thisfrm.length; i++) {
                    if (thisfrm.elements[i].id.indexOf('chkItem') != -1) {
                        if (chkVal == true) {
                            thisfrm.elements[i].checked = true;
                        }
                        else {
                            thisfrm.elements[i].checked = false;
                        }
                    }
                }
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width: 100%">
        <div style="float: left; height: 50px;">
            <%--<uc:ucToolBarButton ID="myToolBarButton" runat="server" />--%>
            <div class="toolBar">
                <span><a href="javascript:void(0)" onclick="box_create_item()" class="btn btn-sm btn-primary">新增</a>
                    <asp:LinkButton ID="lbt_Delete" runat="server" OnClick="lbt_Delete_Click"  class="btn btn-sm btn-danger">删除</asp:LinkButton>
                    <asp:LinkButton ID="lbt_Refresh" runat="server" OnClick="lbt_Refresh_Click"  class="btn btn-sm btn-info ">刷新</asp:LinkButton>
                </span>
            </div>
        </div>
        <div style="height: 50px;">
            <uc:ucQueryHelper2 ID="myQueryHelper" runat="server" />
        </div>
    </div>
    <table  class="table table-hover table-condensed bordered">
        <asp:Repeater ID="WG_HelpRequestRepeat" runat="server">
            <HeaderTemplate>
                <tr>
                    <th>
                        <input type="checkbox" id="chkAll" onclick="javascript:return SelectAll(this.checked,this.id);">全选
                    </th>
                                        <th>
                        
                    </th>
                                        <th>
                        求助标题
                    </th>
                                        <th>
                        类别（1求助，2帮助）
                    </th>
                                        <th>
                        发起人ID
                    </th>
                                        <th>
                        联系人
                    </th>
                                        <th>
                        联系电话
                    </th>
                                        <th>
                        求助日期
                    </th>
                                        <th>
                        区域ID
                    </th>
                                        <th>
                        服务时段
                    </th>
                                        <th>
                        服务时长
                    </th>
                                        <th>
                        服务明细
                    </th>
                                        <th>
                        承接者
                    </th>
                                        <th>
                        当前状态
                    </th>
                                        <th>
                        创建日期
                    </th>
                                        <th>
                        更新日期
                    </th>
                                        <th>
                        操作
                    </th>
                </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <asp:CheckBox ID="chkItem" runat="server"></asp:CheckBox>
                        <asp:HiddenField ID="hdfID" runat="server" Value='<%# Eval("ID")%>' />
                    </td>

                                        <td>
                        <%#Eval("ID")%>
                    </td>
                                        <td>
                        <%#Eval("Title")%>
                    </td>
                                        <td>
                        <%#Eval("Type")%>
                    </td>
                                        <td>
                        <%#Eval("PromoterID")%>
                    </td>
                                        <td>
                        <%#Eval("LinkMan")%>
                    </td>
                                        <td>
                        <%#Eval("LinkPhone")%>
                    </td>
                                        <td>
                        <%#Eval("BeginTime")%>
                    </td>
                                        <td>
                        <%#Eval("Region")%>
                    </td>
                                        <td>
                        <%#Eval("ServiceIntention")%>
                    </td>
                                        <td>
                        <%#Eval("Duration")%>
                    </td>
                                        <td>
                        <%#Eval("Detail")%>
                    </td>
                                        <td>
                        <%#Eval("UnderTakerID")%>
                    </td>
                                        <td>
                        <%#Eval("Status")%>
                    </td>
                                        <td>
                        <%#Eval("CreateDate")%>
                    </td>
                                        <td>
                        <%#Eval("UpdateDate")%>
                    </td>
                    
                    <td>
                        <a href="javascript:void(0);" id="test" onclick="aa({ title: '求助表管理', width: '600px', height: '350px', boxID: 'dialog-addConntact', showborder: true, showbg: true, fixed: true, content: 'iframe:/Admin/WG_HelpRequest.Edit.aspx?ctrID=<%#Eval("ID") %>' })">
                            编辑</a>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
    <div style="width: 100%">
        <uc:ucPagination ID="myPagination" runat="server" />
    </div>
    </form>
</body>
</html>