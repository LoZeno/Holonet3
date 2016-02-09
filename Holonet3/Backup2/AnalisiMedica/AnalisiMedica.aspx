<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AnalisiMedica.aspx.cs" Inherits="Holonet3.AnalisiMedica.AnalisiMedica" %>
<asp:Content ID="ContentHead" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="ContentBody" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="panUpdate" runat="server">
        <ContentTemplate>
	        <table width="100%">
		        <thead>
			<tr>
				<td>
					<asp:Label ID="lblCodice" runat="server" Text="Inserire il codice dell'enzima da analizzare:"></asp:Label>
				</td>
				<td align="right">
					<asp:TextBox ID="txtCodice" AutoCompleteType="Disabled" runat="server" MaxLength="20"></asp:TextBox>
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
					<hr />
					<asp:Label ID="lblRisultato" runat="server"></asp:Label>
				</td>
			</tr>
		</tbody>
	        </table>

        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="progressNotify" runat="server" AssociatedUpdatePanelID="panUpdate">
        <ProgressTemplate>
                Attendere....
        </ProgressTemplate>
    </asp:UpdateProgress>
    
<asp:Timer ID="Timer1" runat="server" Enabled="false" OnTick="TimerTick">
</asp:Timer>

</asp:Content>
