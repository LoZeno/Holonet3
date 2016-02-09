<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MessaggiInviati.ascx.cs" Inherits="Holonet3.Messaggi.MessaggiInviati" %>
<%@ Register Src="SingleSentMessageControl.ascx" TagPrefix="Holonet" TagName="MessaggioInviato" %>

    <asp:Repeater ID="repeatMessage" runat="server" 
    onitemcreated="repeatMessage_ItemCreated1" 
    onitemdatabound="repeatMessage_ItemDataBound1">
        <ItemTemplate>
            <Holonet:MessaggioInviato ID="singleMessageView" runat="server" />
            <hr />
        </ItemTemplate>
    </asp:Repeater>