<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="MomCare.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <ul>
                <li><a href="Index.aspx">Mom Care</a></li>
                <li><a href="ContactUs.aspx">Contact Us</a></li>
                <li><a href="ShopCard.aspx">Shop Card</a></li>
            </ul>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lbl_Search" runat="server" Text="Search"></asp:Label>
            <asp:TextBox ID="txtb_Search" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
            <asp:GridView ID="GridView1" runat="server" EmptyDataText="No record has found" OnPageIndexChanged="GridView1_SelectedIndexChanged" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            </asp:GridView>
            <asp:Button ID="btn_Search_Click" runat="server" OnClick="btn_Search_Click" Text="Search" />
        </div>
    </form>
</body>
</html>
