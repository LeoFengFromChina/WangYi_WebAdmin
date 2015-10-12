<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucDropDownList.ascx.cs"
    Inherits="MideFrameWork.UI.WebSite.ucDropDownList" %>
<link charset="utf-8" rel="stylesheet" href="../css/reset.css" type="text/css" media="all" />
<link charset="utf-8" rel="stylesheet" href="../searchbar/css/search.css" type="text/css"
    media="all" />
<script type="text/javascript" src="../js/jquery-1.9.1.min.js"></script>
<script type="text/javascript" src="../searchbar/js/search.js"></script>
<div id="searchLine" style="float: right;">
    <div id="selectAll" class="widgetSelect">
        <div class="selectTitle">
            全部
        </div>
        <ul class="selectContent fd-hide">
            <%--        <li><a href="javascript:void(0);" value="all">全部</a> </li>
        <li><a href="javascript:void(0);" value="date">日期</a> </li>
        <li><a href="javascript:void(0);" value="status">状态</a> </li>
        <li><a href="javascript:void(0);" value="content">内容</a> </li>--%>
            <asp:Repeater ID="rpt_DropDownList" runat="server">
                <ItemTemplate>
                    <li><a href="javascript:void(0);" value='<%#Eval("ItemValue") %>'>
                        <%#Eval("ItemText") %></a> </li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </div>
</div>
