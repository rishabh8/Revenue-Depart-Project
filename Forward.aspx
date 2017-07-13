<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Forward.aspx.cs" Inherits="Forward" %>

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
                        <h1 class="page-header">Inbox
                        </h1>
                        <ol class="breadcrumb">
                            <li>
                                <i class="fa fa-fw fa-envelope"></i>Inbox
                            </li>
                        </ol>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-12">
                        <h4>विधान सभा सदन <%=Session["Assembly"].ToString() %> / विधान सभा सत्र <%=Session["Sessions"].ToString() %> /  प्रश्न क्रमांक <% =Session["quesno"].ToString()  %> </h4>
                    </div>

                    <div class="col-lg-12">
                        <link href="css/checkboxlist.css" rel="stylesheet" />
                        <asp:Panel ID="SectionPanel" runat="server">
                            <div class="col-lg-6">
                                <div class="form-group">
                                    <asp:Label ID="Section" runat="server" Text="सेक्शन" CssClass="panel-title" Font-Bold="true" Font-Size="X-Large"></asp:Label>
                                    <div class="divider"></div>
                                    <asp:Panel ID="Panel2" runat="server" ScrollBars="Vertical" CssClass="panel panel-primary">
                                        <asp:CheckBoxList ID="CheckBoxList2" runat="server" CssClass="checkbox" Font-Size="Medium">
                                        </asp:CheckBoxList>
                                    </asp:Panel>

                                </div>
                            </div>
                        </asp:Panel>
                        <div class="col-lg-6">
                            <div class="form-group">
                                <asp:Panel ID="DistrictPanel" runat="server">
                                    <asp:Label ID="District" runat="server" Text="जिला" CssClass="panel-title" Font-Bold="true" Font-Size="X-Large"></asp:Label>
                                    <div class="divider"></div>
                                    <asp:Panel ID="Panel3" runat="server" ScrollBars="Vertical" CssClass="panel panel-primary">
                                        <asp:CheckBoxList ID="CheckBoxList3" runat="server" CssClass="checkbox">
                                        </asp:CheckBoxList>
                                    </asp:Panel>
                                </asp:Panel>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="panel panel-yellow"></div>
                        <div class="col-lg-3">
                            <div class="form-group">
                                <asp:Label ID="Label1" runat="server" Text="शाखा मै प्रेषित क्रमांक" CssClass="panel-title"></asp:Label>
                                <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-3">
                            <div class="form-group">
                                <asp:Label ID="Label2" runat="server" Text="शाखा मै प्रेषित तिथि" CssClass="panel-title"></asp:Label>
                                <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-3">
                            <div class="form-group">
                                <asp:Label ID="Label3" runat="server" Text="जिलों मै प्रेषित क्रमांक" CssClass="panel-title"></asp:Label>
                                <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-3">
                            <div class="form-group">
                                <asp:Label ID="Label4" runat="server" Text="जिलों मै प्रेषित तिथि" CssClass="panel-title"></asp:Label>
                                <asp:TextBox ID="TextBox4" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="panel panel-yellow"></div>
                        <div class="col-lg-4">
                            <div class="form-group">
                                <asp:Label ID="Label5" runat="server" Text="अन्य विभाग को प्रेषित नाम " CssClass="panel-title"></asp:Label>
                                <asp:TextBox ID="TextBox5" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-4">
                            <div class="form-group">
                                <asp:Label ID="Label6" runat="server" Text="प्रेषित क्रमांक" CssClass="panel-title"></asp:Label>
                                <asp:TextBox ID="TextBox6" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-4">
                            <div class="form-group">
                                <asp:Label ID="Label7" runat="server" Text="प्रेषित तिथि " CssClass="panel-title"></asp:Label>
                                <asp:TextBox ID="TextBox7" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="panel panel-yellow"></div>
                        <div class="col-lg-4">
                            <div class="form-group">
                                <asp:Label ID="Label8" runat="server" Text="जवाब पूछा सम्बंधिद का नाम" CssClass="panel-title"></asp:Label>
                                <asp:TextBox ID="TextBox8" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-4">
                            <div class="form-group">
                                <asp:Label ID="Label9" runat="server" Text="जवाब पूछा क्रमांक" CssClass="panel-title"></asp:Label>
                                <asp:TextBox ID="TextBox9" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-4">
                            <div class="form-group">
                                <asp:Label ID="Label10" runat="server" Text="जवाब पूछा तिथि" CssClass="panel-title"></asp:Label>
                                <asp:TextBox ID="TextBox10" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="panel panel-yellow"></div>
                        <div class="col-lg-4">
                            <div class="form-group">
                                <asp:Label ID="Label11" runat="server" Text="जवाब प्रेषित विभाग का नाम " CssClass="panel-title"></asp:Label>
                                <asp:TextBox ID="TextBox11" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-4">
                            <div class="form-group">
                                <asp:Label ID="Label12" runat="server" Text="जवाब प्रेषित क्रमांक" CssClass="panel-title"></asp:Label>
                                <asp:TextBox ID="TextBox12" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-4">
                            <div class="form-group">
                                <asp:Label ID="Label13" runat="server" Text="जवाब प्रेषित तिथि" CssClass="panel-title"></asp:Label>
                                <asp:TextBox ID="TextBox13" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="panel panel-yellow"></div>
                        <div class="col-lg-12">
                            <div class="form-group">
                                <asp:Label ID="Label14" runat="server" Text="रिमार्क" CssClass="panel-title"></asp:Label>
                                <asp:TextBox ID="TextBox14" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="panel panel-yellow"></div>
                        <div class="col-lg-offset-11">
                            <div class="form-group">
                                <asp:Button ID="forward" runat="server" Text="Forward" CssClass="btn btn-block btn-danger" OnClick="Forward_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

