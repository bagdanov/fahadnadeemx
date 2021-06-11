<%@ Page Title="" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeBehind="StockGrid.aspx.cs" Inherits="SalonWeb.StockGrid" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>
        function newStock() {
            location.replace("StockForm.aspx")
        }
        function editStock(id) {
            location.replace("StockForm.aspx?StockID=" + id);
        }
    </script>
    <script src="app-assets/js/jquery-ui.js"></script>
    <link href="app-assets/css/jquery-ui-timepicker-addon.css" rel="stylesheet" />
    <script src="app-assets/js/jquery-ui-timepicker-addon.js"></script>
    <script>
        $(function () {
            $(".datepicker").datepicker({ dateFormat: 'dd/mm/yy' });
        });
    </script>
    <div class="content-body">
        <div class="row">
            <div class="col-12"> <div class="card">
                    <div class="card-header" style=" border-radius: 20px;">
                        <h2 class="card-title">Stock Record</h2>
                        <a class="heading-elements-toggle"><i class="la la-ellipsis-v font-medium-3"></i></a>
                    </div>
                    <div class="col-2 col-sm-1 fonticon-container">
                        <div class="fonticon-wrap" style="max-height: 6px">
                            <i class="ft-plus-circle" onclick="newStock()"></i>
                        </div>
                    </div>
                        <div class="card-content collapse show">
                            <div class="card-body">
                                <div class="table-responsive-sm">
                                    <asp:Repeater runat="server" ID="rptStock" OnItemDataBound="rptStock_ItemDataBound"
                                        OnItemCommand="rptStock_ItemCommand">
                                        <HeaderTemplate>
                                            <table class="table">
                                                <thead>
                                                    <tr   class="gridHeader">
                                                        <th></th>
                                                        <th>Product Category Name</th>
                                                        <th>Product Name</th>
                                                        <th>Date</th>
                                                        <th class="rightAmount">Quantity</th>
                                                        <th class="rightAmount">Price</th>
                                                        <th></th>
                                                    </tr>
                                                </thead>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <tr>
                                                <td class="bg-lighten-5">
                                                    <a><i runat="server" id="btnEdit" onclick="editStock()" style="color: #1E9FF2; font-style: normal">Edit</i></a>
                                                </td>
                                                <td class="bg-blue  bg-lighten-4">
                                                    <asp:Label runat="server" ID="lblProductCategoryName" />
                                                </td>
                                                <td class="bg-lighten-5">
                                                    <asp:Label runat="server" ID="lblProductName" />
                                                </td>
                                                <td class="bg-blue  bg-lighten-4">
                                                    <asp:Label runat="server" ID="lblDate" />
                                                </td>
                                                <td class="rightAmount bg-lighten-5">
                                                    <asp:Label runat="server" ID="lblQuantity" />
                                                </td>
                                                <td class="rightAmount bg-blue  bg-lighten-4">
                                                    <asp:Label runat="server" ID="lblPrice" />
                                                </td>
                                                <td class="icon bg-lighten-5">
                                                    <asp:HiddenField ID="hdIDStock" Value='<%# Eval("StockID") %>' runat="server" />
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

