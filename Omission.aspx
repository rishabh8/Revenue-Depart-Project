<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Omission.aspx.cs" Inherits="Omission" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="wrapper">
        <div id="page-wrapper">
            <div class="container-fluid">
                <div class="row">
                    <div class="col-lg-12">
                        <div class="form-group form-inline">
                            <asp:Panel ID="Panel1" runat="server" HorizontalAlign="Center">
                                <asp:Label ID="Label1" runat="server" Text="Enter Question Number " CssClass="label label-default" Font-Size="13" ></asp:Label>
                                <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"></asp:TextBox>
                            </asp:Panel>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="form-group">
                            <asp:Panel ID="Panel2" runat="server" HorizontalAlign="Center">
                                <asp:Button ID="Button1" runat="server" Text="Check" CssClass="btn btn-block btn-primary" Width="14"/>
                            </asp:Panel>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

