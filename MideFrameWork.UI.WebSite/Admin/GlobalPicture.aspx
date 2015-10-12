
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GlobalPicture.aspx.cs" Inherits="MideFrameWork.UI.WebSite.Admin.GlobalPictureList" %>

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
            manage.messagebox({ title: '图片轮播管理', width: '600px', height: '350px', boxID: 'dialog-addConntact', showborder: true, showbg: true, fixed: true, content: 'iframe:/Admin/GlobalPicture.Edit.aspx' });
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
        <asp:Repeater ID="GlobalPictureRepeat" runat="server">
            <HeaderTemplate>
                <tr>
                    <th>
                        <input type="checkbox" id="chkAll" onclick="javascript:return SelectAll(this.checked,this.id);">全选
                    </th>
                                        <th>
                        ID
                    </th>
                                        <th>
                        中文标题
                    </th>
                                        <th>
                        英文标题
                    </th>
                                        <th>
                        图标路径
                    </th>
                                        <th>
                        连接地址
                    </th>
                                        <th>
                        是否启用
                    </th>
                                        <th>
                        显示顺序
                    </th>
                                        <th>
                        所属组ID
                    </th>
                                        <th>
                        所属者ID
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
                        <%#Eval("ShowTextCN")%>
                    </td>
                                        <td>
                        <%#Eval("ShowTextEN")%>
                    </td>
                                        <td>
                        <%#Eval("IconUrl")%>
                    </td>
                                        <td>
                        <%#Eval("LinkUrl")%>
                    </td>
                                        <td>
                        <%#Eval("IsEnable")%>
                    </td>
                                        <td>
                        <%#Eval("DisplayIndex")%>
                    </td>
                                        <td>
                        <%#Eval("GroupID")%>
                    </td>
                                        <td>
                        <%#Eval("OwnerID")%>
                    </td>
                                        <td>
                        <%#Eval("CreateDate")%>
                    </td>
                                        <td>
                        <%#Eval("UpdateDate")%>
                    </td>
                    
                    <td>
                        <a href="javascript:void(0);" id="test" onclick="aa({ title: '图片轮播管理', width: '600px', height: '350px', boxID: 'dialog-addConntact', showborder: true, showbg: true, fixed: true, content: 'iframe:/Admin/GlobalPicture.Edit.aspx?ctrID=<%#Eval("ID") %>' })">
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