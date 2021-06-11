<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InvoiceGrid.aspx.cs" MasterPageFile="~/Master.master" Inherits="SalonWeb.InvoiceGrid" %>

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
                  <div class="card-header" style=" border-radius: 20px;">
                        <h2 class="card-title">Invoice Record</h2>
                        <a class="heading-elements-toggle"><i class="la la-ellipsis-v font-medium-3"></i></a>
                    </div>
                    <div class="card-content collapse show">
                        <div class="card-body">
                            <div class="table-responsive-sm">
                                <asp:Repeater runat="server" ID="rptAppointment" OnItemDataBound="rptAppointment_ItemDataBound" OnItemCommand="rptAppointment_ItemCommand">
                                    <HeaderTemplate>
                                        <table class="table" >
                                            <thead>
                                                <tr class="gridHeader">
                                                    <th></th>
                                                    <th>Invoice ID</th>
                                                    <th>Customer Name</th>
                                                    <th>Appointment Date</th>
                                                    <th>Invoice Date</th>
                                                    <th class="rightAmount">Service Cost</th>
                                                    <th class="rightAmount">Additional Cost</th>
                                                    <th class="rightAmount">Total Cost</th>
                                                </tr>
                                            </thead>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr> 
                                            <td class="icon bg-lighten-5" >
                                                <a><i runat="server" id="btnEdit" onclick="editAppointment()" style="color:#1E9FF2; font-style:normal">Edit</i></a>
                                            </td>
                                            <td class="bg-blue bg-lighten-4">
                                                <asp:Label runat="server" ID="lblAppointmentID" />
                                            </td>
                                            <td class="bg-lighten-5">
                                                <asp:Label runat="server" ID="lblCustomerName" />
                                            </td>
                                            <td class="bg-blue bg-lighten-4">
                                                <asp:Label runat="server" ID="lblApDateTime" />
                                            </td>
                                            <td  class="bg-lighten-5">
                                                 <asp:Label runat="server" ID="lblDateTime" />
                                            </td>
                                            <td class="rightAmount bg-blue bg-lighten-4">
                                                <asp:Label runat="server" ID="lblServiceCost" />
                                            </td>
                                            <td class="rightAmount bg-lighten-5">
                                                <asp:Label runat="server" ID="lblAdditionalCost" />
                                            </td>
                                            <td class="rightAmount  bg-blue bg-lighten-4">
                                                <asp:Label runat="server" ID="lblTotalCost" />
                                                <asp:HiddenField ID="hdIDAppointment" Value='<%# Eval("AppointmentID") %>' runat="server" />
                                            </td>
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


