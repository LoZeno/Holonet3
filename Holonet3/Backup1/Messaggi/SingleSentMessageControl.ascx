<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SingleSentMessageControl.ascx.cs" Inherits="Holonet3.Messaggi.SingleSentMessageControl" %>
<h3>
        Destinatari: <asp:Label ID="lblDestinatari" runat="server"></asp:Label> <br/>
        OGGETTO: <asp:LinkButton ID="lblTitolo" runat="server" onclick="lblTitolo_Click"></asp:LinkButton>
</h3>