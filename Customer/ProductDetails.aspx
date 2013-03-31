<%@ Page Language="VB" MasterPageFile="~/Master/CustomerMaster.master" AutoEventWireup="false"
    CodeFile="ProductDetails.aspx.vb" Inherits="Customer_ProductDetails" Title="Product Details" Theme="CustomerTheme" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphCustomer" runat="Server">
    <table width="100%"  class="text">
        <tr>
            <td align="center">
            <h2 class="heading">Product Detail</h2>
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Label ID="lblMessage" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
    <table runat="server">
        <tr>
            <td style="height: 281px">
                <asp:GridView ID="gvProductDetails" ShowHeader="False" EnableSortingAndPagingCallbacks="True"
                    runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="ImageId"
                    DataSourceID="odsProductImage" AllowSorting="True" PageSize="1">
                    <Columns>
                        <asp:ImageField DataImageUrlFormatString="~\Images\Product\{0}"
                            DataImageUrlField="ImagePath" HeaderText="Image" SortExpression="ImagePath" >
                            <ControlStyle Height="150px" Width="150px" />
                        </asp:ImageField>
                    </Columns>
                </asp:GridView>
                <asp:ObjectDataSource ID="odsProductImage" runat="server" DeleteMethod="Delete" InsertMethod="Insert"
                    OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataByProductDetails"
                    TypeName="ds_ImageTableAdapters.ImageTableAdapter" UpdateMethod="Update">
                    <DeleteParameters>
                        <asp:Parameter Name="Original_ImageId" Type="Int64" />
                    </DeleteParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="Title" Type="String" />
                        <asp:Parameter Name="ImagePath" Type="String" />
                        <asp:Parameter Name="ProductId" Type="Int64" />
                        <asp:Parameter Name="IsCoverImage" Type="Boolean" />
                        <asp:Parameter Name="IsVisible" Type="Boolean" />
                        <asp:Parameter Name="Original_ImageId" Type="Int64" />
                    </UpdateParameters>
                    <SelectParameters>
                        <asp:QueryStringParameter DefaultValue="0" Name="ProductId" QueryStringField="ID"
                            Type="Int64" />
                    </SelectParameters>
                    <InsertParameters>
                        <asp:Parameter Name="Title" Type="String" />
                        <asp:Parameter Name="ImagePath" Type="String" />
                        <asp:Parameter Name="ProductId" Type="Int64" />
                        <asp:Parameter Name="IsCoverImage" Type="Boolean" />
                        <asp:Parameter Name="IsVisible" Type="Boolean" />
                    </InsertParameters>
                </asp:ObjectDataSource>
            </td>
            <td style="width: 276px; height: 281px;">
                <br />
                <br />
                <h5>
                    <strong>Product:</strong>&nbsp;&nbsp;
                    <asp:Label ID="lblProduct" runat="server" Text=""></asp:Label><br />
                    <br />
                    <strong>Category:</strong>&nbsp;&nbsp;
                    <asp:Label ID="lblCategory" runat="server" Text=""></asp:Label><br />
                    <strong>Company:</strong>&nbsp;&nbsp;
                    <asp:Label ID="lblCompany" runat="server" Text=""></asp:Label><br />
                    <strong>Price:</strong>&nbsp;&nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                    <asp:Image ID="imgRuppes" runat="server" Height="14px" ImageUrl="~/Images/Rupee.gif" Width="20px" />
                    <asp:Label ID="lblPrice" runat="server" Text=""></asp:Label><br />
                    <strong>Brief Description:</strong>&nbsp;&nbsp;
                    <asp:Label ID="lblBriefDescription" runat="server" Text=""></asp:Label><br />
                    <strong>Quantity:</strong>&nbsp;&nbsp;
                    <asp:TextBox ID="txtQuantity" runat="server" Width="25px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvQuantity" runat="server" ControlToValidate="txtQuantity"
                        ErrorMessage="Please enter quantity." ValidationGroup="vgAddtoCart" Text="*"></asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="rvQuantity" runat="server" ControlToValidate="txtQuantity"
                        ErrorMessage="Please enter quantity in 1 to 5." MaximumValue="5" MinimumValue="1" ValidationGroup="vgAddtoCart"
                        Text="*" Type="Integer"></asp:RangeValidator>&nbsp;
                    <asp:Button ID="btnAddtoCart" runat="server" Text="Add to Cart" ValidationGroup="vgAddtoCart" />
                    <asp:Button ID="btnBack" runat="server" Text="Back" />
                    <asp:Label ID="lblQuantityCheck" runat="server"></asp:Label>
                </h5>
                <h5>
                    <br />
                    <asp:ValidationSummary ID="vsAddtoCart" runat="server" ShowMessageBox="true" ShowSummary="false"
                        ValidationGroup="vgAddtoCart" />
                </h5>
            </td>
        </tr>
        <tr>
            <td>
                <h5>
                    <strong>Description:</strong>&nbsp;&nbsp;
                    <asp:Label ID="lblDescription" runat="server" Text=""></asp:Label><br />
                </h5>
            </td>
        </tr>
    </table>
    <asp:ObjectDataSource ID="odsImage" runat="server" DeleteMethod="Delete" InsertMethod="Insert"
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataByProductDetails"
        TypeName="ds_ImageTableAdapters.ImageTableAdapter" UpdateMethod="Update">
        <DeleteParameters>
            <asp:Parameter Name="Original_ImageId" Type="Int64" />
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="Title" Type="String" />
            <asp:Parameter Name="ImagePath" Type="String" />
            <asp:Parameter Name="ProductId" Type="Int64" />
            <asp:Parameter Name="IsCoverImage" Type="Boolean" />
            <asp:Parameter Name="IsVisible" Type="Boolean" />
            <asp:Parameter Name="Original_ImageId" Type="Int64" />
        </UpdateParameters>
        <SelectParameters>
            <asp:QueryStringParameter Name="ProductId" QueryStringField="ID" Type="Int64" />
        </SelectParameters>
        <InsertParameters>
            <asp:Parameter Name="Title" Type="String" />
            <asp:Parameter Name="ImagePath" Type="String" />
            <asp:Parameter Name="ProductId" Type="Int64" />
            <asp:Parameter Name="IsCoverImage" Type="Boolean" />
            <asp:Parameter Name="IsVisible" Type="Boolean" />
        </InsertParameters>
    </asp:ObjectDataSource>
</asp:Content>
