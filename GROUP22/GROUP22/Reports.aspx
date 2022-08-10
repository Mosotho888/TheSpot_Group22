<%@ Page Title="" Language="C#" MasterPageFile="~/Employee.Master" AutoEventWireup="true" CodeBehind="Reports.aspx.cs" Inherits="GROUP22.Reports" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div align="center">
        <h2 style="text-align:center">
            Reports
        </h2>
        <br /><br />
       <asp:Label ID="Label1" runat="server" Text="Employee Email:"></asp:Label>
        &nbsp;<asp:Label ID="lblEmployeeEmail" runat="server"></asp:Label>
        <br /><br />
       <asp:RadioButton ID="rbAscending" runat="server" GroupName="rb" />
       <asp:Label ID="Label2" runat="server" Text="Ascending"></asp:Label>
       <asp:RadioButton ID="rbDescending" runat="server" GroupName="rb" />
       <asp:Label ID="Label3" runat="server" Text="Descending"></asp:Label>
       <br /><br />
       <asp:Label ID="Label5" runat="server" Text="Search: "></asp:Label>
       <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
       <asp:Button ID="btnLoad" runat="server" Text="Load" OnClick="btnLoad_Click" />
       <br /><br />
       <asp:Label ID="lblInfo" runat="server" Text=""></asp:Label>
        <br /><br />
        <asp:GridView ID="gvReport" runat="server" Height="70px" Width="110px" AutoGenerateColumns="False" BorderStyle="Solid" GridLines="Vertical" HorizontalAlign="Center">
            <AlternatingRowStyle Font-Bold="True" Height="70px" HorizontalAlign="Center" />
            <Columns>
                <asp:BoundField DataField="orderId" HeaderText="OrderId">
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle Font-Bold="True" HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="productId" HeaderText="ProductId">
                <HeaderStyle HorizontalAlign="Center" Width="110px" />
                <ItemStyle Font-Bold="True" HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="customerId" HeaderText="CustomerId">
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle Font-Bold="True" HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="productName" HeaderText="ProductName">
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle Font-Bold="True" HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="productPrice" HeaderText="ProductPrice">
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle Font-Bold="True" HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="productQuantity" HeaderText="ProductQuantity">
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle Font-Bold="True" HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="totalPrice" HeaderText="TotalPrice">
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle BorderStyle="Solid" Font-Bold="True" HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="dateOfOrder" HeaderText="DateOfOrder">
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle Font-Bold="True" HorizontalAlign="Center" />
                </asp:BoundField>
            </Columns>
            <EditRowStyle BorderStyle="Solid" Font-Bold="True" Font-Overline="False" Font-Underline="False" />
            <HeaderStyle Font-Bold="False" Height="70px" HorizontalAlign="Center" Width="110px" />
        </asp:GridView>
       
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
       
        <asp:Label ID="lblGrand" runat="server" Text="Grand Total: " align="right"></asp:Label>
        <asp:Label ID="lblTotalAmount" runat="server" Text="" Width="100px"></asp:Label>

        <br />
        <br />
        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
    </div>
</asp:Content>
