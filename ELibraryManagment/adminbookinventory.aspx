<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminbookinventory.aspx.cs" Inherits="ELibraryManagment.adminbookinventory" %>

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
                                    <h4>Books Details</h4>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img src="imgs/books1.png" width="100" />
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
                                <asp:FileUpload CssClass="form-control" ID="FileUpload1" runat="server" />
                            </div>
                        </div>

                        <div class="row mt-2">

                            <div class="col-md-3">
                                <label>Book ID</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="ID"></asp:TextBox>
                                        <asp:Button CssClass="btn btn-primary btn-sm" ID="Button11" runat="server" Text="Go" />
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-9">
                                <label>Book Name</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="Book Name"></asp:TextBox>
                                </div>
                            </div>
                        </div>


                        <div class="row mt-3">

                            <div class="col-md-4">
                                <label>Language</label>
                                <div class="form-group">
                                    <asp:DropDownList CssClass="form-control" ID="DropDownList" runat="server">

                                        <asp:ListItem Text="English" Value="English"></asp:ListItem>
                                        <asp:ListItem Text="Hindi" Value="Hindi"></asp:ListItem>
                                        <asp:ListItem Text="Marathi" Value="Marathi"></asp:ListItem>
                                        <asp:ListItem Text="French" Value="French"></asp:ListItem>
                                        <asp:ListItem Text="German" Value="German"></asp:ListItem>

                                    </asp:DropDownList>
                                </div>

                                   <label class="mt-1">Publisher Name</label>
                                <div class="form-group">
                                    <asp:DropDownList CssClass="form-control" ID="DropDownList1" runat="server">

                                        <asp:ListItem Text="Publisher 1" Value="Publisher 2"></asp:ListItem>
                                        <asp:ListItem Text="Publisher 2" Value="Publisher 2"></asp:ListItem>
                                       

                                    </asp:DropDownList>
                                </div>

                            </div>
                            <div class="col-md-4">
                                
                                     <label>Author Name</label>
                                <div class="form-group">
                                    <asp:DropDownList CssClass="form-control" ID="DropDownList2" runat="server">

                                        <asp:ListItem Text="Author1" Value="Author1"></asp:ListItem>
                                        <asp:ListItem Text="Author2" Value="Author2"></asp:ListItem>
                                  
                                    </asp:DropDownList>

                                </div>

                                   <label class="mt-1">Publisher Date</label>
                                <div class="form-group">
                                  <asp:TextBox CssClass="form-control" ID="TextBox9" runat="server" placeholder="Date" TextMode="Date"></asp:TextBox>
                                </div>

                            </div>

                            <div class="col-md-4">
                                <label>Genre</label>
                                <div class="form-group">
                                   
                                    <asp:ListBox ID="ListBox1" runat="server" CssClass="form-control"> 

                                        <asp:ListItem Text="Wellness" Value="Wellness"></asp:ListItem>
                                        <asp:ListItem Text="Crime" Value="Crime"></asp:ListItem>
                                        <asp:ListItem Text="Drama" Value="Drama"></asp:ListItem>
                                        <asp:ListItem Text="Fantasy" Value="Fantasy"></asp:ListItem>
                                        <asp:ListItem Text="Horror" Value="Horror"></asp:ListItem>
                                        <asp:ListItem Text="Poetry" Value="Poetry"></asp:ListItem>
                                        <asp:ListItem Text="Art" Value="Art"></asp:ListItem>
                                        <asp:ListItem Text="Science" Value="Science"></asp:ListItem>
                                        <asp:ListItem Text="Math" Value="Math"></asp:ListItem>
                                        <asp:ListItem Text="Travel" Value="Travel"></asp:ListItem>
                                        <asp:ListItem Text="Health" Value="Health"></asp:ListItem>
                                    </asp:ListBox>

                                </div>
                            </div>
                        </div>

                                   <div class="row mt-3">
                            <div class="col-md-4">
                                <label>Edition</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox7" runat="server" placeholder="1st" ></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>Book Cost(Per Unit)</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox8" runat="server" placeholder="Book Cost(Per Unit)" ></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>Pages</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox10" runat="server" placeholder="312" ></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row mt-3">
                            <div class="col-md-4">
                                <label>Actual Stock</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="15" ></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>Current Stock</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="14" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>Issued Books</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox5" runat="server" placeholder="abc" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                        </div>


                        <div class="row mt-3">
                            <div class="col-12">
                                <label>Book Description</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox6" runat="server" placeholder="Description"  Rows="2" TextMode="MultiLine"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row mt-3">
                            <div class="col-md-4 mx-auto">
                                <asp:Button CssClass="btn btn-success w-100" ID="Button1" runat="server" Text="Add" />
                            </div>
                            <div class="col-md-4 mx-auto">
                                <asp:Button CssClass="btn btn-primary w-100" ID="Button2" runat="server" Text="Update" />
                            </div>
                            <div class="col-md-4 mx-auto">
                                <asp:Button CssClass="btn btn-danger w-100" ID="Button3" runat="server" Text="Delete" />
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
                                    <h4>Book Inventory List</h4>
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
        <a href="homepage.aspx">&lt;&lt; Back to Home</a>
        <br />
        <br />
    </div>

</asp:Content>
