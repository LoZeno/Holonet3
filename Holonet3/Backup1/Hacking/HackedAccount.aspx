<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HackedAccount.aspx.cs" Inherits="Holonet3.Hacking.HackedAccount" %>
<%@ Register Src="~/Hacking/TentativoHacking.ascx" TagPrefix="Holonet" TagName="Hacking" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<asp:UpdatePanel ID="panUpdate" runat="server">
    <ContentTemplate>
        <table width="100%">
        <tr>
            <td align="center" colspan="2">
                [ <a href="~/Hacking/NewHackedNetwork.aspx" ID="backLink" runat="server">Torna all'elenco account</a> ]
                <hr />
            </td>
        </tr>
        <tr>
            <td align="left" colspan="2">
                <h2>
                    Account di <asp:Label ID="lblNomeProprietario" runat="server"></asp:Label>
                </h2>
                <h3>
                    Elenco delle sue informazioni personali
                </h3>
            </td>
        </tr>
        <tr>
            <td>
                NOTIZIE RICEVUTE - 
            </td>
            <td>
                <asp:Button ID="btnNotizie" runat="server" Text="Tenta di leggere" 
                    onclick="btnNotizie_Click" />
            </td>
        </tr>
        <tr>
            <td>
                MESSAGGI RICEVUTI - 
            </td>
            <td>
                <asp:Button ID="btnInArrivo" runat="server" Text="Tenta di leggere" 
                    onclick="btnInArrivo_Click" />
            </td>
        </tr>
        <tr>
            <td>
                MESSAGGI INVIATI -
            </td>
            <td>
                <asp:Button ID="btnInUscita" runat="server" Text="Tenta di leggere" 
                    onclick="btnInUscita_Click" />
            </td>
        </tr>
        <tr>
            <td>
                RUBRICA CONTATTI -
            </td>
            <td>
                <asp:Button ID="btnRubrica" runat="server" Text="Tenta di leggere" 
                    onclick="btnRubrica_Click" />
            </td>
        </tr>
        <tr>
            <td>
                FILES PERSONALI -
            </td>
            <td>
                <asp:Button ID="btnFiles" runat="server" Text="Tenta di leggere" 
                    onclick="btnFiles_Click" />
            </td>
        </tr>
    </table>
    <Holonet:Hacking ID="ucHacking" runat="server" AccettaSpina="false" Visible="false" />

    </ContentTemplate>
</asp:UpdatePanel>
</asp:Content>
