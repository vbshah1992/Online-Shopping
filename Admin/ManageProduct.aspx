<%@ Page Language="VB" MasterPageFile="~/Master/AdminMaster.master" AutoEventWireup="false"
    CodeFile="ManageProduct.aspx.vb" Inherits="Admin_ManageProduct" Theme="AdminTheme" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphAdmin" runat="Server">
    <table width="100%" class="text">
        <tr>
            <td align="center" colspan="2">
                <h2 class="heading">
                    Manage Product</h2>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                <asp:Label runat="server" ID="lblMessage" ForeColor="#C04000"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:HyperLink runat="server" ID="hlkAdmin" NavigateUrl="~/Admin/Product.aspx">Add</asp:HyperLink>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center" class="heading">
                Product :<asp:TextBox ID="txtProduct" runat="server"></asp:TextBox>&nbsp;
                Category :<asp:DropDownList ID="ddlCategory" runat="server">
                </asp:DropDownList>&nbsp;
                Company :<asp:DropDownList ID="ddlCompany" runat="server">
                </asp:DropDownList>
                &nbsp; &nbsp;<asp:Button ID="btnSearch" runat="server" Text="Search" /></td>
        </tr>
        <tr>
            <td id="tdCount" align="center">
                <asp:Label ID="lblCount" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Black"></asp:Label></td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="gvProduct" runat="server" AllowPaging="True" AllowSorting="True"
                    AutoGenerateColumns="False" DataKeyNames="ProductId" DataSourceID="odsProduct">
                    <Columns>
                        <asp:BoundField DataField="ProductName" HeaderText="Product" SortExpression="ProductName" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Image ID="imgRuppes" runat="server" Height="15px" ImageUrl="~/Images/rup.png"
                                    Width="15px" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
                        <asp:BoundField DataField="BriefDescription" HeaderText="Brief Description" SortExpression="BriefDescription" />
                        <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                        <asp:BoundField DataField="CategoryName" HeaderText="Category" SortExpression="CategoryName" />
                        <asp:BoundField DataField="CompanyName" HeaderText="Company" SortExpression="CompanyName" />
                        <asp:HyperLinkField Text="Image" DataNavigateUrlFields="ProductId" DataNavigateUrlFormatString="~/Admin/ManageImage.aspx?PID={0}"
                            HeaderText="Image" />
                        <asp:ButtonField Text="Edit" CommandName="IsAvailable" HeaderText="Is Available"
                            SortExpression="IsAvailable" />
                        <asp:HyperLinkField Text="Edit" DataNavigateUrlFields="ProductId" DataNavigateUrlFormatString="~/Admin/Product.aspx?ID={0}"
                            HeaderText="Edit" />
                        <asp:CommandField ShowDeleteButton="True" HeaderText="Delete" />
                    </Columns>
                </asp:GridView>
                <asp:ObjectDataSource ID="odsProduct" runat="server" DeleteMethod="Delete" InsertMethod="Insert"
                    OldValuesParameterFormatString="original_{0}" SelectMethod="GetDetails" TypeName="ds_ProductTableAdapters.ProductTableAdapter"
                    UpdateMethod="Update">
                    <DeleteParameters>
                        <asp:Parameter Name="Original_ProductId" Type="Int64" />
                    </DeleteParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="ProductName" Type="String" />
                        <asp:Parameter Name="Price" Type="Decimal" />
                        <asp:Parameter Name="BriefDescription" Type="String" />
                        <asp:Parameter Name="Description" Type="String" />
                        <asp:Parameter Name="CategoryId" Type="Int64" />
                        <asp:Parameter Name="CompanyId" Type="Int64" />
                        <asp:Parameter Name="IsAvailable" Type="Boolean" />
                        <asp:Parameter Name="Original_ProductId" Type="Int64" />
                    </UpdateParameters>
                    <InsertParameters>
                        <asp:Parameter Name="ProductName" Type="String" />
                        <asp:Parameter Name="Price" Type="Decimal" />
                        <asp:Parameter Name="BriefDescription" Type="String" />
                        <asp:Parameter Name="Description" Type="String" />
                        <asp:Parameter Name="CategoryId" Type="Int64" />
                        <asp:Parameter Name="CompanyId" Type="Int64" />
                        <asp:Parameter Name="IsAvailable" Type="Boolean" />
                    </InsertParameters>
                </asp:ObjectDataSource>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnExport" runat="server" Text="Export" />
            </td>
        </tr>
    </table>
</asp:Content>
