<%@ Page Title="Items" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="InventoryTest_WebForms.Items.List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <div class="container">
            <div class="row">
                <div class="col-12">
                    <h1 class="text-center my-5">Items List</h1>
                    
                    <a href="CreateItem.aspx" class="btn btn-info">Add New Item</a>
                    <asp:GridView CssClass="table table-hover table-striped table-bordered text-center" runat="server" AutoGenerateColumns="False" ID="gvList">
                        <Columns>
                            <asp:BoundField DataField="Id" HeaderText="ID"></asp:BoundField>
                            <asp:BoundField DataField="Name" HeaderText="Name"></asp:BoundField>
                            <asp:BoundField DataField="UnitPrice" HeaderText="Unit Price"></asp:BoundField>
                            <asp:BoundField DataField="AvailableUnits" HeaderText="Available Stock"></asp:BoundField>
                            <asp:HyperLinkField DataNavigateUrlFields="Id" DataNavigateUrlFormatString="EditItem.aspx?id={0}" NavigateUrl="~/Items/EditItem.aspx" Text="Edit"></asp:HyperLinkField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </main>
</asp:Content>
