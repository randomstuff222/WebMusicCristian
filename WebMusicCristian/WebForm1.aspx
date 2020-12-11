<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="CristianMusicDB.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Cristian Page</title>
</head>

<script language="javascript" src="../Validation.js" type="text/javascript"></script>  
<script type="text/javascript">
    function Validation() {  
            if (Required('<%=TextBox1.ClientID%>', 'Enter Username'))  
                if (Required('<%=TextBox2.ClientID%>', 'Enter Email'))  
                    if (Required('<%=TextBox3.ClientID%>', 'Enter Password'))  
                        return true;  
            return false;  
        }  
</script>

<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <br />
        <asp:Label ID="Label1" runat="server" Text="Inserted Progress: Pending"></asp:Label>
        <p>
            Create Account</p>
        <p>
            <asp:Label ID="Label2" runat="server"></asp:Label>
        </p>
        <p>
            Name:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </p>
        <p>
            Email:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        </p>
        <p>
            Password:&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        </p>
        <p>
            Country:
            <asp:DropDownList ID="DropDownList1" runat="server">
                <asp:ListItem>United States</asp:ListItem>
                <asp:ListItem>Hawaii</asp:ListItem>
                <asp:ListItem>Mexico</asp:ListItem>
                <asp:ListItem>Puerto Rico</asp:ListItem>
                <asp:ListItem>Jamaica</asp:ListItem>
                <asp:ListItem>El Salvador</asp:ListItem>
                <asp:ListItem>Spain</asp:ListItem>
            </asp:DropDownList>
        </p>
        <p>
            Subscription Plan:
            <asp:DropDownList ID="DropDownList2" runat="server">
                <asp:ListItem>Free</asp:ListItem>
                <asp:ListItem>Premium</asp:ListItem>
            </asp:DropDownList>
        </p>
        <p>
            <asp:Button ID="Button1" runat="server"  Text="Sign Up" OnClientClick="javascript:return Validation();" OnClick="Button1_Click" />
        </p>
        <p>
            Already have an Account?:</p>
        <p>
            <asp:Button ID="Button2" runat="server" Text="Log In" OnClick="Button2_Click" />
        </p>
    </form>
</body>
</html>