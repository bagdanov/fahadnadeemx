<%@ Page Title="" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeBehind="EmployeeForm.aspx.cs" Inherits="SalonWeb.EmployeeForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-body">
        <script src="app-assets/js/jquery-ui.js"></script>
        <link href="app-assets/css/jquery-ui-timepicker-addon.css" rel="stylesheet" />
        <script src="app-assets/js/jquery-ui-timepicker-addon.js"></script>
        <script>
            $(function () {
                $(".datepicker").datepicker({ dateFormat: 'dd/mm/yy' });
            });
        </script>
        <section id="basic-form-layouts">
            <div class="row">
                <div class="col-md-12">
                    <div class="card">
                        <div class="card-header">
                            <h2 class="card-title" id="bordered-layout-colored-controls">Employee Information</h2>
                        </div>
                        <div class="card-content collpase show">
                            <div class="card-body">
                                <div class="form form-horizontal form-bordered" runat="server">
                                    <div class="form-body">
                                        <h4 class="form-section"><i class="la la-eye"></i>Employee Details</h4>
                                        <div class="row">
                                            <div class="col-md-6">
                                                <div class="form-group row">
                                                    <label class="col-md-3 label-control" for="FullName">Full Name<span class="danger">*</span></label>
                                                    <div class="col-md-9">
                                                        <asp:TextBox ID="txtFullName" runat="server" CssClass="form-control border-primary required" name="FullName" ></asp:TextBox>
                                                    </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-md-3 label-control" for="CNIC">CNIC<span class="danger">*</span></label>
                                                <div class="col-md-9">
                                                    <asp:TextBox ID="txtCNIC" runat="server" CssClass="form-control border-primary" name="CNIC" ></asp:TextBox>

                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group row last">
                                                <label class="col-md-3 label-control" for="DOB">Date of Birth</label>
                                                <div class="col-md-9">
                                                    <asp:TextBox ID="txtDOB" runat="server" name="DOB" CssClass="form-control border-primary datepicker" ></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <h4 class="form-section"><i class="ft-mail"></i>Contact Info & Bio</h4>
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-md-3 label-control">Phone Number<span class="danger">*</span></label>
                                                <div class="col-md-9">
                                                    <asp:TextBox ID="txtPhoneNumber" runat="server" name="txtPhoneNumber" CssClass="form-control border-primary phone-formatter" TextMode="Phone" ></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-md-3 label-control">Alternate Phone Number</label>
                                                <div class="col-md-9">
                                                    <asp:TextBox ID="txtAltPhoneNumber" runat="server" name="txtAltPhoneNumber" CssClass="form-control border-primary phone-formatter" TextMode="Phone"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-md-3 label-control" for="userinput5">Email<span class="danger">*</span></label>
                                                <div class="col-md-9">
                                                    <asp:TextBox ID="txtEmailAddress" runat="server" CssClass="form-control border-primary" type="email" name="emailAddress" TextMode="Email" ></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-md-3 label-control" for="userinput5">Password<span class="danger">*</span></label>
                                                <div class="col-md-9">
                                                    <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control border-primary" type="password" name="emailAddress" TextMode="Password" ></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-md-3 label-control" for="userinput6">Address<span class="danger">*</span></label>
                                                <div class="col-md-9">
                                                    <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control border-primary" type="text" name="address" ></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group row last">
                                                <label class="col-md-3 label-control" for="ddlEmpType" >Employee Type<span class="danger">*</span></label>
                                                <div class="col-md-9">
                                                    <asp:DropDownList ID="ddlEmpType" runat="server" CssClass="form-control border-primary">

                                                        <asp:ListItem Value="1" Text=" Hair Stylist"></asp:ListItem>
                                                        <asp:ListItem Value="2" Text=" Expert Makeup Artist"></asp:ListItem>
                                                        <asp:ListItem Value="3" Text=" Hair Consultant & Cut Expert "></asp:ListItem>
                                                        <asp:ListItem Value="4" Text=" Bridal Party Make up Artist"></asp:ListItem>
                                                        <asp:ListItem Value="5" Text=" Facial Queen"></asp:ListItem>
                                                        <asp:ListItem Value="6" Text=" Senior Hair Cut Artist"></asp:ListItem>
                                                        <asp:ListItem Value="7" Text=" Other Services"></asp:ListItem>
                                                    </asp:DropDownList>

                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group row last">
                                                <label class="col-md-3 label-control" for="Notes">Notes</label>
                                                <div class="col-md-9">
                                                    <asp:TextBox ID="txtNotes" Rows="4" runat="server" CssClass="form-control border-primary" type="text"
                                                        name="bio" TextMode="MultiLine"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <%--  <div class="row">
                          <div class="col-md-6">
                               <div class="form-group row last">
                              <label class="col-md-3 label-control" for="EmpExpertise">Employee Expertise</label>
                              <div class="col-md-9">
                                     <asp:CheckBoxList ID="chkboxEmpExpertise" runat="server">
                                         
                                         <asp:ListItem Value="1" Text=" Bridal Make up"></asp:ListItem>
                                         <asp:ListItem Value="2" Text=" Expert Makeup"></asp:ListItem>
                                         <asp:ListItem Value="3" Text=" Facial"></asp:ListItem>
                                         <asp:ListItem Value="4" Text=" Hair Cut"></asp:ListItem>
                                         <asp:ListItem Value="5" Text=" Hair Styling"></asp:ListItem>
                                         <asp:ListItem Value="6" Text=" Hair Consultant"></asp:ListItem>
                                         <asp:ListItem Value="7" Text=" Other Services"></asp:ListItem>
                                         <asp:ListItem Value="8" Text=" Party Make up"></asp:ListItem>

                                     </asp:CheckBoxList>
                              </div>
                            </div>
                          </div>
                       </div>--%>
                                    <div class="form-actions right">
                                    <asp:Label ID="lblError" runat="server" Text="" CssClass="text-danger"></asp:Label>
                                        <asp:Button Text="Submit" ID="btnSubmit" OnClick="btnSubmit_Click" CssClass="btn darkbg" runat="server" />
                                        <asp:Button Text="Cancel" ID="btnCancel" OnClick="btnCancel_Click" CssClass="btn btn-danger" runat="server" />
                                        <%--                                            <asp:Button Text="Reset" ID="btnReset" OnClick="btnReset_Click" CssClass="btn btn-primary" runat="server" />--%>
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
</asp:Content>
