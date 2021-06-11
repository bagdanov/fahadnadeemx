<%@ Page Title="" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeBehind="AppointmentGrid.aspx.cs" Inherits="SalonWeb.AppointmentGrid" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        function newAppointment() {
            location.replace("AppointmentForm.aspx")
        }
        function editAppointment(id) {
            location.replace("AppointmentForm.aspx?AppointmentID=" + id);
        }
    </script>
    <div class="content-body">
        <div class="row">
            <div class="col-12">
                <div class="card">
                    <div class="card-header" style="border-radius: 20px;">
                        <h1 class="card-title">Appointment Record</h1>
                        <a class="heading-elements-toggle"><i class="la la-ellipsis-v font-medium-3 darkbg"></i></a>
                    </div>                  
                    <div class="card-content collapse show">
                        <div class="card-body">
                            <div class="table-responsive-sm">
                                <asp:Repeater runat="server" ID="rptAppointment" OnItemDataBound="rptAppointment_ItemDataBound" OnItemCommand="rptAppointment_ItemCommand">
                                    <HeaderTemplate>
                                        <table class="table">
                                            <thead>
                                                <tr class="gridHeader">                                                   
                                                    <th>Student Name</th>
                                                    <th>Phone Number</th>
                                                    <th>Date</th>
                                                    <th>Status</th>
                                                    <th></th>
                                                    <th></th>
                                                    <th></th>
                                                </tr>
                                            </thead>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>                                        
                                            <td class="bg-blue  bg-lighten-4">
                                                <asp:Label runat="server" ID="lblCustomerName" />
                                            </td>
                                            <td class="icon bg-lighten-5">
                                                <asp:Label runat="server" ID="lblPhoneNumber" />
                                            </td>
                                            <td class="bg-blue  bg-lighten-4">
                                                <asp:Label runat="server" ID="lblDateTime" />
                                            </td>
                                            <td class="icon bg-lighten-5">
                                                <asp:Label runat="server" ID="lblStatus" />
                                            </td>
                                            <td class="bg-blue  bg-lighten-4">
                                                <asp:Label runat="server" ID="lblNotes" />
                                            </td>
                                            <td class="icon bg-lighten-5">
                                                <asp:HiddenField ID="hdIDAppointment" Value='<%# Eval("AppointmentID") %>' runat="server" />
                                                <asp:LinkButton ID="lbtnDelete" runat="server" CommandName="Delete" Text="Delete" class="btn btn-danger" OnClientClick="javascript:return confirm('Are you sure you want to Delete this Record ? (Yes/No)');">
                                                </asp:LinkButton>
                                            </td>
                                             <td class="icon bg-lighten-5">
                                                <a><i runat="server" id="btnEdit" onclick="editAppointment()" class="btn darkbg" style="font-style: normal">Edit</i></a>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        </table>
                                    </FooterTemplate>
                                </asp:Repeater>
                                <asp:Button class="btn darkbg" onclick="newAppointment()"> New Appointment </asp:Button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>