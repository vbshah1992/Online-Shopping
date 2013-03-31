<%@ Page Language="VB" MasterPageFile="~/Master/AdminMaster.master" AutoEventWireup="false"
    CodeFile="OrderDetail.aspx.vb" Inherits="Admin_OrderDetail" Title="Order Detail" Theme="AdminTheme" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphAdmin" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <contenttemplate>
    <h2 align="center" class="heading">
        Order Detail</h2>
    <table align="center" class="text">
    <tr>
            <td align="center" colspan="2">
                <asp:Label ID="lblMessage" runat="server" ForeColor="#C04000"></asp:Label>
            </td>
        </tr>        
        <tr>
            <td>
                Product</td>
            <td>
                <asp:DropDownList ID="ddlProduct" runat="server" AutoPostBack="True" Width="155px">
                </asp:DropDownList><asp:RequiredFieldValidator ID="rfvProduct" runat="server" ControlToValidate="ddlProduct"
                    ErrorMessage="Please select product." InitialValue="0" ValidationGroup="vgLogIn">*</asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td>
                Quantity</td>
            <td>
                <asp:TextBox ID="txtQuantity" runat="server"></asp:TextBox>&nbsp;
                <asp:RequiredFieldValidator ID="rfvQuantity" runat="server" ControlToValidate="txtQuantity"
                    ErrorMessage="Please enter quantity." ValidationGroup="vgLogIn">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revQuantity" runat="server" ControlToValidate="txtQuantity"
                    ErrorMessage="Please enter valid quantity. " ValidationExpression="[0-9, ]*"
                    ValidationGroup="vgLogIn">*</asp:RegularExpressionValidator></td>
        </tr>
        <tr>
            <td>
                Price</td>
            <td>
                <asp:Image ID="imgRuppes" runat="server" Height="15px" ImageUrl="~/Images/rup.png" Width="15px" />&nbsp;
                <asp:label ID="lblPrice" runat="server"></asp:label>&nbsp;
           </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="vgLogIn" />
                <asp:Button ID="btncancel" runat="server" Text="Cancel" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:ValidationSummary ID="vsOrder" runat="server" ValidationGroup="vgLogIn" ShowMessageBox="True" ShowSummary="False" />
            </td>
        </tr>
    </table>
    </contenttemplate>
    </asp:UpdatePanel>
</asp:Content>
