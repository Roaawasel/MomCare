<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="MomCare.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="UserName"></asp:Label>
            <asp:TextBox ID="txtb_UserName" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
            <asp:TextBox ID="txtb_Password" runat="server" OnTextChanged="TextBox2_TextChanged"></asp:TextBox>
        </div>
        <p>
            <asp:Label ID="Label3" runat="server" Text="Rember Me."></asp:Label>
            <asp:CheckBox ID="ChkB_CheckMe" runat="server" OnCheckedChanged="CheckBox1_CheckedChanged" />
        </p>
        <p>
            <asp:Button ID="btn_Login" runat="server" OnClick="btn_Login_Click" Text="Login" />
        </p>
        <p>
            <asp:RangeValidator ID="lbl_Message" runat="server" ControlToValidate="txtb_Password"></asp:RangeValidator>
        </p>
    </form>
</body>
</html>
