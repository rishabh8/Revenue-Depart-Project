<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SendTos.aspx.cs" Inherits="SendTos" ClientIDMode="Static" %>

    <asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    </asp:Content>
    <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <div id="wrapper">
            <div id="page-wrapper">

                <div class="container-fluid">

                    <!-- Page Heading -->
                    <div class="row">
                        <div class="col-lg-12">
                            <h1 class="page-header">प्रश्‍न रिपोर्टिंग <small>(द्वितीय भाग)</small>
                            </h1>
                            <ol class="breadcrumb">
                                <li>
                                    प्रश्‍न दर्ज करें <i class="fa fa-question"></i>
                                </li>
                            </ol>
                        </div>
                    </div>
                    <!-- /.row -->

                    <div class="row">
                        <div class="col-lg-12">
                            <!-- <div class="alert alert-info alert-dismissable">
                            <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                            <i class="fa fa-info-circle"></i>  <strong>Like SB Admin?</strong> Try out <a href="http://startbootstrap.com/template-overviews/sb-admin-2" class="alert-link">SB Admin 2</a> for additional features!
                        </div> -->
                        </div>
                    </div>
                    <!-- /.row -->
                    <link href="css/checkboxlist.css" rel="stylesheet" />
                    <script src="js/jquery.min.js"></script>
                    <script type="text/javascript">
                        $(function () {
                            $("[id*=<% =selectall2.ID%>]").bind("click", function () {
                                if ($(this).is(":checked")) {
                                    $("[id*=<% =CheckBoxList2.ID%>] input").attr("checked", "checked");
                                } else {
                                    $("[id*=<% =CheckBoxList2.ID%>] input").removeAttr("checked");
                                }
                            });
                            $("[id*=<% =CheckBoxList2.ID%>] input").bind("click", function () {
                                if ($("[id*=<% =CheckBoxList2%>] input:checked").length == $("[id*=CheckBoxList2] input").length) {
                                    $("[id*=<% =selectall2%>]").attr("checked", "checked");
                                } else {
                                    $("[id*=<% =selectall2%>]").removeAttr("checked");
                                }
                            });
                        });
                    </script>
                    <script type="text/javascript">
                        $(function () {
                            $("[id*=<% =selectall3.ID%>]").bind("click", function () {
                                if ($(this).is(":checked")) {
                                    $("[id*=<% =CheckBoxList3.ID%>] input").attr("checked", "checked");
                                } else {
                                    $("[id*=<% =CheckBoxList3.ID%>] input").removeAttr("checked");
                                }
                            });
                            $("[id*=<% =CheckBoxList3.ID%>] input").bind("click", function () {
                                if ($("[id*=<% =CheckBoxList3%>] input:checked").length == $("[id*=CheckBoxList2] input").length) {
                                    $("[id*=<% =selectall3%>]").attr("checked", "checked");
                                } else {
                                    $("[id*=<% =selectall3%>]").removeAttr("checked");
                                }
                            });
                        });
                    </script>
                    <script type="text/javascript">
                        $(function () {
                            $("[id*=<% =selectall4.ID%>]").bind("click", function () {
                                if ($(this).is(":checked")) {
                                    $("[id*=<% =CheckBoxList4.ID%>] input").attr("checked", "checked");
                                } else {
                                    $("[id*=<% =CheckBoxList4.ID%>] input").removeAttr("checked");
                                }
                            });
                            $("[id*=<% =CheckBoxList4.ID%>] input").bind("click", function () {
                                if ($("[id*=<% =CheckBoxList4%>] input:checked").length == $("[id*=CheckBoxList2] input").length) {
                                    $("[id*=<% =selectall4%>]").attr("checked", "checked");
                                } else {
                                    $("[id*=<% =selectall4%>]").removeAttr("checked");
                                }
                            });
                        });
                    </script>
                    <script type="text/javascript">
                        $(function () {
                            $("[id*=<% =selectall5.ID%>]").bind("click", function () {
                                if ($(this).is(":checked")) {
                                    $("[id*=<% =CheckBoxList5.ID%>] input").attr("checked", "checked");
                                } else {
                                    $("[id*=<% =CheckBoxList5.ID%>] input").removeAttr("checked");
                                }
                            });
                            $("[id*=<% =CheckBoxList5.ID%>] input").bind("click", function () {
                                if ($("[id*=<% =CheckBoxList5%>] input:checked").length == $("[id*=CheckBoxList2] input").length) {
                                    $("[id*=<% =selectall5%>]").attr("checked", "checked");
                                } else {
                                    $("[id*=<% =selectall5%>]").removeAttr("checked");
                                }
                            });
                        });
                    </script>
                    <script type="text/javascript">
                        $(function () {
                            $("[id*=<% =selectall6.ID%>]").bind("click", function () {
                                if ($(this).is(":checked")) {
                                    $("[id*=<% =CheckBoxList6.ID%>] input").attr("checked", "checked");
                                } else {
                                    $("[id*=<% =CheckBoxList6.ID%>] input").removeAttr("checked");
                                }
                            });
                            $("[id*=<% =CheckBoxList6.ID%>] input").bind("click", function () {
                                if ($("[id*=<% =CheckBoxList6%>] input:checked").length == $("[id*=CheckBoxList2] input").length) {
                                    $("[id*=<% =selectall6%>]").attr("checked", "checked");
                                } else {
                                    $("[id*=<% =selectall6%>]").removeAttr("checked");
                                }
                            });
                        });
                    </script>

                    <div class="row">
                        <div class="col-lg-12">
                            <div class="col-lg-12">
                                <asp:Label ID="lblques" runat="server" Text=""></asp:Label>
                            </div>
                            <div class="col-lg-12">
                                <div class="form-group">
                                    <asp:Label ID="Questions" runat="server" Text="" CssClass="panel-title" Font-Bold="true" style="font-family:'DevLys 010'; font-size:19px; font-weight:bold;"></asp:Label>
                                    <div class="divider"></div>
                                    <asp:Panel ID="Panel1" runat="server" ScrollBars="Vertical" CssClass="panel panel-primary">

                                        <asp:CheckBoxList ID="CheckBoxList1" runat="server" CssClass="checkbox" Font-Size="Medium" Style="font-size:16px;font-weight:bold;"
                                            CellPadding="1" CellSpacing="1" ClientIDMode="Static">

                                        </asp:CheckBoxList>
                                    </asp:Panel>
                                </div>
                            </div>
                            <div class="col-lg-2">

                                <div class="form-group">
                                    <asp:Label ID="Section" runat="server" Text="मण्डल के विभाग" CssClass="panel-title" Font-Bold="true"></asp:Label>
                                    <div class="divider"></div>
                                    <asp:Panel ID="Panel2" runat="server" ScrollBars="Vertical" CssClass="panel panel-primary">
                                        <asp:CheckBox ID="selectall2" runat="server" CssClass="checkbox" Font-Bold="false" Style=" font-size:15px; " CellPadding="1"
                                            CellSpacing="1" Text="सभी चुने"></asp:CheckBox>
                                        <asp:CheckBoxList ID="CheckBoxList2" runat="server" CssClass="checkbox" Font-Bold="false" Style=" font-size:15px; " CellPadding="1"
                                            CellSpacing="1">

                                        </asp:CheckBoxList>
                                    </asp:Panel>
                                </div>
                            </div>
                            <div class="col-lg-2">
                                <div class="form-group">
                                    <asp:Label ID="District" runat="server" Text="जिला कलक्टर" CssClass="panel-title" Font-Bold="true"></asp:Label>
                                    <div class="divider"></div>
                                    <asp:Panel ID="Panel3" runat="server" ScrollBars="Vertical" CssClass="panel panel-primary">
                                        <asp:CheckBox ID="selectall3" runat="server" CssClass="checkbox" Font-Bold="false" Style=" font-size:15px; " CellPadding="1"
                                            CellSpacing="1" Text="सभी चुने"></asp:CheckBox>
                                        <asp:CheckBoxList ID="CheckBoxList3" runat="server" CssClass="checkbox" Style="font-size:15px;" CellPadding="1" CellSpacing="1">

                                        </asp:CheckBoxList>
                                    </asp:Panel>
                                </div>
                            </div>
                            <div class="col-lg-2">
                                <div class="form-group">
                                    <asp:Label ID="sambhagya" runat="server" Text="सम्भागीय आयुक्त" CssClass="panel-title" Font-Bold="true"></asp:Label>
                                    <div class="divider"></div>
                                    <asp:Panel ID="Panel4" runat="server" ScrollBars="Vertical" CssClass="panel panel-primary">
                                        <asp:CheckBox ID="selectall4" runat="server" CssClass="checkbox" Font-Bold="false" Style=" font-size:15px; " CellPadding="1"
                                            CellSpacing="1" Text="सभी चुने"></asp:CheckBox>
                                        <asp:CheckBoxList ID="CheckBoxList4" runat="server" CssClass="checkbox" Style="font-size:15px;" CellPadding="1" CellSpacing="1">

                                        </asp:CheckBoxList>
                                    </asp:Panel>
                                </div>
                            </div>
                            <div class="col-lg-3">
                                <div class="form-group">
                                    <asp:Label ID="RAA" runat="server" Text="राजस्व अपील प्राधिकारी" CssClass="panel-title" Font-Bold="true"></asp:Label>
                                    <div class="divider"></div>
                                    <asp:Panel ID="Panel5" runat="server" ScrollBars="Vertical" CssClass="panel panel-primary">
                                        <asp:CheckBox ID="selectall5" runat="server" CssClass="checkbox" Font-Bold="false" Style=" font-size:15px; " CellPadding="1"
                                            CellSpacing="1" Text="सभी चुने"></asp:CheckBox>
                                        <asp:CheckBoxList ID="CheckBoxList5" runat="server" CssClass="checkbox" Style="font-size:15px;" CellPadding="1" CellSpacing="1">

                                        </asp:CheckBoxList>
                                    </asp:Panel>
                                </div>
                            </div>
                            <div class="col-lg-3">
                                <div class="form-group">
                                    <asp:Label ID="so" runat="server" Text="एस0 ओ0 कम आर0 ए0 ए0" CssClass="panel-title" Font-Bold="true"></asp:Label>
                                    <div class="divider"></div>
                                    <asp:Panel ID="Panel6" runat="server" ScrollBars="Vertical" CssClass="panel panel-primary">
                                        <asp:CheckBox ID="selectall6" runat="server" CssClass="checkbox" Font-Bold="false" Style=" font-size:15px; " CellPadding="1"
                                            CellSpacing="1" Text="सभी चुने"></asp:CheckBox>
                                        <asp:CheckBoxList ID="CheckBoxList6" runat="server" CssClass="checkbox" Style="font-size:15px;" CellPadding="1" CellSpacing="1">

                                        </asp:CheckBoxList>
                                    </asp:Panel>
                                </div>
                            </div>

                        </div>

                        <div class="col-lg-12">
                            <div class="panel panel-yellow"></div>
                            <div class="col-lg-3">
                                <div class="form-group">
                                    <asp:Label ID="Label1" runat="server" Text="शाखा में प्रेषित क्रमांक" CssClass="panel-title"></asp:Label>
                                    <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <script type="text/javascript">
                                $(document).ready(function () {
                                    $("#datetimepicker1").datepicker({
                                        autoclose: true,
                                        format: 'dd-mm-yyyy',
                                        todayHighlight: true,
                                        clearBtn: true,
                                        orientation: 'bottom'
                                    });
                                });
                            </script>
                            <div class="col-lg-3">
                                <div class="form-group">
                                    <asp:Label ID="Label2" runat="server" Text="शाखा में प्रेषित दिनांक" CssClass="panel-title"></asp:Label>
                                    <div class='input-group date' id='datetimepicker1'>
                                        <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control"></asp:TextBox>
                                        <span class="input-group-addon">
                                        <span class="glyphicon glyphicon-calendar"></span>
                                        </span>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-3">
                                <div class="form-group">
                                    <asp:Label ID="Label3" runat="server" Text="जिले में प्रेषित क्रमांक" CssClass="panel-title"></asp:Label>
                                    <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <script type="text/javascript">
                                $(document).ready(function () {
                                    $("#datetimepicker2").datepicker({
                                        autoclose: true,
                                        format: 'dd-mm-yyyy',
                                        todayHighlight: true,
                                        clearBtn: true,
                                        orientation: 'bottom'
                                    });
                                });
                            </script>
                            <div class="col-lg-3">
                                <div class="form-group">
                                    <asp:Label ID="Label4" runat="server" Text="जिले में प्रेषित दिनांक" CssClass="panel-title"></asp:Label>
                                    <div class='input-group date' id='datetimepicker2'>   
                                        <asp:TextBox ID="TextBox4" runat="server" CssClass="form-control"></asp:TextBox>
                                        <span class="input-group-addon">
                                        <span class="glyphicon glyphicon-calendar"></span>
                                        </span>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-12">
                            <div class="panel panel-yellow"></div>
                            <div class="col-lg-4">
                                <div class="form-group">
                                    <asp:Label ID="Label8" runat="server" Text="उत्तर प्राप्त सम्बन्धित का नाम" CssClass="panel-title"></asp:Label>
                                    <asp:TextBox ID="TextBox8" runat="server" CssClass="form-control" Style="font-family :'DevLys 010'; font-size:19px;"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-lg-4">
                                <div class="form-group">
                                    <asp:Label ID="Label9" runat="server" Text="क्रमांक" CssClass="panel-title"></asp:Label>
                                    <asp:TextBox ID="TextBox9" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <script type="text/javascript">
                                $(document).ready(function () {
                                    $("#datetimepicker3").datepicker({
                                        autoclose: true,
                                        format: 'dd-mm-yyyy',
                                        todayHighlight: true,
                                        clearBtn: true,
                                        orientation: 'bottom'
                                    });
                                });
                            </script>
                            <div class="col-lg-4">
                                <div class="form-group">
                                    <asp:Label ID="Label10" runat="server" Text="दिनांक" CssClass="panel-title"></asp:Label>
                                    <div class='input-group date' id='datetimepicker3'>   
                                        <asp:TextBox ID="TextBox10" runat="server" CssClass="form-control"></asp:TextBox>
                                        <span class="input-group-addon">
                                        <span class="glyphicon glyphicon-calendar"></span>
                                        </span>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-12">
                            <div class="panel panel-yellow"></div>
                            <div class="col-lg-4">
                                <div class="form-group">
                                    <asp:Label ID="Label11" runat="server" Text="उत्तर प्रेषित विभाग का नाम " CssClass="panel-title"></asp:Label>
                                    <asp:TextBox ID="TextBox11" runat="server" CssClass="form-control" Style="font-family :'DevLys 010'; font-size:19px;"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-lg-4">
                                <div class="form-group">
                                    <asp:Label ID="Label12" runat="server" Text="क्रमांक" CssClass="panel-title"></asp:Label>
                                    <asp:TextBox ID="TextBox12" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <script type="text/javascript">
                                $(document).ready(function () {
                                    $("#datetimepicker4").datepicker({
                                        autoclose: true,
                                        format: 'dd-mm-yyyy',
                                        todayHighlight: true,
                                        clearBtn: true,
                                        orientation: 'bottom'
                                    });
                                });
                            </script>
                            <div class="col-lg-4">
                                <div class="form-group">
                                    <asp:Label ID="Label13" runat="server" Text="दिनांक" CssClass="panel-title"></asp:Label>
                                    <div class='input-group date' id='datetimepicker4'>    
                                        <asp:TextBox ID="TextBox13" runat="server" CssClass="form-control"></asp:TextBox>
                                        <span class="input-group-addon">
                                        <span class="glyphicon glyphicon-calendar"></span>
                                        </span>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <%--<div class="col-lg-12">
                            <div class="panel panel-yellow"></div>
                            <div class="col-lg-12"
                        </div>--%>
                            <div class="col-lg-12">
                                <div class="panel panel-yellow"></div>
                                <div class="col-lg-12">
                                    <div class="form-group">
                                        <asp:Label ID="Label14" runat="server" Text="टिप्पणी" CssClass="panel-title"></asp:Label>
                                        <asp:TextBox ID="TextBox14" runat="server" CssClass="form-control" TextMode="MultiLine" Style="font-family :'DevLys 010'; font-size:19px;"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-12">
                                <div class="panel panel-yellow"></div>
                                <div class="col-lg-offset-9">
                                    <div class="form-group">
                                        <asp:Button ID="SaveDetails" runat="server" Text="Save and Send" CssClass="btn btn-block btn-danger" OnClick="Button1_Click"
                                        />
                                    </div>
                                </div>
                            </div>

                    </div>
                </div>
                <!-- /.container-fluid -->

            </div>

        </div>
    </asp:Content>