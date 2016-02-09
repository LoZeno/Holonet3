<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MessaggiRicevuti.ascx.cs" Inherits="Holonet3.Messaggi.MessaggiRicevuti" %>
<%@ Register Src="~/Messaggi/SingleMessageControl.ascx" TagPrefix="Holonet" TagName="Messaggio" %>

    <asp:Repeater ID="repeatMessage" runat="server" 
        onitemcreated="repeatMessage_ItemCreated" 
        onitemdatabound="repeatMessage_ItemDataBound">
        <ItemTemplate>
            <Holonet:Messaggio ID="singleMessageView" runat="server"></Holonet:Messaggio>
            <hr />
        </ItemTemplate>
    </asp:Repeater>
