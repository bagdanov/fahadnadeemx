<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="SalonWeb.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="apple-touch-icon" href="../../../app-assets/images/logo/salapp-crop.png">
    <link rel="shortcut icon" type="image/x-icon" href="../../../app-assets/images/logo/salapp-crop.png">
    <link href="app-assets/fonts/css.css?family=Open+Sans:300,300i,400,400i,600,600i,700,700i|Quicksand:300,400,500,700" rel="stylesheet" />
    <link href="app-assets/css/line-awesome.min.css" rel="stylesheet" />
    <link href="app-assets/css/jquery-ui.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="app-assets/css/vendors.css">
    <link rel="stylesheet" type="text/css" href="app-assets/css/app.css">
    <link href="app-assets/css/components.css" rel="stylesheet" />
    <script src="app-assets/js/core/app.js"></script>
    <script src="app-assets/js/core/app-menu.js"></script>
    <script src="app-assets/vendors/js/ui/headroom.min.js"></script>
    <script src="app-assets/js/core/app-menu.min.js"></script>
    <script src="app-assets/vendors/js/vendors.min.js"></script>
    <link href="app-assets/fonts/feather/style.min.css" rel="stylesheet" />
    <link href="app-assets/fonts/simple-line-icons/style.min.css" rel="stylesheet" />
    <link href="app-assets/fonts/simple-line-icons/style.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="app-assets/css/core/menu/menu-types/vertical-content-menu.css">

    <link rel="stylesheet" type="text/css" href="../../../app-assets/vendors/css/weather-icons/climacons.min.css">
    <link rel="stylesheet" type="text/css" href="../../../app-assets/fonts/meteocons/style.css">
    <!-- BEGIN Page Level CSS-->
    <link rel="stylesheet" type="text/css" href="../../../app-assets/css/core/colors/palette-gradient.css">

    <!-- BEGIN Custom CSS-->
    <link rel="stylesheet" type="text/css" href="../../../assets/css/style.css">
    <link rel="preconnect" href="https://fonts.gstatic.com">
    <link href="https://fonts.googleapis.com/css2?family=Red+Hat+Display&display=swap" rel="stylesheet">
    <link rel="stylesheet" href="https://maxst.icons8.com/vue-static/landings/line-awesome/line-awesome/1.3.0/css/line-awesome.min.css">

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/js/bootstrap.min.js"></script>
    <%--        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/css/bootstrap.min.css">--%>
    <script src="app-assets/js/jquery-1.12.4.js"></script>
    <style>
        * {
            font-family: 'Red Hat Display', sans-serif;
            color: white !important;
        }

        div.card-header {
            background: none !important;
        }

        .cardborder {
            border-radius: 15px;
            border-color: #00639A;
        }

        .textcolor {
            color: white;
        }

        .card {
            margin: 50px;
            margin-left: 100px;
            margin-right: 100px;
            background: #293aa3;
            padding: 20px;
            padding-left: 50px;
            padding-right: 50px;
            border-radius: 30px !important;
        }

        .main {
            padding-top:50px;
        }

        input {
            color: black !important;
        }

        h1 {
            color: white;
            font-weight: bold;
            text-align: center !important;
        }

        p {
            font-size: 15.16px !important;
            text-align: center;
        }

        .danger {
            color: white !important;
        }

        .btn {
            color: white !important;
            background: none;
            width: 150px;
        }

        .register {
            background: #04a96d;
            color: white;
        }
          
        i {
            font-size: 30px;
        }

        form .form-actions {
            border-top: none;
        }

        .modal .modal-content {
            background: #293aa3 !important;
        }

        .confrim {
            font-size: 64px;
        }
    

    </style>
</head>
<script type="text/javascript">
    function login() {
        location.replace("Login.aspx")
    }
    function register() {

        $('#exampleModalCenter').modal('show');
    }
