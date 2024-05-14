<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Session.aspx.cs" Inherits="MomCare.WebForm5" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lbl_Session" runat="server"></asp:Label>
        </div>
        <p>
            <asp:Label ID="lbl_UserName" runat="server" Text="UserName"></asp:Label>
            <asp:TextBox ID="txtb_UserName" runat="server" OnTextChanged="TextBox2_TextChanged"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="lbl_password" runat="server" Text="Password"></asp:Label>
            <asp:TextBox ID="txtb_Password" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="btn_Login" runat="server" OnClick="btn_Login_Click" Text="Login" />
        </p>
        <p>
            <asp:Label ID="lbl_ErrorMessage" runat="server"></asp:Label>
        </p>
    </form>
</body>
</html>
