<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShopCart.aspx.cs" Inherits="MomCare.ShopCart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" EnableViewState="false"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:DataList ID="DataList1" runat="server" OnSelectedIndexChanged="DataList1_SelectedIndexChanged1" DataSourceID="SqlDataSource1" RepeatDirection="Horizontal" Width="100%">
                            <ItemTemplate>
                                <div>
                                    <p>Price:
                                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("Price") %>' />
                                    </p>
                                    <p>Product Name:
                                        <asp:Label ID="ProductNameLabel" runat="server" Text='<%# Eval("ProductName") %>' />
                                    </p>
                                    <asp:Button ID="Button3" runat="server" Text="Add to cart" CommandArgument='<%# Eval("ProductID") %>' />
                                </div>
                            </ItemTemplate>
                        </asp:DataList>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:sampleDBConnectionString %>" SelectCommand="SELECT [Price], [ProductName], [ProductID] FROM [Table_2]"></asp:SqlDataSource>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="Button2" runat="server" Text="View Cart" PostBackUrl="~/ViewCart.aspx" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>