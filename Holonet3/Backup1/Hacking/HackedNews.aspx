<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HackedNews.aspx.cs" Inherits="Holonet3.Hacking.HackedNews" %>
<%@ Register Src="~/Hacking/TentativoHacking.ascx" TagPrefix="Holonet" TagName="Hacking" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <table  width="100%">
        <tr>
            <td align="center">
                [ <a href="~/Hacking/HackedAccount.aspx" ID="backLink" runat="server">Torna all'elenco dei contenuti</a> ]
            </td>
        </tr>
        <tr>
            <td>
                <h2>
                    Notizie disponibili a <asp:Label ID="lblNomeProprietario" runat="server"></asp:Label>
                </h2>
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:LinkButton ID="btnReload" runat="server" Text="Ricarica notizie" 
                    onclick="btnReload_Click"></asp:LinkButton>
            </td>
        </tr>
    </table>

    <asp:UpdatePanel ID="panelNotizie" runat="server">
        <ContentTemplate>
            <asp:MultiView ID="pageViews" runat="server">
                <asp:View ID="viewNotizia" runat="server">
                    <div class="scroll-pane">
                        <table id="tblContent" runat="server" width="100%">
                            <tr>
                                <td>
                                    <h3>
                                        <p>
                                            <asp:Label ID="lblTitoloNotizia" runat="server"></asp:Label>
                                        </p>
                                        <h3>
                                        </h3>
                                        <h4>
                                            <p>
                                                <asp:Label ID="lblDataNotizia" runat="server"></asp:Label>
                                                - Inviato da:
                                                <asp:Label ID="lblAutore" runat="server"></asp:Label>
                                            </p>
                                            <h4>
                                            </h4>
                                            <p>
                                                <asp:Label ID="lblTestoNotizia" runat="server"></asp:Label>
                                            </p>
                                            <h4>
                                            </h4>
                                            <h3>
                                            </h3>
                                        </h4>
                                    </h3>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="btnPrecedente" runat="server" onclick="btnPrecedente_Click" Text="Precedente" />
                                    -
                                    <asp:Button ID="btnProssima" runat="server" onclick="btnProssima_Click" Text="Successiva" />
                                    -
                                    <asp:Button ID="btnModifica" runat="server" onclick="btnModifica_Click" Text="Tenta modifica" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </asp:View>
                <asp:View ID="viewHacking" runat="server">
                    <Holonet:Hacking ID="hackControl" runat="server" AccettaSpina="true" ParteDaHackerare="notizia" />
                </asp:View>
                <asp:View ID="viewEditor" runat="server">
                    <div class="scroll-pane">
                        <table width="100%">
                            <tr>
                                <td align="right">
                                    Titolo: <asp:TextBox ID="txtOggetto" runat="server" MaxLength="50" Columns="50"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    Testo:<br />
                                    <asp:TextBox ID="txtTesto" runat="server" TextMode="MultiLine" Rows="25" Columns="50" ></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Button ID="btnInvia" runat="server" Text="Invia Messaggio" 
                                        onclick="btnInvia_Click" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </asp:View>
            </asp:MultiView>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