</script>
<body>
    <form id="form1" runat="server">
        <div class="main">
        <div class="row">
            <div class="col-md-12 align-self-center">
                <div class="card">
                    <asp:Button OnClick="login()"><i class="las la-arrow-circle-left"></i></asp:Button>

                    <center>
                        <img src="../../../app-assets/images/logo-1.png" alt="Appointment Management System" width="250px"></center>
                    <div class="card-header" style="border-radius: 20px">
                        <h1>Welcome!</h1>
                        <p>Register your account</p>
                    </div>
                    <div class="card-content collpase show">
                        <div class="card-body">
                            <div class="form form-horizontal form-bordered">
                                <div class="form-body">
                                    <div class="row">
                                        <div class="col-md-12 col-lg-6">
                                            <div class="form-group row">
                                                <%--<label class="col-md-6 label-control" for="userinput1">Full Name<span class="danger">*</span></label>--%>
                                                <div class="col-md-12">
                                                    <asp:TextBox ID="txtFirstName" runat="server" placeholder="enter your full name" CssClass="form-control border-primary" name="firstName"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 col-lg-6">
                                            <div class="form-group row">
                                                <%-- <label class="col-md-6 label-control">Matricola No<span class="danger">*</span></label>--%>
                                                <div class="col-md-12">
                                                    <asp:TextBox ID="txtPhoneNumber" runat="server" placeholder="enter your matricola no " name="txtPhoneNumber" CssClass="form-control border-primary" TextMode="Phone"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 col-lg-6" style="display: none;">
                                            <div class="form-group row">
                                                <label class="col-md-6 label-control" for="userinput2">Last Name</label>
                                                <div class="col-md-9">
                                                    <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control border-primary" name="lastName"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row" style="display: none;">
                                        <div class="col-md-6">
                                            <div class="form-group row last">
                                                <label class="col-md-6 label-control" for="userinput3">Date of Birth</label>
                                                <div class="col-md-9">
                                                    <asp:TextBox ID="txtDOB" runat="server" name="txtDOB" CssClass="form-control border-primary datepicker" TextMode="Date"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">

                                        <div class="col-md-6" style="display: none;">
                                            <div class="form-group row">
                                                <label class="col-md-8 label-control">Alternate Matricola </label>
                                                <div class="col-md-9">
                                                    <asp:TextBox ID="txtAltPhoneNumber" runat="server" name="txtAltPhoneNumber" CssClass="form-control border-primary" TextMode="Phone"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-12 col-lg-6">
                                            <div class="form-group row">
                                                <%-- <label class="col-md-6 label-control" for="userinput5">Email<span class="danger">*</span></label>--%>
                                                <div class="col-md-12">
                                                    <asp:TextBox ID="txtEmailAddress" runat="server" placeholder="enter your email" CssClass="form-control border-primary" type="email" name="emailAddress" TextMode="Email"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 col-lg-6">
                                            <div class="form-group row">
                                                <%-- <label class="col-md-6 label-control" for="userinput5">Password<span class="danger">*</span></label>--%>
                                                <div class="col-md-12">
                                                    <asp:TextBox ID="txtPassword" runat="server" placeholder="enter your password" CssClass="form-control border-primary" type="password" name="emailAddress" TextMode="Password"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row" style="display: none;">
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
                                    <div class="row" style="display: none;">
                                        <div class="col-md-6">
                                            <div class="form-group row last">
                                                <label class="col-md-6 label-control" for="userinput8">Notes</label>
                                                <div class="col-md-9">
                                                    <asp:TextBox ID="txtNotes" Rows="4" runat="server" CssClass="form-control border-primary" type="text" name="bio" TextMode="MultiLine"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-actions center">
                                        <input type="checkbox" name="term&condition" value="Agree term & condition" required />
                                        Agree term & condition<br /><br />
                                        <asp:Label ID="lblError" runat="server" Text="" CssClass="text-danger"></asp:Label>
                                        <asp:Button class="btn register" OnClick="register()">Register</asp:Button><br />
                                        <asp:Button class="btn" OnClick="login()">Login </asp:Button>
                                        <%--  <asp:button text="Reset" id="btnReset" onclick="btnReset_Click" cssclass="btn btn-primary" runat="server" />--%>
                                        <!-- Modal -->
                                        <div class="modal fade" id="exampleModalCenter" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
                                            <div class="modal-dialog modal-dialog-centered" role="document">
                                                <div class="modal-content">
                                                    <div class="modal-body">
                                                        <h1><i class="las la-check-circle confrim"></i></h1>
                                                        <h1>SuccessFul</h1>
                                                        <p>your registration has been completed</p>
                                                        <asp:Button Text="Continue" ID="Button1" OnClick="btnSubmit_Click" CssClass="btn register" runat="server" /><br />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
            </div>
        <script src="../../../app-assets/vendors/js/vendors.min.js" type="text/javascript"></script>
        <!-- BEGIN VENDOR JS-->
        <!-- BEGIN PAGE VENDOR JS-->
        <script src="../../../app-assets/vendors/js/ui/headroom.min.js" type="text/javascript"></script>
        <script src="../../../app-assets/vendors/js/charts/chartist.min.js" type="text/javascript"></script>
        <script src="../../../app-assets/vendors/js/charts/chartist-plugin-tooltip.min.js"
            type="text/javascript"></script>
        <script src="../../../app-assets/vendors/js/charts/raphael-min.js" type="text/javascript"></script>
        <script src="../../../app-assets/vendors/js/charts/morris.min.js" type="text/javascript"></script>
        <script src="../../../app-assets/vendors/js/timeline/horizontal-timeline.js" type="text/javascript"></script>
        <!-- END PAGE VENDOR JS-->
        <!-- BEGIN MODERN JS-->
        <script src="../../../app-assets/js/core/app-menu.js" type="text/javascript"></script>
        <script src="../../../app-assets/js/core/app.js" type="text/javascript"></script>
        <script src="../../../app-assets/js/scripts/customizer.js" type="text/javascript"></script>
        <!-- END MODERN JS-->
        <!-- BEGIN PAGE LEVEL JS-->
        <script src="../../../app-assets/js/scripts/pages/dashboard-ecommerce.js" type="text/javascript"></script>
    </form>

</body>
</html>
