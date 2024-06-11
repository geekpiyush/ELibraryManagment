<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminpublishermanagement.aspx.cs" Inherits="ELibraryManagment.adminpublishermanagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script>  
             $(document).ready(function () {
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
                                    <h4>Publisher Details</h4>        
                                </center>
                            </div>

                             <div class="row">
                            <div class="col">
                                <center>
                                    <img src="imgs/publisher.png" width="100" />
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
                            <div class="col-md-5">
                                <label>Publisher ID</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="Publisher ID"></asp:TextBox>

                                    <asp:Button CssClass="btn btn-dark" ID="Button11" runat="server" Text="Go" OnClick="Button11_Click" />
                                    </div>
                                    
                                </div>
                            </div>
                            <div class="col-md-7">
                                <label>Publisher Name</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="Publisher Name"></asp:TextBox>
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
                                    <h4>Publisher List</h4>
                                </center>
                            </div>
                        </div>
                      

                          <div class="row">
                            <div class="col">
                                
                                 <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:elibraryDBConnectionString %>" SelectCommand="SELECT * FROM [publisher_master_tbl]"></asp:SqlDataSource>
                                <asp:GridView ID="GridVie12" runat="server" CssClass="table table-striped table-bordered" AutoGenerateColumns="False" DataKeyNames="publisher_id" DataSourceID="SqlDataSource2">
                                    <Columns>
                                        <asp:BoundField DataField="publisher_id" HeaderText="publisher_id" ReadOnly="True" SortExpression="publisher_id" />
                                        <asp:BoundField DataField="publisher_name" HeaderText="publisher_name" SortExpression="publisher_name" />
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
