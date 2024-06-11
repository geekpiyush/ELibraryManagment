<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="signup.aspx.cs" Inherits="ELibraryManagment.signup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="container">

        <div class="row">

            <div class="col-md-8 mx-auto">

                <div class="card">
                    <div class="card-body">

                        <div class="row">
                            <div class="col">
                                <center>
                                    <img src="imgs/generaluser.png" width="100"/>
                                </center
                            </div>
                        </div>

                           <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Member Sign Up</h4>
                                </center>
                            </div>
                          </div>

                           <div class="row">
                            <div class="col">
                                    <hr>
                            </div>
                        </div>



                          <div class="row">
                            <div class="col-md-6">
                                   <lable>Full Name</lable>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="Full Name"></asp:TextBox>
                                </div>  
                            </div>

                             <div class="col-md-6">
                                     <lable>Date of Birth</lable>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="Member ID" TextMode="Date"></asp:TextBox>

                                </div>
                             </div>
                        </div>

                              <div class="row mt-2">
                            <div class="col-md-6">
                                   <lable>Contact Number</lable>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Contact Number" TextMode="Number"></asp:TextBox>
                                </div>  
                            </div>

                             <div class="col-md-6">
                                     <lable>Email ID</lable>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Email ID" TextMode="Email"></asp:TextBox>

                                </div>
                             </div>
                        </div>

                       <div class="row mt-2">
                            <div class="col-md-4">
                                   <lable>State</lable>
                                <div class="form-group">
                                    <asp:DropDownList CssClass="form-control" ID="DropDownList1" runat="server">
                                        <asp:ListItem Text="Select" Value="select"></asp:ListItem>
                                        <asp:ListItem Text="Delhi" Value="Delhi"></asp:ListItem>
                                        <asp:ListItem Text="Uttar Pradesh" Value="Uttar Pradesh"></asp:ListItem>
                                        <asp:ListItem Text="Bihar" Value="Bihar"></asp:ListItem>
                                        <asp:ListItem Text="Maharashtra" Value="Maharashtra"></asp:ListItem>
                                    </asp:DropDownList>
                                   </div>  
                            </div>

                             <div class="col-md-4">
                                     <lable>City</lable>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox6" runat="server" placeholder="City" TextMode="SingleLine"></asp:TextBox>

                                </div>
                             </div>

                           
                             <div class="col-md-4">
                                     <lable>Pincode</lable>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox7" runat="server" placeholder="Pincode" TextMode="Number"></asp:TextBox>

                                </div>
                             </div>

                        </div>

                              <div class="row mt-2">
                            <div class="col">
                                   <lable>Full Address</lable>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox5" runat="server" placeholder="Full Address" TextMode="MultiLine" Rows="2"></asp:TextBox>
                                </div>  
                            </div>
                        </div>


                         <div class="row mt-3">
                             <center>
                                  <div class="col">
                                <span class="badge rounded-pill bg-info text-dark text-center">Login Credentials</span> 
                            </div>
                             </center>
                           
                          </div>


                           <div class="row mt-1">
                            <div class="col-md-6">
                                   <lable>User ID</lable>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox8" runat="server" placeholder="User ID" TextMode="SingleLine"></asp:TextBox>
                                </div>  
                            </div>

                             <div class="col-md-6">
                                     <lable>Password</lable>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox9" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>

                                </div>
                             </div>
                        </div>


                         <div class="row mt-2">
                            <div class="col">

                                 <div class="form-group">
                                    
                                     <asp:Button CssClass="btn btn-success w-100" ID="Button1" runat="server"
                                  Text="Sign Up" OnClick="Button1_Click" />
                                </div>

                            </div>
                        </div>

                    </div>

                </div>

            </div>
            

        </div>

    </div>

</asp:Content>
