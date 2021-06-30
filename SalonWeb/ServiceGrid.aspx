<%@ Page Title="" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeBehind="ServiceGrid.aspx.cs" Inherits="SalonWeb.ServiceGrid" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-body">
        <div class="row">
            <div class="col-12">
                <div class="card">
                    <div class="card-header" style="border-radius: 20px;">
                        <h2 class="card-title">Services Record</h2>
                        <a class="heading-elements-toggle"><i class="la la-ellipsis-v font-medium-3"></i></a>
                    </div>
                    <div class="card-content collapse show">
                        <div class="card-body">
                            <div class="table-responsive-sm">
                                <asp:Repeater runat="server" ID="rptService" OnItemDataBound="rptService_ItemDataBound"
                                    OnItemCommand="rptService_ItemCommand">
                                    <HeaderTemplate>
                                        <table class="table">
                                            <thead>
                                                <tr class="gridHeader">
                                                    
                                                    <th>Name</th>
                                                    <th id="headerNotes" runat="server">Notes</th>
                                                    <th></th>
                                                    <th id="headerDelete" runat="server"></th>
                                                    <th id="headerEdit" runat="server"></th>
                                                </tr>
                                            </thead>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            
                                            <td class="bg-blue  bg-lighten-4">
                                                <asp:Label runat="server" ID="lblName" />
                                                <asp:TextBox runat="server" ID="txtName" CssClass="form-control" />
                                            </td>
                                            <td class="bg-lighten-5" runat="server" id="notes">
                                                <asp:Label runat="server" ID="lblNote" />
                                                <asp:TextBox runat="server" ID="txtNote" CssClass="form-control" />
                                            </td>
                                            <td>

                                            </td>
                                            <td class="bg-blue  bg-lighten-4 " id="del" runat="server">
                                                <asp:LinkButton ID="lbtnDeleteService" runat="server" CommandName="Delete" Text="Delete" class="btn btn-danger" OnClientClick="javascript:return confirm('Are you sure you want to Delete this Record ? (Yes/No)');">
                                                </asp:LinkButton>
                                            </td>
                                            <td class="bg-lighten-5 " id="edit" runat="server">
                                                <asp:LinkButton runat="server" CommandName="Edit" ID="lbtnEdit" Text="Edit" class="btn darkbg"></asp:LinkButton>
                                                <asp:LinkButton runat="server" CommandName="Update" ID="lbtnUpdate" Text="Update" class="btn darkbg"></asp:LinkButton>
                                                <asp:HiddenField ID="hdIDService" Value='<%# Eval("ServiceID") %>' runat="server"></asp:HiddenField>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <tr id="foot" runat="server">
                                            <td>
                                                <asp:LinkButton ID="lbtnAdd" runat="server" CommandName="Add" Text="Add" class="btn darkbg">
                                                </asp:LinkButton>
                                            </td>
                                            <td>
                                                <asp:TextBox runat="server" ID="txtName" CssClass="form-control" />
                                            </td>
                                            <td>
                                                <asp:TextBox runat="server" ID="txtNote" CssClass="form-control" />
                                            </td>
                                        </tr>
                                        </table>
                                    </FooterTemplate>
                                </asp:Repeater>
                                <asp:Label ID="lblServiceError" runat="server" Text="" CssClass="text-center text-danger"></asp:Label>
                            </div>
                        </div>
                        <div class="card-body" style="display:none">
                            <h2 class="card-title">Service Types Record</h2>
                            <div class="table-responsive-sm">
                                <asp:Repeater runat="server" ID="rptServiceType" OnItemDataBound="rptServiceType_ItemDataBound"
                                    OnItemCommand="rptServiceType_ItemCommand">
                                    <HeaderTemplate>
                                        <table class="table ">
                                            <thead>
                                                <tr class="gridHeader">                                           
                                                    <th>Service Name</th>
                                                    <th>Type</th>
                                                    <th class="rightAmount">Cost</th>
                                                    <th class="rightAmount">Time Required (mins)</th>
                                                    <th id="stHeaderNotes" runat="server">Notes</th>
                                                    <th></th>
                                                    <th id="stHeaderDelete" runat="server"></th>
                                                    <th id="stHeaderEdit" runat="server"></th>
                                                </tr>
                                            </thead>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                           
                                            <td class="bg-blue  bg-lighten-4">
                                                <asp:Label runat="server" ID="lblName" />
                                                <asp:DropDownList ID="ddlServiceName" runat="server" CssClass="form-control">
                                                </asp:DropDownList>
                                            </td>
                                            <td class=" bg-lighten-5">
                                                <asp:Label runat="server" ID="lblTypeName" />
                                                <asp:TextBox runat="server" ID="txtTypeName" CssClass="form-control" />
                                            </td>
                                            <td class="rightAmount bg-blue  bg-lighten-4">
                                                <asp:Label runat="server" ID="lblCost" />
                                                <asp:TextBox runat="server" ID="txtCost" CssClass="form-control rightAmount" />
                                            </td>
                                            <td class="rightAmount bg-lighten-5">
                                                <asp:Label runat="server" ID="lblTimeRequired" />
                                                <asp:TextBox runat="server" ID="txtTimeRequired" CssClass="form-control rightAmount" />
                                            </td>
                                            <td class="bg-blue  bg-lighten-4" id="stNotes" runat="server">
                                                <asp:Label runat="server" ID="lblNote" />
                                                <asp:TextBox runat="server" ID="txtNote" CssClass="form-control " />
                                            </td>
                                            <td></td>
                                            <td class="bg-lighten-5" id="stDel" runat="server">
                                                <asp:LinkButton ID="lbtnDeleteType" runat="server" CommandName="Delete" Text="Delete" class="btn btn-danger" OnClientClick="javascript:return confirm('Are you sure you want to Delete this Record ? (Yes/No)');">
                                                </asp:LinkButton>
                                            </td>
                                             <td class="  bg-lighten-5" id="stEdit" runat="server">
                                                <asp:LinkButton runat="server" CommandName="Edit" ID="lbtnEdit" Text="Edit" class="btn btn-primary"></asp:LinkButton>
                                                <asp:LinkButton runat="server" CommandName="Update" ID="lbtnUpdate" Text="Update" class="btn btn-primary"></asp:LinkButton>
                                                <asp:HiddenField ID="hdIDServiceType" Value='<%# Eval("ServiceTypeID") %>' runat="server" />
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <tr id="stFoot" runat="server">
                                            <td class="bg-lighten-5">
                                                <asp:LinkButton ID="lbtnAdd" runat="server" CommandName="Add" Text="Add" class="btn btn-primary">
                                                </asp:LinkButton>
                                            </td>
                                            <td class="bg-blue  bg-lighten-4">
                                                <asp:Label runat="server" ID="lblName" />
                                                <asp:DropDownList ID="ddlServiceName" runat="server" CssClass="form-control">
                                                </asp:DropDownList>
                                            </td>
                                            <td class=" bg-lighten-5">
                                                <asp:TextBox runat="server" ID="txtTypeName" CssClass="form-control" />
                                            </td>
                                            <td class="rightAmount bg-blue  bg-lighten-4">
                                                <asp:TextBox runat="server" ID="txtCost" CssClass="form-control rightAmount" />
                                            </td>
                                            <td class="rightAmount bg-lighten-5">
                                                <asp:TextBox runat="server" ID="txtTimeRequired" CssClass="form-control rightAmount" />
                                            </td>
                                            <td class="bg-blue  bg-lighten-4">
                                                <asp:TextBox runat="server" ID="txtNote" CssClass="form-control" />
                                            </td>
                                        </tr>
                                        </table>
                                    </FooterTemplate>
                                </asp:Repeater>
                                <asp:Label ID="lblServiceTypeError" runat="server" Text="" CssClass="text-center text-danger"></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
