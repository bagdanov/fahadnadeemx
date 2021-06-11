<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StockForm.aspx.cs" Inherits="SalonWeb.StockForm" MasterPageFile="~/Master.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" >
    <div class="content-body">
         <script src="app-assets/js/jquery-ui.js"></script>
        <link href="app-assets/css/jquery-ui-timepicker-addon.css" rel="stylesheet" />
        <script src="app-assets/js/jquery-ui-timepicker-addon.js"></script>
    <script>
            $(function () {
                $(".datepicker").datepicker({dateFormat: 'dd/mm/yy' });
            });
        </script>   
    <section id="basic-form-layouts">
            <div class="row">
                <div class="col-md-12">
                    <div class="card">
                        <div class="card-header" style=" border-radius: 20px;">
                            <h2 class="card-title" id="bordered-layout-colored-controls">Stock Record</h2>
                        </div>
                        <div class="card-content collpase show">
                            <div class="card-body">
                                <div class="form form-horizontal form-bordered" >
                                    <div class="form-body">
                                        <h4 class="form-section"><i class="la la-eye"></i>Stock Record</h4>
                                        <div class="row">
                                            <div class="col-md-6">
                                                <div class="form-group row">
                                                    <label class="col-md-3 label-control" for="userinput1">Product Category Name<span class="danger">*</span></label>
                                                    <div class="col-md-9">
                                                        <asp:DropDownList ID="ddlProductCategoryName" runat="server" CssClass="c-select form-control required custom-select"
                                                            AutoPostBack="true" OnSelectedIndexChanged="ddlProductCategoryName_SelectedIndexChanged" >
                                                        </asp:DropDownList> </div>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="form-group row">
                                                    <label class="col-md-3 label-control" for="userinput2">Product Name<span class="danger">*</span></label>
                                                    <div class="col-md-9">
                                                        <asp:DropDownList ID="ddlProductName" runat="server" CssClass="c-select form-control required custom-select"
                                                            AutoPostBack="true" >
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-6">
                                                <div class="form-group row last">
                                                    <label class="col-md-3 label-control" for="userinput3">Date</label>
                                                    <div class="col-md-9">
                                                        <asp:textbox id="txtDate" runat="server" CssClass="form-control border-primary datepicker"></asp:textbox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="form-group row last">
                                                    <label class="col-md-3 label-control" for="userinput3">Quantity</label>
                                                    <div class="col-md-9">
                                                        <asp:textbox id="txtQuantity" runat="server" cssclass="form-control border-primary rightAmount" textmode="SingleLine"></asp:textbox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-6">
                                                <div class="form-group row last">
                                                    <label class="col-md-3 label-control" for="userinput3">Price</label>
                                                    <div class="col-md-9">
                                                        <asp:textbox id="txtPrice" runat="server" cssclass="form-control border-primary rightAmount" textmode="SingleLine" ></asp:textbox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="form-group row last">
                                                    <label class="col-md-3 label-control" for="userinput3">Notes</label>
                                                    <div class="col-md-9">
                                                        <asp:textbox id="txtNotes" runat="server" Rows="4"  CssClass="form-control border-primary" textmode="MultiLine"></asp:textbox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="form-actions right"> <asp:Label ID="lblError" runat="server" Text="" CssClass="text-danger"></asp:Label>
                                   
                                            <asp:button text="Submit" id="btnSubmit" onclick="btnSubmit_Click" CssClass="btn darkbg" runat="server" />
                                            <asp:button text="Cancel" id="btnCancel" onclick="btnCancel_Click" CssClass="btn btn-danger" runat="server" />
                                            <%--<asp:button text="Reset" id="btnReset" onclick="btnReset_Click" CssClass="btn btn-primary" runat="server" />--%>
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
