<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewAnalisiMedica.aspx.cs" Inherits="Holonet3.AnalisiMedica.NewAnalisiMedica" %>
<%@ Register Src="~/QRCodeReader/QrCodeReader.ascx" TagPrefix="Holonet" TagName="QrReader" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../Scripts/jquery-1.4.1.min.js" type="text/javascript" language="javascript"></script>
    <script src="../Scripts/jquery.webcamqrcode.js" type="text/javascript" language="javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table width="100%">
        <tr class="GridViewHeader">
            <td align="center">Analisi Medica</td>
        </tr>
        <tr>
            <td>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:MultiView ID="PageViews" runat="server">
                            <asp:View ID="viewIdentificazione" runat="server">
                                <div style="text-align:center; width:100%">
                                    Inserire il campione da analizzare
                                </div>
                                <Holonet:QrReader ID="qrReader" runat="server" />
                            </asp:View>
                            <asp:View ID="viewElaborazione" runat="server">
                                <h1 style="background-color:White">
                                    Attendere, analisi in corso. <img src="../Images/Graphics/dots64.gif" alt="(Analisi)" />
                                </h1>
                            </asp:View>
                            <asp:View ID="viewRisultato" runat="server">
                                Risultato delle analisi: <br />
                                <asp:TextBox ID="txtRisultato" runat="server" TextMode="MultiLine" Columns="50" Rows="15" ReadOnly="true"></asp:TextBox>
                                <br />
                                <asp:Button ID="btnReset" runat="server" Text="Nuova Analisi" 
                                    onclick="btnReset_Click" />
                            </asp:View>
                        </asp:MultiView>
                        <asp:Timer ID="Timer1" runat="server" Enabled="false" OnTick="TimerTick">
                        </asp:Timer>
                    </ContentTemplate>
                </asp:UpdatePanel>                
            </td>
        </tr>
    </table>
</asp:Content>
