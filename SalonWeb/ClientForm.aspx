<%@ Page Title="" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeBehind="ClientForm.aspx.cs" Inherits="SalonWeb.ClientForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-body">
        <%--     <script src="app-assets/js/jquery-ui.js"></script>
        <link href="app-assets/css/jquery-ui-timepicker-addon.css" rel="stylesheet" />
        <script src="app-assets/js/jquery-ui-timepicker-addon.js"></script>
        <script>
            $(function () {
                $(".datepicker").datepicker({ dateFormat: 'dd/mm/yy' });
            });
        </script>--%>
        <section id="basic-form-layouts">
            <div class="row">
                <div class="col-md-12">
                    <div class="card">
                        <div class="card-header">
                            <h2 class="card-title" id="bordered-layout-colored-controls">Client Information</h2>
                        </div>
                        <div class="card-content collpase show">
                            <div class="card-body">
                                <div class="form form-horizontal form-bordered" runat="server">
                                    <div class="form-body">
                                        <h4 class="form-section"><i class="la la-eye"></i>Client Details</h4>
                                        <div class="row">
                                            <div class="col-md-6">
                                                <div class="form-group row">
                                                    <label class="col-md-3 label-control" for="FullName">Name<span class="danger">*</span></label>
                                                    <div class="col-md-9">
                                                        <asp:TextBox ID="txtName" runat="server" CssClass="form-control border-primary required" name="FullName"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="form-group row last">
                                                    <label class="col-md-3 label-control" for="ddlClientType">Client Type <span class="danger">*</span></label>
                                                    <div class="col-md-9">
                                                        <asp:DropDownList ID="ddlClientType" runat="server" CssClass="form-control border-primary">
                                                            <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                            <asp:ListItem Text="Salon " Value="1"></asp:ListItem>
                                                            <asp:ListItem Text="Gym" Value="2"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-6">
                                                <div class="form-group row last">
                                                    <label class="col-md-3 label-control" for="txtNTN">NTN <span class="danger">*</span></label>
                                                    <div class="col-md-9">
                                                        <asp:TextBox ID="txtNTN" runat="server" CssClass="form-control border-primary"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="form-group row last">
                                                    <label class="col-md-3 label-control" for="txtSNTN">SNTN <span class="danger">*</span></label>
                                                    <div class="col-md-9">
                                                        <asp:TextBox ID="txtSNTN" runat="server" CssClass="form-control border-primary"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-6">
                                                <div class="form-group row last">
                                                    <label class="col-md-3 label-control" for="txtTagLine">Tag Line</label>
                                                    <div class="col-md-9">
                                                        <asp:TextBox ID="txtTagLine" runat="server" CssClass="form-control border-primary"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <h4 class="form-section"><i class="ft-mail"></i>Contact Info & Bio</h4>
                                        <div class="row">
                                            <div class="col-md-6">
                                                <div class="form-group row">
                                                    <label class="col-md-3 label-control">Phone Number <span class="danger">*</span></label>
                                                    <div class="col-md-9">
                                                        <asp:TextBox ID="txtTelePhoneNumber" runat="server" name="txtPhoneNumber" CssClass="form-control border-primary phone-formatter" TextMode="Phone"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="form-group row">
                                                    <label class="col-md-3 label-control">Mobile Number</label>
                                                    <div class="col-md-9">
                                                        <asp:TextBox ID="txtMobile" runat="server" CssClass="form-control border-primary phone-formatter" TextMode="Phone"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-6">
                                                <div class="form-group row">
                                                    <label class="col-md-3 label-control" for="userinput5">Email <span class="danger">*</span></label>
                                                    <div class="col-md-9">
                                                        <asp:TextBox ID="txtEmailAddress" runat="server" CssClass="form-control border-primary" type="email" name="emailAddress" TextMode="Email"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="form-group row">
                                                    <label class="col-md-3 label-control" for="userinput5">Address <span class="danger">*</span></label>
                                                    <div class="col-md-9">
                                                        <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control border-primary" TextMode="SingleLine" name="address"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-6">
                                                <div class="form-group row">
                                                    <label class="col-md-3 label-control" for="userinput6">City<span class="danger">*</span></label>
                                                    <div class="col-md-9">
                                                        <asp:TextBox ID="txtCity" runat="server" CssClass="form-control border-primary" type="text" name="city"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="form-group row">
                                                    <label class="col-md-3 label-control" for="userinput6">Country</label>
                                                    <div class="col-md-9">
                                                        <asp:TextBox ID="txtCountry" runat="server" CssClass="form-control border-primary" type="text" name="city"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-6">
                                                <div class="form-group row last">
                                                    <label class="col-md-3 label-control" for="txtWebsite">Website</label>
                                                    <div class="col-md-9">
                                                        <asp:TextBox ID="txtWebsite" runat="server" CssClass="form-control border-primary" type="text"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
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
                                        <div class="form-actions right">
                                            <asp:Button Text="Submit" ID="btnSubmit" OnClick="btnSubmit_Click" CssClass="btn darkbg" runat="server" />
                                            <asp:Button Text="Cancel" ID="btnCancel" OnClick="btnCancel_Click" CssClass="btn btn-danger" runat="server" />
                                            <%--<asp:Button Text="Reset" ID="btnReset" OnClick="btnReset_Click" CssClass="btn btn-primary" runat="server" />--%>
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