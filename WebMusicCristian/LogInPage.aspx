<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogInPage.aspx.cs" Inherits="WebMusicCristian.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
    <script language="javascript" src="../Validation.js" type="text/javascript"></script>  
<script type="text/javascript">
    function Validation() {  
            if (Required('<%=TextBox1.ClientID%>', 'Enter Username'))  
                if (Required('<%=TextBox3.ClientID%>', 'Enter Email'))  
                    if (Required('<%=TextBox4.ClientID%>', 'Enter Password'))  
                        return true;  
            return false;  
        }  
</script>
<body>
    <form id="form1" runat="server">
        <div>
            Log In:<br />
            <br />
            Username:&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            Email:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            <br />
            Password:&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
        </div>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Log in" OnClientClick="javascript:return Validation();" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Sign Up" />
&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label1" runat="server"></asp:Label>
        <br />
    </form>
</body>
</html>
