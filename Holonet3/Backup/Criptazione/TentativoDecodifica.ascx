<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TentativoDecodifica.ascx.cs" Inherits="Holonet3.Criptazione.TentativoDecodifica" %>
<script type="text/javascript" language="javascript">

    function isNumberKey(evt) {
        var charCode = (evt.which) ? evt.which : event.keyCode
        if (charCode > 31 && (charCode < 48 || charCode > 57))
            return false;

        return true;
    }

</script> 

