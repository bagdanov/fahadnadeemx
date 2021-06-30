<%@ Page Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeBehind="DashBoardCustomer.aspx.cs" Inherits="SalonWeb.DashBoardCustomer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="https://fonts.googleapis.com/css?family=Open+Sans:300,300i,400,400i,600,600i,700,700i|Quicksand:300,400,500,700"
        rel="stylesheet">
    <link href="https://maxcdn.icons8.com/fonts/line-awesome/1.1/css/line-awesome.min.css"
        rel="stylesheet">
    <link rel="stylesheet" type="text/css" href="../../../app-assets/css/core/colors/palette-gradient.css">
    <style>
        .card-body {
            background: #253b9e !important;
            color: white;
        }

        h1 {
            font-weight: bold;
            color: white;
        }

        .btn {
            color: white !important;
            background: none;
            width: 150px;
        }

        .booking {
            background: #04a96d;
            color: white;
        }
    </style>
    <script src="app-assets/chartjs/Chart.js"></script>
    <script>
        function newAppointment() {
            location.replace("AppointmentForm.aspx")
        }
    </script>
    <div class="content-body" id="dashboardAdmin">
        <div class="row">
            <div class="col-xl-4 col-12">
                <div class="card pull-up">
                    <div class="card-content">
                        <div class="card-body">
                            <div class="media d-flex">
                                <div class="media-body text-center">
                                    <h3 class="info">
                                        <asp:Label ID="lblAppointments" runat="server" Text="" CssClass="info" hidden="true"></asp:Label></h3>
                                    <i><img src="app-assets/images/icons/SEGRETERIA.png" width="64px" /></i>
                                    <h1>Segreteria</h1>
                                    <p>
                                        The standard chunk of Lorem Ipsum used since the 1500s is 
                                         reproduced below for those interested. Sections 1.10.32 and 
                                         1.10.33 from "de Finibus Bonorum et Malorum" by Cicero are also 
                                         reproduced in their exact original form, accompanied by English 
                                         versions from the 1914 translation by H. Rackham  versions from the 1914 translation by H. Rackham
                                    </p>
                                    <asp:Button class="btn booking" OnClick="newAppointment()">Booking Now </asp:Button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-xl-4 col-12">
                <div class="card pull-up">
                    <div class="card-content">
                        <div class="card-body">
                            <div class="media d-flex">
                                <div class="media-body text-center">
                                    <h3 class="warning">
                                        <asp:Label ID="lblProfit" runat="server" Text="" CssClass="warning" hidden="true"></asp:Label></h3>
                                     <i><img src="app-assets/images/icons/LIBRARY.png" width="64px" /></i>
                                    <h1>Library</h1>
                                    <p>
                                        The standard chunk of Lorem Ipsum used since the 1500s is 
                                         reproduced below for those interested. Sections 1.10.32 and 
                                         1.10.33 from "de Finibus Bonorum et Malorum" by Cicero are also 
                                         reproduced in their exact original form, accompanied by English 
                                         versions from the 1914 translation by H. Rackham  versions from the 1914 translation by H. Rackham 
                                    </p>
                                    <asp:Button class="btn booking" OnClick="newAppointment()">Booking Now </asp:Button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-xl-4 col-12">
                <div class="card pull-up">
                    <div class="card-content">
                        <div class="card-body">
                            <div class="media d-flex">
                                <div class="media-body text-center">
                                    <h3 class="success">
                                        <asp:Label ID="lblIncome" runat="server" Text="" CssClass="success" hidden="true"></asp:Label></h3>
                                      <i><img src="app-assets/images/icons/INTERNATIONAL-DESK.png" width="64px" /></i>
                                    <h1>International Desk</h1>
                                    <p>
                                        The standard chunk of Lorem Ipsum used since the 1500s is 
                                         reproduced below for those interested. Sections 1.10.32 and 
                                         1.10.33 from "de Finibus Bonorum et Malorum" by Cicero are also 
                                         reproduced in their exact original form, accompanied by English 
                                         versions from the 1914 translation by H. Rackham
                                    </p>
                                    <asp:Button class="btn booking" OnClick="newAppointment()">Booking Now </asp:Button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-xl-4 col-12" style="display: none">
                <div class="card pull-up">
                    <div class="card-content">
                        <div class="card-body">
                            <div class="media d-flex">
                                <div class="media-body text-left">
                                    <h3 class="danger">
                                        <asp:Label ID="lblExpenses" runat="server" Text="" CssClass="danger"></asp:Label></h3>
                                    <h6>Monthly Expense</h6>
                                </div>
                                <div>
                                    <i class="icon-calculator danger font-large-2 float-right"></i>
                                </div>
                            </div>
                            <div class="progress progress-sm mt-1 mb-0 box-shadow-2">
                                <div class="progress-bar bg-gradient-x-danger" role="progressbar" style="width: 85%"
                                    aria-valuenow="85" aria-valuemin="0" aria-valuemax="100">
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="row match-height" style="display: none">
            <div class="col-lg-12">
                <div class="card">
                    <div class="card-content">
                        <canvas id="cvsWeeklySales" style="display: block; width: 1013px; height: 706px;" width="1013" height="706" class="chartjs-render-monitor"></canvas>
                    </div>
                </div>
            </div>
            <div class="col-xl-4 col-lg-12" style="display: none;">
                <div class="card">
                    <div class="card-content">
                        <canvas id="cvsWeeklyRevenue" style="display: block; width: 1013px; height: 706px;" width="1013" height="706" class="chartjs-render-monitor"></canvas>
                    </div>
                </div>
            </div>
            <div class="col-xl-4 col-lg-12" style="display: none;">
                <div class="card">
                    <div class="card-content">
                        <canvas id="cvsMonthly" style="display: block; width: 1013px; height: 706px;" width="1013" height="706" class="chartjs-render-monitor"></canvas>
                    </div>
                </div>
            </div>
        </div>
        <div class="row match-height" style="display: none;">
            <div class="col-12 col-lg-6">
                <div class="card">
                    <div class="card-header" style="border-radius: 20px;">
                        <a class="heading-elements-toggle"><i class="la la-ellipsis-v font-medium-3"></i></a>
                        <div class="heading-elements">
                            <ul class="list-inline mb-0">
                                <li><a class="btn btn-sm btn-danger box-shadow-2 round btn-min-width pull-right"
                                    href="AppointmentGrid.aspx" target="_blank" style="margin-top: -15px;">Approved Appointments</a></li>
                            </ul>
                        </div>
                    </div>
                    <div class="card-content">
                        <div class="table-responsive-sm">
                            <asp:Repeater runat="server" ID="rptAppointment" OnItemDataBound="rptAppointment_ItemDataBound">
                                <HeaderTemplate>
                                    <table class="table table-hover table-xl mb-0">
                                        <thead>
                                            <tr class="gridHeader">
                                                <th class="border-top-0">Name</th>
                                                <th class="border-top-0">Phone Number</th>
                                                <th class="border-top-0">Date</th>
                                            </tr>
                                        </thead>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tbody>
                                        <tr>
                                            <td class="text-truncate bg-lighten-5">
                                                <asp:Label runat="server" ID="lblCustomerName" />
                                            </td>
                                            <td class="text-truncate bg-blue  bg-lighten-4">
                                                <asp:Label runat="server" ID="lblPhoneNumber" />
                                            </td>
                                            <td class="text-truncate bg-lighten-5">
                                                <asp:Label runat="server" ID="lblDate" />
                                            </td>
                                        </tr>
                                    </tbody>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </table>
                               
                                </FooterTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-12 col-lg-6">
                <div class="card">
                    <div class="card-header" style="border-radius: 20px;">
                        <a class="heading-elements-toggle"><i class="la la-ellipsis-v font-medium-3"></i></a>
                        <div class="heading-elements">
                            <ul class="list-inline mb-0">
                                <li><a class="btn btn-sm btn-danger box-shadow-2 round btn-min-width pull-right"
                                    href="AppointmentGrid.aspx" target="_blank" style="margin-top: -15px;">Pending Appointments</a></li>
                            </ul>
                        </div>
                    </div>
                    <div class="card-content">
                        <div class="table-responsive-sm">
                            <asp:Repeater runat="server" ID="rptPendingAppointment" OnItemDataBound="rptPendingAppointment_ItemDataBound">
                                <HeaderTemplate>
                                    <table class="table table-hover table-xl mb-0">
                                        <thead>
                                            <tr class="gridHeader">
                                                <th class="border-top-0">Name</th>
                                                <th class="border-top-0">Phone Number</th>
                                                <th class="border-top-0">Date</th>
                                            </tr>
                                        </thead>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tbody>
                                        <tr>
                                            <td class="text-truncate bg-lighten-5">
                                                <asp:Label runat="server" ID="lblCustomerName" />
                                            </td>
                                            <td class="text-truncate bg-blue  bg-lighten-4">
                                                <asp:Label runat="server" ID="lblPhoneNumber" />
                                            </td>
                                            <td class="text-truncate bg-lighten-5">
                                                <asp:Label runat="server" ID="lblDate" />
                                            </td>
                                        </tr>
                                    </tbody>
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
    <script>
        $(document).ready(function () {
            LoadCharts();
        });
        function LoadCharts() {
            $.ajax({
                url: 'Salonapi.svc/GetWeeklySales?tenantID=<%=TenantID%>',
                type: "GET",
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    LoadWeeklySales(data);
                },
                error: function (xhr, ajaxOptions, thrownError) {
                    console.log(xhr.status);
                    console.log(thrownError);
                    console.log(ajaxOptions);
                }
            });

            $.ajax({
                url: 'Salonapi.svc/GetWeeklyRevenue?tenantID=<%=TenantID%>',
                type: "GET",
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    LoadWeeklyRevenue(data);
                },
                error: function (xhr, ajaxOptions, thrownError) {
                    console.log(xhr.status);
                    console.log(thrownError);
                    console.log(ajaxOptions);
                }
            });

            $.ajax({
                url: 'Salonapi.svc/GetMonthlySales?tenantID=<%=TenantID%>',
                type: "GET",
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    LoadMonthly(data);
                },
                error: function (xhr, ajaxOptions, thrownError) {
                    console.log(xhr.status);
                    console.log(thrownError);
                    console.log(ajaxOptions);
                }
            });
        }
        var barWeeklySales;
        var barWeeklyRevenue;
        var barMonthly;
        function LoadWeeklySales(data) {
            var sales = [];
            var appointments = [];
            var labels = [];
            for (var i = 0; i < data.length; i++) {
                sales.push(data[i].Sales);
                appointments.push(data[i].TotalAppointments);
                labels.push(data[i].Day);
            }
            var barWeeklySales = {
                labels: labels,
                datasets: [{
                    label: 'Appointments',
                    backgroundColor: '#EE5510',
                    borderColor: '#EE5510',
                    type: 'line',
                    fill: false,
                    borderWidth: 1,
                    stack: 'Stack 2',
                    data: appointments,
                    yAxisID: 'y-axis-2'
                }, {
                    label: 'Sales',
                    backgroundColor: '#FFBD33',
                    type: 'bar',
                    borderColor: '#FFBD33',
                    borderWidth: 1,
                    stack: 'Stack 1',
                    data: sales,
                    yAxisID: 'y-axis-1'
                }]
            }; var maxY1 = 0;
            var maxY2 = 1.6;

            var ctx = document.getElementById('cvsWeeklySales').getContext('2d');
            window.myBar = new Chart(ctx, {
                type: 'bar',
                data: barWeeklySales,
                options: {
                    title: {
                        display: true,
                    },
                    responsive: true,
                    gridLines: {
                        color: "#fff",
                        lineWidth: 2
                    },
                    tooltips: {
                        mode: 'index',
                        intersect: false,
                        callbacks: {
                            label: function (tooltipItem, data) {
                                if (data.datasets[tooltipItem.datasetIndex].label === 'Sales') {
                                    return data.datasets[tooltipItem.datasetIndex].label + ': Rs ' + tooltipItem.yLabel;
                                }
                                else {
                                    return data.datasets[tooltipItem.datasetIndex].label + ':  ' + tooltipItem.yLabel;
                                }
                            }
                        }
                    },
                    scales: {
                        xAxes: [{
                            gridLines: {
                                display: false,
                            }
                        }],
                        yAxes: [{
                            type: 'linear', // only linear but allow scale type registration. This allows extensions to exist solely for log scale for instance
                            position: 'left',
                            id: 'y-axis-1',
                            stacked: true,
                            gridLines: {
                                display: false,
                            }
                        },
                        {
                            type: 'linear', // only linear but allow scale type registration. This allows extensions to exist solely for log scale for instance
                            position: 'right',
                            id: 'y-axis-2',
                            stacked: true,
                            gridLines: {
                                display: false,
                            }
                        }]
                    }
                }
            });
        }

        function LoadWeeklyRevenue(data) {
            var sales = [];
            var expense = [];
            var profit = [];
            var labels = [];
            for (var i = 0; i < data.length; i++) {
                sales.push(data[i].Sales);
                expense.push(data[i].Expense);
                profit.push(data[i].Profit);
                labels.push(data[i].Day);
            }
            var barWeeklyRevenue = {
                labels: labels,
                datasets: [{
                    label: 'Sales',
                    backgroundColor: '#FFBD33',
                    borderColor: '#FFBD33',
                    borderWidth: 1,
                    data: sales
                }, {
                    label: 'Expense',
                    backgroundColor: '#3346FF',
                    borderColor: '#3346FF',
                    borderWidth: 1,
                    data: expense
                }, {
                    label: 'Profit',
                    backgroundColor: '#AAAAA0',
                    borderColor: '#AAAAA0',
                    borderWidth: 1,
                    data: profit
                }]
            };
            var ctx = document.getElementById('cvsWeeklyRevenue').getContext('2d');
            window.myBar = new Chart(ctx, {
                type: 'bar',
                data: barWeeklyRevenue,
                options: {
                    responsive: true,
                    legend: {
                        position: 'top',
                    },
                    chartArea: {
                        backgroundColor: 'rgba(0, 85, 85, 0.4)'
                    },
                    tooltips: {
                        mode: 'index',
                        intersect: false,
                        callbacks: {
                            label: function (tooltipItem, data) {
                                return data.datasets[tooltipItem.datasetIndex].label + ': Rs ' + tooltipItem.yLabel;
                            }
                        }
                    }
                }
            });
        }

        function LoadMonthly(data) {
            var sales = [];
            var expense = [];
            var profit = [];
            var labels = [];
            for (var i = 0; i < data.length; i++) {
                sales.push(data[i].Sales);
                expense.push(data[i].Expense);
                profit.push(data[i].Profit);
                labels.push(data[i].Month);
            }
            var barMonthly = {
                labels: labels,
                datasets: [{
                    label: 'Sales',
                    backgroundColor: '#FFBD33',
                    borderColor: '#FFBD33',
                    borderWidth: 1,
                    data: sales
                }, {
                    label: 'Expense',
                    backgroundColor: '#3346FF',
                    borderColor: '#3346FF',
                    borderWidth: 1,
                    data: expense
                }, {
                    label: 'Profit',
                    backgroundColor: '#AAAAA0',
                    borderColor: '#AAAAA0',
                    borderWidth: 1,
                    data: profit
                }]
            };
            var ctx = document.getElementById('cvsMonthly').getContext('2d');
            window.myBar = new Chart(ctx, {
                type: 'bar',
                data: barMonthly,
                options: {
                    responsive: true,
                    legend: {
                        position: 'top',
                    }, tooltips: {
                        mode: 'index',
                        intersect: false,
                        callbacks: {
                            label: function (tooltipItem, data) {
                                return data.datasets[tooltipItem.datasetIndex].label + ': Rs ' + tooltipItem.yLabel;
                            }
                        }
                    }
                }
            });
        }
    </script>
</asp:Content>
