<%@ Page Title="Manage Users" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ManageUser.aspx.cs" Inherits="ManageUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="wrapper">
        <div id="page-wrapper">
            <div class="container-fluid">
                <div class="col-lg-12">
                    <div class="col-lg-offset-6">
                        <button id="BANU" class="btn btn-lg btn-primary btn-block" onclick="hidepf(); return false">Add New User</button>
                    </div>
                </div>
                <script type="text/javascript">
                    function hidepf() {
                        $(".anu").toggle();
                    }
                    function hidepf1() {
                        $(".ans").toggle();
                    }
                    function hidepf3() {
                        $(".grp").toggle();
                    }
                    </script>

                <asp:Panel runat="server" ID="pnl1">
                <div class="anu" style="display:none">
                <div class="col-lg-12">
                                  <div class="panel panel-yellow"></div>
                                    <div class="col-lg-3">
                                        <div class="form-group">
                                            <asp:Label ID="Label1" runat="server" Text="Name" CssClass="panel-title"></asp:Label>
                                            <asp:TextBox ID="Name" runat="server" placeholder="Enter Name" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-lg-3">
                                        <div class="form-group">
                                            <asp:Label ID="Label2" runat="server" Text="Post" CssClass="panel-title"></asp:Label>
                                            <asp:TextBox ID="Post" runat="server" placeholder="Enter Ur Post" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-lg-3">
                                        <div class="form-group">
                                            <asp:Label ID="Label3" runat="server" Text="User ID" CssClass="panel-title"></asp:Label>
                                            <asp:TextBox ID="Email" runat="server" placeholder="Enter E-Mail" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-lg-3">
                                        <div class="form-group">
                                            <asp:Label ID="Label8" runat="server" Text="Password" CssClass="panel-title"></asp:Label>
                                            <asp:TextBox ID="Password" runat="server" placeholder="Enter Ur password 6 Digit" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                <div class="col-lg-12">
                                  <div class="panel panel-yellow"></div>
                                    <div class="col-lg-3">
                                        <div class="form-group">
                                            <asp:Label ID="lblContNo" runat="server" Text="Contact Number" CssClass="panel-title"></asp:Label>
                                            <asp:TextBox ID="ContNo" runat="server" MaxLength="10" ValidateRequestMode="Enabled" placeholder="Enter Contact Detail" CssClass="form-control" TextMode="Number"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-lg-3">
                                        <div class="form-group">
                                            <asp:Label ID="Label5" runat="server" Text="Autherize" CssClass="panel-title"></asp:Label>
                                            <asp:TextBox ID="Authen" runat="server" placeholder="Select Autherition A/F/Q/U" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-lg-3">
                                        <div class="form-group">
                                            <asp:Label ID="Label6" runat="server" Text="Department" CssClass="panel-title"></asp:Label>
                                            <asp:TextBox ID="OFMAIL" runat="server" placeholder="Dist/Section" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-lg-3">
                                        <div class="form-group">
                                            <asp:Label ID="lblRCV" runat="server" Text="District/Section" CssClass="panel-title"></asp:Label>
                                            <asp:TextBox ID="RCV" runat="server" placeholder="District/Section" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                    
                <div class="col-lg-12">
                    <div class="col-lg-offset-10">
                        <asp:Button ID="SaveUser" runat="server" Text="Store" CssClass="btn btn-lg btn-primary btn-block" OnClick="SaveUser_Click" />
                    </div>
                </div>
                    </div>
                    <div class="col-lg-12">
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:revenueConnectionString1 %>" SelectCommand="SELECT * FROM [member]"></asp:SqlDataSource>
                            <asp:GridView ID="GridView1" runat="server" RowStyle-Wrap="false" AllowPaging="True" AllowSorting="True" DataSourceID="SqlDataSource1">
                        
                                                       
                            </asp:GridView>
                        </div>
               </asp:Panel>

                <div class="col-lg-12">
                   <div class="col-lg-offset-6"> <button id="btnSession" class="btn btn-lg btn-primary btn-block" onclick="hidepf1(); return false">विधान सभा सदन & सत्र</button></div>
                </div>
                <asp:Panel runat="server" ID="pnl2">
                <div class="ans" style="display:none">
                <div class="col-lg-12">
                                  <div class="panel panel-yellow"></div>
                                    <div class="col-lg-3">
                                        <div class="form-group">
                                            <asp:Label ID="Label4" runat="server" Text="विधान सभा सदन" CssClass="panel-title"></asp:Label>
                                            <asp:TextBox ID="txtSadan" runat="server" placeholder="विधान सभा सदन" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-lg-3">
                                        <div class="form-group">
                                            <asp:Label ID="Label7" runat="server" Text="विधान सभा सत्र" CssClass="panel-title"></asp:Label>
                                            <asp:TextBox ID="txtSession" runat="server" placeholder="विधान सभा सत्र" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>                    
                <div class="col-lg-12">
                    <div class="col-lg-offset-7">
                        <asp:Button ID="btnAsmSes" runat="server" Text="Store" CssClass="btn btn-lg btn-primary btn-block" OnClick="btnAsmSes_Click" Width="100%" />
                    </div>
                </div>
                    </div>
                    <div class="col-lg-12">
                            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:revenueConnectionString1 %>" SelectCommand="SELECT * FROM [AssemblySession] ORDER BY [Assemblys], [Session]"></asp:SqlDataSource>
                            <asp:GridView ID="GridView2" runat="server" RowStyle-Wrap="false" AllowPaging="True" AllowSorting="True" DataSourceID="SqlDataSource2" AutoGenerateColumns="False">
                        
                                                       
                                <Columns>
                                    <asp:BoundField DataField="Assemblys" HeaderText="Assemblys" SortExpression="Assemblys" />
                                    <asp:BoundField DataField="Session" HeaderText="Session" SortExpression="Session" />
                                </Columns>
                                <RowStyle Wrap="False" />
                        
                                                       
                            </asp:GridView>
                        </div>
               </asp:Panel>


                <div class="col-lg-12">
                    <div class="col-lg-offset-6">
                        <button id="btnGroup" class="btn btn-lg btn-primary btn-block" onclick="hidepf3(); return false">ग्रुप</button>
                    </div>
                </div>
                <asp:Panel runat="server" ID="pnl3">
                <div class="grp" style="display:none">
                <div class="col-lg-12">
                                  <div class="panel panel-yellow"></div>
                                    <div class="col-lg-3">
                                        <div class="form-group">
                                            <asp:Label ID="Label9" runat="server" Text="ग्रुप" CssClass="panel-title"></asp:Label>
                                            <asp:TextBox ID="txtGrp" runat="server" placeholder="ग्रुप" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>                    
                <div class="col-lg-12">
                    <div class="col-lg-offset-8">
                        <asp:Button ID="btnGrp" runat="server" Text="Store" CssClass="btn btn-lg btn-primary btn-block" OnClick="btnGrp_Click" />
                    </div>
                </div>
                    </div>
                    <div class="col-lg-12">
                            <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:revenueConnectionString1 %>" SelectCommand="SELECT * FROM [MST_Group]"></asp:SqlDataSource>
                            <asp:GridView ID="GridView3" runat="server" RowStyle-Wrap="false" AllowPaging="True" AllowSorting="True" DataSourceID="SqlDataSource3" AutoGenerateColumns="False" Width="104px">
                        
                                                       
                                <Columns>
                                    <asp:BoundField DataField="GRP" HeaderText="GRP" SortExpression="GRP">
                                    <HeaderStyle Font-Bold="True" Font-Italic="True" Font-Size="Medium" />
                                    <ItemStyle Font-Italic="True" Font-Size="Medium" />
                                    </asp:BoundField>
                                </Columns>
                                <RowStyle Wrap="False" />
                        
                                                       
                            </asp:GridView>
                        </div>
               </asp:Panel>
                    
                </div>

            </div>
            
        </div>
   
</asp:Content>

