<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SelezioneRete.aspx.cs" Inherits="Holonet3.SelezioneRete" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="<%# ResolveUrl("~/") %>Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="<%# ResolveUrl("~/") %>Scripts/jQueryExtensions.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
        $(document).ready(function () {
            debugger;
            var myDiv = $('#centralBox');
            myDiv.center(true);
            alert(myDiv.css('position'));
            alert(myDiv.css('top'));
            alert(myDiv.css('left'));
        });
    </script>
</head>
<body>

    <form id="form1" runat="server">
            <div id="centralBox" style="display:inline-block">
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        </div>
    </form>
</body>
</html>
