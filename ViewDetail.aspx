<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ViewDetail.aspx.cs" Inherits="ViewDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="wrapper">
        <div id="page-wrapper">

            <div class="container-fluid">

                <!-- Page Heading -->
                <div class="row">
                    <div class="col-lg-12">
                        <h1 class="page-header"> प्राप्त प्रश्‍न <small> <% =Application["Username"] %> </small>
                        </h1>
                        <ol class="breadcrumb">
                            <li>
                                प्रश्‍नो का विवरण <i class="fa fa-file-pdf-o"></i> 
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
                <div class="row">
                    <div class="col-lg-12">
                        <div class="panel-body">
                            <div class="table-responsive">
                                <asp:GridView ID="GridView1" runat="server" CssClass="table table-bordered table-hover table-striped" AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound" >
                                    <Columns>
                                        <asp:BoundField HeaderText="क्र.सं." />
                                        <asp:BoundField DataField="ques_no" HeaderText="प्रश्‍न संख्या" SortExpression="ques_no" />
                                        <asp:BoundField DataField="session" HeaderText="सत्र" SortExpression="session" />
                                        <asp:BoundField DataField="sadan" HeaderText="विधान सभा सदन" SortExpression="sadan" />
                                        <asp:BoundField DataField="relatedVibag" HeaderText="विभाग" SortExpression="relatedVibag" />
                                        <asp:BoundField DataField="quesType" HeaderText="प्रकार" SortExpression="quesType" />
                                        <asp:BoundField DataField="listed" HeaderText="सूचीबद्ध / असूचीबद्ध" SortExpression="listed" />
                                        <asp:BoundField DataField="branchdate" HeaderText="प्रश्‍न प्राप्ति दिनांक" SortExpression="branchdate" />
                                    </Columns>
                                </asp:GridView>
                                <% if(Request.QueryString["id"] == "A") { %>
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:revenueConnectionString1 %>" SelectCommand="SELECT * FROM [TotalQuestion] WHERE ([RCV] = @RCV)">
                                    <SelectParameters>
                                        <asp:SessionParameter DefaultValue="0" Name="RCV" SessionField="RCV" Type="String" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                                <% } else if(Request.QueryString["id"] == "B") { %>
                                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:revenueConnectionString1 %>" SelectCommand="SELECT * FROM [TotalAnswerG] WHERE ([RCV] = @RCV)">
                                    <SelectParameters>
                                        <asp:SessionParameter DefaultValue="0" Name="RCV" SessionField="RCV" Type="String" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                                <% } else if( Request.QueryString["id"] == "C") { %>
                                <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:revenueConnectionString1 %>" SelectCommand="SELECT * FROM  WHERE ([RCV] = @RCV)">
                                    <SelectParameters>
                                        <asp:SessionParameter DefaultValue="0" Name="RCV" SessionField="RCV" Type="String" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                                <% } %>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- /.container-fluid -->

        </div>
        <!-- /#page-wrapper -->
    </div>
</asp:Content>

