<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WG_Menber.aspx.cs" Inherits="MideFrameWork.UI.WebSite.Admin.WG_MenberList" %>

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
            manage.messagebox({ title: '会员表管理', width: '600px', height: '350px', boxID: 'dialog-addConntact', showborder: true, showbg: true, fixed: true, content: 'iframe:/Admin/WG_Menber.Edit.aspx' });
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
                <span><a href="javascript:void(0)" onclick="box_create_item()" class="btn btn-sm btn-primary">
                    新增</a>
                    <asp:LinkButton ID="lbt_Delete" runat="server" OnClick="lbt_Delete_Click" class="btn btn-sm btn-danger">删除</asp:LinkButton>
                    <asp:LinkButton ID="lbt_Refresh" runat="server" OnClick="lbt_Refresh_Click" class="btn btn-sm btn-info ">刷新</asp:LinkButton>
                </span>
            </div>
        </div>
        <div style="height: 50px;">
            <uc:ucQueryHelper2 ID="myQueryHelper" runat="server" />
        </div>
    </div>
    <table class="table table-hover table-condensed bordered">
        <asp:Repeater ID="WG_MenberRepeat" runat="server">
            <HeaderTemplate>
                <tr>
                    <th>
                        <input type="checkbox" id="chkAll" onclick="javascript:return SelectAll(this.checked,this.id);">全选
                    </th>
                    <th>
                        昵称
                    </th>
                    <th>
                        账号
                    </th>
                    <th>
                        性别
                    </th>
                    <th>
                        会员等级
                    </th>
                    <th>
                        服务时长
                    </th>
                    <th>
                        联系电话
                    </th>
                    <th>
                        学历
                    </th>
                    <th>
                        状态
                    </th>
                    <th>
                        创建日期
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
                        <%#Eval("NickName")%>
                    </td>
                    <td>
                        <%#Eval("Name")%>
                    </td>
                    <td>
                        <%#Eval("Sex")%>
                    </td>
                    <td>
                        <%#Eval("Flag").ToString() == "0" ? "游客" : Eval("Flag").ToString() == "1" ? "求助者" :
                        "志愿者"%>
                    </td>
                    <td>
                        <%#Eval("ServiceHours")%> 小时
                    </td>
                    <td>
                        <%#Eval("Phone")%>
                    </td>
                    <td>
                        <%#Eval("Education")%>
                    </td>
                    <td>
                        <%#Eval("Status").ToString() == "0" ? "正常" :Eval("Status").ToString() == "1" && Eval("Flag").ToString()=="1"?"申请成为求助者":Eval("Status").ToString() == "1" && Eval("Flag").ToString()=="2"?"申请成为志愿者":"" %>
                    </td>
                    <td>
                        <%#Eval("CreateDate")%>
                    </td>
                    <td>
                       
                        <a href="javascript:void(0);" id="test3" onclick="aa({ title: '会员管理', width: '600px', height: '350px', boxID: 'dialog-addConntact', showborder: true, showbg: true, fixed: true, content: 'iframe:/Admin/WG_Menber.Edit.aspx?ctrID=<%#Eval("ID") %>' })">
                            编辑</a>
                        <a href="javascript:void(0);" id="test2" onclick="aa({ title: '会员授权', width: '600px', height: '350px', boxID: 'dialog-addConntact', showborder: true, showbg: true, fixed: true, content: 'iframe:/Admin/WG_Menber_Operation.aspx?ctrID=<%#Eval("ID") %>' })">
                            授权</a>
                        <a href="javascript:void(0);" id="test1" onclick="aa({ title: '会员审核', width: '600px', height: '350px', boxID: 'dialog-addConntact', showborder: true, showbg: true, fixed: true, content: 'iframe:/Admin/WG_Menber.Validate.aspx?ctrID=<%#Eval("ID") %>' })"> <%#Eval("Status").ToString() == "0" ? "":"审核"%></a>
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
