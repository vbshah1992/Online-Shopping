<%@ Page Language="VB" MasterPageFile="~/Master/CustomerMaster.master" AutoEventWireup="false"
    CodeFile="MyProfile.aspx.vb" Inherits="Customer_MyProfile" Title="My Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphCustomer" runat="Server">
    <h2 align="center" class="heading">
        My Profile</h2>
    <table align="center"  class="text">
        <tr>
            <td align="center" colspan="2">
                <asp:Label ID="lblMessage" runat="server" ForeColor="black"></asp:Label>
                </td>
                <td align="right">
                <asp:LinkButton ID="lnkEditProfile" Text="EditProfile" runat="server"></asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td>
                First Name :
            </td>
            <td>
                <asp:Label ID="lblFirstName" runat="server" ForeColor="black"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                Last Name :
            </td>
            <td>
                <asp:Label ID="lblLastName" runat="server" ForeColor="black"></asp:Label>&nbsp;
            </td>
        </tr>
        <tr>
            <td>
                Address :
            </td>
            <td>
                <asp:Label ID="lblAddress" runat="server" ForeColor="black"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                City :
            </td>
            <td>
                <asp:Label ID="lblCity" runat="server" ForeColor="black">
                </asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                Pincode :
            </td>
            <td>
                <asp:Label ID="lblPincode" runat="server" ForeColor="black"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                Phone Number :
            </td>
            <td>
                <asp:Label ID="lblPhoneNumber" runat="server" ForeColor="black"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                Contact Number :
            </td>
            <td>
                <asp:Label ID="lblContactNumber" runat="server" ForeColor="black"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                Email Id :
            </td>
            <td>
                <asp:Label ID="lblEmailId" runat="server" ForeColor="black"></asp:Label>
            </td>
        </tr>        
        <tr>
            <td colspan="2" align="center">
                &nbsp;<asp:Button ID="btncancel" runat="server" Text="Back" />
            </td>
        </tr>
    </table>
</asp:Content>
