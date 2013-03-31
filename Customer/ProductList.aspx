<%@ Page Language="VB" MasterPageFile="~/Master/CustomerMaster.master" AutoEventWireup="false"
    CodeFile="ProductList.aspx.vb" Inherits="Customer_ProductList" Title="ProductList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphCustomer" runat="Server">
    <table width="100%" class="text">
        <tr>
            <td align="center" class="heading">
                Product : &nbsp;<asp:TextBox ID="txtProduct" runat="server"></asp:TextBox>
                <asp:Button ID="btnSearch" runat="server" Text="Search" />
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Label ID="lblMessage" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
    <asp:DataList ID="dlProduct" runat="server" DataKeyField="ProductId" DataSourceID="odsProduct"
        RepeatColumns="3" RepeatDirection="Horizontal" CellSpacing="15" ItemStyle-BackColor="#eee6e6">
        <ItemTemplate>
            <asp:Panel CssClass="popupMenu" ID="PopupMenu" runat="server">
                <div style="border: 1px outset white; padding: 2px;">
                    <div>
                            <asp:HyperLink Text='<%# Eval("Price") %>' ID="lnkPrice" runat="server" /></div>
                    <div>
                            <asp:HyperLink Text="Details" ID="lnkDetails" runat="server" /></div>
                </div>
            </asp:Panel>
            <atk:HoverMenuExtender ID="hme2" runat="Server" HoverCssClass="popupHover" PopupControlID="PopupMenu"
                TargetControlID="Panel9" PopupPosition="Left" PopDelay="25" />
            <h5>
                <table>
                    <tr class="title_box">
                        <td colspan="2">
                            <strong>Product:</strong>&nbsp;&nbsp;
                            <asp:Label ID="ProductNameLabel" runat="server" Text='<%# Eval("ProductName") %>'>
                            </asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">
                            <asp:Panel ID="Panel9" runat="server" Width="80%">
                                <a href="ProductDetails.aspx?ID=<%#Eval("ProductId") %>">
                                    <asp:Image ID="img" runat="server" CssClass="imagezoom" ToolTip='<%# Eval("ProductName") %>' />
                                </a>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <strong>Price:</strong>
                        </td>
                        <td>
                            <asp:Image ID="imgRuppes" runat="server" Height="23px" ImageUrl="~/Images/Rupee.gif"
                                Width="20px" />
                            <asp:Label ID="PriceLabel" runat="server" Text='<%# Eval("Price") %>'></asp:Label><br />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">
                            <a href="ProductDetails.aspx?ID=<%#Eval("ProductId") %>">Details</a>
                        </td>
                    </tr>
                </table>
            </h5>
        </ItemTemplate>
    </asp:DataList><asp:ObjectDataSource ID="odsProduct" runat="server" DeleteMethod="Delete"
        InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="SearchProduct"
        TypeName="ds_ProductTableAdapters.ProductTableAdapter" UpdateMethod="Update">
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
        <SelectParameters>
            <asp:ControlParameter ControlID="txtProduct" Name="ProductName" PropertyName="Text"
                Type="String" DefaultValue="" />
            <asp:QueryStringParameter DefaultValue="0" Name="CompanyId" QueryStringField="COID"
                Type="Int64" />
            <asp:QueryStringParameter DefaultValue="0" Name="CategoryId" QueryStringField="CID"
                Type="Int64" />
            <asp:QueryStringParameter DefaultValue="0" Name="ParentCategoryId" QueryStringField="PCID"
                Type="Int64" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
