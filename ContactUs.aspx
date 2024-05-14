<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ContactUs.aspx.cs" Inherits="MomCare.ContactUs" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
              <asp:Label ID="lbl_text" runat="server" Text="Name"></asp:Label>
            <asp:TextBox ID="txtb_name" runat="server" Height="29px" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
        </div>
        <p>
            <asp:Label ID="lbl_text2" runat="server" Text="Phone"></asp:Label>
            <asp:TextBox ID="txtb_phone" runat="server" Height="24px"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="lbl_text3" runat="server" Text="Email"></asp:Label>
            <asp:TextBox ID="txtb_email" runat="server" Width="227px"></asp:TextBox>
            <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Allready Exsit" ForeColor="Red" MaximumValue="20" MinimumValue="1" ControlToValidate="txtb_email">*</asp:RangeValidator>
            <asp:Label ID="lbl_Error" runat="server"></asp:Label>
        </p>
        
        <asp:Button runat="server" Text="Save" ID="btn_Save" OnClientClick="return Validate();" OnClick="btn_Save_Click"></asp:Button>
        <asp:Button runat="server" Text="Select" ID="btn_Select" OnClientClick="return Validate();" OnClick="btn_Select_Click"></asp:Button>
        <asp:Button runat="server" Text="Update" ID="btn_Update" OnClientClick="return Validate();" OnClick="btn_Update_Click"></asp:Button>

        </div>
        <div>
        <asp:Label ID="lbl_Up" runat="server" Text="UploadFile"></asp:Label>
            <asp:FileUpload ID="FileUpload1" runat="server" />
            <asp:Button ID="btn_Upload" runat="server" OnClick="btn_Upload_Click" Text="Upload" />
            <asp:Button ID="btn_Upload2" runat="server" OnClick="Button1_Click" style="margin-bottom: 0px" Text="Save " />
        <asp:RangeValidator ID="lbl_Message" runat="server" EnableViewState="False" ControlToValidate="FileUpload1" OnDataBinding="btn_Upload_Click"></asp:RangeValidator>
            </div>
        </div>
        </div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:sampleDBConnectionString %>" OnSelecting="SqlDataSource1_Selecting" SelectCommand="SELECT [Name], [Phone], [Emailp FROM[Table_1] Where Email = @Email" InsertCommand="insert into sampleDB (Name , Phone ,Email) values (@Name, @Phone , @Email)" UpdateCommand="Update Table_1  set Name = @Name ,Phone=@Phone ,where Email= @Email">
            <InsertParameters>
                <asp:ControlParameter ControlID="txtb_name" Name="Name" PropertyName="Text" />
                <asp:ControlParameter ControlID="txtb_phone" Name="Phone" PropertyName="Text" />
                <asp:ControlParameter ControlID="txtb_email" Name="Email" PropertyName="Text" />
            </InsertParameters>
            <SelectParameters>
                <asp:ControlParameter ControlID="txtb_name" Name="Name" PropertyName="Text" />
                <asp:ControlParameter ControlID="txtb_phone" Name="Phone" PropertyName="Text" />
                <asp:ControlParameter ControlID="txtb_email" Name="Email" PropertyName="Text" />
            </SelectParameters>
            <UpdateParameters>
                <asp:ControlParameter ControlID="txtb_email" Name="Email" PropertyName="Text" />
            </UpdateParameters>
        </asp:SqlDataSource>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" PageSize="2">
            <Columns>
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                <asp:BoundField DataField="Phone" HeaderText="Phone" SortExpression="Phone" />
            </Columns>
        </asp:GridView>
        <asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource1" OnItemCommand="Repeater1_ItemCommand">
            <HeaderTemplate>
                <table>
                    <tr><th>Name</th><th>Phone</th></tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%# DataBinder.Eval(Container.DataItem, "Name") %></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "Phone") %></td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
        <asp:DataList ID="DataList1" runat="server" OnSelectedIndexChanged="DataList1_SelectedIndexChanged" RepeatDirection="Horizontal">
        </asp:DataList>
    </form>
</body>
</html>
