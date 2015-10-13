
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
        <asp:Repeater ID="WG_MenberRepeat" runat="server">
            <HeaderTemplate>
                <tr>
                    <th>
                        <input type="checkbox" id="chkAll" onclick="javascript:return SelectAll(this.checked,this.id);">全选
                    </th>
                                        <th>
                        
                    </th>
                                        <th>
                        昵称
                    </th>
                                        <th>
                        会员名称
                    </th>
                                        <th>
                        密码
                    </th>
                                        <th>
                        
                    </th>
                                        <th>
                        性别
                    </th>
                                        <th>
                        
                    </th>
                                        <th>
                        邮箱
                    </th>
                                        <th>
                        会员标识[游客，求助者，自愿者]
                    </th>
                                        <th>
                        头像地址
                    </th>
                                        <th>
                        国家
                    </th>
                                        <th>
                        省份
                    </th>
                                        <th>
                        市
                    </th>
                                        <th>
                        区
                    </th>
                                        <th>
                        社区/小区
                    </th>
                                        <th>
                        联系电话
                    </th>
                                        <th>
                        微信号
                    </th>
                                        <th>
                        QQ号
                    </th>
                                        <th>
                        身份证
                    </th>
                                        <th>
                        联系地址
                    </th>
                                        <th>
                        学历
                    </th>
                                        <th>
                        专业
                    </th>
                                        <th>
                        擅长技能
                    </th>
                                        <th>
                        服务意向
                    </th>
                                        <th>
                        服务时段
                    </th>
                                        <th>
                        服务总时长
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
                        <%#Eval("NickName")%>
                    </td>
                                        <td>
                        <%#Eval("Name")%>
                    </td>
                                        <td>
                        <%#Eval("Psw")%>
                    </td>
                                        <td>
                        <%#Eval("Scores")%>
                    </td>
                                        <td>
                        <%#Eval("Sex")%>
                    </td>
                                        <td>
                        <%#Eval("Birthday")%>
                    </td>
                                        <td>
                        <%#Eval("Email")%>
                    </td>
                                        <td>
                        <%#Eval("Flag")%>
                    </td>
                                        <td>
                        <%#Eval("PhotoUrl")%>
                    </td>
                                        <td>
                        <%#Eval("Country")%>
                    </td>
                                        <td>
                        <%#Eval("Province")%>
                    </td>
                                        <td>
                        <%#Eval("City")%>
                    </td>
                                        <td>
                        <%#Eval("District")%>
                    </td>
                                        <td>
                        <%#Eval("Community")%>
                    </td>
                                        <td>
                        <%#Eval("Phone")%>
                    </td>
                                        <td>
                        <%#Eval("WeChat")%>
                    </td>
                                        <td>
                        <%#Eval("QQ")%>
                    </td>
                                        <td>
                        <%#Eval("PersonalID")%>
                    </td>
                                        <td>
                        <%#Eval("Address")%>
                    </td>
                                        <td>
                        <%#Eval("Education")%>
                    </td>
                                        <td>
                        <%#Eval("Major")%>
                    </td>
                                        <td>
                        <%#Eval("SpecialSkill")%>
                    </td>
                                        <td>
                        <%#Eval("ServiceIntention")%>
                    </td>
                                        <td>
                        <%#Eval("ServiceTimeInterval")%>
                    </td>
                                        <td>
                        <%#Eval("ServiceHours")%>
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
                        <a href="javascript:void(0);" id="test" onclick="aa({ title: '会员表管理', width: '600px', height: '350px', boxID: 'dialog-addConntact', showborder: true, showbg: true, fixed: true, content: 'iframe:/Admin/WG_Menber.Edit.aspx?ctrID=<%#Eval("ID") %>' })">
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