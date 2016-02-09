<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewRubrica.aspx.cs" Inherits="Holonet3.Messaggi.NewRubrica" %>
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
                    <td>
                        <h1>
                            RUBRICA DESTINATARI
                        </h1>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="grdPeople" runat="server" AutoGenerateColumns="False" AllowPaging="true" Width="90%"                              PageSize="20"
                            OnPageIndexChanging="grdPeople_PageIndexChanging">
                           <Columns>
                                <asp:BoundField DataField="NumeroSalvato" HeaderText="Numero" 
                                   ReadOnly="True" SortExpression="NumeroSalvato" ItemStyle-Width="10%" />
                                <asp:BoundField DataField="NomeVisualizzato" HeaderText="Nome" 
                                   ReadOnly="True" SortExpression="NomeVisualizzato" ItemStyle-Width="80%" />
                                <asp:TemplateField HeaderText="Selez." ItemStyle-Width="10%" >
                                    <ItemTemplate>
                                        <asp:CheckBox Checked="false" ID="chkCol" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                           </Columns>
                           <PagerSettings Mode="NextPrevious" />
                           <HeaderStyle Font-Bold="true" CssClass="GridViewHeader" ForeColor="White"/>
                           <RowStyle CssClass="GridViewRow" />
                           <AlternatingRowStyle CssClass="GridViewAltRow" />
                        </asp:GridView> 
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblEliminaText" runat="server">Cancella elementi selezionati: </asp:Label> <asp:Button ID="btnElimina" runat="server" OnClick="btnElimina_Click" Text="Cancella dalla rubrica" />
                    </td>
                </tr>
                <tr>
                <td align="center">
                    <h2>
                        <hr />
                        Inserisci nuovo contatto:
                        <h2>
                        </h2>
                    </h2>
                </td>
            </tr>
            <tr>
                <td>
                    Numero: <asp:TextBox ID="txtNumero" runat="server" keypress="NumericOnly" MaxLength="4" Columns="4"></asp:TextBox>
                    - Nome: <asp:TextBox ID="txtNome" runat="server" MaxLength="30" Columns="10"></asp:TextBox> - 
                    <asp:Button ID="btnSalva" runat="server" onclick="btnSalva_Click" Text="Salva in rubrica" />
                </td>
            </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
