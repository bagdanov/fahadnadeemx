<%@ Page Title="" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeBehind="EmployeeGrid.aspx.cs" Inherits="SalonWeb.EmployeeGrid" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>
        function newEmployee() {
            location.replace("EmployeeForm.aspx")
        }
        function editEmployee(id) {
            location.replace("EmployeeForm.aspx?EmployeeID=" + id);
        }
    </script>
    <div class="content-body">
        <div class="row">
            <div class="col-12">
                <div class="card">
                    <div class="card-header" style=" border-radius: 20px;">
                        <h2 class="card-title">Employee Record</h2>
                        <a class="heading-elements-toggle"><i class="la la-ellipsis-v font-medium-3 btn darkbg"></i></a>
                    </div>                
                        <div class="card-content collapse show">
                            <div class="card-body">
                                <div class="table-responsive-sm">
                                    <asp:Repeater runat="server" ID="rptEmployee" OnItemDataBound="rptEmployee_ItemDataBound" OnItemCommand="rptEmployee_ItemCommand">
                                        <HeaderTemplate>
                                            <table class="table">
                                                <thead>
                                                    <tr class="gridHeader">
                                                        
                                                        <th>Full Name</th>
                                                        <th>Phone Number</th>
                                                        <th>Employee Expertise</th>
                                                        <th>Email Address</th>
                                                        <th></th>
                                                        <th></th>
                                                    </tr>
                                                </thead>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <tr class="textcolor">
                                               
                                                <td class="bg-blue  bg-lighten-4">
                                                    <asp:Label runat="server" ID="lblFullName" />
                                                </td>
                                                <td class="bg-lighten-5">
                                                    <asp:Label runat="server" ID="lblPhoneNumber" />
                                                </td>
                                                <td class="bg-blue  bg-lighten-4">
                                                    <asp:Label runat="server" ID="lblEmpType" />
                                                </td>
                                                <td class="bg-lighten-5">
                                                    <asp:Label runat="server" ID="lblEmailAddress" />
                                                </td>
                                                <td class="icon bg-blue  bg-lighten-4">
                                                    <asp:HiddenField ID="hdIDEmployee" Value='<%# Eval("EmployeeID") %>' runat="server" />
                                                    <asp:LinkButton ID="lbtnDelete" runat="server" CommandName="Delete" Text="Delete" class="btn btn-danger" OnClientClick="javascript:return confirm('Are you sure you want to Delete this Record ? (Yes/No)');">
                                                    </asp:LinkButton>
                                                </td>
                                                 <td class="icon bg-lighten-5">
                                                    <a><i runat="server" id="btnEdit" onclick="editEmployee()"  class="btn darkbg" style="font-style: normal">Edit</i></a>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            </table>
                                        </FooterTemplate>
                                    </asp:Repeater>
                                      <asp:Button class="btn darkbg" onclick="newEmployee()"> New Employee </asp:Button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>

