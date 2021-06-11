<%@ Page Title="" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeBehind="CustomerForm.aspx.cs" Inherits="SalonWeb.CustomerForm" %>

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
                        <div class="card-header" style="border-radius: 20px">
                            <h2 class="card-title" id="bordered-layout-colored-controls">Student Information</h2>
                        </div>
                        <div class="card-content collpase show">
                            <div class="card-body">
                                <div class="form form-horizontal form-bordered">
                                    <div class="form-body">
                                        <h4 class="form-section">About Student</h4>
                                        <div class="row">
                                            <div class="col-md-6">
                                                <div class="form-group row">
                                                    <label class="col-md-6 label-control" for="userinput1">First Name<span class="danger">*</span></label>
                                                    <div class="col-md-9">
                                                        <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control border-primary" name="firstName"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="form-group row">
                                                    <label class="col-md-6 label-control" for="userinput2">Last Name</label>
                                                    <div class="col-md-9">
                                                        <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control border-primary" name="lastName"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-6">
                                                <div class="form-group row last">
                                                    <label class="col-md-6 label-control" for="userinput3">Date of Birth</label>
                                                    <div class="col-md-9">
                                                        <asp:TextBox ID="txtDOB" runat="server" name="txtDOB" CssClass="form-control border-primary datepicker" TextMode="Date"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <h4 class="form-section">Contact Info & Bio</h4>
                                        <div class="row">
                                            <div class="col-md-6">
                                                <div class="form-group row">
                                                    <label class="col-md-6 label-control">Phone Number<span class="danger">*</span></label>
                                                    <div class="col-md-9">
                                                        <asp:TextBox ID="txtPhoneNumber" runat="server" name="txtPhoneNumber" CssClass="form-control border-primary" TextMode="Phone"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="form-group row">
                                                    <label class="col-md-8 label-control">Alternate Phone Number</label>
                                                    <div class="col-md-9">
                                                        <asp:TextBox ID="txtAltPhoneNumber" runat="server" name="txtAltPhoneNumber" CssClass="form-control border-primary" TextMode="Phone"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-6">
                                                <div class="form-group row">
                                                    <label class="col-md-6 label-control" for="userinput5">Email<span class="danger">*</span></label>
                                                    <div class="col-md-12">
                                                        <asp:TextBox ID="txtEmailAddress" runat="server" CssClass="form-control border-primary" type="email" name="emailAddress" TextMode="Email"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="form-group row">
                                                    <label class="col-md-6 label-control" for="userinput5">Password<span class="danger">*</span></label>
                                                    <div class="col-md-9">
                                                        <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control border-primary" type="password" name="emailAddress" TextMode="Password"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-6">
                                                <div class="form-group row">
                                                    <label class="col-md-6 label-control" for="userinput6">Address</label>
                                                    <div class="col-md-9">
                                                        <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control border-primary" type="text" name="address"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="form-group row last">
                                                    <label class="col-md-6 label-control" for="userinput6">City</label>
                                                    <div class="col-md-9">
                                                        <asp:DropDownList ID="ddlCity" runat="server" CssClass="form-control border-primary">
                                                            <asp:ListItem Value="1" Text=" Karachi">
                                                                </asp:ListItem>
                                                            <asp:ListItem Value="2" Text="Lahore"></asp:ListItem>
                                                            <asp:ListItem Value="3" Text=" Islamabad"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-6">
                                                <div class="form-group row last">
                                                    <label class="col-md-6 label-control" for="userinput8">Notes</label>
                                                    <div class="col-md-9">
                                                        <asp:TextBox ID="txtNotes" Rows="4" runat="server" CssClass="form-control border-primary" type="text" name="bio" TextMode="MultiLine"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="form-actions right">
                                            <asp:Label ID="lblError" runat="server" Text="" CssClass="text-danger"></asp:Label>
                                            <asp:Button Text="Submit" ID="btnSubmit" OnClick="btnSubmit_Click" CssClass="btn darkbg" runat="server" />
                                            <asp:Button Text="Cancel" ID="btnCancel" OnClick="btnCancel_Click" CssClass="btn btn-danger" runat="server" />
                                            <%--  <asp:button text="Reset" id="btnReset" onclick="btnReset_Click" cssclass="btn btn-primary" runat="server" />--%>
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
