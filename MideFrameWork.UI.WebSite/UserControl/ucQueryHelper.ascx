<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucQueryHelper.ascx.cs"
    Inherits="MideFrameWork.UI.WebSite.ucQueryHelper" %>
<script type="text/javascript" src="../js/calendar.js"></script>
<%--<script type="text/javascript" src="<%=Request.ApplicationPath %>/js/calendar.js"></script>
--%>
<div style="text-align: right;">
    <asp:CompareValidator ID="DateValidator1" runat="server" ControlToCompare="txtCalendarFrom"
        ControlToValidate="txtCalendarTo" ForeColor="Red" ErrorMessage="结束日期小于开始日期" Operator="GreaterThanEqual"
        Type="Date" Width="196px" Display="Dynamic"></asp:CompareValidator>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtKeyWord"
        runat="server" ForeColor="Red" ValidationExpression="^[\u4e00-\u9fa50-9a-zA-Z]{0,}$"
        ErrorMessage="输入内容格式不正确!"></asp:RegularExpressionValidator>
    搜索：
    <%--    <asp:DropDownList ID="ddlSort" onchange="KeySelect(this)" AutoPostBack="true" runat="server">--%>
    <asp:DropDownList ID="ddlSort" onchange="change()" runat="server">
        <asp:ListItem Value="全部" Selected="True">全部</asp:ListItem>
        <asp:ListItem Value="Name">名称</asp:ListItem>
        <asp:ListItem Value="CreatedTime">创建时间</asp:ListItem>
    </asp:DropDownList>
    <asp:TextBox ID="txtKeyWord" runat="server" Width="80px"></asp:TextBox><span id="txtCalendar"
        runat="server"><asp:Label ID="lbl_From" runat="server" Text="从"></asp:Label><asp:TextBox
            name="txtCalendarFrom" ID="txtCalendarFrom" runat="server" Width="80px"></asp:TextBox><asp:Label
                ID="lbl_To" runat="server" Text="至"></asp:Label><asp:TextBox name="txtCalendarTo"
                    ID="txtCalendarTo" runat="server" Width="80px"></asp:TextBox></span>
    <asp:DropDownList ID="dllStatus" runat="server">
    </asp:DropDownList>
    <asp:ImageButton ID="imgbtn_Search" runat="server" OnClick="btnGo_Click" ImageAlign="AbsMiddle"
        ImageUrl="~/images/Query/btnGo01.gif" />
</div>
