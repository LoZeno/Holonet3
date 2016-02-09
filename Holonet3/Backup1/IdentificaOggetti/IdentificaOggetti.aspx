<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="IdentificaOggetti.aspx.cs" Inherits="Holonet3.IdentificaOggetti.IdentificaOggetti" %>
<asp:Content ID="ContentHeader" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="ContentBody" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="panUpdate" runat="server">
        <ContentTemplate>
            <table class="utilityTable">
		        <thead>
			        <tr>
				        <td>
					        <asp:Label ID="lblCodice" runat="server" Text="Inserire il codice identificativo dell'oggetto:"></asp:Label>
				        </td>
				        <td align="right">
					        <asp:TextBox ID="txtCodice" AutoCompleteType="Disabled" runat="server" MaxLength="10"></asp:TextBox>
				        </td>
				        <td align="right">
					        <asp:Button ID="btnInvia" runat="server" OnClick="btnIdentifica" Text="Ricerca" />
				        </td>
			        </tr>
			        <tr>
				        <td colspan="3" align="right">
					        <asp:Button ID="btnClear" runat="server" Text="Nuova Ricerca" OnClick="NewSearch" />
				        </td>
			        </tr>
		        </thead>	
		        <tbody>
			        <tr>
				        <td colspan="3">
					        <asp:Image ImageAlign="TextTop" ID="imgOggetto" runat="server" Visible="false" />
					        <asp:Label ID="lblNome" runat="server"></asp:Label><br />
					        <asp:Label ID="lblDescrizione" runat="server"></asp:Label><br />
				        </td>
			        </tr>
			        <tr>
				        <td colspan="3">
					        <asp:Label ID="lblCariche" runat="server"></asp:Label>
				        </td>
			        </tr>
			        <tr>
				        <td colspan="3">
					        <asp:Label ID="lblData" runat="server"></asp:Label>
				        </td>
			        </tr>
			        <tr>
				        <td colspan="3">
					        <asp:Label ID="lblCosto" runat="server"></asp:Label>
				        </td>
			        </tr>
		        </tbody>
	        </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="progressNotify" runat="server" AssociatedUpdatePanelID="panUpdate">
        <ProgressTemplate>
            ATTENDERE PREGO...
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>
