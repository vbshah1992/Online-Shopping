<%@ Page Language="VB" MasterPageFile="~/Master/AdminMaster.master" AutoEventWireup="false"
    Theme="AdminTheme" CodeFile="ManageImage.aspx.vb" Inherits="Admin_ManageImage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphAdmin" runat="Server">
    <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <contenttemplate>--%>
    <table width="100%" class="text">
        <tr>
            <td align="center" colspan="2">
                <h2 class="heading">
                    Manage Image</h2>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2" style="height: 21px">
                <asp:Label runat="server" ForeColor="#C04000" ID="lblMessage"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left">
                <asp:LinkButton runat="server" ID="lnkImage" Text="Add" />
            </td>
            <td align="right">
                <asp:LinkButton ID="lbnBack" runat="server">Back</asp:LinkButton></td>
        </tr>
        <tr>
            <td align="left" align="center" class="heading">
                Product :
                <asp:DropDownList ID="ddlProduct" runat="server" AutoPostBack="True">
                </asp:DropDownList></td>
            <td align="right">
            </td>
        </tr>
        <tr>
            <td id="tdCount" align="center">
                <asp:Label ID="lblCount" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Black"></asp:Label></td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="gvImage" runat="server" AllowPaging="True" AllowSorting="True"
                    AutoGenerateColumns="False" DataKeyNames="ImageId" DataSourceID="odsImage">
                    <Columns>
                        <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                        <asp:ImageField DataImageUrlFormatString="~\Images\Product\{0}" HeaderText="Image"
                            DataImageUrlField="ImagePath" SortExpression="ImagePath">
                            <ControlStyle Height="50px" Width="50px" />
                        </asp:ImageField>
                        <asp:ButtonField Text="Edit" CommandName="IsCoverImage" HeaderText="Is Cover Image"
                            SortExpression="IsCoverImage" />
                        <asp:ButtonField Text="Edit" CommandName="IsVisible" HeaderText="Is Visible" SortExpression="IsVisible" />
                        <asp:HyperLinkField Text="Edit" DataNavigateUrlFields="ImageId,ProductId" DataNavigateUrlFormatString="~/Admin/Image.aspx?Id={0}&amp;PID={1}"
                            HeaderText="Edit" />
                        <asp:CommandField ShowDeleteButton="True" HeaderText="Delete" />
                        <%--For donloading something
                        <asp:TemplateField HeaderText="Download">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkDownload" CommandName="Download" CommandArgument='<%#Eval("ImageId") %>' Text="Download" runat="server"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                    </Columns>
                </asp:GridView>
                <asp:ObjectDataSource ID="odsImage" runat="server" DeleteMethod="Delete" InsertMethod="Insert"
                    OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataByPid" TypeName="ds_ImageTableAdapters.ImageTableAdapter"
                    UpdateMethod="Update">
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
                    <InsertParameters>
                        <asp:Parameter Name="Title" Type="String" />
                        <asp:Parameter Name="ImagePath" Type="String" />
                        <asp:Parameter Name="ProductId" Type="Int64" />
                        <asp:Parameter Name="IsCoverImage" Type="Boolean" />
                        <asp:Parameter Name="IsVisible" Type="Boolean" />
                    </InsertParameters>
                    <SelectParameters>
                        <asp:QueryStringParameter DefaultValue="0" Name="ProductId" QueryStringField="PID"
                            Type="Int64" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </td>
        </tr>
    </table>
    <%--</contenttemplate>
    </asp:UpdatePanel>--%>
</asp:Content>
