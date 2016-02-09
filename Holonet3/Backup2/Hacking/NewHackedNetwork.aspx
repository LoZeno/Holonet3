<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewHackedNetwork.aspx.cs" Inherits="Holonet3.Hacking.NewHackedNetwork" %>
<%@ Register Namespace="HolonetWebControls" Assembly="HolonetControls" TagPrefix="Holonet" %>
<%@ Register Src="~/Hacking/TentativoHacking.ascx" TagPrefix="Holonet" TagName="Hacking" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <title>Hacked Network</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table width="100%">
        <tr class="GridViewHeader">
            <td>
                Elenco degli Account di Rete:
            </td>
        </tr>
        <tr>
            <td class="Status">
                <asp:UpdatePanel ID="messagepanel" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="errorMessage" runat="server" Visible="false">Tentativo di accesso fallito!!</asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td valign="top">
                <asp:UpdatePanel ID="listPanel" runat="server">
                    <ContentTemplate>
                        <asp:MultiView ID="pageViews" runat="server">
                            <asp:View ID="viewAccountList" runat="server">
                                <Holonet:ClickableGridView ID="grdAccount" runat="server" 
                                    AutoGenerateColumns="false" AllowPaging="true" PageSize="20" Width="100%"
                                    RowCssClass="GridViewRow" 
                                    HoverRowCssClass="GridViewAltRow" 
                                    onrowclicked="grdAccount_RowClicked" 
                                    onpageindexchanging="grdAccount_PageIndexChanging">
                                    <Columns>
                                        <asp:BoundField DataField="NumeroPG" HeaderText="NumeroPG" HeaderStyle-CssClass="hiddencol"  
                                            ReadOnly="true" SortExpression="NumeroPG" ItemStyle-CssClass="hiddencol" />
                                        <asp:BoundField DataField="Nome" HeaderText="Nome" 
                                            ReadOnly="True" SortExpression="Nome" />
                                        <asp:BoundField DataField="Titolo" HeaderText="Titolo" 
                                            ReadOnly="True" SortExpression="Titolo" />
                                    </Columns>
                                    <PagerSettings Mode="NextPrevious" />
                                    <HeaderStyle Font-Bold="true" CssClass="GridViewHeader" ForeColor="White"/>
                                    <RowStyle CssClass="GridViewRow" />
                                </Holonet:ClickableGridView>
                            </asp:View>
                            <asp:View ID="viewHackAccount" runat="server">
                                <Holonet:Hacking ID="hackControl" runat="server" AccettaSpina="true" ParteDaHackerare="account" />
                            </asp:View>
                        </asp:MultiView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
                <asp:LinkButton ID="lnkReload" runat="server" Text="Ricarica la lista utenti" 
                    onclick="lnkReload_Click"></asp:LinkButton>
            </td>
        </tr>
    </table>
</asp:Content>
