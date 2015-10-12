<%@ Control Language="C#" AutoEventWireup="true" EnableViewState="true" CodeBehind="ucQueryHelper2.ascx.cs"
    Inherits="MideFrameWork.UI.WebSite.ucQueryHelper2" %>
<script type="text/javascript" src="../js/calendar.js"></script>
<%--<script type="text/javascript" src="<%=Request.ApplicationPath %>/js/calendar.js"></script>
--%>
<%--<link charset="utf-8" rel="stylesheet" href="../css/reset.css" type="text/css" media="all" />--%>
<link charset="utf-8" rel="stylesheet" href="../searchbar/css/search.css" type="text/css"
    media="all" />
<script type="text/javascript" src="../js/jquery-1.9.1.min.js"></script>
<script type="text/javascript" src="../searchbar/js/search.js"></script>
<script type="text/javascript">
    function setStatus() {
        $("#selectStatus").attr("index", "status");
        $("#selectKeyWord").hide();
        $("#selectStatus").show();
    }
    function setDate() {
        $("#selectStatus").hide();
        $("#selectKeyWord").hide();
        $("#selectDate").show();
    }
</script>
<div id="searchLine" style="float: right;">
    <div id="searchLabel">
        搜索:</div>
    <div id="selectAll" class="widgetSelect">
        <input type="hidden" id="hid_FistSelect" class="hidvalueSave" value="all" title="全部"
            runat="server" />
        <div class="selectTitle" runat="server" enableviewstate="true" id="FistSelect" name="FistSelect"
            value="" index="">
            <%=FirstSelectText%>
        </div>
        <ul class="selectContent fd-hide">
            <asp:Repeater runat="server" ID="rpt_FirstSelect">
                <ItemTemplate>
                    <li><a href="javascript:void(0);" value="<%#Eval("Value")%>" index="<%#Eval("Type")%>">
                        <%#Eval("Text")%></a> </li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </div>
    <div id="selectKeyWord" index="content" class="selectList">
        <span class="inputtext">
            <input name="txtKeyWord" type="text" id="txtKeyWord" runat="server" /></span>
    </div>
    <div id="selectDate" index="date" class="selectList">
        <label>
            从</label>
        <span class="inputtext">
            <input name="datetxt1" type="text" id="datetxt1" runat="server" clientidmode="Static" />
        </span>
        <label>
            到</label>
        <span class="inputtext">
            <input name="datetxt2" type="text" id="datetxt2" runat="server" clientidmode="Static" /></span>
    </div>
    <div id="selectStatus" class="widgetSelect selectList" index="status">
        <input type="hidden" id="hid_SecondSelect" runat="server" class="hidvalueSave" value="all"
            title="全部" />
        <div class="selectTitle" runat="server" id="SecondSelect" name="SecondSelect" value="">
            <%=SecondSelectText%></div>
        <ul class="selectContent fd-hide">
            <asp:Repeater ID="rpt_SecondSelect" runat="server">
                <ItemTemplate>
                    <li><a href="javascript:void(0);" value="<%#Eval("Value")%>">
                        <%#Eval("Text")%></a> </li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </div>
    <%--    <a href="javascript:void(0);" id="searchBtn" type="submit" class="searchBtn" onclick="<%#Search()%>"
        runat="server">搜索</a>--%>
    <asp:LinkButton ID="searchBtn" runat="server" CssClass="searchBtn" OnClick="btnGo_Click">搜索</asp:LinkButton>
</div>
