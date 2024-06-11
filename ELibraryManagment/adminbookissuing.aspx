<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminbookissuing.aspx.cs" Inherits="ELibraryManagment.adminbookissuing" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="container-fluid">
        <div class="row">
            <div class="col-md-5">
                <div class="card">
                    <div class="card-body">
                       
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Book Issuing</h4>        
                                </center>
                            </div>

                             <div class="row">
                            <div class="col">
                                <center>
                                    <img src="imgs/books.png" width="100"/>
                                </center>
                            </div>
                        </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>

                        <div class="row">
                      
                            <div class="col-md-7">
                                <label>Member ID</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="Member ID"></asp:TextBox>
                                </div>
                            </div>

                               <div class="col-md-5">
                                <label>Book ID</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="Book ID"></asp:TextBox>

                                    <asp:Button CssClass="btn btn-dark" ID="Button11" runat="server" Text="Go" />
                                    </div>
                                    
                                </div>
                            </div>
                        </div>

                          <div class="row mt-3">
                      
                            <div class="col-md-6">
                                <label>Member Name</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Member Name" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>

                               <div class="col-md-6">
                                <label>Book Name</label>
                                <div class="form-group">
                                   
                                        <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Book Name" ReadOnly="true"></asp:TextBox>

                                    
                                </div>
                            </div>
                        </div>


                              <div class="row mt-3">
                      
                            <div class="col-md-6">
                                <label>Start Date</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox5" runat="server" placeholder="Start Date" TextMode="Date"></asp:TextBox>
                                </div>
                            </div>

                               <div class="col-md-6">
                                <label>End Date</label>
                                <div class="form-group">
                                   
                                        <asp:TextBox CssClass="form-control" ID="TextBox6" runat="server" placeholder="End Date" TextMode="Date"></asp:TextBox>

                                    
                                </div>
                            </div>
                        </div>
                       
                        <div class="row mt-3">
                            <div class="col-6">
                               <asp:Button CssClass="btn btn-primary w-100" ID="Button1" runat="server" Text="Issue" />
                            </div>
                            <div class="col-6">
                               <asp:Button CssClass="btn btn-success btn-block w-100" ID="Button2" runat="server" Text="Return" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-md-7">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Issued Book List</h4>
                                </center>
                            </div>
                        </div>
                      

                          <div class="row">
                            <div class="col">
                                <asp:GridView ID="GridView1" runat="server" CssClass="table table-striped table-bordered"></asp:GridView>
                            </div>
                        </div>

              
                    </div>
                </div>
            </div>
        </div>
      
    </div>

</asp:Content>
