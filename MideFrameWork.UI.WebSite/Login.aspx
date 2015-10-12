<%@ Page Language="C#" EnableSessionState="True" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MideFrameWork.UI.WebSite.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function Alert_GoBackIndex(url, msg) {
            alert(msg);
            window.location.href = url;
        }
    </script>
</head>
<body>
    <div style="text-align: center">
        <img alt="" src="images/blue-loading.gif" />
    </div>
    <form id="form1" runat="server">
    </form>
</body>
</html>
