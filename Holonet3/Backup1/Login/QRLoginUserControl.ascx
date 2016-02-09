<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="QRLoginUserControl.ascx.cs" Inherits="Holonet3.Login.QRLoginUserControl" %>
<%@ Register Src="~/QRCodeReader/QrCodeReader.ascx" TagPrefix="Holonet" TagName="QrCodeReader" %>

<Holonet:QrCodeReader ID="qrReader" runat="server" />
<br />
<div>
    <asp:Label ID="lblErrorMessage" runat="server"></asp:Label>
</div>