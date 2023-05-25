<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateInvoice.aspx.cs" Inherits="InventoryTest_WebForms.Invoices.CreateInvoice" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-12">
                <div class="Section">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <div class="row g-3">
                                <div class="col-auto">
                                    <label for="txtSearch" class="visually-hidden">Email</label>
                                    <asp:TextBox runat="server" ID="txtSearch" class="form-control" placeholder="Please Enter Client Phone No."/>
                                </div>
                                <div class="col-auto">
                                    <asp:Button runat="server" ID="btnSearch" Text="Search" class="btn btn-primary mb-3" OnClick="btnSearch_Click"></asp:Button>
                                </div>
                                <div class="col-auto">
                                    <asp:DropDownList ID="drplstClients" CssClass="form-select" runat="server"></asp:DropDownList>
                                </div>
                                <div class="col-auto">
                                    <asp:Button runat="server" ID="btnGetClient" Text="Get Client Informations" class="btn btn-primary mb-3" OnClick="drplstClients_SelectedIndexChanged"></asp:Button>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4 mb-3">
                                    <label for="exampleFormControlInput1" class="form-label">ID</label>
                                    <asp:TextBox runat="server" ReadOnly="true" class="form-control" ID="txtClientID" />
                                </div>
                                <div class="col-md-4 mb-3">
                                    <label for="exampleFormControlInput1" class="form-label">Client Name</label>
                                    <asp:TextBox runat="server" ReadOnly="true" class="form-control" ID="txtClientFullName" />
                                </div>
                                <div class="col-md-4 mb-3">
                                    <label for="exampleFormControlInput1" class="form-label">Client Phone</label>
                                    <asp:TextBox runat="server" ReadOnly="true" class="form-control" ID="txtClientPhone" />
                                </div>
                                <div class="col-md-12 mb-3">
                                    <label for="exampleFormControlInput1" class="form-label">Client Address</label>
                                    <asp:TextBox runat="server" ReadOnly="true" class="form-control" ID="txtClientAddress" />
                                </div>
                            </div>

                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div class="Section">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <div class="row g-3">
                                <div class="col-auto">
                                    <asp:TextBox runat="server" ID="txtItemSearch" class="form-control" placeholder="Please Enter Item Name" />
                                </div>
                                <div class="col-auto">
                                    <asp:Button runat="server" ID="btnItemSearch" class="btn btn-primary mb-3" Text="Search for Item" OnClick="btnItemSearch_Click" />
                                </div>
                                <div class="col-auto">
                                    <asp:DropDownList ID="drpItems" CssClass="form-select" runat="server"></asp:DropDownList>
                                </div>
                                <div class="col-auto">
                                    <asp:Button runat="server" ID="btnGetItem" Text="Get Item Informations" class="btn btn-primary mb-3" OnClick="btnGetItem_Click"></asp:Button>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-3">
                                    <label class="form-label">Item ID</label>
                                    <asp:TextBox runat="server" ReadOnly="true" ID="txtItemId" CssClass="form-control" />
                                </div>
                                <div class="col-md-3">
                                    <label class="form-label">Item Name</label>
                                    <asp:TextBox runat="server" ReadOnly="true" ID="txtItemName" CssClass="form-control" />
                                </div>
                                <div class="col-md-3">
                                    <label class="form-label">Item Price</label>
                                    <asp:TextBox runat="server" ReadOnly="true" ID="txtItemPrice" CssClass="form-control" />
                                </div>
                                <div class="col-md-3">
                                    <label class="form-label">Item Available Quantity</label>
                                    <asp:TextBox runat="server" ReadOnly="true" ID="txtItemAvailable" CssClass="form-control" />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-3">
                                    <label class="form-label">Quantity</label>
                                    <asp:TextBox runat="server" TextMode="Number" min="1" value="1" max="100" ID="txtRequestedQuantity" CssClass="form-control" OnTextChanged="txtRequestedQuantity_TextChanged" />
                                </div>
                                <div class="col-md-3">
                                    <label class="form-label">Item Total Price</label>
                                    <asp:TextBox runat="server" ReadOnly="true" ID="txtTotalPrice" CssClass="form-control" />
                                </div>
                                <div class="col-md-3">
                                    <asp:Button runat="server" ID="btnAddItem" CssClass="btn btn-primary" Text="Add" OnClick="btnAddItem_Click" />
                                </div>
                            </div>
                            <div class="row mt-2">
                                <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover table-striped table-bordered text-center" AutoGenerateColumns="False">
                                    <Columns>
                                        <asp:BoundField DataField="ItemID" FooterText="Item ID"></asp:BoundField>
                                        <asp:BoundField DataField="ItemName" HeaderText="Item Name"></asp:BoundField>
                                        <asp:BoundField DataField="ItemPrice" HeaderText="Item Price"></asp:BoundField>
                                        <asp:BoundField DataField="Quantity" HeaderText="Quantity"></asp:BoundField>
                                        <asp:BoundField DataField="TotalPrice" HeaderText="Total Price"></asp:BoundField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                            <div class="row">
                                <div class="col-md-3">
                                    <label class="form-label">Invoice Total Price</label>
                                    <asp:TextBox runat="server" ReadOnly="true" value="0" ID="txtInvoiceTotalPrice" CssClass="form-control" />
                                </div>
                                <div class="col-md-3">
                                    <label class="form-label">Invoice Discount Price</label>
                                    <asp:TextBox runat="server" TextMode="Number" min="0" value="0" ID="txtInvoiceDiscountPrice" CssClass="form-control" OnTextChanged="txtInvoiceDiscountPrice_TextChanged" />
                                </div>
                                <div class="col-md-3">
                                    <label class="form-label">Invoice Disount Percentage</label>
                                    <asp:TextBox runat="server" TextMode="Number" min="0" value="0" ID="txtInvoiceDiscountPercentage" CssClass="form-control" OnTextChanged="txtInvoiceDiscountPrice_TextChanged" />
                                </div>
                                <div class="col-md-3">
                                    <label class="form-label">Invoice Net Price</label>
                                    <asp:TextBox runat="server" ReadOnly="true" value="0" ID="txtInvoiceNetPrice" CssClass="form-control" />
                                </div>
                            </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                </div>
            </div>
        </div>
        <asp:Button runat="server" ID="BtnCreateInvoice" Text="Create Invoice" CssClass="btn btn-success" OnClick="BtnCreateInvoice_Click" />

    </div>
</asp:Content>
<asp:Content runat="server" id="content2" ContentPlaceHolderID="Css" >
    <link href="../Content/CreateInvoice.css" rel="stylesheet" type="text/css" />
</asp:Content>