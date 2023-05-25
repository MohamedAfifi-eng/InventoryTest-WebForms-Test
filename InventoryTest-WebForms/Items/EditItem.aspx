<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditItem.aspx.cs" Inherits="InventoryTest_WebForms.Items.EditItem" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h1>Edit Item</h1>
        <asp:HiddenField ID="txtId" runat="server" />
        <div class="row">
            <div class="col-md-4">
                <div class="form-floating mb-3">
                    <asp:TextBox runat="server" type="text" class="form-control" ID="txtName" placeholder="name@example.com"></asp:TextBox>
                    <label for="MainContent_txtName">Item Name</label>
                    <asp:RequiredFieldValidator ControlToValidate="txtName" ValidationGroup="G1" CssClass="text-danger" ID="ValidatorItemNameRequired" runat="server" ErrorMessage="Item Name Is Required"></asp:RequiredFieldValidator>
                </div>
                <div class="form-floating mb-3">
                    <asp:TextBox runat="server" type="text" class="form-control" ID="txtUnitPrice" placeholder="name@example.com"></asp:TextBox>
                    <label for="MainContent_txtUnitPrice">Unit Price</label>
                    <asp:RequiredFieldValidator ControlToValidate="txtUnitPrice" ValidationGroup="G1" CssClass="text-danger" ID="ValidatortxtUnitPriceRequired" runat="server" ErrorMessage="Item Unit Price Is Required"></asp:RequiredFieldValidator>
                </div>
                <div class="form-floating mb-3">
                    <asp:TextBox runat="server" type="text" class="form-control" ID="txtAvailableUnits" placeholder="name@example.com"></asp:TextBox>
                    <label for="MainContent_txtAvailableUnits">Available Units in Stock</label>
                </div>
                <p>
                    <asp:Button runat="server" ID="btnSave" Text="Save" CssClass="btn btn-primary" ValidationGroup="G1" OnClick="btnSave_Click"></asp:Button>
                    <a class="btn btn-secondary" href="List.aspx">Cancel</a>
                </p>
            </div>
        </div>
    </div>

</asp:Content>
