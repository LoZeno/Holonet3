<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ListaHoloFiles.ascx.cs" Inherits="Holonet3.Holodischi.ListaHoloFiles" %>
<%@ Register Src="~/Holodischi/SingleHoloFile.ascx" TagPrefix="Holonet" TagName="SingleFile" %>

    <asp:Repeater ID="rptHoloFile" runat="server" 
    onitemcreated="rptHoloFile_ItemCreated" 
    onitemdatabound="rptHoloFile_ItemDataBound">
        <ItemTemplate>
            <Holonet:SingleFile ID="SingleFileView" runat="server" />
            <hr />
        </ItemTemplate>
    </asp:Repeater>
