<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HackedFiles.aspx.cs" Inherits="Holonet3.Hacking.HackedFiles" %>
<%@ Register Src="~/Hacking/TentativoHacking.ascx" TagPrefix="Holonet" TagName="Hacking" %>
<%@ Register Src="~/CartellaPersonale/ListaFiles.ascx" TagPrefix="Holonet" TagName="ListaFiles" %>
<%@ Register Src="~/Informatica/Decriptazione.ascx" TagPrefix="Holonet" TagName="Decrypt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <asp:UpdatePanel ID="panelPosta" runat="server">
        <ContentTemplate>
            <table width="100%">
                <tr>
                    <td align="center" colspan="4">
                        [ <a href="~/Hacking/HackedAccount.aspx" ID="backLink" runat="server">Torna all'elenco dei contenuti</a> ]
                    </td>
                </tr>
                <tr class="menu">
                    <td align="center" colspan="4">
                        <h2>
                            Files personali
                        </h2>
                    </td>
                </tr>
                <tr>
                    <td valign="top" colspan="2" style="width: 50%">
                        <table style="width: 100%; vertical-align: text-top;">
                            <tr>
                                <td>
                                    <Holonet:Listafiles ID="listaFilePersonali" runat="server" Visible="false" />
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td valign="top" colspan="2">
                        <asp:Panel ID="panMessage" runat="server" Visible="false" Width="100%">
                            <h2>
                                Oggetto: <asp:Label ID="lblTitolo" runat="server"></asp:Label>
                            </h2>
                            <asp:Label ID="lblTesto" runat="server"></asp:Label>
                            <hr />
                            <asp:Button ID="btnSalva" runat="server" Text="Salva Messaggio nel tuo account" 
                                onclick="btnSalva_Click" />
                            <Holonet:Decrypt ID="ucDecrypt" runat="server" Visible="true" />
                        </asp:Panel>
                        <asp:Panel ID="panSalvato" runat="server" Visible="false" Width="100%">
                            <h2>
                                Messaggio "<asp:Label ID="lblTitoloSalvato" runat="server" Font-Bold="true"></asp:Label>" salvato con successo.
                            </h2>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
            <Holonet:Hacking ID="ucHacking" runat="server" AccettaSpina="true" ParteDaHackerare="missioni" Visible="false" />
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
