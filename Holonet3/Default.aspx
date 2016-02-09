<%@ Page Title="Home page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="Holonet3._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        benvenuto <asp:Label ID="lblNomePersonaggio" runat="server"></asp:Label> 
    </h2>
    <p>
        Accesso eseguito nel terminale Holonet.
    </p>
    <p>
        Selezionare a lato la funzione desiderata.
    </p>
</asp:Content>
