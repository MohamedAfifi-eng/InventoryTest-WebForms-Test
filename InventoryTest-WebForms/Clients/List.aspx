<%@ Page Title="Clients List" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="InventoryTest_WebForms.Clients.List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h1 class="text-center">Clients List</h1>
        <p>
            <a class="btn btn-info" href="CreateClient.aspx">Add New Client</a>
        </p>
        <div class="row">
            <div class="col-12">
                <asp:GridView ID="gvClientsList" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-hover table-striped text-center">
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="ID"></asp:BoundField>
                        <asp:BoundField DataField="FullName" HeaderText="Client Name"></asp:BoundField>
                        <asp:BoundField DataField="Phone" HeaderText="Phone"></asp:BoundField>
                        <asp:BoundField DataField="Address" HeaderText="Address"></asp:BoundField>
                        <asp:BoundField DataField="Account" HeaderText="Account Balance"></asp:BoundField>
                        <asp:HyperLinkField DataNavigateUrlFields="Id" DataNavigateUrlFormatString="Edit.aspx?id={0}" NavigateUrl="Edit.aspx" Text="Edit">
                            <ItemStyle CssClass="btn btn-outline-info"></ItemStyle>
                        </asp:HyperLinkField>
                    </Columns>
                    
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
