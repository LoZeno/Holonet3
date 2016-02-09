<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LetturaDischi.aspx.cs" Inherits="Holonet3.Holodischi.LetturaDischi" %>
<%@ Register Src="~/Holodischi/ListaHoloFiles.ascx" TagPrefix="Holonet" TagName="ListaFiles" %>

<asp:Content ID="ContentHeader" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="ContentBody" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="panUpdate" runat="server">
        <ContentTemplate>
            <table width="100%">
                <tr>
                    <td>
                        <h2>
                            Inserire il codice del disco:
                        </h2>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtCodiceDisco" runat="server" Columns="50"></asp:TextBox> 
                        <asp:Button ID="btnInvia" runat="server" Text="Apri Disco" 
                            onclick="btnInvia_Click" />
                    </td>
                </tr>
                <tr>
                    <td valign="top" colspan="2" style="width: 50%">
                        <table style="width: 100%; vertical-align: text-top;">
                            <tr>
                                <td>
                                    <Holonet:ListaFiles ID="listFiles" runat="server" Visible="false" />
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td valign="top" colspan="2">
                        <asp:Panel ID="panFile" runat="server" Visible="false" Width="100%">
                            <h3>
                                <asp:Label ID="lblNomeFile" runat="server"></asp:Label>
                            </h3>
                            <asp:Label ID="lblTesto" runat="server"></asp:Label>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="progressNotify" runat="server" AssociatedUpdatePanelID="panUpdate">
        <ProgressTemplate>
            ATTENDERE PREGO.....
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>
