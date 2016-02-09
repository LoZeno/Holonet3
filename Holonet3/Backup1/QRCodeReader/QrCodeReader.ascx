<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="QrCodeReader.ascx.cs" Inherits="Holonet3.QRCodeReader.QrCodeReader" %>
<script type="text/javascript">
    (function ($) {
        $('document').ready(function () {
            $('#qrcodebox').WebcamQRCode({
                onQRCodeDecode: function (p_data) {
                    $('#qrcode_result').html(p_data);
                    LaunchPostBack(p_data);
                }
            });

            $('#btn_start').click(function () {
                $('#qrcodebox').WebcamQRCode().start();
            });

//            $('#btn_stop').click(function () {
//                $('#qrcodebox').WebcamQRCode().stop();
//            });
        });
    })(jQuery);
</script>
<div style="width: 350px; height: 350px; margin: 0 auto;" id="qrcodebox">
</div>
<%--ricordarsi di commentare il seguente bottone quando si va in release!--%>
<input type="button" value="TestPostBack" id="btn_post" onclick="LaunchPostBack('9c57d718-00b6-43de-9696-2a60095d9bd7')" />
<%--<input type="button" value="Start" id="btn_start" /> --%>
<%--<input type="button" value="Stop" id="btn_stop" />--%>
<asp:Button ID="btnForNothing" runat="server" style="display:none" />
<asp:HiddenField ID="hidValue" runat="server" ClientIDMode="Static" />
