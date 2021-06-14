<%@ Page Title="" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeBehind="CRMGrid.aspx.cs" Inherits="SalonWeb.CRMGrid" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        function newCustomer() {
            location.replace("CustomerForm.aspx")
        }
        function editCustomer(id) {
            location.replace("CustomerForm.aspx?CustomerID=" + id);
        }

    </script>
    <div class="content-body">
        <div class="row">
            <div class="col-12">
                <div class="card">
                    <div class="card-header">
                        <h2 class="card-title">Customer Record</h2>
                        <a class="heading-elements-toggle"><i class="la la-ellipsis-v font-medium-3"></i></a>
                    </div>
                    <div class="col-2 col-sm-1 fonticon-container">
                        <div class="fonticon-wrap" style="max-height: 5px">
                            <i class="ft-plus-circle" onclick="newCustomer()"></i>
                        </div>
                    </div>
                    <div class="card-content collapse show">
                        <div class="card-body">
                            <div class="table-responsive-sm">
                                <asp:Repeater runat="server" ID="rptCustomer" OnItemDataBound="rptCustomer_ItemDataBound" OnItemCommand="rptCustomer_ItemCommand">
                                    <HeaderTemplate>
                                        <table class="table">
                                            <thead>
                                                <tr  class="gridHeader">
                                                    <th ></th>
                                                    <th>Full Name</th>
                                                    <th>Phone Number</th>
                                                    <th>Email Address</th>
                                                    <th></th>
                                                    <th></th>
                                                </tr>
                                            </thead>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>    
                                            <td class="icon bg-lighten-5" >
                                                <a><i runat="server" id="btnEdit" onclick="editCustomer()" style="color:#1E9FF2; font-style:normal">Edit</i></a>
                                            <td  class="bg-blue bg-lighten-4">
                                                <asp:Label runat="server" ID="lblFullName" />
                                            </td>
                                            <td class="icon bg-lighten-5" >
                                                <asp:Label runat="server" ID="lblPhoneNumber" />
                                            </td>
                                            <td class="bg-blue bg-lighten-4">
                                                <asp:Label runat="server" ID="lblEmailAddress" />
                                            </td>
                                            <td class="icon bg-lighten-5" ">
                                                <asp:LinkButton ID="lbtnAppointments" runat="server" CommandName="Appointments" Text="Show All Appointments">
                                                </asp:LinkButton>
                                            </td>
                                            <td class="icon bg-blue bg-lighten-4">
                                                <asp:HiddenField ID="hdIDCustomer" Value='<%# Eval("CustomerID") %>' runat="server" />
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
