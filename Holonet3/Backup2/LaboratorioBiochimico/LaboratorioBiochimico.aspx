<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LaboratorioBiochimico.aspx.cs" Inherits="Holonet3.LaboratorioBiochimico.LaboratorioBiochimico" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <asp:UpdatePanel ID="panUpdate" runat="server">
        <ContentTemplate>
             <table width="100%">
		        <thead>
			        <tr>
				        <td colspan="3">
					        <asp:Label ID="titolo" runat="server" Text="LABORATORIO DI SINTESI PRONTO: prego inserire componenti base"></asp:Label>
				        </td>
			        </tr>
			        <tr>
				        <td>
					        <asp:Label ID="Label4" runat="server" Text="Inserire ingrediente numero 1:"></asp:Label>
				        </td>
				        <td align="right" colspan="2">
					        <asp:TextBox ID="txtCodice1" AutoCompleteType="Disabled" runat="server" MaxLength="20"></asp:TextBox>
				        </td>
			        </tr>
			        <tr>
				        <td>
					        <asp:Label ID="Label3" runat="server" Text="Inserire ingrediente numero 2:"></asp:Label>
				        </td>
				        <td align="right" colspan="2">
					        <asp:TextBox ID="txtCodice2" AutoCompleteType="Disabled" runat="server" MaxLength="20"></asp:TextBox>
				        </td>
			        </tr>
			        <tr>
				        <td>
					        <asp:Label ID="Label2" runat="server" Text="Inserire ingrediente numero 3:"></asp:Label>
				        </td>
				        <td align="right" colspan="2">
					        <asp:TextBox ID="txtCodice3" AutoCompleteType="Disabled" runat="server" MaxLength="20"></asp:TextBox>
				        </td>
			        </tr>
			        <tr>
				        <td>
					        <asp:Label ID="Label1" runat="server" Text="Inserire ingrediente numero 4:"></asp:Label>
				        </td>
				        <td align="right" colspan="2">
					        <asp:TextBox ID="txtCodice4" AutoCompleteType="Disabled" runat="server" MaxLength="20"></asp:TextBox>
				        </td>
			        </tr>
			        <tr>
				        <td>
					        <asp:Label ID="lblCodice5" runat="server" Text="Inserire ingrediente numero 5:"></asp:Label>
				        </td>
				        <td align="right" colspan="2">
					        <asp:TextBox ID="txtCodice5" AutoCompleteType="Disabled" runat="server" MaxLength="20"></asp:TextBox>
				        </td>
			        </tr>
			        <tr>
				        <td align="right" colspan="3">
					        <asp:Button ID="btnInvia" runat="server" OnClick="btnIdentifica" Text="Ricerca" />
				        </td>
			        </tr>
			        <tr>
				        <td colspan="3" align="right">
					        <asp:Button ID="btnClear" runat="server" Text="Nuovo Esperimento" OnClick="NewSearch" />
				        </td>
			        </tr>
		        </thead>	
		        <tbody>
			        <tr>
				        <td colspan="3">
					        <hr />
					        <asp:Label ID="lblRisultato" runat="server"></asp:Label>
				        </td>
			        </tr>
		        </tbody>
	        </table>
        <asp:Timer ID="Timer1" Enabled="false" OnTick="TimerTick" runat="server">
        </asp:Timer>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
