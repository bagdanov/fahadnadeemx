<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductService.aspx.cs" Inherits="SalonWeb.ProductService" MasterPageFile="~/Master.master"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>
        function newProductService() {
            location.replace("ProductServiceForm.aspx")
        }
        function editProductService(id) {
            location.replace("ProductServiceForm.aspx?ProductServiceID=" + id);
        }
    </script>
    <div class="content-body">
        <div class="row">
            <div class="col-12">
                <div class="card">
                    <div class="card-header">
                        <h4 class="card-title">Product Service Record</h4>
                        <a class="heading-elements-toggle"><i class="la la-ellipsis-v font-medium-3"></i></a>
                        <div class="heading-elements">
                            <ul class="list-inline mb-0">
                                <li><a data-action="collapse"><i class="ft-minus"></i></a></li>
                                <li><a data-action="reload"><i class="ft-rotate-cw"></i></a></li>
                                <li><a data-action="expand"><i class="ft-maximize"></i></a></li>
                                <li><a data-action="close"><i class="ft-x"></i></a></li>
                            </ul>
                        </div>
                    </div>
                    <div class="col-md-4 col-sm-6 col-12 fonticon-container">
                        <div class="fonticon-wrap">
                            <i class="ft-plus-circle" onclick="newEmployee()"></i>
                        </div>
                    </div>
                        <div class="card-content collapse show">
                            <div class="card-body">
                                <div class="table-responsive">
                                    <asp:Repeater runat="server" ID="rptProductService" OnItemDataBound="rptProductService_ItemDataBound" OnItemCommand="rptProductService_ItemCommand">
                                        <HeaderTemplate>
                                            <table class="table">
                                                <thead>
                                                    <tr>
                                                        <th></th>
                                                        <th>Service</th>
                                                        <th>Service Type</th>
                                                        <th>Product Category</th>
                                                        <th>Product</th>
                                                        <th>Quantity</th>
                                                        <th>Notes</th>
                                                        <th></th>
                                                    </tr>
                                                </thead>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <tr>
                                                <td class="icon">
                                                    <div class="col-md-4 col-sm-6 col-12 fonticon-container">
                                                        <i runat="server" id="btnEdit" class="ft-edit-2" onclick="editProductService()"></i>
                                                    </div>
                                                </td>
                                                <td>
                                                    <asp:Label runat="server" ID="lblService" />
                                                </td>
                                                <td>
                                                    <asp:Label runat="server" ID="lblServiceType" />
                                                </td>
                                                <td>
                                                    <asp:Label runat="server" ID="lblProductCategory" />
                                                </td>
                                                <td>
                                                    <asp:Label runat="server" ID="lblProduct" />
                                                </td>
                                                <td>
                                                    <asp:Label runat="server" ID="lblQuantity" />
                                                </td>
                                                <td>
                                                    <asp:Label runat="server" ID="lblNotes" />
                                                </td>
                                               <td class="icon">
                                                    <asp:HiddenField ID="hdIDProductService" Value='<%# Eval("ProductServiceID") %>' runat="server" />
                                                        <asp:LinkButton ID="lbtnDelete" runat="server" CommandName="Delete" Text="Delete" OnClientClick="javascript:return confirm('Are you sure you want to Delete this Record ? (Yes/No)');">
                                                        </asp:LinkButton>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            </table>
                                        </FooterTemplate>
                                    </asp:Repeater>
                                </div>
                            </div>
                        </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

