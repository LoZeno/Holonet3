<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewLetturaDischi.aspx.cs" Inherits="Holonet3.Holodischi.NewLetturaDischi" %>
<%@ Register Src="~/QRCodeReader/QrCodeReader.ascx" TagPrefix="Holonet" TagName="QrReader" %>
<%@ Register Namespace="HolonetWebControls" Assembly="HolonetControls" TagPrefix="Holonet" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../Scripts/jquery-1.4.1.min.js" type="text/javascript" language="javascript"></script>
    <script src="../Scripts/jquery.webcamqrcode.js" type="text/javascript" language="javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
             <table width="100%">
                <tr class="GridViewHeader">
                    <td colspan="2" align="center">Lettura Datapad e Holodiski</td>
                </tr>
                <tr>
                    <td>                        
                        <asp:MultiView ID="PageViews" runat="server">
                            <asp:View ID="viewLettore" runat="server">
                                <Holonet:QrReader ID="qrReader" runat="server" />
                                <h3 style="background-color:White">
                                    <asp:Label ID="lblDescrizione" runat="server"></asp:Label>
                                </h3>  
                            </asp:View>
                            <asp:View ID="viewElencoFiles" runat="server">
                                <Holonet:ClickableGridView ID="grdFileList" runat="server"
                                AutoGenerateColumns="false" AllowPaging="true" PageSize="20" Width="100%"
                                    RowCssClass="GridViewRow" 
                                    HoverRowCssClass="GridViewAltRow" 
                                    onrowclicked="grdFileList_RowClicked" 
                                    onpageindexchanging="grdFileList_PageIndexChanging">
                                    <Columns>
                                        <asp:BoundField DataField="NumeroFile" HeaderText="Numero" HeaderStyle-CssClass="hiddencol"  
                                            ReadOnly="true" SortExpression="NumeroFile" ItemStyle-CssClass="hiddencol" />
                                        <asp:BoundField DataField="NomeFile" HeaderText="File" 
                                            ReadOnly="True" SortExpression="NomeFile" ItemStyle-Width="100%" />
                                    </Columns>
                                    <PagerSettings Mode="NextPrevious" />
                                    <HeaderStyle Font-Bold="true" CssClass="GridViewHeader" ForeColor="White"/>
                                    <RowStyle CssClass="GridViewRow" />
                                </Holonet:ClickableGridView>
                            </asp:View>
                            <asp:View ID="viewMostraFile" runat="server">
                                <h3>
                                    <asp:Label ID="lblNomeFile" runat="server"></asp:Label>
                                </h3>
                                <div class="scroll-pane">
                                    <asp:Label ID="lblTesto" runat="server"></asp:Label>
                                </div>
                                <asp:Button ID="btnLista" runat="server" Text="Torna a lista file" />
                            </asp:View>
                        </asp:MultiView>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
