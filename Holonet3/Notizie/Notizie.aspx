<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Notizie.aspx.cs" Inherits="Holonet3.Notizie.Notizie" %>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContent" runat="server">
    <title>Notizie</title>
    <script type="text/javascript" id="sourcecode">
//        function applyScroll() {
//            var myheight = $('#tblContent').height();
//            myheight = (myheight * 70) / 100;
//            myheight = parseInt(myheight);
//            $('.scroll-pane').css('height', myheight + 'px');
//            $('.scroll-pane').jScrollPane({ showArrows: true });
//        }

//        $(function () {
//            applyScroll();
//        });

//        $(window).resize(function(){
//            applyScroll();
//        });
	</script>
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdateProgress ID="progressNotify" runat="server" AssociatedUpdatePanelID="panelNotizie">
        <ProgressTemplate>
            ELABORAZIONE IN CORSO, ATTENDERE...
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="panelNotizie" runat="server">
        <ContentTemplate>
            <div id="tblContent" class="functionContainer" style="width:85%; height:100%; overflow:hidden">
                <div class="functionContent" id="headerNews" style="height:30%">
                    <asp:Image ID="facePicture" runat="server" ClientIDMode="Static" /><br />
                    <asp:Button ID="btnPrecedente" runat="server" onclick="btnPrecedente_Click" Text="Precedente" />
                    -
                    <asp:Button ID="btnProssima" runat="server" onclick="btnProssima_Click" Text="Successiva" />
                </div>
                <div class="functionContent" style="height:30%">
                   <h1>
                        <p>
                            <asp:Label ID="lblDataNotizia" runat="server"></asp:Label>
                            <br />
                            Inviato da:
                            <asp:Label ID="lblAutore" runat="server"></asp:Label>
                        </p>
                    </h1>
                    <h2>
                        <p>
                            <asp:Label ID="lblTitoloNotizia" runat="server"></asp:Label>
                        </p>
                    </h2>
                </div>
                <div class="scroll-pane" style="white-space:normal">
                    <asp:Label ID="lblTestoNotizia" runat="server"></asp:Label>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
