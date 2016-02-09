<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewIdentificaOggetti.aspx.cs" Inherits="Holonet3.IdentificaOggetti.NewIdentificaOggetti" %>
<%@ Register Src="~/QRCodeReader/QrCodeReader.ascx" TagPrefix="Holonet" TagName="QrReader" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../Scripts/jquery-1.4.1.min.js" type="text/javascript" language="javascript"></script>
    <script src="../Scripts/jquery.webcamqrcode.js" type="text/javascript" language="javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table width="100%">
        <tr class="GridViewHeader">
            <td colspan="2" align="center">Identificazione Oggetti</td>
        </tr>
        <tr>
            <td valign="top">
                <Holonet:QrReader ID="qrReader" runat="server" />
            </td>
            <td align="left" valign="top">
                <asp:UpdatePanel ID="updatePanel1" runat="server">
                    <ContentTemplate>
                        <table width="100%">
                            <tr>
				                <td>
					                <asp:Image ImageAlign="TextTop" ID="imgOggetto" runat="server" Visible="false" />
					                Nome: <asp:Label ID="lblNome" runat="server" Font-Bold="true"></asp:Label><br />
                                    Tipo: <asp:Label ID="lblTipo" runat="server" Font-Bold="true"></asp:Label>
					                Descrizione:<asp:Label ID="lblDescrizione" runat="server" Font-Bold="true"></asp:Label><br />
				                </td>
			                </tr>
                            <tr>
                                <td>
                                    Effetto: <asp:Label ID="lblEffetto" runat="server" Font-Bold="true"></asp:Label>
                                </td>
                            </tr>
			                <tr>
				                <td>
					                Cariche: <asp:Label ID="lblCariche" runat="server" Font-Bold="true"></asp:Label>
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
