<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inventory.aspx.cs" Inherits="SalonWeb.Inventory" MasterPageFile="~/Master.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-body">
        <div class="row">
            <div class="col-12">
                <div class="card">
                    <div class="card-header" style=" border-radius: 20px;">
                        <h2 class="card-title">Product Category Record</h2>
                        <a class="heading-elements-toggle"><i class="la la-ellipsis-v font-medium-3"></i></a>
                    </div>
                    <div class="card-content collapse show">
                        <div class="card-body">
                            <div class="table-responsive-sm">
                                <asp:Repeater runat="server" ID="rptProductCategory" OnItemDataBound="rptProductCategory_ItemDataBound"
                                    OnItemCommand="rptProductCategory_ItemCommand">
                                    <HeaderTemplate>
                                        <table class="table">
                                            <thead>
                                                <tr class="gridHeader">
                                                    <th></th>
                                                    <th>Name</th>
                                                    <th>Notes</th>
                                                    <th></th>
                                                </tr>
                                            </thead>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td class="bg-blue  bg-lighten-5">
                                                <asp:LinkButton runat="server" CommandName="Edit" ID="lbtnEdit" Text="Edit"></asp:LinkButton>
                                                <asp:LinkButton runat="server" CommandName="Update" ID="lbtnUpdate" Text="Update"></asp:LinkButton>
                                                <asp:HiddenField ID="hdProductCategoryID" Value='<%# Eval("ProductCategoryID") %>' runat="server" />
                                            </td>
                                            <td class="bg-blue  bg-lighten-4">
                                                <asp:Label runat="server" ID="lblName" />
                                                <asp:TextBox runat="server" ID="txtName" CssClass="form-control" />
                                            </td>
                                            <td class="bg-blue  bg-lighten-5">
                                                <asp:Label runat="server" ID="lblNote" />
                                                <asp:TextBox runat="server" ID="txtNote" CssClass="form-control" />
                                            </td>
                                            <td class="bg-blue  bg-lighten-4">
                                                <asp:LinkButton ID="lbtnDelete" runat="server" CommandName="Delete" Text="Delete" OnClientClick="javascript:return confirm('Are you sure you want to Delete this Record ? (Yes/No)');">
                                                </asp:LinkButton>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <tr>
                                            <td class="bg-blue  bg-lighten-5">
                                                <asp:LinkButton ID="lbtnAdd" runat="server" CommandName="Add" Text="Add">
                                                </asp:LinkButton>
                                            </td>
                                            <td class="bg-blue  bg-lighten-4">
                                                <asp:TextBox runat="server" ID="txtName" CssClass="form-control" />
                                            </td>
                                            <td class="bg-blue  bg-lighten-5">
                                                <asp:TextBox runat="server" ID="txtNote" CssClass="form-control" />
                                            </td>
                                        </tr>
                                        </table>
                                    </FooterTemplate>
                                </asp:Repeater>
                                <asp:Label ID="lblProductCategoryError" runat="server" Text="" CssClass="text-center text-danger"></asp:Label>
                            </div>
                        </div>
                        <div class="card">
                            <div class="card-header" style=" border-radius: 20px;">
                                <h2 class="card-title">Product Record</h2>
                                <a class="heading-elements-toggle"><i class="la la-ellipsis-v font-medium-3"></i></a>
                            </div>
                            <div class="card-body">
                                <div class="table-responsive-sm">
                                    <asp:Repeater runat="server" ID="rptProduct" OnItemDataBound="rptProduct_ItemDataBound"
                                        OnItemCommand="rptProduct_ItemCommand">
                                        <HeaderTemplate>
                                            <table class="table">
                                                <thead>
                                                    <tr   class="gridHeader">
                                                        <th></th>
                                                        <th>Product Category Name</th>
                                                        <th>Product Name</th>
                                                        <th>Notes</th>
                                                        <th></th>
                                                    </tr>
                                                </thead>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <tr>
                                                <td class="bg-blue  bg-lighten-5">
                                                    <asp:LinkButton runat="server" CommandName="Edit" ID="lbtnEdit" Text="Edit"></asp:LinkButton>
                                                    <asp:LinkButton runat="server" CommandName="Update" ID="lbtnUpdate" Text="Update"></asp:LinkButton>
                                                    <asp:HiddenField ID="hdProductID" Value='<%# Eval("ProductID") %>' runat="server" />
                                                </td>
                                                <td class="bg-blue  bg-lighten-4">
                                                    <asp:Label runat="server" ID="lblProductCategory" />
                                                    <asp:DropDownList ID="ddlProductCategory" runat="server" CssClass="form-control">
                                                    </asp:DropDownList>
                                                </td>
                                                <td class="bg-blue  bg-lighten-5">
                                                    <asp:Label runat="server" ID="lblProductName" />
                                                    <asp:TextBox runat="server" ID="txtProductName" CssClass="form-control" />
                                                </td>
                                                <td class="bg-blue  bg-lighten-4">
                                                    <asp:Label runat="server" ID="lblNote" />
                                                    <asp:TextBox runat="server" ID="txtNote" CssClass="form-control" />
                                                </td>
                                                <td class="bg-blue  bg-lighten-5">
                                                    <asp:LinkButton ID="lbtnDeleteProduct" runat="server" CommandName="Delete" Text="Delete" OnClientClick="javascript:return confirm('Are you sure you want to Delete this Record ? (Yes/No)');">
                                                    </asp:LinkButton>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <tr>
                                                <td class="bg-blue  bg-lighten-5">
                                                    <asp:LinkButton ID="lbtnAdd" runat="server" CommandName="Add" Text="Add">
                                                    </asp:LinkButton>
                                                </td>
                                                <td class="bg-blue  bg-lighten-4">
                                                    <asp:DropDownList ID="ddlProductCategory" runat="server" CssClass="form-control">
                                                    </asp:DropDownList>
                                                </td>
                                                <td class="bg-blue  bg-lighten-5">
                                                    <asp:TextBox runat="server" ID="txtProductName" CssClass="form-control" />
                                                </td>
                                                <td class="bg-blue  bg-lighten-4">
                                                    <asp:TextBox runat="server" ID="txtNote" CssClass="form-control" />
                                                </td>
                                            </tr>
                                            </table>
                                        </FooterTemplate>
                                    </asp:Repeater>
                                    <asp:Label ID="lblProductError" runat="server" Text="" CssClass="text-center text-danger"></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>
