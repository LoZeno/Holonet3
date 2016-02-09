<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FilePersonali.aspx.cs" Inherits="Holonet3.CartellaPersonale.FilePersonali" %>
<%@ Register Src="~/CartellaPersonale/ListaFiles.ascx" TagPrefix="Holonet" TagName="Elenco" %>
<%@ Register Src="~/Informatica/Criptazione.ascx" TagPrefix="Holonet" TagName="CryptaFile" %>

<asp:Content ID="ContentHeader" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="ContentBody" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="panelFiles" runat="server">
        <ContentTemplate>
            <table width="100%">
                <thead>
                    <tr>
                        <td colspan="2" align="left">
                            <h3>
                                Files Personali - <asp:Button ID="btnCrea" runat="server" Text="Nuovo File" 
                                    onclick="btnCrea_Click" />
                            </h3>
                        </td>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td valign="top" style="width: 50%">
                            <table style="width: 100%; vertical-align: text-top;">
                                <tr>
                                    <td>
                                        <Holonet:Elenco ID="listaFiles" runat="server" Visible="false"></Holonet:Elenco>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td valign="top" style="width: 50%">
                            <asp:Panel ID="panelShowFile" runat="server" Visible="false">
                                <h2>
                                Oggetto: <asp:Label ID="lblTitolo" runat="server"></asp:Label>
                                </h2>
                                <asp:Label ID="lblTesto" runat="server"></asp:Label>
                                <hr />
                            </asp:Panel>
                        </td>
                    </tr>
                </tbody>
            </table>
            <asp:Panel ID="panWriteFile" runat="server" Visible="false">
                <table width="100%">
                    <thead>
                        <tr>
                            <td>
                                Scrivi File
                            </td>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>
                                Titolo File: <asp:TextBox ID="txtOggetto" runat="server" MaxLength="50" Columns="50"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Testo:<br />
                                <asp:TextBox ID="txtTesto" runat="server" TextMode="MultiLine" Rows="30" Columns="50"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnInvia" runat="server" Text="Salva" 
                                    onclick="btnInvia_Click" />
                            </td>
                        </tr>
                    </tbody>
                </table>
                <Holonet:CryptaFile ID="ucCriptazione" runat="server" Visible="true" />
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="progressNotify" runat="server" AssociatedUpdatePanelID="panelFiles">
        <ProgressTemplate>
            ATTENDERE, PER FAVORE...
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>
