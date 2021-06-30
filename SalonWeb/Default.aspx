<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SalonWeb.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Unifi Appointment Management System </title>

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
</head>
<style>
    * {
        font-family: 'Red Hat Display', sans-serif;
    }

    h1 {
        color: #293aa3;
        font-weight: 600;
    }

    p {
        font-size:16px;
    }

    .main {
        background:#293aa3;
        width: 100%;
        padding: 10px;
        padding-left:100px;
        padding-right:100px;
        height: 450px;
        margin:0 auto;
    }

    .shedow {
        background: white;
        padding: 30px;
        border-radius: 20px;
         box-shadow: rgba(0, 0, 0, 0.1) 0px 10px 15px -3px, rgba(0, 0, 0, 0.05) 0px 4px 6px -2px;
    }

   
    .btn {
        border:2px solid #293aa3;
        background:none;
        margin:10px;
        width:150px
    }
    .register {
        background: #293aa3;
        color:white;
    }
    img {
        margin:20px;
    }

   @media screen and (min-width: 720px) { 
         .reverse {
            flex-flow: wrap-reverse !important;
         }
    }

</style>
        <script type="text/javascript">
            function register() {
            location.replace("Register.aspx")
        }
            function login() {
                location.replace("Login.aspx")
            }
    </script>
<body>
    <form id="form1" runat="server">
        <div class="main">
            <center>
                <img src="../../../app-assets/images/logo-1.png" alt="Appointment Management System" width="200px"></center>
            <br />
            <br />
            <div class="container">
                <div class="row shedow">
                    <div class="col">
                        <div class="row reverse">
                            <div class="col-md-12 col-lg-6">
                                <h1>Make an Appointment</h1>
                                <br />
                                <p>
                              Unifi Appointment booking, to make this easier for students and staff members 
of university to manage appointments department wise. The user can book an appointment in any of the selected
departments right now. We have initially three departments in the list Library, Seggetaria and International desk.
                                </p>
                                <br />
                                 <asp:Button class="btn register" onclick="register()"> Register </asp:Button>
                                  <asp:Button class="btn" onclick="login()"> login </asp:Button>
                                <br />
                                <br />
                                <br />
                                <img src="../../../app-assets/images/defualt-icon.png" alt="Appointment Management System" width="80%">
                            </div>
                            <div class="col-md-12 col-lg-6">
                                <img src="../../../app-assets/images/defualtImag.png" alt="Appointment Management System" width="80%">
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>

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
