<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExpenseGrid.aspx.cs" MasterPageFile="~/Master.master" Inherits="SalonWeb.ExpenseGrid" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
            <div class="col-12">
                <div class="card">
                    <div class="card-header" style=" border-radius: 20px;">
                        <h2 class="card-title">Expense Record</h2>
                        <a class="heading-elements-toggle"><i class="la la-ellipsis-v font-medium-3"></i></a>
                    </div>
                        <div class="card-content collapse show">
                            <div class="card-body">
                                <div class="table-responsive-sm">
                                    <asp:Repeater runat="server" ID="rptExpense" OnItemDataBound="rptExpense_ItemDataBound" OnItemCommand="rptExpense_ItemCommand">
                                        <HeaderTemplate>
                                            <table class="table">
                                                <thead>
                                                    <tr  class="gridHeader">
                                                        <th></th>
                                                        <th>Expense Type</th>
                                                        <th>Expense Type Details</th>
                                                        <th>Date</th>
                                                        <th class="rightAmount">Amount</th>
                                                        <th>Notes</th>
                                                        <th></th>
                                                    </tr>
                                                </thead>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <tr>
                                                <td class="bg-lighten-5">
                                                    <asp:LinkButton runat="server" CommandName="Edit" ID="lbtnEdit" Text="Edit"></asp:LinkButton>
                                                    <asp:LinkButton runat="server" CommandName="Update" ID="lbtnUpdate" Text="Update"></asp:LinkButton>
                                                    <asp:HiddenField ID="hdIDExpense" Value='<%# Eval("ExpenseID") %>' runat="server" />
                                                </td>
                                                <td class="bg-blue  bg-lighten-4">
                                                    <asp:Label runat="server" ID="lblExpenseType" />
                                                    <asp:DropDownList ID="ddlExpenseType" runat="server" CssClass="form-control">
                                                        <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                        <asp:ListItem Text="Water Tanker " Value="1"></asp:ListItem>
                                                        <asp:ListItem Text="Electric Bill" Value="2"></asp:ListItem>
                                                        <asp:ListItem Text="Water Bottles" Value="3"></asp:ListItem>
                                                        <asp:ListItem Text="Tea" Value="4"></asp:ListItem>
                                                        <asp:ListItem Text="Sweeper" Value="5"></asp:ListItem>
                                                        <asp:ListItem Text="Internal Work" Value="6"></asp:ListItem>
                                                        <asp:ListItem Text="Product Purchasing" Value="7"></asp:ListItem>
                                                        <asp:ListItem Text="Other Expenses" Value="8"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td class="bg-lighten-5">
                                                    <asp:Label runat="server" ID="lblExpenseTypeName" />
                                                    <asp:TextBox runat="server" ID="txtExpenseTypeName" CssClass="form-control" />
                                                </td>
                                                <td class="bg-blue  bg-lighten-4">
                                                    <asp:Label runat="server" ID="lblDate" />
                                                    <asp:TextBox runat="server" ID="txtDate" CssClass="form-control datepicker" required />
                                                </td>
                                                <td class="rightAmount bg-lighten-5">
                                                    <asp:Label runat="server" ID="lblAmount" />
                                                    <asp:TextBox runat="server" ID="txtAmount" CssClass="form-control rightAmount" />
                                                </td>
                                                <td class="bg-blue  bg-lighten-4">
                                                    <asp:Label runat="server" ID="lblNote" />
                                                    <asp:TextBox runat="server" ID="txtNote" CssClass="form-control" />
                                                </td>
                                                <td class="bg-lighten-5">
                                                    <asp:LinkButton ID="lbtnDeleteService" runat="server" CommandName="Delete" Text="Delete" OnClientClick="javascript:return confirm('Are you sure you want to Delete this Record ? (Yes/No)');">
                                                    </asp:LinkButton>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <tr>
                                                <td  class="bg-lighten-5">
                                                    <asp:LinkButton ID="lbtnAdd" runat="server" CommandName="Add" Text="Add">
                                                    </asp:LinkButton>
                                                </td>
                                                <td  class="bg-blue  bg-lighten-4">
                                                    <asp:DropDownList ID="ddlExpenseType" runat="server" CssClass="form-control" required>
                                                        <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                        <asp:ListItem Text="Water Tanker " Value="1"></asp:ListItem>
                                                        <asp:ListItem Text="Electric Bill" Value="2"></asp:ListItem>
                                                        <asp:ListItem Text="Water Bottles" Value="3"></asp:ListItem>
                                                        <asp:ListItem Text="Tea" Value="4"></asp:ListItem>
                                                        <asp:ListItem Text="Sweeper" Value="5"></asp:ListItem>
                                                        <asp:ListItem Text="Internal Work" Value="6"></asp:ListItem>
                                                        <asp:ListItem Text="Product Purchasing" Value="7"></asp:ListItem>
                                                        <asp:ListItem Text="Other Expenses" Value="8"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td class="bg-lighten-5">
                                                    <asp:TextBox runat="server" ID="txtExpenseTypeName" CssClass="form-control" />
                                                </td>
                                                <td  class="bg-blue  bg-lighten-4">
                                                    <asp:TextBox runat="server" ID="txtDate" CssClass="form-control datepicker" />
                                                </td>
                                                <td class="rightAmount bg-lighten-5">
                                                    <asp:TextBox runat="server" ID="txtAmount" CssClass="form-control rightAmount" />
                                                </td>
                                                <td  class="bg-blue  bg-lighten-4">
                                                    <asp:TextBox runat="server" ID="txtNote" CssClass="form-control" />
                                                </td>
                                            </tr>
                                            </table>
                                        </FooterTemplate>
                                    </asp:Repeater>
                                    <asp:Label ID="lblExpenseError" runat="server" Text="" CssClass="text-center text-danger"></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>
