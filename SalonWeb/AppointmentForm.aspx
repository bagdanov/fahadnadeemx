<%@ Page Title="" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeBehind="AppointmentForm.aspx.cs" Inherits="SalonWeb.AppointmentForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-body">
        <script src="app-assets/js/jquery-ui.js"></script>
        <script>
            
        </script>
        <section id="basic-form-layouts">
            <div class="row">
                <div class="col-md-12">
                    <div class="card">
                        <div class="card-header" style="border-radius: 20px;">
                            <h2 class="card-title" id="bordered-layout-colored-controls">Appointment Information</h2>
                        </div>
                        <div class="card-content collpase show">
                            <div class="card-body">
                                <div class="form form-horizontal form-bordered borderround">
                                    <div class="form-body">
                                        <h4 class="form-section">Student Details</h4>
                                        <div class="row">
                                            <div class="col-md-6">
                                                <div class="form-group row">
                                                    <label class="col-md-4 label-control" for="userinput1">Full Name<span class="danger">*</span></label>
                                                    <div class="col-md-9">
                                                        <asp:TextBox ID="txtCustomerName" runat="server" CssClass="form-control border-primary" name="CustomerName"></asp:TextBox>

                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="form-group row">
                                                    <label class="col-md-6 label-control">Matricola No<span class="danger">*</span></label>
                                                    <div class="col-md-9">
                                                        <asp:TextBox ID="txtPhoneNumber" runat="server" name="txtPhoneNumber" AutoCompleteType="Disabled" CssClass="form-control border-primary searchPhone" TextMode="Phone"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <asp:HiddenField ID="hdCustomerID" runat="server"></asp:HiddenField>
                                        <h4 class="form-section">Appointment Details</h4>
                                        <div class="row">
                                            <div class="col-md-6">
                                                <div class="form-group row">
                                                    <label class="col-md-6 label-control" for="services">
                                                        Department <span class="danger">*</span>
                                                    </label>
                                                    <div class="col-md-9">
                                                        <asp:DropDownList ID="ddlServiceName" runat="server" CssClass="form-control border-primary " AutoPostBack="true"
                                                            OnSelectedIndexChanged="OnSelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </div>
                                                    <asp:LinkButton runat="server" CommandName="Add" ID="lbtnAdd" Text="Add" Width="55px" OnClick="lbtnAdd_Click" CssClass="btn darkbg rightAmount"></asp:LinkButton>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="form-group row">
                                                    <label for="AppointmentDateTime" class="col-md-8 label-control">
                                                        Appointment Date&Time<span class="danger">*</span>
                                                    </label>
                                                    <div class="col-md-9">
                                                        <div class='input-group'>
                                                            <asp:TextBox runat="server" class="form-control" ID="txtApDatetime" TextMode="DateTimeLocal"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-6" style="display:none">
                                                <div class="form-group row">
                                                    <label class="col-md-6 label-control" for="serviceTypes">
                                                        Services Type <span class="danger">*</span>
                                                    </label>
                                                    <div class="col-md-9">
                                                        <asp:DropDownList ID="ddlServiceTypeName" runat="server" CssClass="c-select form-control custom-select"
                                                            AutoPostBack="true">
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">                           
                                            <div class="col-md-6">
                                                <div class="form-group row last">
                                                    <label class="col-md-8 label-control" for="ddlAppointmentStatus" id="lblAppointmentStatus" runat="server">Appointment Status<span class="danger">*</span></label>
                                                    <div class="col-md-9">
                                                        <asp:DropDownList ID="ddlAppointmentStatus" runat="server" CssClass="form-control required border-primary" OnSelectedIndexChanged="ddlAppointmentStatus_SelectedIndexChanged" AutoPostBack="True">
                                                            <asp:ListItem Text="--Select--" Selected="True" Value="0"></asp:ListItem>
                                                            <asp:ListItem Text="Pending " Value="1"></asp:ListItem>
                                                            <asp:ListItem Text="Cancelled" Value="2"></asp:ListItem>
                                                            <asp:ListItem Text="Approved" Value="3"></asp:ListItem>
                                                            <asp:ListItem Text="Invoiced" Value="4"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <%--   <div class="col-md-6">
                                                <div class="form-group row last">
                                                    <label class="col-md-3 label-control" for="ddlEmp">Employee<span class="danger">*</span></label>
                                                    <div class="col-md-9">
                                                        <asp:DropDownList ID="ddlEmp" runat="server" CssClass="form-control required border-primary" required>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>--%>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-6">
                                                <div class="form-group row last">
                                                    <label class="col-md-8 label-control" for="userinput6">Reason for Appointment</label>
                                                    <div class="col-md-9">
                                                        <asp:TextBox ID="txtNotes" Rows="4" runat="server" CssClass="form-control border-primary" type="text" name="Notes" TextMode="MultiLine"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row" style="display:none;">
                                            <div class="col-md-12">
                                                <div class="form-group row last">
                                                    <div class="table-responsive-sm">
                                                        <asp:Repeater runat="server" ID="rptServiceType" OnItemDataBound="rptServiceType_ItemDataBound" OnItemCommand="rptServiceType_ItemCommand">
                                                            <HeaderTemplate>
                                                                <table class="table">
                                                                    <thead>
                                                                        <tr>
                                                                            <th>Service Name</th>
                                                                            <th>Type</th>
                                                                            <th class="rightAmount">Cost</th>
                                                                            <th class="rightAmount">Time Required</th>
                                                                            <th></th>
                                                                        </tr>
                                                                    </thead>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label runat="server" ID="lblServiceName" />
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label runat="server" ID="lblServiceType" />
                                                                    </td>
                                                                    <td class="rightAmount">
                                                                        <asp:Label runat="server" ID="lblCost" />
                                                                    </td>
                                                                    <td class="rightAmount">
                                                                        <asp:Label runat="server" ID="lblTimeRequired" />
                                                                    </td>
                                                                    <td class="icon">
                                                                        <asp:HiddenField ID="hdServiceID" Value='<%# Eval("ServiceID") %>' runat="server" />
                                                                        <asp:HiddenField ID="hdServiceTypeID" Value='<%# Eval("ServiceTypeID") %>' runat="server" />
                                                                        <asp:HiddenField ID="hdAppointmentServiceID" Value='<%# Eval("AppointmentServiceID") %>' runat="server" />
                                                                        <asp:HiddenField ID="hdAppointmentID" Value='<%# Eval("AppointmentID") %>' runat="server" />
                                                                        <asp:LinkButton ID="lbtnDelete" runat="server" CommandName="Delete" Text="Delete">
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
                                        <div class="row" style="display:none;">
                                            <div class="col-md-6">
                                                <div class="form-group row">
                                                    <label class="col-md-3 label-control" for="services">
                                                        Total time 
                                                    </label>
                                                    <div class="col-md-9 ">
                                                        <asp:Label runat="server" ID="lblTotalTime" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row" style="display:none;">
                                            <div class="col-md-6">
                                                <div class="form-group row">
                                                    <label class="col-md-4 label-control" for="services">
                                                        Service cost 
                                                    </label>
                                                    <div class="col-md-9">
                                                        Rs &nbsp
                                                        <asp:Label runat="server" ID="lblServiceCost" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div id="hideInvoice" runat="server">
                                            <h2 class="form-section"><i class="la la-eye"></i>Invoice</h2>
                                            <div class="row">
                                                <div class="col-md-6">
                                                    <div class="form-group row">
                                                        <label class="col-md-3 label-control">Invoice Date</label>
                                                        <div class="col-md-9">
                                                            <div class='input-group'>
                                                                <asp:TextBox runat="server" CssClass="form-control datepicker required" ID="txtInvoiceDate"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-6">
                                                    <div class="form-group row">
                                                        <label class="col-md-3 label-control" for="userinput1">Additional Cost</label>
                                                        <div class="col-md-9">
                                                            <asp:TextBox ID="txtAdditionalCost" runat="server" CssClass="form-control border-primary rightAmount"
                                                                OnTextChanged="txtAdditionalCost_TextChanged" AutoPostBack="True" Text="0"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-6">
                                                    <div class="form-group row">
                                                        <label class="col-md-3 label-control">Payment Mode</label>
                                                        <div class="col-md-9">
                                                            <asp:DropDownList ID="ddlPaymentMode" runat="server" CssClass="form-control border-primary">
                                                                <asp:ListItem Text="--Select--" Enabled="false" Selected="True" Value="0"></asp:ListItem>
                                                                <asp:ListItem Text="Cash" Value="1"></asp:ListItem>
                                                                <asp:ListItem Text="Credit/Debit Card" Value="2"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-6 ">
                                                    <div class="form-group row">
                                                        <label class="col-md-3 label-control" for="Total-Cost">Total Cost</label>
                                                        <div class="col-md-9">
                                                            <asp:Label ID="lblTotalCost" runat="server" Text="" Font-Bold="True" Font-Size="Large" CssClass="rightAmount"></asp:Label>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-6">
                                                <div class="col-md-9">
                                                    <asp:Label ID="lblSubmitError" runat="server" Text="" ForeColor="Red" Font-Size="Medium" Font-Bold="True" CssClass="col-md-3 label-control right"></asp:Label>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="form-actions right">

                                            <asp:Label ID="lblError" runat="server" Text="" CssClass="text-danger"></asp:Label>
                                            <asp:Button Text="Submit" ID="btnSubmit" OnClick="btnSubmit_Click" CssClass="btn darkbg" runat="server" />
                                            <asp:Button Text="Cancel" ID="btnCancel" OnClick="btnCancel_Click" class="btn btn-danger" runat="server" />
                                            <%--   <asp:Button Text="Reset" ID="btnReset" OnClick="btnReset_Click" CssClass="btn btn-primary" runat="server" />--%>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </div>
    <script>
        $(function () {
            $(".searchPhone").autocomplete({
                delay: 0,
                source: function (request, response) {
                    $.ajax({
                        url: "salonapi.svc/GetCustomerByPhone?tenantID=<%=TenantID%> &phoneNumber=" + request.term,
                        type: "GET",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (data) {
                            debugger;
                            response($.map(data, function (item) {
                                return {
                                    label: item.PhoneNumber,
                                    id: item.CustomerID,
                                    name: item.FirstName + ' ' + item.LastName
                                }
                            }))
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            alert(textStatus);
                        }
                    });
                },
                create: function () {
                },
                select: function (e, i) {
                    $('.searchPhone').val(i.item.label);
                    $('#<%=txtCustomerName.ClientID %>').val(i.item.name);
                    $('#<%=hdCustomerID.ClientID %>').val(i.item.id);
                }
            });
        });
    </script>
</asp:Content>