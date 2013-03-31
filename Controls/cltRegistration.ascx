<%@ Control Language="VB" AutoEventWireup="false" CodeFile="cltRegistration.ascx.vb"
    Inherits="Controls_cltRegistration" %>
<asp:UpdatePanel ID="Update1" runat="server">
    <ContentTemplate>
        <div>
            <asp:Panel ID="Panel2" runat="server" CssClass="collapsePanelHeader" Height="30px"
                Width="275px">
                <div style="padding: 5px; cursor: pointer; vertical-align: middle;">
                    <div style="float: left; vertical-align: middle;">
                        <asp:ImageButton ID="Image1" runat="server" ImageUrl="~/Images/plus.png" AlternateText="(Fill Details...)"
                            Height="14px" Width="18px" />
                    </div>
                    <div style="float: left; margin-left: 20px;">
                    </div>
                    <div style="float: left;">
                        Registration</div>
                </div>
            </asp:Panel>
            <asp:Panel ID="Panel1" runat="server" CssClass="collapsePanel" Height="1px" Width="100%"
                BackColor="DarkGray">
                <br />
                <table width="100%" class="text">
                    <tr valign="top">
                        <td style="width: 270px; height: 250px">
                            <table align="center">
                                <tr valign="top">
                                    <td align="center" colspan="2">
                                        <asp:Label ID="lblMessage" runat="server" ForeColor="#C04000"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        First Name&nbsp;</td>
                                    <td>
                                        <asp:TextBox ID="txtFirstName" runat="server" Width="155px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" ControlToValidate="txtFirstName"
                                            ErrorMessage="Please enter first name." ValidationGroup="vgRegistration">*</asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="revFirstName" runat="server" ControlToValidate="txtFirstName"
                                            ErrorMessage="Please enter valid first name." ValidationExpression="[A-Z,a-z, ]*"
                                            ValidationGroup="vgRegistration">*</asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Last Name</td>
                                    <td>
                                        <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>&nbsp;
                                        <asp:RequiredFieldValidator ID="rfvLastName" runat="server" ControlToValidate="txtLastName"
                                            ErrorMessage="Please enter last name." ValidationGroup="vgRegistration">*</asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="revLastName" runat="server" ControlToValidate="txtLastName"
                                            ErrorMessage="Please enter valid last name." ValidationExpression="[A-Z,a-z, ]*"
                                            ValidationGroup="vgRegistration">*</asp:RegularExpressionValidator></td>
                                </tr>
                                <tr>
                                    <td>
                                        Address</td>
                                    <td>
                                        <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine" Width="155px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvAddress" runat="server" ControlToValidate="txtAddress"
                                            ErrorMessage="Please enter address." ValidationGroup="vgRegistration">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td  style="width: 270px; height: 250px">
                            <table>
                                <tr valign="top" style="height: 50px">
                                    <td>
                                        Country
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlCountry" runat="server" AutoPostBack="True" Width="155px">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="rfvCountry" runat="server" ControlToValidate="ddlCountry"
                                            ErrorMessage="Please select country." InitialValue="0" ValidationGroup="vgRegistration">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr style="height: 50px">
                                    <td>
                                        State
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlState" runat="server" AutoPostBack="True" Width="155px">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="rfvState" runat="server" ControlToValidate="ddlState"
                                            ErrorMessage="Please select state." InitialValue="0" ValidationGroup="vgRegistration">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr style="height: 50px">
                                    <td>
                                        City</td>
                                    <td>
                                        <asp:DropDownList ID="ddlCity" runat="server" AutoPostBack="True" Width="155px">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="rfvCity" runat="server" ControlToValidate="ddlCity"
                                            ErrorMessage="Please select city." InitialValue="0" ValidationGroup="vgRegistration">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr style="height: 50px">
                                    <td colspan="2" align="right">
                                        <asp:Button ID="btnSave" runat="server" Text="Registration" ValidationGroup="vgRegistration" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td style="width: 270px; height: 250px">
                            <table>
                                <tr valign="top" style="height: 50px">
                                    <td>
                                        Pincode
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPincode" runat="server" Width="155px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvPincode" runat="server" ControlToValidate="txtPincode"
                                            ErrorMessage="Please enter pin code." ValidationGroup="vgRegistration">*</asp:RequiredFieldValidator>&nbsp;
                                        <asp:RegularExpressionValidator ID="revPincode" runat="server" ControlToValidate="txtPincode"
                                            ErrorMessage="Please enter valid pin code." ValidationExpression="[0-9, ]*" ValidationGroup="vgRegistration">*</asp:RegularExpressionValidator></td>
                                </tr>
                                <tr style="height: 50px">
                                    <td>
                                        Phone Number</td>
                                    <td>
                                        <asp:TextBox ID="txtPhoneNumber" runat="server" Width="155px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvPhoneNumber" runat="server" ControlToValidate="txtPhoneNumber"
                                            ErrorMessage="Please enter phone number" ValidationGroup="vgRegistration">*</asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="revPhoneNumber" runat="server" ControlToValidate="txtPhoneNumber"
                                            ErrorMessage="Please enter valid phone number" ValidationExpression="\w{10}"
                                            ValidationGroup="vgRegistration">*</asp:RegularExpressionValidator></td>
                                </tr>
                                <tr style="height: 50px">
                                    <td>
                                        Contact Number</td>
                                    <td>
                                        <asp:TextBox ID="txtContactNumber" runat="server" Width="155px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvContactNumber" runat="server" ControlToValidate="txtContactNumber"
                                            ErrorMessage="Please enter contact Number." ValidationGroup="vgRegistration">*</asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="revContactNumber" runat="server" ErrorMessage="Please enter valid contact number"
                                            ValidationExpression="\w{10}" ValidationGroup="vgRegistration" ControlToValidate="txtContactNumber">*</asp:RegularExpressionValidator></td>
                                </tr>
                                <tr style="height: 50px">
                                    <td colspan="2" align="left">
                                        <asp:Button ID="btncancel" runat="server" Text="Cancel" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td  style="width: 270px; height: 250px">
                            <table>
                                <tr valign="top">
                                    <td>
                                        Email Id</td>
                                    <td>
                                        <asp:TextBox ID="txtEmailId" runat="server" Width="155px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvEmailId" runat="server" ControlToValidate="txtEmailId"
                                            ErrorMessage="Please enter email id." ValidationGroup="vgRegistration">*</asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="revEmailId" runat="server" ControlToValidate="txtEmailId"
                                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ErrorMessage="Please enter valid  email  id."
                                            ValidationGroup="vgRegistration">*</asp:RegularExpressionValidator></td>
                                </tr>
                                <tr>
                                    <td>
                                        Password</td>
                                    <td>
                                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="155px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword"
                                            ErrorMessage="Please enter password." ValidationGroup="vgRegistration">*</asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="revPassword" runat="server" ControlToValidate="txtPassword"
                                            ErrorMessage="Please enter password between 4 to 20 characters." ValidationExpression="\w{4,20}"
                                            ValidationGroup="vgRegistration">*</asp:RegularExpressionValidator></td>
                                </tr>
                                <tr>
                                    <td>
                                        Confirm Password</td>
                                    <td>
                                        <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" Width="155px"></asp:TextBox>
                                        <asp:CompareValidator ID="cvConfirmPassword" runat="server" ControlToCompare="txtPassword"
                                            ControlToValidate="txtConfirmPassword" ErrorMessage="Password and confirm password does not match."
                                            ValidationGroup="vgRegistration">*</asp:CompareValidator></td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:ValidationSummary ID="vsAdmin" runat="server" ValidationGroup="vgRegistration" ShowMessageBox="True"
                                            ShowSummary="False" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
        <atk:CollapsiblePanelExtender ID="cpeDemo" runat="Server" TargetControlID="Panel1"
            ExpandControlID="Panel2" CollapseControlID="Panel2" Collapsed="True" TextLabelID="Label1"
            ImageControlID="Image1" ExpandedImage="~/Images/plus.png" CollapsedImage="~/Images/plus.png"
            SuppressPostBack="true" />
    </ContentTemplate>
</asp:UpdatePanel>
