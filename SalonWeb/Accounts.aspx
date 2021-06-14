<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Accounts.aspx.cs" Inherits="SalonWeb.Accounts" MasterPageFile="~/Master.master" %>

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
                <div class="card textcolor">
                    <div class="card-header" style="border-radius: 20px;">
                        <div class="row">
                            <div class="col-md-2">
                                <h2 class="card-title">Accounts Record</h2>
                            </div>
                            <div class="col-md-3">
                                <asp:TextBox runat="server" ID="txtToDate" CssClass="form-control datepicker " placeholder="From date" />
                            </div>
                            <div class="col-md-3">
                                <asp:TextBox runat="server" ID="txtFromDate" CssClass="form-control datepicker " placeholder="To date" />
                            </div>
                            <div class="col-md-3">
                                <asp:Button runat="server" Text="Search" ID="btnSearch" OnClick="btnSearch_Click" CssClass="btn darkbg"></asp:Button>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="card-content collapse show">
                    <div class="card-body">
                        <div class="table-responsive-sm">
                            <asp:Repeater runat="server" ID="rptAccount" OnItemDataBound="rptAccount_ItemDataBound"
                                OnItemCommand="rptAccount_ItemCommand">
                                <HeaderTemplate>
                                    <table class="table">
                                        <thead>
                                            <tr class="gridHeader">
                                                <th></th>
                                                <th>Account ID</th>
                                                <th>ID</th>
                                                <th>Type</th>
                                                <th>Date</th>
                                                <th>Description</th>
                                                <th class="rightAmount">Debit(Out)</th>
                                                <th class="rightAmount">Credit(In)</th>
                                                <th class="rightAmount">Balance</th>
                                                <th></th>
                                            </tr>
                                        </thead>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td class="bg-lighten-5">
                                            <asp:LinkButton runat="server" CommandName="Edit" ID="lbtnEdit" Text="Edit"></asp:LinkButton>
                                            <asp:LinkButton runat="server" CommandName="Update" ID="lbtnUpdate" Text="Update"></asp:LinkButton>
                                            <asp:HiddenField ID="hdIDAccount" Value='<%# Eval("AccountID") %>' runat="server" />
                                            <asp:HiddenField ID="hdIDModule" Value='<%# Eval("ModuleID") %>' runat="server" />
                                        </td>
                                        <td class="bg-blue  bg-lighten-4">
                                            <asp:Label runat="server" ID="lblAccountID" />
                                        </td>
                                        <td class="bg-lighten-5">
                                            <asp:Label runat="server" ID="lblObjectID" />
                                        </td>
                                        <td class="bg-blue  bg-lighten-4">
                                            <asp:Label runat="server" ID="lblType" />
                                            <asp:DropDownList ID="ddlType" runat="server" CssClass="form-control">
                                                <asp:ListItem Text="--Select--" Selected="True" Value="0"></asp:ListItem>
                                                <asp:ListItem Text="Cash in Hand " Value="5"></asp:ListItem>
                                                <asp:ListItem Text="Starting Balance" Value="4"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td class="bg-lighten-5">
                                            <asp:Label runat="server" ID="lblDate" />
                                            <asp:TextBox runat="server" ID="txtDate" CssClass="form-control datepicker" required />
                                        </td>
                                        <td class="bg-blue  bg-lighten-4">
                                            <asp:Label runat="server" ID="lblDesciption" />
                                            <asp:TextBox runat="server" ID="txtDesciption" CssClass="form-control" required />
                                        </td>
                                        <td class="rightAmount bg-lighten-5">
                                            <asp:Label runat="server" ID="lblDebit" />
                                            <asp:TextBox runat="server" ID="txtDebit" CssClass="form-control rightAmount" />
                                        </td>
                                        <td class="rightAmount bg-blue  bg-lighten-4">
                                            <asp:Label runat="server" ID="lblCredit" />
                                            <asp:TextBox runat="server" ID="txtCredit" CssClass="form-control rightAmount" />
                                        </td>
                                        <td class="rightAmount bg-lighten-5">
                                            <asp:Label runat="server" ID="lblBalance" />
                                        </td>
                                        <td class="bg-blue  bg-lighten-4">
                                            <asp:LinkButton ID="lbtnDelete" runat="server" CommandName="Delete" Text="Delete" OnClientClick="javascript:return confirm('Are you sure you want to Delete this Record ? (Yes/No)');">
                                            </asp:LinkButton>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <tr>
                                        <td class="bg-lighten-5"> 
                                            <asp:LinkButton ID="lbtnAdd" runat="server" CommandName="Add" Text="Add">
                                            </asp:LinkButton>
                                        </td>
                                        <td></td>
                                        <td></td>
                                        <td class="bg-blue  bg-lighten-4">
                                            <asp:DropDownList ID="ddlType" runat="server" CssClass="form-control">
                                                <asp:ListItem Text="--Select--" Selected="True" Value="0"></asp:ListItem>
                                                <asp:ListItem Text="Cash in Hand " Value="5"></asp:ListItem>
                                                <asp:ListItem Text="Starting Balance" Value="4"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td class="bg-lighten-5">
                                            <asp:TextBox runat="server" ID="txtDate" CssClass="form-control datepicker" />
                                        </td>
                                        <td class="bg-blue  bg-lighten-4">
                                            <asp:TextBox runat="server" ID="txtDesciption" CssClass="form-control" />
                                        </td>
                                        <td class="rightAmount bg-lighten-5"" colspan="2">
                                            <asp:TextBox runat="server" ID="txtAmount" CssClass="form-control rightAmount" />
                                        </td>
                                        <td></td>
                                    </tr>
                                    </table>
                                </FooterTemplate>
                            </asp:Repeater>
                            <asp:Label ID="lblAccountError" runat="server" Text="" CssClass="text-center text-danger"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </div>
</asp:Content>