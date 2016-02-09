<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TentativoHacking.ascx.cs" Inherits="Holonet3.Hacking.TentativoHacking" %>
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
            <asp:LinkButton ID="btnAvviaHacking" runat="server" 
                onclick="btnAvviaHacking_Click" Text="Accesso per tentativo di hacking"></asp:LinkButton>
        </div>

        <div id="divMain" runat="server" style="width:100%" visible="false">
            <table width="100%">
                <thead>
                    <tr>
                        <td align="center" valign="top" colspan="2">
                            <h2>
                                TENTATIVO DI HACKING
                            </h2>
                        </td>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td align="right">
                            Numero PG Hacker:
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
                    <tr id="trSpina" runat="server">
                        <td align="right">
                            Spina (opzionale):
                        </td>
                        <td>
                            <asp:TextBox ID="txtSpina" runat="server" Columns="15"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Button ID="btnInvia" runat="server" Text="Tentativo" 
                                onclick="btnInvia_Click" />
                        </td>
                        <td>
                            <asp:Button ID="btnAnnulla" runat="server" Text="Ci ho ripensato!" 
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

        <div id="divAttenderePrego" runat="server" style="width:100%; background-color:White" visible="false">
            <h1>
                Attendere prego <asp:Label ID="lblAttendere" runat="server" Text="0%"></asp:Label> <img src="../Images/Graphics/globe64.gif" alt="(Connessione in corso)" />
            </h1>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>

<asp:Timer ID="Timer1" runat="server" Enabled="false" OnTick="TimerTick">
</asp:Timer>

