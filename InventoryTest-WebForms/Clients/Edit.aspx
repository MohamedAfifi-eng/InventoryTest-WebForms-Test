<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="InventoryTest_WebForms.Clients.Edit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h1 class="text-center">Edit Client</h1>
        <div class="row">
            <div class="col-md-4">
                <asp:HiddenField ID="txtId" runat="server" />
                <div class="form-floating mb-3">
                    <asp:TextBox runat="server" type="text" class="form-control" ID="txtFullName" placeholder="n"></asp:TextBox>
                    <label for="floatingInput">Full Name</label>
                </div>
                <div class="form-floating mb-3">
                    <asp:TextBox runat="server" type="text" class="form-control" ID="txtPhone" placeholder="n"></asp:TextBox>
                    <label for="floatingInput">Phone</label>
                </div>
                <div class="form-floating mb-3">
                    <asp:TextBox runat="server" type="text" class="form-control" ID="txtAddress" placeholder="n"></asp:TextBox>
                    <label for="floatingInput">Address</label>
                </div>
                <div class="form-floating mb-3">
                    <asp:TextBox runat="server" type="text" class="form-control" ID="txtAccount" placeholder="n"></asp:TextBox>
                    <label for="floatingInput">Account</label>
                </div>
                <p>
                    <asp:Button runat="server" ID="btnSave" CssClass="btn btn-primary" Text="Save" OnClick="btnSave_Click" />
                    <a href="List.aspx" class="btn btn-secondary">Cancel</a>
                </p>
            </div>
        </div>
    </div>

</asp:Content>
