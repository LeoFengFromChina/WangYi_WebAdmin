﻿    <script type="text/javascript">
        function box_create_item() {
            manage.messagebox({ title: '团队表管理', width: '600px', height: '350px', boxID: 'dialog-addConntact', showborder: true, showbg: true, fixed: true, content: 'iframe:About.aspx' });
            return false;
        }
    </script>
<%@ Page Title="主页" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="WebTest._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        欢迎使用 ASP.NET!
    </h2>
    <p>
        若要了解关于 ASP.NET 的详细信息，请访问 <a href="http://www.asp.net/cn" title="ASP.NET 网站">www.asp.net/cn</a>。
     
        <asp:LinkButton ID="LinkButton1" runat="server" OnClientClick="box_create_item" onclick="LinkButton1_Click" >LinkButton</asp:LinkButton>
    </p>
    <p>
        您还可以找到 <a href="http://go.microsoft.com/fwlink/?LinkID=152368"
            title="MSDN ASP.NET 文档">MSDN 上有关 ASP.NET 的文档</a>。
    </p>
</asp:Content>
