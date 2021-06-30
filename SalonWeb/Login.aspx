<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SalonWeb.Login" %>

<!DOCTYPE html>
<html class="loading" lang="en" data-textdirection="ltr">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=0, minimal-ui">
    <meta name="description" content="Modern admin is super flexible, powerful, clean &amp; modern responsive bootstrap 4 admin template with unlimited possibilities with bitcoin dashboard.">
    <meta name="keywords" content="admin template, modern admin template, dashboard template, flat admin template, responsive admin template, web app, crypto dashboard, bitcoin dashboard">
    <meta name="author" content="PIXINVENT">
    <title>Login Page - Unifi App</title>
    <link rel="apple-touch-icon" href="../../../app-assets/images/logo/salapp-crop.png">
    <link rel="shortcut icon" type="image/x-icon" href="../../../app-assets/images/logo/salapp-crop.png">
    <link href="https://fonts.googleapis.com/css?family=Open+Sans:300,300i,400,400i,600,600i,700,700i|Quicksand:300,400,500,700"
        rel="stylesheet">
    <link href="https://maxcdn.icons8.com/fonts/line-awesome/1.1/css/line-awesome.min.css"
        rel="stylesheet">
    <!-- BEGIN VENDOR CSS-->
    <link rel="stylesheet" type="text/css" href="../../../app-assets/css/vendors.css">
    <link rel="stylesheet" type="text/css" href="../../../app-assets/vendors/css/forms/icheck/icheck.css">
    <link rel="stylesheet" type="text/css" href="../../../app-assets/vendors/css/forms/icheck/custom.css">
    <!-- END VENDOR CSS-->
    <!-- BEGIN MODERN CSS-->
    <link rel="stylesheet" type="text/css" href="../../../app-assets/css/app.css">
    <!-- END MODERN CSS-->
    <!-- BEGIN Page Level CSS-->
    <link rel="stylesheet" type="text/css" href="../../../app-assets/css/core/menu/menu-types/vertical-content-menu.css">
    <link rel="stylesheet" type="text/css" href="../../../app-assets/css/core/colors/palette-gradient.css">
    <link rel="stylesheet" type="text/css" href="../../../app-assets/css/pages/login-register.css">
    <!-- END Page Level CSS-->
    <!-- BEGIN Custom CSS-->
    <link rel="stylesheet" type="text/css" href="../../../assets/css/style.css">
    <!-- END Custom CSS-->
    <link rel="preconnect" href="https://fonts.gstatic.com">
    <link href="https://fonts.googleapis.com/css2?family=Red+Hat+Display&display=swap" rel="stylesheet">

    <style>
        * {
            font-family: 'Red Hat Display', sans-serif;
        }
        .darkbg {
             background-color: #04aa6d;
            color: white;
            font-size: large;
        }

        .cardborder {
            border-radius: 25px;
            border-color: #00639A;
            background-color: #293aa3;
            
        }
        .textcolor{
            color:white;
        }
    </style>
</head>
<body class="vertical-layout vertical-content-menu 1-column   menu-expanded blank-page blank-page"
    data-open="click" data-menu="vertical-content-menu" data-col="1-column">
    <!-- ////////////////////////////////////////////////////////////////////////////-->
    <div class="app-content content" style="background: white">
        <div class="content-wrapper">
            <div class="content-header row">
            </div>
            <div class="content-body">
                <section class="flexbox-container">
                    <div class="col-12 d-flex align-items-center justify-content-center">
                        <div class="col-md-4 col-10 box-shadow-2 p-0 cardborder">
                            <div class="card border-lighten-3 m-0 cardborder">
                                <div class="card-header border-1 cardborder" style="border-radius:25px;">
                                    <div class="card-title text-center cardborder">
                                        <div class="p-1">
                                            <img src="../../../app-assets/images/logo-1.png" alt="Appointment Management System" style="max-height:170px; max-width:150px;">
                                                <br />
                                                <br />
                                                 <h1 style="color:white; font-weight:bold;">Admin Panel</h1>
                                                  <p style="color:white;">Login to your existing Account</p>
                                        </div>
                                    </div>
                                </div>
                                <div class="card-content">
                                    <div class="card-body">
                                        <form class="form-horizontal form-simple" action="#" novalidate runat="server">
                                            <fieldset class="form-group position-relative has-icon-left mb-0">
                                                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control form-control-lg input-lg" placeholder="Your Email" TextMode="Email" required></asp:TextBox>
                                                <div class="form-control-position">
                                                    <i class="ft-user"></i>
                                                </div>
                                            </fieldset>
                                            <br />
                                            <fieldset class="form-group position-relative has-icon-left">
                                                <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control form-control-lg input-lg" placeholder="Enter Password" TextMode="Password" required></asp:TextBox>
                                                <div class="form-control-position">
                                                    <i class="la la-key"></i>
                                                </div>
                                            </fieldset>
                                            <div class="form-group row">
                                                <div class="col-md-6 col-12 text-center text-md-left">
                                                    <fieldset>
                                                         <asp:CheckBox ID="chkRememberMe" runat="server"/>
                                                        <label for="remember-me" class="textcolor">&nbsp;&nbsp; Remember Me</label>
                                                    </fieldset>
                                                </div>
                                            </div>
                                            <div class="form-actions center">
                                                <asp:Button ID="btnSubmit" runat="server" class="btn darkbg" style="width:150px" Text="Login" OnClick="btnSubmit_Click" />
                                                <asp:Label ID="lblLoginFailed" runat="server" ForeColor="Red" Font-Size="Medium" Font-Bold="True" CssClass="text-center"></asp:Label>
                                            </div>
                                        </form>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </section>
            </div>
        </div>
    </div>
    <!-- ////////////////////////////////////////////////////////////////////////////-->
    <!-- BEGIN VENDOR JS-->
    <script src="../../../app-assets/vendors/js/vendors.min.js" type="text/javascript"></script>
    <!-- BEGIN VENDOR JS-->
    <!-- BEGIN PAGE VENDOR JS-->
    <script src="../../../app-assets/vendors/js/ui/headroom.min.js" type="text/javascript"></script>
    <script src="../../../app-assets/vendors/js/forms/icheck/icheck.min.js" type="text/javascript"></script>
    <script src="../../../app-assets/vendors/js/forms/validation/jqBootstrapValidation.js"
        type="text/javascript"></script>
    <!-- END PAGE VENDOR JS-->
    <!-- BEGIN MODERN JS-->
    <script src="../../../app-assets/js/core/app-menu.js" type="text/javascript"></script>
    <script src="../../../app-assets/js/core/app.js" type="text/javascript"></script>
    <!-- END MODERN JS-->
    <!-- BEGIN PAGE LEVEL JS-->
    <script src="../../../app-assets/js/scripts/forms/form-login-register.js" type="text/javascript"></script>
    <!-- END PAGE LEVEL JS-->
</body>
</html>
