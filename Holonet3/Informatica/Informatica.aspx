<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Informatica.aspx.cs" Inherits="Holonet3.Informatica.Informatica" %>
<%@ Register Src="~/Informatica/Criptazione.ascx" TagPrefix="Holonet" TagName="Encrypt" %>
<%@ Register Src="~/Hacking/TentativoHacking.ascx" TagPrefix="Holonet" TagName="Hacking" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="panMainContent" runat="server">
        <ContentTemplate>
            <table width="100%">
                <tr>
                    <td align="center" colspan="3">
                        <h2>
                            Account di <asp:Label ID="lblNomeProprietario" runat="server"></asp:Label>
                        </h2>
                        <h3>
                            Livello di protezione attuale: <asp:Label ID="lblLevel" runat="server"></asp:Label>
                        </h3>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Button ID="btnEncrypt" runat="server" Text="Incrementare la Sicurezza" />
                    </td>
                    <td align="center">
                        <asp:Button ID="btnHack" runat="server" Text="Infrangere reti" />
                    </td>
                    <td align="center">
                        <asp:Button ID="btnPublish" runat="server" Text="Pubblica Notizie" />
                    </td>
                </tr>
            </table>
            <asp:UpdatePanel ID="panFunctions" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:MultiView ID="PageViews" runat="server">
                        <asp:View ID="viewEmpty" runat="server">
                            <h3>
                                <asp:Label ID="lblSuccess" runat="server" Visible="false" Font-Bold="true">Notizia pubblicata con successo</asp:Label>
                            </h3>
                        </asp:View>
                        <asp:View ID="viewNotizie" runat="server">
                            <div class="scroll-pane">
                                <table width="100%">
                                    <tr>
                                        <td align="right" colspan="2">
                                            Titolo: <asp:TextBox ID="txtOggetto" runat="server" MaxLength="50" Columns="50"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            Data Scadenza Notizia:<br /> <asp:Calendar ID="calScadenza" runat="server" SelectionMode="Day" FirstDayOfWeek="Monday"></asp:Calendar>
                                        </td>
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
                        <asp:View ID="viewHackRete" runat="server">
                            <div class="scroll-pane">
                                Seleziona la rete da infrangere: <asp:DropDownList ID="cmbRete" runat="server">
                                </asp:DropDownList>
                                <Holonet:Hacking ID="hackControl" runat="server" LivelloHacking="2" ParteDaHackerare="altro" AccettaSpina="false" />
                            </div>
                        </asp:View>
                        <asp:View ID="viewRemoto" runat="server">
                            <iframe id="frameHack" runat="server" scrolling="auto" width="100%" class="scroll-pane">
                            </iframe>
                        </asp:View>
                        <asp:View ID="viewCrypt" runat="server">
                            <Holonet:Encrypt ID="ucEncrypt" runat="server" />
                        </asp:View>
                    </asp:MultiView>
                </ContentTemplate>
            </asp:UpdatePanel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
