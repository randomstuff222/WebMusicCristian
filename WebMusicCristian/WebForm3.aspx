<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm3.aspx.cs" Inherits="WebMusicCristian.WebForm3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <h3>Welcome
        <asp:Label ID="Label1" runat="server"></asp:Label>
    </h3>
    <p>
        <asp:Label ID="Label10" runat="server"></asp:Label>
    </p>
    <title></title>
<script language="javascript" src="../Validation.js" type="text/javascript"></script>  
<script type="text/javascript">
    function Validation() {  
            if (OnlyEmpty('<%=TextBox2.ClientID%>', 'Incorrect Format on the Name of the New Playlist', true))  
                if (OnlyEmpty('<%=TextBox3.ClientID%>', 'Incorrect Format on the Search Bar for the Name of Song', true))  
                    if (OnlyEmpty('<%=TextBox4.ClientID%>', 'Incorrect Format on the Search Bar for the Artist of Song', true)) 
                        if (OnlyEmpty('<%=TextBox5.ClientID%>', 'Incorrect Format on the "Song Number" Text Slot', true)) 
                            return true;  
            return false;  
        }  
</script>



</head>
<body>
    <form id="form1" runat="server">
        <div style="width: 1213px; height: 385px">
            <br />
            <asp:Label ID="Label2" runat="server" Text="Here are your playlist songs:"></asp:Label>

            <br />

            <asp:HiddenField ID="hdnfldVariable" runat="server" />
            <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />
&nbsp;&nbsp;
            <br />
&nbsp;<asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack = "true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
            </asp:DropDownList>
&nbsp;<br />
            <br />
            <asp:Label ID="Label3" runat="server"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <asp:PlaceHolder ID="PlaceHolder3" runat="server"></asp:PlaceHolder>
            &nbsp;&nbsp;<asp:PlaceHolder ID="PlaceHolder5" runat="server"></asp:PlaceHolder>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <asp:Label ID="Label4" runat="server" Text="Songs in the Database:"></asp:Label>
            &nbsp;
            <asp:PlaceHolder ID="PlaceHolder2" runat="server"></asp:PlaceHolder>
            &nbsp;<asp:PlaceHolder ID="PlaceHolder6" runat="server"></asp:PlaceHolder>
            <br />
            <br />
            Playlist
            <asp:DropDownList ID="DropDownList2" runat="server" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" AutoPostBack="True">
            </asp:DropDownList>
&nbsp;
            <input id="Hidden1" type="hidden" value="hello" runat="server" />
&nbsp;&nbsp;<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            &nbsp;&nbsp;
            <asp:Label ID="Label7" runat="server"></asp:Label>
            <br />
            Song Number:
            <asp:TextBox ID="TextBox5" runat="server" Width="25px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Create Playlist" OnClientClick="javascript:return Validation();" />
&nbsp;<asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="Delete Playlist" Width="120px" OnClientClick="javascript:return Validation();" />
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Add to Playlist" Height="32px" Width="107px" OnClientClick="javascript:return Validation();" />
            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Remove From Playlist" Width="142px" Height="31px" OnClientClick="javascript:return Validation();" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label9" runat="server"></asp:Label>
            <br />
            <asp:TextBox ID="TextBox1" runat="server" Width="172px" style="margin-top: 48px"></asp:TextBox>
        <asp:Label ID="Label6" runat="server"></asp:Label>
&nbsp;&nbsp;&nbsp;
            <br />
            <br />
            Search Song by Song Name:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Search Song by Artist:<br />
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Search" OnClientClick="javascript:return Validation();" />
            <br />
            <asp:Label ID="Label8" runat="server"></asp:Label>
            <br />
            <asp:PlaceHolder ID="PlaceHolder7" runat="server"></asp:PlaceHolder>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button6" runat="server" OnClick="Button6_Click" Text="Return to Sign In" OnClientClick="javascript:return Validation();" />
&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button7" runat="server" OnClick="Button7_Click" Text="Return to Log In" OnClientClick="javascript:return Validation();" />
            <br />
            <br />
            <asp:Button ID="Button8" runat="server" OnClick="Button8_Click" Text="Upgrade To Premium" />
            <br />
        </div>
    </form>

</body>
</html>
