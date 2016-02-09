<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Decriptazione.ascx.cs" Inherits="Holonet3.Informatica.Decriptazione" %>
<script type="text/javascript" language="javascript">

    function isNumberKey(evt) {
        var charCode = (evt.which) ? evt.which : event.keyCode
        if (charCode > 31 && (charCode < 48 || charCode > 57))
            return false;

        return true;
    }

</script> 

<asp:UpdatePanel ID="panMain" runat="server">
    <ContentTemplate>
        <div id="divStarter" runat="server" style="width:100%" visible="true">
            <asp:LinkButton ID="btnAvviaDecoding" runat="server" 
                onclick="btnAvviaDecoding_Click" Text="Accesso per Decrittazione testo"></asp:LinkButton>
        </div>

        <div id="divMain" runat="server" style="width:100%" visible="false">
            <table width="100%">
                <thead>
                    <tr>
                        <td align="center" valign="top" colspan="2">
                            <h2>
                                DECRIPTAZIONE
                            </h2>
                        </td>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td align="right">
                            Numero PG Offuscatore:
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtNumeroPg" runat="server" Columns="15"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            Password:
                        </td>
                        <td>
                            <asp:TextBox ID="txtPassword" runat="server" Columns="15" TextMode="Password"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Button ID="btnInvia" runat="server" Text="Decoding" 
                                onclick="btnInvia_Click" />
                        </td>
                        <td>
                            <asp:Button ID="btnAnnulla" runat="server" Text="Annulla" 
                                onclick="btnAnnulla_Click" />
                        </td>
                    </tr>
                    <tr id="trErrorMessage" runat="server" visible="false">
                        <td colspan="2">
                            <h1>
                                <asp:Label ID="lblError" runat="server"></asp:Label>
                            </h1>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>

        <div id="divAttenderePrego" runat="server" style="width:100%" visible="false">
            <h1>
                Attendere prego.... <asp:Label ID="lblAttendere" runat="server" Text="0%"></asp:Label>
            </h1>
        </div>

    </ContentTemplate>
</asp:UpdatePanel>

<asp:Timer ID="Timer1" runat="server" Enabled="false" OnTick="TimerTick">
</asp:Timer>