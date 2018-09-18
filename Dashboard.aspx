<%@ Page Title="DashBoard" Language="C#" AutoEventWireup="true" CodeFile="Dashboard.aspx.cs" MasterPageFile="~/MasterPage.master" Inherits="Dashboard" ClientIDMode="Static" %>
<%@ Import Namespace="System.Data.SqlClient" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="wrapper">
        <div id="page-wrapper">

            <div class="container-fluid">

                <!-- Page Heading -->
                <div class="row">
                    <div class="col-lg-12">
                        <h1 class="page-header"> Dashboard <small> Overview </small>
                        </h1>
                        <ol class="breadcrumb">
                            <li>
                                <i class="fa fa-dashboard"></i>Dashboard
                            </li>
                        </ol>
                    </div>
                </div>
                <!-- /.row -->

               <%-- <div class="row">
                    <div class="col-lg-12">
                        <div class="alert alert-info alert-dismissable">
                            <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                            <i class="fa fa-info-circle"></i><strong>Like SB Admin?</strong> Try out <a href="http://startbootstrap.com/template-overviews/sb-admin-2" class="alert-link">SB Admin 2</a> for additional features!
                        </div>
                    </div>
                </div>--%>
                <!-- /.row -->
                
                <%  SqlDataReader reader = DataConnection.selectQuery("select * from member where admin='A' and memeberid=" + Convert.ToInt32(Session["RCV"].ToString()));
                    if (reader.HasRows)
                    {
                        %>

                <div class="row">
                    <div class="col-lg-4 col-md-6">
                        <div class="panel panel-primary">
                            <div class="panel-heading">
                                <div class="row">
                                    <div class="col-xs-3">
                                        <i class="fa fa-question fa-5x"></i>
                                    </div>
                                    <div class="col-xs-9 text-right">
                                        <div class="huge">
                                            <asp:Label ID="TotalQuesC" runat="server" Text=""></asp:Label>
                                        </div>
                                        <div style="font-size:20px"> कुल प्रश्‍न प्राप्त </div>
                                    </div>
                                </div>
                            </div>
                            <a href="ViewDetail.aspx?id=E">
                                <div class="panel-footer">
                                    <span class="pull-left">विवरण</span>
                                    <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                                    <div class="clearfix"></div>
                                </div>
                            </a>
                        </div>
                    </div>
                    <div class="col-lg-4 col-md-6">
                        <div class="panel panel-green">
                            <div class="panel-heading">
                                <div class="row">
                                    <div class="col-xs-3">
                                        <i class="fa fa-comments fa-5x"></i>
                                    </div>
                                    <div class="col-xs-9 text-right">
                                        <div class="huge">
                                            <asp:Label ID="TotalAnswerC" runat="server" Text=""></asp:Label>

                                        </div>
                                        <div style="font-size:20px">उत्तर प्रेषित</div>
                                    </div>
                                </div>
                            </div>
                            <a href="ViewDetail.aspx?id=F">
                                <div class="panel-footer">
                                    <span class="pull-left">विवरण</span>
                                    <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                                    <div class="clearfix"></div>
                                </div>
                            </a>
                        </div>
                    </div>
                    <div class="col-lg-4 col-md-6">
                        <div class="panel panel-red">
                            <div class="panel-heading">
                                <div class="row">
                                    <div class="col-xs-3">
                                        <i class="fa fa-comments fa-5x"></i>
                                    </div>
                                    <div class="col-xs-9 text-right">
                                        <div class="huge">
                                            <asp:Label ID="TotalAnswerNC" runat="server" Text=""></asp:Label>

                                        </div>
                                        <div style="font-size:20px">लम्बित प्रश्‍न</div>
                                    </div>
                                </div>
                            </div>
                            <a href="ViewDetail.aspx?id=F">
                                <div class="panel-footer">
                                    <span class="pull-left">विवरण</span>
                                    <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                                    <div class="clearfix"></div>
                                </div>
                            </a>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="col-lg-4 col-md-6">
                        <div class="panel panel-yellow">
                            <div class="panel-heading">
                                <div class="row">
                                    <div class="col-xs-3">
                                        <i class="fa fa-question fa-5x"></i>
                                    </div>
                                    <div class="col-xs-9 text-right">
                                        <div class="huge">
                                            <asp:Label ID="AnswerP" runat="server" Text=""></asp:Label>
                                        </div>
                                        <div style="font-size:18px"> उत्तर प्राप्त करने हेतु प्रेषित प्रश्‍न </div>
                                    </div>
                                </div>
                            </div>
                            <a href="ViewDetail.aspx?id=E">
                                <div class="panel-footer">
                                    <span class="pull-left">विवरण</span>
                                    <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                                    <div class="clearfix"></div>
                                </div>
                            </a>
                        </div>
                    </div>
                    <div class="col-lg-4 col-md-6">
                        <div class="panel panel-white" style="background-color:brown;color:white;">
                            <div class="panel-heading">
                                <div class="row">
                                    <div class="col-xs-3">
                                        <i class="fa fa-comments fa-5x"></i>
                                    </div>
                                    <div class="col-xs-9 text-right">
                                        <div class="huge">
                                            <asp:Label ID="AnswerPrat" runat="server" Text=""></asp:Label>

                                        </div>
                                        <div style="font-size:18px">प्राप्त उत्तर</div>
                                    </div>
                                </div>
                            </div>
                            <a href="ViewDetail.aspx?id=F">
                                <div class="panel-footer" style="color:brown">
                                    <span class="pull-left">विवरण</span>
                                    <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                                    <div class="clearfix"></div>
                                </div>
                            </a>
                        </div>
                    </div>
                    <div class="col-lg-4 col-md-6">
                        <div class="panel panel-white" style="background-color:darkkhaki;color:white;">
                            <div class="panel-heading">
                                <div class="row">
                                    <div class="col-xs-3">
                                        <i class="fa fa-comments fa-5x"></i>
                                    </div>
                                    <div class="col-xs-9 text-right">
                                        <div class="huge">
                                            <asp:Label ID="NonAnswered" runat="server" Text=""></asp:Label>

                                        </div>
                                        <div style="font-size:18px">अप्राप्त उत्तर</div>
                                    </div>
                                </div>
                            </div>
                            <a href="ViewDetail.aspx?id=F">
                                <div class="panel-footer" style="color:darkkhaki">
                                    <span class="pull-left">विवरण</span>
                                    <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                                    <div class="clearfix"></div>
                                </div>
                            </a>
                        </div>
                    </div>
                    </div>
                </div>
                <% }
                   SqlDataReader reader2 = DataConnection.selectQuery("select * from member where admin='F' and memeberid=" + Convert.ToInt32(Session["RCV"].ToString()));
                   if(reader2.HasRows)
                   {
                       
                     %>
                    <div class="row">
                    <div class="col-lg-4 col-md-6">
                        <div class="panel panel-primary">
                            <div class="panel-heading">
                                <div class="row">
                                    <div class="col-xs-3">
                                        <i class="fa fa-question fa-5x"></i>
                                    </div>
                                    <div class="col-xs-9 text-right">
                                        <div class="huge">
                                            <asp:Label ID="TotalSectionQuestionR" runat="server" Text=""></asp:Label>
                                        </div>
                                        <div style="font-size:20px"> कुल प्रश्‍न प्राप्त </div>
                                    </div>
                                </div>
                            </div>
                            <a href="ViewDetail.aspx?id=E">
                                <div class="panel-footer">
                                    <span class="pull-left">विवरण</span>
                                    <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                                    <div class="clearfix"></div>
                                </div>
                            </a>
                        </div>
                    </div>
                    <div class="col-lg-4 col-md-6">
                        <div class="panel panel-green">
                            <div class="panel-heading">
                                <div class="row">
                                    <div class="col-xs-3">
                                        <i class="fa fa-comments fa-5x"></i>
                                    </div>
                                    <div class="col-xs-9 text-right">
                                        <div class="huge">
                                            <asp:Label ID="TotalSectionA" runat="server" Text=""></asp:Label>

                                        </div>
                                        <div style="font-size:20px">उत्तर प्रेषित</div>
                                    </div>
                                </div>
                            </div>
                            <a href="ViewDetail.aspx?id=F">
                                <div class="panel-footer">
                                    <span class="pull-left">विवरण</span>
                                    <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                                    <div class="clearfix"></div>
                                </div>
                            </a>
                        </div>
                    </div>
                    <div class="col-lg-4 col-md-6">
                        <div class="panel panel-red">
                            <div class="panel-heading">
                                <div class="row">
                                    <div class="col-xs-3">
                                        <i class="fa fa-comments fa-5x"></i>
                                    </div>
                                    <div class="col-xs-9 text-right">
                                        <div class="huge">
                                            <asp:Label ID="DifferentLeftSection" runat="server" Text=""></asp:Label>

                                        </div>
                                        <div style="font-size:20px">लम्बित प्रश्‍न</div>
                                    </div>
                                </div>
                            </div>
                            <a href="ViewDetail.aspx?id=F">
                                <div class="panel-footer">
                                    <span class="pull-left">विवरण</span>
                                    <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                                    <div class="clearfix"></div>
                                </div>
                            </a>
                        </div>
                    </div>
                </div>

            <div class="row">
                    <div class="col-lg-4 col-md-6">
                        <div class="panel panel-yellow">
                            <div class="panel-heading">
                                <div class="row">
                                    <div class="col-xs-3">
                                        <i class="fa fa-question fa-5x"></i>
                                    </div>
                                    <div class="col-xs-9 text-right">
                                        <div class="huge">
                                            <asp:Label ID="TotalQusF" runat="server" Text=""></asp:Label>
                                        </div>
                                        <div style="font-size:18px"> उत्तर प्राप्त करने हेतु प्रेषित प्रश्‍न </div>
                                    </div>
                                </div>
                            </div>
                            <a href="ViewDetail.aspx?id=E">
                                <div class="panel-footer">
                                    <span class="pull-left">विवरण</span>
                                    <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                                    <div class="clearfix"></div>
                                </div>
                            </a>
                        </div>
                    </div>
                    <div class="col-lg-4 col-md-6">
                        <div class="panel panel-white" style="background-color:brown;color:white;">
                            <div class="panel-heading">
                                <div class="row">
                                    <div class="col-xs-3">
                                        <i class="fa fa-comments fa-5x"></i>
                                    </div>
                                    <div class="col-xs-9 text-right">
                                        <div class="huge">
                                            <asp:Label ID="TotalQusFA" runat="server" Text=""></asp:Label>

                                        </div>
                                        <div style="font-size:18px">प्राप्त उत्तर</div>
                                    </div>
                                </div>
                            </div>
                            <a href="ViewDetail.aspx?id=F">
                                <div class="panel-footer" style="color:brown">
                                    <span class="pull-left">विवरण</span>
                                    <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                                    <div class="clearfix"></div>
                                </div>
                            </a>
                        </div>
                    </div>
                    <div class="col-lg-4 col-md-6">
                        <div class="panel panel-white" style="background-color:darkkhaki;color:white;">
                            <div class="panel-heading">
                                <div class="row">
                                    <div class="col-xs-3">
                                        <i class="fa fa-comments fa-5x"></i>
                                    </div>
                                    <div class="col-xs-9 text-right">
                                        <div class="huge">
                                            <asp:Label ID="DifferentQF" runat="server" Text=""></asp:Label>

                                        </div>
                                        <div style="font-size:18px">अप्राप्त उत्तर</div>
                                    </div>
                                </div>
                            </div>
                            <a href="ViewDetail.aspx?id=F">
                                <div class="panel-footer" style="color:darkkhaki">
                                    <span class="pull-left">विवरण</span>
                                    <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                                    <div class="clearfix"></div>
                                </div>
                            </a>
                        </div>
                    </div>
                    </div>

                <%
                    }
                    SqlDataReader read3 = DataConnection.selectQuery("select * from member where admin='U' and memeberid=" + Convert.ToInt32(Session["RCV"].ToString()));
                    if(read3.HasRows)
                    {
                     %>

                <div class="row">
                    <div class="col-lg-4 col-md-6">
                        <div class="panel panel-primary">
                            <div class="panel-heading">
                                <div class="row">
                                    <div class="col-xs-3">
                                        <i class="fa fa-question fa-5x"></i>
                                    </div>
                                    <div class="col-xs-9 text-right">
                                        <div class="huge">
                                            <asp:Label ID="totalQues" runat="server" Text=""></asp:Label>
                                        </div>
                                        <div style="font-size:x-large">कितने प्रश्‍न आये</div>
                                    </div>
                                </div>
                            </div>
                            <a href="ViewDetail.aspx?id=A">
                                <div class="panel-footer">
                                    <span class="pull-left">View Details</span>
                                    <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                                    <div class="clearfix"></div>
                                </div>
                            </a>
                        </div>
                    </div>
                    <div class="col-lg-4 col-md-6">
                        <div class="panel panel-green">
                            <div class="panel-heading">
                                <div class="row">
                                    <div class="col-xs-3">
                                        <i class="fa fa-comments fa-5x"></i>
                                    </div>
                                    <div class="col-xs-9 text-right">
                                        <div class="huge">
                                            <asp:Label ID="leftQues" runat="server" Text=""></asp:Label>

                                        </div>
                                        <div style="font-size:x-large">कितने जवाब दिए </div>
                                    </div>
                                </div>
                            </div>
                            <a href="ViewDetail.aspx?id=B">
                                <div class="panel-footer">
                                    <span class="pull-left">View Details</span>
                                    <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                                    <div class="clearfix"></div>
                                </div>
                            </a>
                        </div>
                    </div>
                    <div class="col-lg-4 col-md-6">
                        <div class="panel panel-yellow">
                            <div class="panel-heading">
                                <div class="row">
                                    <div class="col-xs-3">
                                        <i class="fa fa-question-circle fa-5x"></i>
                                    </div>
                                    <div class="col-xs-9 text-right">
                                        <div class="huge">
                                            <asp:Label ID="leftQuestion" runat="server" Text=""></asp:Label>
                                        </div>
                                        <div style="font-size:x-large">लम्बित प्रश्‍न</div>
                                    </div>
                                </div>
                            </div>
                            <a href="ViewDetail.aspx?id=C">
                                <div class="panel-footer">
                                    <span class="pull-left">View Details</span>
                                    <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                                    <div class="clearfix"></div>
                                </div>
                            </a>
                        </div>
                    </div>
                </div>
                <!-- /.row -->
                <% } %>

            <div class="row">
                <% if(Session["UR"].ToString() == "A") { %>
                <div class="col-lg-12">
                    <div class="col-lg-12" style="padding: 0px;border: solid 2px brown">
                        <div class="col-lg-12">
                            <marquee><h4 style="color: brown">Un-Send Question List </h4></marquee>
                        </div>
                        <div class="col-lg-12">
                            <div class="form-group">
                                <div class="table-responsive">
                                    <asp:GridView ID="GridView1" runat="server" CssClass="table table-bordered table-hover table-striped" DataSourceID="SqlDataSource1" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound">
                                        <Columns>
                                            <asp:BoundField HeaderText="क्र.सं." />
                                            <asp:BoundField DataField="ques_no" HeaderText="प्रश्‍न संख्या" SortExpression="ques_no" />
                                            <asp:BoundField DataField="sadan" HeaderText="विधान सभा सदन" SortExpression="sadan" />
                                            <asp:BoundField DataField="session" HeaderText="विधान सभा सत्र" SortExpression="session" />
                                            <asp:BoundField DataField="revenueQuesNo" HeaderText="राजस्व विभाग पत्र क्रमांक" SortExpression="revenueQuesNo" />
                                            <asp:BoundField DataField="relatedVibag" HeaderText="सम्बधित विभाग" SortExpression="relatedVibag" />
                                            <asp:BoundField DataField="quesType" HeaderText="प्रश्‍न प्रकार" SortExpression="quesType" />
                                            <asp:BoundField DataField="listed" HeaderText="सूचीबद्ध / असूचीबद्ध" SortExpression="listed" />
                                            <asp:BoundField DataField="listeddate" HeaderText="सूचीबद्ध होने की तिथि" SortExpression="listeddate" />
                                            <asp:BoundField DataField="branchdate" HeaderText="प्रश्‍न प्राप्ति दिनांक" SortExpression="branchdate" />
                                            <asp:BoundField DataField="membernames" HeaderText="सदस्य का नाम" SortExpression="membernames" />
                                            <asp:TemplateField HeaderText="Action">
                                                <ItemTemplate>
                                                    <asp:Button ID="btn1" Text="Send TO" runat="server" CssClass="btn btn-info" CommandArgument="<%#((GridViewRow) Container).RowIndex %>" CommandName="SendButton" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:revenueConnectionString1 %>" SelectCommand="select ques_no,sadan,session,revenueQuesNo,relatedVibag,quesType,listed,listeddate,branchdate,membernames from question
where (ques_no not in (select QNO from Message) or session not in (select Session from Message) or sadan not in (select Assemblys from Message) ) and memberno=2"></asp:SqlDataSource>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <% } %>
            </div>
                
                <!-- /.row -->

                
                <!-- /.row -->

            </div>
            <!-- /.container-fluid -->

        </div>
        <!-- /#page-wrapper -->
</asp:Content>
