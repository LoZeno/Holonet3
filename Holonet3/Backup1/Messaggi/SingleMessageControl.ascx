<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SingleMessageControl.ascx.cs" Inherits="Holonet3.Messaggi.SingleMessageControl" %>
<h3>
        DA: <asp:Label ID="lblMittente" runat="server"></asp:Label> <br/>
        OGGETTO: <asp:LinkButton ID="lblTitolo" runat="server" onclick="lblTitolo_Click"></asp:LinkButton>
</h3>
        Letta: <asp:Label ID="lblStatoLettura" runat="server" Font-Bold="true"></asp:Label>