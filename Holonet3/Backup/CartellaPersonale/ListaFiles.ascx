<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ListaFiles.ascx.cs" Inherits="Holonet3.CartellaPersonale.ListaFiles" %>

<%@ Register Src="~/CartellaPersonale/SingleFile.ascx" TagPrefix="Holonet" TagName="ShowFile" %>

    <asp:Repeater ID="rptShowFile" runat="server" 
    onitemcreated="rptShowFile_ItemCreated" 
    onitemdatabound="rptShowFile_ItemDataBound">
        <ItemTemplate>
            <Holonet:ShowFile ID="showSingleFile" runat="server" />
        </ItemTemplate>
    </asp:Repeater>