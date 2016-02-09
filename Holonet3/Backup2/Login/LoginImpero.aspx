<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LoginImpero.aspx.cs" Inherits="Holonet3.Account.LoginImpero" Theme="TemaVerde" %>
<%@ Register Src="~/Login/LoginUserControl.ascx" TagPrefix="Holonet" TagName="Login" %>
<%@ Register Src="~/Login/QRLoginUserControl.ascx" TagPrefix="Holonet" TagName="QRLogin" %>
<%@ Register Src="~/Hacking/TentativoHacking.ascx" TagPrefix="Holonet" TagName="Hacking" %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContent" runat="server">
    <%--I seguenti .js sono da includere per poter usare il plugin del QRCodeReader--%>
    <script src="../Scripts/jquery-1.4.1.min.js" type="text/javascript" language="javascript"></script>
    <script src="../Scripts/jquery.webcamqrcode.js" type="text/javascript" language="javascript"></script>
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <%--<Holonet:Login ID="ucLogin" runat="server"/>--%>
    <Holonet:QRLogin ID="qrLogin" runat="server"></Holonet:QRLogin>
    <asp:UpdatePanel ID="panHack" runat="server">
        <ContentTemplate>
            <Holonet:Hacking ID="ucHacking" runat="server" AccettaSpina="false" ParteDaHackerare="altro" LivelloHacking="0" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
