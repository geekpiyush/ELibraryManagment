<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="userlogin.aspx.cs" Inherits="ELibraryManagment.userlogin" %>
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
                                    <img src="imgs/generaluser.png" width="150"/>
                                </center
                            </div>
                        </div>

                           <div class="row">
                            <div class="col">
                                <center>
                                    <h3>Member Login</h3>
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

                               <lable>Member ID</lable>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Member ID"></asp:TextBox>

                                </div>

                                <lable>Password</lable>
                                 <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>

                                </div>

                                 <div class="form-group">
                                    <asp:Button ID="Button1" runat="server" Text="Login" class="btn btn-success w-100 mt-2 btn-lg" OnClick="Button1_Click"/>
                                </div>

                                 <div class="form-group">
                                    <a href="signup.aspx"><input id="Button2" type="button" value="Sign-Up"class="btn btn-primary w-100 mt-2 btn-lg" style="color:white;"/></a>
                                </div>

                            </div>
                        </div>

                    </div>

                </div>

            </div>
             <a href="homepage.aspx"><< Back to Home</a>
            <br />
            <br />

        </div>

    </div>

</asp:Content>
