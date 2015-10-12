<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucToolBarButton.ascx.cs"
    Inherits="MideFrameWork.UI.WebSite.ucToolBarButton" %>
<div id="ToolBar">
    <asp:ImageButton ID="imgbtn_Add" ImageUrl="~/images/Query/btnGo01.gif" ImageAlign="AbsMiddle" Visible="true" ToolTip="新增" runat="server" OnClick="imgbtn_Add_Click" />
    <asp:ImageButton ID="imgbtn_Delete" ImageUrl="~/images/Query/btnGo01.gif" ImageAlign="AbsMiddle" Visible="true" ToolTip="删除" runat="server" OnClick="imgbtn_Add_Click" />
    <asp:ImageButton ID="imgbtn_Refresh" ImageUrl="~/images/Query/btnGo01.gif" ImageAlign="AbsMiddle"  Visible="true" ToolTip="刷新" runat="server" OnClick="imgbtn_Add_Click" />
    <asp:ImageButton ID="imgbtn_Update" ImageUrl="~/images/Query/btnGo01.gif" ImageAlign="AbsMiddle"  Visible="false" ToolTip="修改" runat="server" OnClick="imgbtn_Add_Click" />
    <asp:ImageButton ID="imgbtn_Import" ImageUrl="~/images/Query/btnGo01.gif" ImageAlign="AbsMiddle"  Visible="false" ToolTip="导入" runat="server" OnClick="imgbtn_Add_Click" />
    <asp:ImageButton ID="imgbtn_Export" ImageUrl="~/images/Query/btnGo01.gif" ImageAlign="AbsMiddle"  Visible="false" ToolTip="导出" runat="server" OnClick="imgbtn_Add_Click" />
    <asp:ImageButton ID="imgbtn_GoBack" ImageUrl="~/images/Query/btnGo01.gif" ImageAlign="AbsMiddle"  Visible="false" ToolTip="返回" runat="server" OnClick="imgbtn_Add_Click" />
    <asp:ImageButton ID="imgbtn_Ex1" ImageUrl="~/images/Query/btnGo01.gif" ImageAlign="AbsMiddle"  Visible="false" ToolTip="扩展一" runat="server" OnClick="imgbtn_Add_Click" />
    <asp:ImageButton ID="imgbtn_Ex2" ImageUrl="~/images/Query/btnGo01.gif" ImageAlign="AbsMiddle"  Visible="false" ToolTip="扩展二" runat="server" OnClick="imgbtn_Add_Click" />
</div>
