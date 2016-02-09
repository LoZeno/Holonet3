<%@ Page Title="Dettagli sull'organizzazione" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="About.aspx.cs" Inherits="Holonet3.About" Theme="TemaBlu" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Informazioni su Holonet 3
    </h2>
    <h3>
        <p>
            <asp:Label ID="lblNameVer" runat="server"></asp:Label>
        </p>
    </h3>
    <h4>
        <p>
            <asp:Label ID="lblCopyright" runat="server" Font-Bold="true"></asp:Label>
        </p>
        <p>
            Sviluppato per SWLive GRV
        </p>
    </h4>
    <h5>
        <p>
            Utilizza librerie di proprietà di Gianluca "Number" Guazzo
        </p>
    </h5>
    
</asp:Content>
