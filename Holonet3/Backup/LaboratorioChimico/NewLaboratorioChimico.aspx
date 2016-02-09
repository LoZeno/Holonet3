<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewLaboratorioChimico.aspx.cs" Inherits="Holonet3.LaboratorioChimico.NewLaboratorioChimico" %>
<%@ Register Src="~/QRCodeReader/QrCodeReader.ascx" TagPrefix="Holonet" TagName="QrReader" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../Scripts/jquery-1.4.1.min.js" type="text/javascript" language="javascript"></script>
    <script src="../Scripts/jquery.webcamqrcode.js" type="text/javascript" language="javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="functionContainer">
        <div class="GridViewHeader">
                Laboratorio Chimico
        </div>
        <div class="functionContent" style="padding-right:10px; width:45%">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <Holonet:QrReader ID="qrReader" runat="server" />
                </ContentTemplate>
            </asp:UpdatePanel>
            <br />
            <asp:Button ID="btnReset" runat="server" onclick="btnReset_Click" Text="Nuova Elaborazione" />
        </div>
        <div class="functionContent" style="padding-top:4px; width:52%">
            <div class="GridViewHeader" style="text-align:left">
                Ingredienti Inseriti:
            </div>
            <div>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:HiddenField ID="hidField" runat="server" />
                        <asp:TextBox ID="txtElencoIngredienti" runat="server" TextMode="MultiLine" Rows="20" Columns="40" ReadOnly="true"></asp:TextBox> <br />
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:Button ID="btnCrea" runat="server" onclick="btnCrea_Click" Text="Inizia Elaborazione" Enabled="false" />
            </div>
        </div>
    </div>
    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
        <ContentTemplate>
            <asp:MultiView ID="ElaborazioneViews" runat="server">
                <asp:View ID="viewAttesa" runat="server">
                    <h1 style="background-color:White">
                       <asp:Label ID="lblDescrizione" runat="server"></asp:Label> 
                    </h1>
                </asp:View>
                <asp:View ID="viewElaborazione" runat="server">
                    <h1 style="background-color:White">
                        Preparazione composto in corso, si prega di attendere <img src="../Images/Graphics/balls64.gif" alt="(elaborazione)" />
                    </h1>
                </asp:View>
                <asp:View ID="viewRisultato" runat="server">
                    <table width="100%" style="background-color:White">
                            <tr>
				                <td>
					                <asp:Image ImageAlign="TextTop" ID="imgOggetto" runat="server" Visible="false" />
					                Nome: <asp:Label ID="lblNome" runat="server" Font-Bold="true"></asp:Label><br />
					                Descrizione:<asp:Label ID="Label1" runat="server" Font-Bold="true"></asp:Label><br />
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
                </asp:View>
            </asp:MultiView>

            <asp:Timer ID="Timer1" Enabled="false" runat="server">
            </asp:Timer>
        </ContentTemplate>
    </asp:UpdatePanel>
    
</asp:Content>
