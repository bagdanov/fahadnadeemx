<%@ Page Title="" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeBehind="ClientsGrid.aspx.cs" Inherits="SalonWeb.ClientsGrid" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        function newClient() {
            location.replace("ClientForm.aspx")
        }
        function editClient(id) {
            location.replace("ClientForm.aspx?ClientID=" + id);
        }
    </script>
    <div class="content-body">
        <div class="row">
            <div class="col-12">
                <div class="card">
                    <div class="card-header" style="border-radius: 20px;">
                        <h2 class="card-title">Clients Record</h2>
                        <a class="heading-elements-toggle"><i class="la la-ellipsis-v font-medium-3"></i></a>
                    </div>
                    <div class="col-2 col-sm-1 fonticon-container">
                        <div class="fonticon-wrap" style="max-height: 5px">
                            <i class="ft-plus-circle" onclick="newClient()"></i>
                        </div>
                    </div>
                    <div class="card-content collapse show">
                        <div class="card-body">
                            <div class="table-responsive-sm">
                                <asp:Repeater runat="server" ID="rptClient" OnItemDataBound="rptClient_ItemDataBound" OnItemCommand="rptClient_ItemCommand">
                                    <HeaderTemplate>
                                        <table class="table">
                                            <thead>
                                                <tr class="gridHeader">
                                                    <th></th>
                                                    <th>Client Name</th>
                                                    <th>Client Type </th>
                                                    <th>Mobile</th>
                                                    <th>Website</th>
                                                    <%--<th class="rightAmount">Amount</th>--%>
                                                    <th>Notes</th>
                                                    <th></th>
                                                </tr>
                                            </thead>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td class="icon bg-lighten-5">
                                                <a><i runat="server" id="btnEdit" onclick="editClient()" style="color: #1E9FF2; font-style: normal">Edit</i></a>
                                                <asp:HiddenField ID="hdIDClient" Value='<%# Eval("ClientID") %>' runat="server" />
                                            </td>

                                            <td class="bg-blue  bg-lighten-4">
                                                <asp:Label runat="server" ID="lblClientName" />
                                            </td>
                                            <td class="bg-lighten-5">
                                                <asp:Label runat="server" ID="lblClientType" />
                                            </td>
                                            <td class="bg-blue  bg-lighten-4">
                                                <asp:Label runat="server" ID="lblMobile" />
                                            </td>
                                            <td class="bg-lighten-5">
                                                <asp:Label runat="server" ID="lblWebsite" />
                                            </td>
                                            <td class="bg-blue  bg-lighten-4">
                                                <asp:Label runat="server" ID="lblNote" />
                                            </td>
                                            <td class="bg-lighten-5">
                                                <asp:LinkButton ID="lbtnDeleteService" runat="server" CommandName="Delete" Text="Delete" OnClientClick="javascript:return confirm('Are you sure you want to Delete this Record ? (Yes/No)');">
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