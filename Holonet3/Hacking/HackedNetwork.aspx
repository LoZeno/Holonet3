<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HackedNetwork.aspx.cs" Inherits="Holonet3.Hacking.HackedNetwork" %>
<%@ Register Src="~/Hacking/TentativoHacking.ascx" TagPrefix="Holonet" TagName="Hacking" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<script type="text/javascript" language="javascript">

    function isNumberKey(evt) {
        var charCode = (evt.which) ? evt.which : event.keyCode
        if (charCode > 31 && (charCode < 48 || charCode > 57))
            return false;

        return true;
    }

</script> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
        <table width="100%">
            <tr>
                <td colspan="2">
                    <h2>
                        Selezionare un account (scrivere il numero):
                    </h2>
                    <asp:TextBox ID="txtAccountDaAprire" runat="server" Columns="6"></asp:TextBox>
                    <asp:Button ID="btnTenta" runat="server" Text="Inizia hacking" 
                        onclick="btnTenta_Click" />
                        -
                    <asp:Button ID="btnAnnulla" runat="server" Text="Torna all'elenco" 
                        onclick="btnAnnulla_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <h1>
                        <asp:Label ID="lblFallimento" runat="server" Visible="false" Text="TENTATIVO FALLITO!!!"></asp:Label>
                    </h1>
                </td>
            </tr>
        </table>
    <div id="divElenco" runat="server" visible="true" style="width:100%;">
        <table width="100%">
            <asp:Repeater ID="rptAccountRete" runat="server" 
                onitemcreated="rptAccountRete_ItemCreated" 
                onitemdatabound="rptAccountRete_ItemDataBound">
                <ItemTemplate>
                    <tr>
                        <td>
                            <h4>
                                Account: <asp:Label ID="lblNumero" runat="server"></asp:Label>
                            </h4>
                        </td>
                        <td>
                            <h4>
                                Nome: <asp:Label ID="lblNome" runat="server"></asp:Label>
                            </h4>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </div>
    <Holonet:Hacking ID="ucHacking" runat="server" Visible="false" AccettaSpina="true" ParteDaHackerare="account" />
</asp:Content>
