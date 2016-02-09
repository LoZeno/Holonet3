<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewMessaggi.aspx.cs" Inherits="Holonet3.Messaggi.NewMessaggi" %>
<%@ Register Namespace="HolonetWebControls" Assembly="HolonetControls" TagPrefix="Holonet" %>
<%@ Register Src="~/Informatica/Criptazione.ascx" TagPrefix="Holonet" TagName="CriptaMessaggio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <title>Messaggi Personali</title>
    <script type="text/javascript" id="sourcecode">
//        function applyScroll() {
//            var myheight = $(window).height();
//            myheight = (myheight * 70) / 100;
//            myheight = parseInt(myheight);
//            $('.scroll-pane').css('height', myheight + 'px');
//            $('.scroll-pane').jScrollPane({ showArrows: true });
//        }

//        $(function () {
//            applyScroll();
//        });

//        $(window).resize(function(){
//            applyScroll();
//        });
	</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table width="100%">
        <tr class="menu">
            <td align="center" style="width: 25%;">
                <h2>
                    Messaggi
                </h2>
            </td>
            <td align="center" style="width: 25%;">
                <asp:LinkButton ID="lnkEditor" runat="server" Text="Nuovo Messaggio" 
                    onclick="lnkEditor_Click"></asp:LinkButton>
            </td>
            <td align="center" style="width: 25%;">
                <asp:LinkButton ID="lnkInArrivo" runat="server" Text="Messaggi In Arrivo" 
                    onclick="lnkInArrivo_Click"></asp:LinkButton>
            </td>
            <td align="center" style="width: 25%;">
                <asp:LinkButton ID="lnkInviati" runat="server" Text="Messaggi Inviati" 
                    onclick="lnkInviati_Click"></asp:LinkButton>
            </td>
        </tr>
        <tr class="GridViewHeader">
            <td colspan="4" align="center">
                <asp:UpdatePanel ID="TitlePanel" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblPageTitle" runat="server"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td valign="top" colspan="4">
                <asp:UpdatePanel ID="listPanel" runat="server">
                    <ContentTemplate>
                        <asp:MultiView ID="PageViews" runat="server">
                            <asp:View ID="viewMessageList" runat="server">
                                <Holonet:ClickableGridView ID="grdMessaggi" runat="server" 
                                    AutoGenerateColumns="false" AllowPaging="true" PageSize="20" Width="100%"
                                    RowCssClass="GridViewRow" 
                                    HoverRowCssClass="GridViewAltRow" 
                                    onrowclicked="grdMessaggi_RowClicked" 
                                    onpageindexchanging="grdMessaggi_PageIndexChanging">
                                    <Columns>
                                        <asp:BoundField DataField="Numero" HeaderText="Numero" HeaderStyle-CssClass="hiddencol"  
                                            ReadOnly="true" SortExpression="Numero" ItemStyle-CssClass="hiddencol" />
                                        <asp:BoundField DataField="Mittente" HeaderText="Mittente" 
                                            ReadOnly="True" SortExpression="Mittente" ItemStyle-Width="20%" />
                                        <asp:TemplateField HeaderText ="Destinatari" ItemStyle-Width="20%">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDestinatari" runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Oggetto" HeaderText="Oggetto" 
                                            ReadOnly="True" SortExpression="Oggetto" />
                                        <asp:BoundField DataField="Data" HeaderText="Data" 
                                            ReadOnly="true" SortExpression="Data" ItemStyle-Width="20%" />
                                        <asp:BoundField DataField="Letta" HeaderText="Letta" HeaderStyle-CssClass="hiddencol"  
                                            ReadOnly="true" SortExpression="Letta" ItemStyle-CssClass="hiddencol" />
                                    </Columns>
                                    <PagerSettings Mode="NextPrevious" />
                                    <HeaderStyle Font-Bold="true" CssClass="GridViewHeader" ForeColor="White"/>
                                    <RowStyle CssClass="GridViewRow" />
                                </Holonet:ClickableGridView>
                            </asp:View>
                            <asp:View ID="readMessage" runat="server">
                                <asp:HiddenField ID="hidMessageId" runat="server" />
                                <table width="100%" class="Status">
                                    <tr>
                                        <td align="left" style="width:15%">
                                            <asp:Button ID="btnIndietro" runat="server" Text="Torna a Messaggi" />  
                                        </td>
                                        <td align="left" style="width:15%">
                                            <asp:Button ID="btnRispondi" runat="server" Text="Rispondi" />
                                        </td>
                                        <td align="center">
                                            <asp:Button ID="btnSalvaMittente" runat="server" Text="Salva Mittente" />
                                        </td>
                                        <td align="right" style="width:15%">
                                            <asp:Button ID="btnSalva" runat="server" Text="Salva Messaggio" />
                                        </td>
                                        <td align="right" style="width:15%">
                                            <asp:Button ID="btnCancella" runat="server" Text="Cancella Messaggio" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="5" align="center">
                                            <asp:Label ID="statusMessage" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <div class="scroll-pane">
                                    <h3>
                                        DA: <asp:Label ID="lblMittente" runat="server"></asp:Label>
                                    </h3>
                                    <h3 id="rowDestinatari" runat="server">
                                        A: <asp:Label ID="lblDestinatari" runat="server"></asp:Label>
                                    </h3>
                                    <h4>
                                        <asp:Label ID="lblData" runat="server" Font-Italic="true"></asp:Label>
                                    </h4>
                                    <h2>
                                        Oggetto: <asp:Label ID="lblTitolo" runat="server"></asp:Label>
                                    </h2>
                                    <asp:Label ID="lblTesto" runat="server"></asp:Label>
                                    <hr />
                                </div>
                            </asp:View>
                            <asp:View ID="createMessage" runat="server">
                            <asp:HiddenField ID="hidReceivers" runat="server" />
                                <table width="100%">
                                    <tr>
                                        <td align="center">
                                            <asp:Label ID="statusInvio" runat="server" Visible="false"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            Destinatari: <asp:TextBox ID="txtDestinatari" runat="server" MaxLength="100" Columns="50" AutoPostBack="true"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:DropDownList ID="cmbNomiSalvati" runat="server">
                                            </asp:DropDownList>
                                        
                                            <asp:Button ID="btnAggiungi" Text="Aggiungi ai destinatari" runat="server" 
                                                onclick="btnAggiungi_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            Oggetto: <asp:TextBox ID="txtOggetto" runat="server" MaxLength="50" Columns="50"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            Testo:<br />
                                            <asp:TextBox ID="txtTesto" runat="server" TextMode="MultiLine" Rows="25" Columns="50" ></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Button ID="btnInvia" runat="server" Text="Invia Messaggio" 
                                                onclick="btnInvia_Click" /> - 
                                            <asp:Button ID="btnCrypt" runat="server" Text="Cripta e invia" 
                                                onclick="btnCrypt_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </asp:View>
                            <asp:View ID="encryptMessage" runat="server">
                                <Holonet:CriptaMessaggio ID="ucCrypt" runat="server" Visible="true" />
                                <asp:UpdateProgress ID="UpdateCryptProgress" runat="server">
                                    <ProgressTemplate>
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                            </asp:View>
                        </asp:MultiView>                        
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
