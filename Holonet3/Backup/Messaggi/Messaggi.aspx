<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Messaggi.aspx.cs" Inherits="Holonet3.Messaggi.Messaggi" %>
<%@ Register Src="~/Messaggi/MessaggiRicevuti.ascx" TagPrefix="Holonet" TagName="MessaggiRicevuti" %>
<%@ Register Src="~/Messaggi/MessaggiInviati.ascx" TagPrefix="Holonet" TagName="MessaggiInviati" %>
<%@ Register Src="~/Informatica/Criptazione.ascx" TagPrefix="Holonet" TagName="CriptaMessaggio"  %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContent" runat="server">
    <title>Messaggi Personali</title>
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="panelPosta" runat="server">
        <ContentTemplate>
            <table width="100%">
                <tr class="menu">
                    <td align="center" style="width: 25%;">
                        <h2>
                            Messaggi
                        </h2>
                    </td>
                    <td align="center" style="width: 25%;">
                        <asp:LinkButton ID="lnkEditor" runat="server" Text="Nuovo Messaggio" 
                            onclick="lnkEditor_Click"></asp:LinkButton>
                    </td>
                    <td align="center" style="width: 25%;">
                        <asp:LinkButton ID="lnkInArrivo" runat="server" Text="Messaggi In Arrivo" 
                            onclick="lnkInArrivo_Click"></asp:LinkButton>
                    </td>
                    <td align="center" style="width: 25%;">
                        <asp:LinkButton ID="lnkInviati" runat="server" Text="Messaggi Inviati" 
                            onclick="lnkInviati_Click"></asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td valign="top" colspan="2" style="width: 50%">
                        <table style="width: 100%; vertical-align: text-top;">
                            <tr>
                                <td>
                                    <Holonet:MessaggiRicevuti ID="listaMessaggiRicevuti" runat="server" Visible="false" />
                                    <Holonet:MessaggiInviati ID="listaMessaggiInviati" runat="server" Visible="false" />
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td valign="top" colspan="2">
                        <asp:Panel ID="panMessage" runat="server" Visible="false" Width="100%">
                            <h3>
                                <asp:Label ID="lblMittente" runat="server"></asp:Label>
                            </h3>
                            <h2>
                                Oggetto: <asp:Label ID="lblTitolo" runat="server"></asp:Label>
                            </h2>
                            <asp:Label ID="lblTesto" runat="server"></asp:Label>
                            <hr />
                            <asp:Button ID="btnSalva" runat="server" Text="Salva Messaggio" 
                                onclick="btnSalva_Click" /> - <asp:Button ID="btnCancella" runat="server" 
                                Text="Elimina Messaggio" onclick="btnCancella_Click" />
                        </asp:Panel>
                        <asp:Panel ID="panSalvato" runat="server" Visible="false" Width="100%">
                            <h2>
                                Messaggio "<asp:Label ID="lblTitoloSalvato" runat="server" Font-Bold="true"></asp:Label>" salvato con successo.
                            </h2>
                        </asp:Panel>
                        <asp:Panel ID="panCancellato" runat="server" Visible="false" Width="100%">
                            <h2>
                                Messaggio "<asp:Label ID="lblTitoloCancellato" runat="server" Font-Bold="true"></asp:Label>" cancellato con successo.
                            </h2>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
            <asp:Panel ID="panSendMessage" Visible="false" runat="server" Width="100%">
                <table width="100%">
                    <thead>
                        <tr>
                            <td colspan="2">
                                Invia nuovo messaggio
                            </td>
                        </tr>
                    </thead>
                    <tr>
                        <td colspan="2">
                            Destinatari: <asp:TextBox ID="txtDestinatari" runat="server" MaxLength="100" Columns="48"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:DropDownList ID="cmbNomiSalvati" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td align="left">
                            <asp:Button ID="btnAggiungi" Text="Aggiungi ai destinatari" runat="server" 
                                onclick="btnAggiungi_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            Oggetto: <asp:TextBox ID="txtOggetto" runat="server" MaxLength="50" Columns="50"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            Testo:<br />
                            <asp:TextBox ID="txtTesto" runat="server" TextMode="MultiLine" Rows="30" Columns="50"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Button ID="btnInvia" runat="server" Text="Invia Messaggio" 
                                onclick="btnInvia_Click" />
                        </td>
                    </tr>
                </table>
                <Holonet:CriptaMessaggio ID="ucCriptazione" runat="server" Visible="true" />
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="progressNotify" runat="server" AssociatedUpdatePanelID="panelPosta">
        <ProgressTemplate>
            ELABORAZIONE IN CORSO, ATTENDERE....
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>
