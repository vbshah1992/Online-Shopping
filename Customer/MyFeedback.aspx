<%@ Page Language="VB" MasterPageFile="~/Master/CustomerMaster.master" AutoEventWireup="false"
    CodeFile="MyFeedback.aspx.vb" Inherits="Customer_MyFeedback" Theme="CustomerTheme" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphCustomer" runat="Server">
    <table align="center" width="100%">
        <tr>
            <td align="center">
            <h2 class="heading">My Feedback</h2>
            </td>
        </tr>
        <tr>
            <td id="tdCount" align="center">
                <asp:Label ID="lblCount" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Black"></asp:Label></td>
        </tr>
        <tr>
            <td align="left">
                <asp:LinkButton ID="lnkAdd" runat="server">Add</asp:LinkButton></td>
        </tr>
        <tr>
            <td align="center">
                <asp:GridView ID="gvMyFeedback" runat="server" AllowPaging="True" AllowSorting="True"
                    AutoGenerateColumns="False" DataKeyNames="FeedbackId" DataSourceID="odsMyFeedback">
                    <Columns>
                        <asp:BoundField DataField="Feedback" HeaderText="Feedback" SortExpression="Feedback" />
                        <asp:BoundField DataField="FeedbackDate" HeaderText="FeedbackDate" SortExpression="FeedbackDate"
                            DataFormatString="{0:dd-MMM-yyyy}" />
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
    <asp:ObjectDataSource ID="odsMyFeedback" runat="server" DeleteMethod="Delete" InsertMethod="Insert"
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataByCustomer"
        TypeName="ds_FeedbackTableAdapters.FeedbackTableAdapter" UpdateMethod="Update">
        <DeleteParameters>
            <asp:Parameter Name="Original_FeedbackId" Type="Int64" />
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="Feedback" Type="String" />
            <asp:Parameter Name="FeedbackDate" Type="DateTime" />
            <asp:Parameter Name="CustomerId" Type="Int64" />
            <asp:Parameter Name="Original_FeedbackId" Type="Int64" />
        </UpdateParameters>
        <InsertParameters>
            <asp:Parameter Name="Feedback" Type="String" />
            <asp:Parameter Name="FeedbackDate" Type="DateTime" />
            <asp:Parameter Name="CustomerId" Type="Int64" />
        </InsertParameters>
        <SelectParameters>
            <asp:QueryStringParameter DefaultValue="0" Name="CustomerId" QueryStringField="ID"
                Type="Int64" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
