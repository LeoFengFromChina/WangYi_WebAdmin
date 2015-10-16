<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Des.aspx.cs" Inherits="MideFrameWork_AppDataInterface.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="数据"></asp:Label>
        <asp:TextBox ID="txt_data" runat="server"></asp:TextBox><br />
        <asp:Label ID="Label2" runat="server" Text="密文"></asp:Label>
        <asp:TextBox ID="txt_key" runat="server"></asp:TextBox><br />
        <asp:Button ID="Button1" runat="server" Text="加密" OnClick="Button1_Click" />
        <asp:Button
            ID="Button2" runat="server" Text="解密" onclick="Button2_Click" /><br />
        <asp:Label ID="lbl_return" runat="server" Text=""></asp:Label>
    </div>
    </form>
</body>
</html>
