<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GetBackPsw.aspx.cs" Inherits="MideFrameWork_AppDataInterface.GetBackPsw1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="输入新密码："></asp:Label><asp:TextBox ID="txt_NewPsw" TextMode="Password" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label2" runat="server" Text="输入新密码："></asp:Label><asp:TextBox ID="txt_Confirm" TextMode="Password" runat="server"></asp:TextBox>
            <asp:Button ID="btn_OK" runat="server" Text="确认" OnClick="btn_OK_Click" /><asp:Label ID="lbl_Hint" runat="server" Text="" ForeColor="Red"></asp:Label>
        </div>
    </form>
</body>
</html>
