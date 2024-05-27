<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminauthormanagement.aspx.cs" Inherits="ELibraryManagment.adminauthormanagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script>  
        $(document).ready(function ()
        {
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
        });
    </script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <div class="container">
        <div class="row">
            <div class="col-md-5">
                <div class="card">
                    <div class="card-body">
                       
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Author Details</h4>        
                                </center>
                            </div>

                             <div class="row">
                            <div class="col">
                                <center>
                                    <img src="imgs/writer.png" width="100" />
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
                            <div class="col-md-4">
                                <label>Author ID</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="Author ID"></asp:TextBox>

                                    <asp:Button CssClass="btn btn-dark" ID="Button11" runat="server" Text="Go" OnClick="Button11_Click" />
                                    </div>
                                    
                                </div>
                            </div>
                            <div class="col-md-8">
                                <label>Author Name</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="Author Name"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                       
                        <div class="row mt-3">
                            <div class="col-4">
                               <asp:Button CssClass="btn btn-primary w-100" ID="Button1" runat="server" Text="Add" OnClick="Button1_Click" />
                            </div>
                            <div class="col-4">
                               <asp:Button CssClass="btn btn-warning btn-block w-100" ID="Button2" runat="server" Text="Update" OnClick="Button2_Click" />
                            </div>
                            <div class="col-4">
                               <asp:Button CssClass="btn btn-danger btn-block w-100" ID="Button3" runat="server" Text="Delete" OnClick="Button3_Click" />
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
                                    <h4>Author List</h4>
                                </center>
                            </div>
                        </div>
                      

                          <div class="row">
                            <div class="col">
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:elibraryDBConnectionString %>" SelectCommand="SELECT * FROM [author_master_tbl]"></asp:SqlDataSource>
                                <asp:GridView ID="GridView1" runat="server" CssClass="table table-striped table-bordered" AutoGenerateColumns="False" DataKeyNames="author_id" DataSourceID="SqlDataSource1">
                                    <Columns>
                                        <asp:BoundField DataField="author_id" HeaderText="author_id" ReadOnly="True" SortExpression="author_id" />
                                        <asp:BoundField DataField="author_name" HeaderText="author_name" SortExpression="author_name" />
                                    </Columns>
                                </asp:GridView>
                              
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
