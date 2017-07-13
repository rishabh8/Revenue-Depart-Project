<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Message.aspx.cs" Inherits="Message" ClientIDMode="Static" %>
<%@ Import Namespace="System" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="wrapper">
        <div id="page-wrapper">
            <div class="container-fluid">
                <!-- Page Heading -->
                <div class="row">
                    <div class="col-lg-12">
                        <h1 class="page-header">Inbox
                        </h1>
                        <ol class="breadcrumb">
                            <li>
                                <i class="fa fa-fw fa-envelope"></i>Inbox
                            </li>
                        </ol>
                    </div>
                </div>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:revenueConnectionString1 %>" SelectCommand="SELECT * FROM [MessageView] WHERE ([RCV] = @RCV)">
                    <SelectParameters>
                        <asp:SessionParameter DefaultValue="0" Name="RCV" SessionField="RCV" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>

                <div class="row">
                    <div class="col-lg-12">
                        <div class="panel-heading">
                            <h3> प्रश्‍न सूची :</h3>
                        </div>
                        <div class="panel-body">
                            <div class="table-responsive">
                                <asp:GridView ID="GridView2" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="ques_no" DataSourceID="SqlDataSource2" OnRowCommand="GridView2_RowCommand" OnRowDataBound="GridView2_RowDataBound" CellPadding="6" CellSpacing="1" CssClass="table table-bordered table-hover table-striped" PageSize="10">
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:BoundField HeaderText="क्र.सं." />
                                        <asp:BoundField DataField="ques_no" HeaderText="प्रश्‍न संख्या" ReadOnly="True" SortExpression="ques_no" />
                                        <asp:BoundField DataField="sadan" HeaderText="विधान सभा सदन" SortExpression="sadan" />
                                        <asp:BoundField DataField="session" HeaderText="सत्र" SortExpression="session" />
                                        <asp:BoundField DataField="quesType" HeaderText="प्रश्‍न प्रकार" SortExpression="quesType" />
                                        <asp:BoundField DataField="listed" HeaderText="सूचीबद्ध/असूचीबद्ध" SortExpression="listed" />
                                        <asp:BoundField DataField="listeddate" HeaderText="सूचीबद्ध दिनांक" SortExpression="listeddate" />
                                        <asp:BoundField DataField="branchdate" HeaderText="प्रश्न दर्ज दिनांक" SortExpression="branchdate" />
                                        <asp:BoundField DataField="membernames" HeaderText="सदस्य का नाम" SortExpression="membernames" />
                                        <asp:BoundField DataField="relatedVibag" HeaderText="विभाग" SortExpression="relatedVibag" />

                                        <asp:TemplateField HeaderText="मुल फाईल">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkDownload" CommandName="LinkBtn" CommandArgument="<%#((GridViewRow) Container).RowIndex %>" Text="प्रश्‍न देखें " runat="server"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="उत्तर प्रेषित करें">
                                            <ItemTemplate>
                                                <asp:Button ID="btnAns" runat="server" Text="उत्तर प्रेषित" CommandName="EditButton" CommandArgument="<%#((GridViewRow) Container).RowIndex %>" CssClass="btn btn-info"  />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="अग्रेषित करें">
                                            <ItemTemplate>
                                                <asp:Button ID="btnForward" runat="server" Text="अग्रेषित" CommandName="ForwardButton" CommandArgument="<%#((GridViewRow) Container).RowIndex %>" CssClass="btn btn-info" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:HiddenField ID="sender1" runat="server" Value='<%# Bind("Sender") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>

                        </div>
                        <% if(Session["UR"].ToString() == "U"){ %>
                        <div class="panel-heading">
                            <h3>अग्रेषित प्रश्‍न सूची :</h3>
                        </div>
                        <div class="panel-body">
                            <div class="table-responsive">
                                <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource4" CssClass="table table-bordered table-hover table-striped" OnRowCommand="GridView4_RowCommand" AllowPaging="true" AllowSorting="false" PageSize="5" OnRowDataBound="GridView4_RowDataBound">
                                    <Columns>
                                        <asp:BoundField HeaderText="क्र.सं." />
                                        <asp:BoundField DataField="quesno" HeaderText="प्रश्‍न संख्या" SortExpression="quesno" />
                                        <asp:BoundField DataField="Assemblys" HeaderText="विधान सभा सदन" SortExpression="Assemblys" />
                                        <asp:BoundField DataField="Session" HeaderText="सत्र" SortExpression="Session" />
                                        <asp:BoundField DataField="quesType" HeaderText="प्रश्‍न प्रकार" SortExpression="quesType"/>
                                        <asp:BoundField DataField="member_name" HeaderText="उत्तर प्रेषित सदस्य" SortExpression="member_name" />
                                        <asp:BoundField DataField="listed" HeaderText="सूचीबद्ध/असूचीबद्ध" SortExpression="listed" />
                                        <%--<asp:BoundField DataField="forwardto" HeaderText="forwardto" SortExpression="forwardto" />--%>
                                        <asp:TemplateField HeaderText="उत्तर प्रेषित करें">
                                            <ItemTemplate>
                                                <asp:Button ID="btnAns" runat="server" Text="उत्तर प्रेषित" CommandName="EditButton" CommandArgument="<%#((GridViewRow) Container).RowIndex %>" CssClass="btn btn-info" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    
                                </asp:GridView>
                                <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:revenueConnectionString1 %>" SelectCommand="SELECT * FROM [SenderView] WHERE ([forwardto] = @forwardto)">
                                    <SelectParameters>
                                        <asp:SessionParameter DefaultValue="0" Name="forwardto" SessionField="RCV" Type="String" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                            </div>
                        </div>
                        <% } %>
                    </div>
                    
                </div>


                <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:revenueConnectionString1 %>" SelectCommand="SELECT [ques_no], [QNO], [sadan], [session], [files_path], [quesType] FROM [SubmittedView] WHERE ([RCV] = @RCV)">
                    <SelectParameters>
                        <asp:SessionParameter DefaultValue="0" Name="RCV" SessionField="RCV" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <div class="row">
                </div>
                <div class="row">
                    <div class="col-lg-12">
                        <div class="panel-heading">
                            <h3>उत्तर प्रेषित प्रश्‍न सूची : </h3>
                        </div>
                        <div class="panel-body">
                            <div class="table-responsive">
                                
                                <asp:GridView ID="GridView3" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="ques_no" DataSourceID="SqlDataSource3" OnRowCommand="GridView3_RowCommand" OnRowDataBound="GridView3_RowDataBound" CellPadding="6" CellSpacing="1" CssClass="table table-bordered table-hover table-striped">
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:BoundField HeaderText="क्र.सं." />
                                        <asp:BoundField DataField="ques_no" HeaderText="प्रश्‍न संख्या" ReadOnly="True" SortExpression="ques_no" />
                                        <asp:BoundField DataField="sadan" HeaderText="विधान सभा सदन" SortExpression="sadan" />
                                        <asp:BoundField DataField="session" HeaderText="सत्र" SortExpression="session" />
                                        <asp:BoundField DataField="quesType" HeaderText="प्रश्‍न प्रकार" SortExpression="quesType" />
                                        
                                         <asp:TemplateField HeaderText="मुल प्रश्‍न">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkDownload" CommandName="LinkBtn" CommandArgument="<%#((GridViewRow) Container).RowIndex %>" Text="प्रश्‍न देखें" runat="server"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="उत्तर प्रेषित करें">
                                            <ItemTemplate>
                                                <asp:Button ID="btnAns" runat="server" Text="उत्तर प्रेषित" CommandName="EditButton" CommandArgument="<%#((GridViewRow) Container).RowIndex %>" CssClass="btn btn-info" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                    </Columns>                                    
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>