<%@ Page EnableEventValidation="false" Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Holonet3.AddOn.QRCodeReader.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="js/jquery.min.js"></script>
    <script type="text/javascript" src="js/jquery.webcamqrcode.min.js"></script>
</head>
<body>
    
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
        </asp:ScriptManager>
    <div>
        <script>
            (function ($) {
                $('document').ready(function () {
                    $('#qrcodebox').WebcamQRCode({
                        onQRCodeDecode: function (p_data) {
                            $('#qrcode_result').html(p_data);
                            //window.location.href = './Default.aspx?uid=' + p_data + "&numpg=" + NumeroPG;
                            //LaunchBack(p_data);
                            LaunchPostBack(p_data);
                        }
                    });

                    $('#btn_start').click(function () {
                        $('#qrcodebox').WebcamQRCode().start();
                    });

                    $('#btn_stop').click(function () {
                        $('#qrcodebox').WebcamQRCode().stop();
                    });
                });
            })(jQuery);
        </script>
        <div style="width: 350px; height: 350px;" id="qrcodebox">
        </div>
<%--        <script language="javascript" type="text/javascript">
            function LaunchBack(p_data) {
                $('#hidValue').val(p_data); //imposto il valore nell'hiddenfield
                __doPostBack('btnForNothing', p_data);
            }
        </script>--%>
        <input type="button" value="Start" id="btn_start" /> 
        <input type="button" value="Stop" id="btn_stop" />

        <input type="button" value="TestPostBack" id="btn_post" onclick="LaunchPostBack('blablabla')" />
         <%--la funzione LaunchPostBack viene generata a runtime dal C# e iniettata in pagina--%>

        Last QRCode value: <span id="qrcode_result" runat="server">none</span>
        <asp:Label runat="server" ID="lblResult"></asp:Label>
        <asp:Button ID="btnForNothing" runat="server" style="display:none" />
        <asp:HiddenField ID="hidValue" runat="server" ClientIDMode="Static" />
    </div>
    </form>
</body>
</html>
