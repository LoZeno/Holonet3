<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Rubrica.aspx.cs" Inherits="Holonet3.Messaggi.Rubrica" %>
<asp:Content ID="ContentHead" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript" language="javascript">

    function isNumberKey(evt) {
        var charCode = (evt.which) ? evt.which : event.keyCode
        if (charCode > 31 && (charCode < 48 || charCode > 57))
            return false;

        return true;
    }

</script> 

</asp:Content>
<asp:Content ID="ContentBody" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="panelMessage" runat="server">
        <ContentTemplate>
        <table style="width:100%">
            <tr>
                <td colspan="2">
                    <h1>
                        RUBRICA DESTINATARI
                    </h1>
                </td>
            </tr>
            <tr>
                <td>
                    <h3>
                        Identificativo
                    </h3>
                </td>
                <td>
                    <h3>
                        Nome Destinatario
                    </h3>
                </td>
            </tr>
            <asp:Repeater ID="rptNumeriSalvati" runat="server" 
                onitemcreated="rptNumeriSalvati_ItemCreated" 
                onitemdatabound="rptNumeriSalvati_ItemDataBound">
                <ItemTemplate>
                    <tr>
                        <td><asp:Label ID="lblNumero" runat="server"></asp:Label></td>
                        <td><asp:Label ID="lblNome" runat="server"></asp:Label></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            <tr>
                <td colspan="2" align="center">
                    <h2>
                        <hr />
                        Inserisci nuovo contatto:
                        <h2>
                        </h2>
                    </h2>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    Numero: <asp:TextBox ID="txtNumero" runat="server" keypress="NumericOnly" MaxLength="4" Columns="4"></asp:TextBox>
                    - Nome: <asp:TextBox ID="txtNome" runat="server" MaxLength="30" Columns="10"></asp:TextBox> - 
                    <asp:Button ID="btnSalva" runat="server" onclick="btnSalva_Click" Text="Salva in rubrica" />
                </td>
            </tr>
        </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="progressNotify" runat="server" AssociatedUpdatePanelID="panelMessage">
        <ProgressTemplate>
            <h1>
                ATTENDERE PREGO....
            </h1>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>
