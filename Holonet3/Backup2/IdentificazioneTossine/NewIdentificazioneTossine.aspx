<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewIdentificazioneTossine.aspx.cs" Inherits="Holonet3.IdentificazioneTossine.NewIdentificazioneTossine" %>
<%@ Register Src="~/QRCodeReader/QrCodeReader.ascx" TagPrefix="Holonet" TagName="QrReader" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../Scripts/jquery-1.4.1.min.js" type="text/javascript" language="javascript"></script>
    <script src="../Scripts/jquery.webcamqrcode.js" type="text/javascript" language="javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table width="100%">
        <tr class="GridViewHeader">
            <td colspan="2" align="center">Identificazione Tossine</td>
        </tr>
        <tr>
            <td valign="top">
                <Holonet:QrReader ID="qrReader" runat="server" />
            </td>
            <td valign="top" align="left">
                <asp:UpdatePanel ID="updatePanel1" runat="server">
                    <ContentTemplate>
                        <table width="100%">
                            <tr>
				                <td>
					                <asp:Image ImageAlign="TextTop" ID="imgOggetto" runat="server" Visible="false" />
					                Nome: <asp:Label ID="lblNome" runat="server" Font-Bold="true"></asp:Label><br />
					                Descrizione:<asp:Label ID="lblDescrizione" runat="server" Font-Bold="true"></asp:Label><br />
                                    Tipo: <asp:Label ID="lblTipo" runat="server" Font-Bold="true"></asp:Label><br />
				                </td>
			                </tr>
                            <tr>
                                <td>
                                    Modo d'Uso: <asp:Label ID="lblModoUso" runat="server" Font-Bold="true"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Effetto: <asp:Label ID="lblEffetto" runat="server" Font-Bold="true"></asp:Label>
                                </td>
                            </tr>
			                <tr>
				                <td>
					                Valore di Efficacia: <asp:Label ID="lblEfficacia" runat="server" Font-Bold="true"></asp:Label>
				                </td>
			                </tr>
			                <tr>
				                <td>
					                Data di scadenza: <asp:Label ID="lblData" runat="server" Font-Bold="true"></asp:Label>
				                </td>
			                </tr>
			                <tr>
				                <td>
					                Valore in crediti: <asp:Label ID="lblCosto" runat="server" Font-Bold="true"></asp:Label>
				                </td>
			                </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
    
</asp:Content>
