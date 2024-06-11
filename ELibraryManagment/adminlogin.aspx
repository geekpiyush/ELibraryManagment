<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminlogin.aspx.cs" Inherits="ELibraryManagment.adminlogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">

        <div class="row">

            <div class="col-md-6 mx-auto">

                <div class="card">
                    <div class="card-body">

                        <div class="row">
                            <div class="col">
                                <center>
                                    <img src="imgs/adminuser.png" width="150"/>
                                </center
                            </div>
                        </div>

                           <div class="row">
                            <div class="col">
                                <center>
                                    <h3>Admin Login</h3>
                                </center>
                            </div>
                          </div>

                           <div class="row">
                            <div class="col">
                                    <hr>
                            </div>
                        </div>

                         <div class="row">
                            <div class="col">

                               <lable>Admin ID</lable>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Admin ID"></asp:TextBox>

                                </div>

                                <lable>Password</lable>
                                 <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>

                                </div>

                                 <div class="form-group">
                                    <asp:Button ID="Button1" runat="server" Text="Login" class="btn btn-success w-100 mt-2 btn-lg" OnClick="Button1_Click"/>
                                </div>
                            </div>
                        </div>

                    </div>

                </div>

            </div>
          

        </div>

    </div>

</asp:Content>
