<%@ Page Language="VB" MasterPageFile="~/Master/AdminMaster.master" AutoEventWireup="false"
    Theme="AdminTheme" CodeFile="ManageCategory.aspx.vb" Inherits="Admin_ManageCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphAdmin" runat="Server">  
    <table width="100%" class="text">
        <tr>
            <td align="center" colspan="2">
                <h2 class="heading">
                    Manage Category</h2>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                <asp:Label runat="server" ForeColor="#C04000" ID="lblMessage"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:HyperLink runat="server" ID="hlkCategory" NavigateUrl="~/Admin/Category.aspx">Add</asp:HyperLink>
            </td>
        </tr>
        <tr>
            <td id="tdCount" align="center">
                <asp:Label ID="lblCount" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Black"></asp:Label></td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="gvCategory" runat="server" EnableSortingAndPagingCallbacks="True"
                    AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="CategoryId"
                    DataSourceID="odsCategory">
                    <Columns>
                        <asp:BoundField DataField="CategoryName" HeaderText="Category" SortExpression="CategoryName" />
                        <asp:BoundField DataField="ParentCategory" HeaderText="Parent Category" SortExpression="ParentCategory" />
                        <asp:HyperLinkField Text="Edit" DataNavigateUrlFields="CategoryId,CategoryName" DataNavigateUrlFormatString="~/Admin/Category.aspx?Id={0}&amp;CategoryName={1}"
                            HeaderText="Edit" />
                        <asp:CommandField ShowDeleteButton="True" HeaderText="Delete" />
                    </Columns>
                </asp:GridView>
                <asp:ObjectDataSource ID="odsCategory" runat="server" DeleteMethod="Delete" InsertMethod="Insert"
                    OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataByParentCategory"
                    TypeName="ds_CategoryTableAdapters.CategoryTableAdapter" UpdateMethod="Update">
                    <DeleteParameters>
                        <asp:Parameter Name="Original_CategoryId" Type="Int64" />
                    </DeleteParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="CategoryName" Type="String" />
                        <asp:Parameter Name="ParentCategoryId" Type="Int64" />
                        <asp:Parameter Name="Original_CategoryId" Type="Int64" />
                    </UpdateParameters>
                    <InsertParameters>
                        <asp:Parameter Name="CategoryName" Type="String" />
                        <asp:Parameter Name="ParentCategoryId" Type="Int64" />
                    </InsertParameters>
                </asp:ObjectDataSource>
            </td>
        </tr>
    </table>
</asp:Content>
