<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AnsweredQues.aspx.cs" Inherits="AnsweredQues" ClientIDMode="Static" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="expt.css" rel="stylesheet" />
    <script src="js/jquery11.js"></script>
    <script>
        $(document).ready(function () {
            $("#btnExpt").click(function (e) {
                e.preventDefault();

                //getting data from our table
                var data_type = 'data:application/vnd.ms-excel';
                var table_div = document.getElementById('table_wrapper');
                var table_html = table_div.outerHTML.replace(/ /g, '%20');

                var a = document.createElement('a');
                a.href = data_type + ', ' + table_html;
                a.download = 'exported_table_' + Math.floor((Math.random() * 9999999) + 1000000) + '.xls';
                a.click();
            });
        });

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:UpdatePanel runat="server">
        <ContentTemplate>

            <div id="wrapper">
                <div id="page-wrapper">
                    <div class="container-fluid">
                        <asp:ScriptManager runat="server" />
                        <div class="panel-body" runat="server" id="eprt1" style="background-color: black; position: fixed; height: 100%; width: 100%; z-index: 999; opacity: 0.9;" visible="false">
                            <div style="z-index: 1000; margin: 100px; width: 60%">
                                <asp:Button ID="btnclose" runat="server" Text="X" OnClick="btnclose_Click" />
                            </div>
                            <div class="table-responsive" id="table_wrapper" style="z-index: 1000; margin: 100px; width: 60%">

                                <asp:GridView ID="GridView2" CssClass="GridView" runat="server" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black" OnRowDataBound="GridView2_RowDataBound" Width="100%">
                                    <FooterStyle BackColor="#CCCCCC" />
                                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                                    <RowStyle BackColor="White" />
                                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                    <SortedAscendingHeaderStyle BackColor="#808080" />
                                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                    <SortedDescendingHeaderStyle BackColor="#383838" />
                                </asp:GridView>
                            </div>
                            <div style="z-index: 1000; margin: 100px; width: 60%">
                                <asp:Button ID="btnExpt" Text="Export" runat="server" OnClick="btnExpt_Click" />
                            </div>
                        </div>
                        <!-- Page Heading -->
                        <div class="row">
                            <div class="col-lg-12">
                                <h1 class="page-header"> राज्य सरकार को प्रेषित प्रश्नों का विवरण </h1>
                                <ol class="breadcrumb">
                                    <li>
                                        <i class="fa fa-fw fa-envelope"></i> राज्य सरकार को प्रेषित का विवरण 
                                    </li>
                                </ol>
                            </div>
                        </div>
                        <asp:Panel runat="server" ID="pnl1">
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:revenueConnectionString1 %>" SelectCommand="SELECT [QNO], [Submitted], [Session], [Assemblys], [member_name], [RCV] FROM [SQList] WHERE ([Sender] = @Sender) ORDER BY [QNO]">
                                <SelectParameters>
                                    <asp:SessionParameter DefaultValue="0" Name="Sender" SessionField="RCV" Type="String" />
                                </SelectParameters>
                            </asp:SqlDataSource>

                            <div class="row">
                                <div class="col-lg-12">
                                    <div class="panel-body">
                                        <div class="table-responsive">
                                            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound" BorderColor="Red" BorderStyle="Solid" BorderWidth="2px" CellPadding="6" CellSpacing="1" Font-Bold="True" Font-Size="Medium" ForeColor="#333333" CssClass="table table-bordered table-hover table-striped" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" >
                                                <Columns>
                                                    <asp:TemplateField HeaderText="राज्य सरकार को प्रेषित">
                                                        <ItemTemplate>
                                                            <asp:Button ID="SGGovt" runat="server" Text="राज्य सरकार को प्रेषित" CommandName="SGGovt" CommandArgument="<%#((GridViewRow) Container).RowIndex %>" CssClass="btn btn-info" Visible="false" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="Assemblys" HeaderText="विधान सभा सदन" SortExpression="Assemblys" />
                                                    <asp:BoundField DataField="Session" HeaderText="विधान सभा सत्र" SortExpression="Session" />
                                                    <asp:BoundField DataField="QNO" HeaderText="प्रश्‍न संख्या" SortExpression="QNO" />
                                                    <asp:BoundField DataField="member_name" HeaderText="शाखा का नाम" SortExpression="member_name" />
                                                    <asp:TemplateField HeaderText="प्राप्त उत्तर">
                                                        <ItemTemplate>
                                                            <div class="progress" style="display: none">
                                                                <div class="progress-bar" role="progressbar" aria-valuenow="60" aria-valuemin="0" aria-valuemax="100" style="width: <%=Session["prgb"]%>;">
                                                                    <span class="sr-only">60% Complete</span>
                                                                </div>
                                                            </div>
                                                            <asp:Button ID="btnAns" runat="server" Text="प्राप्त उत्तर" CommandName="EditButton" CommandArgument="<%#((GridViewRow) Container).RowIndex %>" Visible="false" CssClass="btn btn-info" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="विवरण">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btnExport" runat="server" Text="View Detail" CommandName="ExportButton" CommandArgument="<%#((GridViewRow) Container).RowIndex %>" CssClass="btn btn-info"></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Submitted" SortExpression="Submitted" Visible="False">
                                                        <ItemTemplate>
                                                            <asp:HiddenField ID="Label1" runat="server" Value='<%# Bind("Submitted") %>'></asp:HiddenField>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="RCV" SortExpression="RCV" Visible="False">
                                                        <ItemTemplate>
                                                            <asp:HiddenField ID="Label2" runat="server" Value='<%# Bind("RCV") %>'></asp:HiddenField>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                </Columns>

                                            </asp:GridView>
                                        </div>
                                    </div>

                                </div>
                            </div>

                        </asp:Panel>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

