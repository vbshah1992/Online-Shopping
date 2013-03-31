<%@ Page Language="VB" MasterPageFile="~/Master/AdminMaster.master" AutoEventWireup="false"
    CodeFile="Product.aspx.vb" Inherits="Admin_Product" Title="Product" Theme="AdminTheme" %>

<asp:Content ContentPlaceHolderID="cphAdmin" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <contenttemplate>
    <h2 align="center" class="heading">
       Product</h2>
    <table align="center" class="text">
        <tr>
            <td align="center" colspan="2">
                <asp:Label ID="lblMessage" runat="server" ForeColor="#C04000"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                Product Name&nbsp;</td>
            <td>
                <asp:TextBox ID="txtProductName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvProductName" runat="server" ControlToValidate="txtProductName"
                    ErrorMessage="Please enter product." ValidationGroup="vgLogIn">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revProductName" runat="server" ControlToValidate="txtProductName"
                    ErrorMessage="Please enter valid product." ValidationExpression="[A-Z,a-z, ]*"
                    ValidationGroup="vgLogIn">*</asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>
                Price</td>
            <td>
                <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>&nbsp;
                <asp:RequiredFieldValidator ID="rfvPrice" runat="server" ControlToValidate="txtPrice"
                    ErrorMessage="Please enter price." ValidationGroup="vgLogIn">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revPrice" runat="server" ControlToValidate="txtPrice"
                    ErrorMessage="Please enter valid price." ValidationExpression="[0-9,., ]*"
                    ValidationGroup="vgLogIn">*</asp:RegularExpressionValidator>
                </td>
        </tr>
        <tr>
            <td>
                Brief Description</td>
            <td>
                <asp:TextBox ID="txtBriefDescription" runat="server" TextMode="MultiLine" Width="150px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvBriefDescription" runat="server" ControlToValidate="txtBriefDescription"
                    ErrorMessage="Please enter brief description." ValidationGroup="vgLogIn">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                Description</td>
            <td>
                <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Width="150px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvDescription" runat="server" ControlToValidate="txtDescription"
                    ErrorMessage="Please enter description." ValidationGroup="vgLogIn">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                Category</td>
            <td>
                <asp:DropDownList ID="ddlCategory" runat="server" AutoPostBack="True" Width="155px">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvCategory" runat="server" ControlToValidate="ddlCategory"
                    ErrorMessage="Please select Category." InitialValue="0" ValidationGroup="vgLogIn">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                Company</td>
            <td>
                <asp:DropDownList ID="ddlCompany" runat="server" AutoPostBack="True" Width="155px">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvCompany" runat="server" ControlToValidate="ddlCompany"
                    ErrorMessage="Please select Company." InitialValue="0" ValidationGroup="vgLogIn">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                Is Available</td>
            <td>
                <asp:CheckBox ID="chkIsAvailable" runat="server" /></td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="vgLogIn" />
                <asp:Button ID="btncancel" runat="server" Text="Cancel" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:ValidationSummary ID="vsAdmin" runat="server" ValidationGroup="vgLogIn" ShowMessageBox="True" ShowSummary="False" />
            </td>
        </tr>
    </table>
    </contenttemplate>
    </asp:UpdatePanel>
</asp:Content>
