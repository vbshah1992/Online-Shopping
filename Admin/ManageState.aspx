<%@ Page Language="VB" MasterPageFile="~/Master/AdminMaster.master" AutoEventWireup="false"
    CodeFile="ManageState.aspx.vb" Inherits="Admin_ManageState" Theme="AdminTheme" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphAdmin" runat="Server">
    <table width="100%" class="text">
        <tr>
            <td align="center" colspan="2">
              <h2 class="heading">Manage State</h2>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2" style="height: 21px">
                <asp:Label runat="server" ID="lblMessage" ForeColor="#C04000"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:HyperLink runat="server" ID="hlkState" NavigateUrl="~/Admin/State.aspx">Add</asp:HyperLink>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center" class="heading">
                State :
                <asp:TextBox ID="txtState" runat="server"></asp:TextBox>
                &nbsp; Country :
                <asp:DropDownList ID="ddlCountry" runat="server">
                </asp:DropDownList>
                &nbsp; &nbsp;<asp:Button ID="btnSearch" runat="server" Text="Search" /></td>
        </tr>
        <tr>
            <td id="tdCount" align="center">
                <asp:Label ID="lblCount" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Black"></asp:Label></td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="gvState" runat="server" EnableSortingAndPagingCallbacks="True" AllowPaging="True" AllowSorting="True"
                    AutoGenerateColumns="False" DataKeyNames="StateId" DataSourceID="odsState">
                    <Columns>                        
                        <asp:BoundField DataField="StateName" HeaderText="State" SortExpression="StateName" />
                        <asp:BoundField DataField="CountryName" HeaderText="Country" SortExpression="CountryName" />
                        <asp:HyperLinkField Text="Edit" DataNavigateUrlFields="StateId,StateName" DataNavigateUrlFormatString="~/Admin/State.aspx?Id={0}&amp;StateName={1}" HeaderText="Edit" />
                        <asp:CommandField ShowDeleteButton="True" HeaderText="Delete" />
                    </Columns>
                </asp:GridView>
                <asp:ObjectDataSource ID="odsState" runat="server" DeleteMethod="Delete" InsertMethod="Insert"
                    OldValuesParameterFormatString="original_{0}" SelectMethod="GetDetails" TypeName="ds_StateTableAdapters.StateTableAdapter"
                    UpdateMethod="Update">
                    <DeleteParameters>
                        <asp:Parameter Name="Original_StateId" Type="Int64" />
                    </DeleteParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="StateName" Type="String" />
                        <asp:Parameter Name="CountryId" Type="Int64" />
                        <asp:Parameter Name="Original_StateId" Type="Int64" />
                    </UpdateParameters>
                    <InsertParameters>
                        <asp:Parameter Name="StateName" Type="String" />
                        <asp:Parameter Name="CountryId" Type="Int64" />
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
