<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucPagination.ascx.cs"
    Inherits="MideFrameWork.UI.WebSite.ucPagination" %>
<div style="text-align: center;">
    <asp:ImageButton ID="imgbtn_FirstPage" runat="server" OnClick="imgbtn_FirstPage_Click"
        ImageUrl="~/images/Pagination/page-first.gif" ImageAlign="AbsMiddle" />
    <asp:ImageButton ID="imgbtn_FrontPage" runat="server" OnClick="imgbtn_FirstPage_Click"
        ImageUrl="~/images/Pagination/page-prev.gif" ImageAlign="AbsMiddle" />&nbsp;每页
    <asp:DropDownList ID="ddl_PageSize" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_PageSize_SelectedIndexChanged">
        <asp:ListItem>10</asp:ListItem>
        <asp:ListItem>20</asp:ListItem>
        <asp:ListItem>40</asp:ListItem>
        <asp:ListItem>50</asp:ListItem>
        <asp:ListItem>100</asp:ListItem>
    </asp:DropDownList>
    条 | 当前
    <asp:Label ID="lbl_CurrentPageIndex" runat="server" Text="1" ForeColor="Blue"></asp:Label>/<asp:Label
        ID="lbl_TotalPage" runat="server" Text="  1 "></asp:Label>页 | 共<asp:Label ID="lbl_TotalRecord"
            runat="server" Text="0 "></asp:Label>条
    <asp:ImageButton ID="imgbtn_NextPage" runat="server" OnClick="imgbtn_FirstPage_Click"
        ImageUrl="~/images/Pagination/page-next.gif" ImageAlign="AbsMiddle" />
    <asp:ImageButton ID="imgbtn_FinalPage" runat="server" OnClick="imgbtn_FirstPage_Click"
        ImageUrl="~/images/Pagination/page-last.gif" ImageAlign="AbsMiddle" />
</div>
